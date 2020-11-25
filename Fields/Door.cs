using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public class Door : Field, IEnter
    {
        public string nameOfKey;
        public bool locked = true;
        public string password;
        public FieldType field = FieldType.PASSABLE;

        public Door(string name, string password, FieldType fieldType) : base(name, fieldType)
        {
            this.password = password;
            this.fieldType = fieldType;
        }

        public Field Enter()
        {
            
            if (locked)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("YOU SHALL NOT PASS! Door is locked!");
                Console.ResetColor();
                return null;
            }
            return this.east;
            
            
        }
        public bool UnlockDoor(Key key)
        {
            if (key.passwort == password)
            {
                locked = false;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You have unlocked {name} with {key}");
                Console.ResetColor();
                
            }
            return !locked;
        }
    }
}