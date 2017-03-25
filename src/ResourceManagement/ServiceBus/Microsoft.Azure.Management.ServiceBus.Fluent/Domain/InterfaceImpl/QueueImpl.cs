// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Queue.Definition;
    using Queue.Update;
    using System.Collections.Generic;
    using System;
    using Management.Fluent.ServiceBus.Models;

    internal partial class QueueImpl 
    {
        /// <summary>
        /// Specifies that expired message must be moved to dead-letter queue.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Queue.Definition.IWithCreate Queue.Definition.IWithExpiredMessageMovedToDeadLetterQueue.WithExpiredMessageMovedToDeadLetterQueue()
        {
            return this.WithExpiredMessageMovedToDeadLetterQueue() as Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that expired message should not be moved to dead-letter queue.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithExpiredMessageMovedToDeadLetterQueue.WithoutExpiredMessageMovedToDeadLetterQueue()
        {
            return this.WithoutExpiredMessageMovedToDeadLetterQueue() as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that expired message must be moved to dead-letter queue.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithExpiredMessageMovedToDeadLetterQueue.WithExpiredMessageMovedToDeadLetterQueue()
        {
            return this.WithExpiredMessageMovedToDeadLetterQueue() as Queue.Update.IUpdate;
        }

        /// <summary>
        /// The idle interval after which the queue is automatically deleted.
        /// Note: unless it is explicitly overridden the default delete on idle duration
        /// is infinite (TimeSpan.Max).
        /// </summary>
        /// <param name="durationInMinutes">Idle duration in minutes.</param>
        /// <return>The next stage of queue definition.</return>
        Queue.Definition.IWithCreate Queue.Definition.IWithDeleteOnIdle.WithDeleteOnIdleDurationInMinutes(int durationInMinutes)
        {
            return this.WithDeleteOnIdleDurationInMinutes(durationInMinutes) as Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// The idle interval after which the queue is automatically deleted.
        /// </summary>
        /// <param name="durationInMinutes">Idle duration in minutes.</param>
        /// <return>The next stage of queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithDeleteOnIdle.WithDeleteOnIdleDurationInMinutes(int durationInMinutes)
        {
            return this.WithDeleteOnIdleDurationInMinutes(durationInMinutes) as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that the default batching should be disabled on this queue.
        /// With batching Service Bus can batch multiple message when it write or delete messages
        /// from it's internal store.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Queue.Definition.IWithCreate Queue.Definition.IWithMessageBatching.WithoutMessageBatching()
        {
            return this.WithoutMessageBatching() as Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that batching of messages should be disabled when Service Bus write messages to
        /// or delete messages from it's internal store.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithMessageBatching.WithoutMessageBatching()
        {
            return this.WithoutMessageBatching() as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that Service Bus can batch multiple message when it write messages to or delete
        /// messages from it's internal store. This increases the throughput.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithMessageBatching.WithMessageBatching()
        {
            return this.WithMessageBatching() as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies maximum number of times a message can be delivered. Once this count has exceeded,
        /// message will be moved to dead-letter queue.
        /// </summary>
        /// <param name="deliveryCount">Maximum delivery count.</param>
        /// <return>The next stage of queue definition.</return>
        Queue.Definition.IWithCreate Queue.Definition.IWithMessageMovedToDeadLetterQueueOnMaxDeliveryCount.WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(int deliveryCount)
        {
            return this.WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(deliveryCount) as Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies maximum number of times a message can be delivered. Once this count has exceeded,
        /// message will be moved to dead-letter queue.
        /// </summary>
        /// <param name="deliveryCount">Maximum delivery count.</param>
        /// <return>The next stage of queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithMessageMovedToDeadLetterQueueOnMaxDeliveryCount.WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(int deliveryCount)
        {
            return this.WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(deliveryCount) as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the duration of the duplicate message detection history.
        /// </summary>
        /// <param name="duplicateDetectionHistoryDuration">Duration of the history.</param>
        /// <return>The next stage of queue definition.</return>
        Queue.Definition.IWithCreate Queue.Definition.IWithDuplicateMessageDetection.WithDuplicateMessageDetection(TimeSpan duplicateDetectionHistoryDuration)
        {
            return this.WithDuplicateMessageDetection(duplicateDetectionHistoryDuration) as Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the duration of the duplicate message detection history.
        /// </summary>
        /// <param name="duration">Duration of the history.</param>
        /// <return>The next stage of queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithDuplicateMessageDetection.WithDuplicateMessageDetectionHistoryDuration(TimeSpan duration)
        {
            return this.WithDuplicateMessageDetectionHistoryDuration(duration) as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that duplicate message detection needs to be disabled.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithDuplicateMessageDetection.WithoutDuplicateMessageDetection()
        {
            return this.WithoutDuplicateMessageDetection() as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that the default partitioning should be disabled on this queue.
        /// Note: if the parent Service Bus is Premium SKU then partition cannot be
        /// disabled.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Queue.Definition.IWithCreate Queue.Definition.IWithPartitioning.WithoutPartitioning()
        {
            return this.WithoutPartitioning() as Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that partitioning should be enabled on this queue.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Queue.Definition.IWithCreate Queue.Definition.IWithPartitioning.WithPartitioning()
        {
            return this.WithPartitioning() as Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a manage authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue definition.</return>
        Queue.Definition.IWithCreate Queue.Definition.IWithAuthorizationRule.WithNewManageRule(string name)
        {
            return this.WithNewManageRule(name) as Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a listen authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue definition.</return>
        Queue.Definition.IWithCreate Queue.Definition.IWithAuthorizationRule.WithNewListenRule(string name)
        {
            return this.WithNewListenRule(name) as Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a send authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue definition.</return>
        Queue.Definition.IWithCreate Queue.Definition.IWithAuthorizationRule.WithNewSendRule(string name)
        {
            return this.WithNewSendRule(name) as Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a manage authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithAuthorizationRule.WithNewManageRule(string name)
        {
            return this.WithNewManageRule(name) as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Creates a listen authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithAuthorizationRule.WithNewListenRule(string name)
        {
            return this.WithNewListenRule(name) as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Creates a send authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithAuthorizationRule.WithNewSendRule(string name)
        {
            return this.WithNewSendRule(name) as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Removes an authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithAuthorizationRule.WithoutAuthorizationRule(string name)
        {
            return this.WithoutAuthorizationRule(name) as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the duration after which the message expires.
        /// Note: unless it is explicitly overridden the default ttl is infinite (TimeSpan.Max).
        /// </summary>
        /// <param name="ttl">Time to live duration.</param>
        /// <return>The next stage of queue definition.</return>
        Queue.Definition.IWithCreate Queue.Definition.IWithDefaultMessageTTL.WithDefaultMessageTTL(TimeSpan ttl)
        {
            return this.WithDefaultMessageTTL(ttl) as Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the duration after which the message expires.
        /// </summary>
        /// <param name="ttl">Time to live duration.</param>
        /// <return>The next stage of queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithDefaultMessageTTL.WithDefaultMessageTTL(TimeSpan ttl)
        {
            return this.WithDefaultMessageTTL(ttl) as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Gets current size of the queue, in bytes.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.IQueue.CurrentSizeInBytes
        {
            get
            {
                return this.CurrentSizeInBytes();
            }
        }

        /// <summary>
        /// Gets the idle duration after which the queue is automatically deleted.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.IQueue.DeleteOnIdleDurationInMinutes
        {
            get
            {
                return this.DeleteOnIdleDurationInMinutes();
            }
        }

        /// <summary>
        /// Gets number of active messages in the queue.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.IQueue.ActiveMessageCount
        {
            get
            {
                return this.ActiveMessageCount();
            }
        }

        /// <summary>
        /// Gets indicates whether the queue is to be partitioned across multiple message brokers.
        /// </summary>
        bool Microsoft.Azure.Management.Servicebus.Fluent.IQueue.IsPartitioningEnabled
        {
            get
            {
                return this.IsPartitioningEnabled();
            }
        }

        /// <summary>
        /// Gets the exact time the queue was created.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Servicebus.Fluent.IQueue.CreatedAt
        {
            get
            {
                return this.CreatedAt();
            }
        }

        /// <summary>
        /// Gets indicates whether this queue has dead letter support when a message expires.
        /// </summary>
        bool Microsoft.Azure.Management.Servicebus.Fluent.IQueue.IsDeadLetteringEnabledForExpiredMessages
        {
            get
            {
                return this.IsDeadLetteringEnabledForExpiredMessages();
            }
        }

        /// <summary>
        /// Gets indicates whether server-side batched operations are enabled.
        /// </summary>
        bool Microsoft.Azure.Management.Servicebus.Fluent.IQueue.IsBatchedOperationsEnabled
        {
            get
            {
                return this.IsBatchedOperationsEnabled();
            }
        }

        /// <summary>
        /// Gets entry point to manage authorization rules for the Service Bus queue.
        /// </summary>
        Microsoft.Azure.Management.Servicebus.Fluent.IQueueAuthorizationRules Microsoft.Azure.Management.Servicebus.Fluent.IQueue.AuthorizationRules
        {
            get
            {
                return this.AuthorizationRules() as Microsoft.Azure.Management.Servicebus.Fluent.IQueueAuthorizationRules;
            }
        }

        /// <summary>
        /// Gets the number of messages in the queue.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.IQueue.MessageCount
        {
            get
            {
                return this.MessageCount();
            }
        }

        /// <summary>
        /// Gets the maximum size of memory allocated for the queue in megabytes.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.IQueue.MaxSizeInMB
        {
            get
            {
                return this.MaxSizeInMB();
            }
        }

        /// <summary>
        /// Gets number of messages transferred to another queue, topic, or subscription.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.IQueue.TransferMessageCount
        {
            get
            {
                return this.TransferMessageCount();
            }
        }

        /// <summary>
        /// Gets the duration after which the message expires, starting from when the message is sent to queue.
        /// </summary>
        TimeSpan Microsoft.Azure.Management.Servicebus.Fluent.IQueue.DefaultMessageTtlDuration
        {
            get
            {
                return this.DefaultMessageTtlDuration() as TimeSpan;
            }
        }

        /// <summary>
        /// Gets indicates whether the queue supports sessions.
        /// </summary>
        bool Microsoft.Azure.Management.Servicebus.Fluent.IQueue.IsSessionEnabled
        {
            get
            {
                return this.IsSessionEnabled();
            }
        }

        /// <summary>
        /// Gets the current status of the queue.
        /// </summary>
        EntityStatus Microsoft.Azure.Management.Servicebus.Fluent.IQueue.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <summary>
        /// Gets number of messages sent to the queue that are yet to be released
        /// for consumption.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.IQueue.ScheduledMessageCount
        {
            get
            {
                return this.ScheduledMessageCount();
            }
        }

        /// <summary>
        /// Gets indicates if this queue requires duplicate detection.
        /// </summary>
        bool Microsoft.Azure.Management.Servicebus.Fluent.IQueue.IsDuplicateDetectionEnabled
        {
            get
            {
                return this.IsDuplicateDetectionEnabled();
            }
        }

        /// <summary>
        /// Gets the exact time the queue was updated.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Servicebus.Fluent.IQueue.UpdatedAt
        {
            get
            {
                return this.UpdatedAt();
            }
        }

        /// <summary>
        /// Gets last time a message was sent, or the last time there was a receive request to this queue.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Servicebus.Fluent.IQueue.AccessedAt
        {
            get
            {
                return this.AccessedAt();
            }
        }

        /// <summary>
        /// Gets number of messages transferred into dead letters.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.IQueue.TransferDeadLetterMessageCount
        {
            get
            {
                return this.TransferDeadLetterMessageCount();
            }
        }

        /// <summary>
        /// Gets the duration of the duplicate detection history.
        /// </summary>
        TimeSpan Microsoft.Azure.Management.Servicebus.Fluent.IQueue.DuplicateMessageDetectionHistoryDuration
        {
            get
            {
                return this.DuplicateMessageDetectionHistoryDuration() as TimeSpan;
            }
        }

        /// <summary>
        /// Gets the maximum number of a message delivery before marking it as dead-lettered.
        /// </summary>
        int Microsoft.Azure.Management.Servicebus.Fluent.IQueue.MaxDeliveryCountBeforeDeadLetteringMessage
        {
            get
            {
                return this.MaxDeliveryCountBeforeDeadLetteringMessage();
            }
        }

        /// <summary>
        /// Gets the duration of peek-lock which is the amount of time that the message is locked for other receivers.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.IQueue.LockDurationInSeconds
        {
            get
            {
                return this.LockDurationInSeconds();
            }
        }

        /// <summary>
        /// Gets indicates whether express entities are enabled.
        /// </summary>
        bool Microsoft.Azure.Management.Servicebus.Fluent.IQueue.IsExpressEnabled
        {
            get
            {
                return this.IsExpressEnabled();
            }
        }

        /// <summary>
        /// Gets number of messages in the dead-letter queue.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.IQueue.DeadLetterMessageCount
        {
            get
            {
                return this.DeadLetterMessageCount();
            }
        }

        /// <summary>
        /// Specifies the maximum size of memory allocated for the queue.
        /// </summary>
        /// <param name="sizeInMB">Size in MB.</param>
        /// <return>The next stage of queue definition.</return>
        Queue.Definition.IWithCreate Queue.Definition.IWithSize.WithSizeInMB(long sizeInMB)
        {
            return this.WithSizeInMB(sizeInMB) as Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the maximum size of memory allocated for the queue.
        /// </summary>
        /// <param name="sizeInMB">Size in MB.</param>
        /// <return>The next stage of queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithSize.WithSizeInMB(long sizeInMB)
        {
            return this.WithSizeInMB(sizeInMB) as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that session support should be enabled for the queue.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Queue.Definition.IWithCreate Queue.Definition.IWithSession.WithSession()
        {
            return this.WithSession() as Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that session support should be disabled for the queue.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithSession.WithoutSession()
        {
            return this.WithoutSession() as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that session support should be enabled for the queue.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithSession.WithSession()
        {
            return this.WithSession() as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that messages in this queue are express hence they can be cached in memory
        /// for some time before storing it in messaging store.
        /// Note: By default queue is not express.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Queue.Definition.IWithCreate Queue.Definition.IWithExpressMessage.WithExpressMessage()
        {
            return this.WithExpressMessage() as Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that messages in this queue are express hence they can be cached in memory
        /// for some time before storing it in messaging store.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithExpressMessage.WithExpressMessage()
        {
            return this.WithExpressMessage() as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that messages in this queue are not express hence they should be cached in memory.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithExpressMessage.WithoutExpressMessage()
        {
            return this.WithoutExpressMessage() as Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the amount of time that the message is locked for other receivers.
        /// Note: unless it is explicitly overridden the default lock duration is 60 seconds,
        /// the maximum allowed value is 300 seconds.
        /// </summary>
        /// <param name="durationInSeconds">Duration of a lock in seconds.</param>
        /// <return>The next stage of queue definition.</return>
        Queue.Definition.IWithCreate Queue.Definition.IWithMessageLockDuration.WithMessageLockDurationInSeconds(int durationInSeconds)
        {
            return this.WithMessageLockDurationInSeconds(durationInSeconds) as Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the amount of time that the message is locked for other receivers.
        /// </summary>
        /// <param name="durationInSeconds">Duration of a lock in seconds.</param>
        /// <return>The next stage of queue update.</return>
        Queue.Update.IUpdate Queue.Update.IWithMessageLockDuration.WithMessageLockDurationInSeconds(int durationInSeconds)
        {
            return this.WithMessageLockDurationInSeconds(durationInSeconds) as Queue.Update.IUpdate;
        }
    }
}