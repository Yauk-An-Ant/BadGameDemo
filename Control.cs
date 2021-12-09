using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class Control
    {
        public static void Combat(Player player, Enemy enemy, Checkpoint checkpoint, ConsoleColor color)
        {
            Console.Clear();
            Console.WriteLine("The {0} attacks you!", enemy.name);
            float defense = player.armor.defense;
            int lowest = player.equipped.lowestDamage;
            int highest = player.equipped.highestDamage;
            bool effect = false;
            int counter = 0;
            Utility item = new Utility();
            do
            {
                if(effect)
                {
                    counter--;
                    if(counter == 0)
                    {
                        if(!item.delay)
                        {
                            player.equipped.lowestDamage = lowest;
                            player.equipped.highestDamage = highest;
                            player.armor.defense = defense;
                            effect = false;
                        } else
                        {
                            item.Use(player, color);
                            item.delay = false;
                            counter = item.cooldown;
                        }
                    }
                }
                Console.Write("Your turn: ");
                string turn = Console.ReadLine().ToLower();
                if (turn.Equals("a"))
                {
                    player.equipped.Damage(enemy);
                }
                else if (turn.Equals("d"))
                {
                        Console.WriteLine("You defend!");
                        player.armor.defense = 100;
                }
                else
                {
                    ExtraChoices(player, turn, enemy, color);
                    foreach(var i in player.inventory.utilities)
                    {
                        if(i.cooldown != 0)
                        {
                            effect = true;
                            counter = i.cooldown;
                            item = i;
                        }
                    }
                }
                if (enemy.health > 0)
                {
                    enemy.Damage(player, color, ConsoleColor.Red);
                }
                else
                {
                    enemy.Die();
                }
                if (player.health <= 0)
                {
                    checkpoint.checkpoint--;
                    Program.GameOver(player, checkpoint);
                }
            } while (enemy.health > 0);
            checkpoint.checkpoint++;
            Console.WriteLine("Do you wish to loot the enemy? Press l to do so.");
            string choice = Console.ReadLine().ToLower();
            if(choice.Equals("l"))
            {
                Loot(player, enemy);
            }
            checkpoint.checkpoint++;
            Console.WriteLine("Do you wish to save your game?");
            Console.Write("");
            string save = Console.ReadLine().ToLower();
            SaveSystem saves = new SaveSystem();
            if (save.Contains("ye"))
            {
                saves.Save(checkpoint, player);
            }
        }
        public static void Loot(Player player, Enemy enemy)
        {
            enemy.inventory.Display();
            bool view = true;
            Console.WriteLine("Do you wish to view the stats of any item?");
            Console.Write("");
            string c = Console.ReadLine().ToLower();
            if (c.Contains("ye"))
                do
                {
                    Console.Write("Type the name of the item, press n to exit: ");
                    string v = Console.ReadLine().ToLower();
                    bool weapon = false;
                    bool utility = false;
                    foreach (var i in enemy.inventory.weapons.ToList())
                    {
                        if (v.Equals(i.name.ToLower()))
                        {
                            Console.WriteLine("Name: {0}", i.name);
                            Console.WriteLine("Damage: {0}-" + i.highestDamage, i.lowestDamage);
                            Console.WriteLine("Chance of Missing: 1 in {0}", i.missChance);
                            Console.WriteLine("Durability: {0}", i.durability);
                            weapon = true;
                            break;
                        }
                    }
                    foreach (var i in enemy.inventory.armor.ToList())
                    {
                        if (v.Equals(i.name.ToLower()))
                        {
                            Console.WriteLine("Name: {0}", i.name);
                            Console.WriteLine("Defense: {0}", i.defense);
                            Console.WriteLine("Durability: {0}", i.durability);
                            weapon = false;
                            break;
                        }
                    }
                    foreach (var i in enemy.inventory.utilities.ToList())
                    {
                        if (v.Equals(i.name.ToLower()))
                        {
                            Console.WriteLine("Name: {0}", i.name);
                            Console.WriteLine("Effect: {0}", i.effect);
                            utility = true;
                            break;
                        }
                    }
                    if (v.Equals("n"))
                    {
                        view = false;
                        enemy.inventory.Display();
                        break;
                    }
                    Console.Write("Press c to compare with currently equipped: ");
                    string comp = Console.ReadLine().ToLower();
                    if (comp.Contains("c") && !utility)
                    {
                        Console.WriteLine("Equipped:");
                        if (weapon)
                        {
                            Console.WriteLine("Name: {0}", player.equipped.name);
                            Console.WriteLine("Damage: {0}-" + player.equipped.highestDamage, player.equipped.lowestDamage);
                            Console.WriteLine("Durability: {0}", player.equipped.durability);
                            Console.WriteLine("Chance of Missing: 1 in {0}", player.equipped.missChance);
                        }
                        else if (!weapon)
                        {
                            Console.WriteLine("Name: {0}", player.armor.name);
                            Console.WriteLine("Defense: {0}", player.armor.defense);
                            Console.WriteLine("Durability: {0}", player.armor.durability);
                        }
                    }
                } while (view);
            string choice;
            do
            {
                Console.Write("Type what you wish to take: ");
                choice = Console.ReadLine().ToLower();
                foreach (Weapon i in enemy.inventory.weapons.ToList())
                {
                    if (choice.Equals(i.name.ToLower()))
                    {
                        player.inventory.weapons.Add(i);
                        Console.WriteLine("You have taken a {0}", i.name);
                        enemy.inventory.weapons.Remove(i);
                        player.inventory.weapons.Remove(player.inventory.weapons[0]);
                        enemy.inventory.Display();
                        break;
                    }
                }
                foreach (Armor i in enemy.inventory.armor.ToList())
                {
                    if (choice.Equals(i.name.ToLower()))
                    {
                        player.inventory.armor.Add(i);
                        Console.WriteLine("You have taken the {0}", i.name);
                        enemy.inventory.armor.Remove(i);
                        enemy.inventory.Display();
                        break;
                    }
                }
                foreach (Utility i in enemy.inventory.utilities.ToList())
                {
                    if (choice.Equals(i.name.ToLower()))
                    {
                        player.inventory.utilities.Add(i);
                        Console.WriteLine("You have taken a {0}", i.name);
                        enemy.inventory.utilities.Remove(i);
                        enemy.inventory.Display();
                        break;
                    }
                }
            } while (!choice.Equals("n"));
        }
        public static void ExtraChoices(Player player, string choice, ConsoleColor color)
        {
            if (choice.Equals("i"))
            {
                bool equip;
                do
                {
                    equip = false;
                    player.inventory.Display();
                    Console.Write("");
                    string c = Console.ReadLine().ToLower();
                    if (c.Equals("e"))
                    {
                        Console.Write("Type what you wish to equip or use: ");
                        string eq = Console.ReadLine().ToLower();
                        for (int i = 0; i < player.inventory.weapons.Count; i++)
                        {
                            if (eq.Equals(player.inventory.weapons[i].name.ToLower()))
                            {
                                player.Equip(player.inventory.weapons[i]);
                                Console.WriteLine("You have equipped {0}!", player.inventory.weapons[i].name);
                                equip = true;
                            }
                        }
                        for (int i = 0; i < player.inventory.armor.Count; i++)
                        {
                            if (eq.Equals(player.inventory.armor[i].name.ToLower()))
                            {
                                player.Equip(player.inventory.armor[i]);
                                Console.WriteLine("You have equipped {0}!", player.inventory.armor[i].name);
                                equip = true;
                            }
                        }
                        foreach (var i in player.inventory.utilities)
                        {
                            if (eq.Equals(i.name.ToLower()))
                            {
                                i.Use(player, color);
                                player.inventory.utilities.Remove(i);
                                equip = true;
                                break;
                            }
                        }
                    }
                    else if (c.Equals("v"))
                    {
                        Console.Write("Type what you wish to view the stats of: ");
                        string stat = Console.ReadLine().ToLower();
                        bool weapon = false;
                        bool utility = false;
                        for (int i = 0; i < player.inventory.weapons.Count; i++)
                        {
                            if (stat.Equals(player.inventory.weapons[i].name.ToLower()))
                            {
                                Console.WriteLine("Name: {0}", player.inventory.weapons[i].name);
                                Console.WriteLine("Damage: {0}-" + player.inventory.weapons[i].highestDamage, player.inventory.weapons[i].lowestDamage);
                                Console.WriteLine("Chance of Missing: 1 in {0}", player.inventory.weapons[i].missChance);
                                Console.WriteLine("Durability: {0}", player.inventory.weapons[i].durability);
                                weapon = true;
                            }
                        }
                        for (int i = 0; i < player.inventory.armor.Count; i++)
                        {
                            if (stat.Equals(player.inventory.armor[i].name.ToLower()))
                            {
                                Console.WriteLine("Name: {0}", player.inventory.armor[i].name);
                                Console.WriteLine("Defense: {0}", player.inventory.armor[i].defense);
                                Console.WriteLine("Durability: {0}", player.inventory.armor[i].durability);
                                weapon = false;
                            }
                        }
                        foreach (var i in player.inventory.utilities)
                        {
                            if (stat.Equals(i.name.ToLower()))
                            {
                                Console.WriteLine("Name: {0}", i.name);
                                Console.WriteLine("Effect: {0}", i.effect);
                                utility = true;
                            }
                        }
                        Console.Write("");
                        string comp = Console.ReadLine().ToLower();
                        if (comp.Contains("c") && !utility)
                        {
                            Console.WriteLine("Equipped:");
                            if (weapon == true)
                            {
                                Console.WriteLine("Name: {0}", player.equipped.name);
                                Console.WriteLine("Damage: {0}-" + player.equipped.highestDamage, player.equipped.lowestDamage);
                                Console.WriteLine("Durability: {0}", player.equipped.durability);
                                Console.WriteLine("Chance of Missing: 1 in {0}", player.equipped.missChance);
                            }
                            else
                            {
                                Console.WriteLine("Name: {0}", player.armor.name);
                                Console.WriteLine("Defense: {0}", player.armor.defense);
                                Console.WriteLine("Durability: {0}", player.armor.durability);
                            }
                        }
                    } else
                    {
                        equip = true;
                    }
                } while (!equip);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("That wasn't an option.");
            }
        }
        public static void ExtraChoices(Player player, string choice, Enemy enemy, ConsoleColor color)
        {
            if (choice.Equals("v"))
            {
                enemy.View();
            }
            else if (choice.Equals("i"))
            {
                bool equip;
                do
                {
                    equip = false;
                    player.inventory.Display();
                    Console.Write("");
                    string c = Console.ReadLine().ToLower();
                    if (c.Equals("e"))
                    {
                        Console.Write("Type what you wish to equip or use: ");
                        string eq = Console.ReadLine().ToLower();
                        for (int i = 0; i < player.inventory.weapons.Count; i++)
                        {
                            if (eq.Equals(player.inventory.weapons[i].name.ToLower()))
                            {
                                player.Equip(player.inventory.weapons[i]);
                                Console.WriteLine("You have equipped {0}!", player.inventory.weapons[i].name);
                                equip = true;
                            }
                        }
                        for (int i = 0; i < player.inventory.armor.Count; i++)
                        {
                            if (eq.Equals(player.inventory.armor[i].name.ToLower()))
                            {
                                player.Equip(player.inventory.armor[i]);
                                Console.WriteLine("You have equipped {0}!", player.inventory.armor[i].name);
                                equip = true;
                            }
                        }
                        foreach (var i in player.inventory.utilities)
                        {
                            if (eq.Equals(i.name.ToLower()))
                            {
                                i.Use(player, color);
                                player.inventory.utilities.Remove(i);
                                equip = true;
                                break;
                            }
                        }
                    }
                    else if (c.Equals("v"))
                    {
                        Console.Write("Type what you wish to view the stats of: ");
                        string stat = Console.ReadLine().ToLower();
                        bool weapon = false;
                        bool utility = false;
                        for (int i = 0; i < player.inventory.weapons.Count; i++)
                        {
                            if (stat.Equals(player.inventory.weapons[i].name.ToLower()))
                            {
                                Console.WriteLine("Name: {0}", player.inventory.weapons[i].name);
                                Console.WriteLine("Damage: {0}-" + player.inventory.weapons[i].highestDamage, player.inventory.weapons[i].lowestDamage);
                                Console.WriteLine("Chance of Missing: 1 in {0}", player.inventory.weapons[i].missChance);
                                Console.WriteLine("Durability: {0}", player.inventory.weapons[i].durability);
                                weapon = true;
                            }
                        }
                        for (int i = 0; i < player.inventory.armor.Count; i++)
                        {
                            if (stat.Equals(player.inventory.armor[i].name.ToLower()))
                            {
                                Console.WriteLine("Name: {0}", player.inventory.armor[i].name);
                                Console.WriteLine("Defense: {0}", player.inventory.armor[i].defense);
                                Console.WriteLine("Durability: {0}", player.inventory.armor[i].durability);
                                weapon = false;
                            }
                        }
                        foreach (var i in player.inventory.utilities)
                        {
                            if (stat.Equals(i.name.ToLower()))
                            {
                                Console.WriteLine("Name: {0}", i.name);
                                Console.WriteLine("Effect: {0}", i.effect);
                                utility = true;
                            }
                        }
                        Console.Write("");
                        string comp = Console.ReadLine().ToLower();
                        if (comp.Contains("c") && !utility)
                        {
                            Console.WriteLine("Equipped:");
                            if (weapon)
                            {
                                Console.WriteLine("Name: {0}", player.equipped.name);
                                Console.WriteLine("Damage: {0}-" + player.equipped.highestDamage, player.equipped.lowestDamage);
                                Console.WriteLine("Durability: {0}", player.equipped.durability);
                                Console.WriteLine("Chance of Missing: 1 in {0}", player.equipped.missChance);
                            }
                            else if (!weapon)
                            {
                                Console.WriteLine("Name: {0}", player.armor.name);
                                Console.WriteLine("Defense: {0}", player.armor.defense);
                                Console.WriteLine("Durability: {0}", player.armor.durability);
                            }
                        }
                    } else
                    {
                        equip = true;
                    }
                }while(!equip);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("That isn't an option, nice use of your turn, actually think next time maybe.");
            }
        }
        public static void CombatTutorial(Player player, Enemy enemy, Checkpoint checkpoint)
        {
            player.health = 100;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("The {0} attacks you!", enemy.name);
            Console.WriteLine("A strange voice rings out through your mind");
            Console.WriteLine("???: 'So, you've gotten into your first fight after all this started.'");
            Console.WriteLine("???: 'Who am I? That's irrelavant and we have much more pressing matters to deal with.'");
            Console.WriteLine("???: 'First thing's first, we need something for you to fight back with.'");
            Console.WriteLine("???: Press i to go to your inventory and find out what you can even use. If there's nothing in there you can probably just bare hand this.'");
            bool chosen = false;
            do
            {
                string turn1 = Console.ReadLine().ToLower();
                if (turn1.Equals("i"))
                {
                    chosen = true;
                    player.inventory.Display();
                }
                else
                {
                    Console.WriteLine("???: 'That wasn't what you were supposed to do! I'm only trying to help you here!'");
                }
            } while (!chosen);
            Console.WriteLine("???: 'Alright, now you're gonna want to press e to equip some sort of weapon.'");
            chosen = false;
            do
            {
                Console.Write("");
                string choice = Console.ReadLine().ToLower();
                if (choice.Equals("e"))
                {
                    Console.Write("Type what you wish to equip or use: ");
                    string eq = Console.ReadLine().ToLower();
                    for (int i = 0; i < player.inventory.weapons.Count; i++)
                    {
                        if (eq.Equals(player.inventory.weapons[i].name.ToLower()))
                        {
                            player.Equip(player.inventory.weapons[i]);
                            Console.WriteLine("You have equipped {0}!", player.inventory.weapons[i].name);
                            chosen = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("???: 'That wasn't what you were supposed to do! I'm only trying to help you here!'");
                }
            } while (!chosen);
            Console.WriteLine("???: 'If you're wondering what the Jail Rags are and where you got them from, you have them on right now and you had them on when you got here. They don't do much.'");
            Console.WriteLine("Alright now we get into the meat of things!");
            enemy.Damage(player, ConsoleColor.Black, ConsoleColor.DarkRed);
            Console.WriteLine("???: 'Whoops, I cost you a turn. Equipping things does take a turn, and it's not like you can win this without anything equipped.'");
            Console.WriteLine("???: 'Good news is, it's now your turn. Press a to attack it yourself. Retaliation!'");
            chosen = false;
            do
            {
                Console.Write("");
                string turn2 = Console.ReadLine().ToLower();
                if (turn2.Equals("a"))
                {
                    chosen = true;
                    player.equipped.Damage(enemy);
                }
                else
                {
                    Console.WriteLine("???: 'That wasn't what you were supposed to do! I'm only trying to help you here!'");
                }
            } while (!chosen);
            enemy.Damage(player, ConsoleColor.Black, ConsoleColor.DarkRed);
            Console.WriteLine("???: 'Another thing I have to teach you is that you can view the stats of your enemy. Press v to do that.'");
            chosen = false;
            do
            {
                Console.Write("");
                string turn2 = Console.ReadLine().ToLower();
                if (turn2.Equals("v"))
                {
                    chosen = true;
                    enemy.View();
                }
                else
                {
                    Console.WriteLine("???: 'That wasn't what you were supposed to do! I'm only trying to help you here!'");
                }
            } while (!chosen);
            enemy.Damage(player, ConsoleColor.Black, ConsoleColor.DarkRed);
            Console.WriteLine("???: 'Oh well, another turn gone. But you've gotta learn sometime, and better now then never, eh?'");
            Console.WriteLine("???: 'Alright, now you can get the rest on your own.'");
            bool first = true;
            bool brek = true;
            do
            {
                Console.Write("Your turn: ");

                string turn = Console.ReadLine().ToLower();
                if (turn.Equals("a"))
                {
                    player.equipped.Damage(enemy);
                    if (first)
                    {
                        Console.WriteLine("???: 'Yeah, you're getting it!'");
                    }
                }
                else if (turn.Equals("i"))
                {
                    player.inventory.Display();
                    Console.Write("");
                    string choice = Console.ReadLine().ToLower();
                    if (choice.Equals("e"))
                    {
                        Console.Write("Type what you wish to equip or use: ");
                        string eq = Console.ReadLine().ToLower();
                        for (int i = 0; i < player.inventory.weapons.Count; i++)
                        {
                            if (eq.Equals(player.inventory.weapons[i].name.ToLower()))
                            {
                                player.Equip(player.inventory.weapons[i]);
                                Console.WriteLine("You have equipped {0}!", player.inventory.weapons[i].name);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("That isn't an option, nice use of your turn, actually think next time maybe.");
                }
                if (enemy.health > 0)
                {
                    enemy.Damage(player, ConsoleColor.Black, ConsoleColor.DarkRed);
                }
                else
                {
                    enemy.Die();
                }
                if (player.armor.defense == 0 && brek)
                {
                    brek = false;
                    Console.WriteLine("???: 'It wasn't doing much anyway. I'm not really a fan of those.'");
                }
                if (player.health <= 0)
                {
                    Program.GameOver(player, checkpoint);
                }
                first = false;
            } while (enemy.health > 0);
            Console.WriteLine("???: Yay! You did it! ok i'll stop that's probably annoying. Onto the important stuff!");
            Console.ReadLine();
            Console.WriteLine("???: 'Now that you've beaten that guy, why don't you steal all his stuff too? It's not like he was using it well.'");
            Console.WriteLine("???: 'Press l to loot him'");
            chosen = false;
            do
            {
                Console.Write("");
                string choice = Console.ReadLine().ToLower();
                if (choice.Equals("l"))
                {
                    LootTutorial(player, enemy);
                    chosen = true;
                }
                else
                {
                    Console.WriteLine("???: 'That wasn't what you were supposed to do! I'm only trying to help you here!'");
                }
            } while (!chosen);
            Jail.Lure(player);
        }
        public static void LootTutorial(Player player, Enemy enemy)
        {
            enemy.inventory.Display();
            Console.WriteLine("???: 'First thing you want to do, is answer yes to the next question to view the stats of one of the items. After it gives you one, you can type another name to look at another. Press n to exit it.'");
            Console.WriteLine("???: 'Oh, and press c after it shows you the stats to compare it to what you have on right now.'");
            bool view = true;
            bool b = false;
            do
            {
                Console.WriteLine("Do you wish to view the stats of any item?");
                Console.Write("");
                string c = Console.ReadLine().ToLower();
                if (c.Equals("yes"))
                {
                    b = true;
                    do
                    {
                        Console.Write("Type the name of the item: ");
                        string v = Console.ReadLine().ToLower();
                        bool weapon = false;
                        bool utility = false;
                        foreach (var i in enemy.inventory.weapons.ToList())
                        {
                            if (v.Equals(i.name.ToLower()))
                            {
                                Console.WriteLine("Name: {0}", i.name);
                                Console.WriteLine("Damage: {0}-" + i.highestDamage, i.lowestDamage);
                                Console.WriteLine("Chance of Missing: 1 in {0}", i.missChance);
                                Console.WriteLine("Durability: {0}", i.durability);
                                weapon = true;
                            }
                        }
                        foreach (var i in enemy.inventory.armor.ToList())
                        {
                            if (v.Equals(i.name.ToLower()))
                            {
                                Console.WriteLine("Name: {0}", i.name);
                                Console.WriteLine("Defense: {0}", i.defense);
                                Console.WriteLine("Durability: {0}", i.durability);
                                weapon = false;
                            }
                        }
                        foreach (var i in enemy.inventory.utilities.ToList())
                        {
                            if (v.Equals(i.name.ToLower()))
                            {
                                Console.WriteLine("Name: {0}", i.name);
                                Console.WriteLine("Effect: {0}", i.effect);
                                utility = true;
                                break;
                            }
                        }
                        if (v.Contains("n"))
                        {
                            view = false;
                        }
                        Console.Write("Press c to compare to what you currently have equipped: ");
                        string comp = Console.ReadLine().ToLower();
                        if (comp.Contains("c") && !utility)
                        {
                            Console.WriteLine("Equipped:");
                            if (weapon)
                            {
                                Console.WriteLine("Name: {0}", player.equipped.name);
                                Console.WriteLine("Damage: {0}-" + player.equipped.highestDamage, player.equipped.lowestDamage);
                                Console.WriteLine("Durability: {0}", player.equipped.durability);
                                Console.WriteLine("Chance of Missing: 1 in {0}", player.equipped.missChance);
                            }
                            else if (!weapon)
                            {
                                Console.WriteLine("Name: {0}", player.armor.name);
                                Console.WriteLine("Defense: {0}", player.armor.defense);
                                Console.WriteLine("Durability: {0}", player.armor.durability);
                            }
                        }
                    } while (view);
                }
                else
                {
                    Console.WriteLine("???: 'That wasn't what you were supposed to do! I'm only trying to help you here!'");
                }
            } while (!b);
            Console.WriteLine("Alright, now you can just type things you want to take, and exit out of it by pressing n. You should probably take everything");
                string choice;
            do
            {
                Console.Write("Type what you wish to take: ");
                choice = Console.ReadLine().ToLower();
                foreach (Weapon i in enemy.inventory.weapons.ToList())
                {
                    if (choice.Equals(i.name.ToLower()))
                    {
                        player.inventory.weapons.Add(i);
                        Console.WriteLine("You have taken a {0}", i.name);
                        enemy.inventory.weapons.Remove(i);
                        player.inventory.weapons.Remove(player.inventory.weapons[0]);
                        enemy.inventory.Display();
                        break;
                    }
                }
                foreach (Armor i in enemy.inventory.armor.ToList())
                {
                    if (choice.Equals(i.name.ToLower()))
                    {
                        player.inventory.armor.Add(i);
                        Console.WriteLine("You have taken the {0}", i.name);
                        enemy.inventory.armor.Remove(i);
                        enemy.inventory.Display();
                        break;
                    }
                }
                foreach (Utility i in enemy.inventory.utilities.ToList())
                {
                    if (choice.Equals(i.name.ToLower()))
                    {
                        player.inventory.utilities.Add(i);
                        Console.WriteLine("You have taken a {0}", i.name);
                        enemy.inventory.utilities.Remove(i);
                        enemy.inventory.Display();
                        break;
                    }
                }
            } while (!choice.Equals("n"));
            ExtraChoicesTutorial(player, ConsoleColor.Black);
            Checkpoint checkpoint = new Checkpoint();
            checkpoint.SetCheckpoint(4);
            Console.WriteLine("Do you wish to save your game?");
            Console.Write("");
            string save = Console.ReadLine().ToLower();
            SaveSystem saves = new SaveSystem();
            if (save.Contains("ye"))
            {
                saves.Save(checkpoint, player);
            }
            Jail.Lure(player);
        }
        public static void ExtraChoicesTutorial(Player player, ConsoleColor color)
        {
            Console.WriteLine("???: 'Alright, now what I'm about to teach you can be used any time you are presented with a choice, so listen up.'");
            Console.WriteLine("???: 'Now the first thing, is that you can now open your inventory whenever. Press i just like always to do that.'");
            bool chosen = false;
            do
            {
                Console.Write("");
                string choice = Console.ReadLine().ToLower();
                if (choice.Equals("i"))
                {
                    bool equip;
                    do
                    {
                        equip = false;
                        chosen = true;
                        player.inventory.Display();
                        Console.WriteLine("???: 'You already know the details of most of this stuff but you can press e to equip or use stuff, press v to view the stats of anything, and c after v to compare them. Press n to exit. The main thing here is that you can now do this whenever really. Try it out!'");
                        Console.Write("");
                        string c = Console.ReadLine().ToLower();
                        if (c.Equals("e"))
                        {
                            chosen = true;
                            Console.Write("Type what you wish to equip or use: ");
                            string eq = Console.ReadLine().ToLower();
                            for (int i = 0; i < player.inventory.weapons.Count; i++)
                            {
                                if (eq.Equals(player.inventory.weapons[i].name.ToLower()))
                                {
                                    player.Equip(player.inventory.weapons[i]);
                                    Console.WriteLine("You have equipped {0}!", player.inventory.weapons[i].name);
                                    equip = true;
                                }
                            }
                            for (int i = 0; i < player.inventory.armor.Count; i++)
                            {
                                if (eq.Equals(player.inventory.armor[i].name.ToLower()))
                                {
                                    player.Equip(player.inventory.armor[i]);
                                    Console.WriteLine("You have equipped {0}!", player.inventory.armor[i].name);
                                    equip = true;
                                }
                            }
                            foreach (var i in player.inventory.utilities)
                            {
                                if (eq.Equals(i.name.ToLower()))
                                {
                                    i.Use(player, color);
                                    equip = true;
                                }
                            }
                        }
                        else if (c.Equals("v"))
                        {
                            chosen = true;
                            Console.Write("Type what you wish to view the stats of: ");
                            string stat = Console.ReadLine().ToLower();
                            bool weapon = false;
                            bool utility = false;
                            for (int i = 0; i < player.inventory.weapons.Count; i++)
                            {
                                if (stat.Equals(player.inventory.weapons[i].name.ToLower()))
                                {
                                    Console.WriteLine("Name: {0}", player.inventory.weapons[i].name);
                                    Console.WriteLine("Damage: {0}-" + player.inventory.weapons[i].highestDamage, player.inventory.weapons[i].lowestDamage);
                                    Console.WriteLine("Chance of Missing: 1 in {0}", player.inventory.weapons[i].missChance);
                                    Console.WriteLine("Durability: {0}", player.inventory.weapons[i].durability);
                                    weapon = true;
                                }
                            }
                            for (int i = 0; i < player.inventory.armor.Count; i++)
                            {
                                if (stat.Equals(player.inventory.armor[i].name.ToLower()))
                                {
                                    Console.WriteLine("Name: {0}", player.inventory.armor[i].name);
                                    Console.WriteLine("Defense: {0}", player.inventory.armor[i].defense);
                                    Console.WriteLine("Durability: {0}", player.inventory.armor[i].durability);
                                    weapon = false;
                                }
                            }
                            foreach (var i in player.inventory.utilities)
                            {
                                if (stat.Equals(i.name.ToLower()))
                                {
                                    Console.WriteLine("Name: {0}", i.name);
                                    Console.WriteLine("Effect: {0}", i.effect);
                                    utility = true;
                                }
                            }
                            Console.Write("Press c to compare with what you currently have equipped: ");
                            string comp = Console.ReadLine().ToLower();
                            if (comp.Contains("c") && !utility)
                            {
                                Console.WriteLine("Equipped:");
                                if (weapon == true)
                                {
                                    Console.WriteLine("Name: {0}", player.equipped.name);
                                    Console.WriteLine("Damage: {0}-" + player.equipped.highestDamage, player.equipped.lowestDamage);
                                    Console.WriteLine("Durability: {0}", player.equipped.durability);
                                    Console.WriteLine("Chance of Missing: 1 in {0}", player.equipped.missChance);
                                }
                                else
                                {
                                    Console.WriteLine("Name: {0}", player.armor.name);
                                    Console.WriteLine("Defense: {0}", player.armor.defense);
                                    Console.WriteLine("Durability: {0}", player.armor.durability);
                                }
                            }
                        } else
                        {
                            equip = true;
                        }
                    } while (!equip);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("???: 'That wasn't what you were supposed to do! I'm only trying to help you here!'");
                }
            } while (!chosen);
            Console.WriteLine("???: 'Well then, that's all I really have to teach you for now. You can figure everything else out on your own anyway. I'm excited to see how your story progresses, and we'll see each other again at some point, or at least we'll hear.'");
            Console.ReadLine();
        }
    }
}
