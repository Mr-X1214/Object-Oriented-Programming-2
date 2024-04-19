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
        ThreeOrMore three = new ThreeOrMore();
        SevensOut seven = new SevensOut();
        Die die = new Die();

        public void Tests()
        {
            Console.WriteLine("Testing the dice rolls.");
            // this creates a dice roll to test
            die.Roll();
            Debug.Assert(die.Roll() > 0); // this and the one bellow tests that it's within a specific range
            Debug.Assert(die.Roll() < 7);
            Console.WriteLine("Test of the dice rolls complete.");

            Console.WriteLine("Testing Sevens Out: 7 stops the game.");
            // this does a test game
            seven.Player1PVE();
            Debug.Assert(seven.playerScore1 != 7);
            Console.WriteLine("Testing of Sevens Out complete.");

            Console.WriteLine("Testing Three Or More: 20 stops the game, scores are correct.");
            three.Player1PVE();
            Debug.Assert(three.playerScore1 != 1 && three.botScore != 1);
            Debug.Assert(three.playerScore1 != 20 && three.botScore != 20);
            Console.WriteLine("The testing has been completed.");
        }
    }
}
