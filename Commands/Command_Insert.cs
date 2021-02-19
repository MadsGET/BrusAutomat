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

        public override string TryExecute(params string[] parameters)
        {
            if (!ValidateParameterLength(parameters.Length) || OperationTarget == null) return MsgError;

            bool isValid = int.TryParse(parameters[1], out int value);
            if (isValid) return OperationTarget.InsertCoin(value);
            else return $"Could not recognize '{parameters[1]}' as a valid coin type.";
        }
    }
}
