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

        public VendingMachine(VendingMachineItems items )
        {
            Inventory = items.Items.ToDictionary(item => item.Key);
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
            StringBuilder items = new StringBuilder()

            return items.ToString();
        }

        public void SelectItem(string key)
        {

        }
    }
}
