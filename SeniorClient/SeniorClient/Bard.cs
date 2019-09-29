using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorClient
{
    public class Bard : Character
    {
        /**/
        /*
        

        NAME

                Bard::Bard() - default constructor for Bard class

        SYNOPSIS

                Bard();

        DESCRIPTION

                Default constructor for the Bard class
                -Adds all proficiency choices to potentialProficiencies list, used in character creation
                -Adds Dexterity and Charisma Saving Throw proficiences to proficiencyList
        RETURNS

                NA, constructor

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public Bard()
        {
            potentialProficiencies.Add("Acrobatics");
            potentialProficiencies.Add("Animal Handling");
            potentialProficiencies.Add("Arcana");
            potentialProficiencies.Add("Athletics");
            potentialProficiencies.Add("Deception");
            potentialProficiencies.Add("History");
            potentialProficiencies.Add("Insight");
            potentialProficiencies.Add("Intimidation");
            potentialProficiencies.Add("Ivestigation");
            potentialProficiencies.Add("Medicine");
            potentialProficiencies.Add("Nature");
            potentialProficiencies.Add("Perception");
            potentialProficiencies.Add("Performance");
            potentialProficiencies.Add("Persuasion");
            potentialProficiencies.Add("Religion");
            potentialProficiencies.Add("Slight of Hand");
            potentialProficiencies.Add("Stealth");
            potentialProficiencies.Add("Survival");

            proficiencyList.Add("Dexterity Saving Throw");
            proficiencyList.Add("Charisma Saving Throw");
        }

        /**/
        /*
        

        NAME

                Bard::firstLevel() - overriden firstLevel function specifically for Bard class

        SYNOPSIS

                public override void firstLevel()

        DESCRIPTION

                Function designed to set all level 1 values for the Bard class
                -Sets level equal to 1
                -Sets maxHP equal to 8 plus constitution modifier
                -Sets currentHp = maxHp
                -Sets currentInsp = MaxInsp
                -Calls setArmor(), setting the armor class value
                -Calls setMaxSlots(), setting the max number of spellslots for ever level of spell
                -Copys spellSlots to currentSlots, giving the amount of uses the Bard currently has equal to the max number of spellslots which had just been set
                -Calls checkMagic, making sure there is no more spells the bard is able to learn currently, and allowing it to pick new spells if there are
                -Creates Rapier, Dagger, and Leather Armor items, adding them all ot myItems list
        RETURNS

                NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public override void firstLevel()
        {
            level = 1;
            maxHP = 8 + ((Constitution / 2) - 5);
            currentHP = maxHP;            
            currentInsp = MaxInsp;
            setArmor();
            
            setMaxSlots();
            Array.Copy(spellSlots, currentSlots, 9);
            checkMagic();  
            
            item Rapier = new item(1, 8, 0, "Rapier", true);
            item Dagger = new item(1, 4, 0, "Dagger", true);
            item LeatherArmor = new item(0, 0, 11, "Leather Armor", true);
            myItems.Add(Rapier);
            myItems.Add(Dagger);
            myItems.Add(LeatherArmor);
        }

        /**/
        /*
        

        NAME

                Bard::SpellCastBonus() - overriden SpellCastBonus function, determining class specific bonus to casting spell attacks

        SYNOPSIS

                public override int SpellCastBonus()

        DESCRIPTION

                Int value of the spellcast bonus, which is added to spells when they are cast and require attack rolls
                -Returns Charisma modifier + Proficiency
        RETURNS

                Returns int value equal to Charimsa modifier + Proficiency

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public override int SpellCastBonus()
        {
            return (((Charisma / 2) - 5) + Proficiency);
        }

        /**/
        /*
        

        NAME

                Bard::InspirationDie - property used to determine the number of sides awarded when Bards use their Class Ablity

        SYNOPSIS

                InspirationDie;

        DESCRIPTION

                Property used in determining the sides of inspiration dice awarded by the Bard class ability
                -If level is less than 5, return 6
                -Else if level is less than 10, return 8
                -Else if level is less than 15, return 10
                -Otherwise, return 12
        RETURNS

                Returns int value based on the current level of the character

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int InspirationDie
        {
            get
            {
                if (level < 5)
                {
                    return 6;
                }
                else if (level < 10) { return 8; }
                else if (level < 15) { return 10; }
                else { return 12; }
            }
        }

        /**/
        /*
        

        NAME

                Bard::CantripsKnown - property used to determine the number of cantrips that a Bard should know at any given level

        SYNOPSIS

                CantripsKnown;

        DESCRIPTION

                Property used in determining the amount of cantrips a bard should have
                -If level is less than 4, return 2 
                -Else if level is less than 10, return 3
                -Otherwise return 4
        RETURNS

                Returns int value based on the current level of the character

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        override public int CantripsKnown
        {
            get
            {
                if (level < 4)
                {
                    return 2;
                }
                else if (level < 10) { return 3; }
                else { return 4; }
            }
        }
        /**/
        /*
        

        NAME

                Bard::CantripsKnown - property used to determine the number of spells that a Bard should know at any given level

        SYNOPSIS

                SpellsKnownn;

        DESCRIPTION

                Property used in determining the amount of spells a bard should have
                -If level is 1, return 4
                -Else if level is 2, return 5
                -Else if level is 3, return 6
                -Else if level is 4, return 7
                -Else if level is 5, return 8
                -Else if level is 6, return 9
                -Else if level is 7, return 10
                -Else if level is 8, return 11
                -Else if level is 9, return 12
                -Else if level is 10, return 14
                -Else if level is less than or equal to 12, return 15
                -Else if level is 13, return 16
                -Else if level is 14, return 18
                -Else if level is less than 16 2, return 19
                -Else if level is 17, return 20
                -Otherwise, return 22
        RETURNS

                Returns int value based on the current level of the character

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        override public int SpellsKnown
        {
            get
            {
                if (level == 1)
                {
                    return 4;
                }
                else if (level == 2)
                {
                    return 5;
                }
                else if (level == 3)
                {
                    return 6;
                }
                else if (level == 4)
                {
                    return 7;
                }
                else if (level == 5)
                {
                    return 8;
                }
                else if (level == 6)
                {
                    return 9;
                }
                else if (level == 7)
                {
                    return 10;
                }
                else if (level == 8) { return 11; }
                else if (level == 9) { return 12; }
                else if (level == 10) { return 14; }
                else if (level <= 12) { return 15; }
                else if (level == 13) { return 16; }
                else if (level == 14) { return 18; }
                else if (level <= 16) { return 19; }
                else if (level == 17) { return 20; }
                else { return 22; }
            }
        }

        private int currentInsp;
        /**/
        /*
        

        NAME

                Bard::CurrentInsp - property used to determine the number of inspiration uses a Bard has left

        SYNOPSIS

                CurrentInsp;

        DESCRIPTION

                Property used in determining the amount of spells a bard should have
                
        RETURNS

                Returns int value of currentInsp private member variable

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int CurrentInsp { get { return currentInsp; } }

        /**/
        /*
        

        NAME

                Bard::MaxInsp - property used to determine the maximum uses of Inspiration a bard has in a single rest period

        SYNOPSIS

                MaxInsp;

        DESCRIPTION

                Property used in determining the amount of inspiration uses a bard has in a rest cycle
               
        RETURNS

                Returns int value based on the Charisma of the bard (Charisma divided by 2, then subtracted by 5)

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int MaxInsp
        {
            get { return (Charisma / 2) - 5; }
        }

        /**/
        /*
        

        NAME

                Bard::setMaxSlots - overridden function used for setting the max number of spellslots available to a bard at every level

        SYNOPSIS

                public override void setMaxSlots();

        DESCRIPTION

                Function used to set the maximum amount of spellslots for every level of spell for bards
                -Depending on level of Bard, changed value of int array spellslots
        RETURNS

                NA, void function to only set value to spellslots

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public override void setMaxSlots()
        {
            if (level == 1) { spellSlots = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 }; }
            else if (level == 2)
            {
                spellSlots = new int[9] { 3, 0, 0, 0, 0, 0, 0, 0, 0 };
            }
            else if (level == 3)
            {
                spellSlots = new int[9] { 4, 2, 0, 0, 0, 0, 0, 0, 0 };
            }
            else if (level == 4)
            {
                spellSlots = new int[9] { 4, 3, 0, 0, 0, 0, 0, 0, 0 };
            }
            else if (level == 5)
            {
                spellSlots = new int[9] { 4, 3, 2, 0, 0, 0, 0, 0, 0 };
            }
            else if (level == 6)
            {
                spellSlots = new int[9] { 4, 3, 3, 0, 0, 0, 0, 0, 0 };
            }
            else if (level == 7)
            {
                spellSlots = new int[9] { 4, 3, 3, 1, 0, 0, 0, 0, 0 };
            }
            else if (level == 8)
            {
                spellSlots = new int[9] { 4, 3, 3, 2, 0, 0, 0, 0, 0 };
            }
            else if (level == 9)
            {
                spellSlots = new int[9] { 4, 3, 3, 3, 1, 0, 0, 0, 0 };
            }
            else if (level == 10)
            {
                spellSlots = new int[9] { 4, 3, 3, 3, 2, 0, 0, 0, 0 };
            }
            else if (level == 11)
            {
                spellSlots = new int[9] { 4, 3, 3, 3, 2, 1, 0, 0, 0 };
            }
            else if (level == 13)
            {
                spellSlots = new int[9] { 4, 3, 3, 3, 2, 1, 1, 0, 0 };
            }
            else if (level == 15)
            {
                spellSlots = new int[9] { 4, 3, 3, 3, 2, 1, 1, 1, 0 };
            }
            else if (level == 17)
            {
                spellSlots = new int[9] { 4, 3, 3, 3, 2, 1, 1, 1, 1 };
            }
            else if (level == 18)
            {
                spellSlots = new int[9] { 4, 3, 3, 3, 3, 1, 1, 1, 1 };
            }
            else if (level == 19)
            {
                spellSlots = new int[9] { 4, 3, 3, 3, 3, 2, 1, 1, 1 };
            }
            else
            {
                spellSlots = new int[9] { 4, 3, 3, 3, 3, 2, 2, 1, 1 };
            }
        }

        /**/
        /*
        

        NAME

                Bard::LevelUp - overridden function used for increasing the level of a Bard and all of the associated increases in power that come with that

        SYNOPSIS

                public override void LevelUp();

        DESCRIPTION

                Function used when leveling up Bard characters, increasing health, level, Maximum spellslots, and spells known
                -Call increaseMaxHp, passing in rollCon(8) as the int value for it
                -Call increaseLevel
                -Call setMaxSlots
                -Copy the spellSlots array to the currentSlots array
                -Call checkMagic
        RETURNS

                NA, void function to call other functions and set value of currentSlots array

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        override public void LevelUp()
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

                Bard::longRest - overridden function used for allowing a Bard to take a Long Rest

        SYNOPSIS

                public override void longRest()

        DESCRIPTION

                Function used to take a long rest for a Bard
                -sets currentHP to maxHP
                -Copy spellSlots to currentSlots
                -sets currentInsp to MaxInsp

        RETURNS

                NA, void function to restore currentHP, currentSlots, and currentInsp

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public override void longRest()
        {
            currentHP = maxHP;
            Array.Copy(spellSlots, currentSlots, 9);
            currentInsp = MaxInsp;
        }

        /**/
        /*
        

        NAME

                Bard::shortRest - overridden function used for allowing a Bard to take a Short Rest

        SYNOPSIS

                public override void shortRest()

        DESCRIPTION

                Function used to take a short rest for a Bard
                -calls heal, and passes in rollCon(8) for the int value for it

        RETURNS

                NA, void function to call heal and get the value for it to be called with

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

                Bard::classAbility - overridden function used for letting bards use their class ability

        SYNOPSIS

                public override string classAbility()

        DESCRIPTION

                Function used to activate a Bard's class ability
                -decriments currentInsp
                -returns a string composed of the character name, a description of the ability and the amount of inspiration given from InspirationDie

        RETURNS

                Returns string value describing what takes place when the ability is activated

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override string classAbility()
        {
            currentInsp--;
            return charName + " sings an inspiring tune, giving someone 1d" + InspirationDie.ToString() + " to any one ability check, attack roll, or saving throw for the next 10 minutes.";
        }

        /**/
        /*
        

        NAME

                Bard::CanUseAbility - overridden property used to determine if the class ability can be used

        SYNOPSIS

                CanUseAbility;

        DESCRIPTION

                Property determining if the class ability is usable
                -Returns the boolean result of CurrentInsp>0

        RETURNS

                Returns boolean value for determining if the ability is useable

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public override bool CanUseAbility()
        {
            return (CurrentInsp > 0);
        }

    }
}
