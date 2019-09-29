using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorClient
{
    public class Druid : Character
    {
        /**/
        /*
        

        NAME

               Druid::Druid - Constructor for druid class

        SYNOPSIS

                public Druid()

        DESCRIPTION

                 Default construtor for druid class
                 -Adds all proficiency choices to potentialProficiencies list
                 -Adds Intelligence Saving Throw and Wisdom Saving Throw proficiencies to proficiencies
                 -Adds "Wolf", "Bear", and "Tortoise" to the abilities list for selecting of class abilities
                 -Sets haveUsedAbility to false

        RETURNS

                NA, constructor function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public Druid()
        {
            potentialProficiencies.Add("Arcana");
            potentialProficiencies.Add("Animal Handling");
            potentialProficiencies.Add("Insight");
            potentialProficiencies.Add("Medicine");
            potentialProficiencies.Add("Nature");
            potentialProficiencies.Add("Perception");
            potentialProficiencies.Add("Religion");
            potentialProficiencies.Add("Survival");

            proficiencies.Add("Intelligence Saving Throw");
            proficiencies.Add("Wisdom Saving Throw");

            List<string> tempList = new List<string>() { "Wolf", "Tortoise", "Bear" };

            abilities.AddRange(tempList);

            haveUsedAbility = false;
        }

        /**/
        /*
        

        NAME

               Druid::firstLevel - Overriden function to set Druid characters to their first level

        SYNOPSIS

                public override void firstLevel()

        DESCRIPTION

                  Function used to set a druid character at their first level for play
                 -Sets maxHP to 8 + Constitution modifier
                 -Sets level to 1
                 -Calls setMaxSlots
                 -Copies spellSlots to currentSlots
                 -Creates Dagger, Scimitar, and Leather Armor items, and adds them to myItems
                 -Calls setArmor
                 -Calls checkMagic

        RETURNS

                NA, constructor function

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
            item Dagger = new item(1, 4, 0, "Dagger", true);
            item Scimitar = new item(1, 6, 0, "Scimitar", true);
            item LeatherArmor = new item(0, 0, 11, "Leather Armor", true);
            myItems.Add(Dagger);
            myItems.Add(Scimitar);
            myItems.Add(LeatherArmor);
            setArmor();
            checkMagic();


        }

        /**/
        /*
        

        NAME

               Druid::SpellCastBonus - Overriden property used to get the Spellcast Bonus when attacking with some spells

        SYNOPSIS

                public override int SpellCastBonus

        DESCRIPTION

                  Property used to return an int value to be added to spell attack rolls
                 -Returns Wisdom modifier + proficiency bonus

        RETURNS

                Returns int value used to add to spell attack rolls

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

               Druid::CantripsKnown - Overriden property used to get the number of cantrips a Druid can know at any level

        SYNOPSIS

                public override int CantripsKnown

        DESCRIPTION

                  Property used to return the number of cantrips a druid can know at any time
                 -If level is less than 4, return 2
                 -Else if level is less than 10, return 3
                 -Otherwise, return 4

        RETURNS

                Returns int value used to check that the number of Cantrips currently available to a Druid is as high as it should be

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override int CantripsKnown
        {
            get
            {
                if (level < 4) { return 2; }
                else if (level < 10) { return 3; }
                else { return 4; }
            }
        }

        /**/
        /*
        

        NAME

               Druid::SpellsKnown - Overriden property used to get the number of spells a Druid can know at any level

        SYNOPSIS

                public override int SpellsKnown

        DESCRIPTION

                  Property used to return the number of spells a druid can know at any time
                 -Return level + Wisdom modifier

        RETURNS

                Returns int value used to check that the number of spells currently available to a Druid is as high as it should be

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override int SpellsKnown
        {
            get
            {
                return (level + ((Wisdom / 2) - 5));
            }
        }

        /**/
        /*
        

        NAME

                Druid::setMaxSlots() - overriden function used for setting the maximum spellslots of each level for Druids

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

               Druid::LevelUp - Overriden function used to handle all of the increases in strength that comes with leveling up for Druids

        SYNOPSIS

                public override void LevelUp

        DESCRIPTION

                  Function used to increase maxHP, level, spellSlots, and magic learned
                 -Calls increaseMaxHP function, passing in rollCon(8) as the int value for its parameter
                 -Calls increaseLevel
                 -Calls setMaxSlots
                 -Copies spellSlots to currentSlots
                 -Sets HaveUsedAbility boolean to false
                 -Calls checkMagic

        RETURNS

                NA, void function used to call other functions and set currentSlots and HaveUsedAbility

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
            HaveUsedAbility = false;
            checkMagic();
        }

        /**/
        /*
        

        NAME

               Druid::LongRest - Overriden function used to allow Druids to take a long rest

        SYNOPSIS

                public override void longRest

        DESCRIPTION

                  Function used to facilitate the Long Rest action for Druids
                 -Set currentHP to maxHP
                 -Copy spellSlots array to currentSlots array
                 -Set HaveUsedAbility to false

        RETURNS

                NA, void function used to set some class variable values

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override void longRest()
        {
            currentHP = maxHP;
            Array.Copy(spellSlots, currentSlots, 9);
            HaveUsedAbility = false;
        }

        private bool haveUsedAbility;
        /**/
        /*
        

        NAME

               Druid::HaveUsedAbility - Property used to return and set the haveUsedAbility boolean value

        SYNOPSIS

                public bool HaveUsedAbility

        DESCRIPTION

                  Property used to return whether or not the Cleric class ability has been used
                 -Get
                 --return haveUsedAbility
                 -Set
                 --Set haveUsedAbility to value

        RETURNS

                Returns boolean value to determine if the class ability has been used yet in this rest cycle

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public bool HaveUsedAbility
        {
            get { return haveUsedAbility; }
            set { haveUsedAbility = value; }
        }

        /**/
        /*
        

        NAME

               Druid::shortRest - Overriden function used to allow the Druid class to take the Short Rest action

        SYNOPSIS

                public override void shortRest

        DESCRIPTION

                  Function used to allow Druids to take a short rest
                 -Call heal, and use rollCon(8) as the int value passed into it
                 -Set HaveUsedAbility to false

        RETURNS

                Returns int value used to check that the number of spells currently available to a Druid is as high as it should be

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override void shortRest()
        {
            heal(rollCon(8));
            HaveUsedAbility = false;
        }

        /**/
        /*
        

        NAME

               Druid::classAbility - Overriden function used to facilitate the using of the Druid's various class abilities

        SYNOPSIS

                public override string classAbility

        DESCRIPTION

                  Function used to activate the Druid class ability
                 -Set HaveUsedAbility to true
                 -If abilityChoice is "Wolf"
                 --Return the specific string for the Wolf spirit ability
                 -Else if abilityChoice is Tortoise
                 --Return the specific string for the Tortoise spirit ability
                 -Otherwise (the only option being bear)
                 --Return the specific string for the Bear spirit ability

        RETURNS

                Returns string value representing the result of the ability used by the Druid

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override string classAbility()
        {

            HaveUsedAbility = true;
            if (abilityChoice == "Wolf")
            {
                return charName + " invokes the spirit of the Wolf, gaining 10 extra movement speed. \n";
            }
            else if (abilityChoice == "Tortoise")
            {
                return charName + " invokes the spirite of the tortoise, taking half damage for the rest of combat. \n";
            }
            else
            {
                return charName + " invokes the spirit of the bear, gaining an additional damage die on phyisical attacks made this combat. \n";
            }

        }

        /**/
        /*
        

        NAME

               Druid::CanUseAbility - Overriden function used to determine if the class ability of Druid can be used

        SYNOPSIS

                public override bool CanUseAbility

        DESCRIPTION

                  Function used to return boolean determining if the class ability can be used
                 -Return the opposite of HaveUsedAbility

        RETURNS

                Returns boolean value determining if class ability is currently useable
        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override bool CanUseAbility()
        {
            return !haveUsedAbility;
        }

    }
}
