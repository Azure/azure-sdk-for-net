// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Globalization;

namespace Azure.Messaging.ServiceBus.Management
{
    internal static class QueuePropertiesExtensions
    {
        public static XDocument Serialize(this QueueProperties description)
        {
            var queueDescriptionElements = new List<object>()
            {
                new XElement(XName.Get("LockDuration", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.LockDuration)),
                new XElement(XName.Get("MaxSizeInMegabytes", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.MaxSizeInMegabytes)),
                new XElement(XName.Get("RequiresDuplicateDetection", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.RequiresDuplicateDetection)),
                new XElement(XName.Get("RequiresSession", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.RequiresSession)),
                description.DefaultMessageTimeToLive != TimeSpan.MaxValue ? new XElement(XName.Get("DefaultMessageTimeToLive", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DefaultMessageTimeToLive)) : null,
                new XElement(XName.Get("DeadLetteringOnMessageExpiration", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DeadLetteringOnMessageExpiration)),
                description.RequiresDuplicateDetection && description.DuplicateDetectionHistoryTimeWindow != default ?
                    new XElement(XName.Get("DuplicateDetectionHistoryTimeWindow", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DuplicateDetectionHistoryTimeWindow))
                    : null,
                new XElement(XName.Get("MaxDeliveryCount", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.MaxDeliveryCount)),
                new XElement(XName.Get("EnableBatchedOperations", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableBatchedOperations)),
                description.AuthorizationRules?.Serialize(),
                new XElement(XName.Get("Status", ManagementClientConstants.ServiceBusNamespace), description.Status.ToString()),
                description.ForwardTo != null ? new XElement(XName.Get("ForwardTo", ManagementClientConstants.ServiceBusNamespace), description.ForwardTo) : null,
                description.UserMetadata != null ? new XElement(XName.Get("UserMetadata", ManagementClientConstants.ServiceBusNamespace), description.UserMetadata) : null,
                description.AutoDeleteOnIdle != TimeSpan.MaxValue ? new XElement(XName.Get("AutoDeleteOnIdle", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.AutoDeleteOnIdle)) : null,
                new XElement(XName.Get("EnablePartitioning", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnablePartitioning)),
                description.ForwardDeadLetteredMessagesTo != null ? new XElement(XName.Get("ForwardDeadLetteredMessagesTo", ManagementClientConstants.ServiceBusNamespace), description.ForwardDeadLetteredMessagesTo) : null
            };

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

        /// <summary>
        ///
        /// </summary>
        public static QueueProperties ParseFromContent(string xml)
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
                throw new ServiceBusException(false, ex.Message);
            }

            throw new ServiceBusException("Queue was not found", ServiceBusFailureReason.MessagingEntityNotFound);
        }

        private static QueueProperties ParseFromEntryElement(XElement xEntry)
        {
            var name = xEntry.Element(XName.Get("title", ManagementClientConstants.AtomNamespace)).Value;
            var properties = new QueueProperties(name);

            var qdXml = xEntry.Element(XName.Get("content", ManagementClientConstants.AtomNamespace))?
                .Element(XName.Get("QueueDescription", ManagementClientConstants.ServiceBusNamespace));

            if (qdXml == null)
            {
                throw new ServiceBusException("Queue was not found", ServiceBusFailureReason.MessagingEntityNotFound);
            }

            foreach (var element in qdXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "MaxSizeInMegabytes":
                        properties.MaxSizeInMegabytes = int.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "RequiresDuplicateDetection":
                        properties.RequiresDuplicateDetection = bool.Parse(element.Value);
                        break;
                    case "RequiresSession":
                        properties.RequiresSession = bool.Parse(element.Value);
                        break;
                    case "DeadLetteringOnMessageExpiration":
                        properties.DeadLetteringOnMessageExpiration = bool.Parse(element.Value);
                        break;
                    case "DuplicateDetectionHistoryTimeWindow":
                        properties.DuplicateDetectionHistoryTimeWindow = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "LockDuration":
                        properties.LockDuration = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "DefaultMessageTimeToLive":
                        properties.DefaultMessageTimeToLive = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "MaxDeliveryCount":
                        properties.MaxDeliveryCount = int.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "EnableBatchedOperations":
                        properties.EnableBatchedOperations = bool.Parse(element.Value);
                        break;
                    case "Status":
                        properties.Status = element.Value;
                        break;
                    case "AutoDeleteOnIdle":
                        properties.AutoDeleteOnIdle = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "EnablePartitioning":
                        properties.EnablePartitioning = bool.Parse(element.Value);
                        break;
                    case "UserMetadata":
                        properties.UserMetadata = element.Value;
                        break;
                    case "ForwardTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            properties.ForwardTo = element.Value;
                        }
                        break;
                    case "ForwardDeadLetteredMessagesTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            properties.ForwardDeadLetteredMessagesTo = element.Value;
                        }
                        break;
                    case "AuthorizationRules":
                        properties.AuthorizationRules = AuthorizationRules.ParseFromXElement(element);
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
                        if (properties.UnknownProperties == null)
                        {
                            properties.UnknownProperties = new List<object>();
                        }

                        properties.UnknownProperties.Add(element);
                        break;
                }
            }

            return properties;
        }

        public static List<QueueProperties> ParseCollectionFromContent(string xml)
        {
            try
            {
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var queueList = new List<QueueProperties>();

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
                throw new ServiceBusException(false, ex.Message);
            }

            throw new ServiceBusException("No queues were found", ServiceBusFailureReason.MessagingEntityNotFound);
        }

        public static void NormalizeDescription(this QueueProperties description, string baseAddress)
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
            baseAddress = new UriBuilder(baseAddress).Uri.ToString();

            if (!Uri.TryCreate(forwardTo, UriKind.Absolute, out Uri forwardToUri))
            {
                forwardToUri = new Uri(new Uri(baseAddress), forwardTo);
            }

            return forwardToUri.AbsoluteUri;
        }
    }
}
