using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorClient
{
    public class Barbarian : Character
    {
        /**/
        /*
        

        NAME

                Bariarian::Barbarian() - default constructor for Barbarian class

        SYNOPSIS

                Barbarian();

        DESCRIPTION

                Default constructor the Barbarian class. 
                -Adds all correct Barbarian proficiency choioces to the potentialProficiencies list
                which is used in character creation.
                -Adds Strength and Constitution Saving throw proficiencies
                -Sets raging, a boolean used in the charcters ability, to false
        RETURNS

                NA - just constructor

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public Barbarian()
        {
            potentialProficiencies.Add("Animal Handling");
            potentialProficiencies.Add("Athletics");
            potentialProficiencies.Add("Intimidation");
            potentialProficiencies.Add("Nature");
            potentialProficiencies.Add("Perception");
            potentialProficiencies.Add("Survival");

            proficiencyList.Add("Strength Saving Throw");
            proficiencyList.Add("Constituion Saving Throw");

            raging = false;
        }

        /**/
        /*
        

        NAME

                Bariarian::firstLevel() - function used to start at level 1 for Barbarians

        SYNOPSIS

                void Barbarian::firstLevel()

        DESCRIPTION

                Function to handle level 1 preparation for Barbarians 
                -Sets maxHP to 12 + Constitution modifer
                -Sets currentHP to maxHP
                -Calls setArmor(), setting armor class
                -Sets level to 1
                -Creates Greataxe and Handaxe, adding them to inventory
                -Sets Rage uses to MaxRageUsages
        RETURNS

                NA - void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override void firstLevel()
        {
            maxHP = 12 + ((Constitution / 2) - 5);
            currentHP = maxHP;
            setArmor();
            level = 1;
            item Greataxe = new item(1, 12, 0, "Greataxe", false);
            item Handaxe = new item(1, 6, 0, "Handaxe", false);
            myItems.Add(Greataxe);
            myItems.Add(Handaxe);
            Rages = MaxRageUsages;
        }

        /**/
        /*
        

        NAME

                Bariarian::LeveLUp() - function used to handle leveling up of Barbarian

        SYNOPSIS

                void LevelUp();

        DESCRIPTION

                Function used to handle leveling up of Barbarian characters 
                -calls increaseMaxHp and passes in rollCon(12) as the value, rolling constitution with a d12 to determine health gains
                -calls increaseLevel(), increasing the Level value and handling any stat increases that may occur
                
        RETURNS

                NA - void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        override public void LevelUp()
        {
            increaseMaxHP(rollCon(12));
            increaseLevel();
            
        }
        private bool raging;


        /**/
        /*
        

        NAME

                Bariarian::MaxRageUsages - Property to get the maximum amount of times a Barbarian can rage before a long rest

        SYNOPSIS

                int MaxRageUsages

        DESCRIPTION

                Property used to determine most rage usages at any level
                -get
                --if level is less than 3, returns 2
                --if level is less than 6, returns 3
                --if level is less than 13, returns 4
                --if level is less than 17, returns 5
                --if level is less than 20, return 6
                --if level is 20, returns int.MaxValue to represent unlimited uses
        RETURNS

                int MaxRageUsages, amount of times rage ability can be used before a long rest must be taken

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int MaxRageUsages
        {
            get
            {
                if (level < 3) { return 2; }
                else if (level < 6) { return 3; }
                else if (level < 13) { return 4; }
                else if (level < 17) { return 5; }
                else if (level < 20) { return 6; }
                else { return int.MaxValue; }
            }

        }
        /**/
        /*
        

        NAME

                Bariarian::RageBonuses() - property used to determine how much rage increases strength rolls

        SYNOPSIS

                int RageBonuses;

        DESCRIPTION

                Property returning the value given at different levels for raging
                -get
                --if level is less than 5, return 2
                --if level is less than 9, return 3
                --if level is less than 13, return 4
                --if level is less than 17, return 5
                --otherwise, return 6
        RETURNS

                int RageBonuses, amount to increase rollStr() results by when raging at any level

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int RageBonuses
        {
            get
            {
                if (level < 5) { return 2; }
                else if (level < 9) { return 3; }
                else if (level < 13) { return 4; }
                else if (level < 17) { return 5; }
                else { return 6; }
            }
        }
        /**/
        /*
        

        NAME

                Bariarian::rollStr(int sides) - overriden rollStr function to handle Barbarian raging

        SYNOPSIS

                public override int rollStr(int sides)
                    sides -> the amount of sides of the die being rolled

        DESCRIPTION

                Rolls a die, and if the Barbarian is raging then the roll will be increased by the rage bonuses
                -if raging, roll a die of the sides you determine, add your strength modifier, and you RageBonuses value
                -otherwise, just roll a die of the sides you determine and add your strength modifier
        RETURNS

                Returns int result of the die roll and modifiers

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override int rollStr(int sides)
        {
            if (raging) { return (myDie.RollDice(sides) + ((Strength - 10) / 2)) + RageBonuses; }
            else { return myDie.RollDice(sides) + ((Strength - 10) / 2); }
        }

        private int currentRages;
        /**/
        /*
        

        NAME

                Bariarian::Rages() - Property to return the amount of rages currently available to the barbarian

        SYNOPSIS

                int Rages;

        DESCRIPTION

                Property for the currentRages value
                -get: return currentRages
                -set: currentRages = set value
        RETURNS

                On get, returns currentRages. On set, sets currentRages.

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int Rages
        {
            get { return currentRages; }
            set { currentRages = value; }
        }

        /**/
        /*
        

        NAME

                Bariarian::longRest() - overriden longRest function specific to barbarian

        SYNOPSIS

                void longRest();

        DESCRIPTION

                Lets Barbarian take a long rest, healing completely, refreshing rage uses, and ending any rage currently happening
                -Sets currentHP to maxHP
                -Sets currentRages to MaxRageUsages
                -Sets raging to false

        RETURNS

                NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        override public void longRest()
        {
            currentHP = maxHP;
            currentRages = MaxRageUsages;
            raging = false;
        }
        /**/
        /*
        

        NAME

                Bariarian::shortRest() - overriden shortRest function specific to Barbarians

        SYNOPSIS

                public override void shortRest();

        DESCRIPTION

                Lets the Barbarian take a short rest, healing 1d12 roll, and ending any rage happenign
                -heals a d12 constitution roll
                -sets raging to false
        RETURNS

                NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        override public void shortRest()
        {
            heal(rollCon(12));
            raging = false;
        }
        /**/
        /*
        

        NAME

                Bariarian::classAbility() - overriden class ability specific to Barbarian, letting them use rage

        SYNOPSIS

                public override string classAbility()

        DESCRIPTION

                Activates the barbarians rage, increasing their strength for it's durration
                -if the barbarian is not raging
                --begin raging
                --reduce the amount of rages that are remaining
                --return successful string
                -if raging
                --return failure string(already raging)
        RETURNS

                Returns string result of attempting to rage, either indicating successs if the rage is activated or failure if it was already activated

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public override string classAbility()
        {
            if (!raging)
            {
                raging = true;
                currentRages--;
                return charName + " begins to rage, empowering their phyiscal strength with their anger.";
            }
            return charName + " is already raging.";
        }

        /**/
        /*
        

        NAME

                Bariarian::CanUseAbility() - overriden CanUseAbility function for Barbarians

        SYNOPSIS

                public override bool CanUseAbility()

        DESCRIPTION

                Returns a bool that tells if the Class Ability can be used
                -returns whether or not currentRages is greater than 0
        RETURNS

                Returns bool result of currentRages>0

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override bool CanUseAbility()
        {
            return (currentRages > 0); ;
        }

        /**/
        /*
        

        NAME

                Bariarian::setArmor() - overriden setArmor function to handle Barbarian specific handling of Armor class

        SYNOPSIS

                public override void setArmor()

        DESCRIPTION

                Sets the armor class of the Barbarian, using it's specific class rules to determine
                -Checks through all items in myItems and locates items with an armor value
                -If an item with an armor value is found, hasArmor boolean is set to true, otherwise left as false
                -If the hasArmor boolean is true, armorClass is set to the highest value among all armored items
                -If hasArmor is false, armorClass is set to 10 + Dexterity Modifier + Constitution Modifier *This is the difference from the default*

        RETURNS

                NA, void function

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
            else //No armor
            {
                armorClass = 10 + ((Dexterity / 2) - 5) + ((Constitution / 2) - 5);
            }
        }
    }
}
