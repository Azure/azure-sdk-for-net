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
                    return SqlFilterExtensions.ParseFromXElement(xElement);
                case "CorrelationFilter":
                    return CorrelationFilterExtensions.ParseFromXElement(xElement);
                case "TrueFilter":
                    return new TrueFilter();
                case "FalseFilter":
                    return new FalseFilter();
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
                case SqlFilter sqlFilter:
                    switch (sqlFilter)
                    {
                        case TrueFilter _:
                            return sqlFilter.Serialize(nameof(TrueFilter));

                        case FalseFilter _:
                            return sqlFilter.Serialize(nameof(FalseFilter));

                        default:
                            return sqlFilter.Serialize(nameof(SqlFilter));
                    }

                case CorrelationFilter correlationFilter:
                    return correlationFilter.Serialize();

                default:
                    throw new NotImplementedException($"filter type {filter.GetType().Name} is not supported.");
            }
        }
    }
}
