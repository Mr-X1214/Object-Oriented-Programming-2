using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_game
{
    public class Statistics
    {
        public static int hps1
        { get; set; }

        public static int hps2
        { get; set; }

        public static int hbs
        { get; set; }

        public static int sc
        { get; set; }

        public static int dc
        { get; set; }

        public static int gc
        { get; set; }

        public static int win1
        { get; set; }

        public static int win2
        { get; set; }

        public static int winb
        { get; set; }

        public static int tc
        { get; set; }

        public static int rc
        { get; set; }

        public static int gc3
        { get; set; }

        public void Stats()
        {
            Console.WriteLine("\nSevens Out Statistics: ");
            Console.WriteLine($"\nPlayer 1 high score: {hps1}");
            Console.WriteLine($"Player 2 high score: {hps2}");
            Console.WriteLine($"Computer high score: {hbs}");
            Console.WriteLine($"Amount of turns taken: {sc}");
            Console.WriteLine($"Times dice has been rolled: {dc}");
            Console.WriteLine($"Time game played: {gc}");
            Console.ReadLine();
            Console.WriteLine("\nThree Or More Statistics: ");
            Console.WriteLine($"\nPlayer 1 wins: {win1}");
            Console.WriteLine($"Player 2 wins: {win2}");
            Console.WriteLine($"Computer wins: {winb}");
            Console.WriteLine($"Amount of turns taken: {tc}");
            Console.WriteLine($"Times dice has been rerolled: {rc}");
            Console.WriteLine($"Times game played: {gc3}");
            Console.ReadLine();
            next();
        }

        public void next()
        {
            Game game = new Game();
            game.menu();
        }
    }
}
