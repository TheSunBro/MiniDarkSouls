using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MiniDarkSouls3
{
    public class BonFire : Field, IEnter
    {
        public int costPerLevelUp = 1000;
        public BonFire(string name) : base(name)
        {
        }

        public Field Enter()
        {
            return this;
        }
        public void Levelup(Player player)
        {
            
            if (player.amountOfSouls >= costPerLevelUp)
            {
                Console.WriteLine("Press ENTER to LEVEL UP");
                Console.ReadLine();
                player.strenght++;
                player.amountOfSouls -= costPerLevelUp;
            }
            
        }
    }
    

}
