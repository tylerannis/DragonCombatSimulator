using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonCombatSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Greeting();
            DragonSlayer();
            Console.ReadKey();
        }
        static void DragonSlayer()
        {
            //set the health for both of you
            int yourHealth = 100;
            int dragonHealth = 200;
         
            //you can use a random number generator multiple times for different things, you don't need a new random for every time you want a different set of numbers

           
           
            bool playing = true;
        
            
            //make your attacks
            while (playing)
            {
                //give the user ablitiy to make a decsison
                string input = Console.ReadLine();
                //make a random number generator for chance of hit
                Random hit = new Random();
                int number = hit.Next(0, 101);
                if (dragonHealth > 0)
                {
                    if (hit.Next(0, 101) < 81)
                    {
                        //make a rng for Dragon attack strength
                        int fire = hit.Next(5, 16);
                        yourHealth = yourHealth - fire;
                        Console.WriteLine("The dragon did " + fire + " damage.");
                    }
                    else
                    {
                        Console.WriteLine("That was close better not let it cook you!");
                    }

                if (input == "1")
                {
                    //make random number generator for sword attack strength
                    
                    int sword = hit.Next(20, 36);
                    if (number < 71)
                    {
                        dragonHealth -= sword;
                    
                        Console.WriteLine("Nice attack you did " + sword + " damage. The dragon now has " + dragonHealth + " hp left.");
                        Console.WriteLine("You have " + yourHealth + " hp left.");
                        
                    }
                    else
	                 {
                        Console.WriteLine("You missed, better scurry away");
                        Console.WriteLine("You have " + yourHealth + " hp left.");
	                 }
                }
                else if (input == "2")
                {
                    //make rng for magic attack strength
                    
                    int mage = hit.Next(10, 16);
                    dragonHealth -= mage;
                  
                    Console.WriteLine("The magic takes an effect of " + mage + " damage. The dragons health is now " + dragonHealth);
                    Console.WriteLine("You have " + yourHealth + " hp left.");
                }
                else  if (input == "3")
                {
                    //make random number generator for healing
                   
                    int heal = hit.Next(10, 21);
                    yourHealth += heal;
                
                    Console.WriteLine("You're still alive! Your health went up by " + heal + " !");
                    Console.WriteLine("You have " + yourHealth + " left.");
                }
                else
                {
                    Console.WriteLine("You don't have that attack! You are just dying!");
                }
                                
                }
                else
                {
                    playing = false;
                    Console.WriteLine("You got lucky and slew the dragon");
                }
           
               
                if (yourHealth <= 0)
                {
                    playing = false;
                    Console.WriteLine("As expected, the dragon had you for dinner");
                }
              

            }
            AddHighScore(yourHealth);
            DisplayHighScore();
        }
        static void Greeting()
        {       
            Console.WriteLine("HALT!! Who dares approach the dungeon?");
            Console.WriteLine("<<enter name>> to skip story and get controls for game look for these <<  >>");
            string name = Console.ReadLine();
            Console.WriteLine("So " + name + " you think you have what it takes to make it through the dungeon\n And defeat the dragon? If so... you are stronger than I was before I tried and failed. My name is Harold and I will guide you as much as I can, I have faith in you " + name + " What are your attacks? .....You don't know!? You must have been hit with a memory spell earlier.\n\nWell from the looks of it you have a sword. <Swords are strong but they only hit 70% of the time. <<You can accsess your sword attack by pressing 1.>>\n\nDo feel that? It's magic... You must be part warlock! \n<Magic is really useful, it never misses it's target, but being half warlock \nyour spells won't be as effective. <<You can use magic by pressing 2.>> \n\nIt looks like you are a smart enough warrior to bring some healing potions, they seem pretty standard so they'll heal you 10 points. You only have 10 right now but you might find some in the dugeon.<<use potions to get 10 health back by \npressing 3>> \n\nYou can dodge attacks but if you do that you lose a turn.\n<<You can dodge by pressing 4.>>");
            Console.WriteLine("\n\nWell, " + name + " let's get started.");
            Console.WriteLine("<<Press enter to start the game>>");
            Console.ReadLine();
        }
        static void AddHighScore(int playerScore)
        {
            Console.WriteLine("Your Name: ");
            string playerName = Console.ReadLine();

            //Create connection to database
            TylerEntities db = new TylerEntities();

            //New HighScore Object must create new instance of an Object
            HighScore newHighScore = new HighScore();
            //populate the object
            newHighScore.Date = DateTime.Now;
            newHighScore.Game = "Dragon Slayer1";
            newHighScore.PlayerName = playerName;
            newHighScore.Score = playerScore;

            //add it to the database
            db.HighScores.Add(newHighScore);
            //now it's set up but not in the database yet
            //Nothing happens until you save
            db.SaveChanges();

        }
        static void DisplayHighScore()
        {
            //clear the console
            Console.Clear();
            //Write the High Score Text
            
            Console.WriteLine("============================= DRAGON SLAYER HIGH SCORE =============================");
            
            //create a new connection to the database
            TylerEntities db = new TylerEntities();

            //get the HS list
            List<HighScore> highScoreList = db.HighScores.Where(x => x.Game == "Dragon Slayer1").OrderByDescending(x => x.Score).Take(10).ToList();
            
            foreach (HighScore highScore in highScoreList)
            {
                Console.WriteLine("{0}, {1} - {2}", highScoreList.IndexOf(highScore) + 1, highScore.PlayerName, highScore.Score);
            }
            

        }
    }
}
