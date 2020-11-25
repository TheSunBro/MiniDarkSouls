using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public class DarkMoonKnight : Enemy
    {
        public DarkMoonKnight(string name, int maxHealthPoints, int attackRating) : base(name, maxHealthPoints, attackRating)
        {
            this.droppedSouls = 800;
        }

        public override void DropItem(Player player)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 5);
            if (randomNumber == 0 && currentHealthPoints <= 0)
            {
                player.currentPosition.itemsOnField.Add(new Sword("DARK MOON GREATSWORD", 15));
            }
        }

        public override void DropSouls(Player player)
        {
            if (this.currentHealthPoints <= 0)
            {
                player.amountOfSouls += droppedSouls;
                isAlive = false;
                
            }
        }

        public override void Fight(Player player)
        {
            int extraDamage = 5;
            if (GetHitDetection())
            {
                this.hasHitPlayer = true;
                player.currentHealth -= this.attackRating + extraDamage;
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
            int randomNumber = random.Next(0, 2);
            if (randomNumber == 0)
            {
                return true;
            }
            return false;
        }
    }
}
