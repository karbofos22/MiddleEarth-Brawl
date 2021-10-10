using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MiddleEarthBrawl
{
   


    class CoreOperations : Fighters
    {
        private Fighters player1 { get; set; }
        private Fighters player2 { get; set; }
        private Fighters ai { get; set; }
        private int gameMode { get; set;}
        private bool Player1Turn { get; set;}
        private bool Player2Turn { get; set;}
        private bool Aiturn { get; set; }





        public void GreetUser()
        {
            Console.WriteLine("\tGood day to you, sir!\n\tWelcome to our fighting game!\n");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void ChooseGameMode()
        {
            Console.WriteLine("Please, choose game mode: Player vs AI(1) or Player vs Player(2)\n");
            gameMode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (gameMode)
            {
                case 1:
                    Console.WriteLine("You selected \"Player vs AI\" game mode\n");
                    break;
                case 2:
                    Console.WriteLine("You selected \"Player vs Player\" game mode\n");
                    break;
                default:
                    Console.WriteLine("You did not select one of available game modes, please, try again\n");
                    ChooseGameMode();
                    break;
            }
        }

        public void ChooseFighter()
        {
            if (gameMode == 1)
            {
                
                Console.WriteLine(
                "If you want to choose mighty human knight - enter 1 and press Enter\n" +
                "If you want to choose brutal dwarf berserker - enter 2 and press Enter\n" +
                "If you want to choose noble elf swordmaster - enter 3 and press Enter\n");
                Console.WriteLine("\t\tNow select your champion:");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        player1 = CreateHumanFighter();
                        WarriorInfo(player1);
                        CreateRandomAI();
                        break;
                    case "2":
                        player1 = CreateDwarfFighter();
                        WarriorInfo(player1);
                        CreateRandomAI();
                        break;
                    case "3":
                        player1 = CreateElfFighter();
                        WarriorInfo(player1);
                        CreateRandomAI();
                        break;
                    default:
                        Console.WriteLine("Вы не сделали выбор, пожалуйста, выберите персонажа");
                        ChooseFighter();
                        break;
                }
            }
            else if (gameMode == 2)
            {
                Console.WriteLine(
                "If you want to choose mighty human knight - Sigfrid, enter 1 and press Enter\n" +
                "If you want to choose brutal dwarf berserker - Balin, enter 2 and press Enter\n" +
                "If you want to choose noble elf swordmaster - Anfalen, enter 3 and press Enter\n");

                Console.WriteLine("\t\tPlayer1, select your champion:");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        player1 = CreateHumanFighter();
                        WarriorInfo(player1);
                        break;
                    case "2":
                        player1 = CreateDwarfFighter();
                        WarriorInfo(player1);
                        break;
                    case "3":
                        player1 = CreateElfFighter();
                        WarriorInfo(player1);
                        break;
                    default:
                        Console.WriteLine("Вы не сделали выбор, пожалуйста, выберите персонажа");
                        ChooseFighter();
                        break;
                }
                Console.WriteLine("\t\tPlayer2, select your champion:");
                string userInput2 = Console.ReadLine();
                switch (userInput2)
                {
                    case "1":
                        player2 = CreateHumanFighter();
                        WarriorInfo(player2);
                        break;
                    case "2":
                        player2 = CreateDwarfFighter();
                        WarriorInfo(player2);
                        break;
                    case "3":
                        player2 = CreateElfFighter();
                        WarriorInfo(player2);
                        break;
                    default:
                        Console.WriteLine("Вы не сделали выбор, пожалуйста, выберите персонажа");
                        ChooseFighter();
                        break;
                }

            }
        }
        public void CreateRandomAI()
        {
            Random random = new();
            int randomNum = random.Next(1, 3);
            switch (randomNum)
            {
                case 1:
                    ai = CreateHumanFighter();
                    break;
                case 2:
                    ai = CreateDwarfFighter();
                    break;
                case 3:
                    ai = CreateElfFighter();
                    break;
                default:
                    break;
            }
        }
       
        public void FirstStrikeTryOut()
        {
            Random random = new();
            int player1Toss = 0;
            int player2Toss = 0;
            int aiToss = 0;
            Console.WriteLine("Warriors! Toss a coin(press \"space\") for the first strike rigth");
          
            if (gameMode == 1)
            {
                Console.WriteLine("Player1:");

                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine();
                    player1Toss = random.Next(1, 10);
                    aiToss = random.Next(1, 10);
                }
            }
            if (player1Toss > aiToss)
            {
                Aiturn = false;
                Player1Turn = true;
            }
            else
            {
                Aiturn = true;
                Player1Turn = false;
            }
            
            if (gameMode == 2)
            {
                Console.WriteLine("Player1:");

                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine();
                    player1Toss = random.Next(1, 10);
                    
                }
                Console.WriteLine("Player2:");
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    player2Toss = random.Next(1, 10);
                }
            }
            if (player1Toss > player2Toss)
            {
                Player1Turn = true;
                Player2Turn = false;
            }
            else
            {
                Player1Turn = false;
                Player2Turn = true;
            }
        }
        public void Rules()
        {
            Console.WriteLine("Rules are simple:\nFor hit to the head press q(player1) or a(player2)\n" +
                              "For hit to the body press w(player1) or s(player2)\n" +
                              "For hit to the legs press e(player1) or c(player2)\n");
        }

        public void Action()
        {
            string userInput = "";
            Console.WriteLine();
            Console.WriteLine("\t\tLETS GET READY TO RUMBLE!!\n"+
                              "\t(please wait a bit, the fighters are getting ready)");

            if (gameMode == 1)
            {
                while (FightIsOn(player1, ai))
                {
                    Thread.Sleep(5000);
                    Console.Clear();
                    Rules();
                    HealthStatus(player1, ai);

                    if (Player1Turn)
                    {
                        Console.WriteLine("\t\tBattle log:");
                        userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "q":
                                HitToHead(player1, ai);
                                Player1Turn = false;
                                Aiturn = true;
                                break;


                            case "w":
                                HitToBody(player1, ai);
                                Player1Turn = false;
                                Aiturn = true;
                                break;
                            case "e":
                                HitToLegs(player1, ai);
                                Player1Turn = false;
                                Aiturn = true;
                                break;
                        }
                    }
                    if (Aiturn)
                    {
                        userInput = AiHits();
                        switch (userInput)
                        {
                            case "q":
                                HitToHead(ai, player1);
                                Aiturn = false;
                                Player1Turn = true;
                                break;


                            case "w":
                                HitToBody(ai, player1);
                                Aiturn = false;
                                Player1Turn = true;
                                break;
                            case "e":
                                HitToLegs(ai, player1);
                                Aiturn = false;
                                Player1Turn = true;
                                break;
                        }
                    }
                }
                BattleResult(player1, ai);
            }
            if(gameMode == 2)
            {
                Console.Clear();
                Rules();
                HealthStatus(player1, ai);

                if (Player1Turn)
                {
                    Console.WriteLine("\t\tPlayer1, turn!");
                    userInput = Console.ReadLine();

                }
                else if (Player2Turn)
                {
                    Console.WriteLine("\t\tPlayer2, turn!");
                    userInput = Console.ReadLine();
                }

                switch (userInput)
                {
                    case "q":
                    case "a":
                        if (gameMode == 1)
                        {
                            HitToHead(player1, ai);
                            userInput = AiHits();
                        }
                        else if (gameMode == 2)
                        {
                            HitToHead(player1, player2);
                        }
                        break;
                    case "w":
                    case "s":
                        if (gameMode == 1)
                        {
                            HitToBody(player1, ai);
                        }
                        else if (gameMode == 2)
                        {
                            HitToBody(player1, player2);
                        }
                        break;
                    case "e":
                    case "c":
                        if (gameMode == 1)
                        {
                            HitToLegs(player1, ai);
                        }
                        else if (gameMode == 2)
                        {
                            HitToLegs(player1, player2);
                        }
                        break;
                }
            }
            BattleResult(player1, player2);
        }
    }
}
