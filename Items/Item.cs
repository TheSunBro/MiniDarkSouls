using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public abstract class Item
    {
        public string pic;
        public string name;
        public Item(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
