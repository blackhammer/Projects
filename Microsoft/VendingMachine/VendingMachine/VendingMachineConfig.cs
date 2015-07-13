/*****************
 * David Reid
 * Copyright 2015
 *****************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using VendingMachine.Entities;

namespace VendingMachine
{
    public static class VendingMachineConfig
    {
        public static string FilePath { get; set; }

        public static VendingMachineItems VendingMachineItems { get; set; }

        static VendingMachineConfig()
        {
            Initialize();
        }

        public static void Initialize()
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                FilePath = ConfigurationManager.AppSettings["VendingMachineDB"];
            }
        }

        public static void Load()
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                try
                {
                    using (FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(VendingMachineItems));

                        VendingMachineItems = (VendingMachineItems)xmlSerializer.Deserialize(fileStream);
                    }
                }
                catch (Exception)
                {
                    //We could add some extra details about this exception here, eg adding an error code or set an error message to display
                    throw;
                }
            }
        }

        public static void Save()
        {
            if (!string.IsNullOrEmpty(FilePath) && VendingMachineItems != null)
            {
                try
                {
                    using (XmlTextWriter xmlTextWriter = new XmlTextWriter(FilePath, Encoding.UTF8))
                    {

                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(VendingMachineItems));

                        xmlSerializer.Serialize(xmlTextWriter, VendingMachineItems);
                    }
                }
                catch (Exception)
                {
                    //We could add some extra details about this exception here, eg adding an error code or set an error message to display
                    throw;
                }
            }
        }

        public static VendingMachineItems GetItems()
        {
            return VendingMachineItems;
        }
    }
}
