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
            var expression = xElement.Element(XName.Get("SqlExpression", ManagementClientConstants.SbNs))?.Value;
            if (string.IsNullOrWhiteSpace(expression))
            {
                return null;
            }

            var filter = new SqlFilter(expression);

            var parameters = xElement.Element(XName.Get("Parameters", ManagementClientConstants.SbNs));
            if (parameters != null && parameters.HasElements)
            {
                foreach(var param in parameters.Elements(XName.Get("KeyValueOfstringanyType", ManagementClientConstants.SbNs)))
                {
                    var key = param.Element(XName.Get("Key", ManagementClientConstants.SbNs))?.Value;
                    var value = XmlObjectConvertor.ParseValueObject(param.Element(XName.Get("Value", ManagementClientConstants.SbNs)));
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
                parameterElement = new XElement(XName.Get("Parameters", ManagementClientConstants.SbNs));
                foreach (var param in filter.Parameters)
                {
                    parameterElement.Add(
                        new XElement(XName.Get("KeyValueOfstringanyType", ManagementClientConstants.SbNs),
                            new XElement(XName.Get("Key", ManagementClientConstants.SbNs), param.Key),
                            XmlObjectConvertor.SerializeObject(param.Value)));
                }
            }

            return new XElement(
                XName.Get("Filter", ManagementClientConstants.SbNs),
                new XAttribute(XName.Get("type", ManagementClientConstants.XmlSchemaInstanceNs), filterName),
                new XElement(XName.Get("SqlExpression", ManagementClientConstants.SbNs), filter.SqlExpression),
                parameterElement);
        }
    }
}