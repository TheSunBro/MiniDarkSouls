using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public class BigPotion : HealthRegen, IConsumable
    {
       
        public BigPotion(string name) : base(name)
        {
            this.healthGain = 40;
        }
    }
}
