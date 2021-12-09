using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class Utility
    {
        public string name;
        public string effect;
        public int cooldown;
        public bool delay;
        public virtual void Use(Player player, ConsoleColor color)
        {
            
        }
    }
}
