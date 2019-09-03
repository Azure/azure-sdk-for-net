// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Xml.Linq;
    using Microsoft.Azure.ServiceBus.Filters;
    using Microsoft.Azure.ServiceBus.Management;

    internal static class RuleActionExtensions
    {
        internal static RuleAction ParseFromXElement(XElement xElement)
        {
            var attribute = xElement.Attribute(XName.Get("type", ManagementClientConstants.XmlSchemaInstanceNamespace));
            if (attribute == null)
            {
                return null;
            }

            switch (attribute.Value)
            {
                case "SqlRuleAction":
                    return ParseFromXElementSqlRuleAction(xElement);

                case "EmptyRuleAction":
                    return null;

                default:
                    MessagingEventSource.Log.ManagementSerializationException(
                        $"{nameof(RuleActionExtensions)}_{nameof(ParseFromXElement)}",
                        xElement.ToString());
                    return null;
            }
        }


        static RuleAction ParseFromXElementSqlRuleAction(XElement xElement)
        {
            var expression = xElement.Element(XName.Get("SqlExpression", ManagementClientConstants.ServiceBusNamespace))?.Value;
            if (string.IsNullOrWhiteSpace(expression))
            {
                return null;
            }

            var action = new SqlRuleAction(expression);

            var parameters = xElement.Element(XName.Get("Parameters", ManagementClientConstants.ServiceBusNamespace));
            if (parameters != null && parameters.HasElements)
            {
                foreach (var param in parameters.Elements(XName.Get("KeyValueOfstringanyType", ManagementClientConstants.ServiceBusNamespace)))
                {
                    var key = param.Element(XName.Get("Key", ManagementClientConstants.ServiceBusNamespace))?.Value;
                    var value = XmlObjectConvertor.ParseValueObject(param.Element(XName.Get("Value", ManagementClientConstants.ServiceBusNamespace)));
                    action.Parameters.Add(key, value);
                }
            }
            
            return action;
        }

        public static XElement Serialize(this RuleAction action)
        {
            if (action is SqlRuleAction sqlRuleAction)
            {
                XElement parameterElement = null;
                if (sqlRuleAction.parameters != null)
                {
                    parameterElement = new XElement(XName.Get("Parameters", ManagementClientConstants.ServiceBusNamespace));
                    foreach (var param in sqlRuleAction.Parameters)
                    {
                        parameterElement.Add(
                            new XElement(XName.Get("KeyValueOfstringanyType", ManagementClientConstants.ServiceBusNamespace),
                                new XElement(XName.Get("Key", ManagementClientConstants.ServiceBusNamespace), param.Key),
                                XmlObjectConvertor.SerializeObject(param.Value)));
                    }
                }

                return new XElement(
                        XName.Get("Action", ManagementClientConstants.ServiceBusNamespace),
                        new XAttribute(XName.Get("type", ManagementClientConstants.XmlSchemaInstanceNamespace), nameof(SqlRuleAction)),
                        new XElement(XName.Get("SqlExpression", ManagementClientConstants.ServiceBusNamespace), sqlRuleAction.SqlExpression),
                        parameterElement);
            }
            else
            {
                throw new NotImplementedException($"Rule action of type {action.GetType().Name} is not implemented");
            }
        }
    }
}