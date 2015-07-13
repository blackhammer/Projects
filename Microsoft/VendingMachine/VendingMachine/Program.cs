/*****************
 * David Reid
 * Copyright 2015
 *****************/

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

using VendingMachine.Entities;
using VendingMachine.Entities.Enums;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachineConfig.Load();
            VendingMachine vendingMachine = new VendingMachine(VendingMachineConfig.VendingMachineItems);

            Console.Out.WriteLine("Welcome to the Vending Machine! Enjoy your snack");
            Console.Out.WriteLine(Instructions());

            bool exit = false;

            while (!exit)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.KeyChar)
                {
                    case '1':
                    {
                        Console.Out.WriteLine(vendingMachine.PrintItems());
                        break;
                    }
                    case '2':
                    {
                        Console.Out.WriteLine("How much money will you insert? (e.g 0.50 or 1)");
                        string userInput = Console.In.ReadLine();

                        float money = 0.0f;
                        if (float.TryParse(userInput, out money) && money > 0.0f)
                        {
                            vendingMachine.InsertCoin(money);
                            Console.Out.WriteLine(string.Format("Current Balance: ${0:F2}.", vendingMachine.CurrentBalance));
                        }
                        else
                        {
                            Console.Out.WriteLine("That is not a valid amount.");
                        }
                        break;
                    }
                    case '3':
                    {
                        Console.Out.WriteLine(string.Format("Current Balance: ${0:F2}.", vendingMachine.CurrentBalance));
                        break;
                    }
                    case '4':
                    {
                        Console.Out.WriteLine("Enter the key for the snack that you want:");
                        string userInput = Console.In.ReadLine();

                        VendingMachineItem item = null;
                        bool success = vendingMachine.SelectItem(userInput, out item);
                        if (success)
                        {
                            Console.Out.WriteLine("You successfully purchased {0}.", item.Name);

                            if (vendingMachine.CurrentBalance > 0.0)
                            {
                                Console.Out.WriteLine("Your change is ${0:F2}.", vendingMachine.RefundBalance());
                            }
                        }
                        else
                        {
                            if (item == null)
                            {
                                Console.Out.WriteLine("The key entered is not valid.");
                            }
                            else if (item.Remaining == 0)
                            {
                                Console.Out.WriteLine("{0} is sold out.", item.Name);
                            }
                            else if (item.Cost > vendingMachine.CurrentBalance)
                            {
                                Console.Out.WriteLine(string.Format("There is not enough money in the machine. Please add ${0:F2}.", item.Cost - vendingMachine.CurrentBalance));
                            }
                            else
                            {
                                Console.Out.WriteLine("There was an unexpected error making this purchase...");
                            }
                        }
                        break;
                    }
                    case '5':
                    {
                        float refundAmount = vendingMachine.RefundBalance();
                        if (refundAmount > 0.0f)
                        {
                            Console.Out.WriteLine(string.Format("Your change is: ${0:F2}.", refundAmount));
                        }
                        else
                        {
                            Console.Out.WriteLine("You did not insert any money.");
                        }
                        break;
                    }
                    case 'r':
                    {
                        ResetData();
                        vendingMachine = new VendingMachine(VendingMachineConfig.VendingMachineItems);
                        Console.Out.WriteLine("The data has been reset.");
                        break;
                    }
                    case 'q':
                    {
                        exit = true;
                        VendingMachineConfig.VendingMachineItems = vendingMachine.GetItems();
                        VendingMachineConfig.Save();
                        break;
                    }
                    default:
                    {
                        Console.Out.WriteLine("\nI did not understand your request.");
                        Console.Out.WriteLine(Instructions());
                        break;
                    }
                }
            }

            Console.Out.WriteLine("Good bye!\nPress ENTER key to continue...");
            Console.In.Read();
        }

        static string Instructions()
        {
            StringBuilder instructions = new StringBuilder();
            instructions.AppendLine("Press 1 to list items");
            instructions.AppendLine("Press 2 to insert money");
            instructions.AppendLine("Press 3 to show balance");
            instructions.AppendLine("Press 4 to select an item");
            instructions.AppendLine("Press 5 to get a refund");
            instructions.AppendLine("Press r to reset the data");
            instructions.AppendLine("Press q to quit");

            return instructions.ToString();
        }

        static void LoadData()
        {
            VendingMachineConfig.Load();
            VendingMachineItems vendingMachine = VendingMachineConfig.VendingMachineItems;
        }

        static void ResetData()
        {
            VendingMachineItems vendingMachine = new VendingMachineItems();

            vendingMachine.Items.Add(new VendingMachineItem("Coca-Cola", VendingMachineItemTypes.DRINK, 2.00f, 10, "A3"));
            vendingMachine.Items.Add(new VendingMachineItem("Gatorade", VendingMachineItemTypes.DRINK, 2.00f, 10, "A4"));
            vendingMachine.Items.Add(new VendingMachineItem("Vitamin Water", VendingMachineItemTypes.DRINK, 2.00f, 10, "A5"));
            vendingMachine.Items.Add(new VendingMachineItem("Granola Plus", VendingMachineItemTypes.HEALTHBAR, 1.75f, 10, "B3"));
            vendingMachine.Items.Add(new VendingMachineItem("Nature Valley", VendingMachineItemTypes.HEALTHBAR, 1.75f, 10, "B4"));
            vendingMachine.Items.Add(new VendingMachineItem("Oh HENRY", VendingMachineItemTypes.CANDYBAR, 2.25f, 10, "C2"));
            vendingMachine.Items.Add(new VendingMachineItem("Snickers", VendingMachineItemTypes.CANDYBAR, 2.25f, 10, "C3"));
            vendingMachine.Items.Add(new VendingMachineItem("Sun Chips", VendingMachineItemTypes.CHIPS, 2.50f, 10, "D4"));
            
            VendingMachineConfig.VendingMachineItems = vendingMachine;
            VendingMachineConfig.Save();
        }
    }
}
