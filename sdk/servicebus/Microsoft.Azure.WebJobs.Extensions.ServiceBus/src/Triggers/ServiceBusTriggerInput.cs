// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    // The core object we get when an ServiceBus is triggered.
    // This gets converted to the user type (Message, string, poco, etc)
    internal sealed class ServiceBusTriggerInput
    {
        private bool _isSingleDispatch;

        private ServiceBusTriggerInput() { }

        public IMessageReceiver MessageReceiver;

        public Message[] Messages { get; set; }

        public static ServiceBusTriggerInput CreateSingle(Message message)
        {
            return new ServiceBusTriggerInput
            {
                Messages = new Message[]
                {
                      message
                },
                _isSingleDispatch = true
            };
        }

        public static ServiceBusTriggerInput CreateBatch(Message[] messages)
        {
            return new ServiceBusTriggerInput
            {
                Messages = messages,
                _isSingleDispatch = false
            };
        }

        public bool IsSingleDispatch
        {
            get
            {
                return _isSingleDispatch;
            }
        }

        public TriggeredFunctionData GetTriggerFunctionData()
        {
            if (Messages.Length > 0)
            {
                Message message = Messages[0];
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
                            { "SequenceNumber",  message.SystemProperties.SequenceNumber.ToString(CultureInfo.InvariantCulture) },
                            { "DeliveryCount", message.SystemProperties.DeliveryCount.ToString(CultureInfo.InvariantCulture) },
                            { "EnqueuedTimeUtc", message.SystemProperties.EnqueuedTimeUtc.ToUniversalTime().ToString("o") },
                            { "LockedUntilUtc", message.SystemProperties.LockedUntilUtc.ToUniversalTime().ToString("o") },
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
                        sequenceNumbers[i] = Messages[i].SystemProperties.SequenceNumber;
                        deliveryCounts[i] = Messages[i].SystemProperties.DeliveryCount;
                        enqueuedTimes[i] = Messages[i].SystemProperties.EnqueuedTimeUtc.ToUniversalTime().ToString("o");
                        lockedUntils[i] = Messages[i].SystemProperties.LockedUntilUtc.ToUniversalTime().ToString("o");
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