// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Messaging.ServiceBus.Primitives
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
            ServiceBusMessage sentMessage,
            bool isSettled,
            int deliveryCount,
            DateTimeOffset lockedUntil,
            long sequenceNumber,
            string deadLetterSource,
            short partitionId,
            long enqueuedSequenceNumber,
            DateTimeOffset enqueuedTime,
            Guid lockTokenGuid,
            object bodyObject
        ) => new ServiceBusReceivedMessage
        {
            SentMessage = sentMessage,
            IsSettled = isSettled,
            DeliveryCount = deliveryCount,
            LockedUntil = lockedUntil,
            SequenceNumber = sequenceNumber,
            DeadLetterSource = deadLetterSource,
            PartitionId = partitionId,
            EnqueuedSequenceNumber = enqueuedSequenceNumber,
            EnqueuedTime = enqueuedTime,
            LockTokenGuid = lockTokenGuid,
            BodyObject = bodyObject
        };
    }
}
