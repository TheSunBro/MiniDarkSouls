using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MiniDarkSouls3
{
    public class Player
    {
        public double attackModifikator = 1;
        public int strenght = 1;
        public int amountOfSouls = 0;
        public bool hasHitEnemy = false;
        public bool isAlive = true;
        public string name;
        public int stamina;
        public int maxHealthPoints;
        public int currentHealth;
        public bool hasFoundEnemy = false;
        public bool hasFoundLoot = false;
        public Field currentPosition;
        public Item equippedItem;
        public bool canSwim = false;
        public bool isFighting = false;
        public List<Item> backPack = new List<Item>();

        public Player(string name, int maxHealthPoints, Field startPosition)
        {
            this.name = name;
            this.maxHealthPoints = maxHealthPoints;
            this.currentHealth = maxHealthPoints;
            this.currentPosition = startPosition;
        }

        public string StringOfPosition()
        {
            string position = $"{name} is in {this.currentPosition}";
            return position;
        }

        
        public string GetStats()
        {
            string stats = ($"SOULS : {this.amountOfSouls}\tSTRENGHT: {this.strenght}\t{this.currentHealth}/{maxHealthPoints} HP");
            Console.WriteLine();
            return stats;
        }
        
        public bool Move(MovingType direction)
        {
            Field fieldInMovingDirection = currentPosition.GetFieldInDirection(direction);
            if (fieldInMovingDirection != null)
            {
                if (fieldInMovingDirection is OpenWater)
                {
                    LifeDrain();
                }
                if (fieldInMovingDirection is Door)
                {
                    this.OpenDoor(fieldInMovingDirection as Door);
                    
                }
                
                Field fieldToMoveTo = (fieldInMovingDirection as IEnter).Enter();
                if (fieldToMoveTo != null)
                {
                    this.currentPosition = fieldToMoveTo;
                    if (fieldInMovingDirection is BonFire)
                    {
                        
                        (this.currentPosition as BonFire).Levelup(this);
                    }

                    isFighting = false;
                    ScanForEnemy();
                    return true;
                }
            }
            return false;
        }

        public void Fight()
        {
            if (!hasFoundEnemy)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Enemy to Fight");
                Console.ResetColor();
            }
            if (hasFoundEnemy && (equippedItem is Weapon) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{name} has no equipped Weapon.");
                Console.ResetColor();
            }
            if (hasFoundEnemy && equippedItem is Weapon && equippedItem != null)
            {
                isFighting = true;
                GetHitDetection();
                TellEnemyToFight();
                

                if (hasHitEnemy)
                {
                    DoDamage();
                }
            }
        }

        private void DoDamage()
        {
            currentPosition.enemy.currentHealthPoints -= (this.equippedItem as Weapon).damage + strenght;
            //currentPosition.enemy.DropItem(this);
            //currentPosition.enemy.DropSouls(this);
        }

        public Field GetPosition()
        {
            return this.currentPosition;
        }

        private void TellEnemyToFight()
        {
            currentPosition.enemy.Fight(this);
        }

        public void PickUpLoot()
        {
            if (currentPosition.itemsOnField.Count <= 0)
            {
                Console.WriteLine("No Item to Pick up");
            }
            else
            {
                backPack.AddRange(currentPosition.itemsOnField);
                foreach (var item in currentPosition.itemsOnField)
                {
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"---------> {item.name} added to Inventory");
                    Console.ResetColor();
                }
                currentPosition.itemsOnField.Clear();
            }
        }

        public void LifeDrain()
        {
            int drainPerMove = 10;
            currentHealth -= drainPerMove;
        }

        public Item GetItemFromID(int userInput)
        {
            while (userInput <= backPack.Count)
            {
                return backPack[userInput - 1];
            }
            return null;
            
        }

        public void UseItemFromInventory()
        {
            Console.WriteLine();
            Console.WriteLine("Choose Your ITEM");
            try
            {
                Item chosenItem = GetItemFromID(int.Parse(Console.ReadLine()));
                GetItemFromUser(chosenItem);
            }
            catch (SystemException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No item chosen", ex);
                Console.ResetColor();
            }
        }

        public void GetItemFromUser(Item chosenItem)
        {
            if (chosenItem is IUseable)
            {
                (chosenItem as IUseable).Use(this);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{name} has equipped {chosenItem}");
                Console.ResetColor();
            }
            else if (chosenItem is IConsumable)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{name} has used {chosenItem}");
                Console.ResetColor();
                (chosenItem as IConsumable).Use(this);
            }
        }

        public void OpenDoor(Door door)
        {
            if (equippedItem is Key)
            {
                door.UnlockDoor(equippedItem as Key);
            }
        }

        public bool ScanForEnemy()
        {
            if (currentPosition.enemy != null)
            {
                return this.hasFoundEnemy = true;
            }
            return this.hasFoundEnemy = false;
        }

        public bool GetHitDetection()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 2);
            if (randomNumber == 0)
            {
                return hasHitEnemy = true; 
            }
            return hasHitEnemy = false;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}