using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public class UndeadKnight : Enemy
    {
        
        public UndeadKnight(string name, int healthPoints, int attackRating) : base(name, healthPoints, attackRating)
        {
            this.droppedSouls = 400;
        }

        public override void DropItem(Player player)
        {
            if (currentHealthPoints <= 0)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 10);
                if (randomNumber == 0)
                {
                    player.currentPosition.itemsOnField.Add(new BigPotion("BIG HEALTH POTION"));
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
            if (GetHitDetection())
            {
                this.hasHitPlayer = true;
                player.currentHealth -= this.attackRating;
            }
            else
            {
                this.hasHitPlayer = false;
            }
            if (player.currentHealth <= 0)
            {
                player.isAlive = false;
            }
        }

        public override bool GetHitDetection()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 3);
            if (randomNumber == 0)
            {
                return true;
            }
            return false;
        }
    }
        
}
