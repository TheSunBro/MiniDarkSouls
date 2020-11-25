using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public abstract class Weapon : Item, IUseable
    {
        public int damage;
        public Weapon(string name, int damage) : base(name)
        {
            this.damage = damage;
        }

        public void Use(Player player)
        {
            player.equippedItem = this;
        }
    }
}
