using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class MolassesDrink : Utility
    {
        public ShittyBooze()
        {
            name = "Family Friendly Molasses Drink";
            effect = "Allows you attack faster, and therefore do more damage, but you become far easier to hit and more vulerable.";
            cooldown = 0;
        }
        public override void Use(Player player, ConsoleColor color)
        {
            player.equipped.lowestDamage *= 2;
            player.equipped.highestDamage *= 2;
            Console.WriteLine("Your damage is doubled for the next three turns!");
            player.armor.defense /= 2;
            Console.WriteLine("Your defense is halved for the next three turns.");
            cooldown = 4;
            delay = false;
        }
    }
}
