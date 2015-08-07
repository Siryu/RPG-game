using System;
using System.Collections.Generic;
using System.Text;

namespace TileEngine
{
    public class Weapon
    {
        public string name;
        public string type;
        public List<string> equipClass = new List<string>();
        public string textureName;
        public int attack;
        public int acc;
        public int parry;
        public int strbonus;
        public int dexbonus;
        public int agibonus;
        public int stabonus;
        public string damageType;
        public string specialAbility;

        public Weapon()
        {

        }
    }
}
