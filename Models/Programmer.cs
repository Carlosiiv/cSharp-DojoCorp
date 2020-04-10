using System;
using System.Collections.Generic;
using cSharp_DojoCorp.Interfaces;

namespace cSharp_DojoCorp.Models
{
    public class Programmer : Hero
    {
        Suitcase Suitcase = new Suitcase();
        public Programmer(string name) : base(name)
        {
            Level = 0;
            Dexterity = 5;
            Strength = 3;
            Speed = 7;
            Luck = 3;
            health = 100;
        }
        public override void SayName()
        {
            Console.WriteLine($"Hello My name is {Name}, and I'm a Programmer.");
        }

        public override int Attack(Villian target)
        {
            int dmgResult = base.Attack(target);
            Console.WriteLine($"You use a verbal for loop and confuse them for {dmgResult} points of mental strain!");
            return target.Health;
        }

        public int Secondary(Villian target)
        {
            Random rand = new Random();
            int dmgResult = rand.Next(Luck,25) * Strength * 2;
            target.Health -= dmgResult;
            Console.WriteLine($"You throw a punch, your lack of strength is bad, but you hit for {dmgResult}.");
            return target.Health;
        }


        public override int Choice(){
        bool playing = true;
        int choice = 0, choice2;
        while (playing){
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Punch");
            // Console.WriteLine("3. Item");

            bool check = int.TryParse(Console.ReadLine(), out choice);
            if ( !check || choice > 3 || choice <= 0 ){
                Console.WriteLine("Thats not one of the options! Try again!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Punch");
                // Console.WriteLine("3. Item");
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

            if (decision == 4){
                Consume(Suitcase.baggie[0]);
            }
            if (decision == 5){
                Consume(Suitcase.baggie[1]);
            }
            if (decision == 6){
                Consume(Suitcase.baggie[2]);
            }
            
            }
        }


}
