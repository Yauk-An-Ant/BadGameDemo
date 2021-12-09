using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class WoodenSword : Weapon
    {
        public WoodenSword()
        {
            name = "Wooden Sword";
            lowestDamage = 3;
            highestDamage = 5;
            durability = 26;
            missChance = 8;
        }
    }
}
