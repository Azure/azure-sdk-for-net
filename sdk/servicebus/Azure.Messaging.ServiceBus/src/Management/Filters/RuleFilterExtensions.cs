// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml.Linq;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus.Management
{
    internal static class RuleFilterExtensions
    {
        public static RuleFilter ParseFromXElement(XElement xElement)
        {
            var attribute = xElement.Attribute(XName.Get("type", ManagementClientConstants.XmlSchemaInstanceNamespace));
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
            switch (filter)
            {
                case SqlRuleFilter sqlRuleFilter:
                    switch (sqlRuleFilter)
                    {
                        case TrueRuleFilter _:
                            return sqlRuleFilter.Serialize("TrueFilter");

                        case FalseRuleFilter _:
                            return sqlRuleFilter.Serialize("FalseFilter");

                        default:
                            return sqlRuleFilter.Serialize("SqlFilter");
                    }

                case CorrelationRuleFilter correlationRuleFilter:
                    return correlationRuleFilter.Serialize("CorrelationFilter");

                default:
                    throw new NotImplementedException($"filter type {filter.GetType().Name} is not supported.");
            }
        }
    }
}
