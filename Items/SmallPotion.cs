using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public class SmallPotion : HealthRegen, IConsumable
    {
        public SmallPotion(string name) : base(name)
        {
            this.healthGain = 10;
        }
    }
}