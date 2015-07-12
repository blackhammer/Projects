/*****************
 * David Reid
 * Copyright 2015
 *****************/
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

using VendingMachine.Entities.Enums;

namespace VendingMachine.Entities
{
    public class VendingMachineItems 
    {
        public List<VendingMachineItem> Items { get; set; }

        public VendingMachineItems()
        {
            Items = new List<VendingMachineItem>();
        }
    }
}
