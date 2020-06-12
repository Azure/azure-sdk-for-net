// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Azure.Messaging.ServiceBus.Management
{
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
                throw new ServiceBusException(false, ex.Message);
            }

            throw new ServiceBusException("Topic was not found", ServiceBusException.FailureReason.MessagingEntityNotFound);
        }

        public static TopicRuntimeInfo ParseFromEntryElement(XElement xEntry)
        {
            var name = xEntry.Element(XName.Get("title", ManagementClientConstants.AtomNamespace)).Value;
            var topicRuntimeInfo = new TopicRuntimeInfo(name);

            var qdXml = xEntry.Element(XName.Get("content", ManagementClientConstants.AtomNamespace))?
                .Element(XName.Get("TopicDescription", ManagementClientConstants.ServiceBusNamespace));

            if (qdXml == null)
            {
                throw new ServiceBusException("Topic was not found", ServiceBusException.FailureReason.MessagingEntityNotFound);
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
                        break;
                }
            }

            return topicRuntimeInfo;
        }

        public static List<TopicRuntimeInfo> ParseCollectionFromContent(string xml)
        {
            try
            {
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var topicList = new List<TopicRuntimeInfo>();

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

            throw new ServiceBusException("No topics were found", ServiceBusException.FailureReason.MessagingEntityNotFound);
        }
    }
}
