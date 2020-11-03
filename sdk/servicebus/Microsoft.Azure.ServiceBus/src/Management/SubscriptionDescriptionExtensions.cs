// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Linq;

    internal static class SubscriptionDescriptionExtensions
    {
        public static void NormalizeDescription(this SubscriptionDescription description, string baseAddress)
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

        static string NormalizeForwardToAddress(string forwardTo, string baseAddress)
        {
            if (!Uri.TryCreate(forwardTo, UriKind.Absolute, out var forwardToUri))
            {
                if (!baseAddress.EndsWith("/", StringComparison.Ordinal))
                {
                    baseAddress += "/";
                }

                forwardToUri = new Uri(new Uri(baseAddress), forwardTo);
            }

            return forwardToUri.AbsoluteUri;
        }

        public static SubscriptionDescription ParseFromContent(string topicName, string xml)
        {
            try
            {
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "entry")
                    {
                        return ParseFromEntryElement(topicName, xDoc);
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex);
            }

            throw new MessagingEntityNotFoundException("Subscription was not found");
        }

        public static IList<SubscriptionDescription> ParseCollectionFromContent(string topicName, string xml)
        {
            try
            {
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var subscriptionList = new List<SubscriptionDescription>();

                        var entryList = xDoc.Elements(XName.Get("entry", ManagementClientConstants.AtomNamespace));
                        foreach (var entry in entryList)
                        {
                            subscriptionList.Add(ParseFromEntryElement(topicName, entry));
                        }

                        return subscriptionList;
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex);
            }

            throw new MessagingEntityNotFoundException("No subscriptions were found");
        }

        private static SubscriptionDescription ParseFromEntryElement(string topicName, XElement xEntry)
        {
            var name = xEntry.Element(XName.Get("title", ManagementClientConstants.AtomNamespace)).Value;
            var subscriptionDesc = new SubscriptionDescription(topicName, name);

            var qdXml = xEntry.Element(XName.Get("content", ManagementClientConstants.AtomNamespace))?
                .Element(XName.Get("SubscriptionDescription", ManagementClientConstants.ServiceBusNamespace));

            if (qdXml == null)
            {
                throw new MessagingEntityNotFoundException("Subscription was not found");
            }

            foreach (var element in qdXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "LockDuration":
                        subscriptionDesc.LockDuration = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "RequiresSession":
                        subscriptionDesc.RequiresSession = bool.Parse(element.Value);
                        break;
                    case "DefaultMessageTimeToLive":
                        subscriptionDesc.DefaultMessageTimeToLive = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "DeadLetteringOnMessageExpiration":
                        subscriptionDesc.EnableDeadLetteringOnMessageExpiration = bool.Parse(element.Value);
                        break;
                    case "DeadLetteringOnFilterEvaluationExceptions":
                        subscriptionDesc.EnableDeadLetteringOnFilterEvaluationExceptions = bool.Parse(element.Value);
                        break;
                    case "MaxDeliveryCount":
                        subscriptionDesc.MaxDeliveryCount = int.Parse(element.Value);
                        break;
                    case "EnableBatchedOperations":
                        subscriptionDesc.EnableBatchedOperations = bool.Parse(element.Value);
                        break;
                    case "Status":
                        subscriptionDesc.Status = (EntityStatus)Enum.Parse(typeof(EntityStatus), element.Value);
                        break;
                    case "ForwardTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            subscriptionDesc.ForwardTo = element.Value;
                        }
                        break;
                    case "UserMetadata":
                        subscriptionDesc.UserMetadata = element.Value;
                        break;
                    case "ForwardDeadLetteredMessagesTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            subscriptionDesc.ForwardDeadLetteredMessagesTo = element.Value;
                        }
                        break;
                    case "AutoDeleteOnIdle":
                        subscriptionDesc.AutoDeleteOnIdle = XmlConvert.ToTimeSpan(element.Value);
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
                        if (subscriptionDesc.UnknownProperties == null)
                        {
                            subscriptionDesc.UnknownProperties = new List<object>();
                        }

                        subscriptionDesc.UnknownProperties.Add(element);
                        break;
                }
            }

            return subscriptionDesc;
        }

        public static XDocument Serialize(this SubscriptionDescription description)
        {
            var subscriptionDescriptionElements = new List<object>()
            {
                new XElement(XName.Get("LockDuration", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.LockDuration)),
                new XElement(XName.Get("RequiresSession", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.RequiresSession)),
                description.DefaultMessageTimeToLive != TimeSpan.MaxValue ? new XElement(XName.Get("DefaultMessageTimeToLive", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DefaultMessageTimeToLive)) : null,
                new XElement(XName.Get("DeadLetteringOnMessageExpiration", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableDeadLetteringOnMessageExpiration)),
                new XElement(XName.Get("DeadLetteringOnFilterEvaluationExceptions", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableDeadLetteringOnFilterEvaluationExceptions)),
                description.DefaultRuleDescription != null ? description.DefaultRuleDescription.SerializeRule("DefaultRuleDescription") : null,
                new XElement(XName.Get("MaxDeliveryCount", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.MaxDeliveryCount)),
                new XElement(XName.Get("EnableBatchedOperations", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableBatchedOperations)),
                new XElement(XName.Get("Status", ManagementClientConstants.ServiceBusNamespace), description.Status.ToString()),
                description.ForwardTo != null ? new XElement(XName.Get("ForwardTo", ManagementClientConstants.ServiceBusNamespace), description.ForwardTo) : null,
                description.UserMetadata != null ? new XElement(XName.Get("UserMetadata", ManagementClientConstants.ServiceBusNamespace), description.UserMetadata) : null,
                description.ForwardDeadLetteredMessagesTo != null ? new XElement(XName.Get("ForwardDeadLetteredMessagesTo", ManagementClientConstants.ServiceBusNamespace), description.ForwardDeadLetteredMessagesTo) : null,
                description.AutoDeleteOnIdle != TimeSpan.MaxValue ? new XElement(XName.Get("AutoDeleteOnIdle", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.AutoDeleteOnIdle)) : null
            };

            if (description.UnknownProperties != null)
            {
                subscriptionDescriptionElements.AddRange(description.UnknownProperties);
            }

            return new XDocument(
                new XElement(XName.Get("entry", ManagementClientConstants.AtomNamespace),
                    new XElement(XName.Get("content", ManagementClientConstants.AtomNamespace),
                        new XAttribute("type", "application/xml"),
                        new XElement(XName.Get("SubscriptionDescription", ManagementClientConstants.ServiceBusNamespace),
                            subscriptionDescriptionElements
                        ))
                ));
        }
    }
}