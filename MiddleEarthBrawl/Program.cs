using System;

namespace MiddleEarthBrawl
{
    class Program
    {
        static void Main(string[] args)
        {
           
            GameManager newGame = new();
            while (newGame.PlayAgain)
            {
                newGame.Start();
            }
            Environment.Exit(1);
        }
    }
}
