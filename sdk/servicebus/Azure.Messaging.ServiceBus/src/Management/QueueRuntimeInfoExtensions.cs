// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml.Linq;
using System.Collections.Generic;

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
                        qRuntime.AccessedAt = DateTime.Parse(element.Value);
                        break;
                    case "CreatedAt":
                        qRuntime.CreatedAt = DateTime.Parse(element.Value);
                        break;
                    case "MessageCount":
                        qRuntime.MessageCount = long.Parse(element.Value);
                        break;
                    case "SizeInBytes":
                        qRuntime.SizeInBytes = long.Parse(element.Value);
                        break;
                    case "UpdatedAt":
                        qRuntime.UpdatedAt = DateTime.Parse(element.Value);
                        break;
                    case "CountDetails":
                        qRuntime.MessageCountDetails = new MessageCountDetails();
                        foreach (var countElement in element.Elements())
                        {
                            switch (countElement.Name.LocalName)
                            {
                                case "ActiveMessageCount":
                                    qRuntime.MessageCountDetails.ActiveMessageCount = long.Parse(countElement.Value);
                                    break;
                                case "DeadLetterMessageCount":
                                    qRuntime.MessageCountDetails.DeadLetterMessageCount = long.Parse(countElement.Value);
                                    break;
                                case "ScheduledMessageCount":
                                    qRuntime.MessageCountDetails.ScheduledMessageCount = long.Parse(countElement.Value);
                                    break;
                                case "TransferMessageCount":
                                    qRuntime.MessageCountDetails.TransferMessageCount = long.Parse(countElement.Value);
                                    break;
                                case "TransferDeadLetterMessageCount":
                                    qRuntime.MessageCountDetails.TransferDeadLetterMessageCount = long.Parse(countElement.Value);
                                    break;
                            }
                        }
                        break;
                }
            }

            return qRuntime;
        }

        public static IList<QueueRuntimeInfo> ParseCollectionFromContent(string xml)
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
