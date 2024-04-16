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

        public void Stats()
        {
            seven.SOStats();
            Console.ReadLine();
            three.TOMStats();
        }
    }
}
