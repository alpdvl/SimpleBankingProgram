using System;
using System.Collections.Generic;
using System.Linq;
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
            int checkedEntries = 0; // made for registerPageManager, its here on main aswell cuz of the poor code design
            double currentPageMultiplier = 1; // default is mainMultiplier

            string[] dataHolder = new string[6]; // made for file handling ||

            Console.CursorVisible = false;

            Console.Title = "SharpBank";
            
            
            

            PageManager(ref currentPage, ref currentPageMultiplier, ref dataHolder, ref checkedEntries);
        }

        static void PageManager(ref int currentPage, ref double currentPageMultiplier, ref string[] dataHolder, ref int checkedEntries)
        {


            

            // dont forget to update this part when you want to change the amount of rows in any menu

            int countOfCurrentRows = 5;


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
                
                for(int i = 0; i < countOfMainPageRows; i++)
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
            PagePrinter(countOfCurrentRows, currentPageTitles,ref currentPage, ref currentPageMultiplier, ref dataHolder, ref checkedEntries);

            

        }

        static void PagePrinter(int amountOfRows, string[] currentPageTitles,ref int currentPage, ref double currentPageMultiplier, ref string[] dataHolder, ref int checkedEntries) 
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
                

                if(cycler==currentRow)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    
                        // prints titles, prints cursor and input values in "input titles"
                        if (currentPageMultiplier==100)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write(currentPageTitles[cycler]);
                            if (cycler <4 )
                            {
                            Console.Write("-> ");
                                
                            }
                            
                            if (cycler>=2)
                            {
                                Console.Write(dataHolder[cycler-1]);
                                if (cycler==2 )
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

                    
                        if ((currentPageMultiplier == 100) && (cycler<4))
                        {
                            Console.Write(currentPageTitles[cycler]+"-> ");

                            if (cycler>=2)
                            {
                                Console.WriteLine(dataHolder[cycler-1]);
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
                currentRow = UpdateCurrentRowAndPage(currentRow, amountOfRows,ref currentPage, ref currentPageMultiplier, ref dataHolder, ref checkedEntries);
                cycler = 0;
                Console.Clear();

            }

            


        }


        // moves cursor handles inputs for pages 
        static int UpdateCurrentRowAndPage(int currentRow,int amountOfRows,ref int currentPage, ref double currentPageMultiplier, ref string[] dataHolder, ref int checkedEntries)
        {

            var key = Console.ReadKey().Key;


            if (key == ConsoleKey.DownArrow)
            {
                

                if (currentRow < amountOfRows-1)
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
                    currentRow = amountOfRows-1;
                }
            }
            else if (key == ConsoleKey.Enter)
            
            {
                if (currentRow == amountOfRows-1)
                {
                    if(currentPage==0)
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
                    }



                }
                else 
                {
                    // each page has its own unique multiplier value 
                    if(currentPageMultiplier==10)
                    {
                        LoginPageHandler(ref currentRow, ref  dataHolder, ref checkedEntries);   
                    }
                    else if(currentPageMultiplier==100)
                    {
                        registerPageHandler(ref currentRow, ref dataHolder,ref checkedEntries); 
                    }
                    else
                    {
                        currentPage = (currentRow * Convert.ToInt32(currentPageMultiplier)) + 1; 
                        currentPageMultiplier = Math.Pow(10,currentPage); // tried to give each page its own multiplier that way
                                                                          // i can easily access them via arithmetic operations 



                        //Console.WriteLine("#####"+currentPageMultiplier);
                        //Console.ReadLine();
                        Console.Clear();

                    }
                }


                Console.Clear();
                // there is too many ref variables in this program we gotta find a way to decrease the
                // amount of referencing we use in our program
                PageManager(ref currentPage, ref currentPageMultiplier, ref  dataHolder, ref checkedEntries);
                


            }

            // have no idea about why i've used return instead of putting another ref lmao 
            return currentRow;

        }


        
        static void LoginPageHandler(ref int currentRow, ref string[] dataHolder,ref int checkedEntries)
        {
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
                        int lineOfTerm;
                        int lineOfTermHolder;

                        readRecord(passwordHolder, "testing.txt", 2, out isExist,out lineOfTermHolder);
                        if (isExist)
                        {
                            readRecord(dataHolder[0], "testing.txt", 1, out isExist, out lineOfTerm);
                            if (lineOfTerm==lineOfTermHolder)
                            {
                                dataHolder[1] = passwordHolder;
                                checkedEntries++;
                                Console.WriteLine("Correct Password!\nPress enter to continue...");
                                Console.ReadLine();
                            }
                            

                        }
                        else
                        {
                            Console.WriteLine("Wrong Password!\nPress enter to continue...");
                            Console.ReadLine();
                        }
                    } while (!isExist);


                    
                    

                    break;
                case 2:



                    do
                    {

                        Console.Clear();
                        Console.WriteLine("Enter ur banking number...");
                        string bankingNumberHolder = Console.ReadLine();
                        int lineOfTerm;
                        int lineOfTermHolder;

                        readRecord(bankingNumberHolder, "testing.txt", 4, out isExist, out lineOfTermHolder);
                        if (isExist)
                        {
                            readRecord(dataHolder[0], "testing.txt", 1, out isExist, out lineOfTerm);
                            if (lineOfTerm == lineOfTermHolder)
                            {
                                dataHolder[3] = bankingNumberHolder;
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
                    Console.WriteLine("checkedEntries:" + checkedEntries);
                    Console.ReadLine() ;
                            if(checkedEntries==3)
                            {
                        Console.WriteLine("You have Successfuly entered to ur account ");
                        checkedEntries = 0;
                        Console.ReadLine();
                        // we should have a new function in here which handles whole new page system for banking stuff
                    }
                            else if(checkedEntries>=3)
                    {
                        Console.WriteLine("There was a mistake your checked entries is:"+checkedEntries);
                        Console.ReadLine();
                        checkedEntries = 0;
                    }
                    else
                    {
                        Console.WriteLine("There was probably a mistake!: checkedentries:" + checkedEntries);
                        Console.ReadLine();
                    }


                    break;



                default:
                    break;
            }
        }

         
        static void registerPageHandler(ref int currentRow, ref string[] dataHolder, ref int checkedEntries)
        {
            bool isValid=false;
            


            string userNameHolder;
            string passwordHolder;
            string passwordHolderCheck;
            string phoneNumber;


            
            switch (currentRow)
            {
                
                case 0:


                    do
                    {
                        // registering new account gotta add new piece of codes to make sure that each username is unique
                        // with that we also need to implement a way of giving random bank numbers for each new account created which can act as
                        // username in a way 
                        Console.Clear();
                        Console.WriteLine("Enter ur username...");
                        userNameHolder = Console.ReadLine();
                        if (userNameHolder=="-1")
                        {

                            break;
                        }
                        
                        else
                        {
                            bool isExist;
                            int lineOfTerm;
                            readRecord(userNameHolder, "testing.txt", 1, out isExist, out lineOfTerm);
                            // need to add checking new username registration with already present usernames in DB 
                            if (userNameHolder.Length>=16 || userNameHolder.Length<=4)
                            {
                                isValid = false;
                                Console.WriteLine("Username should be longer than 4 and shorter than 16");
                                Thread.Sleep(1200);
                            }
                            else if(isExist)
                            {
                                // it already exists
                                Console.WriteLine("That user name is already taken please try something else!");
                                Thread.Sleep(1200);
                            }
                            else
                            {
                                
                                dataHolder[0] = userNameHolder;
                                checkedEntries++;
                                isValid = true;
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

                            dataHolder[1] = passwordHolder;
                            checkedEntries++;
                            isValid = true;


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

                            if (dataHolder[1] ==passwordHolderCheck)
                            {
                                checkedEntries++;
                                isValid = true;
                            }
                            else
                            {
                                Console.WriteLine("Two passwords are different!");
                                Console.WriteLine("|First one is:"+dataHolder[1]+"|\t|Second one is:"+passwordHolderCheck+"|");
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

                            dataHolder[2] = phoneNumber;
                            checkedEntries++;
                            isValid = true;


                        }
                    }
                    while (!isValid);


                    break;

                    case 4:
                    if (checkedEntries==4)
                    {
                        dataHolder[3] =randomBankNumber();
                        
                        addRecord(dataHolder[0], dataHolder[1], dataHolder[2] , dataHolder[3],"testing.txt");
                        checkedEntries=0;
                        Console.WriteLine("Values are successfully added to the file!\nPress Enter To Continue...");
                        for (int i = 0; i <= 3; i++)
                        {
                            dataHolder[i] = "";
                        }
                        Console.ReadLine();
                    }
                    else
                    {
                        if(checkedEntries>4)
                        {
                            for (int i = 0; i <= 3; i++)
                            {
                                dataHolder[i] = "";
                                checkedEntries = 0;
                            }
                        }
                        // added a statement which checks for inputing values into file safely and as a whole!!
                        // that way preventing any serious mistakes from happening with the cost of making things harder for user 
                        Console.WriteLine("Please complete all of the entries before trying again!   |"+checkedEntries+" out of 4|");
                        Console.WriteLine("Press Enter To Continue...");
                        for(int i=0; i<=3;i++)
                        {
                            dataHolder[i] = "";
                        }
                        checkedEntries = 0;
                        Console.ReadLine();
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
                        isExist=true;
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
            int lastButInt=0;
            Random rnd = new Random();
            temp[0] = 1;
            temp[1]=3;
            for (int i = 2; i < temp.Length; i++)
            {
                temp[i] = rnd.Next(0,9);



            }

            for (int i = 0; i < temp.Length; i++)
            {
                lastButInt= lastButInt + (temp[i] * Convert.ToInt32(Math.Pow(10, 9-i)));
            }
            Console.WriteLine(lastButInt);
            Console.ReadLine();
            last = Convert.ToString(lastButInt);
            return last;

        }





    }
}
