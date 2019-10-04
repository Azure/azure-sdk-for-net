// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    using System;
    using System.Xml.Linq;

    internal static class TopicRuntimeInfoExtensions
    {
        public static TopicRuntimeInfo ParseFromContent(string xml)
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

        static TopicRuntimeInfo ParseFromEntryElement(XElement xEntry)
        {
            var name = xEntry.Element(XName.Get("title", ManagementClientConstants.AtomNamespace)).Value;
            var topicRuntimeInfo = new TopicRuntimeInfo(name);

            var qdXml = xEntry.Element(XName.Get("content", ManagementClientConstants.AtomNamespace))?
                .Element(XName.Get("TopicDescription", ManagementClientConstants.ServiceBusNamespace));

            if (qdXml == null)
            {
                throw new MessagingEntityNotFoundException("Topic was not found");
            }

            foreach (var element in qdXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "AccessedAt":
                        topicRuntimeInfo.AccessedAt = DateTime.Parse(element.Value);
                        break;
                    case "CreatedAt":
                        topicRuntimeInfo.CreatedAt = DateTime.Parse(element.Value);
                        break;
                    case "SizeInBytes":
                        topicRuntimeInfo.SizeInBytes = long.Parse(element.Value);
                        break;
                    case "SubscriptionCount":
                        topicRuntimeInfo.SubscriptionCount = int.Parse(element.Value);
                        break;
                    case "UpdatedAt":
                        topicRuntimeInfo.UpdatedAt = DateTime.Parse(element.Value);
                        break;
                    case "CountDetails":
                        topicRuntimeInfo.MessageCountDetails = new MessageCountDetails();
                        foreach (var countElement in element.Elements())
                        {
                            switch (countElement.Name.LocalName)
                            {
                                case "ActiveMessageCount":
                                    topicRuntimeInfo.MessageCountDetails.ActiveMessageCount = long.Parse(countElement.Value);
                                    break;
                                case "DeadLetterMessageCount":
                                    topicRuntimeInfo.MessageCountDetails.DeadLetterMessageCount = long.Parse(countElement.Value);
                                    break;
                                case "ScheduledMessageCount":
                                    topicRuntimeInfo.MessageCountDetails.ScheduledMessageCount = long.Parse(countElement.Value);
                                    break;
                                case "TransferMessageCount":
                                    topicRuntimeInfo.MessageCountDetails.TransferMessageCount = long.Parse(countElement.Value);
                                    break;
                                case "TransferDeadLetterMessageCount":
                                    topicRuntimeInfo.MessageCountDetails.TransferDeadLetterMessageCount = long.Parse(countElement.Value);
                                    break;
                            }
                        }
                        break;
                }
            }

            return topicRuntimeInfo;
        }
    }
}