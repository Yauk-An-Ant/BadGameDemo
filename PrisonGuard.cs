using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class PrisonGuard : Enemy
    {
        public PrisonGuard()
        {
            inventory = new Inventory();
            name = "Prison Guard";
            weapon = new WoodenSword();
            health = 20;
            armor = new GuardOutfit();
            Painkiller pain1 = new Painkiller();
            Painkiller pain2 = new Painkiller();
            Painkiller pain3 = new Painkiller();
            ShittyBooze booze1 = new ShittyBooze();
            ShittyBooze booze2 = new ShittyBooze();
            this.inventory.weapons.Add(weapon);
            this.inventory.armor.Add(armor);
            this.inventory.utilities.Add(pain1);
            this.inventory.utilities.Add(pain2);
            this.inventory.utilities.Add(pain3);
            this.inventory.utilities.Add(booze1);
            this.inventory.utilities.Add(booze2);
        }
        public PrisonGuard(bool Weakened)
        {
            if(Weakened)
            {
                inventory = new Inventory();
                name = "Prison Guard";
                weapon = new WoodenSword();
                health = 10;
                armor = new GuardOutfit();
                armor.defense -= 3;
                Painkiller pain1 = new Painkiller();
                Painkiller pain2 = new Painkiller();
                Painkiller pain3 = new Painkiller();
                this.inventory.weapons.Add(weapon);
                this.inventory.armor.Add(armor);
                this.inventory.utilities.Add(pain1);
                this.inventory.utilities.Add(pain2);
                this.inventory.utilities.Add(pain3);
            } else
            {
                inventory = new Inventory();
                name = "Prison Guard";
                weapon = new Bludgeon();
                health = 20;
                armor = new GuardOutfit();
                Painkiller pain1 = new Painkiller();
                Painkiller pain2 = new Painkiller();
                Painkiller pain3 = new Painkiller();
                MolassesDrink m1 = new MolassesDrink();
                MolassesDrink m2 = new MolassesDrink();
                MolassesDrink m3 = new MolassesDrink();
                this.inventory.weapons.Add(weapon);
                this.inventory.armor.Add(armor);
                this.inventory.utilities.Add(pain1);
                this.inventory.utilities.Add(pain2);
                this.inventory.utilities.Add(pain3);
                this.inventory.utilities.Add(m1);
                this.inventory.utilities.Add(m2);
                this.inventory.utilities.Add(m3);
            }
        }
    } 
}
