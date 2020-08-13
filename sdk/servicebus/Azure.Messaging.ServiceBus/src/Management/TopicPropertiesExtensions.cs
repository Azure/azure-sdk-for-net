// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;

namespace Azure.Messaging.ServiceBus.Management
{
    internal static class TopicPropertiesExtensions
    {
        public static TopicProperties ParseFromContent(string xml)
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

            throw new ServiceBusException("Topic was not found", ServiceBusFailureReason.MessagingEntityNotFound);
        }

        public static List<TopicProperties> ParseCollectionFromContent(string xml)
        {
            try
            {
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var topicList = new List<TopicProperties>();

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
                throw new ServiceBusException(false, ex.Message);
            }

            throw new ServiceBusException("No topics were found", ServiceBusFailureReason.MessagingEntityNotFound);
        }

        private static TopicProperties ParseFromEntryElement(XElement xEntry)
        {
            var name = xEntry.Element(XName.Get("title", ManagementClientConstants.AtomNamespace)).Value;
            var topicDesc = new TopicProperties(name);

            var qdXml = xEntry.Element(XName.Get("content", ManagementClientConstants.AtomNamespace))?
                .Element(XName.Get("TopicDescription", ManagementClientConstants.ServiceBusNamespace));

            if (qdXml == null)
            {
                throw new ServiceBusException("Topic was not found", ServiceBusFailureReason.MessagingEntityNotFound);
            }

            foreach (var element in qdXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "MaxSizeInMegabytes":
                        topicDesc.MaxSizeInMegabytes = long.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "RequiresDuplicateDetection":
                        topicDesc.RequiresDuplicateDetection = bool.Parse(element.Value);
                        break;
                    case "DuplicateDetectionHistoryTimeWindow":
                        topicDesc.DuplicateDetectionHistoryTimeWindow = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "DefaultMessageTimeToLive":
                        topicDesc.DefaultMessageTimeToLive = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "EnableBatchedOperations":
                        topicDesc.EnableBatchedOperations = bool.Parse(element.Value);
                        break;
                    case "Status":
                        topicDesc.Status = element.Value;
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

        public static XDocument Serialize(this TopicProperties description)
        {
            var topicDescriptionElements = new List<object>
            {
                description.DefaultMessageTimeToLive != TimeSpan.MaxValue ? new XElement(XName.Get("DefaultMessageTimeToLive", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DefaultMessageTimeToLive)) : null,
                new XElement(XName.Get("MaxSizeInMegabytes", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.MaxSizeInMegabytes)),
                new XElement(XName.Get("RequiresDuplicateDetection", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.RequiresDuplicateDetection)),
                description.RequiresDuplicateDetection && description.DuplicateDetectionHistoryTimeWindow != default ?
                    new XElement(XName.Get("DuplicateDetectionHistoryTimeWindow", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DuplicateDetectionHistoryTimeWindow))
                    : null,
                new XElement(XName.Get("EnableBatchedOperations", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableBatchedOperations)),
                description.AuthorizationRules?.Serialize(),
                new XElement(XName.Get("Status", ManagementClientConstants.ServiceBusNamespace), description.Status.ToString()),
                description.UserMetadata != null ? new XElement(XName.Get("UserMetadata", ManagementClientConstants.ServiceBusNamespace), description.UserMetadata) : null,
                new XElement(XName.Get("SupportOrdering", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.SupportOrdering)),
                description.AutoDeleteOnIdle != TimeSpan.MaxValue ? new XElement(XName.Get("AutoDeleteOnIdle", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.AutoDeleteOnIdle)) : null,
                new XElement(XName.Get("EnablePartitioning", ManagementClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnablePartitioning))
            };

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
