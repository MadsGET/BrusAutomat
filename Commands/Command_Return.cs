using System;
using System.Collections.Generic;
using System.Text;

namespace BrusAutomat.Commands
{
    class Command_Return : Command
    {
        public Command_Return(VendingMachine target) : 
        base("Return", 1) 
        {
            OperationTarget = target;
        }

        private VendingMachine OperationTarget;
        
        public override string TryExecute(params string[] parameters)
        {
            if (OperationTarget != null)
            {
                if (!OperationTarget.ReturnCoins()) 
                {
                    return "Vending machine has no coins to return.";
                }
            }

            return "Vending machine has returned your coins.";
        }
    }
}
