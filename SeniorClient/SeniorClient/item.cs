using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorClient
{
    public class item
    {
        /**/
        /*
        

        NAME

               Item::Item - Default constructor to Item class

        SYNOPSIS

                public item()

        DESCRIPTION

                  Default constructor for item class

        RETURNS

                NA, default constructor that doesn't do anything

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public item() { }

        /**/
        /*
        

        NAME

               Item::Item - Parameterized constructor for item

        SYNOPSIS

                public item(int damIn, int dieIn, int armIn, string itemName, bool dex)

            int damIn -> int value used to set the Damage value of the item
            int dieIn -> int value uesd to set the Dice value of the item
            int armIn -> int value used to set the Armor value of the item
            string itemName -> string value used to set the Name of the item
            bool dex -> boolean value used to set the DexBased boolean of an item

        DESCRIPTION

                  Parameterized constructor for item class
                  -Sets Damage to damIn
                  -Sets Dice to dieIn
                  -Sets Armor to armIn
                  -Sets Name to itemName
                  -Sets DexBased to dex

        RETURNS

                NA, constructor that just sets some member variables

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/

        public item(int damIn, int dieIn, int armIn, string itemName, bool dex)
        {
            Damage = damIn;
            Dice = dieIn;
            Armor = armIn;
            Name = itemName;
            DexBased = dex;
        }

        private string name;
        /**/
        /*
        

        NAME

               Item::Name - Property returning/setting the Name string

        SYNOPSIS

                public string Name

        DESCRIPTION

                  Property for the Name string
                  -get
                  --Return name
                  -set
                  --Set name to value

        RETURNS

                On get, return string value of the name of the item

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int damage;
        /**/
        /*
        

        NAME

               Item::Damage - Property returning/setting the Damage int

        SYNOPSIS

                public int Damage

        DESCRIPTION

                  Property for the Damage int
                  -get
                  --Return damage
                  -set
                  --Set damage to value

        RETURNS

                On get, return int value of the damage of the item

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        private int dice;
        /**/
        /*
        

        NAME

               Item::Dice - Property returning/setting the Dice int

        SYNOPSIS

                public int Dice

        DESCRIPTION

                  Property for the Dice int
                  -get
                  --Return dice
                  -set
                  --Set dice to value

        RETURNS

                On get, return int value of the damage dice of the item

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int Dice
        {
            get { return dice; }
            set { dice = value; }
        }
        private int armor;
        /**/
        /*
        

        NAME

               Item::Armor - Property returning/setting the Armor int

        SYNOPSIS

                public int Armor

        DESCRIPTION

                  Property for the Armor int
                  -get
                  --Return armor
                  -set
                  --Set armor to value

        RETURNS

                On get, return int value of the armor value of the item

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public int Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        private bool dexBased;
        /**/
        /*
        

        NAME

               Item::DexBased - Property returning/setting the DexBased boolean

        SYNOPSIS

                public bool DexBased

        DESCRIPTION

                  Property for the DexBased boolean
                  -get
                  --Return DexBased
                  -set
                  --Set DexBased to value

        RETURNS

                On get, return bool value of the dexBased variable of the item

        AUTHOR

                Michael Goldberg

        DATE

                

        */
        /**/
        public bool DexBased
        {
            get { return dexBased; }
            set { dexBased = value; }
        }
    }
}
