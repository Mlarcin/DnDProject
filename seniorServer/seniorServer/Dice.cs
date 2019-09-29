using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorClient
{
    public class Dice
    {
        public Dice() { }

        private Random random = new Random();


        public int RollDice(int sides)
        {

            return random.Next(1, sides+1);
        }

        public int[] multipleRolls(int times, int sides)
        {
            int[] returnArray = new int[times];
            for (int i = 0; i < times; i++)
            {
                returnArray[i] = RollDice(sides+1);
            }
            return returnArray;
        }
        public int RollSeveral(int times, int sides)
        {
            int total = 0;
            for (int i = 0; i < times; i++)
            {
                total += random.Next(1, sides+1);
            }
            return total;
        }
    }
}
