// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Azure.Messaging.ServiceBus.Management
{
    internal static class QueueRuntimeInfoExtensions
    {
        public static QueueRuntimeInfo ParseFromContent(string xml)
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

            throw new ServiceBusException("Queue was not found", ServiceBusException.FailureReason.MessagingEntityNotFound);
        }

        private static QueueRuntimeInfo ParseFromEntryElement(XElement xEntry)
        {
            var name = xEntry.Element(XName.Get("title", ManagementClientConstants.AtomNamespace)).Value;
            var qRuntime = new QueueRuntimeInfo(name);

            var qdXml = xEntry.Element(XName.Get("content", ManagementClientConstants.AtomNamespace))?
                .Element(XName.Get("QueueDescription", ManagementClientConstants.ServiceBusNamespace));

            if (qdXml == null)
            {
                throw new ServiceBusException("Queue was not found", ServiceBusException.FailureReason.MessagingEntityNotFound);
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
                        qRuntime.MessageCount = long.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "SizeInBytes":
                        qRuntime.SizeInBytes = long.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "UpdatedAt":
                        qRuntime.UpdatedAt = DateTimeOffset.Parse(element.Value, CultureInfo.InvariantCulture);
                        break;
                    case "CountDetails":
                        qRuntime.CountDetails = new MessageCountDetails();
                        foreach (var countElement in element.Elements())
                        {
                            switch (countElement.Name.LocalName)
                            {
                                case "ActiveMessageCount":
                                    qRuntime.CountDetails.ActiveMessageCount = long.Parse(countElement.Value, CultureInfo.InvariantCulture);
                                    break;
                                case "DeadLetterMessageCount":
                                    qRuntime.CountDetails.DeadLetterMessageCount = long.Parse(countElement.Value, CultureInfo.InvariantCulture);
                                    break;
                                case "ScheduledMessageCount":
                                    qRuntime.CountDetails.ScheduledMessageCount = long.Parse(countElement.Value, CultureInfo.InvariantCulture);
                                    break;
                                case "TransferMessageCount":
                                    qRuntime.CountDetails.TransferMessageCount = long.Parse(countElement.Value, CultureInfo.InvariantCulture);
                                    break;
                                case "TransferDeadLetterMessageCount":
                                    qRuntime.CountDetails.TransferDeadLetterMessageCount = long.Parse(countElement.Value, CultureInfo.InvariantCulture);
                                    break;
                            }
                        }
                        break;
                }
            }

            return qRuntime;
        }

        public static List<QueueRuntimeInfo> ParseCollectionFromContent(string xml)
        {
            try
            {
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var queueList = new List<QueueRuntimeInfo>();

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

            throw new ServiceBusException("No queues were found", ServiceBusException.FailureReason.MessagingEntityNotFound);
        }
    }
}
