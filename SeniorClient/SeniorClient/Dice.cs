using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorClient
{
    public class Dice
    {
        /**/
        /*
        

        NAME

               Dice::Dice - Default constructor for Dice class

        SYNOPSIS

                Dice()

        DESCRIPTION

                 Constructor for Dice class


        RETURNS

                NA, class constructor

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public Dice() { }

        private Random random = new Random();

        /**/
        /*
        

        NAME

               Dice::RollDice - Function to roll a die

        SYNOPSIS

                public int RollDice(int sides)

            int sides-> the number of sides the die to be rolled will have

        DESCRIPTION

                 Function used to roll dice
                 -return the next random value between the range of 1 and the amount of sides determined by int sides


        RETURNS

                Returns int value based on the result of the random.Next call

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int RollDice(int sides)
        {

            return random.Next(1, sides+1);
        }

        /**/
        /*
        

        NAME

               Dice::multipleRolls - Function used to return several results of dice.RollDice

        SYNOPSIS

                multipleRolls(int times, int sides)

            int times -> the number of times the dice will be rolled, causing the number of elements in the array that will be returned
            int side -> the number of sides the dice being rolled will have

        DESCRIPTION

                 Function to return array of int results for rolling a die
                 -Create int array returnArray, giving it a size equal to times
                 -For every spot in the array, set that spot equal to RollDice(sides)
                 -Return returnArray


        RETURNS

                Returns an integer array to determine the results of the several consecutive dice rolls

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int[] multipleRolls(int times, int sides)
        {
            int[] returnArray = new int[times];
            for (int i = 0; i < times; i++)
            {
                returnArray[i] = RollDice(sides+1);
            }
            return returnArray;
        }

        /**/
        /*
        

        NAME

               Dice::RollSeveral - Function used to roll many of a single dice to create a single sum result

        SYNOPSIS

                public int RollSeveral(int times, int sides)

            int times -> int value to determine the number of times the die will be rolled
            int sides -> int value to determine the number of sides the die being rolled will have

        DESCRIPTION

                 Function to return the sum of many dice rolls as one value
                 -Initialize int total and set it to 0
                 -For the number of times equal to times, add to total the result of a dice roll with the number of sides determined by 'sides'
                 -Return total


        RETURNS

                Returns int value based on the sum of all of the dice rolls

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int RollSeveral(int times, int sides)
        {
            int total = 0;
            for (int i = 0; i < times; i++)
            {
                total += RollDice(sides+1);
            }
            return total;
        }
    }
}
