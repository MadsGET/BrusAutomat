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

        public override string TryExecute(params string[] parameters)
        {
            string codeInput = parameters[1];
            if (ValidateParameterLength(parameters.Length) && OperationTarget != null) 
            {
                return OperationTarget.Purchase(codeInput);
            }
            else return MsgError;
        }
    }
}
