// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml.Linq;
using Azure.Messaging.ServiceBus.Management;

namespace Azure.Messaging.ServiceBus.Filters
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
                    MessagingEventSource.Log.ManagementSerializationException(
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
                            return sqlRuleFilter.Serialize(nameof(TrueRuleFilter));

                        case FalseRuleFilter _:
                            return sqlRuleFilter.Serialize(nameof(FalseRuleFilter));

                        default:
                            return sqlRuleFilter.Serialize(nameof(SqlRuleFilter));
                    }

                case CorrelationRuleFilter correlationRuleFilter:
                    return correlationRuleFilter.Serialize();

                default:
                    throw new NotImplementedException($"filter type {filter.GetType().Name} is not supported.");
            }
        }
    }
}
