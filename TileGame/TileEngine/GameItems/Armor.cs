using System;
using System.Collections.Generic;
using System.Text;

namespace TileEngine
{
    public class Armor
    {
        public string name;
        public string type;
        public List<string> equipClass = new List<string>();
        public string textureName; 
        public int def;
        public int strbonus;
        public int dexbonus;
        public int agibonus;
        public int stabonus;
        public string defenseType;
        public string specialAbility;

        public Armor()
        {

        }
    }
}
