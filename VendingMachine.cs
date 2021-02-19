using System;
using System.Collections.Generic;
using System.Text;

namespace BrusAutomat
{
    class VendingMachine
    {
        public readonly string Name;
        public CoinCollection Coins { get; private set; }
        public ProductCollection Products { get; private set; }
        public readonly int[] AcceptedCoinValues;

        public VendingMachine(string name, Product[] products, params int[] acceptedCoinValues) 
        {
            Name = name;
            Coins = new CoinCollection(acceptedCoinValues);
            Products = new ProductCollection(products);
            AcceptedCoinValues = acceptedCoinValues;
        }

        public bool InsertCoin(int value) 
        {
            Coin fetchedCoin = Coins.GetCoin(value);

            if (fetchedCoin != null)
            {
                fetchedCoin.Amount++;
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool ReturnCoins() 
        {
            if (Coins.Value() <= 0) return false;
            Coins = new CoinCollection(AcceptedCoinValues);
            return true;
        }

        public bool Purchase(string productCode) 
        {
            Product selectedProduct = Products.GetItem(productCode);

            Console.WriteLine(selectedProduct);

            if (selectedProduct != null && Coins.Value() >= selectedProduct.Price)
            {
                int newCoinCollectionValue = Coins.Value() - selectedProduct.Price;
                Coins = new CoinCollection(newCoinCollectionValue, AcceptedCoinValues);
                return true;
            }
            else return false;
        }

        public override string ToString() 
        {
            string result = $"*** {Name} ***\n\n- PRODUCTS -\n";
            result += Products.ToString();
            result += $"\n- Accepted Coins -\n{Coins}\n";
            result += $"\n- CURRENT AMOUNT -\n{Coins.Value()}.00 NOK\n";

            return result;
        }
    }
}
