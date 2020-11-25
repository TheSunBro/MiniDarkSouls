using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public class Floor : Field, IEnter
    {

        public Floor(string name) : base(name)
        {
            
        }

        public Field Enter()
        {
            return this;
        }
    }
}