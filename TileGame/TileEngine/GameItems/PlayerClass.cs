using System;
using System.Collections.Generic;
using System.Text;

namespace TileEngine
{
    public class PlayerClass
    {
        public string name;
        public List<string> equippableArmors = new List<string>();
        public List<string> equippableWeapons = new List<string>();
        public int str;
        public int dex;
        public int agi;
        public int sta;
        public List<string> skills = new List<string>();
        public List<string> spells = new List<string>();
    }
}
