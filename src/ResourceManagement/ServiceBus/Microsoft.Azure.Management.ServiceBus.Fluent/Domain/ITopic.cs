// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update;
    using System;

    /// <summary>
    /// Type representing Service Bus topic.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface ITopic  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IIndependentChildResource<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusManager,Microsoft.Azure.Management.ServiceBus.Fluent.Models.TopicInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ServiceBus.Fluent.ITopic>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Topic.Update.IUpdate>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.ServiceBus.Fluent.Models.TopicInner>
    {
        /// <summary>
        /// Gets last time a message was sent, or the last time there was a receive request to this topic.
        /// </summary>
        System.DateTime AccessedAt { get; }

        /// <summary>
        /// Gets indicates whether express entities are enabled.
        /// </summary>
        bool IsExpressEnabled { get; }

        /// <summary>
        /// Gets entry point to manage subscriptions associated with the topic.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.ISubscriptions Subscriptions { get; }

        /// <summary>
        /// Gets the current status of the topic.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.Models.EntityStatus Status { get; }

        /// <summary>
        /// Gets number of active messages in the topic.
        /// </summary>
        long ActiveMessageCount { get; }

        /// <summary>
        /// Gets entry point to manage authorization rules for the Service Bus topic.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.ITopicAuthorizationRules AuthorizationRules { get; }

        /// <summary>
        /// Gets indicates whether server-side batched operations are enabled.
        /// </summary>
        bool IsBatchedOperationsEnabled { get; }

        /// <summary>
        /// Gets the maximum size of memory allocated for the topic in megabytes.
        /// </summary>
        long MaxSizeInMB { get; }

        /// <summary>
        /// Gets indicates if this topic requires duplicate detection.
        /// </summary>
        bool IsDuplicateDetectionEnabled { get; }

        /// <summary>
        /// Gets the duration of the duplicate detection history.
        /// </summary>
        System.TimeSpan DuplicateMessageDetectionHistoryDuration { get; }

        /// <summary>
        /// Gets the exact time the topic was updated.
        /// </summary>
        System.DateTime UpdatedAt { get; }

        /// <summary>
        /// Gets current size of the topic, in bytes.
        /// </summary>
        long CurrentSizeInBytes { get; }

        /// <summary>
        /// Gets number of messages transferred into dead letters.
        /// </summary>
        long TransferDeadLetterMessageCount { get; }

        /// <summary>
        /// Gets number of messages in the dead-letter topic.
        /// </summary>
        long DeadLetterMessageCount { get; }

        /// <summary>
        /// Gets number of messages sent to the topic that are yet to be released
        /// for consumption.
        /// </summary>
        long ScheduledMessageCount { get; }

        /// <summary>
        /// Gets the exact time the topic was created.
        /// </summary>
        System.DateTime CreatedAt { get; }

        /// <summary>
        /// Gets indicates whether the topic is to be partitioned across multiple message brokers.
        /// </summary>
        bool IsPartitioningEnabled { get; }

        /// <summary>
        /// Gets the idle duration after which the topic is automatically deleted.
        /// </summary>
        long DeleteOnIdleDurationInMinutes { get; }

        /// <summary>
        /// Gets the duration after which the message expires, starting from when the message is sent to topic.
        /// </summary>
        System.TimeSpan DefaultMessageTtlDuration { get; }

        /// <summary>
        /// Gets number of subscriptions for the topic.
        /// </summary>
        int SubscriptionCount { get; }

        /// <summary>
        /// Gets number of messages transferred to another topic, topic, or subscription.
        /// </summary>
        long TransferMessageCount { get; }
    }
}