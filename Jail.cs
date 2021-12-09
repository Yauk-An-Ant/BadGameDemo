using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadGame
{
    public class Jail
    {
        private int areaNumber;
        public Jail()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            areaNumber = 2;
        }
        public void Start(Player player)
        {
            Console.Clear();
            Player B = player;
            Checkpoint saver = new Checkpoint();
            saver.SetCheckpoint(areaNumber);
            bool chosen;
            Console.Clear();
            Console.WriteLine("The Jail:");
            Console.WriteLine("'Yeah that's right, this is a cell.'");
            Console.WriteLine("'You just got shoved in here, and then you stood up and stared into space until I just snapped you out of it.'");
            Console.WriteLine("'I'm Monkus by the way.");
            Console.WriteLine("You: 'I don't- I don't remember what happened'");
            Console.WriteLine("Monkus: 'A lot of us don't, it'll come to you eventually.'");
            Console.WriteLine("Monkus: Either way, you came at the perfect time. I had a whole escape plan ready, but it requires two people. My cell has only been me for quite a bit of time now.");
            Console.WriteLine("You stare at him in confusion as you try to orient yourself.");
            Console.WriteLine("Monkus: 'So, will you join me? Trust me, you don't want to know what being in here is like.'");
            Console.WriteLine("1. 'Yes'  2. 'No'");
            do
            {
                Console.Write("");
                string choice = Console.ReadLine();
                chosen = false;
                if(choice.Equals("1"))
                {
                    chosen = true;
                    Console.WriteLine("Monkus: 'Alright, let me tell you what the plan is.'");
                    Console.ReadLine();
                    Plan(player);
                } else if(choice.Equals("2"))
                {
                    Console.WriteLine("Oh, you must be trying to orient yourself. I'll give you some time, you'll probably change your mind anyway.");
                    Console.WriteLine("Hours pass and you have finally come to terms with your surroundings despite not having remembered any of your past. You thought about Monkus' offer and are going to make a decision.");
                    Console.WriteLine("1. 'Hey, I changed my mind.'  2. Do nothing");
                    do
                    {
                        Console.Write("");
                        string choice2 = Console.ReadLine();
                        chosen = false;
                        if(choice2.Equals("1"))
                        {
                            chosen = true;
                            Console.WriteLine("Monkus: 'Alright, let me tell you what the plan is.'");
                            Console.ReadLine();
                            Plan(player);

                        } else if(choice2.Equals("2"))
                        {
                            chosen = true;
                            Console.WriteLine("Monkus doesn't bring it up again and both of you stop talking to each other. You never find an opening, but occaisonally food is shuffled through the bars in the ceiling. You both sit and rot inside the jail cell and eventually die slow and painful deaths.");
                            Program.GameOver(B, saver);
                        }
                    } while (!chosen);
                } else
                {
                    Console.WriteLine("That wasn't an option.");
                }
            } while (!chosen);
        }
        public void Plan(Player player)
        {
            bool understand = false;
            while (!understand)
            {
                bool chosen;
                Console.WriteLine("Monkus: 'The opening on the ceiling, it's only been there for a few years. Before that, they used to give you food through a cage door. The cage door's gotten its hinges removed and has been sealed, but we might be able to pry it open if we find it.'");
                Console.WriteLine("Monkus: 'It's hidden on one of the walls in this room, and I know for a fact that there are other cells in this accursed prison. The plan is, we bust out of this cell, bust some crazy prisoners out of their cells, and start a rampage in this place.'");
                Console.WriteLine("Monkus: 'While the guards are occupied with the rabid lunatics in those cells we make our escape.'");
                Console.WriteLine("Monkus: 'Now while the doors probably take two people to push, I could manage on my own. The real problem comes with the actual escape.'");
                Console.WriteLine("Monkus: 'The main way out of this stupid place is a giant, heavily guarded gate. They're not gonna relax the security on that thing, especially with a rampage going on in here.'");
                Console.WriteLine("Monkus: 'The reason I need two people is because we're either gonna find a blunt object and break the wall down, which would require one person to keep watch, or we're gonna find some sort of door or cut one ourselves which I'd need someone to hold open.'");
                Console.WriteLine("Monkus: 'It's easy to catch us if we're the only two running out of this place, which is why we need at least one of us to direct some of the prisoners toward the escape and have them escape too, while the other plans or scouts ahead, which should lower our chances of being caught immediately after escaping.'");
                Console.WriteLine("Monkus: 'And then we can figure out what to do from there.'");
                Console.WriteLine("Monkus: 'You understand all that, yes or no?'");
                do
                {
                    chosen = false;
                    Console.Write("");
                    string choice = Console.ReadLine().ToLower();
                    if (choice.Equals("yes"))
                    {
                        chosen = true;
                        understand = true;
                        Console.WriteLine("Monkus: 'Then let's get to it!'");
                        Console.ReadLine();
                        CellEscape(player);
                    }
                    else if (choice.Equals("no"))
                    {
                        chosen = true;
                        understand = false;
                    } else
                    {
                        Console.WriteLine("That wasn't an option.");
                    }
                } while (!chosen);
            }
        }
        public void CellEscape(Player player)
        {
            bool chosen;
            Console.WriteLine("Monkus: 'Ok so to search for the door, we need to feel across the walls until we feel a ridge jutting out from the wall.'");
            Console.WriteLine("You: 'Wouldn't it be faster if we split up?'");
            Console.WriteLine("Monkus: 'Exactly what I was thinking. What do you want to take, left or right?'");
            do
            {
                chosen = false;
                Console.Write("");
                string choice = Console.ReadLine().ToLower();
                if(choice.Equals("left"))
                {
                    chosen = true;
                    Console.WriteLine("You: 'I'll take the left.'");
                    Console.WriteLine("Monkus: 'Alright, I'll take the right then.'");
                    Console.WriteLine("You begin to feel across the wall, slowly moving to the left as you do so.");
                    Console.WriteLine("You find that the seemingly uniform gray walls are not smooth at all. The rough surface of the stone walls causes you to scrape your hand.");
                    player.health -= 2;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Health - 2, your health is now {0}.", player.health);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Monkus: 'Hey, {0}! I found it, or at least I think this is it.'", player.name);
                    OpenDoor(player);
                } else if(choice.Equals("right"))
                {
                    chosen = true;
                    Console.WriteLine("You: 'I'll take the right.");
                    Console.WriteLine("Monkus: 'Alright, I'll take the left then.'");
                    Console.WriteLine("You begin to feel across the wall, slowly moving to the right as you do so.");
                    Console.WriteLine("You find that the seemingly uniform gray walls are not smooth at all.");
                    Console.WriteLine("A rough spike coming from the wall cuts your hand. You hold your paining hand as a little blood seeps out, but it is only a minor cut.");
                    player.health -= 5;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Health - 5, your health is now {0}.", player.health);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("You resume searching, but only with your other hand. Eventually you feel a ridge coming out from the wall. You look and see no difference from the rest of the wall, but you can feel the ridge moving down.");
                    Console.WriteLine("You: 'Hey Monkus, I think I found the door!'");
                    OpenDoor(player);
                } else
                {
                    Console.WriteLine("That wasn't an option.");
                }
            } while (!chosen);
        }
        public void OpenDoor(Player player)
        {
            Console.WriteLine("You: 'How the hell are we gonna open this?'");
            Console.WriteLine("Monkus: I managed to get a knife in here through a contact I had a while back. Even cut a space to hide it.");
            Console.WriteLine("He moved to the wall to find this knife that he had been hiding. He removed a section of the stone from the wall, revealing a small socket in which was a shiny, metallic knife.");
            Console.WriteLine("He took it and walked back over to where you are standing.");
            Console.WriteLine("Monkus: 'This thing hasn't been used much, so it's still sharp enough to at least chip stone. The sealing they used isn't actually cement and should be weaker than the rest of the walls.'");
            Console.WriteLine("He grabbed the knife and flipped it in his hand before jamming it into the wall. Sawing through the wall, he cut downward from the top right corner to the bottom of the door.");
            Console.WriteLine("You are surprised that it even got through the wall, and he cuts through the remaining seal.");
            Console.WriteLine("Monkus 'Alright, now we just have to slam into this as hard as we can and hope it breaks free.'");
            Console.WriteLine("He gets ready to charge into the door and you line up with him. He counts down and you both begin to charge.");
            Console.WriteLine("You then have this instinctual thought to stop in your tracks. Do you follow through with the charge?");
            bool chosen;
            do
            {
                chosen = false;
                Console.Write("");
                string choice = Console.ReadLine().ToLower();
                if(choice.Contains("ye"))
                {
                    chosen = true;
                    Console.WriteLine("You both slam shoulder first into the door and it breaks free from the wall, chipping the stone around it.");
                    Console.WriteLine("It falls to the ground leaving a large open space in the wall in its place.");
                    StoneChip chip = new StoneChip();
                    Console.WriteLine("You notice a large stone chip on the ground. You think that perhaps it could be used as a weapon. Do you pick it up?");
                    Console.Write("");
                    string choice2 = Console.ReadLine().ToLower();
                    if(choice2.Equals("yes"))
                    {
                        player.PickUp(chip);
                    }
                    Console.WriteLine("Monkus: 'Come on, lets go'");
                    Console.WriteLine("He gestures for you to follow him and rushes off down the hallway to the left.");
                    Prisoner(player);
                } else if(choice.Contains("no"))
                {
                    chosen = true;
                    Console.WriteLine("You stop just before slamming into the door and Monkus slams into it alone.");
                    Console.WriteLine("The door shakes but does not move. Monkus looks back at you with a confused expression as he delivers a kick to the door.");
                    Console.WriteLine("The door falls to the ground leaving a large open space in the wall in its place.");
                    Console.WriteLine("Monkus 'What were you doing?'");
                    Console.WriteLine("You stand there with not much explanation to give.");
                    Console.WriteLine("Monkus: 'Doesn't matter, we don't have the time. Follow me.");
                    Console.WriteLine("You follow Monkus down the hallway to your left.");
                    Prisoner(player);
                } else
                {
                    Console.WriteLine("That wasn't an option.");
                }
            } while (!chosen);
        }
        public void Prisoner(Player player)
        {
            Console.ReadLine();
            Console.WriteLine("The hallways looked the same as your cell, albeit stretching for a seemingly infinite length.");
            Console.WriteLine("The walls were pure gray with seemingly no methods of escape.");
            Console.WriteLine("Not too far away from your own cell, you see a shallow groove on the wall in the shape of a door. It was apparently visible from the outside.");
            Console.WriteLine("It was surprising that there were no guards around any of these cells.");
            Console.WriteLine("Monkus stopped in front of the door and brought out the knife again.");
            Console.WriteLine("Monkus: 'Alright, so we are going to open as many of these doors as possible and release however many prisoners may remain.'");
            Console.WriteLine("Monkus: 'The problem is we don't know their state of mind so we need to be cautious. This might be the first time they're seeing another human in a while, and so they will probably naturally try to chase us.'");
            Console.WriteLine("Monkus: 'So, as soon as we open this door, I'm gonna step in for a second and then we both run to the next. Hopefully losing them along the way.'");
            Console.WriteLine("He wedges the knife into the seal of the door and begins to cut the door out of the wall in the same way as he had done earlier for their own cell.");
            Console.WriteLine("After he finishes, he steps back and looks at you with what seems like an endearing expression.");
            Console.WriteLine("Monkus: 'Together, now.'");
            Console.ReadLine();
            Console.WriteLine("He counts down from 3 once more and you both begin to charge towards the door and slam into it at once.");
            Console.WriteLine("The door makes a loud noise as it breaks away from the rest of the wall and falls to the ground, revealing a malnourished prisoner inside.");
            Console.WriteLine("Monkus takes one foot inside, witnesses the prisoner, turns around, and tells you to run with the most urgency you have ever heard him express");
            Console.ReadLine();
            Console.WriteLine("Because of his tone of voice, you immediately turn around and begin to bolt in the other direction.");
            Console.WriteLine("Monkus joins you at your side and you sneak a glance behind you due to your curiosity.");
            Console.WriteLine("Behind you, you see the malnourished prisoner on all fours, galloping towards you with a rabid expression on his face.");
            Console.WriteLine("Another prisoner comes out of the door, looking and acting the same as the first, and you turn your head back foward to focus on sprinting away.");
            Console.WriteLine("You: 'Why are they on all fours?!'");
            Console.WriteLine("Monkus: 'I think they reverted to their primal instincts or something, and that for some reason includes them becoming quadrupedal.'");
            Console.WriteLine("You both keep running until you see the next door's cell.");
            Console.ReadLine();
            Console.WriteLine("Monkus: 'Yes I'm going to open that one too.'");
            Console.WriteLine("You: 'How in the world are we gonna deal with those strange things chasing us then?!'");
            Console.WriteLine("Monkus: 'Look at them, they're probably dumb enough to chase you in a circle, so lure them away somehow! Unless you want to cut open the door?'");
            Console.WriteLine("1. 'I'll take that over being chased by rabid prisoners!'  2. *Look back* 'You're probably right, I'll figure something out.'");
            bool chosen;
            do
            {

                chosen = false;
                Console.Write("");
                string choice = Console.ReadLine().ToLower();
                if(choice.Equals("1"))
                {
                    Console.WriteLine("Monkus: Suit yourself.");
                    Console.WriteLine("He hands you the knife and you notice tiny granules of the sealing material they used stuck all over his hands and arm.");
                    Console.WriteLine("You take it from him and run over to the door. You thrust the knife through the indents around the door and see a little spray of the sealing material.");
                    Console.WriteLine("You begin to make a cut down the side of the door and the sealing material begins to spray towards you.");
                    Console.WriteLine("It hits your hands, arms, and face and a little ends up getting in your eye.");
                    player.health -= 1;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Health - 1, your health is now {0}.", player.health);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("You look behind you to see that Monkus' suggestion had actually worked.");
                    Console.WriteLine("He had been running in circles and the prisoners were actually chasing him in those circles.");
                    Console.WriteLine("You: 'I finished it!'");
                    Console.WriteLine("Monkus gives you a thumbs up and turns in your direction. You start running and join him as you both slam into the door.");
                    Console.WriteLine("You both run through the opening and make a large circle within the room and run back outside, the prisoners in the cell joining the mob chasing you.");
                    Console.WriteLine("You think about the spraying sealant and ponder whether you should hand the knife back to Monkus. Do you do so?");
                    do
                    {
                        Console.Write("");
                        choice = Console.ReadLine().ToLower();
                        if(choice.Contains("ye"))
                        {
                            chosen = true;
                            Console.WriteLine("You hand the knife back to Monkus and tell him to do the cutting.");
                            Console.WriteLine("Monkus: 'I knew you'd like this job better.'");
                            Console.WriteLine("You both move down the hallway, cutting down the doors as you go.");
                            Console.WriteLine("Every time Monkus goes to cut down a door, you run in a circle which the prisoners never seem to catch onto.");
                            Console.WriteLine("The circle increases in size each time, just as the mob does. Eventually the mob consists of every prisoner in the hallway save one cell and you near the end.");
                        } else if(choice.Contains("n"))
                        {
                            chosen = true;
                            Console.WriteLine("You both continue down the hallway, Monkus luring away the mob of prisoners, and you cutting down the doors.");
                            Console.WriteLine("Each time you cut down a door, the sealant sprays at you, which causes you to sustain more total pain than you expected.");
                            player.health -= 6;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Health - 6, your health is now {0}.", player.health);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("Eventually you near the end of the hallway and the mob following you both becomes quite large.");
                            Console.WriteLine("You want to open the final cell but decide that it is best to not get any more sealant in your eye and hand the knife back to Monkus");
                            Console.WriteLine("You: 'Can you do the last one?'");
                            Console.WriteLine("Monkus: 'Huh? You want me to do it now, just for the last one? Alright then, but you'll take my job.'");
                        } else
                        {
                            chosen = false;
                            Console.WriteLine("That wasn't an option.");
                        }
                    } while (!chosen);
                    Hallway(player);
                }
                else if(choice.Equals("2"))
                {
                    chosen = true;
                    Console.WriteLine("You follow through with Monkus' suggestion and run in a circle. The prisoners follow you and never think of cutting through the circle.");
                    Console.WriteLine("Monkus declares that he finished and you both run into the door together. You continue running as the mob of prisoners is still chasing you.");
                    Console.WriteLine("Monkus runs with you and you both make one large circle before exiting the room the way you came, more prisoners having joined the mob.");
                    Console.WriteLine("You move down the hallway, the size of your circles increasing as the size of the mob increases. They never catch on and continue to blindly chase you in a circle.");
                    Console.WriteLine("After releasing the prisoners of many cells, the hallway reached its end, and only one door remained.");
                    Hallway(player);
                } else
                {
                    chosen = false;
                    Console.WriteLine("That wasn't an option.");
                }
            }while(!chosen); 
        }
        public void Hallway(Player player)
        {
            Console.ReadLine();
            Console.WriteLine("Monkus moves over to open the final door and begins to cut it open.");
            Console.WriteLine("You begin to turn to start your circle, but you witness what looks like a guard round the corner.");
            Console.WriteLine("You turn anyway, but the mob behind you moves past you entirely and moves to attack the guard.");
            Console.WriteLine("Monkus yells that he has finished once more and you snap out of your pondering and join him as he slams the final door.");
            Console.WriteLine("This one on the other hand does not move very much.");
            Console.WriteLine("Monkus: 'Let me just give it a kick.'");
            Console.WriteLine("Monkus kicks the door which causes it to open and let his foot in.");
            Console.WriteLine("It doesn't open any more than that though and Monkus seems to have gotten his foot stuck in the door.");
            Console.WriteLine("You had been watching the guard, who had brought out a wooden sword to try and stop the prisoners from injuring him.");
            Console.WriteLine("He beats a few of them unconsious and does get hurt from their attack. The prisoners then all change their focus to something else, most likely another guard, and run down to the right.");
            Console.WriteLine("You hear the guard mumble quietly,");
            Console.WriteLine("Guard: 'Eh, I'll let them take care of that.'");
            Console.ReadLine();
            Console.WriteLine("The guard then turns his attention to you as Monkus desperately tries to get his foot out from being wedged between the door and the wall.");
            Console.WriteLine("Guard:'Now who are you two? Wait are you the new guy?!'");
            Console.WriteLine("He mumbles again,");
            Console.WriteLine("Guard: 'I can't be letting this one get away.'");
            Console.WriteLine("Monkus: 'Due to my... situation, I'm gonna have to let you take care of this one!'");
            Console.WriteLine("The guard begins to charge at you, sword raised in the air.");
            Console.WriteLine("You clench your fist and get ready to take him on. You can't remember why, but you feel like you've won against far greater odds before.");
            PrisonGuard guard = new PrisonGuard(true);
            Checkpoint checkpoint = new Checkpoint();
            checkpoint.SetCheckpoint(3);
            SaveSystem save = new SaveSystem();
            Console.ReadLine();
            save.Save(checkpoint, player);
            Control.CombatTutorial(player, guard, checkpoint);
        }
        public static void Lure(Player player)
        {
            Console.WriteLine("You were so caught up in the heat of battle that you did not even question the voice.");
            Console.WriteLine("You now ponder what the voice could have been, but are interuppted by Monkus shouting for you to help him.");
            Console.WriteLine("You had completely forgotten about how Monkus had gotten stuck.");
            Console.WriteLine("Monkus: 'Yeah, you beat him, and now we're safe for a little bit, SO WHY DON'T YOU COME HELP ME OUT HERE!'");
            Console.ReadLine();
            Console.WriteLine("You walk over to the door and begin to kick it from the side in which Monkus' foot is stuck.");
            Console.WriteLine("Eventually, it comes loose and you both push the door down. Monkus holds his foot in pain for a few seconds but he seems to be entirely healed immediately after.");
            Console.ReadLine();
            Console.WriteLine("Then, you see the last two prisoners of the hallway running at you. You had forgotten about the prisoners and are in shock for a second, but Monkus pulls you, causing you to snap out of it.");
            Console.WriteLine("You: 'What's the plan now?'");
            Console.WriteLine("Monkus: 'Well the prisoners here are already loose throughout the place, now we just have to shake these two off and find our escape method.'");
            Console.WriteLine("You: 'I don't think those things'll be letting off.'");
            Console.WriteLine("Monkus: 'Well, the others went right and so did we, so let's assume there are more guards this way. We find one, let these two go after them, and run away. Simple.'");
            Console.ReadLine();
            Console.WriteLine("You both turn to the right and continue running. At the end of the hallway you spot a guard and a group of released prisoners.");
            Console.WriteLine("Monkus motions for you to swerve from the side and you both get out of the way for the prisoners behind you to join the group.");
            Console.WriteLine("Monkus: 'Let's go back the way we came, and the other way from there.'");
            Console.WriteLine("You are a little more relaxed, now that you are not being chased by a bunch of rabid prisoners. Still, you feel a sense of urgency, as if slow movement could cause the plan to fail, and after seeing the other prisoners, you certainly don't want to remain here.");
            Console.ReadLine();
            Console.WriteLine("You make it to a crossroads at the other end of the hallway.");
            Console.WriteLine("Monkus: 'If I remember this place correctly, which I'm not sure I do, either side should lead us to somewhere we might be able to escape, so you pick.'");
            Console.WriteLine("1. Left  2. Right");
            bool chosen = false;
            do
            {
                Console.Write("");
                string choice = Console.ReadLine().ToLower();
                if (choice.Equals("1"))
                {
                    chosen = true;
                    Console.WriteLine("You turn to the left and Monkus follows you.");
                    Console.WriteLine("You jog on for a bit before seeing the massive gate Monkus had talked about. There was no way you were getting through that.");
                    Console.WriteLine("The thing had to be at least 50 feet tall, the front filled with ornate designs, in a huge contrast to the drab, gray rest of the area.");
                    Console.WriteLine("There were guards everywhere, it was almost as if they had concentrated their entire force here, considering how empty the halls were.");
                    Console.WriteLine("Multiple floors of enforcement, platforms high upon the gate from which the guards watched every move. Not that anything extraordinary happened here, except for today.");
                    Console.WriteLine("You turn to Monkus to tell him to turn back but you notice something from the corner of your eye.");
                    Console.WriteLine("A giant guard towers over you, an angry expression on his face. The guard holds a giant club, that looks like it was made out of some sort of metal or stone.");
                    Console.WriteLine("You look back to see the gate and realize there is nowhere to flee.");
                    PrisonGuard guard = new PrisonGuard(false);
                    Checkpoint checkpoint = new Checkpoint();
                    checkpoint.SetCheckpoint(4);
                    Control.Combat(player, guard, checkpoint, ConsoleColor.Black);
                    WallBreak(player);
                }
                else if (choice.Equals("2"))
                {
                    chosen = true;
                    Console.WriteLine("You choose right and you go down the hallway to your right.");
                    Console.WriteLine("Monkus stops walking randomly and begins to stare at the wall.");
                    Console.WriteLine("Monkus: 'I rememeber now. That line.'");
                    Console.WriteLine("You look at the wall and notice a very thin line running across the middle for only a short stretch.");
                    Console.WriteLine("Monkus: 'When they brought me in here, there was something past this wall. Light... not artificial light but real, natural light.'");
                    Console.WriteLine("Monkus: 'The guard tried to shield my eyes but I saw the light and the line. I think this is a way out. A door that slides up.'");
                    Console.ReadLine();
                    Console.WriteLine("You then realize you never asked about Monkus' past or reasons for being here. It had just never come to mind.");
                    Console.WriteLine("You open your mouth to pose the question, but just as you do, you hear a guard call out from behind you.");
                    Console.WriteLine("Guard: 'You two! I'll at least get you two! Before we all die from the rampage of those beasts I will end in glory!'");
                    PrisonGuard guard = new PrisonGuard();
                    Checkpoint checkpoint = new Checkpoint();
                    checkpoint.SetCheckpoint(5);
                    Control.Combat(player, guard, checkpoint, ConsoleColor.Black);
                    EscapeDoor(player);
                }
                else
                {
                    Control.ExtraChoices(player, choice, ConsoleColor.Black);
                }
            } while (!chosen);
        }
        public static void EscapeDoor(Player player)
        {
            Console.WriteLine("Monkus: 'Alright, now that we've taken care of that. We can finally finish this.'");
            Console.WriteLine("Monkus brought out the knife again and slid it under the bottom of the wall where the line was.");
            Console.WriteLine("He wedged it up a bit with the knife, just enough to get fingers under it.");
            Console.WriteLine("Monkus: 'Hey, come over and lift this up with me.'");
            Console.ReadLine();
            Console.WriteLine("You put your hands under the door and begin to try and lift it up.");
            Console.WriteLine("Monkus adds his force to it and it slowly rises up from the bottom to where the line is, leaving an opening large enough for someone to walk through.");
            Console.WriteLine("The light blazed through, and it was tempting, but there was still one step of the plan left.");
            Console.WriteLine("Monkus: 'Can you- Oh, right. Actually, I'll do it. Stay here and hold this door up, be ready to run when I get back.'");
            Console.ReadLine();
            Console.WriteLine("You wait for a little while and see Monkus rounding the corner, with a whole host of prisoners running at his back.");
            Console.WriteLine("He points to the side, eyes widened, telling you to move to the side.");
            Console.WriteLine("He rushes out, the prisoners following him, but just before he left he said,");
            Console.WriteLine("Monkus: 'Hold it for a second or two more, then run like the wind, find me somewhere near the front of the crowd.'");
            Console.WriteLine("You watch as the prisoners completely ignore you, running like the madmen they are for the taste of freedom.");
            Console.WriteLine("You let go of the door and begin to run out, not looking back.");
            Console.ReadLine();
            End(player);
        }
        public static void WallBreak(Player player)
        {
            Console.WriteLine("Monkus: 'If you didn't already take that massive bludgeon, I will.'");
            Console.WriteLine("Monkus: 'It's perfect, we go back a bit and smash the wall open and use it to leave.'");
            Console.WriteLine("You do exactly that, and take the bludgeon, and hit the wall. After a few hits, it started to crack, and eventually break open. You just had to hope no one had heard.");
            Console.WriteLine("The light from the opening blazed through, and it was tempting, but there was still one step of the plan left.");
            Console.WriteLine("Monkus told you to follow him and he led you back where you had came, but down a different turn this time.");
            Console.WriteLine("You: 'Where are we going?'");
            Console.WriteLine("Monkus: You'll see, {0}, you'll see.", player.name);
            Console.WriteLine("You both ran out into an intersection to see almost all of the prisoners running towards you.");
            Console.WriteLine("Monkus: 'I knew they'd head for the gate.'");
            Console.ReadLine();
            Console.WriteLine("You run back the way you had came back to the opening, the prisoners chasing you along the way.");
            Console.WriteLine("Monkus: 'Alright, we're going to run out there, and hide in the crowd for a bit.'");
            Console.WriteLine("You run through the opening you had created, the wave of light running over you, and the crowd of prisoners following behind.");
            Console.ReadLine();
            End(player);
        }
        public static void End(Player player)
        {
            Console.WriteLine("You bathed in the daylight, and kept running, finding Monkus in the crowd and continuing forward.");
            Console.WriteLine("You could hear the sounds of guard rushing out to stop you and the other prisoners, but they were too late, you had already won.");
            Console.WriteLine("You only look forward now, wondering what could happen in those vast sand plains that lie ahead.");
            Console.ReadLine();
            DemoEnd(player);
        }
        public static void DemoEnd(Player player)
        {
            Console.WriteLine("???: 'So, {0}, looks like you got to the end of the demo.'", player.name);
            Console.WriteLine("???: 'This is the demo if you haven't realized yet.'");
            Console.WriteLine("???: 'I did get to see you again sooner than I expected, but I'm afraid this visit will be brief.'");
            Console.WriteLine("???: 'Well, it's called BadGame and all, so you probably didn't like it, but on the off chance that you did... well, I guess you'll just have to wait for a little more.'");
            Console.WriteLine("???: 'Hopefully this won't be the end.'");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}