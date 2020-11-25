using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public abstract class Enemy
    {
        public string pic;
        public bool isAlive = true;
        public int droppedSouls;
        public bool hasHitPlayer = false;
        public bool isFighting = false;
        public string name;
        public int currentHealthPoints;
        public int maxHealthPoints;
        public int attackRating;
        public Field position;
        public Player player;
        public int damageDone;
  
        public Enemy(string name, int maxHealthPoints, int attackRating)
        {
            this.name = name;
            this.maxHealthPoints = maxHealthPoints;
            this.currentHealthPoints = maxHealthPoints;
            this.attackRating = attackRating;
        }
        public abstract void Fight(Player player);
        public abstract void DropItem(Player player);
        public abstract bool GetHitDetection();
        public abstract void DropSouls(Player player);
        public override string ToString()
        {
            return this.name;
        }


    }
}
