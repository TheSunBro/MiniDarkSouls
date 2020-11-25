using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public class Sword : Weapon, IUseable
    {
        public Sword(string name, int damage) : base(name, damage)
        {
            this.pic = @"      
            _
 _         | |
| | _______| |---------------------------------------------\
|:-)_______|==[]============================================>
|_|        | |---------------------------------------------/
           |_|

";
        }
    }
}
