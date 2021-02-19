﻿using BrusAutomat.Commands;
using System;

namespace BrusAutomat
{
    class Program
    {

        static readonly Product[] products = new[]
        {
            new Product("Coca-Cola 500ml", 49, "f535"),
            new Product("Sprite 250ml   ", 25, "f635"),
            new Product("Espresso 133ml ", 30, "g989"),
            new Product("Redbull 600ml  ", 60, "r243"),
        };
        static readonly VendingMachine VendingMachine = new VendingMachine("Soda Vending Machine", products, 1, 5, 10, 25);


        static readonly Command[] actions = new Command[]
        {
            new Command_Purchase(VendingMachine),
            new Command_Insert(VendingMachine),
            new Command_Return(VendingMachine),
        };
        static readonly CommandCollection commands = new CommandCollection(actions);


        static void Main(string[] args)
        {
            string lastAction = "Type 'Help' for more information.\n";

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{VendingMachine}\n{commands.ActionStringList}\n");
                Console.Write(lastAction + "-> ");
                lastAction = commands.TryExecute(Console.ReadLine().Split(" "));
            }
        }
    }
}
