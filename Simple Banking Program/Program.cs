using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_Banking_Program
{
    internal class Program
    {



        static void Main(string[] args)
        {
            
            
            


            int currentPage = 0; // lets program know where it prints rn
            int checkedEntries = 0; // declared and init. for registerPageManager, its here on main aswell cuz of the poor code design
            double currentPageMultiplier = 1; // default is mainMultiplier

            string[] dataHolder = new string[6]; // declared and init. for file handling

            Console.CursorVisible = false;

            Console.Title = "SharpBank";




            PageManager(ref currentPage, ref currentPageMultiplier, ref dataHolder, ref checkedEntries);
        }

        static void PageManager(ref int currentPage, ref double currentPageMultiplier, ref string[] dataHolder, ref int checkedEntries)
        {





            int countOfCurrentRows = 5;

            // dont forget to update corresponding part when you want to change the amount of rows in any menu

            const int countOfMainPageRows = 5;
            string[] mainPageTitles = new string[countOfMainPageRows]
            {
                "Login",
                "Register",
                "Support",
                "Filler Page",
                "EXIT"
            };
            const int countOfLoginPageRows = 5;
            string[] loginPageTitles = new string[countOfLoginPageRows]
            {
                "Enter Username",
                "Enter Password",
                "Enter Your Banking Number",
                "Login!",
                " <- BACK"
            };


            const int countOfRegisterPageRows = 6;
            string[] registerPageTitles = new string[countOfRegisterPageRows]
            {
                "Username",
                "Password",
                "Password",
                "Phone Number",
                "Register",
                " <- BACK"
            };

            const int countOfSupportPageRows = 5;
            string[] supportPageTitles = new string[countOfSupportPageRows]
            {
                "Call us",
                "Message us",
                "Fill form",
                "Mail us",
                " <- BACK"
            };


            const int countOfFillerPageRows = 5;
            string[] fillerPageTitles = new string[countOfFillerPageRows]
            {
                "Filler option!",
                "Filler option 2!",
                "Filler option 3!",
                "Filler option 4!",
                " <- BACK"
            };




            string[] currentPageTitles = new string[6]
            {
                "",
                "",
                "",
                "",
                "",
                ""
            };


            // currently useless
            // might stay useless in the future aswell! 
            double mainMultiplier = 1;
            double loginMultiplier = 10;
            double registerMultiplier = 100;
            double supportMultiplier = 1000;
            double fillerMultiplier = 10000;



            // helps with giving the true values of each page 
            if (currentPage == 0)
            {

                for (int i = 0; i < countOfMainPageRows; i++)
                {
                    currentPageTitles[i] = mainPageTitles[i];
                }
                countOfCurrentRows = countOfMainPageRows;
            }
            else if (currentPage == 1)
            {

                for (int i = 0; i < countOfLoginPageRows; i++)
                {
                    currentPageTitles[i] = loginPageTitles[i];
                }
                countOfCurrentRows = countOfLoginPageRows;
            }
            else if (currentPage == 2)
            {

                for (int i = 0; i < countOfRegisterPageRows; i++)
                {
                    currentPageTitles[i] = registerPageTitles[i];
                }
                countOfCurrentRows = countOfRegisterPageRows;
            }
            else if (currentPage == 3)
            {

                for (int i = 0; i < countOfSupportPageRows; i++)
                {
                    currentPageTitles[i] = supportPageTitles[i];
                }
                countOfCurrentRows = countOfSupportPageRows;
            }

            else if (currentPage == 4)
            {

                for (int i = 0; i < countOfFillerPageRows; i++)
                {
                    currentPageTitles[i] = fillerPageTitles[i];
                }
                countOfCurrentRows = countOfFillerPageRows;
            }

            //          PRINTING/refreshing
            PagePrinter(countOfCurrentRows, currentPageTitles, ref currentPage, ref currentPageMultiplier, ref dataHolder, ref checkedEntries);



        }

        static void PagePrinter(int amountOfRows, string[] currentPageTitles, ref int currentPage, ref double currentPageMultiplier, ref string[] dataHolder, ref int checkedEntries)
        {
            int currentRow = 0; // stands for Y axis
                                //current page>  |0:Main Page|1:Login Page|2:Register Page|3:Support Page|4:Filler Page|5:EXIT Page|





            // havent use x axis yet 

            // printing format:
            //
            //      ( 0) 
            //      .
            //      .
            //      .
            //      .
            //      ( +y)  




            // makes sure that program prints each title one by one
            int cycler = 0;


            while (true)

            {


                while (cycler < amountOfRows)
                {


                    if (cycler == currentRow)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;

                        // prints titles, prints cursor and input values in "input titles"
                        if (currentPageMultiplier == 100)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write(currentPageTitles[cycler]);
                            if (cycler < 4)
                            {
                                Console.Write("-> ");

                            }

                            if (cycler >= 2)
                            {
                                Console.Write(dataHolder[cycler - 1]);
                                if (cycler == 2)
                                {
                                    Console.WriteLine(" <----This should be same with this");
                                }
                                else
                                {
                                    Console.WriteLine("");
                                }
                            }
                            else
                            {
                                Console.WriteLine(dataHolder[cycler]);

                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine(currentPageTitles[cycler]);
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;



                    }
                    else
                    {


                        if ((currentPageMultiplier == 100) && (cycler < 4))
                        {
                            Console.Write(currentPageTitles[cycler] + "-> ");

                            if (cycler >= 2)
                            {
                                Console.WriteLine(dataHolder[cycler - 1]);
                            }
                            else
                            {
                                Console.WriteLine(dataHolder[cycler]);
                            }
                        }
                        else
                        {
                            Console.WriteLine(currentPageTitles[cycler]);
                        }
                    }

                    cycler++;
                    //Console.WriteLine(currentPageMultiplier); //WIP
                    //Console.WriteLine(currentRow);            //WIP

                }
                currentRow = UpdateCurrentRowAndPage(currentRow, amountOfRows, ref currentPage, ref currentPageMultiplier, ref dataHolder, ref checkedEntries);
                cycler = 0;
                Console.Clear();

            }




        }


        // moves cursor handles inputs for pages 
        static int UpdateCurrentRowAndPage(int currentRow, int amountOfRows, ref int currentPage, ref double currentPageMultiplier, ref string[] dataHolder, ref int checkedEntries)
        {

            var key = Console.ReadKey().Key;


            if (key == ConsoleKey.DownArrow)
            {


                if (currentRow < amountOfRows - 1)
                {
                    currentRow++;
                }
                else
                {
                    currentRow = 0;
                }
            }
            else if (key == ConsoleKey.UpArrow)
            {
                if (currentRow > 0)
                {
                    currentRow--;
                }
                else
                {
                    currentRow = amountOfRows - 1;
                }
            }
            else if (key == ConsoleKey.Enter)

            {
                if (currentRow == amountOfRows - 1)
                {
                    if (currentPage == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Are you sure that you want to exit from the app?");
                        Environment.Exit(0);
                    }
                    else
                    {
                        checkedEntries = 0;
                        currentPage = 0;
                        currentPageMultiplier = 1;
                        for (int i = 0; i <= 3; i++)
                        {
                            dataHolder[i] = "";
                        }
                    }



                }
                else
                {
                    // each page has its own unique multiplier value 
                    if (currentPageMultiplier == 10)
                    {
                        LoginPageHandler(ref currentRow, ref dataHolder, ref checkedEntries);
                    }
                    else if (currentPageMultiplier == 100)
                    {
                        registerPageHandler(ref currentRow, ref dataHolder, ref checkedEntries);
                    }
                    else
                    {
                        currentPage = (currentRow * Convert.ToInt32(currentPageMultiplier)) + 1;
                        currentPageMultiplier = Math.Pow(10, currentPage); // tried to give each page its own multiplier that way
                                                                           // i can easily access them via arithmetic operations
                                                                           // sadly, seems like it didnt work that well



                        //Console.WriteLine("#####"+currentPageMultiplier);
                        //Console.ReadLine();
                        Console.Clear();

                    }
                }


                Console.Clear();
                
                PageManager(ref currentPage, ref currentPageMultiplier, ref dataHolder, ref checkedEntries);



            }

            
            return currentRow;

        }



        static void LoginPageHandler(ref int currentRow, ref string[] dataHolder, ref int checkedEntries)
        {
            bool isCorrect = false;
            switch (currentRow)
            {
                case 0:
                    bool isExist;

                    do
                    {

                        Console.Clear();
                        Console.WriteLine("Enter ur username...");
                        string userNameHolder = Console.ReadLine();
                        int lineOfTerm;

                        readRecord(userNameHolder, "testing.txt", 1, out isExist, out lineOfTerm);
                        if (!isExist)
                        {
                            Console.WriteLine("Wrong username please enter again!\nPress enter to continue...");
                            Console.ReadLine();

                        }
                        else
                        {
                            Console.WriteLine("Correct username!\nPress enter to continue...");
                            dataHolder[0] = userNameHolder;
                            checkedEntries++;
                            Console.ReadLine();
                        }
                    } while (!isExist);



                    break;

                case 1:

                    do
                    {
                        
                        Console.Clear();
                        Console.WriteLine("Enter ur password...");
                        string passwordHolder = Console.ReadLine();
                       
                        string password = "";
                        checkPassword(dataHolder[0], out password);
                        if (passwordHolder.Equals(password)) 
                        {
                            dataHolder[1] = passwordHolder;
                            checkedEntries++;
                            Console.WriteLine("Correct Password!");
                            Console.ReadLine();

                        }
                        else
                        {
                            Console.WriteLine("Wrong Password!\nPress enter to continue...");
                            Console.ReadLine();
                        }
                    } while (isCorrect);





                    break;
                case 2:



                    do
                    {

                        Console.Clear();
                        Console.WriteLine("Enter ur banking number...");
                        string bankingNumberHolder = Console.ReadLine();
                        int lineOfTerm;
                        int lineOfTermHolder;

                        readRecord(bankingNumberHolder, "testing.txt", 4, out isExist, out lineOfTermHolder); // checks if that bankingNumber exists in db 
                        if (isExist)
                        {
                            readRecord(dataHolder[0], "testing.txt", 1, out isExist, out lineOfTerm); // compares the username with that banking number
                            if (lineOfTerm == lineOfTermHolder)
                            {
                                dataHolder[3] = bankingNumberHolder; // puts user's bankingnumber to dataholder for storing later uses 
                                checkedEntries++;
                                Console.WriteLine("Correct Bank Number!\nPress enter to continue...");
                                Console.ReadLine();
                            }


                        }
                        else
                        {
                            Console.WriteLine("Wrong Bank Number!\nPress enter to continue...");
                            Console.ReadLine();
                        }
                    } while (!isExist);




                    break;

                case 3:
                    //Console.WriteLine("checkedEntries:" + checkedEntries);
                    //Console.ReadLine();
                    if (checkedEntries == 3)
                    {
                        Console.WriteLine("You have Successfuly entered to ur account\nPress Enter To Continue... ");
                        checkedEntries = 0;
                        Console.ReadLine();
                        bankPageHandler(dataHolder[3]);
                        
                    }
                    else if (checkedEntries >= 3)
                    {
                        Console.WriteLine("There was a mistake your checked entries is:" + checkedEntries);
                        Console.ReadLine();
                        checkedEntries = 0;
                    }
                    else
                    {
                        Console.WriteLine("There was probably a mistake!: checkedentries:" + checkedEntries);
                        Console.ReadLine();
                        checkedEntries = 0;
                    }


                    break;



                default:
                    break;
            }
        }


        static void registerPageHandler(ref int currentRow, ref string[] dataHolder, ref int checkedEntries)
        {
            bool isValid = false;



            string userNameHolder;
            string passwordHolder;
            string passwordHolderCheck;
            string phoneNumber;



            switch (currentRow)
            {

                case 0:


                    do      // we should prevent user inputting any values with coma because we're using csv files for our data management 
                    {
                        
                        Console.Clear();
                        Console.WriteLine("Enter ur username...");
                        userNameHolder = Console.ReadLine();
                        if (userNameHolder == "-1") // -1 exits from input screen
                        {

                            break;
                        }

                        else
                        {
                            bool isExist;
                            int lineOfTerm;
                            readRecord(userNameHolder, "testing.txt", 1, out isExist, out lineOfTerm);// checks if username already exists
                            if (userNameHolder.Length >= 16 || userNameHolder.Length <= 4)
                            {
                                isValid = false;
                                Console.WriteLine("Username should be longer than 4 and shorter than 16");
                                Thread.Sleep(1200);
                            }
                            else if (isExist)
                            {
                                // it already exists
                                Console.WriteLine("That user name is already taken please try something else!");
                                Thread.Sleep(1200);
                            }
                            else
                            {
                                if(userNameHolder.Contains(','))
                                {
                                    Console.WriteLine("You cant have ',' in your username please fix that!\nPress Enter To Continue...");
                                    Console.ReadLine();
                                    
                                }
                                else
                                {
                                    
                                dataHolder[0] = userNameHolder;
                                checkedEntries++;
                                isValid = true;
                                }
                            }


                        }
                    }
                    while (!isValid);


                    break;

                case 1:


                    do
                    {

                        Console.Clear();
                        Console.WriteLine("Enter ur password...");
                        passwordHolder = Console.ReadLine();
                        if (passwordHolder == "-1")
                        {

                            break;
                        }

                        else
                        {
                            if(passwordHolder.Length<3 && passwordHolder.Length > 24)
                            {
                                Console.WriteLine("Your password should be longer than 3 and shorter than 24\nPress Enter To Continue...");
                                Console.ReadLine();

                            }
                            else
                            {
                                if(passwordHolder.Contains(","))
                                {
                                    Console.WriteLine("You cant have ',' in your password please fix that!\nPress Enter To Continue...");
                                    Console.ReadLine();
                                }

                                else
                                {
                                    
                                dataHolder[1] = passwordHolder;
                            checkedEntries++;
                            isValid = true;
                                }
                            }


                        }
                    }
                    while (!isValid);


                    break;
                case 2:


                    do
                    {

                        Console.Clear();
                        Console.WriteLine("Enter ur password...");
                        passwordHolderCheck = Console.ReadLine();
                        if (passwordHolderCheck == "-1")
                        {

                            break;
                        }

                        else
                        {

                            if (dataHolder[1] == passwordHolderCheck)
                            {
                                checkedEntries++;
                                isValid = true;
                            }
                            else
                            {
                                Console.WriteLine("Two passwords are different!");
                                Console.WriteLine("|First one is:" + dataHolder[1] + "|\t|Second one is:" + passwordHolderCheck + "|");
                                Console.WriteLine("Press enter to continue");
                                Console.ReadLine();
                            }



                        }
                    }
                    while (!isValid);




                    break;
                case 3:



                    do
                    {

                        Console.Clear();
                        Console.WriteLine("Enter ur phone number...");
                        phoneNumber = Console.ReadLine();
                        if (phoneNumber == "-1")
                        {

                            break;
                        }

                        else
                        {
                            if(phoneNumber.Contains(","))
                            {
                                Console.WriteLine("You cant have ',' in your phonenumber please fix that!\nPress Enter To Continue...");
                                Console.ReadLine();
                            }
                            else if(!isOnlyDigit(phoneNumber))
                            {
                                Console.WriteLine("Phone numbers should only have digits in them, please fix that!\nPress Enter To Continue...");
                                Console.ReadLine();
                            }
                            else
                            {
                                
                            dataHolder[2] = phoneNumber;
                            checkedEntries++;
                            isValid = true;
                            }


                        }
                    }
                    while (!isValid);


                    break;

                case 4:
                    if (checkedEntries == 4)
                    {
                        bool isExist=true;
                        int lineOfTerm = 4;
                        dataHolder[3] = randomBankNumber();
                        while (isExist)
                        {
                            //Console.WriteLine("isExist of register page");
                            //Thread.Sleep(1000);
                            readRecord(dataHolder[3], "testing.txt", 1, out isExist, out lineOfTerm);
                            if(isExist)
                            {
                                dataHolder[3] = randomBankNumber();
                            }
                        }
                        addRecord(dataHolder[0], dataHolder[1], dataHolder[2], dataHolder[3], "testing.txt");
                        checkedEntries = 0;
                        Console.WriteLine("Values are successfully added to the file!\nPress Enter To Continue...");

                        addBankRecord(dataHolder[3],"0", "test2.txt");
                        Console.WriteLine("Bank_account2: done!");


                        for (int i = 0; i <= 3; i++)
                        {
                            dataHolder[i] = "";
                        }
                        //Console.ReadLine();
                    }
                    else
                    {
                        if (checkedEntries > 4)
                        {
                            for (int i = 0; i <= 3; i++)
                            {
                                dataHolder[i] = "";
                                checkedEntries = 0;
                            }
                        }
                        // added a statement which checks for inputing values into file safely and as a whole!!
                        // that way preventing any serious mistakes from happening with the cost of making things harder for user 
                        Console.WriteLine("Please complete all of the entries before trying again!   |" + checkedEntries + " out of 4|");
                        Console.WriteLine("Press Enter To Continue...");
                        for (int i = 0; i <= 3; i++)
                        {
                            dataHolder[i] = "";
                        }
                        //checkedEntries = 0;
                        //Console.ReadLine();
                    }
                    break;


                default:
                    break;
            }
        }






        // reads values from files, i'll use this for checking usernames and making other important
        // logical parts of code
        public static string[] readRecord(string searchTerm, string filepath, int positionOfSearchTerm, out bool isExist, out int lineOfTerm)
        {
            positionOfSearchTerm--;
            string[] recordNotFound = { "Record Not Found!" };

            try
            {
                string[] lines = System.IO.File.ReadAllLines(@filepath);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    if (recordMatches(searchTerm, fields, positionOfSearchTerm))
                    {
                        //Console.WriteLine("Record found!");
                        isExist = true;
                        lineOfTerm = i;
                        return fields;

                    }
                }
                isExist = false;
                lineOfTerm = -99;
                return recordNotFound;

            }
            catch (Exception ex)
            {
                Console.WriteLine("This program made an error while reading records!");
                isExist = false;
                lineOfTerm = -99;
                return recordNotFound;
                throw new ApplicationException("This program made an error while reading records!", ex);
            }


        }

        public static bool recordMatches(string searchTerm, string[] record, int positionOfSearchTerm)
        {
            if (record[positionOfSearchTerm].Equals(searchTerm))
            {
                return true;
            }
            return false;
        }




        public static void addRecord(string userName, string passWord, string phoneNumber, string bankNumber, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    file.WriteLine(userName + "," + passWord + "," + phoneNumber + "," + bankNumber);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program made a mistaaaaaaake!: ", ex);
            }
        }


        // this function has to check if that banking number already exists otherwise there would be serious issue 
        static string randomBankNumber()
        {
            string last;
            int[] temp = new int[10];
            int lastButInt = 0;
            Random rnd = new Random();
            temp[0] = 1;
            temp[1] = 3;
            for (int i = 2; i < temp.Length; i++)
            {
                temp[i] = rnd.Next(0, 9);



            }

            for (int i = 0; i < temp.Length; i++)
            {
                lastButInt = lastButInt + (temp[i] * Convert.ToInt32(Math.Pow(10, 9 - i)));
            }
            Console.WriteLine(lastButInt);
            Console.ReadLine();
            last = Convert.ToString(lastButInt);
            return last;

        }


        // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        // ||||||||||||||||||||||||||||||||||||               ---------------                ||||||||||||||||||||||||||||||||||||||||||||||||||||
        // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        // ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||



        // i had to rewrite many functions into NEW functions because of the poor designing chooses
        
        
        static void bankPageHandler(string bankNumber)
        {
            Console.Clear();
            int currentDirection=0;
            int currentRow = 2;
            //int currentPage = 0;
            int amountOfOptions = 3;
            bool isEntered;


            //// start screen!
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;

            Console.Write(" [ ] ");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Money Transactions");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;


            Console.WriteLine("      Past Transactions");
            Console.WriteLine("      Interest Page");
            //////////////////////////////////////////////////////

            while (true)
            {

                
                currentDirection =bankPageInputs(currentDirection);
                currentRow = rowCalc(currentRow, amountOfOptions, currentDirection, out isEntered);

                // money transaction

                // past transactions

                // interest page

                //logout!  this will be added later!


                switch (currentRow)
                {
                    case 2:
                        if (isEntered)
                        {
                            //Console.WriteLine("currentRow:" + currentRow);
                            
                            transferingPage(currentRow, bankNumber);
                        }

                     
                        
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.Gray;

                        Console.Write(" [ ] ");

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Money Transactions");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;


                        Console.WriteLine("      Past Transactions");
                        Console.WriteLine("      Interest Page");


                        break;

                    case 1:
                        if (isEntered)
                        {
                            checkAndPrintPast(bankNumber);
                        }
                        Console.Clear();
                        Console.WriteLine("      Money Transactions");

                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write(" [ ] ");

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Past Transactions");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;

                        Console.WriteLine("      Interest Page");
                        break;

                    case 0:
                        if (isEntered)
                        {
                            
                            InterestHandler(bankNumber);
                        }
                        Console.Clear();
                        Console.WriteLine("      Money Transactions");
                        Console.WriteLine("      Past Transactions");

                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.Gray;

                        Console.Write(" [ ] ");

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;

                        Console.WriteLine("Interest Page");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;




                        break;



                    default: break;
                }



                
                //transferingPage(currentRow, bankNumber);
                //Console.WriteLine("Current Row Is: "+currentRow);
            }

            








        }

        static int bankPageInputs(int currentDirection)
        {



            var key = Console.ReadKey().Key;


            if (key == ConsoleKey.DownArrow)
            {


                currentDirection = -1;
            }
        
            else if (key == ConsoleKey.UpArrow)
            {
                currentDirection= +1;
            }
            else if(key == ConsoleKey.Enter) 
            {
                currentDirection = -555;
            }
            return currentDirection;
        }


        // dont forget to uncomment this section!

        static void transferingPage(int currentRow, string bankNumber)
        {
            string folder = @"transactions";
            string textFile = "";
            bool isDone = false;
            int checkedEntries=0;
            currentRow = 4;
            Console.Clear();
            bool isEntered;
            string[] dataHolder = new string[5];
            bool isExit = false;
            const int amountOfOptions = 5;
            /////////////////////// default screen!
            

            // i didnt want to create new dynamic menu printer function, code will get longer but this way its easier to handle exceptions/bugs
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;

            Console.Write(" [ ] ");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Enter the receiver account's Bank Number");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;


            Console.WriteLine("      Enter the amount which you want to send");
            Console.WriteLine("      Enter your password");
            Console.WriteLine("      Do you confirm?");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("      <-EXIT");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            /////////////////////////////////////////////////////////////////

            string pastTransactionSender="ERROR";
            string pastTransactionReceiver="ERROR";
            bool isBalanceOkay = false;
            string balanceText = "";
            while (!isExit)

            { 
                
                

                
                int currentDirection=bankPageInputs(currentRow);
                currentRow=rowCalc(currentRow,amountOfOptions, currentDirection,out isEntered);
                Console.Clear();
                if(isEntered)
                {



                    if(currentRow==4)
                    {
                        
                        while (!isDone)
                        {


                        isDone=false;
                        Console.WriteLine("Enter the reciever account's bank number...");
                        dataHolder[0]=Console.ReadLine();

                            if (isOnlyDigit(dataHolder[0]))
                            {
                                isDone = true;
                            checkedEntries++;
                            }
                            else
                            {
                                Console.WriteLine("You cant enter anything other than numbers");
                            }
                        }

                        isDone = false;

                    }
                    else if(currentRow==3)
                    {
                        bool isExitRowTwo = false;
                        isBalanceOkay=false;

                        while (!isBalanceOkay && !isExitRowTwo)
                        {
                            // gonna add exit shortcut/key 


                            Console.WriteLine("Enter the amount you want to send...");
                            dataHolder[1] = Console.ReadLine();


                            if (isOnlyDigit(dataHolder[1]))
                            {



                                pastTransactionSender = "| "+ bankNumber+"(YOU) " + " -> sent -> " + dataHolder[1] + "$ to " + dataHolder[0];
                                pastTransactionReceiver = "| " + dataHolder[0]+"(YOU) " + " <- received <- " + dataHolder[1] + "$ from " + bankNumber;
                                int currentBalance = 0;
                                int moneyToSend = Convert.ToInt32(dataHolder[1]);
                                checkBankRecord(bankNumber, out currentBalance);
                                //Console.WriteLine(moneyToSend);
                                //Console.WriteLine("currentbalance:" + currentBalance);
                                if (currentBalance >= moneyToSend)
                                {
                                    currentBalance = currentBalance - moneyToSend;
                                    balanceText = Convert.ToString(currentBalance);
                                    isBalanceOkay = true;
                                    isExitRowTwo = true;
                                    checkedEntries++;

                                }
                                else
                                {
                                    Console.WriteLine("Your balance is not enough for this transaction!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("You cant enter anything other than numbers!");
                            }
                        }


                    }
                    else if (currentRow == 2)
                    {
                        Console.WriteLine("Enter ur password...");
                        dataHolder[2] = Console.ReadLine();
                        checkedEntries++;
                    }
                    else if(currentRow==1)
                    {
                        if (checkedEntries==3)
                        {

                            if(isBalanceOkay)
                            {
                                int receiverBalance = 0;
                                int moneyToReceive = 0;



                                // sender
                                editBankRecord(bankNumber, balanceText, "test2.txt");




                                //receiver
                                moneyToReceive= Convert.ToInt32(dataHolder[1]);

                                checkBankRecord(dataHolder[0], out receiverBalance);

                                receiverBalance = moneyToReceive + receiverBalance;
                                dataHolder[1]= Convert.ToString(receiverBalance);

                                editBankRecord(dataHolder[0], dataHolder[1], "test2.txt");

                                //sender
                                textFile = bankNumber + ".txt";
                                pastTransactionWriter(pastTransactionSender, folder, textFile);

                                //receiver
                                textFile = dataHolder[0] + ".txt";
                                pastTransactionWriter(pastTransactionReceiver, folder, textFile);



                                Console.WriteLine("You've successfuly made the transaction!\nPress any key to continue");
                                Console.ReadKey();

                                // defaulting checkedentries
                                checkedEntries = 0;

                            }
                            


                            
                            
                        }
                        else
                        {
                            Console.WriteLine("There Was a mistake!!!!\nPress any key to continue :"+checkedEntries);
                            checkedEntries = 0;

                            Console.ReadKey();
                        }


                    }

                    else if(currentRow==0)
                    {
                        isExit = true;
                        checkedEntries = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            dataHolder[i] = "";
                        }
                    }
                }




                Console.Clear();
                switch (currentRow)
                {
                    case 4:

                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.Gray;

                        Console.Write(" [ ] ");

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Enter the receiver account's Bank Number");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;
                        
                        
                        Console.WriteLine("      Enter the amount which you want to send");
                        Console.WriteLine("      Enter your password");
                        Console.WriteLine("      Do you confirm?");

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("      <-EXIT");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;

                        break;

                    case 3:
                        Console.WriteLine("      Enter the receiver account's Bank Number");

                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write(" [ ] ");

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Enter the amount which you want to send");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;

                        Console.WriteLine("      Enter your password");
                        Console.WriteLine("      Do you confirm?");


                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("      <-EXIT");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;

                        break;

                    case 2:
                        Console.WriteLine("      Enter the receiver account's Bank Number");
                        Console.WriteLine("      Enter the amount which you want to send");

                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.Gray;

                        Console.Write(" [ ] ");

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;

                        Console.WriteLine("Enter your password");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;

                        Console.WriteLine("      Do you confirm?");


                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("      <-EXIT");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;



                        break;





                    case 1:
                        Console.WriteLine("      Enter the receiver account's Bank Number");
                        Console.WriteLine("      Enter the amount which you want to send");
                        Console.WriteLine("      Enter your password");

                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.Gray;

                        Console.Write(" [ ] ");

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Do you confirm?");
                        
                        

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("      <-EXIT");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;





                        break;

                    case 0:

                        Console.WriteLine("      Enter the receiver account's Bank Number");
                        Console.WriteLine("      Enter the amount which you want to send");
                        Console.WriteLine("      Enter your password");

                       
                        Console.WriteLine("      Do you confirm?");


                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.BackgroundColor = ConsoleColor.Gray;

                        Console.Write(" [ ] ");

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("<-EXIT");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.Black;

                        break;


                    default: break;
                }





            }
                checkedEntries = 0;


        }


        static int rowCalc(int currentRow, int amountOfOptions, int currentDirection, out bool isEntered)
        {
            // have to take a look further look into this part
            isEntered = false;
            if(currentDirection!=-555)
            {
                int temp = currentRow + currentDirection;

                if (temp <= (amountOfOptions - 1) && temp > 0)
                {
                    currentRow = temp;
                    //Console.WriteLine("Current row in first if::::::"+ currentRow);
                }
                else if (temp < 0)
                {

                    currentRow = (amountOfOptions - 1);
                    //Console.WriteLine("Current Row in else if||||||||||" + currentRow);

                }

                else
                {
                    currentRow = 0;
                }
                
                isEntered = false;
                return currentRow;

            }
            else
            {
            isEntered = true;
            currentDirection = 0;
                

                return currentRow;
           

                
            }


        }




        public static void addBankRecord(string bankNumber,string amountOfMoney ,string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    file.WriteLine(bankNumber + "," + amountOfMoney);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("This program made a mistaaaaaaake!: ", ex);
            }
        }


        static void editBankRecord(string bankNumber,string changedMoney, string filepath)
        {
            string tempFile = "temp.txt";
            bool isEdited = false;
            



            try
            {
                string[] everyline = System.IO.File.ReadAllLines(filepath);

                for (int i = 0; i < everyline.Length; i++)
                {
                    //Console.WriteLine("ITS FINE!!!!");
                    //Console.ReadKey();
                    string[] eachPlace = everyline[i].Split(',');
                    //Console.WriteLine("????????FINE!!!!");
                    //Console.ReadKey();
                    if (eachPlace[0].Equals(bankNumber))
                    {
                        Console.WriteLine("if:" + eachPlace[0]);
                        Console.ReadKey();

                        if (!isEdited)
                        {
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(tempFile, true))
                            {
                                file.WriteLine(bankNumber + "," + changedMoney);
                            }

                            isEdited = true;
                        }
                    }
                    else
                    {
                        //Console.WriteLine("else:" + eachPlace[0] + "_" + eachPlace[1]);
                        //Console.ReadKey();
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(tempFile, true))
                        {
                            file.WriteLine(eachPlace[0] + "," + eachPlace[1]);
                        }
                    }
                }


                File.Delete(filepath);

                File.Move(tempFile, filepath);
                Console.WriteLine("Done!");
                Console.ReadKey();



            }
            catch (Exception ex)
            {

                throw new ApplicationException("This program made a mistaaaaaaake!: ", ex);
            }

            
        }

        static void checkBankRecord(string bankNumber,out int currentBalance)
        {
            bool isRead = false;
            currentBalance = 0;
            try
            {
                string[] everyline = System.IO.File.ReadAllLines("test2.txt");



                for (int i = 0; i < everyline.Length; i++)
                {
                    string[] eachPlace = everyline[i].Split(',');

                    if (eachPlace[0].Equals(bankNumber)&& !isRead)
                    {

                        currentBalance = Convert.ToInt32(eachPlace[1]);
                        
                        
                        
                    }


                }
                

            }
            catch (Exception ex)
            {

                throw new ApplicationException("This program made a mistaaaaaaake!: ", ex);
            }
        }

        static void checkPassword(string username, out string password)
        {
            bool isRead = false;
            password = "";
            try
            {
                string[] everyline = System.IO.File.ReadAllLines("testing.txt");



                for (int i = 0; i < everyline.Length; i++)
                {
                    string[] eachPlace = everyline[i].Split(',');

                    if (eachPlace[0].Equals(username) && !isRead)
                    {

                        password = eachPlace[1];



                    }


                }
                

            }
            catch (Exception ex)
            {

                throw new ApplicationException("This program made a mistaaaaaaake!: ", ex);
            }
        }



        static bool isOnlyDigit(string inputOfUser)
        {
            char[] digits ={ '0', '1','2','3','4','5','6','7','8','9'};
            int counter = 0;
            if (inputOfUser == null) { return false; }
            if (inputOfUser.Length == 0) { return false; }

            foreach (char character in inputOfUser)
            {
                    counter = 0;
                for(int i=0; i<10; i++)
                {
                    if(digits[i] == character)
                    {
                        counter++;
                    }
                }
                    if (counter!=1)
                    {
                        return false;
                    }
            }
            return true;


        }

        static void pastTransactionWriter( string lastTransaction, string folder, string textFile)
        {
            string path;

            path = folder + "\\" + textFile;

            bool isExists =false;
            if(Directory.Exists(folder))
            {
                //Console.WriteLine("It already exists");

                isExists = true;
            }
            else
            {
                Directory.CreateDirectory(folder);
                //Console.WriteLine("Created the folder!");
                isExists=true;
            }

            if(isExists)
            {
                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                    {
                        file.WriteLine(lastTransaction);
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("This program made a mistaaaaaaake!: ", ex);
                }
            }



        }


        static void checkAndPrintPast(string bankNumber)
        {
            string folder = @"transactions";
            string path;
            

            path = folder + "\\" + bankNumber+".txt";



            bool isThere=File.Exists(path);


            if (isThere)
            {
                try
                {
                    string[] everyline = System.IO.File.ReadAllLines(path);

                    Console.Clear();
                    Console.WriteLine("|Last Transactions of yours|");

                    for (int i = 0; i < everyline.Length; i++)
                    {
                        if (everyline[i].Contains("received"))
                        {


                            Console.ForegroundColor = ConsoleColor.Green;

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.WriteLine(everyline[i]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("____________________________________________________________");


                    }
                    Console.WriteLine("Press Enter To Continue...");
                    Console.ReadLine();


                }
                catch (Exception ex)
                {

                    throw new ApplicationException("This program made a mistaaaaaaake!: ", ex);
                }

            }
            else
            {
                Console.WriteLine("Couldnt find any transaction for: "+bankNumber+"\nPress Enter To Continue...");
                Console.ReadLine() ;
            }
        }


        static void InterestHandler(string bankNumber)
        {
            Console.Clear ();
            DateTime dateTime = DateTime.Now;
            int currentRow=3;
            bool isEntered;

            int amountOfOptions=4;
            bool isExit = false;


            // start screen
            Console.WriteLine("Current day of the year: "+dateTime.DayOfYear+ " | Current year: " +dateTime.Year);


            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;

            Console.Write(" [ ] ");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Deposit money to ur interest account");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("      Withdraw money from ur interest account");
            Console.WriteLine("      Take a loan from bank");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("      Back<-");
            Console.ForegroundColor = ConsoleColor.Gray;


            while(!isExit)
            {
                //Console.WriteLine(currentRow);
                int currentDirection = bankPageInputs(currentRow);
                currentRow = rowCalc(currentRow, amountOfOptions, currentDirection, out isEntered);
                Console.Clear();
                //Console.WriteLine(currentRow);



                switch (currentRow)
                    {
                        case 3:

                        if (isEntered)
                        {
                            //Console.WriteLine("Depo money...");
                            DepoMoney(bankNumber);
                        }

                        Console.WriteLine("Current day of the year: " + dateTime.DayOfYear + " | Current year: " + dateTime.Year);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.BackgroundColor = ConsoleColor.Gray;

                            Console.Write(" [ ] ");

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(" ");

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("Deposit money to ur interest account");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.Black;

                            Console.WriteLine("      Withdraw money from ur interest account");
                            Console.WriteLine("      Take a loan from bank");

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("      Back<-");
                            Console.ForegroundColor = ConsoleColor.Gray;

                            break;

                        case 2:
                        if (isEntered)
                        {
                            Console.WriteLine("withdraw money...");
                            Console.ReadLine();
                        }

                        Console.WriteLine("Current day of the year: " + dateTime.DayOfYear + " | Current year: " + dateTime.Year);
                        Console.WriteLine("      Deposit money to ur interest account");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.BackgroundColor = ConsoleColor.Gray;

                            Console.Write(" [ ] ");

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("Withdraw money from ur interest account");

                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.Black;

                            Console.WriteLine("      Take a loan from bank");

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("      Back<-");
                            Console.ForegroundColor = ConsoleColor.Gray;

                            break;

                        case 1:
                        if (isEntered)
                        {
                            Console.WriteLine("take loan...");
                            Console.ReadLine();
                        }
                        Console.WriteLine("Current day of the year: " + dateTime.DayOfYear + " | Current year: " + dateTime.Year);
                        Console.WriteLine("      Deposit money to ur interest account");
                            Console.WriteLine("      Withdraw money from ur interest account");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.BackgroundColor = ConsoleColor.Gray;

                            Console.Write(" [ ] ");

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("Take a loan from bank");

                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.Black;


                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("      Back<-");
                            Console.ForegroundColor = ConsoleColor.Gray;



                            break;


                        case 0:
                        if (isEntered)
                        {
                            Console.WriteLine("Press Enter To Continue...");
                            Console.ReadLine();
                            isExit = true;
                        }
                        Console.WriteLine("Current day of the year: " + dateTime.DayOfYear + " | Current year: " + dateTime.Year);
                        Console.WriteLine("      Deposit money to ur interest account");
                            Console.WriteLine("      Withdraw money from ur interest account");
                            Console.WriteLine("      Take a loan from bank");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.BackgroundColor = ConsoleColor.Gray;

                            Console.Write(" [ ] ");

                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(" ");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("Back<-");

                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.Black;







                            break;






                    }

                }



            



        }


        static void DepoMoney(string bankNumber)
        {
            bool exitLoop = false;
            string amountOfMoney = "ERROR";   
            string folder = @"interestManaging";
            string path;
            int currentBalance;

            checkBankRecord(bankNumber, out currentBalance);

            path = folder + "\\" +  "interest.txt";
            DateTime dateTime = DateTime.Now;

            
            Console.WriteLine("Current interest rate is:%5\nEnter the amount which you want to deposit to ur interest account: ");
            amountOfMoney=Console.ReadLine();
            int convertedMoney=Convert.ToInt32(amountOfMoney);
            while (convertedMoney < currentBalance || !exitLoop)
            {
                Console.WriteLine("You cant deposit more than what you have in ur account! | Current Balance in Your Account is: "+currentBalance);
                Console.WriteLine("Current interest rate is:%5\nEnter the amount which you want to deposit to ur interest account: ");
                Console.WriteLine("Enter -13 to exit from this page...");
                amountOfMoney = Console.ReadLine();
                convertedMoney = Convert.ToInt32(amountOfMoney);
                if (convertedMoney == -13)
                {
                    exitLoop = true;
                }
                else
                {
                    bool isExists = false;
                    if (Directory.Exists(folder))
                    {
                        //Console.WriteLine("It already exists");

                        isExists = true;
                    }
                    else
                    {
                        Directory.CreateDirectory(folder);
                        //Console.WriteLine("Created the folder!");
                        isExists = true;
                    }

                    if (isExists)
                    {
                        try
                        {
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                            {
                                file.WriteLine(bankNumber + "," + amountOfMoney + "," + dateTime.DayOfYear + "," + dateTime.Year);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new ApplicationException("This program made a mistaaaaaaake!: ", ex);
                        }
                    }

                    Console.WriteLine("Successful\nPress Enter To Continue...");
                    Console.ReadLine();

                    
                }



            }
            Console.Clear();







        }



    }
}
