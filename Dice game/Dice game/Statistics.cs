using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_game
{
    internal class Statistics
    {
        ThreeOrMore three = new ThreeOrMore();
        SevensOut seven = new SevensOut();
        //List<int> statsseven = new List<int>();

        public void Stats()
        {
            sevenstats(hps1, pas1, hps2, pas2, hbs, bas, sc, dc, gc);
            //sevenstats(hps1, pas1, hps2, pas2, hbs, bas, sc, dc, gc);
            Console.ReadLine();
            three.TOMStats();
        }


        public void sevenstats(int hps1, int pas1, int hps2, int pas2, int hbs, int bas, int sc, int dc, int gc)
        {
            
            Console.WriteLine("\nSevens Out Statistics: ");
            Console.WriteLine($"\nPlayer 1 high score: {hps1}");
            Console.WriteLine($"Player 1 average score: {pas1}");
            Console.WriteLine($"Player 2 high score: {hps2}");
            Console.WriteLine($"Player 2 average score: {pas2}");
            Console.WriteLine($"Computer high score: {hbs}");
            Console.WriteLine($"Computer average score: {bas}");
            Console.WriteLine($"Amount of turns taken played: {sc}");
            Console.WriteLine($"Times dice has been rolled: {dc}");
            Console.WriteLine($"Time game played: {gc}");
        }
    }
}
