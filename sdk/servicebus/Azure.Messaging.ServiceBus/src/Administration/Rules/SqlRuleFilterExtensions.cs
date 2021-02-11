// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Xml.Linq;

namespace Azure.Messaging.ServiceBus.Administration
{
    internal static class SqlRuleFilterExtensions
    {
        internal static RuleFilter ParseFromXElement(XElement xElement)
        {
            var expression = xElement.Element(XName.Get("SqlExpression", AdministrationClientConstants.ServiceBusNamespace))?.Value;
            if (string.IsNullOrWhiteSpace(expression))
            {
                return null;
            }

            var filter = new SqlRuleFilter(expression);

            var parameters = xElement.Element(XName.Get("Parameters", AdministrationClientConstants.ServiceBusNamespace));
            if (parameters != null && parameters.HasElements)
            {
                foreach (var param in parameters.Elements(XName.Get("KeyValueOfstringanyType", AdministrationClientConstants.ServiceBusNamespace)))
                {
                    var key = param.Element(XName.Get("Key", AdministrationClientConstants.ServiceBusNamespace))?.Value;
                    var value = XmlObjectConvertor.ParseValueObject(param.Element(XName.Get("Value", AdministrationClientConstants.ServiceBusNamespace)));
                    filter.Parameters.Add(key, value);
                }
            }
            return filter;
        }

        public static XElement Serialize(this SqlRuleFilter filter, string filterName)
        {
            XElement parameterElement = null;
            if (filter.Parameters != null)
            {
                parameterElement = new XElement(XName.Get("Parameters", AdministrationClientConstants.ServiceBusNamespace));
                foreach (var param in filter.Parameters)
                {
                    parameterElement.Add(
                        new XElement(XName.Get("KeyValueOfstringanyType", AdministrationClientConstants.ServiceBusNamespace),
                            new XElement(XName.Get("Key", AdministrationClientConstants.ServiceBusNamespace), param.Key),
                            XmlObjectConvertor.SerializeObject(param.Value)));
                }
            }

            return new XElement(
                XName.Get("Filter", AdministrationClientConstants.ServiceBusNamespace),
                new XAttribute(XName.Get("type", AdministrationClientConstants.XmlSchemaInstanceNamespace), filterName),
                new XElement(XName.Get("SqlExpression", AdministrationClientConstants.ServiceBusNamespace), filter.SqlExpression),
                parameterElement);
        }
    }
}
