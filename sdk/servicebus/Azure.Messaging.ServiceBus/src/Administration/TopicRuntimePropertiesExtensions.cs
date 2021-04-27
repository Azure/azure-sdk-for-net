// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Globalization;
using Azure.Core.Pipeline;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus.Administration
{
    internal static class TopicRuntimePropertiesExtensions
    {
        public static async Task<TopicRuntimeProperties> ParseResponseAsync(Response response, ClientDiagnostics diagnostics)
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

        public static async Task<TopicRuntimeProperties> ParseFromEntryElementAsync(XElement xEntry, Response response, ClientDiagnostics diagnostics)
        {
            var name = xEntry.Element(XName.Get("title", AdministrationClientConstants.AtomNamespace)).Value;
            var topicRuntimeInfo = new TopicRuntimeProperties(name);

            var qdXml = xEntry.Element(XName.Get("content", AdministrationClientConstants.AtomNamespace))?
                .Element(XName.Get("TopicDescription", AdministrationClientConstants.ServiceBusNamespace));

            if (qdXml == null)
            {
                throw new ServiceBusException(
                    "Topic was not found",
                    ServiceBusFailureReason.MessagingEntityNotFound,
                    innerException: await diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false));
            }

            foreach (var element in qdXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "AccessedAt":
                        topicRuntimeInfo.AccessedAt = DateTimeOffset.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "CreatedAt":
                        topicRuntimeInfo.CreatedAt = DateTimeOffset.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "SizeInBytes":
                        topicRuntimeInfo.SizeInBytes = long.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "SubscriptionCount":
                        topicRuntimeInfo.SubscriptionCount = int.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "UpdatedAt":
                        topicRuntimeInfo.UpdatedAt = DateTimeOffset.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "CountDetails":
                        foreach (var countElement in element.Elements())
                        {
                            switch (countElement.Name.LocalName)
                            {
                                case "ScheduledMessageCount":
                                    topicRuntimeInfo.ScheduledMessageCount = long.Parse(countElement.Value, CultureInfo.InvariantCulture);
                                    break;
                            }
                        }

                        break;
                }
            }

            return topicRuntimeInfo;
        }

        public static async Task<List<TopicRuntimeProperties>> ParsePagedResponseAsync(Response response, ClientDiagnostics diagnostics)
        {
            try
            {
                string xml = await response.ReadAsStringAsync().ConfigureAwait(false);
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var topicList = new List<TopicRuntimeProperties>();

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
    }
}
