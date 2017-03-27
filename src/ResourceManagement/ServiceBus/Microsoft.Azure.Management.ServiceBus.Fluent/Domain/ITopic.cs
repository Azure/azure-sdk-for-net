// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using Topic.Update;
    using System;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ResourceActions;
    using ServiceBus.Fluent;

    /// <summary>
    /// Type representing Service Bus topic.
    /// </summary>
    public interface ITopic  :
        IIndependentChildResource<IServiceBusManager, Management.Fluent.ServiceBus.Models.TopicInner>,
        IRefreshable<Microsoft.Azure.Management.Servicebus.Fluent.ITopic>,
        IUpdatable<Topic.Update.IUpdate>,
        IHasInner<Management.Fluent.ServiceBus.Models.TopicInner>
    {
        /// <summary>
        /// Gets entry point to manage subscriptions associated with the topic.
        /// </summary>
        Microsoft.Azure.Management.Servicebus.Fluent.ISubscriptions Subscriptions { get; }

        /// <summary>
        /// Gets last time a message was sent, or the last time there was a receive request to this topic.
        /// </summary>
        System.DateTime AccessedAt { get; }

        /// <summary>
        /// Gets the maximum size of memory allocated for the topic in megabytes.
        /// </summary>
        long MaxSizeInMB { get; }

        /// <summary>
        /// Gets number of messages transferred to another topic, topic, or subscription.
        /// </summary>
        long TransferMessageCount { get; }

        /// <summary>
        /// Gets number of subscriptions for the topic.
        /// </summary>
        int SubscriptionCount { get; }

        /// <summary>
        /// Gets entry point to manage authorization rules for the Service Bus topic.
        /// </summary>
        Microsoft.Azure.Management.Servicebus.Fluent.ITopicAuthorizationRules AuthorizationRules { get; }

        /// <summary>
        /// Gets number of messages transferred into dead letters.
        /// </summary>
        long TransferDeadLetterMessageCount { get; }

        /// <summary>
        /// Gets the duration after which the message expires, starting from when the message is sent to topic.
        /// </summary>
        TimeSpan DefaultMessageTtlDuration { get; }

        /// <summary>
        /// Gets indicates whether server-side batched operations are enabled.
        /// </summary>
        bool IsBatchedOperationsEnabled { get; }

        /// <summary>
        /// Gets number of messages in the dead-letter topic.
        /// </summary>
        long DeadLetterMessageCount { get; }

        /// <summary>
        /// Gets indicates if this topic requires duplicate detection.
        /// </summary>
        bool IsDuplicateDetectionEnabled { get; }

        /// <summary>
        /// Gets the exact time the topic was created.
        /// </summary>
        System.DateTime CreatedAt { get; }

        /// <summary>
        /// Gets the idle duration after which the topic is automatically deleted.
        /// </summary>
        long DeleteOnIdleDurationInMinutes { get; }

        /// <summary>
        /// Gets the duration of the duplicate detection history.
        /// </summary>
        TimeSpan DuplicateMessageDetectionHistoryDuration { get; }

        /// <summary>
        /// Gets indicates whether express entities are enabled.
        /// </summary>
        bool IsExpressEnabled { get; }

        /// <summary>
        /// Gets number of messages sent to the topic that are yet to be released
        /// for consumption.
        /// </summary>
        long ScheduledMessageCount { get; }

        /// <summary>
        /// Gets indicates whether the topic is to be partitioned across multiple message brokers.
        /// </summary>
        bool IsPartitioningEnabled { get; }

        /// <summary>
        /// Gets the exact time the topic was updated.
        /// </summary>
        System.DateTime UpdatedAt { get; }

        /// <summary>
        /// Gets current size of the topic, in bytes.
        /// </summary>
        long CurrentSizeInBytes { get; }

        /// <summary>
        /// Gets number of active messages in the topic.
        /// </summary>
        long ActiveMessageCount { get; }

        /// <summary>
        /// Gets the current status of the topic.
        /// </summary>
        Management.Fluent.ServiceBus.Models.EntityStatus Status { get; }
    }
}