﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core.Amqp;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Administration;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// This class contains methods to create certain ServiceBus models.
    /// </summary>
    public static class ServiceBusModelFactory
    {
        /// <summary>
        /// Creates a new ServiceBusReceivedMessage instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceBusReceivedMessage ServiceBusReceivedMessage(
            BinaryData body,
            string messageId,
            string partitionKey,
            string viaPartitionKey,
            string sessionId,
            string replyToSessionId,
            TimeSpan timeToLive,
            string correlationId,
            string subject,
            string to,
            string contentType,
            string replyTo,
            DateTimeOffset scheduledEnqueueTime,
            IDictionary<string, object> properties,
            Guid lockTokenGuid,
            int deliveryCount,
            DateTimeOffset lockedUntil,
            long sequenceNumber,
            string deadLetterSource,
            long enqueuedSequenceNumber,
            DateTimeOffset enqueuedTime) =>
            ServiceBusReceivedMessage(body, messageId, partitionKey, viaPartitionKey, sessionId, replyToSessionId,
            timeToLive, correlationId, subject, to, contentType, replyTo, scheduledEnqueueTime, properties,
            lockTokenGuid, deliveryCount, lockedUntil, sequenceNumber, deadLetterSource, enqueuedSequenceNumber, enqueuedTime, ServiceBusMessageState.Active);

        /// <summary>
        /// Creates a new ServiceBusReceivedMessage instance for mocking.
        /// </summary>
        public static ServiceBusReceivedMessage ServiceBusReceivedMessage(
            BinaryData body = default,
            string messageId = default,
            string partitionKey = default,
            string viaPartitionKey = default,
            string sessionId = default,
            string replyToSessionId = default,
            TimeSpan timeToLive = default,
            string correlationId = default,
            string subject = default,
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
            DateTimeOffset enqueuedTime = default,
            ServiceBusMessageState serviceBusMessageState = default)
        {
            var amqpMessage = new AmqpAnnotatedMessage(new AmqpMessageBody(new ReadOnlyMemory<byte>[] { body }));

            if (correlationId != default)
            {
                amqpMessage.Properties.CorrelationId = new AmqpMessageId(correlationId);
            }
            amqpMessage.Properties.Subject = subject;
            if (to != default)
            {
                amqpMessage.Properties.To = new AmqpAddress(to);
            }
            amqpMessage.Properties.ContentType = contentType;
            if (replyTo != default)
            {
                amqpMessage.Properties.ReplyTo = new AmqpAddress(replyTo);
            }
            amqpMessage.MessageAnnotations[AmqpMessageConstants.ScheduledEnqueueTimeUtcName] = scheduledEnqueueTime.UtcDateTime;

            if (messageId != default)
            {
                amqpMessage.Properties.MessageId = new AmqpMessageId(messageId);
            }
            if (partitionKey != default)
            {
                amqpMessage.MessageAnnotations[AmqpMessageConstants.PartitionKeyName] = partitionKey;
            }
            if (viaPartitionKey != default)
            {
                amqpMessage.MessageAnnotations[AmqpMessageConstants.ViaPartitionKeyName] = viaPartitionKey;
            }
            if (sessionId != default)
            {
                amqpMessage.Properties.GroupId = sessionId;
            }
            if (replyToSessionId != default)
            {
                amqpMessage.Properties.ReplyToGroupId = replyToSessionId;
            }
            if (timeToLive != default)
            {
                amqpMessage.Header.TimeToLive = timeToLive;
            }
            if (properties != default)
            {
                foreach (KeyValuePair<string, object> kvp in properties)
                {
                    amqpMessage.ApplicationProperties.Add(kvp);
                }
            }
            amqpMessage.Header.DeliveryCount = (uint)deliveryCount;
            amqpMessage.MessageAnnotations[AmqpMessageConstants.LockedUntilName] = lockedUntil.UtcDateTime;
            amqpMessage.MessageAnnotations[AmqpMessageConstants.SequenceNumberName] = sequenceNumber;
            amqpMessage.MessageAnnotations[AmqpMessageConstants.DeadLetterSourceName] = deadLetterSource;
            amqpMessage.MessageAnnotations[AmqpMessageConstants.EnqueueSequenceNumberName] = enqueuedSequenceNumber;
            amqpMessage.MessageAnnotations[AmqpMessageConstants.EnqueuedTimeUtcName] = enqueuedTime.UtcDateTime;
            amqpMessage.MessageAnnotations[AmqpMessageConstants.MessageStateName] = serviceBusMessageState;

            return new ServiceBusReceivedMessage(amqpMessage)
            {
                LockTokenGuid = lockTokenGuid,
            };
        }

        /// <summary>
        /// Creates a new <see cref="Azure.Messaging.ServiceBus.Administration.QueueProperties"/> instance for mocking.
        /// </summary>
        public static QueueProperties QueueProperties(
            string name,
            TimeSpan lockDuration,
            long maxSizeInMegabytes,
            bool requiresDuplicateDetection,
            bool requiresSession,
            TimeSpan defaultMessageTimeToLive,
            TimeSpan autoDeleteOnIdle,
            bool deadLetteringOnMessageExpiration,
            TimeSpan duplicateDetectionHistoryTimeWindow,
            int maxDeliveryCount,
            bool enableBatchedOperations,
            EntityStatus status,
            string forwardTo,
            string forwardDeadLetteredMessagesTo,
            string userMetadata,
            bool enablePartitioning) =>
            new QueueProperties(name)
            {
                LockDuration = lockDuration,
                MaxSizeInMegabytes = maxSizeInMegabytes,
                RequiresDuplicateDetection = requiresDuplicateDetection,
                RequiresSession = requiresSession,
                DefaultMessageTimeToLive = defaultMessageTimeToLive,
                AutoDeleteOnIdle = autoDeleteOnIdle,
                DeadLetteringOnMessageExpiration = deadLetteringOnMessageExpiration,
                DuplicateDetectionHistoryTimeWindow = duplicateDetectionHistoryTimeWindow,
                MaxDeliveryCount = maxDeliveryCount,
                EnableBatchedOperations = enableBatchedOperations,
                AuthorizationRules = new AuthorizationRules(), // this cannot be created by the user
                Status = status,
                ForwardTo = forwardTo,
                ForwardDeadLetteredMessagesTo = forwardDeadLetteredMessagesTo,
                UserMetadata = userMetadata,
                EnablePartitioning = enablePartitioning
            };

        /// <summary>
        /// Creates a new <see cref="Azure.Messaging.ServiceBus.Administration.QueueProperties"/> instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static QueueProperties QueueProperties(
            string name,
            TimeSpan lockDuration = default,
            long maxSizeInMegabytes = default,
            bool requiresDuplicateDetection = default,
            bool requiresSession = default,
            TimeSpan defaultMessageTimeToLive = default,
            TimeSpan autoDeleteOnIdle = default,
            bool deadLetteringOnMessageExpiration = default,
            TimeSpan duplicateDetectionHistoryTimeWindow = default,
            int maxDeliveryCount = default,
            bool enableBatchedOperations = default,
            EntityStatus status = default,
            string forwardTo = default,
            string forwardDeadLetteredMessagesTo = default,
            string userMetadata = default,
            bool enablePartitioning = default,
            long maxMessageSizeInKilobytes = default) =>
                new QueueProperties(name)
                {
                    LockDuration = lockDuration,
                    MaxSizeInMegabytes = maxSizeInMegabytes,
                    RequiresDuplicateDetection = requiresDuplicateDetection,
                    RequiresSession = requiresSession,
                    DefaultMessageTimeToLive = defaultMessageTimeToLive,
                    AutoDeleteOnIdle = autoDeleteOnIdle,
                    DeadLetteringOnMessageExpiration = deadLetteringOnMessageExpiration,
                    DuplicateDetectionHistoryTimeWindow = duplicateDetectionHistoryTimeWindow,
                    MaxDeliveryCount = maxDeliveryCount,
                    EnableBatchedOperations = enableBatchedOperations,
                    AuthorizationRules = new AuthorizationRules(), // this cannot be created by the user
                    Status = status,
                    ForwardTo = forwardTo,
                    ForwardDeadLetteredMessagesTo = forwardDeadLetteredMessagesTo,
                    UserMetadata = userMetadata,
                    EnablePartitioning = enablePartitioning,
                    MaxMessageSizeInKilobytes = maxMessageSizeInKilobytes
                };

        /// <summary>
        /// Creates a new <see cref="Azure.Messaging.ServiceBus.Administration.TopicProperties"/> instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TopicProperties TopicProperties(
            string name,
            long maxSizeInMegabytes,
            bool requiresDuplicateDetection,
            TimeSpan defaultMessageTimeToLive,
            TimeSpan autoDeleteOnIdle,
            TimeSpan duplicateDetectionHistoryTimeWindow,
            bool enableBatchedOperations,
            EntityStatus status,
            bool enablePartitioning) =>
            new TopicProperties(name)
            {
                MaxSizeInMegabytes = maxSizeInMegabytes,
                RequiresDuplicateDetection = requiresDuplicateDetection,
                DefaultMessageTimeToLive = defaultMessageTimeToLive,
                AutoDeleteOnIdle = autoDeleteOnIdle,
                DuplicateDetectionHistoryTimeWindow = duplicateDetectionHistoryTimeWindow,
                EnableBatchedOperations = enableBatchedOperations,
                AuthorizationRules = new AuthorizationRules(), // this cannot be created by the user
                Status = status,
                EnablePartitioning = enablePartitioning
            };

        /// <summary>
        /// Creates a new <see cref="Azure.Messaging.ServiceBus.Administration.TopicProperties"/> instance for mocking.
        /// </summary>
        public static TopicProperties TopicProperties(
            string name,
            long maxSizeInMegabytes = default,
            bool requiresDuplicateDetection = default,
            TimeSpan defaultMessageTimeToLive = default,
            TimeSpan autoDeleteOnIdle = default,
            TimeSpan duplicateDetectionHistoryTimeWindow = default,
            bool enableBatchedOperations = default,
            EntityStatus status = default,
            bool enablePartitioning = default,
            long maxMessageSizeInKilobytes = default) =>
            new TopicProperties(name)
            {
                MaxSizeInMegabytes = maxSizeInMegabytes,
                RequiresDuplicateDetection = requiresDuplicateDetection,
                DefaultMessageTimeToLive = defaultMessageTimeToLive,
                AutoDeleteOnIdle = autoDeleteOnIdle,
                DuplicateDetectionHistoryTimeWindow = duplicateDetectionHistoryTimeWindow,
                EnableBatchedOperations = enableBatchedOperations,
                AuthorizationRules = new AuthorizationRules(), // this cannot be created by the user
                Status = status,
                EnablePartitioning = enablePartitioning,
                MaxMessageSizeInKilobytes = maxMessageSizeInKilobytes
            };

        /// <summary>
        /// Creates a new <see cref="SubscriptionProperties"/> instance for mocking.
        /// </summary>
        public static SubscriptionProperties SubscriptionProperties(
            string topicName,
            string subscriptionName,
            TimeSpan lockDuration = default,
            bool requiresSession = default,
            TimeSpan defaultMessageTimeToLive = default,
            TimeSpan autoDeleteOnIdle = default,
            bool deadLetteringOnMessageExpiration = default,
            int maxDeliveryCount = default,
            bool enableBatchedOperations = default,
            EntityStatus status = default,
            string forwardTo = default,
            string forwardDeadLetteredMessagesTo = default,
            string userMetadata = default) =>
            new SubscriptionProperties(topicName, subscriptionName)
            {
                LockDuration = lockDuration,
                RequiresSession = requiresSession,
                DefaultMessageTimeToLive = defaultMessageTimeToLive,
                AutoDeleteOnIdle = autoDeleteOnIdle,
                DeadLetteringOnMessageExpiration = deadLetteringOnMessageExpiration,
                MaxDeliveryCount = maxDeliveryCount,
                EnableBatchedOperations = enableBatchedOperations,
                Status = status,
                ForwardTo = forwardTo,
                ForwardDeadLetteredMessagesTo = forwardDeadLetteredMessagesTo,
                UserMetadata = userMetadata
            };

        /// <summary>
        /// Creates a new <see cref="RuleProperties"/> instance for mocking.
        /// </summary>
        public static RuleProperties RuleProperties(
            string name,
            RuleFilter filter = default,
            RuleAction action = default) =>
            new RuleProperties(name, filter)
            {
                Action = action
            };

        /// <summary>
        /// Creates a new <see cref="QueueRuntimeProperties"/> instance for mocking.
        /// </summary>
        public static QueueRuntimeProperties QueueRuntimeProperties(
            string name,
            long activeMessageCount = default,
            long scheduledMessageCount = default,
            long deadLetterMessageCount = default,
            long transferDeadLetterMessageCount = default,
            long transferMessageCount = default,
            long totalMessageCount = default,
            long sizeInBytes = default,
            DateTimeOffset createdAt = default,
            DateTimeOffset updatedAt = default,
            DateTimeOffset accessedAt = default) =>
                new(name)
                {
                    ActiveMessageCount = activeMessageCount,
                    ScheduledMessageCount = scheduledMessageCount,
                    DeadLetterMessageCount = deadLetterMessageCount,
                    TransferDeadLetterMessageCount = transferDeadLetterMessageCount,
                    TransferMessageCount = transferMessageCount,
                    TotalMessageCount = totalMessageCount,
                    SizeInBytes = sizeInBytes,
                    CreatedAt = createdAt,
                    UpdatedAt = updatedAt,
                    AccessedAt = accessedAt
                };

        /// <summary>
        /// Creates a new <see cref="TopicRuntimeProperties"/> instance for mocking.
        /// </summary>
        public static TopicRuntimeProperties TopicRuntimeProperties(
            string name,
            long scheduledMessageCount = default,
            long sizeInBytes = default,
            int subscriptionCount = default,
            DateTimeOffset createdAt = default,
            DateTimeOffset updatedAt = default,
            DateTimeOffset accessedAt = default) =>
                new(name)
                {
                    ScheduledMessageCount = scheduledMessageCount,
                    SizeInBytes = sizeInBytes,
                    SubscriptionCount = subscriptionCount,
                    CreatedAt = createdAt,
                    UpdatedAt = updatedAt,
                    AccessedAt = accessedAt
                };

        /// <summary>
        /// Creates a new <see cref="SubscriptionRuntimeProperties"/> instance for mocking.
        /// </summary>
        public static SubscriptionRuntimeProperties SubscriptionRuntimeProperties(
            string topicName,
            string subscriptionName,
            long activeMessageCount = default,
            long deadLetterMessageCount = default,
            long transferDeadLetterMessageCount = default,
            long transferMessageCount = default,
            long totalMessageCount = default,
            DateTimeOffset createdAt = default,
            DateTimeOffset updatedAt = default,
            DateTimeOffset accessedAt = default) =>
                new(topicName, subscriptionName)
                {
                    ActiveMessageCount = activeMessageCount,
                    DeadLetterMessageCount = deadLetterMessageCount,
                    TransferDeadLetterMessageCount = transferDeadLetterMessageCount,
                    TransferMessageCount = transferMessageCount,
                    TotalMessageCount = totalMessageCount,
                    CreatedAt = createdAt,
                    UpdatedAt = updatedAt,
                    AccessedAt = accessedAt
                };

        /// <summary>
        ///   Initializes a new instance of the <see cref="Azure.Messaging.ServiceBus.ServiceBusMessageBatch" /> class.
        /// </summary>
        ///
        /// <param name="batchSizeBytes">The size, in bytes, that the batch should report; this is a static value and will not mutate as messages are added.</param>
        /// <param name="batchMessageStore">A list to which messages will be added when <see cref="Azure.Messaging.ServiceBus.ServiceBusMessageBatch.TryAddMessage" /> calls are successful.</param>
        /// <param name="batchOptions">The set of options to consider when creating this batch.</param>
        /// <param name="tryAddCallback"> A function that will be invoked when <see cref="Azure.Messaging.ServiceBus.ServiceBusMessageBatch.TryAddMessage" /> is called;
        /// the return of this callback represents the result of <see cref="Azure.Messaging.ServiceBus.ServiceBusMessageBatch.TryAddMessage" />.
        /// If not provided, all events will be accepted into the batch.</param>
        ///
        /// <returns>The <see cref="Azure.Messaging.ServiceBus.ServiceBusMessageBatch" /> instance that was created.</returns>
        ///
        public static ServiceBusMessageBatch ServiceBusMessageBatch(long batchSizeBytes,
                                                    IList<ServiceBusMessage> batchMessageStore,
                                                    CreateMessageBatchOptions batchOptions = default,
                                                    Func<ServiceBusMessage, bool> tryAddCallback = default)
        {
            tryAddCallback ??= _ => true;
            batchOptions ??= new CreateMessageBatchOptions();
            batchOptions.MaxSizeInBytes ??= long.MaxValue;

            var transportBatch = new ListTransportBatch(batchOptions.MaxSizeInBytes.Value, batchSizeBytes, batchMessageStore, tryAddCallback);
            return new ServiceBusMessageBatch(transportBatch, new EntityScopeFactory("mock", "mock"));
        }

        /// <summary>
        /// Creates a new <see cref="ServiceBusTransportMetrics"/> instance for mocking.
        /// </summary>
        /// <param name="lastHeartbeat">The last time that a heartbeat was received from the service.</param>
        /// <param name="lastConnectionOpen">The last time that a connection was opened.</param>
        /// <param name="lastConnectionClose">The last time that a connection was closed.</param>
        /// <returns></returns>
        internal static ServiceBusTransportMetrics ServiceBusTransportMetrics(
            DateTimeOffset? lastHeartbeat = default,
            DateTimeOffset? lastConnectionOpen = default,
            DateTimeOffset? lastConnectionClose = default)
            => new()
            {
                LastHeartBeat = lastHeartbeat,
                LastConnectionOpen = lastConnectionOpen,
                LastConnectionClose = lastConnectionClose
            };

        /// <summary>
        ///   Allows for the transport event batch created by the factory to be injected for testing purposes.
        /// </summary>
        ///
        private sealed class ListTransportBatch : TransportMessageBatch
        {
            /// <summary>The backing store for storing events in the batch.</summary>
            private readonly IList<ServiceBusMessage> _backingStore;

            /// <summary>A callback to be invoked when an adding an event via <see cref="TryAddMessage"/></summary>
            private readonly Func<ServiceBusMessage, bool> _tryAddCallback;

            /// <summary>
            ///   The maximum size allowed for the batch, in bytes.  This includes the events in the batch as
            ///   well as any overhead for the batch itself when sent to the Event Hubs service.
            /// </summary>
            ///
            public override long MaxSizeInBytes { get; }

            /// <summary>
            ///   The size of the batch, in bytes, as it will be sent to the Event Hubs
            ///   service.
            /// </summary>
            ///
            public override long SizeInBytes { get; }

            /// <summary>
            ///   The count of events contained in the batch.
            /// </summary>
            ///
            public override int Count => _backingStore.Count;

            /// <summary>
            ///   Initializes a new instance of the <see cref="ListTransportBatch"/> class.
            /// </summary>
            ///
            /// <param name="maxSizeInBytes"> The maximum size allowed for the batch, in bytes.</param>
            /// <param name="sizeInBytes">The size of the batch, in bytes; this will be treated as a static value for the property.</param>
            /// <param name="backingStore">The backing store for holding events in the batch.</param>
            /// <param name="tryAddCallback">A callback for deciding if a TryAdd attempt is successful.</param>
            ///
            internal ListTransportBatch(long maxSizeInBytes,
                                        long sizeInBytes,
                                        IList<ServiceBusMessage> backingStore,
                                        Func<ServiceBusMessage, bool> tryAddCallback) =>
                (MaxSizeInBytes, SizeInBytes, _backingStore, _tryAddCallback) = (maxSizeInBytes, sizeInBytes, backingStore, tryAddCallback);

            /// <summary>
            ///   Attempts to add an event to the batch, ensuring that the size
            ///   of the batch does not exceed its maximum.
            /// </summary>
            ///
            /// <param name="message">The event to attempt to add to the batch.</param>
            ///
            /// <returns><c>true</c> if the event was added; otherwise, <c>false</c>.</returns>
            ///
            public override bool TryAddMessage(ServiceBusMessage message)
            {
                if (_tryAddCallback(message))
                {
                    _backingStore.Add(message);
                    return true;
                }

                return false;
            }

            /// <summary>
            ///   Clears the batch, removing all events and resetting the
            ///   available size.
            /// </summary>
            ///
            public override void Clear() => _backingStore.Clear();

            /// <summary>
            ///   Represents the batch as an enumerable set of transport-specific
            ///   representations of an event.
            /// </summary>
            ///
            /// <typeparam name="T">The transport-specific event representation being requested.</typeparam>
            ///
            /// <returns>The set of events as an enumerable of the requested type.</returns>
            ///
            public override IReadOnlyCollection<T> AsReadOnly<T>() => _backingStore switch
            {
                IReadOnlyCollection<T> readOnlyCollection => readOnlyCollection,
                _ => new List<T>((IEnumerable<T>) _backingStore)
            };

            /// <summary>
            ///   Performs the task needed to clean up resources used by the <see cref="TransportMessageBatch" />.
            /// </summary>
            ///
            public override void Dispose()
            {
            }
        }
    }
}
