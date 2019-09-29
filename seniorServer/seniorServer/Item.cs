using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorClient
{
    public class item
    {
        public item() { }

        public item(int damIn, int dieIn, int armIn, string itemName, bool dex)
        {
            Damage = damIn;
            Dice = dieIn;
            Armor = armIn;
            Name = itemName;
            DexBased = dex;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int damage;
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        private int dice;
        public int Dice
        {
            get { return dice; }
            set { dice = value; }
        }
        private int armor;
        public int Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        private bool dexBased;
        public bool DexBased
        {
            get { return dexBased; }
            set { dexBased = value; }
        }
    }
}
