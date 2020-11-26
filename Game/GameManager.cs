using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MiniDarkSouls3
{
    public class GameManager
    {
        public Field field = LevelEditor.CreateLevel();
        public Player player;
        public GamePrinter gamePrinter;
        bool isRunning = true;
        public void GameInit()
        {
            Field startField = LevelEditor.CreateLevel();
            player = new Player("Solaire", 100, startField);
            
        }

        public bool CheckForLoot(Player player)
        {
            if (player.currentPosition.itemsOnField.Count >= 0)
            {
                return player.hasFoundLoot = true;
            }
            return false;
        }


        public void ClearEnemy(Player player)
        {
 
            
        }
        public void PlayerControl()
        {
            GameManager gameManager = new GameManager();
            GamePrinter gamePrinter = new GamePrinter();
            gamePrinter.PrintGameStatus(player);
            //string move = "[W] MOVE UP\n[S] MOVE DOWN\n[A] MOVE LEFT\n[D] MOVE RIGHT";
            //string action = "[I] CHECK INVENTORY\n[P] PICK UP ITEM\n[M] SHOW MAP\n[F] FIGHT";
            while (isRunning)
            {

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Thread.Sleep(500);
                Console.WriteLine("________________________________________");
                Console.WriteLine("\tCHOOSE YOUR DESTINY");
                Console.WriteLine($"[W] MOVE UP \t\t [P] PICK UP ITEM");
                Console.WriteLine($"[S] MOVE DOWN \t\t [I] INVENTORY");
                Console.WriteLine($"[D] MOVE RIGHT \t\t [F] FIGHT");
                Console.WriteLine($"[A] MOVE LEFT \t\t [M] MAP");
                Console.WriteLine("_________________________________________");
                Console.ResetColor();
                string userControl = Console.ReadLine().ToLower();
                switch (userControl)
                {
                    case "w":
                        player.Move(MovingType.NORTH);
                        Thread.Sleep(300);
                        gamePrinter.PrintGameStatus(player);
                        
                        break;
                    case "s":
                        player.Move(MovingType.SOUTH);
                        Thread.Sleep(300);
                        gamePrinter.PrintGameStatus(player);
                        break;
                    case "a":
                        player.Move(MovingType.WEST);
                        Thread.Sleep(300);
                        gamePrinter.PrintGameStatus(player);

                        break;
                    case "d":
                        player.Move(MovingType.EAST);
                        Thread.Sleep(300);
                        gamePrinter.PrintGameStatus(player);
                        break;
                    case "i":
                        Thread.Sleep(300);
                        gamePrinter.PrintInventory(player);
                        Thread.Sleep(1000);
                        gamePrinter.PrintGameStatus(player);
                        break;
                    case "p":
                        player.PickUpLoot();
                        Thread.Sleep(300);
                        gamePrinter.PrintGameStatus(player);
                        break;
                    case "m":
                        Thread.Sleep(200);
                        gamePrinter.PrintMap(player);
                        Thread.Sleep(1000);
                        gamePrinter.PrintGameStatus(player);
                        break;
                    case "f":
                        Thread.Sleep(200);
                        player.Fight();
                        Thread.Sleep(750);
                        gamePrinter.PrintFight(player);
                        break;
                    default:
                        Console.WriteLine("Incorrect Input.");
                        break;
                }
            }
        }
    }
}
