// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent;
    using System;

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
        /// <return>Next stage of the queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate WithNewListenRule(string name);

        /// <summary>
        /// Creates a manage authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate WithNewManageRule(string name);

        /// <summary>
        /// Creates a send authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate WithNewSendRule(string name);
    }

    /// <summary>
    /// The stage of the queue definition allowing to define duration for message lock.
    /// </summary>
    public interface IWithMessageLockDuration 
    {
        /// <summary>
        /// Specifies the amount of time that the message is locked for other receivers.
        /// Note: unless it is explicitly overridden the default lock duration is 60 seconds,
        /// the maximum allowed value is 300 seconds.
        /// </summary>
        /// <param name="durationInSeconds">Duration of a lock in seconds.</param>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate WithMessageLockDurationInSeconds(int durationInSeconds);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.ServiceBus.Fluent.IQueue>,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithSize,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithPartitioning,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithDeleteOnIdle,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithMessageLockDuration,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithDefaultMessageTTL,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithSession,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithExpressMessage,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithMessageBatching,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithDuplicateMessageDetection,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithExpiredMessageMovedToDeadLetterQueue,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithMessageMovedToDeadLetterQueueOnMaxDeliveryCount,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithAuthorizationRule
    {
    }

    /// <summary>
    /// The stage of the queue definition allowing specify batching behaviour.
    /// </summary>
    public interface IWithMessageBatching 
    {
        /// <summary>
        /// Specifies that the default batching should be disabled on this queue.
        /// With batching Service Bus can batch multiple message when it write or delete messages
        /// from it's internal store.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate WithoutMessageBatching();
    }

    /// <summary>
    /// The stage of the queue definition allowing to define auto delete behaviour.
    /// </summary>
    public interface IWithDeleteOnIdle 
    {
        /// <summary>
        /// The idle interval after which the queue is automatically deleted.
        /// Note: unless it is explicitly overridden the default delete on idle duration
        /// is infinite (TimeSpan.Max).
        /// </summary>
        /// <param name="durationInMinutes">Idle duration in minutes.</param>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate WithDeleteOnIdleDurationInMinutes(int durationInMinutes);
    }

    /// <summary>
    /// The first stage of a queue definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the queue definition allowing to mark messages as express messages.
    /// </summary>
    public interface IWithExpressMessage 
    {
        /// <summary>
        /// Specifies that messages in this queue are express hence they can be cached in memory
        /// for some time before storing it in messaging store.
        /// Note: By default queue is not express.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate WithExpressMessage();
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
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(int deliveryCount);
    }

    /// <summary>
    /// The stage of the queue definition allowing to specify whether expired message can be moved
    /// to secondary dead-letter queue.
    /// </summary>
    public interface IWithExpiredMessageMovedToDeadLetterQueue 
    {
        /// <summary>
        /// Specifies that expired message must be moved to dead-letter queue.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate WithExpiredMessageMovedToDeadLetterQueue();
    }

    /// <summary>
    /// The stage of the queue definition allowing to define default TTL for messages.
    /// </summary>
    public interface IWithDefaultMessageTTL 
    {
        /// <summary>
        /// Specifies the duration after which the message expires.
        /// Note: unless it is explicitly overridden the default ttl is infinite (TimeSpan.Max).
        /// </summary>
        /// <param name="ttl">Time to live duration.</param>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate WithDefaultMessageTTL(TimeSpan ttl);
    }

    /// <summary>
    /// The stage of the queue definition allowing to enable session support.
    /// </summary>
    public interface IWithSession 
    {
        /// <summary>
        /// Specifies that session support should be enabled for the queue.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate WithSession();
    }

    /// <summary>
    /// The entirety of the Service Bus queue definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IBlank,
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the queue definition allowing to specify partitioning behaviour.
    /// </summary>
    public interface IWithPartitioning 
    {
        /// <summary>
        /// Specifies that the default partitioning should be disabled on this queue.
        /// Note: if the parent Service Bus is Premium SKU then partition cannot be
        /// disabled.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate WithoutPartitioning();

        /// <summary>
        /// Specifies that partitioning should be enabled on this queue.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate WithPartitioning();
    }

    /// <summary>
    /// The stage of the queue definition allowing to specify duration of the duplicate message
    /// detection history.
    /// </summary>
    public interface IWithDuplicateMessageDetection 
    {
        /// <summary>
        /// Specifies the duration of the duplicate message detection history.
        /// </summary>
        /// <param name="duplicateDetectionHistoryDuration">Duration of the history.</param>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate WithDuplicateMessageDetection(TimeSpan duplicateDetectionHistoryDuration);
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
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate WithSizeInMB(long sizeInMB);
    }
}