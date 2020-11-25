using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public abstract class HealthRegen : Item, IConsumable
    {
        public int healthGain;
        public HealthRegen(string name) : base(name)
        {
            
        }

        public void Use(Player player)
        {
            player.currentHealth += healthGain;
            player.backPack.Remove(this);
        }
    }
}
