// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core.Amqp;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Administration;

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
            DateTimeOffset enqueuedTime = default)
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

            return new ServiceBusReceivedMessage(amqpMessage)
            {
                LockTokenGuid = lockTokenGuid,
            };
        }

        /// <summary>
        /// Creates a new <see cref="QueueProperties"/> instance for mocking.
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
            bool enablePartitioning = default) =>
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
        /// Creates a new <see cref="TopicProperties"/> instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TopicProperties TopicProperties(
            string name,
            long maxSizeInMegabytes = default,
            bool requiresDuplicateDetection = default,
            TimeSpan defaultMessageTimeToLive = default,
            TimeSpan autoDeleteOnIdle = default,
            TimeSpan duplicateDetectionHistoryTimeWindow = default,
            bool enableBatchedOperations = default,
            EntityStatus status = default,
            bool enablePartitioning = default) =>
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
        /// Creates a new <see cref="SubscriptionProperties"/> instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RuleProperties RuleProperties(
            string name,
            RuleFilter filter = default,
            RuleAction action = default) =>
            new RuleProperties(name, filter)
            {
                Action = action
            };
    }
}
