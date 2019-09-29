using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorClient
{
    public class Character
    {
        /**/
        /*
        

        NAME

               Character::Charcter - Default constructor for character class

        SYNOPSIS

            public Character()
                
        DESCRIPTION

                   Constructor for character class and all sub classes
                   -Set level, ExperiencePoints, and Gold to 0
                   -Call SpellListPopulating
                   -Populate theSpell spellbook with Spells
                   -Populate theCantrips spellbook with cantrips

        RETURNS

                NA, class constructor

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public Character()
        {
            level = 0;
            ExperiencePoints = 0;
            Gold = 0;
            SpellListPopulating();
            theSpells.populateWithSpells();
            theCantrips.populateWithCantrips();
        }
        /**/
        /*
        

        NAME

               Character::Proficiency - Property for getting value of proficiency bonus

        SYNOPSIS

            public int Proficiency
                
        DESCRIPTION

                 Property used to get proficiency bonus
                 -Returns 2 plus the result of level minus 1, over 4

        RETURNS

                Returns int value representing the proficiency bonus a character has at any level

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int Proficiency
        {
            get
            {
                return 2 + ((level - 1) / 4);
            }
        }
        /**/
        /*
        

        NAME

               Character::increaseMaxHP - function to increase a characters max hp

        SYNOPSIS

            public void increaseMaxHP(int theNumber)

            int theNumber -> Int value by which max hp will be increase by
                
        DESCRIPTION

                   Function to increase a characters max hp
                   -Set maxHP to its current value plus theNumber

        RETURNS

                NA, void function used to change the value of a member variable

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public void increaseMaxHP(int theNumber)
        {
            maxHP += theNumber;
        }

        /**/
        /*
        

        NAME

               Character::Strength - Property used to get/set the str int value

        SYNOPSIS

            public int Strength
                
        DESCRIPTION

                   Property to get/set str int value
                   -Get
                   --Return str
                   -Set
                   --Set str to value

        RETURNS

                On get, returns int value representing the characters strength stat

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public int Strength
        {
            get
            { return str; }
            set
            { str = value; }
        }
        /**/
        /*
        

        NAME

               Character::Dexterity - Property used to get/set the dex int value

        SYNOPSIS

            public int Dexterity
                
        DESCRIPTION

                   Property to get/set dex int value
                   -Get
                   --Return dex
                   -Set
                   --Set dex to value

        RETURNS

                On get, returns int value representing the characters dexterity stat

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int Dexterity
        {
            get
            { return dex; }
            set
            { dex = value; }
        }
        /**/
        /*
        

        NAME

               Character::Constitution - Property used to get/set the con int value

        SYNOPSIS

            public int Constitution
                
        DESCRIPTION

                   Property to get/set con int value
                   -Get
                   --Return con
                   -Set
                   --Set con to value

        RETURNS

                On get, returns int value representing the characters constitution stat

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int Constitution
        {
            get
            { return con; }
            set
            { con = value; }
        }
        /**/
        /*
        

        NAME

               Character::Intelligence - Property used to get/set the _intelligence int value

        SYNOPSIS

            public int Intelligence
                
        DESCRIPTION

                   Property to get/set _intelligence int value
                   -Get
                   --Return _intelligence
                   -Set
                   --Set _intelligence to value

        RETURNS

                On get, returns int value representing the characters intelligence stat

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int Intelligence
        {
            get
            { return _intelligence; }
            set
            { _intelligence = value; }
        }
        /**/
        /*
        

        NAME

               Character::Wisdom - Property used to get/set the wis int value

        SYNOPSIS

            public int Wisdom
                
        DESCRIPTION

                   Property to get/set wis int value
                   -Get
                   --Return wis
                   -Set
                   --Set wis to value

        RETURNS

                On get, returns int value representing the characters wisdom stat

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int Wisdom
        {
            get
            { return wis; }
            set
            { wis = value; }
        }
        /**/
        /*
        

        NAME

               Character::Charisma - Property used to get/set the cha int value

        SYNOPSIS

            public int Charisma
                
        DESCRIPTION

                   Property to get/set cha int value
                   -Get
                   --Return cha
                   -Set
                   --Set cha to value

        RETURNS

                On get, returns int value representing the characters charisma stat

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int Charisma
        {
            get
            { return cha; }
            set
            { cha = value; }
        }
        /**/
        /*
        

        NAME

               Character::setName - Function used to set the name of the character

        SYNOPSIS

            public void setName(string theName)
            string theName -> string value representing the name of the character
                
        DESCRIPTION

                   Function to set the name of the character
                   -Set charName to theName

        RETURNS

                NA, void function that sets member variable

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public void setName(string theName)
        {
            charName = theName;
        }/**/
        /*
        

        NAME

               Character::setRace - Function used to set the race of the character

        SYNOPSIS

            public void setRace(string theRace)
            string theRace -> string value representing the race of the character
                
        DESCRIPTION

                   Function to set the race of the character
                   -Set charRace to theRace

        RETURNS

                NA, void function that sets member variable

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public void setRace(string theRace)
        {
            charRace = theRace;
        }
        /*
        

        NAME

               Character::setClass - Function used to set the class of the character

        SYNOPSIS

            public void setClass(string theClass)
            string theClass -> string value representing the class of the character
                
        DESCRIPTION

                   Function to set the class of the character
                   -Set charClass to theClass

        RETURNS

                NA, void function that sets member variable

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public void setClass(string theClass)
        {
            charClass = theClass;

        }

        protected int[] spellSlots = new int[9];
        /**/
        /*
        

        NAME

               Character::SpellSlots - Property used to get the current value of the spellSlots int array

        SYNOPSIS

            public int[] SpellSlots
                
        DESCRIPTION

                Property to get value of spellSlots
                -Get
                --Return spellSlots

        RETURNS

                Returns int array value representing max number of spellslots of all levels a character currently has

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int[] SpellSlots
        {
            get { return spellSlots; }
        }

        protected int[] currentSlots = new int[9];
        /**/
        /*
        

        NAME

               Character::CurrentSlots- Property used to get the current value of the currentSlots int array

        SYNOPSIS

            public int[] CurrentSlots
                
        DESCRIPTION

                Property to get value of currentSlots
                -Get
                --Return currentSlots

        RETURNS

                Returns int array value representing number of spellslots of all levels a character currently has

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int[] CurrentSlots
        {
            get { return currentSlots; }
        }
        /**/
        /*
        

        NAME

               Character::SpellsKnown - Virtual function used to determine how many spell a character should know. Overriden by class
        SYNOPSIS

            virtual public int SpellsKnown
                
        DESCRIPTION

                   Virtual function to determine how many spell a character should know
                   -Return 0

        RETURNS

                Returns int value 0, overriden by subclasses

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        virtual public int SpellsKnown
        {
            get { return 0; }
        }

        /**/
        /*
        

        NAME

               Character::CurrentNumberOfSpells - Property used to determine the number of spells a character currently has
        SYNOPSIS

            public int CurrentNumberOfSpells
                
        DESCRIPTION

                   Property to determine the number of spells currently known
                   -Get
                   --Initalize int variable returner, set to 0
                   --For every value in spellList
                   ---Increase returner by the length of spellList at spot i
                   --Return returner

        RETURNS

                Returns int value representing the number of spells a character currently owns

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public int CurrentNumberOfSpells
        {
            get
            {
                int returner = 0;
                for (int i = 0; i < spellList.Count(); i++)
                {
                    returner += spellList[i].Count();
                }
                return returner;
            }
        }

        protected int cantripsKnown;
        /**/
        /*
        

        NAME

               Character::CantripsKnown - Virtual function used to determine how many cantrips a character should know. Overriden by class
        SYNOPSIS

            virtual public int CantripsKnown
                
        DESCRIPTION

                   Virtual function to determine how many spell a character should know
                   -Return 0

        RETURNS

                Returns int value 0, overriden by subclasses

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        virtual public int CantripsKnown
        {
            get { return 0; }
        }

        /**/
        /*
        

        NAME

               Character::CurrentNumberOfCantrips - Property used to determine the number of cantrips a character currently has
        SYNOPSIS

            public int CurrentNumberOfCantrips
                
        DESCRIPTION

                   Property to determine the number of cantrips currently known
                   -Get
                   --Return cantripList count
        RETURNS

                Returns int value representing the number of cantrips a character currently owns

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public int CurrentNumberOfCantrips
        {
            get { return cantripList.Count(); }
        }

        /**/
        /*
        

        NAME

               Character::SpellCastBonus - Virtual function used to return bonus to spell attack rolls

        SYNOPSIS

            public virtual int SpellCastBonus()
                
        DESCRIPTION

                   Function to return the bonus to spell attack rolls
                   -Return 0

        RETURNS

                Returns int value of 0, overriden by subclasses

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public virtual int SpellCastBonus() { return 0; }

        protected List<List<Spell>> spellList = new List<List<Spell>>();
        /**/
        /*
        

        NAME

               Character::SpellListPopulating - Function used to create the 9 lists of Spells that are contained in spellList
        
            SYNOPSIS

                public void SpellListPopulating()
                
        DESCRIPTION

                Function used to fill the 9 lists of the SpellList
                -For 9 times, add a list of spells to spellList

        RETURNS

                NA, void function initalizing the large list of lists

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public void SpellListPopulating()
        {
            for (int i = 0; i < 9; i++)
            {
                List<Spell> addingList = new List<Spell>();
                spellList.Add(addingList);
            }
        }
        /**/
        /*
        

        NAME

                Character::SpellListAt - returns one of the specific lists at the levels of spellList

        SYNOPSIS

                public List<Spell> SpellListAt(int index)
            int index -> Int value used to determine which list of spells from spellList to return
                
        DESCRIPTION

                Function to return list of spells from spellList
                -return spellList at spot index

        RETURNS

                Returns List of type Spell value

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public List<Spell> SpellListAt(int index)
        {
            return spellList[index];
        }

        private SpellBook theSpells = new SpellBook();
        private SpellBook theCantrips = new SpellBook();

        protected List<Spell> cantripList = new List<Spell>();
        /**/
        /*
        

        NAME

               Character::CantripList - property used to get the cantripList

        SYNOPSIS

            public List<Spell> CantripList
                
        DESCRIPTION

                   Property used to get cantripList
                   -Get
                   --Return cantripList

        RETURNS

                Returns the List of Spells vlue representing cantripList

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public List<Spell> CantripList { get { return cantripList; } }

        /**/
        /*
        

        NAME

               Character::learnSpell - Function used to learn new spells

        SYNOPSIS

            public void learnSpell(Spell learningSpell)

            Spell learningSpell -> Spell value to be added to character spellList
                
        DESCRIPTION

                   Function used to learn new spells
                   -Add the learningSpell to spellList at the spot learningSpell.Level-1

        RETURNS

                NA, void function used to add a spell to a list of spells

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public void learnSpell(Spell learningSpell)
        {
            spellList[learningSpell.Level-1].Add(learningSpell);
        }
        /**/
        /*
        

        NAME

               Character::learnCantrip - Function used to learn new cantrips

        SYNOPSIS

            public void learnCantrip(Spell learningCantrip)

            Spell learningCantrip -> Spell value to be added to character cantripList
                
        DESCRIPTION

                   Function used to learn new spells
                   -Add the learningCantrip to cantripList

        RETURNS

                NA, void function used to add a cantrip to a list of cantrip spells

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public void learnCantrip(Spell learningCantrip)
        {
            cantripList.Add(learningCantrip);
        }

        /**/
        /*
        

        NAME

                Character::checkMagic - Function used to facilitate the checking that the right number spells and cantrips are known
        SYNOPSIS

                public void checkMagic()
                
        DESCRIPTION

                Function used to facilitate checking that the right number of cantrips and spells are known
                -Call checkCantrips
                -Call checkSpells
        RETURNS

                NA, void function that calls other functions               

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public void checkMagic()
        {
            checkCantrips();
            checkSpell();
        }

        /**/
        /*
        

        NAME

               Character::checkCantrips - Function used to check that the number of cantrips currently known is as high as it should be, and if not then facilitating learning new cantrips

        SYNOPSIS

            public void checkCantrips()
                
        DESCRIPTION

                   Function to ensure the right number of cantrips are known, and learning more if that's not the case
                   -While the CantripsKnown does not equal CurrentNumberOfCantrips
                   --Initialize string spellName and set it to null
                   --Create learningMagicForm passing in theCantrips, 1, and getClass for its values, and on a DialogResult.OK, set spellName to learning.SelectedSpell
                   --If spellName is not found in the names of the spells in CantripList
                   ---Call learnCantrip, passing in the result of searching theCantrips.TheSpell to find a spell with the name matching spellName
                   --Otherwise, display an error message about learning repeat spells

        RETURNS

                NA, void function used to add cantrips to CantripList

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public void checkCantrips()
        {
            while (CantripsKnown != CurrentNumberOfCantrips)
            {
                string spellName=null;
                using (learningMagicForm learning = new learningMagicForm(theCantrips, 1, getClass()))
                {
                    if (learning.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        spellName = learning.SelectedSpell;
                    }
                }
                if (CantripList.FindIndex(x => x.Name == spellName) == -1)
                {
                    learnCantrip(theCantrips.TheSpells.Find(x => x.Name == spellName));
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Error: Cannot learn already known cantrip. Pick new cantrip.");
                }
            }
        }

        /**/
        /*
        

        NAME

                Character::checkSpell - Function used to ensure the right number of spells are currently known, and learning more if not

        SYNOPSIS

                public void checkSpell()
                
        DESCRIPTION

                Function used to check that the right number of spells are currently known, and learning more if not
                -Initalize string spellName, setting to null
                -Initialize int maxSpellSlot, setting to 0
                -Determine the highest level spellSlot the character has access to, and set maxSpellSlot to it
                -Create learningMagicForm, passing in theSpells, maxSpellSlot, and getClass() for its values
                -On a DialogResult.OK, set spellName to the SelectedSpell from the form
                -Initialize boolean value spellKnown, setting to false
                -Check through all 9 lists held in the spellList, looking in each of them for a spell with the name matching spellName
                --If found, set spellKnown to true and break
                -If spellKnown, send error message about learning duplicate spells
                -Otherwise, call learnSpell, passing in the result of finding the spell in theSpells whos name matches spellName

        RETURNS

                NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public void checkSpell()
        {
            while (SpellsKnown != CurrentNumberOfSpells)
            {
                string spellName = null;
                int maxSpellSlot = 0;
                for (int i = 0; i < spellSlots.Length; i++)
                {
                    if (spellSlots[i] != 0)
                    {
                        maxSpellSlot = i+1;
                    }
                }
                using (learningMagicForm learning = new learningMagicForm(theSpells, maxSpellSlot, getClass()))
                {
                    if (learning.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        spellName = learning.SelectedSpell;
                    }
                }
                bool spellKnown = false;
                for (int i = 0; i<spellList.Count(); i++)
                {
                    if (spellList[i].FindIndex(x => x.Name == spellName) != -1)
                    {
                        spellKnown = true;
                        break;
                    }
                }
                if (spellKnown) { System.Windows.Forms.MessageBox.Show("Error: Cannot learn already known spell. Pick a new spell!"); }
                else
                {
                    learnSpell(theSpells.TheSpells.Find(x => x.Name == spellName));
                }
            }
        }

        /**/
        /*
        

        NAME

               Character::CastSpell - Function used to return the result of casting a spell
        SYNOPSIS

            public string CastSpell(string spellName, int level)

            string spellName -> String value used to find the correct spell in one of the lists in spellList
            int level -> int value used to give the correct index of spellList to search in
                
        DESCRIPTION

                 Function used when casting spells and for returning the result of them
                 -Call UseLevel, passing in level
                 -Create string value returnString
                 -Add to return string the announcement of casting the spell.
                 -Search within spellList at spot level to find a spell matching the spellName, and add its effect to the returnString
                 -If that same spell is Damaging, add the damage result to the resultString
                 -If that same spell is Rolling, add the hit result to the resultString
                 -If that same spell is Dc, add the save DC to the returnString
                 -Append a newline
                 -Return returnString

        RETURNS

                Returns string value representing the result of casting the specified spell

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public string CastSpell(string spellName, int level)
        {
            UseLevel(level);
            string returnstring;
            returnstring = charName + " casts " + spellName +". ";
            returnstring += spellList[level].Find(x => x.Name == spellName).Effect;
            if (spellList[level].Find(x => x.Name == spellName).Damaging)
            {
                string damageResult = myDie.RollSeveral((spellList[level].Find(x => x.Name == spellName).Dice), (spellList[level].Find(x => x.Name == spellName).Damage)).ToString() + " is the result of the damage rolls.";
                returnstring += damageResult;
            }
            if (spellList[level].Find(x => x.Name == spellName).Rolling)
            {
                string hitResult = (myDie.RollDice(20) + SpellCastBonus()).ToString() + " is the roll to hit.";
                returnstring += hitResult;
            }
            if (spellList[level].Find(x => x.Name == spellName).Dc)
            {
                returnstring += "The spell save dc for the spell is " + (8 + SpellCastBonus()).ToString();
            }
            returnstring += Environment.NewLine;
            return returnstring;
            
        }

        /**/
        /*
        

        NAME

               Character::CastCantrip - Function used to return the result of casting a cantrip
        SYNOPSIS

            public string CastCantrip(string cantripName)

            string cantripName -> String value used to find the correct cantrip in cantripList
            

        DESCRIPTION

                 Function used when casting cantrips and for returning the result of them
                 -Create string value returnString
                 -Add to return string the announcement of casting the cantrip.
                 -Search within spellList at spot level to find a cantrip matching the cantripName, and add its effect to the returnString
                 -If that same cantrip is Damaging, add the damage result to the resultString
                 -If that same cantrip is Rolling, add the hit result to the resultString
                 -If that same cantrip is Dc, add the save DC to the returnString
                 -Append a newline
                 -Return returnString

        RETURNS

                Returns string value representing the result of casting the specified cantrip

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public string CastCantrip(string cantripName)
        {
            string returnstring;
            returnstring = charName + " casts " + cantripName + ". ";
            returnstring += cantripList.Find(x => x.Name == cantripName).Effect + " ";
            if (cantripList.Find(x => x.Name == cantripName).Damaging)
            {
                string damageResult = myDie.RollSeveral((cantripList.Find(x => x.Name == cantripName).Dice), (cantripList.Find(x => x.Name == cantripName).Damage)).ToString() + " is the result of the damage rolls.";
                returnstring += damageResult;
            }
            if (cantripList.Find(x => x.Name == cantripName).Rolling)
            {
                string hitResult = (myDie.RollDice(20) + SpellCastBonus()).ToString() + " is the roll to hit.";
                returnstring += hitResult;
            }
            if (cantripList.Find(x => x.Name == cantripName).Dc)
            {
                returnstring += "The spell save dc for the spell is " + (8 + SpellCastBonus()).ToString();
            }
            returnstring += Environment.NewLine;
            return returnstring;
        }

        /**/
        /*
        

        NAME

		        Character::UseLevel - Virtual function used to decrement the correct spellSlot in currentSlots

        SYNOPSIS

                 public virtual void UseLevel(int spellLevel)
             int spellLevel -> Int value used to determine the correct spot in currentSlots to decrement
                
        DESCRIPTION

		        Function used to decrement values in currentSlots
                -In currentSlots at the index of spellLevel, decrement the value

        RETURNS

		        NA void function used to change member variable. Overriden by Warlock class

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public virtual void UseLevel(int spellLevel)
        {
            currentSlots[spellLevel]--;
        }

        /**/
        /*
        

        NAME

		        Character::ApplyRacialBonuses - Function used to apply racial bonuses to stats of characters

        SYNOPSIS

                 public void ApplyRacialBonuses()
                
        DESCRIPTION

		        Function to apply racial bonuses to character stats
                -If charRace is Dwarf
                --Increase wisdom by 1 and constitution by 2
                -Else if charRace is Elf
                --Increase Dexterity by 2 and Charisma by 1
                -Else if charRace is Halfling
                --Increase Dexterity by 2 and Constitution by 1
                -Else if charRace is Human
                --Increase all stats by 1
                -Else if charRace is Dragonborn
                --Increase strength by 2 and charisma by 1
                -Else if charRace is Gnome
                --Increase Intelligence by 2 and Dexterity by 1
                -Else if charRace is Half-Elf
                --Increase Charisma by 2, Dexterity by 1, and Wisdom by 1
                -Otherwise (meaning Half-Orc was selected), increase strength by 2 and constitution by 1

        RETURNS

		        NA void function used to change member variable. Overriden by Warlock class

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public void ApplyRacialBonuses()
        {
            if (charRace == "Dwarf")
            {
                Constitution += 2;
                Wisdom += 1;
            }
            else if (charRace == "Elf")
            {
                Dexterity += 2;
                Charisma += 1;
            }
            else if (charRace == "Halfling")
            {
                Dexterity += 2;
                Constitution += 1;
            }
            else if (charRace == "Human")
            {
                Strength += 1;
                Dexterity += 1;
                Intelligence += 1;
                Constitution += 1;
                Charisma += 1;
                Wisdom += 1;
            }
            else if (charRace == "Dragonborn")
            {
                Strength += 2;
                Charisma += 1;
            }
            else if (charRace == "Gnome")
            {
                Intelligence += 2;
                Dexterity += 1;
            }
            else if (charRace == "Half-Elf")
            {
                Charisma += 2;
                Dexterity += 1;
                Wisdom += 1;
            }
            else //Half-Orcs
            {
                Strength += 2;
                Constitution += 1;
            }

        }

        //protected values
        protected string charName;
        protected string charRace;
        protected string charClass;

        protected int SpellBonus;

        protected int currentHP;
        /**/
        /*
        

        NAME

		        Character::CurrentHP - Property used to get/set the currentHP value

        SYNOPSIS

                 public int currentHP

        DESCRIPTION

		        Property used to get/set currentHP value
                -Get
                --Return currentHP
                -Set
                --Set currentHP to value

        RETURNS

		        On get, return int value representing the current HP of a character

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int CurrentHP
        {
            get { return currentHP; }
            set { currentHP = value; }
        }
        protected int str;
        protected int dex;
        protected int con;
        protected int _intelligence;
        protected int wis;
        protected int cha;    

        protected int level;
        /**/
        /*
        

        NAME

		        Character::Level - Property used to get the level value

        SYNOPSIS

                 public int Level

        DESCRIPTION

		        Property used to get Level value
                -Get
                --Return level

        RETURNS

		        Return int value representing the level of a character

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int Level
        {
            get { return level; }
        }
        protected int maxHP;
        /**/
        /*
        

        NAME

		        Character::MaxHP - Property used to get the maxHP value

        SYNOPSIS

                 public int MaxHP

        DESCRIPTION

		        Property used to get maxHP value
                -Get
                --Return maxHP

        RETURNS

		        Return int value representing the maximum health of a character

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int MaxHP
        {
            get { return maxHP; }
        }
        protected int armorClass;
        /**/
        /*
        

        NAME

		        Character::ArmorClass - Property used to get the armorClass value

        SYNOPSIS

                 public int ArmorClass

        DESCRIPTION

		        Property used to get armorClass value
                -Get
                --Return armorClass

        RETURNS

		        Return int value representing the armor class of a character

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int ArmorClass
        {
            get { return armorClass; }
        }
        protected Dice myDie = new Dice();
        /**/
        /*
        

        NAME

		        Character::MyDie - Property used to get the myDie value

        SYNOPSIS

                 public Dice MyDie

        DESCRIPTION

		        Property used to get myDie value
                -Get
                --Return myDie

        RETURNS

		        Return int value representing the die owned by a character

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public Dice MyDie
        {
            get { return myDie; }
        }
        protected List<string> proficiencyList = new List<string>();
        /**/
        /*
        

        NAME

		        Character::increaseLevel - Function used to increase the level of a character

        SYNOPSIS

                 public void increaseLevel()

        DESCRIPTION

		        Function used to increase the level of a character
                -Increment level
                -If level is divisible by 4
                --Call increaseStats

        RETURNS

		        NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        protected void increaseLevel()
        {
            level += 1;
            if (level % 4 == 0)
            {
                increaseStats();
            }
        }


        /**/
        /*
        

        NAME

		        Character::increaseStats - Function used to handle the increasing of character stats

        SYNOPSIS

                 public void increaseStats

        DESCRIPTION

		        Function used to handle the increasing of stats
                -Initialize strings stat1 and stat2
                -Using an increaseStatForm called growing
                --If growing returns a DialogResult.OK
                ---Set stat1 to selectedStat1, and stat2 to selectedStat2
                ---Depending on which stat is selected for stat1, and stat2, increment the selected stats

        RETURNS

		        NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public void increaseStats()
        {
            string stat1, stat2;
            using (increaseStatForm growing = new increaseStatForm())
            {
                if (growing.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    stat1 = growing.selectedStat1;
                    stat2 = growing.selectedStat2;

                    if (stat1 == "Strength") { Strength += 1; }
                    else if (stat1 == "Dexterity") { Dexterity += 1; }
                    else if (stat1 == "Constitution") { Constitution += 1; }
                    else if (stat1 == "Intelligence") { Intelligence += 1; }
                    else if (stat1 == "Wisdom") { Wisdom += 1; }
                    else { Charisma += 1; }

                    if (stat2 == "Strength") { Strength += 1; }
                    else if (stat2 == "Dexterity") { Dexterity += 1; }
                    else if (stat2 == "Constitution") { Constitution += 1; }
                    else if (stat2 == "Intelligence") { Intelligence += 1; }
                    else if (stat2 == "Wisdom") { Wisdom += 1; }
                    else { Charisma += 1; }
                }
            }
        }


        protected List<string> proficiencies = new List<string>();
        protected List<string> potentialProficiencies = new List<string>();

        protected List<string> abilities = new List<string>();
        /**/
        /*
        

        NAME

		        Character::Abilities - Property used to get the abilities value

        SYNOPSIS

                 public List<string> Abilities

        DESCRIPTION

		        Property used to get abilities value
                -Get
                --Return abilities list

        RETURNS

		        Return a List of string values representing the ablities of the character

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public List<string> Abilities
        {
            get { return abilities; }
        }

        /**/
        /*
        

        NAME

		        Character::CanUseAbility - Virtual function used to return whether or not a class ability can be used

        SYNOPSIS

                 virtual public bool CanUseAbility()

        DESCRIPTION

		        Property used to determine if abilitiy is usable
                -Return false

        RETURNS

		        Return boolean value false. Overriden by every character subclass

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        virtual public bool CanUseAbility() { return false; }

        protected string abilityChoice;

        /**/
        /*
        

        NAME

		        Character::AbilityChoice - Property used to get/set the abilityChoice value

        SYNOPSIS

                 public string AbilityChoice

        DESCRIPTION

		        Property used to get/set ability value
                -Get
                --Return abilityChoice
                -Set
                --Set abilityChoice to value

        RETURNS

		        On get, return string value representing the current choice of ability to activate

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public string AbilityChoice
        {
            get { return abilityChoice; }
            set { abilityChoice = value; }
        }

        protected List<item> myItems = new List<item>();

        /**/
        /*
        

        NAME

		        Character::MyItems - Property used to get the myItems list value

        SYNOPSIS

                 public int MyItems

        DESCRIPTION

		        Property used to get myItems list value
                -Get
                --Return myItems

        RETURNS

		        Return List of item values held in the myItems variable

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public List<item> MyItems { get { return myItems; } }

        /**/
        /*
        

        NAME

		        Character::getClass - Function used to return the character's class

        SYNOPSIS

                 public string getClass()

        DESCRIPTION

		        Function used to get the character class
                -Return charClass

        RETURNS

		        Return string value representing the characters class

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public string getClass() { return charClass; }
        /**/
        /*
        

        NAME

		        Character::getRace - Function used to return the character's race

        SYNOPSIS

                 public string getRace()

        DESCRIPTION

		        Function used to get the character race
                -Return charRace

        RETURNS

		        Return string value representing the characters race

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public string getRace() { return charRace; }
        /**/
        /*
        

        NAME

		        Character::getName - Function used to return the character's name

        SYNOPSIS

                 public string getName()

        DESCRIPTION

		        Function used to get the character name
                -Return charName

        RETURNS

		        Return string value representing the characters name

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public string getName() { return charName; }
        /**/
        /*
        

        NAME

		        Character::LevelUp - Virtual function used to level up character

        SYNOPSIS

                 public void LevelUp()

        DESCRIPTION

		        Function used to level up character

        RETURNS

		        NA, empty virtual function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public virtual void LevelUp() { }
        
        /**/
        /*
        

        NAME

		        Character::shortRest - Virtual function used to let a character short rest

        SYNOPSIS

                 public void shortRest()

        DESCRIPTION

		        Function used to let a character take a short rest

        RETURNS

		        NA, empty virtual function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public virtual void shortRest() { }
        /**/
        /*
        

        NAME

		        Character::longRest - Virtual function used to let a character long rest

        SYNOPSIS

                 public void longRest()

        DESCRIPTION

		        Function used to let a character take a long rest

        RETURNS

		        NA, empty virtual function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public virtual void longRest() { }
        /**/
        /*
        

        NAME

		        Character::classAbility - Virtual function used to return result of character abilty activating
        SYNOPSIS

                 public virtual string classAbility()

        DESCRIPTION

		        Function used to return the result of character ability activating

        RETURNS

		        Returns null. Overriden by subclasses

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public virtual string classAbility() { return null; }
        /**/
        /*
        

        NAME

		        Character::getPossibles - Function used to return possible proficiences a character can learn

        SYNOPSIS

                 public string[] getPossibles()

        DESCRIPTION

		        Function used to get an array of potential Proficiences
                -Return potentialProfiences.ToArray()

        RETURNS

		        Returns string array of the potential proficiences

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public string[] getPossibles() { return potentialProficiencies.ToArray(); }

        /**/
        /*
        

        NAME

		        Character::rollStr - Virtual function used make a strength roll

        SYNOPSIS

                 public virtual int rollStr(int sides)

            int sides -> Int value determining the number of sides of the dice that will be rolled

        DESCRIPTION

		        Function used to let a character make a strength roll of any sided die
                -Return myDie.RollDice, passing sides into it, and add to the result of that roll the Strength modifier of the character

        RETURNS

		        Returns int value representing the result of the strength roll. Overriden by Barbarian class

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public virtual int rollStr(int sides)
        {
            return myDie.RollDice(sides) + ((Strength - 10) / 2);
        }
        /**/
        /*
        

        NAME

		        Character::rollDex - Function used to make a dexterity roll

        SYNOPSIS

                 public int rollDex(int sides)

            int sides -> Int value determining the number of sides of the dice that will be rolled

        DESCRIPTION

		        Function used to return the result of a dexterity roll
                -Return myDie.RollDice, passing in sides, and adding to the result of that roll the characters dexterity modifier

        RETURNS

		        Returns int value representing the result of the dexterity roll

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int rollDex(int sides)
        {
            return myDie.RollDice(sides) + ((Dexterity - 10) / 2);
        }
        /**/
        /*
        

        NAME

		        Character::rollInt - Function used to make a intelligence roll

        SYNOPSIS

                 public int rollInt(int sides)

            int sides -> Int value determining the number of sides of the dice that will be rolled

        DESCRIPTION

		        Function used to return the result of a intelligence roll
                -Return myDie.RollDice, passing in sides, and adding to the result of that roll the characters intelligence modifier

        RETURNS

		        Returns int value representing the result of the intelligence roll

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int rollInt(int sides)
        {
            return myDie.RollDice(sides) + ((Intelligence - 10) / 2);
        }
        /**/
        /*
        

        NAME

		        Character::rollCon - Function used to make a constitution roll

        SYNOPSIS

                 public int rollCon(int sides)

            int sides -> Int value determining the number of sides of the dice that will be rolled

        DESCRIPTION

		        Function used to return the result of a constitution roll
                -Return myDie.RollDice, passing in sides, and adding to the result of that roll the characters constitution modifier

        RETURNS

		        Returns int value representing the result of the constitution roll

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int rollCon(int sides)
        {
            return myDie.RollDice(sides) + ((Constitution - 10) / 2);
        }
        /**/
        /*
        

        NAME

		        Character::rollWis - Function used to make a wisdom roll

        SYNOPSIS

                 public int rollWis(int sides)

            int sides -> Int value determining the number of sides of the dice that will be rolled

        DESCRIPTION

		        Function used to return the result of a wisdom roll
                -Return myDie.RollDice, passing in sides, and adding to the result of that roll the characters wisdom modifier

        RETURNS

		        Returns int value representing the result of the wisdom roll

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int rollWis(int sides)
        {
            return myDie.RollDice(sides) + ((Wisdom - 10) / 2);
        }
        /**/
        /*
        

        NAME

		        Character::rollCha - Function used to make a charisma roll

        SYNOPSIS

                 public int rollCha(int sides)

            int sides -> Int value determining the number of sides of the dice that will be rolled

        DESCRIPTION

		        Function used to return the result of a charisma roll
                -Return myDie.RollDice, passing in sides, and adding to the result of that roll the characters charisma modifier

        RETURNS

		        Returns int value representing the result of the charisma roll

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int rollCha(int sides)
        {
            return myDie.RollDice(sides) + ((Charisma - 10) / 2);
        }

        /**/
        /*
        

        NAME

		        Character::addProficiency - Function used to add a new item to the proficiencies list

        SYNOPSIS

                 public void addProficiency(string theProficiency)

            string theProficiency -> String value representing the profiency being added to the character

        DESCRIPTION

		        Function used to add a new item to the proficiencies list
                -Add to the proficiencies list theProficiency

        RETURNS

		        NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public void addProficiency(string theProficiency)
        {
            proficiencies.Add(theProficiency);
        }

        /**/
        /*
        

        NAME

		        Character::checkProf - Function used to check if a certain proficiency is had

        SYNOPSIS

                 public bool checkProf(string theProf)

            string theProf -> String value representing the profiency being checked

        DESCRIPTION

		        Function used to check if a proficiency is learned
                -Return whether or not proficiencies contains theProf

        RETURNS

		        Returns bool value representing whether or not the prof is learned

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public bool checkProf(string theProf)
        {
            return proficiencies.Contains(theProf);
        }

        /**/
        /*
        

        NAME

		        Character::firstLevel - Virtual function used to handle a characters first level

        SYNOPSIS

                 virtual public void firstLevel()

        DESCRIPTION

		        Function used to handle a characters first level

        RETURNS

		        NA, empty virtual function. Overriden by all child classes

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        virtual public void firstLevel() { }

        /**/
        /*
        

        NAME

		        Character::setMaxSlots - Virtual function used to set the spellSlots value of a character

        SYNOPSIS

                 public void setMaxSlots()

        DESCRIPTION

		        Function used to set a characters spellSlots

        RETURNS

		        NA, empty virtual function. Overriden by all child classes

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        virtual public void setMaxSlots() { }

        /**/
        /*
        

        NAME

		        Character::attackWithItem - Function used to attack with an item

        SYNOPSIS

                  public string attackWithItem(string name)

            string name -> String value of the name of the item being used

        DESCRIPTION

		        Function used to attack with item
                -If the item in myItems matching the name value is dexBased
                --Roll a dex attack for it, and roll the damage for it
                -Otherwise
                --Roll a strength attack for it, and roll the damage

        RETURNS

		        Returns string value representing the result of the attack and damage rolls.

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public string attackWithItem(string name)
        {
            if (myItems.Find(x => x.Name == name).DexBased == true)
            {
                if (myItems.Find(x => x.Name == name).Dice >= 2)
                {
                    return charName + " attacks with their " + name + ". The roll to hit is a " + (rollDex(20) + Proficiency).ToString() + ", dealing " + (((MyDie.RollSeveral(myItems.Find(x => x.Name == name).Damage, myItems.Find(x => x.Name == name).Dice)))+((Dexterity/2)-5)).ToString() + " damage.";
                }
                else
                {
                    return charName + " attacks with their " + name + ". The roll to hit is a " + (rollDex(20) + Proficiency).ToString() + ", dealing " + (MyDie.RollDice((myItems.Find(x => x.Name == name).Dice))+ ((Dexterity / 2) - 5)).ToString() + " damage.";
                }
            }
            else
            {
                if (myItems.Find(x => x.Name == name).Dice >= 2)
                {
                    return charName + " attacks with their " + name + ". The roll to hit is a " + (rollStr(20) + Proficiency).ToString() + ", dealing " + (((MyDie.RollSeveral(myItems.Find(x => x.Name == name).Damage, myItems.Find(x => x.Name == name).Dice)))+((Strength/2)-5)).ToString() + " damage.";
                }
                else
                {
                    return charName + " attacks with their " + name + ". The roll to hit is a " + (rollStr(20) + Proficiency).ToString() + ", dealing " + (MyDie.RollDice((myItems.Find(x => x.Name == name).Dice))+((Strength/2)-5)).ToString() + " damage.";
                }
            }
        }

        /**/
        /*
        

        NAME

		        Character::setARmor - Virtual function used to set the characters armor class

        SYNOPSIS

                 virtual public void shortRest()

        DESCRIPTION

		        Function used to set a characters armor class
                -Initalize bool value hasArmor, setting to false
                -Check all items for any armor values, if any do, set hasArmor to true
                -If hasArmor, set the armor class to the highest armor value + dexterity modifier among them
                -Otherwise, set armor class to 8 + dexterity modifier

        RETURNS

		        NA, void function. Overriden by Barbarian and Monk classes.

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        virtual public void setArmor()
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
                armorClass = 8 + ((Dexterity / 2) - 5);
            }
        }

        /**/
        /*
        

        NAME

		        Character::heal - Function used to heal the character

        SYNOPSIS

                 public void heal(int amount)

            int amount -> Int value determining the amount of health a character will heal

        DESCRIPTION

		        Function used to handle healing
                -Increase currentHP by amount
                -If currentHP is greater than maxHP, set currentHP to maxHP

        RETURNS

		        NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public void heal(int amount)
        {
            currentHP += amount;
            if (currentHP > maxHP) { currentHP = maxHP; }
        }

        /**/
        /*
        

        NAME

		        Character::ExperiencePoints - Property used to get/set experiencepoints

        SYNOPSIS

                 public int ExperiencePoints()

        DESCRIPTION

		        Function used to get/set a characters experience points
                -Get
                --Return experiencepoints
                -Set
                --Set experiencepoints to value

        RETURNS

		        On get, return experiencepoints

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int ExperiencePoints { get; set; }
        /**/
        /*
        

        NAME

		        Character::GainXP - Function used to handle gaining experience for a character

        SYNOPSIS

                 public void GainXP(int gainingValue)

            int gainingValue -> int value of the experience points the character gaining

        DESCRIPTION

		        Function used to let a character gain experience points
                -Increase ExperiencePoints by gainingValue
                -Call CheckLevel

        RETURNS

		        NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public void GainXP(int gainingValue)
        {
            ExperiencePoints += gainingValue;
            CheckLevel();
        }
        /**/
        /*
        

        NAME

		        Character::CheckLevel - Function used to check if a levelup should happen

        SYNOPSIS

                 public void CheckLevel()

        DESCRIPTION

		        Function used to check if a character should level up
                -If ExperiencePoints is less than or equal to the CurrentLevelCap
                --Decrease ExperiencePoints by CurrentLevelCap
                --Call LevelUp
                --Call CheckLevel again

        RETURNS

		        NA, void function

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public void CheckLevel()
        {
            if (ExperiencePoints >= CurrentLevelCap)
            {
                ExperiencePoints -= CurrentLevelCap;
                LevelUp();
                CheckLevel();
            }
        }
        /**/
        /*
        

        NAME

		        Character::CurrentLevelCap - Property used to get the current experience level cap

        SYNOPSIS

                 public int CurrentLevelCap

        DESCRIPTION

		        Property used to return experience level caps, used to determine when a level up should happen
                -Based on level of character, returns a speific int value representing the max experience points of any level


        RETURNS

		        Returns int value representing the experience point caps at every level

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int CurrentLevelCap
        {
            get
            {
                if (level == 1) { return 300; }
                else if (level == 2) { return 900; }
                else if (level == 3) { return 2700; }
                else if (level == 4) { return 6500; }
                else if (level == 5) { return 14000; }
                else if (level == 6) { return 23000; }
                else if (level == 7) { return 34000; }
                else if (level == 8) { return 48000; }
                else if (level == 9) { return 64000; }
                else if (level == 10) { return 85000; }
                else if (level == 11) { return 100000; }
                else if (level == 12) { return 120000; }
                else if (level ==13) { return 140000; }
                else if (level ==14) { return 165000; }
                else if (level ==15) { return 195000; }
                else if (level ==16) { return 225000; }
                else if (level ==17) { return 265000; }
                else if (level ==18) { return 305000; }
                else if (level==19) { return 355000; }
                else { return 999999999
; }
            }
        }
        /**/
        /*
        

        NAME

		        Character::Gold - Property used to get/set the Gold held by the character
        SYNOPSIS

                 public int Gold

        DESCRIPTION

		        Property used to get/set Gold of the character
                -Get
                --Return Gold
                -Set
                --Set Gold

        RETURNS

		        On get, returns int value of the Gold the character holds

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public int Gold { get; set; }
    }
}
