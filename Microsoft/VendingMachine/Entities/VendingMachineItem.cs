﻿/*****************
 * David Reid
 * Copyright 2015
 *****************/
using System;
using System.Xml;
using System.Xml.Serialization;

using VendingMachine.Entities.Enums;

namespace VendingMachine.Entities
{
    public class VendingMachineItem
    {
        public VendingMachineItem(string name, VendingMachineItemTypes type, float cost, int remaining, string key)
        {
            Name = name;
            Type = type;
            Cost = cost;
            Remaining = remaining;
            Key = key;
        }

        public VendingMachineItem()
        {
        }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public float Cost { get; set; }

        [XmlAttribute]
        public int Remaining { get; set; }

        [XmlAttribute]
        public string Key { get; set; }

        [XmlAttribute]
        public VendingMachineItemTypes Type { get; set; }

        public string Print()
        {
            // Order: Key Name Cost Remaining
            return string.Format("\t{0}\t{1}\t${2:F2}\t{3}", Key, Name, Cost, Remaining);
        }
    }
}
