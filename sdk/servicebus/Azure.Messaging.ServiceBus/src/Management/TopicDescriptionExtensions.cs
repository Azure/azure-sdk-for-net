// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Management
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

                        var entryList = xDoc.Elements(XName.Get("entry", ManagementClientConstants.AtomNs));
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

            throw new MessagingEntityNotFoundException("Topic was not found");
        }

        private static TopicDescription ParseFromEntryElement(XElement xEntry)
        {
            var name = xEntry.Element(XName.Get("title", ManagementClientConstants.AtomNs)).Value;
            var topicDesc = new TopicDescription(name);

            var qdXml = xEntry.Element(XName.Get("content", ManagementClientConstants.AtomNs))?
                .Element(XName.Get("TopicDescription", ManagementClientConstants.SbNs));

            if (qdXml == null)
            {
                throw new MessagingEntityNotFoundException("Topic was not found");
            }

            foreach (var element in qdXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "MaxSizeInMegabytes":
                        topicDesc.MaxSizeInMB = long.Parse(element.Value);
                        break;
                    case "RequiresDuplicateDetection":
                        topicDesc.RequiresDuplicateDetection = bool.Parse(element.Value);
                        break;
                    case "DuplicateDetectionHistoryTimeWindow":
                        topicDesc.duplicateDetectionHistoryTimeWindow = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "DefaultMessageTimeToLive":
                        topicDesc.DefaultMessageTimeToLive = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "EnableBatchedOperations":
                        topicDesc.EnableBatchedOperations = bool.Parse(element.Value);
                        break;
                    case "Status":
                        topicDesc.Status = (EntityStatus)Enum.Parse(typeof(EntityStatus), element.Value);
                        break;
                    case "UserMetadata":
                        topicDesc.UserMetadata = element.Value;
                        break;
                    case "AutoDeleteOnIdle":
                        topicDesc.AutoDeleteOnIdle = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "EnablePartitioning":
                        topicDesc.EnablePartitioning = bool.Parse(element.Value);
                        break;
                    case "SupportOrdering":
                        topicDesc.SupportOrdering = bool.Parse(element.Value);
                        break;
                    case "AuthorizationRules":
                        topicDesc.AuthorizationRules = AuthorizationRules.ParseFromXElement(element);
                        break;
                    case "AccessedAt":
                    case "CreatedAt":
                    case "MessageCount":
                    case "SizeInBytes":
                    case "UpdatedAt":
                    case "CountDetails":
                    case "SubscriptionCount":
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
                description.DefaultMessageTimeToLive != TimeSpan.MaxValue ? new XElement(XName.Get("DefaultMessageTimeToLive", ManagementClientConstants.SbNs), XmlConvert.ToString(description.DefaultMessageTimeToLive)) : null,
                new XElement(XName.Get("MaxSizeInMegabytes", ManagementClientConstants.SbNs), XmlConvert.ToString(description.MaxSizeInMB)),
                new XElement(XName.Get("RequiresDuplicateDetection", ManagementClientConstants.SbNs), XmlConvert.ToString(description.RequiresDuplicateDetection)),
                description.RequiresDuplicateDetection && description.DuplicateDetectionHistoryTimeWindow != default ?
                    new XElement(XName.Get("DuplicateDetectionHistoryTimeWindow", ManagementClientConstants.SbNs), XmlConvert.ToString(description.DuplicateDetectionHistoryTimeWindow))
                    : null,
                new XElement(XName.Get("EnableBatchedOperations", ManagementClientConstants.SbNs), XmlConvert.ToString(description.EnableBatchedOperations)),
                description.AuthorizationRules?.Serialize(),
                new XElement(XName.Get("Status", ManagementClientConstants.SbNs), description.Status.ToString()),
                description.UserMetadata != null ? new XElement(XName.Get("UserMetadata", ManagementClientConstants.SbNs), description.UserMetadata) : null,
                new XElement(XName.Get("SupportOrdering", ManagementClientConstants.SbNs), XmlConvert.ToString(description.SupportOrdering)),
                description.AutoDeleteOnIdle != TimeSpan.MaxValue ? new XElement(XName.Get("AutoDeleteOnIdle", ManagementClientConstants.SbNs), XmlConvert.ToString(description.AutoDeleteOnIdle)) : null,
                new XElement(XName.Get("EnablePartitioning", ManagementClientConstants.SbNs), XmlConvert.ToString(description.EnablePartitioning))
            };

            if (description.UnknownProperties != null)
            {
                topicDescriptionElements.AddRange(description.UnknownProperties);
            }

            XDocument doc = new XDocument(
                new XElement(XName.Get("entry", ManagementClientConstants.AtomNs),
                    new XElement(XName.Get("content", ManagementClientConstants.AtomNs),
                        new XAttribute("type", "application/xml"),
                        new XElement(XName.Get("TopicDescription", ManagementClientConstants.SbNs),
                            topicDescriptionElements
                        ))
                    ));

            return doc;
        }
    }
}