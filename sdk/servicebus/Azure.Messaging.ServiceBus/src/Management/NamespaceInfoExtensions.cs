// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml.Linq;

namespace Azure.Messaging.ServiceBus.Management
{
    internal class NamespaceInfoExtensions
    {
        public static NamespaceInfo ParseFromContent(string xml)
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

        private static NamespaceInfo ParseFromEntryElement(XElement xEntry)
        {
            var nsInfo = new NamespaceInfo();

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
                        nsInfo.CreatedTime = DateTimeOffset.Parse(element.Value);
                        break;
                    case "ModifiedTime":
                        nsInfo.ModifiedTime = DateTimeOffset.Parse(element.Value);
                        break;
                    case "Name":
                        nsInfo.Name = element.Value;
                        break;
                    case "Alias":
                        nsInfo.Alias = element.Value;
                        break;
                    case "MessagingUnits":
                        int.TryParse(element.Value, out var units);
                        nsInfo.MessagingUnits = units;
                        break;
                    case "NamespaceType":
                        if (Enum.TryParse<NamespaceType>(element.Value, out var nsType))
                        {
                            nsInfo.NamespaceType = nsType;
                        }
                        else if (element.Value == "Messaging") // TODO: workaround till next major as it's a breaking change
                        {
                            nsInfo.NamespaceType = NamespaceType.ServiceBus;
                        }
                        else
                        {
                            nsInfo.NamespaceType = NamespaceType.Others;
                        }
                        break;
                    case "MessagingSKU":
                        if (Enum.TryParse<MessagingSku>(element.Value, out var nsSku))
                        {
                            nsInfo.MessagingSku = nsSku;
                        }
                        else
                        {
                            nsInfo.MessagingSku = MessagingSku.Others;
                        }
                        break;
                }
            }

            return nsInfo;
        }
    }
}
