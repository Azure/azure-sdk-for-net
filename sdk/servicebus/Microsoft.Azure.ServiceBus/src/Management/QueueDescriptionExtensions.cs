// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    using System.Xml.Linq;
    using System;
    using System.Collections.Generic;
    using System.Xml;

    internal static class QueueDescriptionExtensions
    {
        public static XDocument Serialize(this QueueDescription description)
        {
            var queueDescriptionElements = new List<XElement>()
            {
                new XElement(XName.Get("LockDuration", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.LockDuration)),
                new XElement(XName.Get("MaxSizeInMegabytes", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.MaxSizeInMB)),
                new XElement(XName.Get("RequiresDuplicateDetection", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.RequiresDuplicateDetection)),
                new XElement(XName.Get("RequiresSession", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.RequiresSession)),
                description.DefaultMessageTimeToLive != TimeSpan.MaxValue ? new XElement(XName.Get("DefaultMessageTimeToLive", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DefaultMessageTimeToLive)) : null,
                new XElement(XName.Get("DeadLetteringOnMessageExpiration", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableDeadLetteringOnMessageExpiration)),
                description.RequiresDuplicateDetection && description.DuplicateDetectionHistoryTimeWindow != default ?
                    new XElement(XName.Get("DuplicateDetectionHistoryTimeWindow", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DuplicateDetectionHistoryTimeWindow))
                    : null,
                new XElement(XName.Get("MaxDeliveryCount", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.MaxDeliveryCount)),
                new XElement(XName.Get("EnableBatchedOperations", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableBatchedOperations)),
                new XElement(XName.Get("IsAnonymousAccessible", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.IsAnonymousAccessible)),
                description.AuthorizationRules?.Serialize(),
                new XElement(XName.Get("Status", ManagementClientConstants.ServiceBusNamespace), description.Status.ToString()),
                description.ForwardTo != null ? new XElement(XName.Get("ForwardTo", ManagementClientConstants.ServiceBusNamespace), description.ForwardTo) : null,
                description.UserMetadata != null ? new XElement(XName.Get("UserMetadata", ManagementClientConstants.ServiceBusNamespace), description.UserMetadata) : null,
                description.internalSupportOrdering.HasValue ? new XElement(XName.Get("SupportOrdering", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.internalSupportOrdering.Value)) : null,
                description.AutoDeleteOnIdle != TimeSpan.MaxValue ? new XElement(XName.Get("AutoDeleteOnIdle", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.AutoDeleteOnIdle)) : null,
                new XElement(XName.Get("EnablePartitioning", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnablePartitioning)),
                description.ForwardDeadLetteredMessagesTo != null ? new XElement(XName.Get("ForwardDeadLetteredMessagesTo", ManagementClientConstants.ServiceBusNamespace), description.ForwardDeadLetteredMessagesTo) : null,
                new XElement(XName.Get("EnableExpress", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableExpress))
            };

            // Insert unknown properties in the exact order they were in the received xml.
            // Expectation is that servicebus will add any new elements only at the bottom of the xml tree.
            if (description.UnknownProperties != null)
            {
                queueDescriptionElements.AddRange(description.UnknownProperties);
            }

            return new XDocument(
                new XElement(XName.Get("entry", ManagementClientConstants.AtomNamespace),
                    new XElement(XName.Get("content", ManagementClientConstants.AtomNamespace),
                        new XAttribute("type", "application/xml"),
                        new XElement(XName.Get("QueueDescription", ManagementClientConstants.ServiceBusNamespace),
                            queueDescriptionElements.ToArray()))));
        }

        public static QueueDescription ParseFromContent(string xml)
        {
            try
            {
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "entry")
                    {
                        return ParseFromEntryElement(xDoc);
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex);
            }

            throw new MessagingEntityNotFoundException("Queue was not found");
        }

        private static QueueDescription ParseFromEntryElement(XElement xEntry)
        {
            var name = xEntry.Element(XName.Get("title", ManagementClientConstants.AtomNamespace)).Value;
            var qdXml = xEntry.Element(XName.Get("content", ManagementClientConstants.AtomNamespace))?
                .Element(XName.Get("QueueDescription", ManagementClientConstants.ServiceBusNamespace));

            if (qdXml == null)
            {
                throw new MessagingEntityNotFoundException("Queue was not found");
            }

            var qd = new QueueDescription(name);
            foreach (var element in qdXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "LockDuration":
                        qd.LockDuration = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "MaxSizeInMegabytes":
                        qd.MaxSizeInMB = Int64.Parse(element.Value);
                        break;
                    case "RequiresDuplicateDetection":
                        qd.RequiresDuplicateDetection = Boolean.Parse(element.Value);
                        break;
                    case "RequiresSession":
                        qd.RequiresSession = Boolean.Parse(element.Value);
                        break;
                    case "DefaultMessageTimeToLive":
                        qd.DefaultMessageTimeToLive = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "DeadLetteringOnMessageExpiration":
                        qd.EnableDeadLetteringOnMessageExpiration = Boolean.Parse(element.Value);
                        break;
                    case "DuplicateDetectionHistoryTimeWindow":
                        qd.duplicateDetectionHistoryTimeWindow = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "MaxDeliveryCount":
                        qd.MaxDeliveryCount = Int32.Parse(element.Value);
                        break;
                    case "EnableBatchedOperations":
                        qd.EnableBatchedOperations = Boolean.Parse(element.Value);
                        break;
                    case "IsAnonymousAccessible":
                        qd.IsAnonymousAccessible = Boolean.Parse(element.Value);
                        break;
                    case "AuthorizationRules":
                        qd.AuthorizationRules = AuthorizationRules.ParseFromXElement(element);
                        break;
                    case "Status":
                        qd.Status = (EntityStatus)Enum.Parse(typeof(EntityStatus), element.Value);
                        break;
                    case "ForwardTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            qd.ForwardTo = element.Value;
                        }
                        break;
                    case "UserMetadata":
                        qd.UserMetadata = element.Value;
                        break;
                    case "SupportOrdering":
                        qd.SupportOrdering = Boolean.Parse(element.Value);
                        break;
                    case "AutoDeleteOnIdle":
                        qd.AutoDeleteOnIdle = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "EnablePartitioning":
                        qd.EnablePartitioning = bool.Parse(element.Value);
                        break;
                    case "ForwardDeadLetteredMessagesTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            qd.ForwardDeadLetteredMessagesTo = element.Value;
                        }
                        break;
                    case "EnableExpress":
                        qd.EnableExpress = bool.Parse(element.Value);
                        break;
                    case "AccessedAt":
                    case "CreatedAt":
                    case "MessageCount":
                    case "SizeInBytes":
                    case "UpdatedAt":
                    case "CountDetails":
                    case "EntityAvailabilityStatus":
                    case "SkippedUpdate":
                        // Ignore known properties
                        // Do nothing
                        break;
                    default:
                        // For unknown properties, keep them as-is for forward proof.
                        if (qd.UnknownProperties == null)
                        {
                            qd.UnknownProperties = new List<XElement>();
                        }

                        qd.UnknownProperties.Add(element);
                        break;
                }
            }

            return qd;
        }

        public static IList<QueueDescription> ParseCollectionFromContent(string xml)
        {
            try
            {
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var queueList = new List<QueueDescription>();

                        var entryList = xDoc.Elements(XName.Get("entry", ManagementClientConstants.AtomNamespace));
                        foreach (var entry in entryList)
                        {
                            queueList.Add(ParseFromEntryElement(entry));
                        }

                        return queueList;
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex);
            }

            throw new MessagingEntityNotFoundException("No queues were found");
        }

        public static void NormalizeDescription(this QueueDescription description, string baseAddress)
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

        private static string NormalizeForwardToAddress(string forwardTo, string baseAddress)
        {
            if (!Uri.TryCreate(forwardTo, UriKind.Absolute, out var forwardToUri))
            {
                if (!baseAddress.EndsWith("/", StringComparison.OrdinalIgnoreCase))
                {
                    baseAddress += "/";
                }

                forwardToUri = new Uri(new Uri(baseAddress), forwardTo);
            }

            return forwardToUri.AbsoluteUri;
        }
    }
}