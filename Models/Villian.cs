using System;

namespace cSharp_DojoCorp.Models
{
    public abstract class Villian
    {
        public string Name;
        public int Dexterity;
        public int Strength;
        public int Speed;
        public int Luck;
        protected int health;
        protected int maxHealth;
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public int MaxHealth 
        {
            get
            {
                return maxHealth;
            }
            set{
                maxHealth = value;
            }
        }

        
        

        public Villian(string name)
        {
            Name = name;
            Dexterity = 7;
            Strength = 7;
            Speed = 7;
            Luck = 2;
            health = 50;
        }

        public Villian(string name, int dex, int str, int spd)
        {
            Name = name;
            Dexterity = dex;
            Strength = str;
            Speed = spd;
            Luck = 2;
            health = 50;
        }

        public abstract void SayName();

        public virtual void ShowStats()
        {
            Console.WriteLine($"Name: {Name}\nDexterity: {Dexterity}\nStrength: {Strength}\nSpeed: {Speed}\nLuck: {Luck}\nHealth: {health}");
        }
        

        public virtual int Attack(Hero target)
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
            int dmg = skill * 3;
            int critdmg = dmg* 2;
            int miss = 0;
            bool Hit = false;
            if(Luck < 10){
                if(chance.Next(1,4 + target.Dexterity) != 4 + target.Dexterity){
                    Hit = true;
                }
                if (Hit == true){
                    if( c1 == c2){
                    target.Health -= dmg * 2;
                    Console.WriteLine($"{Name} has Crit {target.Name} for {dmg*2}");
                    return critdmg;
                    }
                    else{
                        target.Health -= dmg;
                        Console.WriteLine($"{Name} has hit {target.Name} for {dmg}");
                        return dmg;
                    }
                }
                else{
                    Console.WriteLine($"{Name} Missed!");
                    return miss;
                }                    
            }
            else{
                if(chance.Next(1,10 + target.Dexterity) != 10 + target.Dexterity){
                    Hit = true;
                }
                if( Hit == true){
                    target.Health -= dmg * 2;
                    Console.WriteLine($"{Name} has Crit {target.Name} for {dmg*2}");
                    return critdmg;
                }
                else{
                    Console.WriteLine($"{Name} Missed!");
                    return miss;
                }
            }
        }
        public int EChoice(){
            int eChoice;
            Random rng = new Random();
            eChoice = rng.Next(1, 2);
            return eChoice;
        }

        public virtual void EnemyTurn(int choice , Hero target){
            if (choice == 1){
                Attack(target);
                Console.WriteLine($"{Name} took a Venomous Bite at {target.Name}!");
            }
            Console.ReadLine();
        }



    }
}