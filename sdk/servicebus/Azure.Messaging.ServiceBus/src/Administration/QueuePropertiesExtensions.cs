// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Globalization;
using Azure.Core.Pipeline;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus.Administration
{
    internal static class QueuePropertiesExtensions
    {
        public static XDocument Serialize(this QueueProperties description)
        {
            var queueDescriptionElements = new List<XElement>()
            {
                new XElement(XName.Get("LockDuration", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.LockDuration)),
                new XElement(XName.Get("MaxSizeInMegabytes", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.MaxSizeInMegabytes)),
                new XElement(XName.Get("RequiresDuplicateDetection", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.RequiresDuplicateDetection)),
                new XElement(XName.Get("RequiresSession", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.RequiresSession)),
                description.DefaultMessageTimeToLive != TimeSpan.MaxValue ? new XElement(XName.Get("DefaultMessageTimeToLive", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DefaultMessageTimeToLive)) : null,
                new XElement(XName.Get("DeadLetteringOnMessageExpiration", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DeadLetteringOnMessageExpiration)),
                description.RequiresDuplicateDetection && description.DuplicateDetectionHistoryTimeWindow != default ?
                    new XElement(XName.Get("DuplicateDetectionHistoryTimeWindow", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DuplicateDetectionHistoryTimeWindow))
                    : null,
                new XElement(XName.Get("MaxDeliveryCount", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.MaxDeliveryCount)),
                new XElement(XName.Get("EnableBatchedOperations", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableBatchedOperations)),
                new XElement(XName.Get("IsAnonymousAccessible", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.IsAnonymousAccessible)),
                description.AuthorizationRules?.Serialize(),
                new XElement(XName.Get("Status", AdministrationClientConstants.ServiceBusNamespace), description.Status.ToString()),
                description.ForwardTo != null ? new XElement(XName.Get("ForwardTo", AdministrationClientConstants.ServiceBusNamespace), description.ForwardTo) : null,
                description.UserMetadata != null ? new XElement(XName.Get("UserMetadata", AdministrationClientConstants.ServiceBusNamespace), description.UserMetadata) : null,
                description._internalSupportOrdering.HasValue ? new XElement(XName.Get("SupportOrdering", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description._internalSupportOrdering.Value)) : null,
                description.AutoDeleteOnIdle != TimeSpan.MaxValue ? new XElement(XName.Get("AutoDeleteOnIdle", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.AutoDeleteOnIdle)) : null,
                new XElement(XName.Get("EnablePartitioning", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnablePartitioning)),
                description.ForwardDeadLetteredMessagesTo != null ? new XElement(XName.Get("ForwardDeadLetteredMessagesTo", AdministrationClientConstants.ServiceBusNamespace), description.ForwardDeadLetteredMessagesTo) : null,
                new XElement(XName.Get("EnableExpress", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableExpress))
            };

            // Insert unknown properties in the exact order they were in the received xml.
            // Expectation is that servicebus will add any new elements only at the bottom of the xml tree.
            if (description.UnknownProperties != null)
            {
                queueDescriptionElements.AddRange(description.UnknownProperties);
            }

            return new XDocument(
                new XElement(XName.Get("entry", AdministrationClientConstants.AtomNamespace),
                    new XElement(XName.Get("content", AdministrationClientConstants.AtomNamespace),
                        new XAttribute("type", "application/xml"),
                        new XElement(XName.Get("QueueDescription", AdministrationClientConstants.ServiceBusNamespace),
                            queueDescriptionElements.ToArray()))));
        }

        public static async Task<QueueProperties> ParseResponseAsync(Response response, ClientDiagnostics diagnostics)
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
            response.ContentStream.Position = 0;
            throw new ServiceBusException(
                "Queue was not found",
                ServiceBusFailureReason.MessagingEntityNotFound,
                innerException: await diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false));
        }

        private static async Task<QueueProperties> ParseFromEntryElementAsync(XElement xEntry, Response response, ClientDiagnostics diagnostics)
        {
            var name = xEntry.Element(XName.Get("title", AdministrationClientConstants.AtomNamespace)).Value;

            var qdXml = xEntry.Element(XName.Get("content", AdministrationClientConstants.AtomNamespace))?
                .Element(XName.Get("QueueDescription", AdministrationClientConstants.ServiceBusNamespace));

            if (qdXml == null)
            {
                throw new ServiceBusException(
                    "Queue was not found",
                    ServiceBusFailureReason.MessagingEntityNotFound,
                    innerException: await diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false));
            }

            var properties = new QueueProperties(name);
            foreach (var element in qdXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "LockDuration":
                        properties.LockDuration = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "MaxSizeInMegabytes":
                        properties.MaxSizeInMegabytes = int.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "RequiresDuplicateDetection":
                        properties.RequiresDuplicateDetection = bool.Parse(element.Value);
                        break;
                    case "RequiresSession":
                        properties.RequiresSession = bool.Parse(element.Value);
                        break;
                    case "DefaultMessageTimeToLive":
                        properties.DefaultMessageTimeToLive = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "DeadLetteringOnMessageExpiration":
                        properties.DeadLetteringOnMessageExpiration = bool.Parse(element.Value);
                        break;
                    case "DuplicateDetectionHistoryTimeWindow":
                        properties.DuplicateDetectionHistoryTimeWindow = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "MaxDeliveryCount":
                        properties.MaxDeliveryCount = int.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "EnableBatchedOperations":
                        properties.EnableBatchedOperations = bool.Parse(element.Value);
                        break;
                    case "IsAnonymousAccessible":
                        properties.IsAnonymousAccessible = Boolean.Parse(element.Value);
                        break;
                    case "AuthorizationRules":
                        properties.AuthorizationRules = AuthorizationRules.ParseFromXElement(element);
                        break;
                    case "Status":
                        properties.Status = element.Value;
                        break;
                    case "ForwardTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            properties.ForwardTo = element.Value;
                        }
                        break;
                    case "UserMetadata":
                        properties.UserMetadata = element.Value;
                        break;
                    case "SupportOrdering":
                        properties.SupportOrdering = Boolean.Parse(element.Value);
                        break;
                    case "AutoDeleteOnIdle":
                        properties.AutoDeleteOnIdle = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "EnablePartitioning":
                        properties.EnablePartitioning = bool.Parse(element.Value);
                        break;
                    case "ForwardDeadLetteredMessagesTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            properties.ForwardDeadLetteredMessagesTo = element.Value;
                        }
                        break;
                    case "EnableExpress":
                        properties.EnableExpress = bool.Parse(element.Value);
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
                        if (properties.UnknownProperties == null)
                        {
                            properties.UnknownProperties = new List<XElement>();
                        }

                        properties.UnknownProperties.Add(element);
                        break;
                }
            }

            return properties;
        }

        public static async Task<List<QueueProperties>> ParsePagedResponseAsync(Response response, ClientDiagnostics diagnostics)
        {
            try
            {
                string xml = await response.ReadAsStringAsync().ConfigureAwait(false);
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var queueList = new List<QueueProperties>();

                        var entryList = xDoc.Elements(XName.Get("entry", AdministrationClientConstants.AtomNamespace));
                        foreach (var entry in entryList)
                        {
                            queueList.Add(await ParseFromEntryElementAsync(entry, response, diagnostics).ConfigureAwait(false));
                        }

                        return queueList;
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex.Message, innerException: ex);
            }

            throw new ServiceBusException(
                "No queues were found",
                ServiceBusFailureReason.MessagingEntityNotFound,
                innerException: await diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false));
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
