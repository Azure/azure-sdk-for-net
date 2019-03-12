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
            var queueDescriptionElements = new List<object>()
            {
                new XElement(XName.Get("LockDuration", ManagementClientConstants.SbNs), XmlConvert.ToString(description.LockDuration)),
                new XElement(XName.Get("MaxSizeInMegabytes", ManagementClientConstants.SbNs), XmlConvert.ToString(description.MaxSizeInMB)),
                new XElement(XName.Get("RequiresDuplicateDetection", ManagementClientConstants.SbNs), XmlConvert.ToString(description.RequiresDuplicateDetection)),
                new XElement(XName.Get("RequiresSession", ManagementClientConstants.SbNs), XmlConvert.ToString(description.RequiresSession)),
                description.DefaultMessageTimeToLive != TimeSpan.MaxValue ? new XElement(XName.Get("DefaultMessageTimeToLive", ManagementClientConstants.SbNs), XmlConvert.ToString(description.DefaultMessageTimeToLive)) : null,
                new XElement(XName.Get("DeadLetteringOnMessageExpiration", ManagementClientConstants.SbNs), XmlConvert.ToString(description.EnableDeadLetteringOnMessageExpiration)),
                description.RequiresDuplicateDetection && description.DuplicateDetectionHistoryTimeWindow != default ?
                    new XElement(XName.Get("DuplicateDetectionHistoryTimeWindow", ManagementClientConstants.SbNs), XmlConvert.ToString(description.DuplicateDetectionHistoryTimeWindow))
                    : null,
                new XElement(XName.Get("MaxDeliveryCount", ManagementClientConstants.SbNs), XmlConvert.ToString(description.MaxDeliveryCount)),
                new XElement(XName.Get("EnableBatchedOperations", ManagementClientConstants.SbNs), XmlConvert.ToString(description.EnableBatchedOperations)),
                description.AuthorizationRules?.Serialize(),
                new XElement(XName.Get("Status", ManagementClientConstants.SbNs), description.Status.ToString()),
                description.ForwardTo != null ? new XElement(XName.Get("ForwardTo", ManagementClientConstants.SbNs), description.ForwardTo) : null,
                description.UserMetadata != null ? new XElement(XName.Get("UserMetadata", ManagementClientConstants.SbNs), description.UserMetadata) : null,
                description.AutoDeleteOnIdle != TimeSpan.MaxValue ? new XElement(XName.Get("AutoDeleteOnIdle", ManagementClientConstants.SbNs), XmlConvert.ToString(description.AutoDeleteOnIdle)) : null,
                new XElement(XName.Get("EnablePartitioning", ManagementClientConstants.SbNs), XmlConvert.ToString(description.EnablePartitioning)),
                description.ForwardDeadLetteredMessagesTo != null ? new XElement(XName.Get("ForwardDeadLetteredMessagesTo", ManagementClientConstants.SbNs), description.ForwardDeadLetteredMessagesTo) : null
            };

            if (description.UnknownProperties != null)
            {
                queueDescriptionElements.AddRange(description.UnknownProperties);
            }

            return new XDocument(
                new XElement(XName.Get("entry", ManagementClientConstants.AtomNs),
                    new XElement(XName.Get("content", ManagementClientConstants.AtomNs),
                        new XAttribute("type", "application/xml"),
                        new XElement(XName.Get("QueueDescription", ManagementClientConstants.SbNs),
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
            var name = xEntry.Element(XName.Get("title", ManagementClientConstants.AtomNs)).Value;
            var qd = new QueueDescription(name);

            var qdXml = xEntry.Element(XName.Get("content", ManagementClientConstants.AtomNs))?
                .Element(XName.Get("QueueDescription", ManagementClientConstants.SbNs));

            if (qdXml == null)
            {
                throw new MessagingEntityNotFoundException("Queue was not found");
            }

            foreach (var element in qdXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "MaxSizeInMegabytes":
                        qd.MaxSizeInMB = Int64.Parse(element.Value);
                        break;
                    case "RequiresDuplicateDetection":
                        qd.RequiresDuplicateDetection = Boolean.Parse(element.Value);
                        break;
                    case "RequiresSession":
                        qd.RequiresSession = Boolean.Parse(element.Value);
                        break;
                    case "DeadLetteringOnMessageExpiration":
                        qd.EnableDeadLetteringOnMessageExpiration = Boolean.Parse(element.Value);
                        break;
                    case "DuplicateDetectionHistoryTimeWindow":
                        qd.duplicateDetectionHistoryTimeWindow = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "LockDuration":
                        qd.LockDuration = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "DefaultMessageTimeToLive":
                        qd.DefaultMessageTimeToLive = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "MaxDeliveryCount":
                        qd.MaxDeliveryCount = Int32.Parse(element.Value);
                        break;
                    case "EnableBatchedOperations":
                        qd.EnableBatchedOperations = Boolean.Parse(element.Value);
                        break;
                    case "Status":
                        qd.Status = (EntityStatus)Enum.Parse(typeof(EntityStatus), element.Value);
                        break;
                    case "AutoDeleteOnIdle":
                        qd.AutoDeleteOnIdle = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "EnablePartitioning":
                        qd.EnablePartitioning = bool.Parse(element.Value);
                        break;
                    case "UserMetadata":
                        qd.UserMetadata = element.Value;
                        break;
                    case "ForwardTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            qd.ForwardTo = element.Value;
                        }
                        break;
                    case "ForwardDeadLetteredMessagesTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            qd.ForwardDeadLetteredMessagesTo = element.Value;
                        }
                        break;
                    case "AuthorizationRules":
                        qd.AuthorizationRules = AuthorizationRules.ParseFromXElement(element);
                        break;
                    case "AccessedAt":
                    case "CreatedAt":
                    case "MessageCount":
                    case "SizeInBytes":
                    case "UpdatedAt":
                    case "CountDetails":
                        // Ignore known properties
                        // Do nothing
                        break;
                    default:
                        // For unknown properties, keep them as-is for forward proof.
                        if (qd.UnknownProperties == null)
                        {
                            qd.UnknownProperties = new List<object>();
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

                        var entryList = xDoc.Elements(XName.Get("entry", ManagementClientConstants.AtomNs));
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

            throw new MessagingEntityNotFoundException("Queue was not found");
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