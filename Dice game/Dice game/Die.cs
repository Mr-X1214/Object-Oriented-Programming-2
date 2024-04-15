using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_game
{
    internal class Die
    {
        // this creates the variable for the value of the die roll to be stored in
        public int dieValue = 0;

        //Method


        // this is the method that rolls the dice
        public int Roll()
        {
            // creates the random
            Random rand = new Random();
            // gets the random number
            dieValue = rand.Next(1, 7);

            // returns the value
            return dieValue;
        }
    }
}
