using System;
using System.Collections.Generic;
using System.Text;

namespace BrusAutomat.Commands
{
    class Command_Exit : Command
    {
        public Command_Exit() : base("Exit") { }

        public override string TryExecute(params string[] parameters)
        {
            
            Environment.Exit(0);
            return "";
        }
    }
}
