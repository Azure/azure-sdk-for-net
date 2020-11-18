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
    internal static class SubscriptionPropertiesExtensions
    {
        public static void NormalizeDescription(this SubscriptionProperties description, string baseAddress)
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

        public static string NormalizeForwardToAddress(string forwardTo, string baseAddress)
        {
            baseAddress = new UriBuilder(baseAddress).Uri.ToString();

            if (!Uri.TryCreate(forwardTo, UriKind.Absolute, out Uri forwardToUri))
            {
                forwardToUri = new Uri(new Uri(baseAddress), forwardTo);
            }

            return forwardToUri.AbsoluteUri;
        }

        public static async Task<SubscriptionProperties> ParseResponseAsync(string topicName, Response response, ClientDiagnostics diagnostics)
        {
            try
            {
                string xml = await response.ReadAsStringAsync().ConfigureAwait(false);
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "entry")
                    {
                        return await ParseFromEntryElementAsync(topicName, xDoc, response, diagnostics).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex.Message, innerException: ex);
            }
            throw new ServiceBusException(
                "Subscription was not found",
                ServiceBusFailureReason.MessagingEntityNotFound,
                innerException: await diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false));
        }

        public static async Task<List<SubscriptionProperties>> ParsePagedResponseAsync(string topicName, Response response, ClientDiagnostics diagnostics)
        {
            try
            {
                string xml = await response.ReadAsStringAsync().ConfigureAwait(false);
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var subscriptionList = new List<SubscriptionProperties>();

                        var entryList = xDoc.Elements(XName.Get("entry", AdministrationClientConstants.AtomNamespace));
                        foreach (var entry in entryList)
                        {
                            subscriptionList.Add(await ParseFromEntryElementAsync(topicName, entry, response, diagnostics).ConfigureAwait(false));
                        }

                        return subscriptionList;
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex.Message, innerException: ex);
            }

            throw new ServiceBusException(
                "No subscriptions were found",
                ServiceBusFailureReason.MessagingEntityNotFound,
                innerException: await diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false));
        }

        private static async Task<SubscriptionProperties> ParseFromEntryElementAsync(string topicName, XElement xEntry, Response response, ClientDiagnostics diagnostics)
        {
            var name = xEntry.Element(XName.Get("title", AdministrationClientConstants.AtomNamespace)).Value;
            var subscriptionDesc = new SubscriptionProperties(topicName, name);

            var qdXml = xEntry.Element(XName.Get("content", AdministrationClientConstants.AtomNamespace))?
                .Element(XName.Get("SubscriptionDescription", AdministrationClientConstants.ServiceBusNamespace));

            if (qdXml == null)
            {
                throw new ServiceBusException(
                    "Subscription was not found",
                    ServiceBusFailureReason.MessagingEntityNotFound,
                    innerException: await diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false));
            }

            foreach (var element in qdXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "RequiresSession":
                        subscriptionDesc.RequiresSession = bool.Parse(element.Value);
                        break;
                    case "DeadLetteringOnMessageExpiration":
                        subscriptionDesc.DeadLetteringOnMessageExpiration = bool.Parse(element.Value);
                        break;
                    case "DeadLetteringOnFilterEvaluationExceptions":
                        subscriptionDesc.EnableDeadLetteringOnFilterEvaluationExceptions = bool.Parse(element.Value);
                        break;
                    case "LockDuration":
                        subscriptionDesc.LockDuration = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "DefaultMessageTimeToLive":
                        subscriptionDesc.DefaultMessageTimeToLive = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "MaxDeliveryCount":
                        subscriptionDesc.MaxDeliveryCount = int.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "Status":
                        subscriptionDesc.Status = element.Value;
                        break;
                    case "EnableBatchedOperations":
                        subscriptionDesc.EnableBatchedOperations = bool.Parse(element.Value);
                        break;
                    case "UserMetadata":
                        subscriptionDesc.UserMetadata = element.Value;
                        break;
                    case "AutoDeleteOnIdle":
                        subscriptionDesc.AutoDeleteOnIdle = XmlConvert.ToTimeSpan(element.Value);
                        break;
                    case "ForwardTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            subscriptionDesc.ForwardTo = element.Value;
                        }
                        break;
                    case "ForwardDeadLetteredMessagesTo":
                        if (!string.IsNullOrWhiteSpace(element.Value))
                        {
                            subscriptionDesc.ForwardDeadLetteredMessagesTo = element.Value;
                        }
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

        public static XDocument Serialize(this SubscriptionProperties description)
        {
            var subscriptionDescriptionElements = new List<object>()
            {
                new XElement(XName.Get("LockDuration", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.LockDuration)),
                new XElement(XName.Get("RequiresSession", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.RequiresSession)),
                description.DefaultMessageTimeToLive != TimeSpan.MaxValue ? new XElement(XName.Get("DefaultMessageTimeToLive", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DefaultMessageTimeToLive)) : null,
                new XElement(XName.Get("DeadLetteringOnMessageExpiration", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.DeadLetteringOnMessageExpiration)),
                new XElement(XName.Get("DeadLetteringOnFilterEvaluationExceptions", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableDeadLetteringOnFilterEvaluationExceptions)),
                description.Rule != null ? description.Rule.SerializeRule("DefaultRuleDescription") : null,
                new XElement(XName.Get("MaxDeliveryCount", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.MaxDeliveryCount)),
                new XElement(XName.Get("EnableBatchedOperations", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.EnableBatchedOperations)),
                new XElement(XName.Get("Status", AdministrationClientConstants.ServiceBusNamespace), description.Status.ToString()),
                description.ForwardTo != null ? new XElement(XName.Get("ForwardTo", AdministrationClientConstants.ServiceBusNamespace), description.ForwardTo) : null,
                description.UserMetadata != null ? new XElement(XName.Get("UserMetadata", AdministrationClientConstants.ServiceBusNamespace), description.UserMetadata) : null,
                description.ForwardDeadLetteredMessagesTo != null ? new XElement(XName.Get("ForwardDeadLetteredMessagesTo", AdministrationClientConstants.ServiceBusNamespace), description.ForwardDeadLetteredMessagesTo) : null,
                description.AutoDeleteOnIdle != TimeSpan.MaxValue ? new XElement(XName.Get("AutoDeleteOnIdle", AdministrationClientConstants.ServiceBusNamespace), XmlConvert.ToString(description.AutoDeleteOnIdle)) : null
            };

            if (description.UnknownProperties != null)
            {
                subscriptionDescriptionElements.AddRange(description.UnknownProperties);
            }

            return new XDocument(
                new XElement(XName.Get("entry", AdministrationClientConstants.AtomNamespace),
                    new XElement(XName.Get("content", AdministrationClientConstants.AtomNamespace),
                        new XAttribute("type", "application/xml"),
                        new XElement(XName.Get("SubscriptionDescription", AdministrationClientConstants.ServiceBusNamespace),
                            subscriptionDescriptionElements
                        ))
                ));
        }
    }
}
