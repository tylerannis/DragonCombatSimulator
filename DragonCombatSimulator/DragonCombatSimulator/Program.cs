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
            Console.WriteLine("Welcome to DragonSlayer! You will be trying to kill a dragon with 3 different attacks. \nFirst you have your sword which you will attack using the command 1. \nNext is magic which does less damage then your sword but always hits, use command 2 to use magic. \nLast you can heal yourself with the command 3. You start with 100 hp and the dragon will start with 200. Good luck.\nYou just entered the layer and the dragon attacks! Begin by pressing: 1, 2, or 3");
           //call the function
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
        }
    }
}
