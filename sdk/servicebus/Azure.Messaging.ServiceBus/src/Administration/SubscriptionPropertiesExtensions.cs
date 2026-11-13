// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Azure.Core.Pipeline;

namespace Azure.Messaging.ServiceBus.Administration
{
    internal static class SubscriptionPropertiesExtensions
    {
        public static void NormalizeDescription(this SubscriptionProperties description, string baseAddress)
        {
            if (!string.IsNullOrWhiteSpace(description.ForwardTo))
            {
                description.ForwardTo = NormalizeForwardToAddress(description.ForwardTo, baseAddress);
            }

            if (!string.IsNullOrWhiteSpace(description.ForwardDeadLetteredMessagesTo))
            {
                description.ForwardDeadLetteredMessagesTo = NormalizeForwardToAddress(description.ForwardDeadLetteredMessagesTo, baseAddress);
            }
        }

        public static string NormalizeForwardToAddress(string forwardTo, string baseAddress)
        {
            baseAddress = new UriBuilder(baseAddress).Uri.ToString();

            if (!Uri.TryCreate(forwardTo, UriKind.Absolute, out Uri forwardToUri))
            {
                forwardToUri = new Uri(new Uri(baseAddress), forwardTo);
            }

            return forwardToUri.AbsoluteUri;
        }

        public static async Task<SubscriptionProperties> ParseResponseAsync(string topicName, Response response)
        {
            try
            {
                string xml = await response.ReadAsStringAsync().ConfigureAwait(false);
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "entry")
                    {
                        return ParseFromEntryElement(topicName, xDoc, response);
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex.Message, innerException: ex);
            }
            throw new ServiceBusException(
                "Subscription was not found",
                ServiceBusFailureReason.MessagingEntityNotFound,
                innerException: new RequestFailedException(response));
        }

        public static async Task<List<SubscriptionProperties>> ParsePagedResponseAsync(string topicName, Response response, ClientDiagnostics diagnostics)
        {
            try
            {
                string xml = await response.ReadAsStringAsync().ConfigureAwait(false);
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var subscriptionList = new List<SubscriptionProperties>();

                        var entryList = xDoc.Elements(XName.Get("entry", AdministrationClientConstants.AtomNamespace));
                        foreach (var entry in entryList)
                        {
                            subscriptionList.Add(ParseFromEntryElement(topicName, entry, response));
                        }

                        return subscriptionList;
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex.Message, innerException: ex);
            }

