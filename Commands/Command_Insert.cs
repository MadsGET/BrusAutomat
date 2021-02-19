using System;
using System.Collections.Generic;
using System.Text;

namespace BrusAutomat.Commands
{
    class Command_Insert : Command
    {

        private readonly VendingMachine OperationTarget;

        public Command_Insert(VendingMachine target) : base("Insert", 2) 
        {
            OperationTarget = target;
            HelpText = "'Amount'";
        }

        private string OperationSuccess(int value) => $"Added a coin with value {value}";
        private string OperationFailure(int value) => $"Invalid coin type {value}";

        public override string TryExecute(params string[] parameters)
        {
            if (ValidateParameterLength(parameters.Length) && OperationTarget != null)
            {
                // Try parse coin value
                int.TryParse(parameters[1], out int coinValue);

                if (coinValue > 0) 
                {
                    bool wasExecuted = OperationTarget.InsertCoin(coinValue);
                    if (wasExecuted) return OperationSuccess(coinValue);
                    else return OperationFailure(coinValue);
                }
            }
            
            return MsgError;
        }
    }
}
