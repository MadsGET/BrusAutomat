using System;
using System.Collections.Generic;
using System.Text;

namespace BrusAutomat.Commands
{
    class Command_Purchase : Command
    {
        private readonly VendingMachine OperationTarget;

        public Command_Purchase(VendingMachine target) : base ("Purchase", 2) 
        {
            OperationTarget = target;
            HelpText = "'Code'";
        }

        private string OperationSuccess(string productName) => $"You purchased {productName.Trim()}.";
        private string OperationFailure => $"Not enough coins or item does not exist.";

        public override string TryExecute(params string[] parameters)
        {
            string codeInput = parameters[1];

            if (ValidateParameterLength(parameters.Length) && OperationTarget != null)
            {
                if (OperationTarget.Purchase(codeInput)) 
                {
                    Product fetchedProduct = OperationTarget.Products.GetItem(codeInput);
                    Console.WriteLine(fetchedProduct);
                    return OperationSuccess(fetchedProduct.Name);
                } 
                else return OperationFailure;
            }

            return MsgError;
        }
    }
}
