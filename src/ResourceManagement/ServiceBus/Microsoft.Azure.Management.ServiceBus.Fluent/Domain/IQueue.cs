// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update;
    using System;

    /// <summary>
    /// Type representing Service Bus queue.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IQueue  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IIndependentChildResource<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusManager,Microsoft.Azure.Management.ServiceBus.Fluent.Models.QueueInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ServiceBus.Fluent.IQueue>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Queue.Update.IUpdate>
    {
        /// <summary>
        /// Gets the maximum number of a message delivery before marking it as dead-lettered.
        /// </summary>
        int MaxDeliveryCountBeforeDeadLetteringMessage { get; }

        /// <summary>
        /// Gets the duration of peek-lock which is the amount of time that the message is locked for other receivers.
        /// </summary>
        long LockDurationInSeconds { get; }

        /// <summary>
        /// Gets last time a message was sent, or the last time there was a receive request to this queue.
        /// </summary>
        System.DateTime AccessedAt { get; }

        /// <summary>
        /// Gets indicates whether express entities are enabled.
        /// </summary>
        bool IsExpressEnabled { get; }

        /// <summary>
        /// Gets the current status of the queue.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.Models.EntityStatus Status { get; }

        /// <summary>
        /// Gets number of active messages in the queue.
        /// </summary>
        long ActiveMessageCount { get; }

        /// <summary>
        /// Gets entry point to manage authorization rules for the Service Bus queue.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.IQueueAuthorizationRules AuthorizationRules { get; }

        /// <summary>
        /// Gets indicates whether server-side batched operations are enabled.
        /// </summary>
        bool IsBatchedOperationsEnabled { get; }

        /// <summary>
        /// Gets the maximum size of memory allocated for the queue in megabytes.
        /// </summary>
        long MaxSizeInMB { get; }

        /// <summary>
        /// Gets indicates whether the queue supports sessions.
        /// </summary>
        bool IsSessionEnabled { get; }

        /// <summary>
        /// Gets indicates if this queue requires duplicate detection.
        /// </summary>
        bool IsDuplicateDetectionEnabled { get; }

        /// <summary>
        /// Gets the duration of the duplicate detection history.
        /// </summary>
        System.TimeSpan DuplicateMessageDetectionHistoryDuration { get; }

        /// <summary>
        /// Gets the exact time the queue was updated.
        /// </summary>
        System.DateTime UpdatedAt { get; }

        /// <summary>
        /// Gets current size of the queue, in bytes.
        /// </summary>
        long CurrentSizeInBytes { get; }

        /// <summary>
        /// Gets number of messages transferred into dead letters.
        /// </summary>
        long TransferDeadLetterMessageCount { get; }

        /// <summary>
        /// Gets number of messages in the dead-letter queue.
        /// </summary>
        long DeadLetterMessageCount { get; }

        /// <summary>
        /// Gets number of messages sent to the queue that are yet to be released
        /// for consumption.
        /// </summary>
        long ScheduledMessageCount { get; }

        /// <summary>
        /// Gets the exact time the queue was created.
        /// </summary>
        System.DateTime CreatedAt { get; }

        /// <summary>
        /// Gets the duration after which the message expires, starting from when the message is sent to queue.
        /// </summary>
        System.TimeSpan DefaultMessageTtlDuration { get; }

        /// <summary>
        /// Gets the idle duration after which the queue is automatically deleted.
        /// </summary>
        long DeleteOnIdleDurationInMinutes { get; }

        /// <summary>
        /// Gets indicates whether the queue is to be partitioned across multiple message brokers.
        /// </summary>
        bool IsPartitioningEnabled { get; }

        /// <summary>
        /// Gets number of messages transferred to another queue, topic, or subscription.
        /// </summary>
        long TransferMessageCount { get; }

        /// <summary>
        /// Gets the number of messages in the queue.
        /// </summary>
        long MessageCount { get; }

        /// <summary>
        /// Gets indicates whether this queue has dead letter support when a message expires.
        /// </summary>
        bool IsDeadLetteringEnabledForExpiredMessages { get; }
    }
}