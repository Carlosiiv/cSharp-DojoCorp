using System;
using System.Collections.Generic;

namespace cSharp_DojoCorp.Models
{
    public class BattleInstance
    {
        public static void Restart(){
            // need restart
        }
        public static void IsHeroDead(Hero player)
        {
            if (player.Health <= 0){
                Console.WriteLine("Looks like you're stuck!");
                Console.WriteLine("Better luck next time!");
                string choice0 = "0";
                while (choice0 != "1" && choice0 !="2"){
                    Console.WriteLine("Do you want to try again? 1 to restart and 2 to Exit.");
                    Console.ReadLine();
                }
                switch (choice0)
                {
                    case("1"): 
                    Restart();
                    break;
                    case("2"):
                    Environment.Exit(0);
                    break;
                }
            }
        }
        public static void DiplayStats(Hero hero1 , Hero hero2)
        {
            hero1.ShowStats();
            Console.WriteLine("");
            hero2.ShowStats();
            Console.WriteLine("");
        }

        public static void Battle(Hero hero, Villian challenger)
        {
            while ( challenger.Health > 0 && hero.Health > 0)
            {
                hero.ShowStats();

                hero.YourTurn(hero.Choice(), challenger);

                if (challenger.Health > 0)
                {
                    challenger.EnemyTurn(challenger.EChoice() , hero);
                    IsHeroDead(hero);
                }

            }

            Console.WriteLine("{0} was Defeated!" , challenger.Name);
            Console.ReadLine();
        }
        
    }
}  