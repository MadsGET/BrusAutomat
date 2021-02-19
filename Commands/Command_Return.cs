using System;
using System.Collections.Generic;
using System.Text;

namespace BrusAutomat.Commands
{
    class Command_Return : Command
    {
        private readonly VendingMachine OperationTarget;

        public Command_Return(VendingMachine target) : base("Return", 1) 
        {
            OperationTarget = target;
        }
        
        public override string TryExecute(params string[] parameters)
        {
            if (OperationTarget != null) return OperationTarget.ReturnCoins();
            else return MsgError;
        }
    }
}
