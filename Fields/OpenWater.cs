using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    class OpenWater : Field , IEnter
    {
        public bool canSwim = false;
        public OpenWater(string name, FieldType fieldType) : base(name, fieldType)
        {
            this.fieldType = fieldType;
        }

        public Field Enter()
        {
            if (!canSwim)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("YOU SHALL NOT PASS! LEARN HOW TO SWIM!");
                Console.ResetColor();
                return null;
            }
            return this.east;
        }
    }
}
