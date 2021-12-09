using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class StoneChip : Weapon
    {
        public StoneChip()
        {
            name = "Stone Chip";
            lowestDamage = 1;
            highestDamage = 3;
            durability = 12;
            missChance = 6;
        }
    }
}
