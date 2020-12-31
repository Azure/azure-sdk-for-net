// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Linq;

    internal static class TopicDescriptionExtensions
    {
        public static TopicDescription ParseFromContent(string xml)
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

            throw new MessagingEntityNotFoundException("Topic was not found");
        }

        public static IList<TopicDescription> ParseCollectionFromContent(string xml)
        {
            try
            {
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var topicList = new List<TopicDescription>();

                        var entryList = xDoc.Elements(XName.Get("entry", ManagementClientConstants.AtomNamespace));
                        foreach (var entry in entryList)
                        {
                            topicList.Add(ParseFromEntryElement(entry));
                        }

                        return topicList;
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex);
            }

            throw new MessagingEntityNotFoundException("No topics were found");
        }

        private static TopicDescription ParseFromEntryElement(XElement xEntry)
        {
            var name = xEntry.Element(XName.Get("title", ManagementClientConstants.AtomNamespace)).Value;
            var tdXml = xEntry.Element(XName.Get("content", ManagementClientConstants.AtomNamespace))?
                .Element(XName.Get("TopicDescription", ManagementClientConstants.ServiceBusNamespace));

            if (tdXml == null)
            {
                throw new MessagingEntityNotFoundException("Topic was not found");
            }

            var topicDesc = new TopicDescription(name);
            foreach (var element in tdXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "DefaultMessageTimeToLive":
                        topicDesc.DefaultMessageTimeToLive = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "MaxSizeInMegabytes":
                        topicDesc.MaxSizeInMB = long.Parse(element.Value);
                        break;
                    case "RequiresDuplicateDetection":
                        topicDesc.RequiresDuplicateDetection = bool.Parse(element.Value);
                        break;
                    case "DuplicateDetectionHistoryTimeWindow":
                        topicDesc.duplicateDetectionHistoryTimeWindow = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "EnableBatchedOperations":
                        topicDesc.EnableBatchedOperations = bool.Parse(element.Value);
                        break;
                    case "FilteringMessagesBeforePublishing":
                        topicDesc.FilteringMessagesBeforePublishing = bool.Parse(element.Value);
                        break;
                    case "IsAnonymousAccessible":
                        topicDesc.IsAnonymousAccessible = bool.Parse(element.Value);
                        break;
                    case "AuthorizationRules":
                        topicDesc.AuthorizationRules = AuthorizationRules.ParseFromXElement(element);
                        break;
                    case "Status":
                        topicDesc.Status = (EntityStatus)Enum.Parse(typeof(EntityStatus), element.Value);
                        break;
                    case "ForwardTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            topicDesc.ForwardTo = element.Value;
                        }
                        break;
                    case "UserMetadata":
                        topicDesc.UserMetadata = element.Value;
                        break;
                    case "SupportOrdering":
                        topicDesc.SupportOrdering = bool.Parse(element.Value);
                        break;
                    case "AutoDeleteOnIdle":
                        topicDesc.AutoDeleteOnIdle = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "EnablePartitioning":
                        topicDesc.EnablePartitioning = bool.Parse(element.Value);
                        break;
                    case "EnableSubscriptionPartitioning":
                        topicDesc.EnableSubscriptionPartitioning = bool.Parse(element.Value);
                        break;
                    case "EnableExpress":
                        topicDesc.EnableExpress = bool.Parse(element.Value);
                        break;
                    case "AccessedAt":
                    case "CreatedAt":
                    case "MessageCount":
                    case "SizeInBytes":
                    case "UpdatedAt":
                    case "CountDetails":
                    case "SubscriptionCount":
                    case "EntityAvailabilityStatus":
                    case "SkippedUpdate":
                        // Ignore known properties
                        // Do nothing
                        break;
                    default:
                        // For unknown properties, keep them as-is for forward proof.
                        if (topicDesc.UnknownProperties == null)
                        {
                            topicDesc.UnknownProperties = new List<object>();
                        }

                        topicDesc.UnknownProperties.Add(element);
                        break;
                }
            }

            return topicDesc;
        }

        public static XDocument Serialize(this TopicDescription description)
        {
            var topicDescriptionElements = new List<object>
            {
                description.DefaultMessageTimeToLive != TimeSpan.MaxValue ? new XElement(XName.Get("DefaultMessageTimeToLive", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DefaultMessageTimeToLive)) : null,
                new XElement(XName.Get("MaxSizeInMegabytes", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.MaxSizeInMB)),
                new XElement(XName.Get("RequiresDuplicateDetection", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.RequiresDuplicateDetection)),
                description.RequiresDuplicateDetection && description.DuplicateDetectionHistoryTimeWindow != default ?
                    new XElement(XName.Get("DuplicateDetectionHistoryTimeWindow", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DuplicateDetectionHistoryTimeWindow))
                    : null,
                new XElement(XName.Get("EnableBatchedOperations", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableBatchedOperations)),
                new XElement(XName.Get("FilteringMessagesBeforePublishing", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.FilteringMessagesBeforePublishing)),
                new XElement(XName.Get("IsAnonymousAccessible", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.IsAnonymousAccessible)),
                description.AuthorizationRules?.Serialize(),
                new XElement(XName.Get("Status", ManagementClientConstants.ServiceBusNamespace), description.Status.ToString()),
                description.ForwardTo != null ? new XElement(XName.Get("ForwardTo", ManagementClientConstants.ServiceBusNamespace), description.ForwardTo) : null,
                description.UserMetadata != null ? new XElement(XName.Get("UserMetadata", ManagementClientConstants.ServiceBusNamespace), description.UserMetadata) : null,
                new XElement(XName.Get("SupportOrdering", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.SupportOrdering)),
                description.AutoDeleteOnIdle != TimeSpan.MaxValue ? new XElement(XName.Get("AutoDeleteOnIdle", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.AutoDeleteOnIdle)) : null,
                new XElement(XName.Get("EnablePartitioning", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnablePartitioning)),
                new XElement(XName.Get("EnableSubscriptionPartitioning", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableSubscriptionPartitioning)),
                new XElement(XName.Get("EnableExpress", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableExpress))
            };

            // Insert unknown properties in the exact order they were in the received xml.
            // Expectation is that servicebus will add any new elements only at the bottom of the xml tree.
            if (description.UnknownProperties != null)
            {
                topicDescriptionElements.AddRange(description.UnknownProperties);
            }

            XDocument doc = new XDocument(
                new XElement(XName.Get("entry", ManagementClientConstants.AtomNamespace),
                    new XElement(XName.Get("content", ManagementClientConstants.AtomNamespace),
                        new XAttribute("type", "application/xml"),
                        new XElement(XName.Get("TopicDescription", ManagementClientConstants.ServiceBusNamespace),
                            topicDescriptionElements
                        ))
                    ));

            return doc;
        }
    }
}