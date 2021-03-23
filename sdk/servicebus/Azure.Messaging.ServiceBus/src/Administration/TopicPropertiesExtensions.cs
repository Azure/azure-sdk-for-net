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
    internal static class TopicPropertiesExtensions
    {
        public static async Task<TopicProperties> ParseResponseAsync(Response response, ClientDiagnostics diagnostics)
        {
            try
            {
                string xml = await response.ReadAsStringAsync().ConfigureAwait(false);
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "entry")
                    {
                        return await ParseFromEntryElementAsync(xDoc, response, diagnostics).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex.Message, innerException: ex);
            }

            throw new ServiceBusException(
                "Topic was not found",
                ServiceBusFailureReason.MessagingEntityNotFound,
                innerException: await diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false));
        }

        public static async Task<List<TopicProperties>> ParsePagedResponseAsync(Response response, ClientDiagnostics diagnostics)
        {
            try
            {
                string xml = await response.ReadAsStringAsync().ConfigureAwait(false);
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var topicList = new List<TopicProperties>();

                        var entryList = xDoc.Elements(XName.Get("entry", AdministrationClientConstants.AtomNamespace));
                        foreach (var entry in entryList)
                        {
                            topicList.Add(await ParseFromEntryElementAsync(entry, response, diagnostics).ConfigureAwait(false));
                        }

                        return topicList;
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex.Message, innerException: ex);
            }

            throw new ServiceBusException(
                "No topics were found",
                ServiceBusFailureReason.MessagingEntityNotFound,
                innerException: await diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false));
        }

        private static async Task<TopicProperties> ParseFromEntryElementAsync(XElement xEntry, Response response, ClientDiagnostics diagnostics)
        {
            var name = xEntry.Element(XName.Get("title", AdministrationClientConstants.AtomNamespace)).Value;
            var topicXml = xEntry.Element(XName.Get("content", AdministrationClientConstants.AtomNamespace))?
                .Element(XName.Get("TopicDescription", AdministrationClientConstants.ServiceBusNamespace));

            if (topicXml == null)
            {
                throw new ServiceBusException(
                    "Topic was not found",
                    ServiceBusFailureReason.MessagingEntityNotFound,
                    innerException: await diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false));
            }

            var topicProperties = new TopicProperties(name);
            foreach (var element in topicXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "DefaultMessageTimeToLive":
                        topicProperties.DefaultMessageTimeToLive = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "MaxSizeInMegabytes":
                        topicProperties.MaxSizeInMegabytes = long.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "RequiresDuplicateDetection":
                        topicProperties.RequiresDuplicateDetection = bool.Parse(element.Value);
                        break;
                    case "DuplicateDetectionHistoryTimeWindow":
                        topicProperties.DuplicateDetectionHistoryTimeWindow = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "EnableBatchedOperations":
                        topicProperties.EnableBatchedOperations = bool.Parse(element.Value);
                        break;
                    case "FilteringMessagesBeforePublishing":
                        topicProperties.FilteringMessagesBeforePublishing = bool.Parse(element.Value);
                        break;
                    case "IsAnonymousAccessible":
                        topicProperties.IsAnonymousAccessible = bool.Parse(element.Value);
                        break;
                    case "AuthorizationRules":
                        topicProperties.AuthorizationRules = AuthorizationRules.ParseFromXElement(element);
                        break;
                    case "Status":
                        topicProperties.Status = element.Value;
                        break;
                    case "ForwardTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            topicProperties.ForwardTo = element.Value;
                        }
                        break;
                    case "UserMetadata":
                        topicProperties.UserMetadata = element.Value;
                        break;
                    case "SupportOrdering":
                        topicProperties.SupportOrdering = bool.Parse(element.Value);
                        break;
                    case "AutoDeleteOnIdle":
                        topicProperties.AutoDeleteOnIdle = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "EnablePartitioning":
                        topicProperties.EnablePartitioning = bool.Parse(element.Value);
                        break;
                    case "EnableSubscriptionPartitioning":
                        topicProperties.EnableSubscriptionPartitioning = bool.Parse(element.Value);
                        break;
                    case "EnableExpress":
                        topicProperties.EnableExpress = bool.Parse(element.Value);
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
                        if (topicProperties.UnknownProperties == null)
                        {
                            topicProperties.UnknownProperties = new List<XElement>();
                        }

                        topicProperties.UnknownProperties.Add(element);
                        break;
                }
            }

            return topicProperties;
        }

        public static XDocument Serialize(this TopicProperties description)
        {
            var topicPropertyElements = new List<XElement>
            {
                description.DefaultMessageTimeToLive != TimeSpan.MaxValue ? new XElement(XName.Get("DefaultMessageTimeToLive", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DefaultMessageTimeToLive)) : null,
                new XElement(XName.Get("MaxSizeInMegabytes", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.MaxSizeInMegabytes)),
                new XElement(XName.Get("RequiresDuplicateDetection", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.RequiresDuplicateDetection)),
                description.RequiresDuplicateDetection && description.DuplicateDetectionHistoryTimeWindow != default ?
                    new XElement(XName.Get("DuplicateDetectionHistoryTimeWindow", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DuplicateDetectionHistoryTimeWindow))
                    : null,
                new XElement(XName.Get("EnableBatchedOperations", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableBatchedOperations)),
                new XElement(XName.Get("FilteringMessagesBeforePublishing", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.FilteringMessagesBeforePublishing)),
                new XElement(XName.Get("IsAnonymousAccessible", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.IsAnonymousAccessible)),
                description.AuthorizationRules?.Serialize(),
                new XElement(XName.Get("Status", AdministrationClientConstants.ServiceBusNamespace), description.Status.ToString()),
                description.ForwardTo != null ? new XElement(XName.Get("ForwardTo", AdministrationClientConstants.ServiceBusNamespace), description.ForwardTo) : null,
                description.UserMetadata != null ? new XElement(XName.Get("UserMetadata", AdministrationClientConstants.ServiceBusNamespace), description.UserMetadata) : null,
                new XElement(XName.Get("SupportOrdering", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.SupportOrdering)),
                description.AutoDeleteOnIdle != TimeSpan.MaxValue ? new XElement(XName.Get("AutoDeleteOnIdle", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.AutoDeleteOnIdle)) : null,
                new XElement(XName.Get("EnablePartitioning", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnablePartitioning)),
                new XElement(XName.Get("EnableSubscriptionPartitioning", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableSubscriptionPartitioning)),
                new XElement(XName.Get("EnableExpress", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableExpress))
            };

            // Insert unknown properties in the exact order they were in the received xml.
            // Expectation is that servicebus will add any new elements only at the bottom of the xml tree.
            if (description.UnknownProperties != null)
            {
                topicPropertyElements.AddRange(description.UnknownProperties);
            }

            XDocument doc = new XDocument(
                new XElement(XName.Get("entry", AdministrationClientConstants.AtomNamespace),
                    new XElement(XName.Get("content", AdministrationClientConstants.AtomNamespace),
                        new XAttribute("type", "application/xml"),
                        new XElement(XName.Get("TopicDescription", AdministrationClientConstants.ServiceBusNamespace),
                            topicPropertyElements
                        ))
                    ));

            return doc;
        }
    }
}
