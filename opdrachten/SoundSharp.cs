using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;

namespace opdrachten
{
    public class SoundSharp
    {
        
        private const string Passwordvalid = "SOUNDSHARP";
        private string InputName;
        private List<Mp3> mp3SList = Mp3.InitializeUsingList();

        public static void Main(string[] args)  //run . edit configurations . program paramaters
        {
            SoundSharp prog = new SoundSharp();
            prog.StartLogin(args);
            
            

                                                                            
        }

         void StartLogin(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;  //om € teken te krijgen
            
            if (args.Length == 2)  // check's if there are 2 args
            {
                handleAutomaticLogin(args);
            }
            else
            {
                Login();
                ShowMenu();
            }
        }

        private  void handleAutomaticLogin(string[] args)
        {
            inlogStatus status = automaticLogin(args[0], args[1]);//calls check password
            if (status == inlogStatus.OK)
            {
                Printmp3list();
                PrintInventory();
                PrintStatistics();
            }
            else
            {
                Console.WriteLine("Invalid credentials");
            }
        }
        private inlogStatus automaticLogin(string userid, string password)
        {
            inlogStatus status;
            switch (password)
            {
                                                                                        
                case Passwordvalid:  //check's if password is correct
                    status = inlogStatus.OK;
                    break;
                default:
                    status = inlogStatus.NietOK;
                    break;
            }

            return status;
        }
         inlogStatus Login()
        {
            inlogStatus status = inlogStatus.Onbekend;
            Console.WriteLine("Please enter your name:");
            InputName = Console.ReadLine();
            int i = 1;
            int max = 3;
            while (i <= max)
            {
                if (i > 1) //na 1
                {
                    Console.WriteLine("Poging {0} van 3", i);
                }

                if (i == max) // bij 3 
                {
                    Console.WriteLine("LET OP: Laatste poging");
                }

                Console.WriteLine("Please enter your password:");
                string password = Console.ReadLine();
                switch (password)
                {
                    case Passwordvalid:
                        status = inlogStatus.OK;
                        Console.WriteLine("Welkom bij SoundSharp {0}", InputName);
                        i = max + 1; // zodat het niet verder gaat nadat je het goed heb
                        break;
                    default:
                        status = inlogStatus.NietOK;
                        Console.WriteLine("Password is onjuist.");
                        break;
                }

                i++;
            }

            return status;
        }

        enum inlogStatus
        {
            OK,
            NietOK,
            Onbekend
        };

         void ShowMenu()
        {
            ShowItems(); 
            ConsoleKeyInfo menuInput = new ConsoleKeyInfo();
            while (true)
            {
                menuInput = Console.ReadKey();

                switch (menuInput.KeyChar)
                {
                    case '1':
                        Printmp3list();
                        EnterMenu();
                        break;
                    case '2':
                        PrintInventory();
                        EnterMenu();
                        break;
                    case '3':
                        AdjustInventory();
                        EnterMenu();
                        break;
                    case '4':
                        //PrintStatistics();
                        Statisticslinq();
                        EnterMenu();
                        break;
                    case '5':
                        Addmp3();
                        EnterMenu();
                        break;
                    case '8':
                        Console.WriteLine();
                        ShowItems();
                        break;
                    case '9':
                        Console.WriteLine();
                        Console.WriteLine("Bye {0}",InputName);
                        System.Environment.Exit(0);
                        break;

                }
            }
        }
        
         void ShowItems()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1: Overview mp3 players");
            Console.WriteLine("2: Overview inventory");
            Console.WriteLine("3: Adjust inventory");
            Console.WriteLine("4: Statistics");
            Console.WriteLine("5: Add mp3 player");
            Console.WriteLine("8: Show menu");
            Console.WriteLine("9: Exit");
        }

         void Printmp3list()//1
            {
                Console.WriteLine("\n\nOverview mp3 players");
                Console.WriteLine("-------------------------------------------------------------------------------------------");

                /*Mp3[] mp3s = Mp3.Mp3init();
                for (int i = 0; i < mp3s.Length; i++)
                {
                    Console.WriteLine(mp3s[i].formatMp3());  
                }*/
                

                foreach (Mp3 mp3 in mp3SList)
                {
                    Console.WriteLine(mp3.formatMp3());
                } //print list
                
                Console.WriteLine();
            }
         void PrintInventory()//2
        {
            Console.WriteLine("\n\nOverview inventory");
            Console.WriteLine("-----------------------------");
            
            foreach (Mp3 mp3 in mp3SList)
            {
                Console.WriteLine(mp3.formatinventory());
            }
                
            Console.WriteLine();
        }

