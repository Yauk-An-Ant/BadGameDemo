using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class Fists : Weapon
    {
        public Fists()
        {
            name = "Fists";
            lowestDamage = 1;
            highestDamage = 1;
            durability = int.MaxValue;
            missChance = 5;
        }
    }
}
