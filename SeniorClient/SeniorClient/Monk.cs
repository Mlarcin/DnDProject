using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorClient
{
    public class Monk : Character
    {
        /**/
        /*
        

        NAME

               Monk::Monk - Default constructor for Monk class

        SYNOPSIS

                public Monk

        DESCRIPTION

                   Default constructor used for the Monk class
                  -Adds all proficiency choices to the potentialProficiencies list
                  -Adds Strength Saving Throw and Wisdom Saving Throw to the proficiencies
                  -Adds Step of the Wind, Patient Defense, and Flurry of Blows strings to the ablities list

        RETURNS

                NA, constructor function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public Monk()
        {
            potentialProficiencies.Add("Acrobatics");
            potentialProficiencies.Add("Athletics");
            potentialProficiencies.Add("History");
            potentialProficiencies.Add("Insight");
            potentialProficiencies.Add("Religion");
            potentialProficiencies.Add("Stealth");

            proficiencies.Add("Strength Saving Throw");
            proficiencies.Add("Wisdom Saving Throw");

            abilities.Add("Step of the Wind");
            abilities.Add("Patient Defense");
            abilities.Add("Flurry of Blows");
        }

        /**/
        /*
        

        NAME

               Monk::firstLevel - Overriden function used to handle the first level setting for Monks

        SYNOPSIS

                public override void firstLevel

        DESCRIPTION

                   Function used to set maxHP, level, CurrentKi, starting items, and armor
                  -Sets maxHP to 8 + Constitution modifier
                  -Sets currentHP to maxHP
                  -Sets level to 1
                  -Sets currentKi to MaxKi
                  -Creates Shortsword and Marial Arts items, and adds them to myItems
                  -Calls setArmor

        RETURNS

                NA, void function used to set other values and call other functions

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override void firstLevel()
        {
            maxHP = 8 + ((Constitution / 2) - 5);
            CurrentHP = MaxHP;
            level = 1;
            CurrentKi = MaxKi;
            item Shortsword = new item(1, 6, 0, "Shortsword", false);
            item MartialArts = new item(1, 4, 0, "Martial Arts", true);
            myItems.Add(Shortsword);
            myItems.Add(MartialArts);
            setArmor();
            
        }

        private int currentKi;
        /**/
        /*
        

        NAME

               Monk::CurrentKi - Property used to return/set currentKi value

        SYNOPSIS

                public CurrentKi

        DESCRIPTION

                   Property used to return/set currentKi value
                  -Get
                  --Return currentKi
                  -Set
                  --Set currentKi to value

        RETURNS

                On get, return int value representing the value of the remaining Ki uses

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int CurrentKi
        {
            get { return currentKi; }
            set { currentKi = value; }
        }
        /**/
        /*
        

        NAME

               Monk::MaxKi - Property used to return the maximum amount of Ki a monk can have at any level 
        SYNOPSIS

                public MaxKi

        DESCRIPTION

                   Property used to return how much Ki a monk has at most at any level
                  -Return level

        RETURNS

                Returns int value representing how many ki uses monks have at any level

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public int MaxKi
        {
            get { return level; }
        }

        /**/
        /*
        

        NAME

               Monk::LevelUp - Overriden function used to handle the leveling up of monks and the strength increases that occur with that

        SYNOPSIS

                public override void LevelUp

        DESCRIPTION

                   Function used to handle the increases in strength the comes with a Monk's levelup
                   -Call increaseMaxHp, passing in rollCon(8) for the value for it
                   -Call increaseLevel
                   -Call longRest
                   -If level is now 5, 11, or 17, replace the old Martial Arts item with a stronger one

        RETURNS

                NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override void LevelUp()
        {
            increaseMaxHP(rollCon(8));
            increaseLevel();
            longRest();
            if (level == 5)
            {
                myItems.Remove(myItems.Find(x => x.Name == "Martial Arts"));
                item MartialArts = new item(1, 6, 0, "Martial Arts", true);
                myItems.Add(MartialArts);
            }
            else if (level == 11)
            {
                myItems.Remove(myItems.Find(x => x.Name == "Martial Arts"));
                item MartialArts = new item(1, 8, 0, "Martial Arts", true);
                myItems.Add(MartialArts);
            }
            else if (level == 17)
            {
                myItems.Remove(myItems.Find(x => x.Name == "Martial Arts"));
                item MartialArts = new item(1, 10, 0, "Martial Arts", true);
                myItems.Add(MartialArts);
            }
        }
        /**/
        /*
        

        NAME

               Monk::longRest - Overriden function used to facilitate the long rest ability for Monks

        SYNOPSIS

                public override void longRest

        DESCRIPTION

                   Function used to allow monks to take a long rest, handling the components that come with that
                   -Sets currentHP to maxHP
                   -Sets currentKi to MaxKi

        RETURNS

                NA, void function that sets other member variable values

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override void longRest()
        {
            currentHP = maxHP;
            currentKi = MaxKi;
        }

        /**/
        /*
        

        NAME

               Monk::shortRest - Overriden function used to facilitate the short rest ability for Monks

        SYNOPSIS

                public override void shortRest

        DESCRIPTION

                   Function used to allow monks to take a short rest, handling the components that come with that
                   -Calls heal, passing in rollCon(8) as the parameter for it

        RETURNS

                NA, void function that calls another function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override void shortRest()
        {
            heal(rollCon(8));
        }

        /**/
        /*
        

        NAME

               Monk::classAbility - Overriden function used to return the results of the Monk's attempt to activate their class ability

        SYNOPSIS

                public override string classAbility

        DESCRIPTION

                   Function determines which class ability is being used, and returns the results of what happens
                   -Decrement currentKi
                   -Depending on the AbilityChoice, a different result string is returned

        RETURNS

                Returns string value explaining the result of the class ability activation

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override string classAbility()
        {
            currentKi--;
            if (AbilityChoice == "Step of the Wind")
            {
                return charName + " channels their ki, activating Step of the Wind. Their jump distance is doubled, and they can take the Disengage or Dash actions as a bonus action.";
            }
            else if (AbilityChoice == "Patient Defense")
            {
                return charName + " channels their ki, activating Patient Defense and taking the Dodge action as a bonus action ";
            }
            else//Flurry of Blows 
            {
                return charName + " channels their ki, activating Flurry of Blows, allowing them to make 2 unarmed strikes as a bonus action.";
            }

        }

        /**/
        /*
        

        NAME

               Monk::CanUseAbility - Overriden function used to determine if the class ability of Monks is usable 

        SYNOPSIS

                public override bool CanUseAbility

        DESCRIPTION

                  Function used to determine if function ability is able to be used
                  -Return the result of currentKi>0

        RETURNS

                Returns boolean value representing whether or not the character ability is useable

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override bool CanUseAbility()
        {
            return (currentKi > 0);
        }

        /**/
        /*
        

        NAME

               Monk::setArmor - Overriden function used to set the armor class of a Monk

        SYNOPSIS

                public override void setArmor

        DESCRIPTION

                  Function used to set the armor class of Monks
                  -Initialize boolean hasArmor and set to false
                  -Look at all items currently held, and if any of them have an armor value, store the index in the list itemLocation, and set hasArmor to true
                  -If hasArmor is true, set the armorclass to the highest armor among all items
                  -Otherwise, set armor class to 10 + Dexterity modifier + Wisdom modifier

        RETURNS

                NA, void function used to set value of armorClass

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override void setArmor()
        {
            bool hasArmor = false;
            List<int> itemLocation = new List<int>();
            for (int i = 0; i < myItems.Count(); i++)
            {
                if (myItems[i].Armor != 0)
                {
                    hasArmor = true;
                    itemLocation.Add(i);
                }
            }
            if (hasArmor)
            {
                armorClass = 0;
                for (int i = 0; i < itemLocation.Count(); i++)
                {
                    if (armorClass < myItems[itemLocation[i]].Armor)
                    {
                        armorClass = myItems[itemLocation[i]].Armor + ((Dexterity / 2) - 5);
                    }
                }

            }
            else
            {
                armorClass = 10 + ((Dexterity / 2) - 5) + ((Wisdom / 2) - 5);
            }
        }
    }
}