            throw new ServiceBusException(
                "No subscriptions were found",
                ServiceBusFailureReason.MessagingEntityNotFound,
                innerException: new RequestFailedException(response));
        }

        private static SubscriptionProperties ParseFromEntryElement(string topicName, XElement xEntry, Response response)
        {
            var name = xEntry.Element(XName.Get("title", AdministrationClientConstants.AtomNamespace)).Value;
            var subscriptionProperties = new SubscriptionProperties(topicName, name);

            var subscriptionXml = xEntry.Element(XName.Get("content", AdministrationClientConstants.AtomNamespace))?
                .Element(XName.Get("SubscriptionDescription", AdministrationClientConstants.ServiceBusNamespace));

            if (subscriptionXml == null)
            {
                throw new ServiceBusException(
                    "Subscription was not found",
                    ServiceBusFailureReason.MessagingEntityNotFound,
                    innerException: new RequestFailedException(response));
            }

            foreach (var element in subscriptionXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "LockDuration":
                        subscriptionProperties.LockDuration = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "RequiresSession":
                        subscriptionProperties.RequiresSession = bool.Parse(element.Value);
                        break;
                    case "DefaultMessageTimeToLive":
                        subscriptionProperties.DefaultMessageTimeToLive = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "DeadLetteringOnMessageExpiration":
                        subscriptionProperties.DeadLetteringOnMessageExpiration = bool.Parse(element.Value);
                        break;
                    case "DeadLetteringOnFilterEvaluationExceptions":
                        subscriptionProperties.EnableDeadLetteringOnFilterEvaluationExceptions = bool.Parse(element.Value);
                        break;
                    case "MaxDeliveryCount":
                        subscriptionProperties.MaxDeliveryCount = int.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "EnableBatchedOperations":
                        subscriptionProperties.EnableBatchedOperations = bool.Parse(element.Value);
                        break;
                    case "Status":
                        subscriptionProperties.Status = element.Value;
                        break;
                    case "ForwardTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            subscriptionProperties.ForwardTo = element.Value;
                        }
                        break;
                    case "UserMetadata":
                        subscriptionProperties.UserMetadata = element.Value;
                        break;
                    case "ForwardDeadLetteredMessagesTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            subscriptionProperties.ForwardDeadLetteredMessagesTo = element.Value;
                        }
                        break;
                    case "AutoDeleteOnIdle":
                        subscriptionProperties.AutoDeleteOnIdle = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "AccessedAt":
                    case "CreatedAt":
                    case "MessageCount":
                    case "SizeInBytes":
                    case "UpdatedAt":
                    case "CountDetails":
                    case "DefaultRuleDescription":
                    case "EntityAvailabilityStatus":
                    case "SkippedUpdate":
                        // Ignore known properties
                        // Do nothing
                        break;
                    default:
                        // For unknown properties, keep them as-is for forward proof.
                        subscriptionProperties.UnknownProperties ??= [];

                        subscriptionProperties.UnknownProperties.Add(element);
                        break;
                }
            }

            return subscriptionProperties;
        }

        public static XDocument Serialize(this SubscriptionProperties description)
        {
            var subscriptionDescriptionElements = new List<object>()
            {
                new XElement(XName.Get("LockDuration", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.LockDuration)),
                new XElement(XName.Get("RequiresSession", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.RequiresSession)),
                description.DefaultMessageTimeToLive != TimeSpan.MaxValue ? new XElement(XName.Get("DefaultMessageTimeToLive", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DefaultMessageTimeToLive)) : null,
                new XElement(XName.Get("DeadLetteringOnMessageExpiration", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DeadLetteringOnMessageExpiration)),
                new XElement(XName.Get("DeadLetteringOnFilterEvaluationExceptions", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableDeadLetteringOnFilterEvaluationExceptions)),
                description.Rule != null ? description.Rule.SerializeRule("DefaultRuleDescription") : null,
                new XElement(XName.Get("MaxDeliveryCount", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.MaxDeliveryCount)),
                new XElement(XName.Get("EnableBatchedOperations", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableBatchedOperations)),
                new XElement(XName.Get("Status", AdministrationClientConstants.ServiceBusNamespace), description.Status.ToString()),
                description.ForwardTo != null ? new XElement(XName.Get("ForwardTo", AdministrationClientConstants.ServiceBusNamespace), description.ForwardTo) : null,
                description.UserMetadata != null ? new XElement(XName.Get("UserMetadata", AdministrationClientConstants.ServiceBusNamespace), description.UserMetadata) : null,
                description.ForwardDeadLetteredMessagesTo != null ? new XElement(XName.Get("ForwardDeadLetteredMessagesTo", AdministrationClientConstants.ServiceBusNamespace), description.ForwardDeadLetteredMessagesTo) : null,
                description.AutoDeleteOnIdle != TimeSpan.MaxValue ? new XElement(XName.Get("AutoDeleteOnIdle", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.AutoDeleteOnIdle)) : null
            };

            if (description.UnknownProperties != null)
            {
                subscriptionDescriptionElements.AddRange(description.UnknownProperties);
            }

            return new XDocument(
                new XElement(XName.Get("entry", AdministrationClientConstants.AtomNamespace),
                    new XElement(XName.Get("content", AdministrationClientConstants.AtomNamespace),
                        new XAttribute("type", "application/xml"),
                        new XElement(XName.Get("SubscriptionDescription", AdministrationClientConstants.ServiceBusNamespace),
                            subscriptionDescriptionElements
                        ))
                ));
        }
    }
}
