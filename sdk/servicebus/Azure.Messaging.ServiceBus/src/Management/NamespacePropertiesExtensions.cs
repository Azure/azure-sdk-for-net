// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Xml.Linq;

namespace Azure.Messaging.ServiceBus.Management
{
    internal class NamespacePropertiesExtensions
    {
        public static NamespaceProperties ParseFromContent(string xml)
        {
            try
            {
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "entry")
                    {
                        return ParseFromEntryElement(xDoc);
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex.Message);
            }

            throw new ServiceBusException(false, "Unknown error.");
        }

        private static NamespaceProperties ParseFromEntryElement(XElement xEntry)
        {
            var nsInfo = new NamespaceProperties();

            var nsInfoXml = xEntry.Element(XName.Get("content", ManagementClientConstants.AtomNamespace))?
                .Element(XName.Get("NamespaceInfo", ManagementClientConstants.ServiceBusNamespace));

            if (nsInfoXml == null)
            {
                throw new ServiceBusException(true, "Unknown error.");
            }

            foreach (var element in nsInfoXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "CreatedTime":
                        nsInfo.CreatedTime = DateTimeOffset.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "ModifiedTime":
                        nsInfo.ModifiedTime = DateTimeOffset.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "Name":
                        nsInfo.Name = element.Value;
                        break;
                    case "Alias":
                        nsInfo.Alias = element.Value;
                        break;
                    case "MessagingUnits":
                        _ = int.TryParse(element.Value, out var units);
                        nsInfo.MessagingUnits = units;
                        break;
                    case "NamespaceType":
                            nsInfo.NamespaceType = element.Value;
                        break;
                    case "MessagingSKU":
                            nsInfo.MessagingSku = element.Value;
                        break;
                }
            }

            return nsInfo;
        }
    }
}
