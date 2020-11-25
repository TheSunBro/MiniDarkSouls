using System;

namespace MiniDarkSouls3
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.GameInit();
            gameManager.PlayerControl();
        }
    }
}
