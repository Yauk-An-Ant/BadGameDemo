using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class Weapon
    {
        public string name;
        public int lowestDamage;
        public int highestDamage;
        public int missChance;
        public int durability;
        Random random = new Random();
        public void Damage(Enemy enemy)
        {
            this.durability--;
            if(this.durability <= 0)
            {
                Break();
            }
            int miss = random.Next(0, this.missChance);
            if(miss == 0)
            {
                Console.WriteLine("You missed!");
            } else
            {
                float damage = ((float)(random.Next(this.lowestDamage, this.highestDamage+1)) * (1 - (enemy.armor.defense/100)));
                enemy.health -= damage;
                enemy.armor.durability--;
                Console.WriteLine("You did {0} damage!", damage);
                if (enemy.health >= 0)
                {
                    Console.WriteLine("The {0} now has " + enemy.health + " health!", enemy.name);
                } else
                {
                    Console.WriteLine("The {0} now has 0 health!", enemy.name);
                }
                if(enemy.armor.durability <= 0)
                {
                    enemy.armor.Break(enemy);
                }
            }

        }
        public void Break()
        {
            this.lowestDamage = 1;
            this.highestDamage = 1;
            Console.WriteLine("Your {0} has broken!", this.name);
        }
    }
}
