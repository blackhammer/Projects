/*****************
 * David Reid
 * Copyright 2015
 *****************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VendingMachine.Entities;

namespace VendingMachine
{
    public class VendingMachine
    {
        public float CurrentBalance { get; set; }

        protected Dictionary<string, VendingMachineItem> Inventory { get; set; }

        public VendingMachine(VendingMachineItems items)
        {
            Inventory = items.Items.ToDictionary(item => item.Key.ToUpper());
        }

        public void InsertCoin(float money)
        {
            CurrentBalance += money;
        }

        public float RefundBalance()
        {
            float refund = CurrentBalance;
            CurrentBalance = 0;
            return refund;
        }

        public string PrintItems()
        {
            StringBuilder items = new StringBuilder();

            List<VendingMachineItem> sortedItems = Inventory.Values.OrderBy<VendingMachineItem, string>(item => item.Key).ToList<VendingMachineItem>();

            items.AppendLine("\tKey\tName\t\tCost\tRemaining");

            foreach (VendingMachineItem item in Inventory.Values)
            {
                items.AppendLine(item.Print());
            }

            return items.ToString();
        }

        public bool SelectItem(string key, out VendingMachineItem vendingMachineItem)
        {
            VendingMachineItem item = null;
            bool successfulPurchase = false;

            if (Inventory.TryGetValue(key.ToUpper(), out item))
            {
                if (item != null && item.Cost <= CurrentBalance && item.Remaining > 0)
                {
                    CurrentBalance -= item.Cost;
                    item.Remaining--;
                    successfulPurchase = true;
                }
            }

            vendingMachineItem = item;

            return successfulPurchase;
        }

        public VendingMachineItems GetItems()
        {
            return new VendingMachineItems() { Items = Inventory.Values.OrderBy<VendingMachineItem, string>(item => item.Key).ToList<VendingMachineItem>() };
        }
    }
}
