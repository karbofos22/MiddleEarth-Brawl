using System;

namespace MiddleEarthBrawl
{
    class Program
    {
        static void Main(string[] args)
        {


            
            CoreOperations newGame = new();
            newGame.GreetUser();
            newGame.ChooseGameMode();
            newGame.ChooseFighter();
            newGame.FirstStrikeTryOut();
            newGame.Action();


        }
    }
}
