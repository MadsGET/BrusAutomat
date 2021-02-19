using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BrusAutomat
{
    class ProductCollection
    {
        public Product[] Items { get; }

        public ProductCollection(params Product[] products) 
        {
            Items = products;
        }

        public Product GetItem(string code) 
        {
            foreach (var product in Items) 
            {
                if (product.Code.ToLower() == code.ToLower()) return product;
            }

            return null;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var product in Items) 
            {
                result.Append(product.Name);
                result.Append(' ', 3);
                result.Append($"Price: {product.Price}.00 NOK");
                result.Append(' ', 3);
                result.Append($"Code: {product.Code} \n");
            }

            return result.ToString();
        }
    }
}
