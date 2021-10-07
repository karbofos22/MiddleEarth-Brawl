using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthBrawl
{
    class Fighters
    {
        protected string Name;
        protected int Health;
        protected int HitStrength;
        protected float CritChance;

        protected Fighters CreateElfFighter()
        {
            Fighters anfalen = new();
            anfalen.Name = "Anfalen";
            anfalen.Health = 150;
            anfalen.HitStrength = 2;
            anfalen.CritChance = 1.9F;
            return anfalen;
        }

        protected Fighters CreateDwarfFighter()
        {
            Fighters balin = new();
            balin.Name = "Balin";
            balin.Health = 250;
            balin.HitStrength = 6;
            balin.CritChance = 1.2F;
            return balin;
        }

        protected Fighters CreateHumanFighter()
        {
            Fighters sigfrid = new();
            sigfrid.Name = "Sigfrid";
            sigfrid.Health = 100;
            sigfrid.HitStrength = 4;
            sigfrid.CritChance = 1.7F;
            return sigfrid;
        }

        protected void WarriorInfo(Fighters player)
        {
            Console.WriteLine();
            Console.WriteLine($"Fighter stats:\n" + 
                              $"\tName: {player.Name}\n" +
                              $"\tHealth: {player.Health}\n" +
                              $"\tStrength: {player.HitStrength}\n" +
                              $"\tCritChance: {player.CritChance}\n");
        }

        protected void HitToHead(Fighters player1, Fighters player2OrAi)
        {
            player2OrAi.Health -= (player1.HitStrength * (int)player1.CritChance + 8);
            Console.WriteLine($"\t{player1.Name} delivers a mighty blow to {player2OrAi.Name} " +
                              $"for {(player1.HitStrength * (int)player1.CritChance + 8)} points");
        }
        protected void HitToBody(Fighters player1, Fighters player2OrAi)
        {
            player2OrAi.Health -= (player1.HitStrength * (int)player1.CritChance + 6);
            Console.WriteLine($"\t{player1.Name} delivers a mighty blow to {player2OrAi.Name} " +
                              $"for {(player1.HitStrength * (int)player1.CritChance + 6)} points");
        }
        protected void HitToLegs(Fighters player1, Fighters player2OrAi)
        {
            player2OrAi.Health -= (player1.HitStrength * (int)player1.CritChance + 4);
            Console.WriteLine($"\t{player1.Name} delivers a mighty blow to {player2OrAi.Name} " +
                              $"for {(player1.HitStrength * (int)player1.CritChance + 4)} points");
        }
        protected string AiHits()
        {
            string[] hitLetters = {"q","w","e"};
            Random random = new();
            int num = random.Next(0, 3);
            string aiChoise = "";

            for (int i = num; i <= hitLetters.Length;)
            {
                aiChoise = hitLetters[i];
                break;
            }
            return aiChoise;
        }

        protected void HealthStatus(Fighters player1, Fighters player2OrAi)
        {
            Console.WriteLine();
            Console.WriteLine($"{player1.Name}\t\t\t\t\t\t{player2OrAi.Name}");
            Console.WriteLine($"{player1.Health}\t\t\t\t\t\t\t{player2OrAi.Health}");
        }

        protected bool FightIsOn(Fighters player1, Fighters player2OrAi)
        {
            if (player1.Health > 0 && player2OrAi.Health > 0)
                return true;
            else
                return false;
        }

        protected void BattleResult(Fighters player1, Fighters player2OrAi)
        {
            if (player1.Health <= 0)
            {
                Console.WriteLine($"{player2OrAi.Name} is our winner today!");

            }
            else if (player2OrAi.Health <= 0)
            {
                Console.WriteLine($"\n\t{player1.Name} is our winner today!");

            }
        }
    }
}
