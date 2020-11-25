using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public class Key : Item, IUseable
    {
        public string passwort;
        public Key(string name, string passwort) : base(name)
        {
            this.passwort = passwort;
            this.pic = @" 
     8 8 8 8                     ,ooo.
     8a8 8a8                    oP   ?b
    d888a888zzzzzzzzzzzzzzzzzzzz8     8b
      `""^""'                     ?o___oP'";
        }
        public void Use(Player player)
        {
            player.equippedItem = this;
        }
    }
}