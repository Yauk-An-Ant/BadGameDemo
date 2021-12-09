using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class Painkiller : Utility
    {
        public Painkiller()
        {
            name = "Painkiller";
            effect = "Lets you go on longer - Heals for 10 health";
            cooldown = 0;
        }
        public override void Use(Player player, ConsoleColor color)
        {
            Console.WriteLine("You used the Painkiller!");
            player.health += 10;
            if(player.health >= 100)
            {
                player.health = 100;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health +10! Your health is now {0}!", player.health);
            Console.ForegroundColor = color;
        }
    }
}
