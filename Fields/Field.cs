using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public abstract class Field
    {
        public string pic;
        public FieldType fieldType = FieldType.NON_PASSABLE;
        public string name;
        public int iD;
        public Field north;
        public Field east;
        public Field south;
        public Field west;
        public List<Item> itemsOnField = new List<Item>();
        public Enemy enemy;

        public Field(string name)
        {
            this.name = name;
            GetRandomEnemy();
            GetRandomLoot();
        }

        public Field(string name, FieldType fieldType)
        {
            this.name = name;
            this.fieldType = fieldType;
            
        }
        public Field GetFieldInDirection(MovingType direction) // Verknüpfung der Attribute east, north, west und south des Datentyp "Field" und vom Datentyp Enum Moving Type 
        {
            if (direction == MovingType.NORTH)
            {
                return north;
            }
            if (direction == MovingType.EAST)
            {
                return east;
            }
            if (direction == MovingType.SOUTH)
            {
                return south;
            }
            return west;
        }

        public void LinkFields(Field field, MovingType direction) // gegenseitige Verknüpfung von Feldern
        {
            switch (direction)
            {
                case MovingType.EAST:
                    field.west = this;
                    east = field;
                    break;
                case MovingType.NORTH:
                    field.south = this;
                    north = field;
                    break;
                case MovingType.SOUTH:
                    field.north = this;
                    south = field;
                    break;
                case MovingType.WEST:
                    field.east = this;
                    west = field;
                    break;
            }
        }

        public void GetRandomEnemy()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 2);
            if (randomNumber == 0)
            {
                Enemy randomZombie = new Zombie("ZOMBIE", 20, 3);
                this.enemy = randomZombie;
                enemy.position = this;
            }
            if (randomNumber == 1)
            {
                Enemy randomKnight = new UndeadKnight("HOLLOW KNIGHT", 30, 5);
                this.enemy = randomKnight;
                enemy.position = this;
            }
            int moonKnightSpawn = random.Next(0, 5);
            if (moonKnightSpawn == 0)
            {
                Enemy darkMoonKnight = new DarkMoonKnight("DARK MOON KNIGHT", 50, 10);
                this.enemy = darkMoonKnight;
                enemy.position = this;
            }

        }

        public void GetRandomLoot()
        {
            Random random = new Random();
            {
                int randomNumber = random.Next(0, 5);
                if (randomNumber == 0 && randomNumber == 1)
                {
                    Item randomPotion = new SmallPotion("SMALL HEALTH POTION");
                    itemsOnField.Add(randomPotion);
                }
                if (randomNumber == 2)
                {
                    Item bigPotion = new BigPotion("BIG HEALTHPOTION");
                    itemsOnField.Add(bigPotion);
                }
            }
        }

        public override string ToString()
        {
            return this.name;
        }
    }



    
  

}