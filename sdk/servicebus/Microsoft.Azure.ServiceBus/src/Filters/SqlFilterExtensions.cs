﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System.Xml.Linq;
    using Microsoft.Azure.ServiceBus.Filters;
    using Microsoft.Azure.ServiceBus.Management;

    internal static class SqlFilterExtensions
    {
        public static Filter ParseFromXElement(XElement xElement)
        {
            var expression = xElement.Element(XName.Get("SqlExpression", ManagementClientConstants.ServiceBusNamespace))?.Value;
            if (string.IsNullOrWhiteSpace(expression))
            {
                return null;
            }

            var filter = new SqlFilter(expression);

            var parameters = xElement.Element(XName.Get("Parameters", ManagementClientConstants.ServiceBusNamespace));
            if (parameters != null && parameters.HasElements)
            {
                foreach(var param in parameters.Elements(XName.Get("KeyValueOfstringanyType", ManagementClientConstants.ServiceBusNamespace)))
                {
                    var key = param.Element(XName.Get("Key", ManagementClientConstants.ServiceBusNamespace))?.Value;
                    var value = XmlObjectConvertor.ParseValueObject(param.Element(XName.Get("Value", ManagementClientConstants.ServiceBusNamespace)));
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
                parameterElement = new XElement(XName.Get("Parameters", ManagementClientConstants.ServiceBusNamespace));
                foreach (var param in filter.Parameters)
                {
                    parameterElement.Add(
                        new XElement(XName.Get("KeyValueOfstringanyType", ManagementClientConstants.ServiceBusNamespace),
                            new XElement(XName.Get("Key", ManagementClientConstants.ServiceBusNamespace), param.Key),
                            XmlObjectConvertor.SerializeObject(param.Value)));
                }
            }
            
            return new XElement(
                XName.Get("Filter", ManagementClientConstants.ServiceBusNamespace),
                new XAttribute(XName.Get("type", ManagementClientConstants.XmlSchemaInstanceNamespace), filterName),
                new XElement(XName.Get("SqlExpression", ManagementClientConstants.ServiceBusNamespace), filter.SqlExpression),
                parameterElement);
        }
    }
}