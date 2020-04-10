using System;
using System.Collections.Generic;
using cSharp_DojoCorp.Interfaces;


namespace cSharp_DojoCorp.Models
{
    public class OfficeBum : Hero
    {
        // Suitcase itemList = new Suitcase();
        Suitcase suitcast = new Suitcase();
        List<Item> itemList = new List<Item>();
         public OfficeBum(string name) : base(name)
        {   
            // Suitcase itemList = new Suitcase();
            itemList = suitcast.ItemToUse();
            Dexterity = 3;
            Strength = 3;
            Speed = 3;
            Luck = 6;
            health = 100;
        }
        public override void SayName()
        {
            Console.WriteLine($"Hello My name is {Name}, and I'm an Office GOD!");
        }

        public override int Attack(Villian target)
        {    
            int dmgResult = base.Attack(target);
            Console.WriteLine($"Your constant shrugging and saying of 'yah, bruh' annoys them for {dmgResult} points of mental strain");
            return target.Health;
        }
        public int Secondary(Villian target)
        {
            Random rand = new Random();
            int dmgResult = rand.Next(5,20) * Dexterity;
            target.Health -= dmgResult;
            Console.WriteLine($"You mumble at them causeing {dmgResult} points of brain damage!");
            return target.Health;
        }


        public override int Choice(){
            bool playing = true;
            int choice = 0, choice2;
            while (playing){
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Mumble");
                Console.WriteLine("3. Item");

                bool check = int.TryParse(Console.ReadLine(), out choice);
                if ( !check || choice > 3 || choice <= 0 ){
                    Console.WriteLine("Thats not one of the options! Try again!");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Attack");
                    Console.WriteLine("2. Mumble");
                    Console.WriteLine("3. Item");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                if (choice == 1 || choice == 2 ){
                    break;
                }
                if (choice == 3){
                    Console.WriteLine("Choose an Item:");
                    Console.WriteLine("1. Coffee");
                    Console.WriteLine("2. Water");
                    Console.WriteLine("3. Stapler");
                    bool check2 = int.TryParse(Console.ReadLine(), out choice2);
                    if ( !check2 || choice2 > 3 || choice2 <= 0 ){
                    
                }

                    if (choice2 == 1)
                    {
                        choice = 4;
                    }

                    if (choice2 == 2)
                    {
                        choice = 5;
                    }
                    if (choice2 == 3)
                    {
                        choice = 6;
                    }
                }

                if (choice == 1 || choice == 2 || choice == 4 || choice == 5)
                {
                    break;
                }
            }
            return choice;
        }
        public override void  YourTurn(int decision , Villian target)
        {
            if (decision == 1){

                Attack(target);
            }

            if (decision == 2){

                Secondary(target);
            }

            // if (decision == 4){
            //     Console.WriteLine(itemList.baggie.Count);
            //     Consume(itemList.baggie[0]);
            // }
            // if (decision == 5){
            //     Consume(itemList.baggie[1]);
            // }
            // if (decision == 6){
            //     Consume(itemList.baggie[2],target);
            // }
            if (decision == 4){
                // Console.WriteLine(itemList.baggie.Count);
                Consume(itemList[0]);
            }
            if (decision == 5){
                Consume(itemList[1]);
            }
            if (decision == 6){
                Consume(itemList[2],target);
            }

            
            }
        }
}