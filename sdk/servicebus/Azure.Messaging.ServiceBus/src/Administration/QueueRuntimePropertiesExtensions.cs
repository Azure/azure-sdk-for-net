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
    internal static class QueueRuntimePropertiesExtensions
    {
        public static async Task<QueueRuntimeProperties> ParseResponseAsync(Response response, ClientDiagnostics diagnostics)
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
                "Queue was not found",
                ServiceBusFailureReason.MessagingEntityNotFound,
                innerException: await diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false));
        }

        private static async Task<QueueRuntimeProperties> ParseFromEntryElementAsync(XElement xEntry, Response response, ClientDiagnostics diagnostics)
        {
            var name = xEntry.Element(XName.Get("title", AdministrationClientConstants.AtomNamespace)).Value;
            var qRuntime = new QueueRuntimeProperties(name);

            var qdXml = xEntry.Element(XName.Get("content", AdministrationClientConstants.AtomNamespace))?
                .Element(XName.Get("QueueDescription", AdministrationClientConstants.ServiceBusNamespace));

            if (qdXml == null)
            {
                throw new ServiceBusException(
                    "Queue was not found",
                    ServiceBusFailureReason.MessagingEntityNotFound,
                    innerException: await diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false));
            }

            foreach (var element in qdXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "AccessedAt":
                        qRuntime.AccessedAt = DateTimeOffset.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "CreatedAt":
                        qRuntime.CreatedAt = DateTimeOffset.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "MessageCount":
                        qRuntime.TotalMessageCount = long.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "SizeInBytes":
                        qRuntime.SizeInBytes = long.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "UpdatedAt":
                        qRuntime.UpdatedAt = DateTimeOffset.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "CountDetails":
                        foreach (var countElement in element.Elements())
                        {
                            switch (countElement.Name.LocalName)
                            {
                                case "ActiveMessageCount":
                                    qRuntime.ActiveMessageCount = long.Parse(countElement.Value, CultureInfo.InvariantCulture);
                                    break;
                                case "DeadLetterMessageCount":
                                    qRuntime.DeadLetterMessageCount = long.Parse(countElement.Value, CultureInfo.InvariantCulture);
                                    break;
                                case "ScheduledMessageCount":
                                    qRuntime.ScheduledMessageCount = long.Parse(countElement.Value, CultureInfo.InvariantCulture);
                                    break;
                                case "TransferMessageCount":
                                    qRuntime.TransferMessageCount = long.Parse(countElement.Value, CultureInfo.InvariantCulture);
                                    break;
                                case "TransferDeadLetterMessageCount":
                                    qRuntime.TransferDeadLetterMessageCount = long.Parse(countElement.Value, CultureInfo.InvariantCulture);
                                    break;
                            }
                        }
                        break;
                }
            }

            return qRuntime;
        }

        public static async Task<List<QueueRuntimeProperties>> ParsePagedResponseAsync(Response response, ClientDiagnostics diagnostics)
        {
            try
            {
                string xml = await response.ReadAsStringAsync().ConfigureAwait(false);
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var queueList = new List<QueueRuntimeProperties>();

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
    }
}
