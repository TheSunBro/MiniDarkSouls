﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public class Zombie : Enemy
    {
        public Zombie (string name, int healthPoints, int attackRating) : base(name, healthPoints, attackRating)
        {
            this.droppedSouls = 500;
        }
        public override void DropItem(Player player)
        {
            if (this.currentHealthPoints <= 0)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 5);
                if (randomNumber == 0)
                {
                    player.currentPosition.itemsOnField.Add(new SmallPotion("SMALL HEALTH POTION"));
                }
            }
            
        }

        public override void DropSouls(Player player)
        {
            if (currentHealthPoints <= 0)
            {
               player.amountOfSouls += droppedSouls;
               isAlive = false;
            }
            
        }

        public override void Fight(Player player)
        {
            GetHitDetection();
            if (hasHitPlayer)
            {
                this.hasHitPlayer = true;
                player.currentHealth -= this.attackRating;
            }

            if (player.currentHealth <= 0)
            {
                player.isAlive = false;
            }
            DropSouls(player);
            DropItem(player);
        }

        public override bool GetHitDetection()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 4);
            if (randomNumber == 0)
            {
                return true;
            }
            return false;
        }
    }
}
