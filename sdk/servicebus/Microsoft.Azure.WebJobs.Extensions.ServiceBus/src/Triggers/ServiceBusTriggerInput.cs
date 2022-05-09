// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using System.Globalization;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    // The core object we get when an ServiceBus is triggered.
    // This gets converted to the user type (Message, string, poco, etc)
    internal sealed class ServiceBusTriggerInput
    {
        private bool _isSingleDispatch;

        private ServiceBusTriggerInput() { }

        public ServiceBusReceiveActions ReceiveActions { get; set; }

        public ServiceBusMessageActions MessageActions { get; set; }

        public ServiceBusClient Client { get; set; }

        public ServiceBusReceivedMessage[] Messages { get; set; }

        public static ServiceBusTriggerInput CreateSingle(ServiceBusReceivedMessage message, ServiceBusMessageActions messageActions, ServiceBusReceiveActions receiveActions, ServiceBusClient client)
        {
            return new ServiceBusTriggerInput
            {
                Messages = new ServiceBusReceivedMessage[]
                {
                      message
                },
                _isSingleDispatch = true,
                MessageActions = messageActions,
                ReceiveActions = receiveActions,
                Client = client
            };
        }

        public static ServiceBusTriggerInput CreateBatch(ServiceBusReceivedMessage[] messages, ServiceBusMessageActions messageActions, ServiceBusReceiveActions receiveActions, ServiceBusClient client)
        {
            return new ServiceBusTriggerInput
            {
                Messages = messages,
                _isSingleDispatch = false,
                MessageActions = messageActions,
                ReceiveActions = receiveActions,
                Client = client
            };
        }

        public bool IsSingleDispatch => _isSingleDispatch;

        public TriggeredFunctionData GetTriggerFunctionData()
        {
            if (Messages.Length > 0)
            {
                ServiceBusReceivedMessage message = Messages[0];
                if (IsSingleDispatch)
                {
                    Guid? parentId = ServiceBusCausalityHelper.GetOwner(message);
                    return new TriggeredFunctionData()
                    {
                        ParentId = parentId,
                        TriggerValue = this,
                        TriggerDetails = new Dictionary<string, string>()
                        {
                            { "MessageId", message.MessageId },
                            { "SequenceNumber",  message.SequenceNumber.ToString(CultureInfo.InvariantCulture) },
                            { "DeliveryCount", message.DeliveryCount.ToString(CultureInfo.InvariantCulture) },
                            { "EnqueuedTimeUtc", message.EnqueuedTime.ToUniversalTime().ToString("o") },
                            { "LockedUntilUtc", message.LockedUntil.ToUniversalTime().ToString("o") },
                            { "SessionId", message.SessionId }
                        }
                    };
                }
                else
                {
                    Guid? parentId = ServiceBusCausalityHelper.GetOwner(message);

                    int length = Messages.Length;
                    string[] messageIds = new string[length];
                    int[] deliveryCounts = new int[length];
                    long[] sequenceNumbers = new long[length];
                    string[] enqueuedTimes = new string[length];
                    string[] lockedUntils = new string[length];
                    string sessionId = Messages[0].SessionId;

                    for (int i = 0; i < Messages.Length; i++)
                    {
                        messageIds[i] = Messages[i].MessageId;
                        sequenceNumbers[i] = Messages[i].SequenceNumber;
                        deliveryCounts[i] = Messages[i].DeliveryCount;
                        enqueuedTimes[i] = Messages[i].EnqueuedTime.ToUniversalTime().ToString("o");
                        lockedUntils[i] = Messages[i].LockedUntil.ToUniversalTime().ToString("o");
                    }

                    return new TriggeredFunctionData()
                    {
                        ParentId = parentId,
                        TriggerValue = this,
                        TriggerDetails = new Dictionary<string, string>()
                        {
                            { "MessageIdArray", string.Join(",", messageIds)},
                            { "SequenceNumberArray", string.Join(",", sequenceNumbers)},
                            { "DeliveryCountArray", string.Join(",", deliveryCounts) },
                            { "EnqueuedTimeUtcArray", string.Join(",", enqueuedTimes) },
                            { "LockedUntilArray", string.Join(",", lockedUntils) },
                            { "SessionId", sessionId }
                        }
                    };
                }
            }
            return null;
        }
    }
}