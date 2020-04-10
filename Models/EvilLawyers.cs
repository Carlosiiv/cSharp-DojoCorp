using System;

namespace cSharp_DojoCorp.Models
{
    public class EvilLawyers : Villian
    {
        public EvilLawyers(string name) : base(name)
        {
            Dexterity = 5;
            Strength = 6;
            Speed = 10;
            Luck = 2;
            health = 50;
        }
        public override void SayName()
        {
            Console.WriteLine($"Hello My name is {Name}, and I'm an Evil Lawyer.");
        }
        public override int Attack(Hero target)
        {
            int dmgResult = base.Attack(target);
            Console.WriteLine($"You use a verbal for loop and confuse them for {dmgResult} points of mental strain!");
            return target.Health;
        }
    }
}