using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_game
{
    internal class Testing
    {
        ThreeOrMore three = new ThreeOrMore(); // creates a new three or more object
        SevensOut seven = new SevensOut(); // creates a new sevens out object
        Die die = new Die(); // creates a new die object

        /// <summary>
        /// This method carries out all of the tests
        /// </summary>
        public void Tests()
        {
            Console.WriteLine("\nTesting the dice rolls.");
            // this creates a dice roll to test
            die.Roll();
            Debug.Assert(die.Roll() > 0); // this and the one bellow tests that it's within a specific range
            Debug.Assert(die.Roll() < 7);
            // tells you that the tests are complete before moving onto the next one
            Console.WriteLine("Test of the dice rolls complete.");
            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();
            Console.WriteLine("\nTesting Sevens Out: 7 stops the game.");
            // this tests the game through 2 computer's playing it
            seven.BotTest1();
            Debug.Assert(seven.botTestscore1 != 7 && seven.botTestscore2 != 7); // this makes sure that the game runs when it's not 7
            // this tells you that it's complete before moving onto the next one
            Console.WriteLine("Testing of Sevens Out complete.");
            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();
            Console.WriteLine("\nTesting Three Or More: 20 stops the game and score add correctly.");
            // this tests the game in the same way as the sevens out game was tested
            three.BotTest1();
            Debug.Assert(three.botTestscore1 % 3 == 0 && three.botTestscore2 % 3 == 0); // this makes sure that the score is always a multiple of 3
            Debug.Assert(three.botTestscore1 < 20 && three.botTestscore2 < 20); // this makes sure that the game runs so long as the score isn't over 20
            // tells you that it's complete
            Console.WriteLine("\nTesting of Three Or More complete.");
            Console.WriteLine("All testing complete");
            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();

            Game game = new Game(); // creates a new game object
            game.menu(); // calls the menu
        }
    }
}
