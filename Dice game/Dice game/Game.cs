using System;
using System.Collections.Generic;
using System.Linq;
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

            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("play Sevens Out - seven");
            Console.WriteLine("play Three Or More - three");
            Console.WriteLine("view Statistics - stat");
            Console.WriteLine("perform Testing - test");
            Console.WriteLine();

            while (correct == true)
            {
                Console.WriteLine("Please pick an option by inputting:");
                Console.WriteLine("[seven, three, stats or test]");
                string choice = Console.ReadLine();

                if (choice == "seven")
                {
                    Console.WriteLine();
                    Console.WriteLine("Now playing Sevens Out");
                    correct = false;
                    seven.So();
                }
                else if (choice == "three")
                {
                    Console.WriteLine();
                    Console.WriteLine("Now playing Three Or More");
                    correct = false;
                    three.ToM();
                }
                else if (choice == "stats")
                {
                    Console.WriteLine();
                    Console.WriteLine("Now showing the game statsistics");
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
                else
                {
                    Console.WriteLine("That is not a choice");
                    Console.WriteLine();
                    correct = true;
                }
            }

            Console.ReadLine();
        }
    }
}
