using System;
using System.Collections;
using System.Windows.Forms;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class Inventory
    {
        public List<Weapon> weapons;
        public List<Armor> armor;
        public List<Utility> utilities;
        public Inventory()
        {
            weapons = new List<Weapon>();
            armor = new List<Armor>();
            utilities = new List<Utility>();
        }
        public void Display()
        {
            Console.Write("Weapons:");
            for(int i = 0; i < weapons.Count; i++)
            {
                Console.Write(weapons[i].name + ", ");
            }
            Console.WriteLine();
            Console.Write("Armor:");
            for(int i = 0; i < armor.Count; i++)
            {
                Console.Write(armor[i].name + ", ");
            }
            Console.WriteLine();
            Console.Write("Utilities: ");
            for(int i = 0; i < utilities.Count; i++)
            {
                Console.Write(utilities[i].name + ", ");
            }
            Console.WriteLine();
        }
    }
}
