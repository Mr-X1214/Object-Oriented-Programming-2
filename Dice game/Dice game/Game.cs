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
            // this creates the necassary variables and objects that are used in this class
            bool correct = true; // this is used in the first while statment
            Statistics stats = new Statistics(); // creates a new statistics object
            Testing test = new Testing(); // this creates a new testing object
            ThreeOrMore three = new ThreeOrMore(); // this creates a new three or more object
            SevensOut seven = new SevensOut(); // this creates a new sevens out object
            bool correct2 = true; // this is used in the second while statement

            // these WriteLines are here to display what is on the menu
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("play Sevens Out - seven");
            Console.WriteLine("play Three Or More - three");
            Console.WriteLine("view Statistics - stat");
            Console.WriteLine("perform Testing - test");
            Console.WriteLine("Quit");
            Console.WriteLine();

            // this while statement allows the user to make a wrong choice and not be kicked out of the program
            while (correct == true)
            {
                // these writelines show the choices
                Console.WriteLine("Please pick an option by inputing:");
                Console.WriteLine("[seven, three, stats, test or EXIT]");
                string choice = Console.ReadLine(); // the readline recording the choice

                // this if statment checks the choice
                if (choice == "seven")
                {
                    // if it was seven, it tells you that you're playing that game and makes the while loop stop
                    Console.WriteLine();
                    Console.WriteLine("Now playing Sevens Out");
                    correct = false;
                    Console.WriteLine();

                    // this second while loop allows the user to choose is they want PVP or against the computer
                    while (correct2 == true)
                    {
                        // this shows the choices
                        Console.WriteLine("PVP or against the computer?");
                        Console.WriteLine("enter [PVP or PVE]");
                        string choice2 = Console.ReadLine(); // this records the choice

                        // this if statement checks the choice
                        if (choice2 == "PVP")
                        {
                            // this tells you that you're playing against the player
                            Console.WriteLine();
                            Console.WriteLine("Playing against player");
                            correct2 = false; // makes the while loop stop
                            seven.SOPVP(); // calls the method so the game can be played
                        }
                        else if (choice2 == "PVE")
                        {
                            // tells you are playing against the computer
                            Console.WriteLine();
                            Console.WriteLine("Playing against computer");
                            correct2 = false; // makes the while loop stop
                            seven.SOPVE(); // calls the method so the game can be played
                        }
                        else
                        {
                            // tells you that you haven't made a choice
                            Console.WriteLine();
                            Console.WriteLine("That is not a choice");
                            correct2 = true; // keeps the while loop going so an actual choice can be made
                        }
                    }
                }
                else if (choice == "three")
                {
                    // if it was seven, it tells you that you're playing that game and makes the while loop stop
                    Console.WriteLine();
                    Console.WriteLine("Now playing Three Or More");
                    correct = false;
                    Console.WriteLine();

                    // the second while loop, like in the seven game
                    while (correct2 == true)
                    {
                        // shows the choices
                        Console.WriteLine("PVP or against the computer?");
                        Console.WriteLine("enter [PVP or PVE]");
                        string choice2 = Console.ReadLine(); // records the choice

                        // this if statmente checks the choice
                        if (choice2 == "PVP")
                        {
                            // tells you that you are playing against a player
                            Console.WriteLine();
                            Console.WriteLine("Playing against player");
                            correct2 = false; // stops the while loop
                            three.TOMPVP(); // calls the method for the game so that it can be played
                        }
                        else if (choice2 == "PVE")
                        {
                            // tells you that you are playing against the computer
                            Console.WriteLine();
                            Console.WriteLine("Playing against computer");
                            correct2 = false; // stops the while loop
                            three.TOMPVE(); // calls the method for the game so it can be played
                        }
                        else
                        {
                            // tells you that you didn't make a choice
                            Console.WriteLine();
                            Console.WriteLine("That is not a choice");
                            correct2 = true; // keeps the loop going so you can try again
                        }
                    }
                }
                else if (choice == "stats")
                {
                    // tells you that you are going to see the statistics
                    Console.WriteLine();
                    Console.WriteLine("Now showing the game statistics");
                    correct = false; // ends the while loop
                    stats.Stats(); // calls the method so you can view the statistics
                }
                else if (choice == "test")
                {
                    // tells you that you are testing the games
                    Console.WriteLine();
                    Console.WriteLine("Now testing the games");
                    correct = false; // ends the loop
                    test.Tests(); // calls the method so it can be tested
                }
                else if (choice == "EXIT")
                {
                    // tells you how to exit
                    Console.WriteLine("\nPress enter to exit");
                    break; // ends the loop altogether
                }
                else
                {
                    // tells you that you didn't choose
                    Console.WriteLine("That is not a choice");
                    Console.WriteLine();
                    correct = true; // keeps the while loop going so you can try again
                }
            }

            Console.ReadLine(); // is there to keep the programme open when everything has been displayed
        }

        /// <summary>
        /// this holds the the same menu so that it can be called by other classes, it doesn't do anything different
        /// </summary>
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
