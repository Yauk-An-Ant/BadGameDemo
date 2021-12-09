using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Checkpoint saver = new Checkpoint();
            saver.SetCheckpoint(1);
            player.health = 100;
            Menu(player, saver);
        }
        public static void Menu(Player player, Checkpoint checkpoint)
        {
            Console.Clear();
            SaveSystem save = new SaveSystem();
            Console.Clear();
            Fists fists = new Fists();
            player.inventory.weapons.Add(fists);
            Console.ResetColor();
            Console.WriteLine("badGame.exe!");
            Console.WriteLine("*Full Screen Recommended!*");
            Console.WriteLine("Press L to load the last save");
            Console.WriteLine("Press Enter to start a New Game...");
            Console.Write("");
            string choice = Console.ReadLine().ToLower();
            if (choice.Equals("l"))
            {
                save.Load();
            }
            else
            {
                Scene1(player, checkpoint);
            }
        }
        public static void Scene1(Player player, Checkpoint checkpoint)
        {
            Console.Clear();
            JailRags rags = new JailRags();
            player.Equip(rags);
            player.inventory.armor.Add(rags);
            bool chosen = false;
            Console.WriteLine("'What're you doing? What's your name? Do you even remember your own name or have you really gone mad?'");
            Console.Write("");
            player.name = Console.ReadLine();
            Console.WriteLine("'Well, {0}, you've been standing there like I slammed you in the head with a metal bat.'", player.name);
            Console.WriteLine("1. 'Huh? Where am I?'  2. Say nothing");
            do
            {
                Console.Write("");
                string choice = Console.ReadLine();
                if (choice.Equals("1"))
                {
                    chosen = true;
                    Console.WriteLine("'Where do you think you are? Look around, dullard!'");
                    Console.WriteLine("You look to see a grey room around you, with no source of light except for a very small opening on the ceiling that is barred. The room is completely empty and you cant even seem to find a door or another way out.");
                    Console.WriteLine("You: 'Is this some sort of dungeon or something?'");
                }
                else if (choice.Equals("2"))
                {
                    chosen = true;
                    Console.WriteLine("'Where do you think you are? Look around, dullard!.'");
                    Console.WriteLine("1. Look around  2. Stay still");
                    do
                    {
                        Console.Write("");
                        string choice2 = Console.ReadLine();
                        chosen = false;
                        if (choice2.Equals("1"))
                        {
                            chosen = true;
                            Console.WriteLine("You look to see a grey room around you, with no source of light except for a very small opening on the ceiling that is barred. The room is completely empty and you cant even seem to find a door or another way out.");
                            Console.WriteLine("You: 'Is this some sort of dungeon or something?'");
                        }
                        else if (choice2.Equals("2"))
                        {
                            chosen = true;
                            Console.WriteLine("'Are you a statue or something?'");
                            Console.WriteLine("The man slaps you to test that you are alive.");
                            player.health--;
                            Console.WriteLine("The slap stings your face.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Health - 1, your health is now {0}.", player.health);
                            Console.ResetColor();
                            Console.WriteLine("You move from the slap.");
                            Console.WriteLine("'Ah, so you are a real person. Have you gone insane?! Look around'");
                            Console.WriteLine("He grabs your face and forces you to look around.");
                            Console.WriteLine("You look to see a gray room around you, with no source of light except for a very small opening on the ceiling that is barred. The room is completely empty and you cant even seem to find a door or another way out.");
                            Console.WriteLine("You're jail!");
                        }
                        else
                        {
                            Console.WriteLine("That wasn't an option.");
                        }
                    } while (!chosen);
                }
                else
                {
                    Console.WriteLine("That wasn't an option.");
                }
            } while (!chosen);
            Console.ReadLine();
            Jail jail = new Jail();
            SaveSystem save = new SaveSystem();
            checkpoint.SetCheckpoint(checkpoint.checkpoint + 1);
            Console.Clear();
            save.Save(checkpoint, player);
            jail.Start(player);
        }
        public static void GameOver(Player player, Checkpoint checkpoint)
        {
            Console.WriteLine("???: 'So, {0}, that's it. You've died and the story's over. It was your story after all. Awfully boring ending don't you think? Why not make a better one?'", player.name);
            Console.WriteLine("???: 'Press Enter to entertain me a little further'");
            Console.ReadLine();
            Console.Clear();
            switch (checkpoint.checkpoint)
            {
                case 1:
                    Menu(player, checkpoint);
                    break;
                case 2:
                    Jail jail = new Jail();
                    jail.Start(player);
                    break;
                case 3:
                    PrisonGuard guard = new PrisonGuard(true);
                    Control.CombatTutorial(player, guard, checkpoint);
                    break;
                case 4:
                    Jail.Lure(player);
                    break;
                case 5:
                    Jail.Lure(player);
                    break;
            }
        }
    }
}