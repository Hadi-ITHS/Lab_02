using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects
{
    internal class Dice
    {
        int numberOfDice;
        int sidesPerDice;
        int modifier;
        public Dice(int numberOfDice, int sidesPerDice, int modifier) 
        {
            this.numberOfDice = numberOfDice;
            this.sidesPerDice = sidesPerDice;
            this.modifier = modifier;
        }

        public int Throw ()
            { return numberOfDice * sidesPerDice + 2; }

        public override string ToString()
        {
            return $"{numberOfDice}d{sidesPerDice}+{modifier}";
        }
    }
}
