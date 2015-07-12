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

        public VendingMachine()
        {
        }

        public void InsertCoin(float money)
        {
            CurrentBalance += money;
        }

        public void RefundBalance()
        {
            CurrentBalance = 0;
        }

        public List<VendingMachineItem> ListItems()
        {
            return new List<VendingMachineItem>();
        }

        public void SelectItem(string key)
        {
        }
    }
}
