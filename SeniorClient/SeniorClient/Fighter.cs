using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorClient
{
    public class Fighter : Character
    {
        /**/
        /*
        

        NAME

               Fighter::Fighter - Default constructor to Fighter class

        SYNOPSIS

                public Fighter

        DESCRIPTION

                  Default constructor for the Fighter class
                 -Adds all proficiency choices to potentialProficencies string list
                 -Adds Strength Saving Throw and Constitution Saving Throw to proficencies list
                 -Adds Second Wind and Action Surge to abilities list
                 -Sets ActionUsed and SecondUsed boolean values to false

        RETURNS

                NA, constructor function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public Fighter()
        {
            potentialProficiencies.Add("Acrobatics");
            potentialProficiencies.Add("Animal Handling");
            potentialProficiencies.Add("Athletics");
            potentialProficiencies.Add("History");
            potentialProficiencies.Add("Insight");
            potentialProficiencies.Add("Intimidation");
            potentialProficiencies.Add("Perception");
            potentialProficiencies.Add("Survival");

            proficiencies.Add("Strength Saving Throw");
            proficiencies.Add("Constitution Saving Throw");

            abilities.Add("Second Wind");
            abilities.Add("Action Surge");

            ActionUsed = false;
            SecondUsed = false;

        }
        /**/
        /*
        

        NAME

               Fighter::firstLevel - Overriden function used to set the first level of the fighter class

        SYNOPSIS

                public override void firstLevel

        DESCRIPTION

                  Function used to set the maxHP, level, starting items, and armor for the fighter class
                 -Set maxHP to 10 + Constitution modifier
                 -Set currentHP to maxHP
                 -Set level to 1
                 -Create Chain Mail, Greatsword, and Halberd items, and add them to myItems list
                 -Call setArmor

        RETURNS

                NA, void function used to set maxHP, currentHP, and level values, and to call other functions

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override void firstLevel()
        {
            maxHP = 10 + ((Constitution / 2) - 5);
            currentHP = maxHP;
            level = 1;
            item ChainMail = new item(0, 0, 15, "Chain Mail", true);
            item GreatSword = new item(2, 6, 0, "Greatsword", false);
            item Halberd = new item(1, 10, 0, "Halberd", false);
            myItems.Add(ChainMail);
            myItems.Add(GreatSword);
            myItems.Add(Halberd);
            setArmor();
        }

        private bool actionUsed;
        /**/
        /*
        

        NAME

               Fighter::ActionUsed - Property used to get and set the actionUsed boolean

        SYNOPSIS

                public bool ActionUsed

        DESCRIPTION

                  Property used to get and set the actionUsed boolean
                 -get
                 --Return actionUsed
                 -set
                 --Set actionUsed to value

        RETURNS

                On get, returns boolean value determining if the Action Surge ability has been used

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public bool ActionUsed
        {
            get { return actionUsed; }
            set { actionUsed = value; }
        }
        private bool secondUsed;
        /**/
        /*
        

        NAME

               Fighter::SecondUsed - Property used to get and set the secondUsed boolean

        SYNOPSIS

                public bool SecondUsed

        DESCRIPTION

                  Property used to get and set the secondUsed boolean
                 -get
                 --Return secondUsed
                 -set
                 --Set secondUsed to value

        RETURNS

                On get, returns boolean value determining if the Second Wind ability has been used

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public bool SecondUsed
        {
            get { return secondUsed; }
            set { secondUsed = value; }
        }

        /**/
        /*
        

        NAME

               Fighter::LevelUp - Overriden function used to handle the leveling up process for Fighter class

        SYNOPSIS

                public override void LevelUp

        DESCRIPTION

                  Function used to increase maxHP, Level, and heal the character
                  -Calls increaseMaxHP, passing in rollCon(10) for the int value for it
                  -Calls increaseLevel
                  -Calls longRest

        RETURNS

                NA, void function used to call other functions

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override void LevelUp()
        {
            increaseMaxHP(rollCon(10));
            increaseLevel();
            longRest();
        }

        /**/
        /*
        

        NAME

               Fighter::longRest - Overridden function used to handle the Long Rest action for Fighters

        SYNOPSIS

                public override void longRest

        DESCRIPTION

                  Function used to handle the long rest action for fighters, handling the healing and ability resources
                 -Set ActionUsed to false
                 -Set SecondUsed to false
                 -set currentHP to maxHP

        RETURNS

                NA, void function used to set other member variables

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override void longRest()
        {
            ActionUsed = false;
            SecondUsed = false;
            currentHP = maxHP;
        }

        /**/
        /*
        

        NAME

               Fighter::classAbility - Overridden function used to explain the results of the figher class abilities

        SYNOPSIS

                public override string classAbility

        DESCRIPTION

                  Function used to return the results of Fighters activating their class abilities
                  -If abilityChoice is Action Surge
                  --If ActionUsed is false
                  ---Set ActionUsed to true
                  ---Return the results of activating Action Surge
                  --Otherwise, return that Action Surge is unusable
                  -Otherwise, when the choice is Second Wind
                  --If SecondUsed is false
                  ---Set SecondUsed to true
                  ---Return results of activating Second Wind
                  --Otherwise, return that Second Wind is unusable

        RETURNS

                Return string value explaining the result of the attempted ability use

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override string classAbility()
        {
            if (abilityChoice == "Action Surge")
            {
                if (!ActionUsed)
                {
                    ActionUsed = true;
                    return charName + " feels a burst of energy, gaining an additional action and bonus action this turn";
                }
                else
                {
                    return charName + " needs to rest before using Action Surge again";
                }
            }
            else //Second Wind
            {
                if (!SecondUsed)
                {
                    SecondUsed = true;
                    int hpRest = myDie.RollDice(10);
                    currentHP += hpRest;
                    if (currentHP > maxHP) { currentHP = maxHP; }
                    return charName + " takes a breath, using Second Wind. They restore " + hpRest.ToString() + " (1d10) hp.";
                }
                else
                {
                    return charName + " needs to rest before using Second Wind again";
                }
            }
        }

        /**/
        /*
        

        NAME

               Fighter::CanUseAbility - Overriden function used to determine if the class ability of fighters is usable 

        SYNOPSIS

                public override bool CanUseAbility

        DESCRIPTION

                  Function used to determine if function ability is able to be used
                  -Return the opposite of ActionUsed or SecondUsed, whichever is true

        RETURNS

                Returns boolean value representing whether or not the character ability is useable

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override bool CanUseAbility()
        {
            return !ActionUsed || !SecondUsed;
        }
    }
}
