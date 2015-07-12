/*****************
 * David Reid
 * Copyright 2015
 *****************/
using System;
using System.Xml;
using System.Xml.Serialization;

using VendingMachine.Entities.Enums;

namespace VendingMachine.Entities
{
    [Serializable]
    public interface VendingMachineItem : IXmlSerializable
    {
        [XmlAttribute]
        string Name;

        [XmlAttribute]
        Decimal Cost;

        [XmlAttribute]
        int Remaining;

        [XmlAttribute]
        string Key;

        [XmlAttribute]
        VendingMachineItemTypes Type;

        void Print();
    }
}
