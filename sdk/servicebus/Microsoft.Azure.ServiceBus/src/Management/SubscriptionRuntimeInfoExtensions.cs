﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    using System;
    using System.Xml.Linq;
    using System.Collections.Generic;

    internal static class SubscriptionRuntimeInfoExtensions
    {
        public static SubscriptionRuntimeInfo ParseFromContent(string topicName, string xml)
        {
            try
            {
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "entry")
                    {
                        return ParseFromEntryElement(topicName, xDoc);
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex);
            }

            throw new MessagingEntityNotFoundException("Subscription was not found");
        }

        private static SubscriptionRuntimeInfo ParseFromEntryElement(string topicName, XElement xEntry)
        {
            var name = xEntry.Element(XName.Get("title", ManagementClientConstants.AtomNamespace)).Value;
            var subscriptionRuntimeInfo = new SubscriptionRuntimeInfo(topicName, name);

            var qdXml = xEntry.Element(XName.Get("content", ManagementClientConstants.AtomNamespace))?
                .Element(XName.Get("SubscriptionDescription", ManagementClientConstants.ServiceBusNamespace));

            if (qdXml == null)
            {
                throw new MessagingEntityNotFoundException("Subscription was not found");
            }

            foreach (var element in qdXml.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "AccessedAt":
                        subscriptionRuntimeInfo.AccessedAt = DateTime.Parse(element.Value);
                        break;
                    case "CreatedAt":
                        subscriptionRuntimeInfo.CreatedAt = DateTime.Parse(element.Value);
                        break;
                    case "UpdatedAt":
                        subscriptionRuntimeInfo.UpdatedAt = DateTime.Parse(element.Value);
                        break;
                    case "MessageCount":
                        subscriptionRuntimeInfo.MessageCount = long.Parse(element.Value);
                        break;
                    case "CountDetails":
                        subscriptionRuntimeInfo.MessageCountDetails = new MessageCountDetails();
                        foreach (var countElement in element.Elements())
                        {
                            switch (countElement.Name.LocalName)
                            {
                                case "ActiveMessageCount":
                                    subscriptionRuntimeInfo.MessageCountDetails.ActiveMessageCount = long.Parse(countElement.Value);
                                    break;
                                case "DeadLetterMessageCount":
                                    subscriptionRuntimeInfo.MessageCountDetails.DeadLetterMessageCount = long.Parse(countElement.Value);
                                    break;
                                case "ScheduledMessageCount":
                                    subscriptionRuntimeInfo.MessageCountDetails.ScheduledMessageCount = long.Parse(countElement.Value);
                                    break;
                                case "TransferMessageCount":
                                    subscriptionRuntimeInfo.MessageCountDetails.TransferMessageCount = long.Parse(countElement.Value);
                                    break;
                                case "TransferDeadLetterMessageCount":
                                    subscriptionRuntimeInfo.MessageCountDetails.TransferDeadLetterMessageCount = long.Parse(countElement.Value);
                                    break;
                            }
                        }
                        break;
                }
            }

            return subscriptionRuntimeInfo;
        }

        public static List<SubscriptionRuntimeInfo> ParseCollectionFromContent(string topicPath, string xml)
        {
            try
            {
                var xDoc = XElement.Parse(xml);
                if (!xDoc.IsEmpty)
                {
                    if (xDoc.Name.LocalName == "feed")
                    {
                        var subscriptionList = new List<SubscriptionRuntimeInfo>();

                        var entryList = xDoc.Elements(XName.Get("entry", ManagementClientConstants.AtomNamespace));
                        foreach (var entry in entryList)
                        {
                            subscriptionList.Add(ParseFromEntryElement(topicPath, entry));
                        }

                        return subscriptionList;
                    }
                }
            }
            catch (Exception ex) when (!(ex is ServiceBusException))
            {
                throw new ServiceBusException(false, ex);
            }

            throw new MessagingEntityNotFoundException("No subscriptions were found");
        }
    }
}