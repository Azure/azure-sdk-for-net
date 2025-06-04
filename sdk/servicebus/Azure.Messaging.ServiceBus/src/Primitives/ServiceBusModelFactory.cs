// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core.Amqp;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Administration;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Microsoft.Azure.Amqp;
using System.Globalization;
using Azure.Core.Shared;

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
        /// Creates a new <see cref="ServiceBus.ServiceBusReceivedMessage"/> instance for mocking.
        /// </summary>
        /// <param name="body">The binary data to assign as the value of <see cref="ServiceBusReceivedMessage.Body"/>.</param>
        /// <param name="messageId">The message identifier to assign as the value of <see cref="ServiceBusReceivedMessage.MessageId"/>.</param>
        /// <param name="partitionKey">The partition key to assign as the value of <see cref="ServiceBusReceivedMessage.PartitionKey"/>.</param>
        /// <param name="viaPartitionKey">The "via partition key" to assign as the value of <see cref="ServiceBusReceivedMessage.TransactionPartitionKey"/>.</param>
        /// <param name="sessionId">The session identifier to assign as the value of <see cref="ServiceBusReceivedMessage.SessionId"/>.</param>
        /// <param name="replyToSessionId">The "reply to" session identifier to assign as the value of <see cref="ServiceBusReceivedMessage.ReplyToSessionId"/>.</param>
        /// <param name="timeToLive">The time interval to assign as the value of <see cref="ServiceBusReceivedMessage.TimeToLive"/>.</param>
        /// <param name="correlationId">The correlation identifier to assign as the value of <see cref="ServiceBusReceivedMessage.CorrelationId"/>.</param>
        /// <param name="subject">The subject to assign as the value of <see cref="ServiceBusReceivedMessage.Subject"/>.</param>
        /// <param name="to">The "to" value to assign as the value of <see cref="ServiceBusReceivedMessage.To"/>.</param>
        /// <param name="contentType">The content type to assign as the value of <see cref="ServiceBusReceivedMessage.ContentType"/>.</param>
        /// <param name="replyTo">The "reply to" value to assign as the value of <see cref="ServiceBusReceivedMessage.ReplyTo"/>.</param>
        /// <param name="scheduledEnqueueTime">The time stamp to assign as the value of <see cref="ServiceBusReceivedMessage.ScheduledEnqueueTime"/>.</param>
        /// <param name="properties">The set of application properties to assign as the value of <see cref="ServiceBusReceivedMessage.ApplicationProperties"/>.</param>
        /// <param name="lockTokenGuid">The token to assign as the value of <see cref="ServiceBusReceivedMessage.LockToken"/>.</param>
        /// <param name="deliveryCount">The count to assign as the value of <see cref="ServiceBusReceivedMessage.DeliveryCount"/>.</param>
        /// <param name="lockedUntil">The "locked until" time stamp to assign as the value of <see cref="ServiceBusReceivedMessage.LockedUntil"/>.</param>
        /// <param name="sequenceNumber">The sequence number to assign as the value of <see cref="ServiceBusReceivedMessage.SequenceNumber"/>.</param>
        /// <param name="deadLetterSource">The source to assign as the value of <see cref="ServiceBusReceivedMessage.DeadLetterSource"/>.</param>
        /// <param name="enqueuedSequenceNumber">The sequence number to assign as the value of <see cref="ServiceBusReceivedMessage.EnqueuedSequenceNumber"/>.</param>
        /// <param name="enqueuedTime">The time stamp to assign as the value of <see cref="ServiceBusReceivedMessage.EnqueuedTime"/>.</param>
        /// <param name="serviceBusMessageState">The state of the message to assign as the value of <see cref="ServiceBusReceivedMessage.State"/>.</param>
        /// <returns>The populated <see cref="ServiceBus.ServiceBusReceivedMessage"/> instance to use for mocking.</returns>
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
            amqpMessage.MessageAnnotations[AmqpMessageConstants.MessageStateName] = (int)serviceBusMessageState;

            return new ServiceBusReceivedMessage(amqpMessage)
            {
                LockTokenGuid = lockTokenGuid,
            };
        }

        /// <summary>
        /// Creates a new <see cref="Administration.QueueProperties" /> instance for mocking.
        /// </summary>
        /// <param name="name">The name to assign as the value of <see cref="QueueProperties.Name"/>.</param>
        /// <param name="lockDuration">The duration to assign as the value of <see cref="QueueProperties.LockDuration"/>.</param>
        /// <param name="maxSizeInMegabytes">The size to assign as the value of <see cref="QueueProperties.MaxSizeInMegabytes"/>.</param>
        /// <param name="requiresDuplicateDetection">The boolean flag to assign as the value of <see cref="QueueProperties.RequiresDuplicateDetection"/>.</param>
        /// <param name="requiresSession">The boolean flag to assign as the value of <see cref="QueueProperties.RequiresSession"/>.</param>
        /// <param name="defaultMessageTimeToLive">The time interval to assign as the value of <see cref="QueueProperties.DefaultMessageTimeToLive"/>.</param>
        /// <param name="autoDeleteOnIdle">The boolean flag to assign as the value of <see cref="QueueProperties.AutoDeleteOnIdle"/>.</param>
        /// <param name="deadLetteringOnMessageExpiration">The boolean flag to assign as the value of <see cref="QueueProperties.DeadLetteringOnMessageExpiration"/>.</param>
        /// <param name="duplicateDetectionHistoryTimeWindow">The time interval to assign as the value of <see cref="QueueProperties.DuplicateDetectionHistoryTimeWindow"/>.</param>
        /// <param name="maxDeliveryCount">The count to assign as the value of <see cref="QueueProperties.MaxDeliveryCount"/>.</param>
        /// <param name="enableBatchedOperations">The boolean flag to assign as the value of <see cref="QueueProperties.EnableBatchedOperations"/>.</param>
        /// <param name="status">The status to assign as the value of <see cref="QueueProperties.Status"/>.</param>
        /// <param name="forwardTo">The name of the "forward to" entity to assign as the value of <see cref="QueueProperties.ForwardTo"/>.</param>
        /// <param name="forwardDeadLetteredMessagesTo">The name of the "forward to" entity to assign as the value of <see cref="QueueProperties.ForwardDeadLetteredMessagesTo"/>.</param>
        /// <param name="userMetadata">The metadata to assign as the value of <see cref="QueueProperties.UserMetadata"/>.</param>
        /// <param name="enablePartitioning">The boolean flag to assign as the value of <see cref="QueueProperties.EnablePartitioning"/>.</param>
        /// <returns>The populated <see cref="Administration.QueueProperties"/> instance to use for mocking.</returns>
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
        /// Creates a new <see cref="Administration.QueueProperties"/> instance for mocking.
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
        /// Creates a new <see cref="Administration.TopicProperties"/> instance for mocking.
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
        /// Creates a new <see cref="Administration.TopicProperties" /> instance for mocking.
        /// </summary>
        /// <param name="name">The name to assign as the value of <see cref="TopicProperties.Name"/>.</param>
        /// <param name="maxSizeInMegabytes">The size to assign as the value of <see cref="TopicProperties.MaxSizeInMegabytes"/>.</param>
        /// <param name="requiresDuplicateDetection">The boolean flag to assign as the value of <see cref="TopicProperties.RequiresDuplicateDetection"/>.</param>
        /// <param name="defaultMessageTimeToLive">The time to live to assign as the value of <see cref="TopicProperties.DefaultMessageTimeToLive"/>.</param>
        /// <param name="autoDeleteOnIdle">The time interval to assign as the value of <see cref="TopicProperties.AutoDeleteOnIdle"/>.</param>
        /// <param name="duplicateDetectionHistoryTimeWindow">The time interval to assign as the value of <see cref="TopicProperties.DuplicateDetectionHistoryTimeWindow"/>.</param>
        /// <param name="enableBatchedOperations">The boolean flag to assign as the value of <see cref="TopicProperties.EnableBatchedOperations"/>.</param>
        /// <param name="status">The status to assign as the value of <see cref="TopicProperties.Status"/>.</param>
        /// <param name="enablePartitioning">The boolean flag to assign as the value of <see cref="TopicProperties.EnablePartitioning"/>.</param>
        /// <param name="maxMessageSizeInKilobytes">The message size to assign as the value of <see cref="TopicProperties.MaxMessageSizeInKilobytes"/>.</param>
        /// <returns>The populated <see cref="Administration.TopicProperties"/> instance to use for mocking.</returns>
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
        /// Creates a new <see cref="Administration.NamespaceProperties" /> instance for mocking.
        /// </summary>
        /// <param name="name">The name to assign as the value of <see cref="NamespaceProperties.Name"/>.</param>
        /// <param name="createdTime">The time interval to assign as the value of <see cref="NamespaceProperties.CreatedTime"/>.</param>
        /// <param name="modifiedTime">The time interval to assign as the value of <see cref="NamespaceProperties.ModifiedTime"/>.</param>
        /// <param name="messagingSku">The SKU value to assign as the value of <see cref="NamespaceProperties.MessagingSku"/>.</param>
        /// <param name="messagingUnits">The unit value to assign as the value of <see cref="NamespaceProperties.MessagingUnits"/>.</param>
        /// <param name="alias">The alias to assign as the value of <see cref="NamespaceProperties.Alias"/>.</param>
        /// <returns>The populated <see cref="Administration.NamespaceProperties"/> instance to use for mocking.</returns>
        public static NamespaceProperties NamespaceProperties(
            string name,
            DateTimeOffset createdTime,
            DateTimeOffset modifiedTime,
            MessagingSku messagingSku,
            int messagingUnits,
            string alias) =>
            new NamespaceProperties
            {
                Name = name,
                CreatedTime = createdTime,
                ModifiedTime = modifiedTime,
                MessagingSku = messagingSku,
                MessagingUnits = messagingUnits,
                Alias = alias,
                NamespaceType = new NamespaceType() // this cannot be created by the user
            };

        /// <summary>
        /// Creates a new <see cref="Administration.SubscriptionProperties" /> instance for mocking.
        /// </summary>
        /// <param name="topicName">Name of the topic to assign as the value of <see cref="SubscriptionProperties.TopicName"/>.</param>
        /// <param name="subscriptionName">Name of the subscription to assign as the value of <see cref="SubscriptionProperties.SubscriptionName"/>.</param>
        /// <param name="lockDuration">Duration to assign as the value of <see cref="SubscriptionProperties.LockDuration"/>.</param>
        /// <param name="requiresSession">The boolean flag to assign as the value of <see cref="SubscriptionProperties.RequiresSession"/>.</param>
        /// <param name="defaultMessageTimeToLive">The time interval to assign as the value of <see cref="SubscriptionProperties.DefaultMessageTimeToLive"/>.</param>
        /// <param name="autoDeleteOnIdle">The time interval to assign as the value of <see cref="SubscriptionProperties.AutoDeleteOnIdle"/>.</param>
        /// <param name="deadLetteringOnMessageExpiration">The boolean flag to assign as the value of <see cref="SubscriptionProperties.DeadLetteringOnMessageExpiration"/>.</param>
        /// <param name="maxDeliveryCount">The count to assign as the value of <see cref="SubscriptionProperties.MaxDeliveryCount"/>.</param>
        /// <param name="enableBatchedOperations">The boolean flag to assign as the value of <see cref="SubscriptionProperties.EnableBatchedOperations"/>.</param>
        /// <param name="status">The status to assign as the value of <see cref="SubscriptionProperties.Status"/>.</param>
        /// <param name="forwardTo">The "forward to" entity to assign as the value of <see cref="SubscriptionProperties.ForwardTo"/>.</param>
        /// <param name="forwardDeadLetteredMessagesTo">The "forward to" entity to assign as the value of <see cref="SubscriptionProperties.ForwardDeadLetteredMessagesTo"/>.</param>
        /// <param name="userMetadata">The metadata to assign as the value of <see cref="SubscriptionProperties.UserMetadata"/>.</param>
        /// <returns>The populated <see cref="Administration.SubscriptionProperties"/> instance to use for mocking.</returns>
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
        /// Creates a new <see cref="Administration.RuleProperties" /> instance for mocking.
        /// </summary>
        /// <param name="name">The name to assign as the value of <see cref="RuleProperties.Name"/>.</param>
        /// <param name="filter">The filter to assign as the value of <see cref="RuleProperties.Filter"/>.</param>
        /// <param name="action">The action to assign as the value of <see cref="RuleProperties.Action"/>.</param>
        /// <returns>The populated <see cref="Administration.RuleProperties"/> instance to use for mocking.</returns>
        public static RuleProperties RuleProperties(
            string name,
            RuleFilter filter = default,
            RuleAction action = default) =>
            new RuleProperties(name, filter)
            {
                Action = action
            };

        /// <summary>
        /// Creates a new <see cref="QueueRuntimeProperties" /> instance for mocking.
        /// </summary>
        /// <param name="name">The name to assign as the value of <see cref="QueueRuntimeProperties.Name"/>.</param>
        /// <param name="activeMessageCount">The count to assign as the value of <see cref="QueueRuntimeProperties.ActiveMessageCount"/>.</param>
        /// <param name="scheduledMessageCount">The count to assign as the value of <see cref="QueueRuntimeProperties.ScheduledMessageCount"/>.</param>
        /// <param name="deadLetterMessageCount">The count to assign as the value of <see cref="QueueRuntimeProperties.DeadLetterMessageCount"/>.</param>
        /// <param name="transferDeadLetterMessageCount">The count to assign as the value of <see cref="QueueRuntimeProperties.TransferDeadLetterMessageCount"/>.</param>
        /// <param name="transferMessageCount">The count to assign as the value of <see cref="QueueRuntimeProperties.TransferMessageCount"/>.</param>
        /// <param name="totalMessageCount">The count to assign as the value of <see cref="QueueRuntimeProperties.TotalMessageCount"/>.</param>
        /// <param name="sizeInBytes">The size to assign as the value of <see cref="QueueRuntimeProperties.SizeInBytes"/>.</param>
        /// <param name="createdAt">The time stamp to assign as the value of <see cref="QueueRuntimeProperties.CreatedAt"/>.</param>
        /// <param name="updatedAt">The time stamp to assign as the value of <see cref="QueueRuntimeProperties.UpdatedAt"/>.</param>
        /// <param name="accessedAt">The time stamp to assign as the value of <see cref="QueueRuntimeProperties.AccessedAt"/>.</param>
        /// <returns>The populated <see cref="Administration.QueueRuntimeProperties"/> instance to use for mocking.</returns>
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
        /// Creates a new <see cref="TopicRuntimeProperties" /> instance for mocking.
        /// </summary>
        /// <param name="name">The name to assign as the value of <see cref="TopicRuntimeProperties.Name"/>.</param>
        /// <param name="scheduledMessageCount">The count to assign as the value of <see cref="TopicRuntimeProperties.ScheduledMessageCount"/>.</param>
        /// <param name="sizeInBytes">The size to assign as the value of <see cref="TopicRuntimeProperties.SizeInBytes"/>.</param>
        /// <param name="subscriptionCount">The count to assign as the value of <see cref="TopicRuntimeProperties.SubscriptionCount"/>.</param>
        /// <param name="createdAt">The time stamp to assign as the value of <see cref="TopicRuntimeProperties.CreatedAt"/>.</param>
        /// <param name="updatedAt">The time stamp to assign as the value of <see cref="TopicRuntimeProperties.UpdatedAt"/>.</param>
        /// <param name="accessedAt">The time stamp to assign as the value of <see cref="TopicRuntimeProperties.AccessedAt"/>.</param>
        /// <returns>The populated <see cref="TopicRuntimeProperties"/> instance to use for mocking.</returns>
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
        /// Creates a new <see cref="SubscriptionRuntimeProperties" /> instance for mocking.
        /// </summary>
        /// <param name="topicName">The name to assign as the value of <see cref="SubscriptionRuntimeProperties.TopicName"/>.</param>
        /// <param name="subscriptionName">The name to assign as the value of <see cref="SubscriptionRuntimeProperties.SubscriptionName"/>.</param>
        /// <param name="activeMessageCount">The count to assign as the value of <see cref="SubscriptionRuntimeProperties.ActiveMessageCount"/>.</param>
        /// <param name="deadLetterMessageCount">The count to assign as the value of <see cref="SubscriptionRuntimeProperties.DeadLetterMessageCount"/>.</param>
        /// <param name="transferDeadLetterMessageCount">The count to assign as the value of <see cref="SubscriptionRuntimeProperties.TransferDeadLetterMessageCount"/>.</param>
        /// <param name="transferMessageCount">The count to assign as the value of <see cref="SubscriptionRuntimeProperties.TransferMessageCount"/>.</param>
        /// <param name="totalMessageCount">The count to assign as the value of <see cref="SubscriptionRuntimeProperties.TotalMessageCount"/>.</param>
        /// <param name="createdAt">The time stamp to assign as the value of <see cref="SubscriptionRuntimeProperties.CreatedAt"/>.</param>
        /// <param name="updatedAt">The time stamp to assign as the value of <see cref="SubscriptionRuntimeProperties.UpdatedAt"/>.</param>
        /// <param name="accessedAt">The time stamp to assign as the value of <see cref="SubscriptionRuntimeProperties.AccessedAt"/>.</param>
        /// <returns>The populated <see cref="SubscriptionRuntimeProperties"/> instance to use for mocking.</returns>
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
        /// <remarks>
        ///  The batch instance keeps an internal copy of events successfully added to the batch through <see cref="ServiceBusMessageBatch.TryAddMessage(ServiceBusMessage)"/>, meaning that any
        ///  changes made to <paramref name="batchMessageStore"/> after adding the messages to the batch will not be reflected.
        /// </remarks>
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
            return new ServiceBusMessageBatch(transportBatch, new MessagingClientDiagnostics("mock", "mock", "mock", "mock", "mock"));
        }

        /// <summary>
        ///   Allows for the transport event batch created by the factory to be injected for testing purposes.
        /// </summary>
        ///
        private sealed class ListTransportBatch : TransportMessageBatch
        {
            /// <summary>The backing store for storing events in the batch.</summary>
            private readonly IList<ServiceBusMessage> _backingStore;

            /// <summary>The set of messages that have been added to the batch, in their <see cref="AmqpMessage" /> serialized format.</summary>
            private List<AmqpMessage> _batchMessages;

            /// <summary>A callback to be invoked when an adding a message via <see cref="TryAddMessage"/></summary>
            private readonly Func<ServiceBusMessage, bool> _tryAddCallback;

            /// <summary>The converter to use for translating <see cref="ServiceBusMessage" /> into an AMQP-specific message.</summary>
            private readonly AmqpMessageConverter _messageConverter;

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
                                        Func<ServiceBusMessage, bool> tryAddCallback)
            {
                MaxSizeInBytes = maxSizeInBytes;
                SizeInBytes = sizeInBytes;
                _backingStore = backingStore;
                _batchMessages = new List<AmqpMessage>();
                _messageConverter = new AmqpMessageConverter();
                foreach (var message in _backingStore)
                {
                    _batchMessages.Add(_messageConverter.SBMessageToAmqpMessage(message));
                }
                _tryAddCallback = tryAddCallback;
            }

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
                    _batchMessages.Add(_messageConverter.SBMessageToAmqpMessage(message));
                    return true;
                }

                return false;
            }

            /// <summary>
            ///   Clears the batch, removing all events and resetting the
            ///   available size.
            /// </summary>
            ///
            public override void Clear()
            {
                foreach (var message in _batchMessages)
                {
                    message.Dispose();
                }
                _batchMessages.Clear();
                _backingStore.Clear();
            }

            /// <summary>
            ///   Represents the batch as an enumerable set of transport-specific
            ///   representations of an event.
            /// </summary>
            ///
            /// <typeparam name="T">The transport-specific event representation being requested.</typeparam>
            ///
            /// <returns>The set of events as an enumerable of the requested type.</returns>
            ///
            public override IReadOnlyCollection<T> AsReadOnly<T>()
            {
                if (typeof(T) == typeof(AmqpMessage))
                {
                    return (IReadOnlyCollection<T>)_batchMessages;
                }
                else if (typeof(T) == typeof(ServiceBusMessage))
                {
                    return (IReadOnlyCollection<T>)_backingStore;
                }
                else
                {
                    throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedTransportEventType, typeof(T).Name));
                }
            }

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
