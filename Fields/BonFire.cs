using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MiniDarkSouls3
{
    public class BonFire : Field, IEnter
    {
        public int healthIncreace = 30;
        public int costPerLevelUp = 1000;
        public int levelUpModifikator = 100;
        public BonFire(string name) : base(name)
        {
            
        }

        public Field Enter()
        {
            return this;
        }
        public void Levelup(Player player)
        {
            BonfireNotification(player);
            RestoreHealth(player);
            GiveFreeLevel(player);
            
            
            Console.WriteLine("Press ENTER to LEVEL UP FOR SOULS");
            Console.ReadLine();
            Console.WriteLine(player.GetStats());
            while (player.amountOfSouls >= costPerLevelUp)
            {
                Console.WriteLine("Press ENTER to LEVEL UP FOR SOULS");
                Console.WriteLine($"Level Up takes {costPerLevelUp} Souls");
                Console.ReadLine();
                player.strenght++;
                player.currentHealth += healthIncreace;
                player.amountOfSouls -= costPerLevelUp;
                player.maxHealthPoints = player.currentHealth;
                Console.WriteLine(player.GetStats());
                if (player.amountOfSouls > costPerLevelUp)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NOT ENOUGH SOULS");
                    Console.ResetColor();
                }
            }
            
            ////else
            //{
            //    for (int i = costPerLevelUp; i <= player.amountOfSouls; levelUpModifikator += costPerLevelUp)
            //    {

            //    }
            //}


        }

        public void BonfireNotification(Player player)
        {

            if (player.GetPosition() is BonFire)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(750);
                Console.WriteLine("\t\\[T]/");
                Thread.Sleep(1000);
                Console.ResetColor();
                Console.WriteLine($"PRAISE THE SUN! {player} is resting at BONFIRE");
                Console.WriteLine($"FREE Level UP and FUll Health Regain");
            }
        }

        public void RestoreHealth(Player player)
        {
            player.currentHealth = player.maxHealthPoints;
        }

        public void GiveFreeLevel(Player player)
        {
            int howOften = 1;
            while (howOften < 0)
            {
                player.strenght++;
                howOften--;
            }
        }
    }
    

}
