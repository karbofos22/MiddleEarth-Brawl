using System;

namespace MiddleEarthBrawl
{
    class Program
    {
        static void Main(string[] args)
        {
           
            CoreOperations newGame = new();
            while (newGame.PlayAgain)
            {
                newGame.GreetUser();
                newGame.ChooseGameMode();
                newGame.ChooseFighter();
                newGame.FirstStrikeTryOut();
                newGame.Action();
                newGame.ContinueOrEndGame();
            }
            Environment.Exit(1);

        }
    }
}
