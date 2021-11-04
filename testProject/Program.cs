using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace testProcrect
{
    class Program
    {//lengthmp3list++ = newid;


        public static void Main(string[] args)
        {
            
        }
        /*do
        {
            Console.WriteLine("Please enter your Password:");
            string password = Console.ReadLine();
        
            if (Password == "SOUNDSHARP")
            {
                Console.WriteLine("Welkom bij SoundSharp {0}.",InputName);
                break;
            }
            else
            {
                Console.WriteLine("Password is onjuist.");
                
            }
        } while (true);*/


                /*enum Level
                {
                    Low,
                    Medium,
                    High
                }
                static void Main(string[] args)
                {
                    Level myVar = Level.Medium;
                    Console.WriteLine(myVar);
                }*/



                /*using System;
                namespace opdrachten
                {
                    internal class Program
                    {
                        public static void Main(string[] args)
                        {
                            Console.WriteLine("Please enter your name:");
                            string InputName = Console.ReadLine();
                
                            inlogStatus invoer = new inlogStatus();
                            int i = 1;
                            int max = 3;
                            while (i <= max)
                            {
                                
                
                                if (i > 1)
                                {
                                    Console.WriteLine("Poging {0} van 3",i);
                                }
                
                                if (i == max)
                                {
                                    Console.WriteLine("LET OP: Laatste poging");
                                }
                                invoer = Login();
                                if (invoer == inlogStatus.OK)
                                {
                                    Console.WriteLine("Welkom bij SoundSharp {0}.",InputName);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Password is onjuist.");
                                    i++;
                                }
                            }
                        }
                
                        static inlogStatus Login()
                        {
                            inlogStatus status = inlogStatus.Onbekend;
                            Console.WriteLine("Please enter your password:");
                            string password = Console.ReadLine();
                            switch (password)
                            {
                                case "SOUNDSHARP":
                                    status = inlogStatus.OK;
                
                                    break;
                                default:
                                    status = inlogStatus.NietOK;
                                    break;
                                
                            }
                
                            return status;
                        }
                
                        enum inlogStatus
                        {
                            OK,
                            NietOK,
                            Onbekend
                        };
                    }
                }*/





                /*internal class Program
                {
                    public static void Main(string[] args)
                    {
                        Login();
                    }
    
                    static inlogStatus Login()
                    {
                        inlogStatus status = inlogStatus.Onbekend;
                        Console.Write("Voer naam in: ");
                        string InputName = Console.ReadLine();
                        int i = 1;
                        int max = 3;
                        while (i <= max)
                        {
                            if (i > 1)
                            {
                                Console.WriteLine("Poging {0} van 3", i);
                            }
    
                            if (i == max)
                            {
                                Console.WriteLine("LET OP: Laatste poging");
                            }
    
    
                            Console.Write("Voer wachtwoord in: ");
                            string password = Console.ReadLine();
                            switch (password)
                            {
                                case "SOUNDSHARP":
                                    status = inlogStatus.OK;
                                    Console.WriteLine("Welkom bij SoundSharp {0}.", InputName);
                                    i = max + 1;
                                    break;
                                default:
                                    status = inlogStatus.NietOK;
                                    Console.WriteLine("Password is onjuist.");
                                    i++;
                                    break;
                            }
                        }
    
                        return status;
                    }
    
                    enum inlogStatus
                    {
                        OK,
                        NietOK,
                        Onbekend
                    }
                }*/



//-----------------------
            
        
    }
}