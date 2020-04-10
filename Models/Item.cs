using System;
using System.Collections.Generic;
using cSharp_DojoCorp.Interfaces;

namespace cSharp_DojoCorp.Models
{

    
    public class Item : IConsumable
    {
        public string Name {get;set;}
        public int Value {get;set;}
        public bool IsGood {get;set;}
        public bool IsBad {get;set;}
        public string GetInfo(){
            return $"Item Name:{Name}\nItem Value:{Value}\nGood?:{IsGood}\nBad?:{IsBad}";
        }
        public Item(string name, int value,bool good,bool bad){
            Name = name;
            Value = value;
            IsGood = good;
            IsBad = bad;
        }
        
    }
    public class Suitcase {
        public List<Item> baggie;

        public Suitcase(){
            List<Item> baggie = new List<Item>(){
                new Item("Coffee",25,true,false),
                new Item("Water",25,true,false),
                new Item("Stapler",-25,false,true),
            };
        }
        public List<Item> ItemToUse(){
            return baggie;
        }
    }
     
}