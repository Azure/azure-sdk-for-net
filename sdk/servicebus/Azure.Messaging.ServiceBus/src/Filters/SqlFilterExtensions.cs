// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Azure.Messaging.ServiceBus
{
    using System.Xml.Linq;
    using Azure.Messaging.ServiceBus.Filters;
    using Azure.Messaging.ServiceBus.Management;

    internal static class SqlFilterExtensions
    {
        public static Filter ParseFromXElement(XElement xElement)
        {
            var expression = xElement.Element(XName.Get("SqlExpression", ClientConstants.SbNs))?.Value;
            if (string.IsNullOrWhiteSpace(expression))
            {
                return null;
            }

            var filter = new SqlFilter(expression);

            var parameters = xElement.Element(XName.Get("Parameters", ClientConstants.SbNs));
            if (parameters != null && parameters.HasElements)
            {
                foreach(var param in parameters.Elements(XName.Get("KeyValueOfstringanyType", ClientConstants.SbNs)))
                {
                    var key = param.Element(XName.Get("Key", ClientConstants.SbNs))?.Value;
                    var value = XmlObjectConvertor.ParseValueObject(param.Element(XName.Get("Value", ClientConstants.SbNs)));
                    filter.Parameters.Add(key, value);
                }
            }

            return filter;
        }

        public static XElement Serialize(this SqlFilter filter, string filterName)
        {
            XElement parameterElement = null;
            if (filter.parameters != null)
            {
                parameterElement = new XElement(XName.Get("Parameters", ClientConstants.SbNs));
                foreach (var param in filter.Parameters)
                {
                    parameterElement.Add(
                        new XElement(XName.Get("KeyValueOfstringanyType", ClientConstants.SbNs),
                            new XElement(XName.Get("Key", ClientConstants.SbNs), param.Key),
                            XmlObjectConvertor.SerializeObject(param.Value)));
                }
            }

            return new XElement(
                XName.Get("Filter", ClientConstants.SbNs),
                new XAttribute(XName.Get("type", ClientConstants.XmlSchemaInstanceNs), filterName),
                new XElement(XName.Get("SqlExpression", ClientConstants.SbNs), filter.SqlExpression),
                parameterElement);
        }
    }
}