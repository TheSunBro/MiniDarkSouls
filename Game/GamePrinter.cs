using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MiniDarkSouls3
{
    public class GamePrinter
    {
        public GameManager gameManager = new GameManager();
        public Player player;
        public Enemy enemy;

        public void PrintGameStatus(Player player)
        {
            Console.WriteLine(player.StringOfPosition());
            Console.WriteLine(player.GetStats());
            gameManager.CheckForLoot(player);
            LootNotification(player);
            
            
            
            if (player.equippedItem != null)
            {
                Console.WriteLine($"Eqipped Item: {player.equippedItem}");
            }
            if (player.hasFoundEnemy)
            {
                Console.WriteLine($"{player.currentPosition.enemy} wants to fight {player} in {player.currentPosition} ");
            }
        }

        public void LootNotification(Player player)
        {
            if (player.hasFoundLoot)
            {
                foreach (Item item in player.currentPosition.itemsOnField)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Thread.Sleep(750);
                    Console.WriteLine("\t\\[T]/");
                    Thread.Sleep(1000);
                    Console.ResetColor();
                    Console.WriteLine($"Here lies {item}");
                    Console.WriteLine(item.pic);
                }
            }
        }

        public void PrintFight(Player player)
        {
            if (player.isFighting)
            {
                Console.WriteLine($"{player} VS {player.currentPosition.enemy} in {player.currentPosition}");
                switch (player.currentPosition.enemy.hasHitPlayer)
                {
                    case true:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{player.currentPosition.enemy} hit {player}. It did {player.currentPosition.enemy.attackRating} damage");
                        Console.ResetColor();
                        Console.WriteLine($"{player} has {player.currentHealth}/{player.maxHealthPoints} HP");
                        break;
                    case false:
                        Console.WriteLine($"{player} Blocked {player.currentPosition.enemy}´s Attack");
                        break;
                }
                switch (player.hasHitEnemy)
                {
                    case true:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{player} hit {player.currentPosition.enemy}. It did {(player.equippedItem as Weapon).damage + player.strenght} damage");
                        Console.ResetColor();
                        player.currentPosition.enemy.currentHealthPoints = player.currentPosition.enemy.currentHealthPoints < 0 ? 0 : player.currentPosition.enemy.currentHealthPoints;
                        Console.WriteLine($"{player.currentPosition.enemy} has {player.currentPosition.enemy.currentHealthPoints}/{player.currentPosition.enemy.maxHealthPoints} HP");

                        break;
                    case false:
                        Console.WriteLine($"{player.currentPosition.enemy} blocked {player}´s Attack");
                        break;
                }
                EndOfFight(player);

             
            }
        }

        public void EndOfFight(Player player)
        {
            Enemy enemy = player.currentPosition.enemy;
            if (enemy.currentHealthPoints <= 0)
            {
                player.hasFoundEnemy = false;
                player.isFighting = false;
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(750);
                Console.WriteLine("\t\\[T]/");
                Thread.Sleep(1000);
                Console.ResetColor();
                Console.WriteLine($"{player} has defeated {enemy}");
                enemy.DropItem(player);                                  
                enemy.DropSouls(player);
                gameManager.CheckForLoot(player);
                Console.WriteLine($"{enemy.droppedSouls} SOULS GAINED");
                player.currentPosition.enemy = null;
                gameManager.CheckForLoot(player);
                LootNotification(player);
                
            }
        }

        public void PrintInventory(Player player)
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("\t ITEMS IN INVENTORY");
            Console.WriteLine(player.GetStats());
            Console.WriteLine();

            if (player.backPack.Count <= 0)
            {

                Console.WriteLine($"{player} HAS NO ITEMS");
            }
            else
            {

                foreach (var item in player.backPack)
                {

                    if (item is Weapon)
                    {
                        Console.WriteLine($"{player.backPack.IndexOf(item) + 1} {item} --> Attack Rating: {(item as Weapon).damage} + {player.strenght}");
                    }
                    else if (item is HealthRegen)
                    {
                        Console.WriteLine($"{player.backPack.IndexOf(item) + 1} {item}  --> Health Gain: {(item as HealthRegen).healthGain}");
                    }
                    else
                    {
                        Console.WriteLine($"{player.backPack.IndexOf(item) + 1} {item}");
                    }
                }
                player.UseItemFromInventory();

            }
            Console.WriteLine("---------------------------------------");
        }

        public void PrintMap(Player player)
        {

            if (player.currentPosition.west != null)
            {
                Console.WriteLine($"\tLEFT IS {player.currentPosition.west}");
            }
            //else
            //{
            //    Console.WriteLine("\tON LEFT IS NOTHING");
            //}
            if (player.currentPosition.east != null)
            {
                Console.WriteLine($"\tRIGHT IS {player.currentPosition.east}");
            }
            //else
            //{
            //    Console.WriteLine("\tON RIGHT IS NOTHING");
            //}
            if (player.currentPosition.south != null)
            {
                Console.WriteLine($"\tDOWN IS {player.currentPosition.south}");
            }
            //else
            //{
            //    Console.WriteLine("\tBENEATH IS NOTHING");
            //}
            if (player.currentPosition.north != null)
            {
                Console.WriteLine($"\tUP IS {player.currentPosition.north}");
            }
            Console.WriteLine();
            //else
            //{
            //    Console.WriteLine("\tABOVE IS NOTHING");
            //

        }
    }
}
            
            
    

