using System;
using cSharp_DojoCorp.Models;
using cSharp_DojoCorp.Interfaces;

namespace cSharp_DojoCorp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleCyan("********DIABOLO-CORP********");
            
            ConsoleCyan($"It was another long day at the office. You finally get home, and check your personal email(since your so called office friends are always looking over your screens, making sure everything is nice and productive for your Boss).\n\n A name you hadn't seen in weeks appears in your emails. The recruiter for the interview you had to call out for...?\n\n YOU GOT THE JOB! \n\nCongratulations! You can't wait to accept this and jump out of this gig before it finally wears you down. You hurridly write your two weeks and print it out. \n\n Tomorrow is a big day. \n\nPRESS ENTER TO START");


            Hero player = PlayerSetup();

            ConsoleKey key  = Console.ReadKey(true).Key;
            while(key != ConsoleKey.Enter)
            {
                key  = Console.ReadKey(true).Key;
            }
            Console.WriteLine("BEGIN YOUR ADVENTURE HERE!!!");

            //write a method that will create other team mates.

            // make a game(while) loop to run your game
            //not sure how to do this yet - Tom

            ConsoleCyan("Your direct superdvisor eyes you in horror as you tell her that you're going to accept a new position. \n\n 'Are you ABSOLUTELY SURE you want to do this? We've taken such good care of you here!");

            string choice1= "0";
            while (choice1 !="1" && choice1 !="2")
            {
                Console.WriteLine("Have they really taken good care of you? You've spent a good amount of nights in a sleeping bag in this office. The coffee machine is always on the fritz, and you've given up on bringing lunch since it always 'disappears.' \n\n What do you want to do?");
                Console.WriteLine("How do you answer? 1 for Yes and 2 for No");
                choice1 = Console.ReadLine();
            }
            switch (choice1)
            {
                case("1"):
                    ConsoleRed("'You must be crazy to even THINK of leaving a job like this.'\n\n The passive aggression coming from her mouth burns in your mind, as the two of you begin to furiously debate.");
                    EvilLawyers Stacy = new EvilLawyers("Stacy");
                    BattleInstance.Battle(player, Stacy);
                    player.Health = player.MaxHealth;
                    break;
                    

                case("2"):
                    ConsoleCyan("'I Knew you would see it my way. We really, really, really care for you here and would be lost without you!'\n\n You never leave this company, never retiring as you work under them for the rest of your days.");
                    player.Health = 0;
                    
                    break;
            }
        }

        static void ConsoleCyan(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static void ConsoleRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }


        public static void IsHeroDead(Hero player)
        {
            if (player.Health <= 0){
                Console.WriteLine("Looks like you're stuck!");
                Console.WriteLine("Better luck next time!");
                // string choice0 = "0";
                // while (choice0 != "1" && choice0 !="2"){
                    Console.WriteLine("END - Restart the game to try again.");
                //     Console.ReadLine();
                // }
                // switch (choice0)
                // {
                //     case("1"):
                    
                //     break;
                //     case("2"):
                //     Environment.Exit(0);
                //     break;
                // }
            }
        }



        static Hero PlayerSetup()
        {
            Console.WriteLine("What is your name?");

            string name = Console.ReadLine();
            string choice = "0";

            while( choice != "1" && choice != "2" && choice != "3" && choice !="4")
            {
                Console.WriteLine("What was your role within the company? Use your number keys to decide\n1. Programmer - Writes and Speaks in the obscure language of Code, confusing opponents with mathematical precision.\n2. Lawyer - Knows the ways of the Law, with a post-graduate degree that cost them in the hundreds of thousands. Legaleses opponents into submission.\n3. Accountant - Master of the books and TPS Reports. Number crunches their way to victory.\n4. Office Bum - How did you even get this job, let alone another one? Must be lucky I guess.");
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case("1"):
                    Programmer prohero = new Programmer(name);
                    return prohero;
                case("2"):
                    // Change Ninja to another class of hero.
                    Lawyer lawhero = new Lawyer(name);
                    return lawhero;
                case("3"):
                    // Change Ninja to another class of hero.
                    Accountant acchero = new Accountant(name);
                    return acchero;
                case("4"):
                    OfficeBum bumhero = new OfficeBum(name);
                    return bumhero;
            }
            return null;
        }
    }
}
