/*****************
 * David Reid
 * Copyright 2015
 *****************/

using System;
using System.Configuration;
using System.Collections.Generic;

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
        }

        static void LoadData()
        {
            VendingMachineConfig.Load();
            VendingMachineItems vendingMachine = VendingMachineConfig.VendingMachineItems;
        }

        static void SaveDummyData()
        {
            //string filePath = ConfigurationManager.AppSettings["VendingMachineDB"];

            VendingMachineItems vendingMachine = new VendingMachineItems();

            vendingMachine.Items.Add(new VendingMachineItem("Coca-Cola", VendingMachineItemTypes.DRINK, 2.00f, 10, "A3"));
            vendingMachine.Items.Add(new VendingMachineItem("Pepsi", VendingMachineItemTypes.DRINK, 2.00f, 10, "A4"));
            vendingMachine.Items.Add(new VendingMachineItem("Vitamin Water", VendingMachineItemTypes.DRINK, 2.00f, 10, "A5"));
            vendingMachine.Items.Add(new VendingMachineItem("Granola Plus", VendingMachineItemTypes.HEALTHBAR, 1.75f, 10, "B3"));
            vendingMachine.Items.Add(new VendingMachineItem("Nature Valley", VendingMachineItemTypes.HEALTHBAR, 1.75f, 10, "B4"));
            vendingMachine.Items.Add(new VendingMachineItem("Oh HENRY", VendingMachineItemTypes.CANDYBAR, 2.25f, 10, "C2"));
            vendingMachine.Items.Add(new VendingMachineItem("Snickers", VendingMachineItemTypes.CANDYBAR, 2.25f, 10, "C3"));
            vendingMachine.Items.Add(new VendingMachineItem("Sun Chips", VendingMachineItemTypes.CHIPS, 2.50f, 10, "D4"));

            //VendingMachineConfig.FilePath = filePath;
            VendingMachineConfig.VendingMachineItems = vendingMachine;
            VendingMachineConfig.Save();
        }
    }
}
