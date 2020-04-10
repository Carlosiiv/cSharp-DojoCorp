using System;
using System.Collections.Generic;
using cSharp_DojoCorp.Interfaces;

namespace cSharp_DojoCorp.Models
{
    public abstract class Hero 
    {
        Suitcase Suitcase = new Suitcase();
        public string Name;
        public int Dexterity;
        public int Strength;
        public int Speed;
        public int Level;
        public int Luck;
        protected int health;
        protected int maxHealth;

        public int Health 
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
        
        public int MaxHealth 
        {
            get
            {
                return maxHealth;
            }
            set
            {
                maxHealth = value;
            }
        }

        public Hero(string name)
        {
            Name = name;
            Level = 0;
            Dexterity = 5;
            Strength = 5;
            Speed = 5;
            Luck = 1;
            health = 100;

        }

        public Hero(string name, int dex, int str, int spd, int lck)
        {
            Name = name;
            Level = 0;
            Dexterity = dex;
            Strength = str;
            Speed = spd;
            Luck = lck;
            health = 100;
            maxHealth= 100;
        }

        public abstract void SayName();

        public virtual void ShowStats()
        {
            Console.WriteLine($"Name: {Name}\nDexterity: {Dexterity}\nStrength: {Strength}\nSpeed: {Speed}\nLuck: {Luck}\nHealth: {health}");
        }

        public virtual int Attack(Villian target)
        {
            int skill = Strength;
            if (skill < Dexterity)
            {
                skill = Dexterity;
            }
            if (skill < Speed)
            {
                skill = Speed;
            }

            Random chance = new Random();
            int c1 = chance.Next(0,10-Luck);
            int c2 = chance.Next(0,10-Luck);
            int dmg = skill * 5;
            int critdmg = dmg* 2;
            int miss = 0;
            bool Hit = false;
            if(Luck < 10)
            {
                if(chance.Next(1,4 + target.Dexterity) != 4 + target.Dexterity)
                {
                    Hit = true;
                }
                if (Hit == true)
                {
                    if( c1 == c2)
                    {
                        target.Health -= dmg * 2;
                        Console.WriteLine($"{Name} has Crit {target.Name} for {dmg*2}");
                        return critdmg;
                    }
                    else
                    {
                        target.Health -= dmg;
                        Console.WriteLine($"{Name} has hit {target.Name} for {dmg}");
                        return dmg;
                    }
                }
                else
                {
                    Console.WriteLine($"{Name} Missed!");
                    return miss;
                }                    
            }
            else
            {
                if(chance.Next(1,10 + target.Dexterity) != 10 + target.Dexterity)
                {
                    Hit = true;
                }
                if( Hit == true)
                {
                    target.Health -= dmg * 2;
                    Console.WriteLine($"{Name} has Crit {target.Name} for {dmg*2}");
                    return critdmg;
                }
                else
                {
                    Console.WriteLine($"{Name} Missed!");
                    return miss;
                }
            }
        }

        public virtual int Choice()
        {
            bool playing = true;
            int choice = 0;
            while (playing)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Consume");

                bool check = int.TryParse(Console.ReadLine(), out choice);
                if ( !check || choice > 2 || choice <= 0 )
                {
                    Console.WriteLine("Thats not one of the options! Try again!");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Attack");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                if (choice == 1 || choice == 2)
                {
                    break;
                }
            }
                return choice;
        }

        public virtual void YourTurn(int decision , Villian target)
        {
            if (decision == 1)
            {

                Attack(target);
            }

        }
        public virtual void YourTurn(int decision , Villian target, Hero htarget)
        {
            if (decision == 1)
            {
                Attack(target);
            }

        }
        public virtual int Consume(Item item)
        {
            if( item.IsGood){
                Health += item.Value;
                return Health;
            }
            else{
                Console.WriteLine($"Why Do You WANT TO HURT YOURSELF!?");
                return Health;
            }
        }

        public virtual int Consume(Item item, Villian target)
        {
            if( item.IsGood){
                Health += item.Value;
                return Health;
            }
            else{
                target.Health += item.Value;
                return target.Health;
            }
        }
    }
}