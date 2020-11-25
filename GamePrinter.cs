using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MiniDarkSouls3
{
    public class GamePrinter
    {
        public Player player;

        public void PrintGameStatus(Player player)
        {
            Console.WriteLine($"{player} is in {player.currentPosition}\nHP: {player.currentHealth}/{player.maxHealthPoints}");
            Console.WriteLine($"Amount of SOULS: {player.amountOfSouls}");
            Console.WriteLine($"Strenght: {player.strenght}");
            if (player.currentPosition is BonFire)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(750);
                Console.WriteLine("\t\\[T]/");
                Thread.Sleep(1000);
                Console.ResetColor();
                Console.WriteLine($"PRAISE THE SUN! {player} is BONFIRE");
            }
            if (player.equippedItem != null)
            {
                Console.WriteLine($"Eqipped Item: {player.equippedItem}");
            }
            if (player.currentPosition.itemsOnField.Count >= 0)
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
            if (player.hasFoundEnemy)
            {
                Console.WriteLine($"{player.currentPosition.enemy} is attacking {player} in {player.currentPosition} ");
            }
        }

        public void PrintFight(Player player)
        {
            if (player.isFighting)
            {
                Console.WriteLine($"{player} is fighting {player.currentPosition.enemy} in {player.currentPosition}");
                switch (player.currentPosition.enemy.hasHitPlayer)
                {
                    case true:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{player.currentPosition.enemy} hit {player}. It did {player.currentPosition.enemy.attackRating} damage");
                        Console.ResetColor();
                        Console.WriteLine($"{player} has {player.currentHealth}/{player.maxHealthPoints} HP");
                        break;
                    case false:
                        Console.WriteLine($"Blocked {player.currentPosition.enemy} Attack by {player}");
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
                if (player.currentPosition.enemy.currentHealthPoints <= 0)
                {
                    
                    player.hasFoundEnemy = false;
                    player.isFighting = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Thread.Sleep(750);
                    Console.WriteLine("\t\\[T]/");
                    Thread.Sleep(1000);
                    Console.ResetColor();
                    Console.WriteLine($"{player} has defeated {player.currentPosition.enemy}");
                    Console.WriteLine($"{player.currentPosition.enemy.droppedSouls} SOULS GAINED from this fight");
                    player.currentPosition.enemy = null;

                }
            }
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
                Console.WriteLine($"\tUP IS {player.currentPosition.south}");
            }
            //else
            //{
            //    Console.WriteLine("\tBENEATH IS NOTHING");
            //}
            if (player.currentPosition.north != null)
            {
                Console.WriteLine($"\tDOWN IS {player.currentPosition.north}");
            }
            Console.WriteLine();
            //else
            //{
            //    Console.WriteLine("\tABOVE IS NOTHING");
            //

        }
    }
}
            
            
    

