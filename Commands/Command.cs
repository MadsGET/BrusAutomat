using System;
using System.Collections.Generic;
using System.Text;

namespace BrusAutomat
{
    abstract class Command
    {
        public readonly string Name;
        public readonly int MaxParameterLength;
        protected string MsgError => $"{Name} operation failed: Expected {HelpText}.";
        public string HelpText { get; protected set; } = "'Empty'";

        public Command(string name, int maxParameterLength = 0) 
        {
            Name = name;
            MaxParameterLength = maxParameterLength;
        }

        public abstract string TryExecute(params string[] parameters);
        public bool ValidateName(string other) => other.ToLower() == Name.ToLower();
        protected bool ValidateParameterLength(int length) => length == MaxParameterLength;
        public override string ToString() => $"{Name}";
    }
}
