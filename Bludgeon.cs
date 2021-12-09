using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class Bludgeon : Weapon
    {
        public Bludgeon()
        {
            name = "Bludegon";
            lowestDamage = 4;
            highestDamage = 8;
            durability = 45;
            missChance = 8;
        }
    }
}
