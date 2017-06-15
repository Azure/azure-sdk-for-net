// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent;
    using System;

    /// <summary>
    /// The template for Service Bus queue update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ServiceBus.Fluent.IQueue>,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithSize,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithDeleteOnIdle,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithMessageLockDuration,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithDefaultMessageTTL,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithSession,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithExpressMessage,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithMessageBatching,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithDuplicateMessageDetection,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithExpiredMessageMovedToDeadLetterQueue,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithMessageMovedToDeadLetterQueueOnMaxDeliveryCount,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithAuthorizationRule
    {
    }

    /// <summary>
    /// The stage of the queue definition allowing to enable session support.
    /// </summary>
    public interface IWithSession 
    {
        /// <summary>
        /// Specifies that session support should be disabled for the queue.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithoutSession();

        /// <summary>
        /// Specifies that session support should be enabled for the queue.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithSession();
    }

    /// <summary>
    /// The stage of the queue definition allowing to define auto delete behaviour.
    /// </summary>
    public interface IWithDeleteOnIdle 
    {
        /// <summary>
        /// The idle interval after which the queue is automatically deleted.
        /// </summary>
        /// <param name="durationInMinutes">Idle duration in minutes.</param>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithDeleteOnIdleDurationInMinutes(int durationInMinutes);
    }

    /// <summary>
    /// The stage of the queue definition allowing to mark it as either holding regular or express
    /// messages.
    /// </summary>
    public interface IWithExpressMessage 
    {
        /// <summary>
        /// Specifies that messages in this queue are not express hence they should be cached in memory.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithoutExpressMessage();

        /// <summary>
        /// Specifies that messages in this queue are express hence they can be cached in memory
        /// for some time before storing it in messaging store.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithExpressMessage();
    }

    /// <summary>
    /// The stage of the queue definition allowing to define default TTL for messages.
    /// </summary>
    public interface IWithDefaultMessageTTL 
    {
        /// <summary>
        /// Specifies the duration after which the message expires.
        /// </summary>
        /// <param name="ttl">Time to live duration.</param>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithDefaultMessageTTL(TimeSpan ttl);
    }

    /// <summary>
    /// The stage of the queue definition allowing to specify maximum delivery count of message before
    /// moving it to dead-letter queue.
    /// </summary>
    public interface IWithMessageMovedToDeadLetterQueueOnMaxDeliveryCount 
    {
        /// <summary>
        /// Specifies maximum number of times a message can be delivered. Once this count has exceeded,
        /// message will be moved to dead-letter queue.
        /// </summary>
        /// <param name="deliveryCount">Maximum delivery count.</param>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(int deliveryCount);
    }

    /// <summary>
    /// The stage of the queue definition allowing to specify size.
    /// </summary>
    public interface IWithSize 
    {
        /// <summary>
        /// Specifies the maximum size of memory allocated for the queue.
        /// </summary>
        /// <param name="sizeInMB">Size in MB.</param>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithSizeInMB(long sizeInMB);
    }

    /// <summary>
    /// The stage of the queue definition allowing to define duration for message lock.
    /// </summary>
    public interface IWithMessageLockDuration 
    {
        /// <summary>
        /// Specifies the amount of time that the message is locked for other receivers.
        /// </summary>
        /// <param name="durationInSeconds">Duration of a lock in seconds.</param>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithMessageLockDurationInSeconds(int durationInSeconds);
    }

    /// <summary>
    /// The stage of the queue definition allowing to specify duration of the duplicate message
    /// detection history.
    /// </summary>
    public interface IWithDuplicateMessageDetection 
    {
        /// <summary>
        /// Specifies that duplicate message detection needs to be disabled.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithoutDuplicateMessageDetection();

        /// <summary>
        /// Specifies the duration of the duplicate message detection history.
        /// </summary>
        /// <param name="duration">Duration of the history.</param>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithDuplicateMessageDetectionHistoryDuration(TimeSpan duration);
    }

    /// <summary>
    /// The stage of the queue definition allowing to add an authorization rule for accessing
    /// the queue.
    /// </summary>
    public interface IWithAuthorizationRule 
    {
        /// <summary>
        /// Creates a listen authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithNewListenRule(string name);

        /// <summary>
        /// Creates a manage authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithNewManageRule(string name);

        /// <summary>
        /// Removes an authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithoutAuthorizationRule(string name);

        /// <summary>
        /// Creates a send authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithNewSendRule(string name);
    }

    /// <summary>
    /// The stage of the queue definition allowing to specify whether expired message can be moved
    /// to secondary dead-letter queue.
    /// </summary>
    public interface IWithExpiredMessageMovedToDeadLetterQueue 
    {
        /// <summary>
        /// Specifies that expired message should not be moved to dead-letter queue.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithoutExpiredMessageMovedToDeadLetterQueue();

        /// <summary>
        /// Specifies that expired message must be moved to dead-letter queue.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithExpiredMessageMovedToDeadLetterQueue();
    }

    /// <summary>
    /// The stage of the queue definition allowing configure message batching behaviour.
    /// </summary>
    public interface IWithMessageBatching 
    {
        /// <summary>
        /// Specifies that Service Bus can batch multiple message when it write messages to or delete
        /// messages from it's internal store. This increases the throughput.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithMessageBatching();

        /// <summary>
        /// Specifies that batching of messages should be disabled when Service Bus write messages to
        /// or delete messages from it's internal store.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate WithoutMessageBatching();
    }
}