using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class Enemy
    {
        public string name;
        public Inventory inventory;
        public Weapon weapon;
        public Armor armor;
        public float health;
        public void View()
        {
            Console.WriteLine("Name: {0}", this.name);
            Console.WriteLine("Health: {0}", this.health);
            Console.WriteLine("Defense: {0}", this.armor.defense);
            Console.WriteLine("Damage: {0}-" + this.weapon.highestDamage, this.weapon.lowestDamage);
        }
        public void Damage(Player player, ConsoleColor color, ConsoleColor dcolor)
        {
            Random random = new Random();
            int miss = random.Next(0, this.weapon.missChance);
            if (miss == 0)
            {
                Console.WriteLine("The {0} missed and did 0 damage!", this.name);
            }
            else
            {
                float damage = ((int)(random.Next(this.weapon.lowestDamage, this.weapon.highestDamage+1)) * (1 - (player.armor.defense/100)));
                player.health -= damage;
                Console.WriteLine("The enemy did {0} damage!", damage);
                Console.ForegroundColor = dcolor;
                if (player.health > 0)
                {
                    Console.WriteLine("Health -{0}, your health is now " + player.health, damage);
                } else
                {
                    Console.WriteLine("Health -{0}, your health is now 0", damage);
                }
                Console.ForegroundColor = color;
                player.armor.durability--;
            }
            if(player.armor.durability <= 0 && !player.armor.broken)
            {
                player.armor.broken = true;
                player.armor.Break();
            }
        } 
        public void Die()
        {
            this.health = 0;
            Console.WriteLine("The {0} has been defeated!", this.name);
        }
    }
}
