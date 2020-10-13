// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// This class contains methods to create certain ServiceBus models.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ServiceBusModelFactory
    {
        /// <summary>
        /// Creates a new ServiceBusReceivedMessage instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceBusReceivedMessage ServiceBusReceivedMessage(
            BinaryData body = default,
            string messageId = default,
            string partitionKey = default,
            string viaPartitionKey = default,
            string sessionId = default,
            string replyToSessionId = default,
            TimeSpan timeToLive = default,
            string correlationId = default,
            string label = default,
            string to = default,
            string contentType = default,
            string replyTo = default,
            DateTimeOffset scheduledEnqueueTime = default,
            IDictionary<string, object> properties = default,
            Guid lockTokenGuid = default,
            int deliveryCount = default,
            DateTimeOffset lockedUntil = default,
            long sequenceNumber = -1,
            string deadLetterSource = default,
            long enqueuedSequenceNumber = default,
            DateTimeOffset enqueuedTime = default)
        {
            var sentMessage = new ServiceBusMessage
            {
                Body = body,
                CorrelationId = correlationId,
                Label = label,
                To = to,
                ContentType = contentType,
                ReplyTo = replyTo,
                ScheduledEnqueueTime = scheduledEnqueueTime
            };
            if (messageId != default)
            {
                sentMessage.MessageId = messageId;
            }
            if (partitionKey != default)
            {
                sentMessage.PartitionKey = partitionKey;
            }
            if (viaPartitionKey != default)
            {
                sentMessage.ViaPartitionKey = viaPartitionKey;
            }
            if (sessionId != default)
            {
                sentMessage.SessionId = sessionId;
            }
            if (replyToSessionId != default)
            {
                sentMessage.ReplyToSessionId = replyToSessionId;
            }
            if (timeToLive != default)
            {
                sentMessage.TimeToLive = timeToLive;
            }
            if (properties != default)
            {
                sentMessage.Properties = properties;
            }

            return new ServiceBusReceivedMessage
            {
                SentMessage = sentMessage,
                LockTokenGuid = lockTokenGuid,
                DeliveryCount = deliveryCount,
                LockedUntil = lockedUntil,
                SequenceNumber = sequenceNumber,
                DeadLetterSource = deadLetterSource,
                EnqueuedSequenceNumber = enqueuedSequenceNumber,
                EnqueuedTime = enqueuedTime
            };
        }
    }
}
