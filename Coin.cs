using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BrusAutomat 
{
    class Coin
    {
        public readonly int Value;
        public int Amount;
        
        public Coin(int value, int amount = 1) 
        { 
            Value = value; 
            Amount = amount; 
        }

        // Creates an array of coins.
        public static Coin[] CreateArray(params int[] values) 
        {
            List<Coin> coins = new List<Coin>(values.Length);

            foreach(var value in values)
            {
                coins.Add(new Coin(value, 0));
            }

            return coins.OrderBy(x => -x.Value).ToArray(); ;
        }

        public int TotalValue() => Value * Amount;
        public override string ToString() => $"{Value}x{Amount}";

        public bool CompareTo(Coin other)
        {
            return (Value < other.Value);
        }
    }
}
