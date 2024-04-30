using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_game
{
    public class Statistics
    {
        // bellow are the gets and sets that I used to be able to get the values for the statistics into this class
        public static int hps1 // this is the high player1 score in the sevens out game
        { get; set; }

        public static int hps2 // this is the high player2 score in the sevens out game
        { get; set; }

        public static int hbs // this is the high score for the computer in the sevens out game
        { get; set; }

        public static int sc // this is the counter for how many times a turn has been taken in the sevens out game
        { get; set; }

        public static int dc // this is the counter for how many times the dice has been rolled in the sevens out games
        { get; set; }

        public static int gc // this is the counter for how many times sevens out has been played
        { get; set; }

        public static int win1 // this is how many times player 1 has won in three or more
        { get; set; }

        public static int win2 // this is how many times player 2 has won in three or more
        { get; set; }

        public static int winb // this is how many times the computer has won in three or more
        { get; set; }

        public static int tc // this is how many turns have been taken in three or more
        { get; set; }

        public static int rc // this is how many times the dice has been rerolled in three or more
        { get; set; }

        public static int gc3 // this is how many times three or more has been played
        { get; set; }

        /// <summary>
        /// This method shows all of the statistics for both of the games
        /// </summary>
        public void Stats()
        {
            // these show the different statistics for the sevens out game, telling the player which is which
            Console.WriteLine("\nSevens Out Statistics: ");
            Console.WriteLine($"\nPlayer 1 high score: {hps1}");
            Console.WriteLine($"Player 2 high score: {hps2}");
            Console.WriteLine($"Computer high score: {hbs}");
            Console.WriteLine($"Amount of turns taken: {sc}");
            Console.WriteLine($"Times dice has been rolled: {dc}");
            Console.WriteLine($"Time game played: {gc}");
            Console.ReadLine(); // this makes it so the user has to press enter before seeing the next ones
            // this shows the different statistics for the three or more game, telling the player which is which
            Console.WriteLine("\nThree Or More Statistics: ");
            Console.WriteLine($"\nPlayer 1 wins: {win1}");
            Console.WriteLine($"Player 2 wins: {win2}");
            Console.WriteLine($"Computer wins: {winb}");
            Console.WriteLine($"Amount of turns taken: {tc}");
            Console.WriteLine($"Times dice has been rerolled: {rc}");
            Console.WriteLine($"Times game played: {gc3}");
            // this also keeping it open so that they can view them all before going onto the menu
            Console.ReadLine();
            next(); // this calls the method for the menu
        }

        /// <summary>
        /// This calls the menu 
        /// </summary>
        public void next()
        {
            Game game = new Game(); // creates a new game object
            game.menu(); // calls the method for the menu
        }
    }
}
