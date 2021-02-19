using System;
using System.Collections.Generic;
using System.Text;

namespace BrusAutomat
{
    class Product
    {
        public readonly string Name;
        public readonly int Price;
        public readonly string Code;

        public Product(string name, int price, string productCode) 
        {
            Name = name;
            Price = price;
            Code = productCode;
        }

        public override string ToString()
        {
            return $"{Name} Price: {Price}.00 NOK Code: {Code}";
        }
    }
}
