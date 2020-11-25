using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public class Wall : Field, IEnter
    {
        public Wall(string name) : base(name)
        {

        }

        public Field Enter()
        {
            return null;
        }
    }
}