using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class Armor
    {
        public string name;
        public float defense;
        public int durability;
        public bool broken;
        public void Break()
        {
            defense = 0;
            Console.WriteLine("Your {0} has broken!", this.name);
        }
        public void Break(Enemy enemy)
        {
            defense = 0;
            Console.WriteLine("The {0}'s " + this.name + " has broken!", enemy.name);
        }
    }
}
