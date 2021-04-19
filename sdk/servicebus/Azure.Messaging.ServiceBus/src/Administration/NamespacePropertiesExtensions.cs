// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core.Pipeline;

namespace Azure.Messaging.ServiceBus.Administration
{
    internal class NamespacePropertiesExtensions
    {
        public static async Task<NamespaceProperties> ParseResponseAsync(Response response, ClientDiagnostics diagnostics)
        {
            try
            {
                string xml = await response.ReadAsStringAsync().ConfigureAwait(false);
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "entry")
                    {
                        return await ParseFromEntryElementAsync(xDoc, response, diagnostics).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex.Message, innerException: ex);
            }

            throw new ServiceBusException(
                false,
                "Unknown error.",
                innerException: await diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false));
        }

        private static async Task<NamespaceProperties> ParseFromEntryElementAsync(XElement xEntry, Response response, ClientDiagnostics diagnostics)
        {
            var nsInfo = new NamespaceProperties();

            var nsInfoXml = xEntry.Element(XName.Get("content", AdministrationClientConstants.AtomNamespace))?
                .Element(XName.Get("NamespaceInfo", AdministrationClientConstants.ServiceBusNamespace));

            if (nsInfoXml == null)
            {
                throw new ServiceBusException(
                    false,
                    "Unknown error.",
                    innerException: await diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false));
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
