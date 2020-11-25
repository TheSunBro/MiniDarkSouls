using System;
using System.Collections.Generic;
using System.Text;

namespace MiniDarkSouls3
{
    public class LevelEditor
    {
        public static Field CreateLevel()
        {
            Field start = new Floor("PRISON OF THE ANCIENT DRAGON");
            Field f2 = new Floor("UNDEAD ASYLUM");
            Field f3 = new Floor("FORBIDDEN GARDEN");
            Field f4 = new Floor("GRAND TOWER OF FLAME");
            Field f5 = new Floor("FORSAKEN CEMETERY");
            Field f6 = new Floor("CASTLE OF GIANTS");

            Field fireLinkShrine = new BonFire("FIRELINK SHRINE");


            Field dragonDoor1 = new Door("DRAGON DOOR", "1234", FieldType.PASSABLE);
            //Field d2 = new Door("Door 2");
            //Field d3 = new Door("Door 3");
            //Field d4 = new Door("Door 4");
            //Field d5 = new Door("Door 6");

            Field w1 = new Wall("Wall 1");

            Field ow = new OpenWater("LAKE OF GIANTS", FieldType.PASSABLE);
            Field ow2 = new OpenWater("Open Water 2", FieldType.PASSABLE);


            Item dragonKey = new Key("DRAGON KEY", "1234");
            Weapon sunsword = new Sword("SUN SWORD", 10);
            start.itemsOnField.Add(dragonKey);
            f2.itemsOnField.Add(sunsword);

            start.LinkFields(dragonDoor1, MovingType.EAST);
            dragonDoor1.LinkFields(f2, MovingType.EAST);
            f2.LinkFields(f3, MovingType.EAST);
            f3.LinkFields(f4, MovingType.EAST);
            f4.LinkFields(f5, MovingType.SOUTH);
            f5.LinkFields(fireLinkShrine, MovingType.EAST);
            fireLinkShrine.LinkFields(w1, MovingType.EAST);
            fireLinkShrine.LinkFields(f6, MovingType.NORTH);
            f6.LinkFields(ow, MovingType.NORTH);

            return start;
        }
    }
}
