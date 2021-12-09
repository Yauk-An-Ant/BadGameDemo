using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BadGame
{   [XmlInclude(typeof(Weapon))]
    [XmlInclude(typeof(Fists))]
    [XmlInclude(typeof(StoneChip))]
    [XmlInclude(typeof(WoodenSword))]
    [XmlInclude(typeof(Bludgeon))]
    [XmlInclude(typeof(Armor))]
    [XmlInclude(typeof(JailRags))]
    [XmlInclude(typeof(GuardOutfit))]
    [XmlInclude(typeof(Utility))]
    [XmlInclude(typeof(Painkiller))]
    [XmlInclude(typeof(ShittyBooze))]
    [XmlInclude(typeof(Inventory))]
    public class Player
    {
        public string name;
        public float health;
        public Armor armor;
        public Weapon equipped;
        public Inventory inventory;
        public Player()
        {
            inventory = new Inventory();
            Fists fists = new Fists();
            this.equipped = fists;
        }
        public void PickUp(Armor armor)
        {
            inventory.armor.Add(armor);
            Console.WriteLine("You picked up the {0}!", armor.name);
        }
        public void PickUp(Weapon weapon)
        {
            inventory.weapons.Add(weapon);
            Console.WriteLine("You picked up a {0}!", weapon.name);
        }
        public void PickUp(Utility item)
        {
            inventory.utilities.Add(item);
            Console.WriteLine("You picked up a {0}!", item.name);
        }
        public void Equip(Armor armor)
        {
            this.armor = armor;
        }
        public void Equip(Weapon weapon)
        {
            this.equipped = weapon;
        }
    }
}
