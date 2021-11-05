// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Xml.Linq;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus.Administration
{
    internal static class CorrelationRuleFilterExtensions
    {
        public static RuleFilter ParseFromXElement(XElement xElement)
        {
            var correlationRuleFilter = new CorrelationRuleFilter();
            foreach (var element in xElement.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "CorrelationId":
                        correlationRuleFilter.CorrelationId = element.Value;
                        break;
                    case "MessageId":
                        correlationRuleFilter.MessageId = element.Value;
                        break;
                    case "To":
                        correlationRuleFilter.To = element.Value;
                        break;
                    case "ReplyTo":
                        correlationRuleFilter.ReplyTo = element.Value;
                        break;
                    case "Label":
                        correlationRuleFilter.Subject = element.Value;
                        break;
                    case "SessionId":
                        correlationRuleFilter.SessionId = element.Value;
                        break;
                    case "ReplyToSessionId":
                        correlationRuleFilter.ReplyToSessionId = element.Value;
                        break;
                    case "ContentType":
                        correlationRuleFilter.ContentType = element.Value;
                        break;
                    case "Properties":
                        foreach (var prop in element.Elements(XName.Get("KeyValueOfstringanyType", AdministrationClientConstants.ServiceBusNamespace)))
                        {
                            var key = prop.Element(XName.Get("Key", AdministrationClientConstants.ServiceBusNamespace))?.Value;
                            var value = XmlObjectConvertor.ParseValueObject(prop.Element(XName.Get("Value", AdministrationClientConstants.ServiceBusNamespace)));
                            correlationRuleFilter.ApplicationProperties.Add(key, value);
                        }
                        break;
                    default:
                        ServiceBusEventSource.Log.ManagementSerializationException(
                            $"{nameof(CorrelationRuleFilterExtensions)}_{nameof(ParseFromXElement)}",
                            element.ToString());
                        break;
                }
            }

            return correlationRuleFilter;
        }

        public static XElement Serialize(this CorrelationRuleFilter filter, string filterName)
        {
            XElement parameterElement = new XElement(
                XName.Get(
                    "Properties",
                    AdministrationClientConstants.ServiceBusNamespace));

            foreach (KeyValuePair<string, object> param in filter.ApplicationProperties)
            {
                parameterElement.Add(
                    new XElement(XName.Get("KeyValueOfstringanyType", AdministrationClientConstants.ServiceBusNamespace),
                        new XElement(XName.Get("Key", AdministrationClientConstants.ServiceBusNamespace), param.Key),
                        XmlObjectConvertor.SerializeObject(param.Value)));
            }

            return new XElement(
                XName.Get("Filter", AdministrationClientConstants.ServiceBusNamespace),
                new XAttribute(XName.Get("type", AdministrationClientConstants.XmlSchemaInstanceNamespace), filterName),
                string.IsNullOrWhiteSpace(filter.CorrelationId) ? null :
                    new XElement(XName.Get("CorrelationId", AdministrationClientConstants.ServiceBusNamespace), filter.CorrelationId),
                string.IsNullOrWhiteSpace(filter.MessageId) ? null :
                    new XElement(XName.Get("MessageId", AdministrationClientConstants.ServiceBusNamespace), filter.MessageId),
                string.IsNullOrWhiteSpace(filter.To) ? null :
                    new XElement(XName.Get("To", AdministrationClientConstants.ServiceBusNamespace), filter.To),
                string.IsNullOrWhiteSpace(filter.ReplyTo) ? null :
                    new XElement(XName.Get("ReplyTo", AdministrationClientConstants.ServiceBusNamespace), filter.ReplyTo),
                string.IsNullOrWhiteSpace(filter.Subject) ? null :
                    new XElement(XName.Get("Label", AdministrationClientConstants.ServiceBusNamespace), filter.Subject),
                string.IsNullOrWhiteSpace(filter.SessionId) ? null :
                    new XElement(XName.Get("SessionId", AdministrationClientConstants.ServiceBusNamespace), filter.SessionId),
                string.IsNullOrWhiteSpace(filter.ReplyToSessionId) ? null :
                    new XElement(XName.Get("ReplyToSessionId", AdministrationClientConstants.ServiceBusNamespace), filter.ReplyToSessionId),
                string.IsNullOrWhiteSpace(filter.ContentType) ? null :
                    new XElement(XName.Get("ContentType", AdministrationClientConstants.ServiceBusNamespace), filter.ContentType),
                parameterElement);
        }
    }
}
