using System;

namespace cSharp_DojoCorp.Interfaces
{
    public interface IConsumable
    {
        string Name {get;set;}
        int Value {get;set;}
        string GetInfo();
        bool IsGood {get;set;}
        bool IsBad {get;set;}
    }
    


}