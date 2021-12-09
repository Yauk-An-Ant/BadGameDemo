using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BadGame
{
    public class SaveSystem
    {
        public void Save(Checkpoint check, Player player)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Player));
            XmlSerializer checkSerializer = new XmlSerializer(typeof(Checkpoint));
            FileStream playerfile = new FileStream("PlayerSave.xml", FileMode.Create);
            FileStream checkfile = new FileStream("Check.xml", FileMode.Create);
            TextWriter writer = new StreamWriter(playerfile, new UTF8Encoding());
            TextWriter checkWriter = new StreamWriter(checkfile, new UTF8Encoding());
            Console.Clear();
            Console.WriteLine("Saving your game...");
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("Saving your game..");
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("Saving your game...");
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("Saving your game..");
            System.Threading.Thread.Sleep(200);
            Console.Clear();
            Console.WriteLine("Saving your game...");
            System.Threading.Thread.Sleep(500);
            Console.Clear();
            serializer.Serialize(writer, player);
            checkSerializer.Serialize(checkWriter, check);
            writer.Flush();
            checkWriter.Flush();
            writer.Close();
            checkWriter.Close();
            playerfile.Close();
            playerfile.Dispose();
            checkfile.Close();
            checkfile.Dispose();
        }
        public void Load()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Player));
                XmlSerializer checkSerializer = new XmlSerializer(typeof(Checkpoint));
                FileStream playerfile = new FileStream("PlayerSave.xml", FileMode.Open);
                FileStream checkfile = new FileStream("Check.xml", FileMode.Open);
                TextReader reader = new StreamReader(playerfile);
                TextReader checkReader = new StreamReader(checkfile);
                Player player;
                Checkpoint checkpoint;
                Console.Clear();
                Console.WriteLine("Loading your save...");
                System.Threading.Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("Loading your save...");
                System.Threading.Thread.Sleep(200);
                Console.Clear(); 
                Console.WriteLine("Loading your save...");
                System.Threading.Thread.Sleep(200);
                Console.Clear(); 
                Console.WriteLine("Loading your save...");
                System.Threading.Thread.Sleep(200);
                Console.Clear(); 
                Console.WriteLine("Loading your save...");
                System.Threading.Thread.Sleep(200);
                Console.Clear();
                player = (Player)serializer.Deserialize(reader);
                checkpoint = (Checkpoint)checkSerializer.Deserialize(checkReader);
                reader.Close();
                checkReader.Close();
                playerfile.Close();
                checkfile.Close();
                switch (checkpoint.checkpoint)
                {
                    case 1:
                        Program.Scene1(player, checkpoint);
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
                        Jail.WallBreak(player);
                        break;
                    case 6:
                        Jail.EscapeDoor(player);
                        break;
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Trying to load a save that doesn't exist? Should've known that wouldn't work.");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }
    }
}
