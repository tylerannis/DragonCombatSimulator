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
            Console.WriteLine("Welcome to DragonSlayer! You will be trying to kill a dragon with 3 different attacks. \nFirst you have your sword which you will attack using the command 1. \nNext is magic which does less damage then your sword but always hits, use command 2 to use magic. \nLast you can heal yourself with the command 3. You start with 100 hp and the dragon will start with 200. Good luck.");
           //call the function
            DragonSlayer();
            Console.ReadKey();
        }
        static void DragonSlayer()
        {
            //set the health for both of you
            int yourHealth = 100;
            int dragonHealth = 200;
         
            
           
           
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

                if (input == "1")
                {
                    //make random number generator for sword attack strength
                    Random strength = new Random();
                    int sword = strength.Next(20, 36);
                    if (number < 71)
                    {
                        dragonHealth -= sword;
                        if (number > 81)
                        {
                            //make a rng for Dragon attack strength
                            Random drag = new Random();
                            int fire = drag.Next(5, 16);
                            yourHealth -= fire;
                            Console.WriteLine("Your health is currently " + yourHealth + " and the dragons health is " + dragonHealth + "!");
                        }
                        Console.WriteLine("Nice attack you did " + sword + " amount of damage. The dragon now has " + dragonHealth + " hp left.");
                        Console.WriteLine("You have " + yourHealth + " left.");
                        
                    }
                    else
	{
                        Console.WriteLine("You missed, better scurry away");
                        Console.WriteLine("You have " + yourHealth + " left.");
	}
                }
                else if (input == "2")
                {
                    //make rng for magic attack strength
                    Random magic = new Random();
                    int mage = magic.Next(10, 16);
                    dragonHealth -= mage;
                    if (number > 81)
                    {
                        //make a rng for Dragon attack strength
                        Random drag = new Random();
                        int fire = drag.Next(5, 16);
                        yourHealth -= fire;
                        Console.WriteLine("Your health is currently " + yourHealth + " and the dragons health is " + dragonHealth + "!");
                    }
                    Console.WriteLine("The magic takes an effect of " + mage + " damage. The dragons health is now " + dragonHealth);
                    Console.WriteLine("You have " + yourHealth + " left.");
                }
                else  if (input == "3")
                {
                    //make random number generator for healing
                    Random health = new Random();
                    int heal = health.Next(10, 21);
                    yourHealth += heal;
                    if (number > 81)
                    {
                        //make a rng for Dragon attack strength
                        Random drag = new Random();
                        int fire = drag.Next(5, 16);
                        yourHealth -= fire;
                        Console.WriteLine("Your health is currently " + yourHealth + " and the dragons health is " + dragonHealth + "!");
                    }
                    Console.WriteLine("You're still alive! Your health went up by " + heal + " !");
                    Console.WriteLine("You have " + yourHealth + " left.");
                }
                
                   
                }
                else
                {
                    playing = false;
                    Console.WriteLine("You got lucky and slew the dragon");
                }
                if (yourHealth == 0)
                {
                    playing = false;
                    Console.WriteLine("As expected, the dragon had you for dinner");
                }

            }
        }
    }
}
