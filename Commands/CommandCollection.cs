using System;
using System.Collections.Generic;
using System.Text;

namespace BrusAutomat.Commands
{
    class CommandCollection
    {
        public Command[] Items {get; private set;}
        public readonly string ActionStringList;
        private readonly string msgPrefix = "> ";
        private readonly string msgSuffix = "\n";

        public CommandCollection(Command[] commands) 
        {
            List<Command> newCommands = new List<Command>(commands.Length + 2);
            newCommands.AddRange(commands);
            newCommands.Add(new Command_Exit());
            newCommands.Add(new Command_Help(newCommands));

            Items = newCommands.ToArray();

            ActionStringList += "- VALID ACTIONS -\n";

            for (int i = 0; i < Items.Length; i++)
            {
                ActionStringList += (i != Items.Length - 1) ? $"{Items[i]}, " : $"{Items[i]}.";
            }

        }

        public string TryExecute(string[] input)
        {
            string cmdName = input[0].ToLower();
            string message = "Unknown Command.";

            foreach (Command cmd in Items)
            {
                if (cmd.ValidateName(cmdName))
                {
                    message = cmd.TryExecute(input);
                    break;
                }
            }

            return (message != "") ? msgPrefix + message + msgSuffix : "";
        }
    }
}
