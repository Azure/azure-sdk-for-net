// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;

namespace Azure.Messaging.ServiceBus.Administration
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

                        var entryList = xDoc.Elements(XName.Get("entry", AdministrationClientConstants.AtomNamespace));
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
            var name = xEntry.Element(XName.Get("title", AdministrationClientConstants.AtomNamespace)).Value;
            var topicDesc = new TopicProperties(name);

            var qdXml = xEntry.Element(XName.Get("content", AdministrationClientConstants.AtomNamespace))?
                .Element(XName.Get("TopicDescription", AdministrationClientConstants.ServiceBusNamespace));

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
                description.DefaultMessageTimeToLive != TimeSpan.MaxValue ? new XElement(XName.Get("DefaultMessageTimeToLive", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DefaultMessageTimeToLive)) : null,
                new XElement(XName.Get("MaxSizeInMegabytes", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.MaxSizeInMegabytes)),
                new XElement(XName.Get("RequiresDuplicateDetection", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.RequiresDuplicateDetection)),
                description.RequiresDuplicateDetection && description.DuplicateDetectionHistoryTimeWindow != default ?
                    new XElement(XName.Get("DuplicateDetectionHistoryTimeWindow", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DuplicateDetectionHistoryTimeWindow))
                    : null,
                new XElement(XName.Get("EnableBatchedOperations", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableBatchedOperations)),
                description.AuthorizationRules?.Serialize(),
                new XElement(XName.Get("Status", AdministrationClientConstants.ServiceBusNamespace), description.Status.ToString()),
                description.UserMetadata != null ? new XElement(XName.Get("UserMetadata", AdministrationClientConstants.ServiceBusNamespace), description.UserMetadata) : null,
                new XElement(XName.Get("SupportOrdering", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.SupportOrdering)),
                description.AutoDeleteOnIdle != TimeSpan.MaxValue ? new XElement(XName.Get("AutoDeleteOnIdle", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.AutoDeleteOnIdle)) : null,
                new XElement(XName.Get("EnablePartitioning", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnablePartitioning))
            };

            if (description.UnknownProperties != null)
            {
                topicDescriptionElements.AddRange(description.UnknownProperties);
            }

            XDocument doc = new XDocument(
                new XElement(XName.Get("entry", AdministrationClientConstants.AtomNamespace),
                    new XElement(XName.Get("content", AdministrationClientConstants.AtomNamespace),
                        new XAttribute("type", "application/xml"),
                        new XElement(XName.Get("TopicDescription", AdministrationClientConstants.ServiceBusNamespace),
                            topicDescriptionElements
                        ))
                    ));

            return doc;
        }
    }
}
