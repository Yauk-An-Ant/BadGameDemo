using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class GuardOutfit : Armor
    {
        public GuardOutfit()
        {
            name = "Prison Guard Uniform";
            defense = 5;
            durability = 20;
            broken = false;
        }
    }
}
