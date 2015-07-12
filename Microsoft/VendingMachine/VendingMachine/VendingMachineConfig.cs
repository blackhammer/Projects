/*****************
 * David Reid
 * Copyright 2015
 *****************/

using System;
using System.Collections.Generic;
using System.Xml;

using VendingMachine.Entities;

namespace VendingMachine
{
    public class VendingMachineConfig
    {
        public string FilePath { get; set; }

        public void Load()
        {
        }

        public void Save()
        {
        }

        public List<VendingMachineItem> GetItems()
        {
            return new List<VendingMachineItem>();
        }
    }
}
