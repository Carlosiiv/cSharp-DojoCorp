using System;

namespace cSharp_DojoCorp.Models
{
    public class Auditor : Villian
    {
        public Auditor(string name) : base(name)
        {
            Dexterity = 8;
            Strength = 6;
            Speed = 5;
            Luck = 2;
            health = 50;
        }
        public override void SayName()
        {
            Console.WriteLine($"Hello My name is {Name}, and I'm an Evil Auditor.");
        }
        public override int Attack(Hero target)
        {
            int dmgResult = base.Attack(target);
            Console.WriteLine($"You use a verbal for loop and confuse them for {dmgResult} points of mental strain!");
            return target.Health;
        }
    }
}