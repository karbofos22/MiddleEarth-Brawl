using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleEarthBrawl
{
    class Fighters
    {
        protected string name;
        protected int health;
        protected int hitStrength;
        protected int critChance;

        protected Fighters CreateElfFighter()
        {
            Fighters anfalen = new()
            {
                name = "Anfalen",
                health = 150,
                hitStrength = 2,
                critChance = 5
            };
            return anfalen;
        }

        protected Fighters CreateDwarfFighter()
        {
            Fighters balin = new()
            {
                name = "Balin",
                health = 250,
                hitStrength = 7,
                critChance = 1
            };
            return balin;
        }

        protected Fighters CreateHumanFighter()
        {
            Fighters sigfrid = new()
            {
                name = "Sigfrid",
                health = 100,
                hitStrength = 5,
                critChance = 6
            };
            return sigfrid;
        }

        protected void WarriorInfo(Fighters player)
        {
            Console.WriteLine();
            Console.WriteLine($"Fighter stats:\n" + 
                              $"\tName: {player.name}\n" +
                              $"\tHealth: {player.health}\n" +
                              $"\tStrength: {player.hitStrength}\n" +
                              $"\tCritChance: {player.critChance}\n");
        }

        protected void HitToHead(Fighters player1, Fighters player2OrAi)
        {
            player2OrAi.health -= (player1.hitStrength * (int)player1.critChance + 8);
            Console.WriteLine($" {player1.name} delivers a mighty blow to {player2OrAi.name}'s head " +
                              $"for {(player1.hitStrength * (int)player1.critChance + 8)} points");
        }
        protected void HitToBody(Fighters player1, Fighters player2OrAi)
        {
            player2OrAi.health -= (player1.hitStrength * (int)player1.critChance + 6);
            Console.WriteLine($" {player1.name} delivers a mighty blow to {player2OrAi.name}'s body " +
                              $"for {(player1.hitStrength * (int)player1.critChance + 6)} points");
        }
        protected void HitToLegs(Fighters player1, Fighters player2OrAi)
        {
            player2OrAi.health -= (player1.hitStrength * (int)player1.critChance + 4);
            Console.WriteLine($" {player1.name} delivers a mighty blow to {player2OrAi.name}'s legs " +
                              $"for {(player1.hitStrength * (int)player1.critChance + 4)} points");
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
            Console.WriteLine($"{player1.name}\t\t\t\t\t\t\t{player2OrAi.name}");
            Console.WriteLine($"{player1.health}\t\t\t\t\t\t\t   {player2OrAi.health}");
        }

        protected bool FightIsOn(Fighters player1, Fighters player2OrAi)
        {
            if (player1.health > 0 && player2OrAi.health > 0)
                return true;
            else
                return false;
        }

        protected void BattleResult(Fighters player1, Fighters player2OrAi)
        {
            Console.WriteLine();
            if (player1.health <= 0)
            {
                Console.WriteLine($"\t\t{player2OrAi.name} is our winner today!");
            }
            else if (player2OrAi.health <= 0)
            {
                Console.WriteLine($"\t\t{player1.name} is our winner today!");
            }
        }
    }
}
