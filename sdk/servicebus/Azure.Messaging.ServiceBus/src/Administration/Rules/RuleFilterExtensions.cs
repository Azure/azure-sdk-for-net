// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml.Linq;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus.Administration
{
    internal static class RuleFilterExtensions
    {
        public static RuleFilter ParseFromXElement(XElement xElement)
        {
            var attribute = xElement.Attribute(XName.Get("type", AdministrationClientConstants.XmlSchemaInstanceNamespace));
            if (attribute == null)
            {
                return null;
            }

            switch (attribute.Value)
            {
                case "SqlFilter":
                    return SqlRuleFilterExtensions.ParseFromXElement(xElement);
                case "CorrelationFilter":
                    return CorrelationRuleFilterExtensions.ParseFromXElement(xElement);
                case "TrueFilter":
                    return new TrueRuleFilter();
                case "FalseFilter":
                    return new FalseRuleFilter();
                default:
                    ServiceBusEventSource.Log.ManagementSerializationException(
                        $"{nameof(RuleFilterExtensions)}_{nameof(ParseFromXElement)}",
                        xElement.ToString());
                    return null;
            }
        }

        public static XElement Serialize(this RuleFilter filter)
        {
            return filter switch
            {
                SqlRuleFilter sqlRuleFilter => sqlRuleFilter switch
                {
                    TrueRuleFilter => sqlRuleFilter.Serialize("TrueFilter"),
                    FalseRuleFilter => sqlRuleFilter.Serialize("FalseFilter"),
                    _ => sqlRuleFilter.Serialize("SqlFilter")
                },
                CorrelationRuleFilter correlationRuleFilter => correlationRuleFilter.Serialize("CorrelationFilter"),
                _ => throw new NotImplementedException($"filter type {filter.GetType().Name} is not supported.")
            };
        }
    }
}
