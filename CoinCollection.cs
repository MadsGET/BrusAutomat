using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BrusAutomat
{
    class CoinCollection
    {
        public Coin[] Items { get; }

        public CoinCollection(int collectionValue, int[] coinValues) : this(coinValues)
        {
            int newCollectionValue = 0;

            foreach (var coin in Items) 
            {
                while (newCollectionValue + coin.Value <= collectionValue) 
                {                
                    newCollectionValue += coin.Value;
                    coin.Amount++;
                }
            }
        }

        public CoinCollection(params int[] coinValues) 
        {
            Items = Coin.CreateArray(coinValues);
        }

        public int Value() 
        {
            int result = 0;
            foreach (Coin c in Items) result += c.TotalValue();
            return result;
        }

        public Coin GetCoin(int value) 
        {
            foreach (Coin c in Items) 
            {
                if (c.Value == value) return c;
            }

            return null;
        }

        public string ToStringList(bool oneLine = true) 
        {
            string result = "";

            for (int i = 0; i < Items.Length; i++)
            {
                if (oneLine) result += (i != Items.Length - 1) ? $"{Items[i].Value}, " : $"{Items[i].Value}.";
                else result += $"{Items[i]}\n";
            }

            return result;
        }
    }
}
