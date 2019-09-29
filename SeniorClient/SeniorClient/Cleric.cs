using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorClient
{
    public class Cleric : Character
    {
        /**/
        /*
        

        NAME

                Cleric::Cleric - default constructor for Cleric class

        SYNOPSIS

                Cleric()

        DESCRIPTION

                Constructor for Cleric class
                -Adds all proficiency choioces to potentialProficiencies list of strings
                -Adds Wisdom Saving Throw and Charisma Saving Throw to the proficiencyList list of strings
                -Sets the HavePrayed boolean value to false

        RETURNS

                NA, constructor

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public Cleric()
        {
            potentialProficiencies.Add("History");
            potentialProficiencies.Add("Insight");
            potentialProficiencies.Add("Medicine");
            potentialProficiencies.Add("Persuasion");
            potentialProficiencies.Add("Religion");

            proficiencyList.Add("Wisdom Saving Throw");
            proficiencyList.Add("Charisma Saving Throw");

            HavePrayed = false;
        }

        /**/
        /*
        

        NAME

                Cleric::firstLevel - overriden function used for setting stats for the first level of Clerics

        SYNOPSIS

                public override void firstLevel()

        DESCRIPTION

                 Function to set the starting hp, level, spellSlots, armor, magic, and items for Clerics
                -Sets maxHP to 8 + Constitution modifier
                -Sets level to 1
                -Calls setMaxSlots()
                -Copies spellSlots to currentSlots
                -Creates Mace and ScaleMail items, adding them to myItems list
                -Calls setArmor()
                -Calls checkMagic()

        RETURNS

                NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public override void firstLevel()
        {
            maxHP = 8 + ((Constitution / 2) - 5);
            currentHP = maxHP;
            level = 1;
            setMaxSlots();
            Array.Copy(spellSlots, currentSlots, 9);
            item Mace = new item(1, 6, 0, "Mace", false);
            item ScaleMail = new item(0, 0, 14, "Scale Mail", true);
            myItems.Add(Mace);
            myItems.Add(ScaleMail);
            setArmor();
            checkMagic();
            
        }
        /**/
        /*
        

        NAME

                Cleric::SpellCastBonus - overriden function used for determining what bonus is added to Spell attacks

        SYNOPSIS

                public override int SpellCastBonus()

        DESCRIPTION

                 Function to determine the bonus when attacking with spells
                -Returns Wisdom modifier with Proficiency added

        RETURNS

                Returns int value of the Wisdom modifier + proficiency

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override int SpellCastBonus()
        {
            return ((Wisdom / 2) - 5) + Proficiency;
        }

        /**/
        /*
        

        NAME

                Cleric::CantripsKnown - overriden property used for determining the number of cantrips a Cleric can know at any level

        SYNOPSIS

                public override int CantripsKnown

        DESCRIPTION

                 Property used to determine the number of cantrips a cleric should know at any level
                -If level is less than 4, return 3
                -Else if level is less than 10, return 4
                -Otherwise, return 5

        RETURNS

                Returns int value based on the current level of the character to represent the number of cantrips the cleric should know

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public override int CantripsKnown
        {
            get
            {
                if (level < 4) { return 3; }
                else if (level < 10) { return 4; }
                else { return 5; }
            }
        }

        /**/
        /*
        

        NAME

                Cleric::SpellsKnown - overriden property used for determining the number of spells a cleric should know

        SYNOPSIS

                public override int SpellsKnown

        DESCRIPTION

                 Property used to determine the number of spells a cleric knows at every level
                -If level less than 4, return 3
                -Else if level less than 6, return 4
                -Else if level less than 9, return 5
                -Else if level less than 12, return 7
                -Else if level less than 15, return 8
                -Else if level less than 18, return 10
                -Else if level less than 20, return 12
                -Otherwise, return 15

        RETURNS

                Returns int value used in checking to ensure the amount of spells a cleric should know is accurate

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override int SpellsKnown
        {
            get
            {
                if (level < 4) { return 3; }
                else if (level < 6) { return 4; }
                else if (level < 9) { return 5; }
                else if (level < 12) { return 7; }
                else if (level < 15) { return 8; }
                else if (level < 18) { return 10; }
                else if (level < 20) { return 12; }
                else { return 15; }
            }
        }
        /**/
        /*
        

        NAME

                Cleric::setMaxSlots - overriden function used for setting the maximum spellslots of each level for Clerics

        SYNOPSIS

                public override void setMaxSlots()

        DESCRIPTION

                 Function to set the maximum spellslots of spells for every level
                -Based on character level, sets the spellSlots int array to a certain array

        RETURNS

                NA, void function used to set spellSlots array

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public override void setMaxSlots()
        {
            if (level == 1) { spellSlots = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 }; }
            else if (level == 2) { spellSlots = new int[9] { 3, 0, 0, 0, 0, 0, 0, 0, 0 }; }
            else if (level == 3) { spellSlots = new int[9] { 4, 2, 0, 0, 0, 0, 0, 0, 0 }; }
            else if (level == 4) { spellSlots = new int[9] { 4, 3, 0, 0, 0, 0, 0, 0, 0 }; }
            else if (level == 5) { spellSlots = new int[9] { 4, 3, 2, 0, 0, 0, 0, 0, 0 }; }
            else if (level == 6) { spellSlots = new int[9] { 4, 3, 3, 0, 0, 0, 0, 0, 0 }; }
            else if (level == 7) { spellSlots = new int[9] { 4, 3, 3, 1, 0, 0, 0, 0, 0 }; }
            else if (level == 8) { spellSlots = new int[9] { 4, 3, 3, 2, 0, 0, 0, 0, 0 }; }
            else if (level == 9) { spellSlots = new int[9] { 4, 3, 3, 3, 1, 0, 0, 0, 0 }; }
            else if (level == 10) { spellSlots = new int[9] { 4, 3, 3, 3, 2, 0, 0, 0, 0 }; }
            else if (level == 11 || level == 12) { spellSlots = new int[9] { 4, 3, 3, 3, 2, 1, 0, 0, 0 }; }
            else if (level == 13 || level == 14) { spellSlots = new int[9] { 4, 3, 3, 3, 2, 1, 1, 0, 0 }; }
            else if (level == 15 || level == 16) { spellSlots = new int[9] { 4, 3, 3, 3, 2, 1, 1, 1, 0 }; }
            else if (level == 17) { spellSlots = new int[9] { 4, 3, 3, 3, 2, 1, 1, 1, 1 }; }
            else if (level == 18) { spellSlots = new int[9] { 4, 3, 3, 3, 3, 1, 1, 1, 1 }; }
            else if (level == 19) { spellSlots = new int[9] { 4, 3, 3, 3, 3, 2, 1, 1, 1 }; }
            else { spellSlots = new int[9] { 4, 3, 3, 3, 3, 2, 2, 1, 1 }; }
        }

        /**/
        /*
        

        NAME

                Cleric::LevelUp - overriden function used for the leveling up process for Clerics

        SYNOPSIS

                public override void LevelUp()

        DESCRIPTION

                 Function to level up Clerics from one level to the next, and handle all the strength increases that comes with it
                -Calls increaseMaxHp, using rollCon(8) as the int value for it
                -Calls increaseLevel
                -Calls setMaxSlots
                -Copies spellSlots to currentSlots
                -Calls checkMagic

        RETURNS

                NA, void function used to call other functions and set value of currentSlots

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override void LevelUp()
        {
            increaseMaxHP(rollCon(8));
            increaseLevel();
            setMaxSlots();
            longRest();
            checkMagic();
        }


        /**/
        /*
        

        NAME

                Cleric::longRest - overriden function used allowing Clerics to take a long rest

        SYNOPSIS

                public override void longRest()

        DESCRIPTION

                 Function used to enable the long rest ability for Clerics
                -Sets currentHP to maxHP, healing the character completely
                -Sets HavePrayed to false, allowing use of class ability in the future
                -Copies spellSlots to currentSlots

        RETURNS

                NA, void function used to set currentHP, HavePrayed, and currentSlots

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override void longRest()
        {
            currentHP = maxHP;
            HavePrayed = false;
            Array.Copy(spellSlots, currentSlots, 9);
        }

        /**/
        /*
        

        NAME

                Cleric::shortRest - overriden function used for letting Clerics take a short rest

        SYNOPSIS

                public override void shortRest()

        DESCRIPTION

                 Function used to enable the Clerics short rest ability
                -Calls heal function, passing rollCon(8) in as the int value

        RETURNS

                NA, void function used to heal HP

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

                Cleric::classAbility - overriden function used for using the Cleric class ability

        SYNOPSIS

                public override string classAbility()

        DESCRIPTION

                 Function used when activating Cleric class ability
                -Sets HavePrayed to true
                -Creates int variable favor and sets it to 0
                -If proficiencies list contains "Religion", favor is increased by Proficiency bonus
                -Returns string of charName + description of the ability + the result of a rollCha(20) roll + favor.ToString()

        RETURNS

                Returns string value detailing what happens when the Cleric class ability is activated

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override string classAbility()
        {
            HavePrayed = true;
            int favor = 0;
            if (proficiencies.Contains("Religion")) { favor += Proficiency; }
            return charName + " prays for devine intervention, asking for a minor miracle. They roll a religion check to attempt to garner their diety's favor, and roll " + (rollCha(20) + favor).ToString() + ".";
        }

        private bool havePrayed;
        /**/
        /*
        

        NAME

                Cleric::HavePrayed - Property used for returning the boolean havePrayed value

        SYNOPSIS

                HavePrayed()

        DESCRIPTION

                 Property used for returning the boolean havePrayed value
                -get
                --Returns havePrayed

        RETURNS

                Returns boolean value whether or not the class ability has been used this rest cycle

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public bool HavePrayed
        {
            get { return havePrayed; }
            set { havePrayed = value; ; }
        }

        /**/
        /*
        

        NAME

                Cleric::CanUseAbility - Overriden function used for determining if the class ability can be used or not

        SYNOPSIS

                public override bool CanUseAbility()

        DESCRIPTION

                 Function used to see if the characters class ability can be used
                -returns the opposite of HavePrayed

        RETURNS

                Returns boolean value whether or not the class ability can be used

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public override bool CanUseAbility()
        {
            return !(HavePrayed);
        }
    }
}