         void PrintStatistics()//4 //opdr 10
        {
            Console.WriteLine("\n\nStatistics");
            
            double bestprice = double.MaxValue;
            Mp3 bestmp3 =null;
            double priceMB = 0;
            double totalprice = 0;
            int totalinventory = 0;
            foreach (Mp3 mp3 in mp3SList)
            {
                
                totalinventory = totalinventory + mp3.inventory;
                totalprice = totalprice + (mp3.price * mp3.inventory);
                
                priceMB = mp3.price / int.Parse(mp3.mbsize);
                if (priceMB < bestprice)
                {
                    bestprice = priceMB;
                    bestmp3 = mp3; //verwijst best naar een mp3
                }
                //int mbs = int.Parse(mp3.MBSize);
            }

            Console.WriteLine("Total inventory: " + totalinventory);
            Console.WriteLine("Total price: " + totalprice);
            Console.WriteLine("Average price: {0:0.00} ", (totalprice / totalinventory));
            Console.WriteLine("Best mp3: " + bestmp3.formatMp3() + "best price per MB is: €{0:0.0000}", bestprice);
            

            Console.WriteLine();
            
            
        }

         void Statisticslinq()//4 opdr12
         {
             int totalinventory = mp3SList.Sum(m => m.inventory);
             double totalprice = mp3SList.Sum(m => m.price * m.inventory);
             double avarageprice = (totalprice / totalinventory);

             Mp3 bestmp3 = mp3SList.OrderBy(m => m.price / int.Parse(m.mbsize)).First(); // voor best mp3

             Console.WriteLine("\n\nStatistics");
             Console.WriteLine("Total inventory : "+ totalinventory);
             Console.WriteLine("Total price     : " + totalprice);
             Console.WriteLine("Average price   : {0:0.00}", avarageprice);
             Console.WriteLine("Bestmp3         : " + bestmp3.formatMp3() + " best price per MB is: €{0:0.0000}", (bestmp3.price / int.Parse(bestmp3.mbsize)));

         }
         void Addmp3()//5 
        {

            int lengthmp3list;
            
            Console.WriteLine("\n\nTo add mp3 we need the following information:");
            Console.Write("Make: ");
            string newmake = Console.ReadLine();
            Console.Write("Model: ");
            string newmodel = Console.ReadLine();
            Console.Write("MBSize: ");
            string newmbsize = Console.ReadLine();
            Console.Write("Price: ");
            double newprice = double.Parse(Console.ReadLine());
            Console.Write("Inventory: ");
            int newinventory = int.Parse(Console.ReadLine());
            

            lengthmp3list = mp3SList.Count;
            
            mp3SList.Add(new Mp3(lengthmp3list+1, newmake, newmodel, newmbsize, newprice, newinventory));//add's to mp3Slist not to InitializeUsingList
           Printmp3list();
                
            Console.WriteLine();
        
        }

         void AdjustInventory()//3
        {
            Console.WriteLine("\n\nAdjust inventory");
            int inventoryadjust;
            int idinput =0;
            bool IDValid = false;
            do
            {


                try
                {
                    Console.WriteLine("Please enter the ID:");
                     idinput = int.Parse(Console.ReadLine());
                     
                     IDValid = CheckValidID(idinput);
                     if (IDValid == false)
                     {
                         Console.WriteLine("Invalid ID, please enter a valid ID.");
                         Printmp3list(); 
                     }
                     
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Format Error Please enter a number.",e.Message);
                }
                catch (System.Exception e)
                {
                    Console.WriteLine("Unexpected Error, Please enter a valid number.",e.Message);
                }
                
            } while (IDValid == false);

            bool adjustment = false;
            do 
            {
                try
                {

                    Console.WriteLine("Please enter the adjustment:");
                    inventoryadjust = int.Parse(Console.ReadLine());
                    Mp3 mp3 = mp3SList.Where(Mp3 => Mp3.id == idinput).FirstOrDefault(); //haald inventory info op en zet het in mp3
                    if (mp3.inventory + inventoryadjust < 0)
                    {
                        Console.WriteLine("Error, inventory can't be negative.");
                    }
                    else
                    {
                        mp3.inventory = mp3.inventory + inventoryadjust;
                        Console.WriteLine("ID: "+ mp3.id + " make: " + mp3.make+ " new inventory: " + mp3.inventory);
                        Console.WriteLine();
                        adjustment = true;
                    }
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Format Error Please enter an amount.",e.Message);
                }
                catch (System.Exception e)
                {
                    Console.WriteLine("Unexpected Error, Please enter an amount.",e.Message);
                }

            } while (adjustment == false);
        }

         bool CheckValidID(int idInput)//for 3
        {
            return mp3SList.Any(item => item.id == idInput);
            // bekijkt of idInput gelijk is aan een van de ID's in de list
        }

         void EnterMenu()
        {
            Console.WriteLine("Please enter menu option (8 to show the menu.)");
        }

    }
}