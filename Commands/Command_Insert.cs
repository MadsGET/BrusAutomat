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

            int value = int.Parse(parameters[1]);
            if (value > 0) return OperationTarget.InsertCoin(value);
            else return "SOMETHING ELSE IN INSERT";
        }
    }
}
