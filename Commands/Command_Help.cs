using System;
using System.Collections.Generic;
using System.Text;

namespace BrusAutomat.Commands
{
    class Command_Help : Command
    {
        private readonly string _HelpMsg;

        public Command_Help(List<Command> allCommands) : base("Help", 1) 
        {
            _HelpMsg += "List of available actions\n";

            foreach (Command c in allCommands) 
            {
                _HelpMsg += $"{c} {c.HelpText}\n";
            }

            _HelpMsg += $"{Name} {HelpText}\n";
        }

        public override string TryExecute(params string[] parameters)
        {
            return _HelpMsg;
        }
    }
}
