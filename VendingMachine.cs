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

        public string InsertCoin(int value) 
        {
            Coin fetchedCoin = Coins.GetCoin(value);

            if (fetchedCoin == null) return $"This machine does not accept coin with value '{value}'.";
            else 
            {
                fetchedCoin.Amount++;
                return $"You have inserted a coin with value {value}.";
            }
        }

        public string ReturnCoins() 
        {
            if (Coins.Value() <= 0) return $"This machine does not have any coins to return.";
            else 
            {
                int previousValue = Coins.Value();
                string previousCollection = Coins.ToStringList(false);

                Coins = new CoinCollection(AcceptedCoinValues);
                return $"The machine has returned coins with a total value of {previousValue}.\n\n{previousCollection}";
            }
        }

        public string Purchase(string productCode) 
        {
            Product selectedProduct = Products.GetItem(productCode);

            if (selectedProduct == null)
            {
                return $"Could not find an item with code '{productCode}'.";
            }
            else if (Coins.Value() < selectedProduct.Price)
            {
                return $"You need {selectedProduct.Price - Coins.Value()} more coins to complete this purchase.";
            }
            else 
            {
                int newCoinCollectionValue = Coins.Value() - selectedProduct.Price;
                Coins = new CoinCollection(newCoinCollectionValue, AcceptedCoinValues);
                return $"You have purchased {selectedProduct}.";
            }
        }

        public override string ToString() 
        {
            string result = $"*** {Name} ***\n\n- PRODUCTS -\n";
            result += Products.ToString();
            result += $"\n- Accepted Coins -\n{Coins.ToStringList()}\n";
            result += $"\n- CURRENT AMOUNT -\n{Coins.Value()}.00 NOK\n";

            return result;
        }
    }
}
