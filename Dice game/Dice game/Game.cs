using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dice_game
{
    internal class Game
    {
        static void Main(string[] args)
        {
            bool correct = true;
            Statistics stats = new Statistics();
            Testing test = new Testing();
            ThreeOrMore three = new ThreeOrMore();
            SevensOut seven = new SevensOut();
            bool correct2 = true;

            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("play Sevens Out - seven");
            Console.WriteLine("play Three Or More - three");
            Console.WriteLine("view Statistics - stat");
            Console.WriteLine("perform Testing - test");
            Console.WriteLine("Quit");
            Console.WriteLine();

            while (correct == true)
            {
                Console.WriteLine("Please pick an option by inputing:");
                Console.WriteLine("[seven, three, stats, test or EXIT]");
                string choice = Console.ReadLine();

                if (choice == "seven")
                {
                    Console.WriteLine();
                    Console.WriteLine("Now playing Sevens Out");
                    correct = false;
                    Console.WriteLine();

                    while (correct2 == true)
                    {
                        Console.WriteLine("PVP or against the computer?");
                        Console.WriteLine("enter [PVP or PVE]");
                        string choice2 = Console.ReadLine();

                        if (choice2 == "PVP")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Playing against player");
                            correct2 = false;
                            seven.SOPVP();
                        }
                        else if (choice2 == "PVE")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Playing against computer");
                            correct2 = false;
                            seven.SOPVE();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("That is not a choice");
                            correct2 = true;
                        }
                    }
                }
                else if (choice == "three")
                {
                    Console.WriteLine();
                    Console.WriteLine("Now playing Three Or More");
                    correct = false;
                    Console.WriteLine();

                    while (correct2 == true)
                    {
                        Console.WriteLine("PVP or against the computer?");
                        Console.WriteLine("enter [PVP or PVE]");
                        string choice2 = Console.ReadLine();

                        if (choice2 == "PVP")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Playing against player");
                            correct2 = false;
                            three.TOMPVP();
                        }
                        else if (choice2 == "PVE")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Playing against computer");
                            correct2 = false;
                            three.TOMPVE();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("That is not a choice");
                            correct2 = true;
                        }
                    }
                }
                else if (choice == "stats")
                {
                    Console.WriteLine();
                    Console.WriteLine("Now showing the game statistics");
                    correct = false;
                    stats.Stats();
                }
                else if (choice == "test")
                {
                    Console.WriteLine();
                    Console.WriteLine("Now testing the game");
                    correct = false;
                    test.Tests();
                }
                else if (choice == "EXIT")
                {
                    Console.WriteLine("\nPress enter to exit");
                    break;
                }
                else
                {
                    Console.WriteLine("That is not a choice");
                    Console.WriteLine();
                    correct = true;
                }
            }

            Console.ReadLine();
        }

        public void menu()
        {
            bool correct = true;
            Statistics stats = new Statistics();
            Testing test = new Testing();
            ThreeOrMore three = new ThreeOrMore();
            SevensOut seven = new SevensOut();
            bool correct2 = true;

            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("play Sevens Out - seven");
            Console.WriteLine("play Three Or More - three");
            Console.WriteLine("view Statistics - stat");
            Console.WriteLine("perform Testing - test");
            Console.WriteLine("Quit");
            Console.WriteLine();

            while (correct == true)
            {
                Console.WriteLine("Please pick an option by inputing:");
                Console.WriteLine("[seven, three, stats, test or EXIT]");
                string choice = Console.ReadLine();

                if (choice == "seven")
                {
                    Console.WriteLine();
                    Console.WriteLine("Now playing Sevens Out");
                    correct = false;
                    Console.WriteLine();

                    while (correct2 == true)
                    {
                        Console.WriteLine("PVP or against the computer?");
                        Console.WriteLine("enter [PVP or PVE]");
                        string choice2 = Console.ReadLine();

                        if (choice2 == "PVP")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Playing against player");
                            correct2 = false;
                            seven.SOPVP();
                        }
                        else if (choice2 == "PVE")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Playing against computer");
                            correct2 = false;
                            seven.SOPVE();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("That is not a choice");
                            correct2 = true;
                        }
                    }
                }
                else if (choice == "three")
                {
                    Console.WriteLine();
                    Console.WriteLine("Now playing Three Or More");
                    correct = false;
                    Console.WriteLine();

                    while (correct2 == true)
                    {
                        Console.WriteLine("PVP or against the computer?");
                        Console.WriteLine("enter [PVP or PVE]");
                        string choice2 = Console.ReadLine();

                        if (choice2 == "PVP")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Playing against player");
                            correct2 = false;
                            three.TOMPVP();
                        }
                        else if (choice2 == "PVE")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Playing against computer");
                            correct2 = false;
                            three.TOMPVE();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("That is not a choice");
                            correct2 = true;
                        }
                    }
                }
                else if (choice == "stats")
                {
                    Console.WriteLine();
                    Console.WriteLine("Now showing the game statistics");
                    correct = false;
                    stats.Stats();
                }
                else if (choice == "test")
                {
                    Console.WriteLine();
                    Console.WriteLine("Now testing the game");
                    correct = false;
                    test.Tests();
                }
                else if (choice == "EXIT")
                {
                    Console.WriteLine("\nPress enter to exit");
                    break;
                }
                else
                {
                    Console.WriteLine("That is not a choice");
                    Console.WriteLine();
                    correct = true;
                }
            }
        }
    }
}
