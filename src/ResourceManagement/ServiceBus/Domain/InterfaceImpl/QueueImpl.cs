// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update;
    using System.Collections.Generic;
    using System;

    internal partial class QueueImpl 
    {
        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusManager>.Manager
        {
            get
            {
                return this.Manager as Microsoft.Azure.Management.ServiceBus.Fluent.IServiceBusManager;
            }
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName;
            }
        }

        /// <summary>
        /// Gets the name of the region the resource is in.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.RegionName
        {
            get
            {
                return this.RegionName;
            }
        }

        /// <summary>
        /// Gets the type of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Type
        {
            get
            {
                return this.Type;
            }
        }

        /// <summary>
        /// Gets the region the resource is in.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Region
        {
            get
            {
                return this.Region as Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region;
            }
        }

        /// <summary>
        /// Gets the tags for the resource.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Tags
        {
            get
            {
                return this.Tags as System.Collections.Generic.IReadOnlyDictionary<string,string>;
            }
        }

        /// <summary>
        /// The idle interval after which the queue is automatically deleted.
        /// Note: unless it is explicitly overridden the default delete on idle duration
        /// is infinite (TimeSpan.Max).
        /// </summary>
        /// <param name="durationInMinutes">Idle duration in minutes.</param>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithDeleteOnIdle.WithDeleteOnIdleDurationInMinutes(int durationInMinutes)
        {
            return this.WithDeleteOnIdleDurationInMinutes(durationInMinutes) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// The idle interval after which the queue is automatically deleted.
        /// </summary>
        /// <param name="durationInMinutes">Idle duration in minutes.</param>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithDeleteOnIdle.WithDeleteOnIdleDurationInMinutes(int durationInMinutes)
        {
            return this.WithDeleteOnIdleDurationInMinutes(durationInMinutes) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Creates a send authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithAuthorizationRule.WithNewSendRule(string name)
        {
            return this.WithNewSendRule(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a manage authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithAuthorizationRule.WithNewManageRule(string name)
        {
            return this.WithNewManageRule(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a listen authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithAuthorizationRule.WithNewListenRule(string name)
        {
            return this.WithNewListenRule(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a send authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithAuthorizationRule.WithNewSendRule(string name)
        {
            return this.WithNewSendRule(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Creates a manage authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithAuthorizationRule.WithNewManageRule(string name)
        {
            return this.WithNewManageRule(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Creates a listen authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithAuthorizationRule.WithNewListenRule(string name)
        {
            return this.WithNewListenRule(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Removes an authorization rule for the queue.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithAuthorizationRule.WithoutAuthorizationRule(string name)
        {
            return this.WithoutAuthorizationRule(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that session support should be enabled for the queue.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithSession.WithSession()
        {
            return this.WithSession() as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that session support should be disabled for the queue.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithSession.WithoutSession()
        {
            return this.WithoutSession() as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that session support should be enabled for the queue.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithSession.WithSession()
        {
            return this.WithSession() as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that messages in this queue are express hence they can be cached in memory
        /// for some time before storing it in messaging store.
        /// Note: By default queue is not express.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithExpressMessage.WithExpressMessage()
        {
            return this.WithExpressMessage() as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that messages in this queue are not express hence they should be cached in memory.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithExpressMessage.WithoutExpressMessage()
        {
            return this.WithoutExpressMessage() as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that messages in this queue are express hence they can be cached in memory
        /// for some time before storing it in messaging store.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithExpressMessage.WithExpressMessage()
        {
            return this.WithExpressMessage() as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the maximum size of memory allocated for the queue.
        /// </summary>
        /// <param name="sizeInMB">Size in MB.</param>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithSize.WithSizeInMB(long sizeInMB)
        {
            return this.WithSizeInMB(sizeInMB) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the maximum size of memory allocated for the queue.
        /// </summary>
        /// <param name="sizeInMB">Size in MB.</param>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithSize.WithSizeInMB(long sizeInMB)
        {
            return this.WithSizeInMB(sizeInMB) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that partitioning should be enabled on this queue.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithPartitioning.WithPartitioning()
        {
            return this.WithPartitioning() as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that the default partitioning should be disabled on this queue.
        /// Note: if the parent Service Bus is Premium SKU then partition cannot be
        /// disabled.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithPartitioning.WithoutPartitioning()
        {
            return this.WithoutPartitioning() as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the amount of time that the message is locked for other receivers.
        /// Note: unless it is explicitly overridden the default lock duration is 60 seconds,
        /// the maximum allowed value is 300 seconds.
        /// </summary>
        /// <param name="durationInSeconds">Duration of a lock in seconds.</param>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithMessageLockDuration.WithMessageLockDurationInSeconds(int durationInSeconds)
        {
            return this.WithMessageLockDurationInSeconds(durationInSeconds) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the amount of time that the message is locked for other receivers.
        /// </summary>
        /// <param name="durationInSeconds">Duration of a lock in seconds.</param>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithMessageLockDuration.WithMessageLockDurationInSeconds(int durationInSeconds)
        {
            return this.WithMessageLockDurationInSeconds(durationInSeconds) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the duration after which the message expires.
        /// Note: unless it is explicitly overridden the default ttl is infinite (TimeSpan.Max).
        /// </summary>
        /// <param name="ttl">Time to live duration.</param>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithDefaultMessageTTL.WithDefaultMessageTTL(TimeSpan ttl)
        {
            return this.WithDefaultMessageTTL(ttl) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the duration after which the message expires.
        /// </summary>
        /// <param name="ttl">Time to live duration.</param>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithDefaultMessageTTL.WithDefaultMessageTTL(TimeSpan ttl)
        {
            return this.WithDefaultMessageTTL(ttl) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the duration of the duplicate message detection history.
        /// </summary>
        /// <param name="duplicateDetectionHistoryDuration">Duration of the history.</param>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithDuplicateMessageDetection.WithDuplicateMessageDetection(TimeSpan duplicateDetectionHistoryDuration)
        {
            return this.WithDuplicateMessageDetection(duplicateDetectionHistoryDuration) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that duplicate message detection needs to be disabled.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithDuplicateMessageDetection.WithoutDuplicateMessageDetection()
        {
            return this.WithoutDuplicateMessageDetection() as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the duration of the duplicate message detection history.
        /// </summary>
        /// <param name="duration">Duration of the history.</param>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithDuplicateMessageDetection.WithDuplicateMessageDetectionHistoryDuration(TimeSpan duration)
        {
            return this.WithDuplicateMessageDetectionHistoryDuration(duration) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies maximum number of times a message can be delivered. Once this count has exceeded,
        /// message will be moved to dead-letter queue.
        /// </summary>
        /// <param name="deliveryCount">Maximum delivery count.</param>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithMessageMovedToDeadLetterQueueOnMaxDeliveryCount.WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(int deliveryCount)
        {
            return this.WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(deliveryCount) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies maximum number of times a message can be delivered. Once this count has exceeded,
        /// message will be moved to dead-letter queue.
        /// </summary>
        /// <param name="deliveryCount">Maximum delivery count.</param>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithMessageMovedToDeadLetterQueueOnMaxDeliveryCount.WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(int deliveryCount)
        {
            return this.WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(deliveryCount) as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Gets number of messages transferred to another queue, topic, or subscription.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.TransferMessageCount
        {
            get
            {
                return this.TransferMessageCount();
            }
        }

        /// <summary>
        /// Gets the maximum size of memory allocated for the queue in megabytes.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.MaxSizeInMB
        {
            get
            {
                return this.MaxSizeInMB();
            }
        }

        /// <summary>
        /// Gets the exact time the queue was created.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.CreatedAt
        {
            get
            {
                return this.CreatedAt();
            }
        }

        /// <summary>
        /// Gets number of messages sent to the queue that are yet to be released
        /// for consumption.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.ScheduledMessageCount
        {
            get
            {
                return this.ScheduledMessageCount();
            }
        }

        /// <summary>
        /// Gets indicates whether express entities are enabled.
        /// </summary>
        bool Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.IsExpressEnabled
        {
            get
            {
                return this.IsExpressEnabled();
            }
        }

        /// <summary>
        /// Gets current size of the queue, in bytes.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.CurrentSizeInBytes
        {
            get
            {
                return this.CurrentSizeInBytes();
            }
        }

        /// <summary>
        /// Gets number of active messages in the queue.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.ActiveMessageCount
        {
            get
            {
                return this.ActiveMessageCount();
            }
        }

        /// <summary>
        /// Gets the current status of the queue.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.Models.EntityStatus Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <summary>
        /// Gets the duration after which the message expires, starting from when the message is sent to queue.
        /// </summary>
        System.TimeSpan Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.DefaultMessageTtlDuration
        {
            get
            {
                return this.DefaultMessageTtlDuration();
            }
        }

        /// <summary>
        /// Gets entry point to manage authorization rules for the Service Bus queue.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.IQueueAuthorizationRules Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.AuthorizationRules
        {
            get
            {
                return this.AuthorizationRules() as Microsoft.Azure.Management.ServiceBus.Fluent.IQueueAuthorizationRules;
            }
        }

        /// <summary>
        /// Gets the number of messages in the queue.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.MessageCount
        {
            get
            {
                return this.MessageCount();
            }
        }

        /// <summary>
        /// Gets the duration of peek-lock which is the amount of time that the message is locked for other receivers.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.LockDurationInSeconds
        {
            get
            {
                return this.LockDurationInSeconds();
            }
        }

        /// <summary>
        /// Gets last time a message was sent, or the last time there was a receive request to this queue.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.AccessedAt
        {
            get
            {
                return this.AccessedAt();
            }
        }

        /// <summary>
        /// Gets indicates whether the queue is to be partitioned across multiple message brokers.
        /// </summary>
        bool Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.IsPartitioningEnabled
        {
            get
            {
                return this.IsPartitioningEnabled();
            }
        }

        /// <summary>
        /// Gets number of messages transferred into dead letters.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.TransferDeadLetterMessageCount
        {
            get
            {
                return this.TransferDeadLetterMessageCount();
            }
        }

        /// <summary>
        /// Gets the idle duration after which the queue is automatically deleted.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.DeleteOnIdleDurationInMinutes
        {
            get
            {
                return this.DeleteOnIdleDurationInMinutes();
            }
        }

        /// <summary>
        /// Gets indicates whether this queue has dead letter support when a message expires.
        /// </summary>
        bool Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.IsDeadLetteringEnabledForExpiredMessages
        {
            get
            {
                return this.IsDeadLetteringEnabledForExpiredMessages();
            }
        }

        /// <summary>
        /// Gets indicates whether server-side batched operations are enabled.
        /// </summary>
        bool Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.IsBatchedOperationsEnabled
        {
            get
            {
                return this.IsBatchedOperationsEnabled();
            }
        }

        /// <summary>
        /// Gets indicates if this queue requires duplicate detection.
        /// </summary>
        bool Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.IsDuplicateDetectionEnabled
        {
            get
            {
                return this.IsDuplicateDetectionEnabled();
            }
        }

        /// <summary>
        /// Gets number of messages in the dead-letter queue.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.DeadLetterMessageCount
        {
            get
            {
                return this.DeadLetterMessageCount();
            }
        }

        /// <summary>
        /// Gets the exact time the queue was updated.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.UpdatedAt
        {
            get
            {
                return this.UpdatedAt();
            }
        }

        /// <summary>
        /// Gets the maximum number of a message delivery before marking it as dead-lettered.
        /// </summary>
        int Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.MaxDeliveryCountBeforeDeadLetteringMessage
        {
            get
            {
                return this.MaxDeliveryCountBeforeDeadLetteringMessage();
            }
        }

        /// <summary>
        /// Gets the duration of the duplicate detection history.
        /// </summary>
        System.TimeSpan Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.DuplicateMessageDetectionHistoryDuration
        {
            get
            {
                return this.DuplicateMessageDetectionHistoryDuration();
            }
        }

        /// <summary>
        /// Gets indicates whether the queue supports sessions.
        /// </summary>
        bool Microsoft.Azure.Management.ServiceBus.Fluent.IQueue.IsSessionEnabled
        {
            get
            {
                return this.IsSessionEnabled();
            }
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name;
            }
        }

        /// <summary>
        /// Specifies that expired message must be moved to dead-letter queue.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithExpiredMessageMovedToDeadLetterQueue.WithExpiredMessageMovedToDeadLetterQueue()
        {
            return this.WithExpiredMessageMovedToDeadLetterQueue() as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that expired message must be moved to dead-letter queue.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithExpiredMessageMovedToDeadLetterQueue.WithExpiredMessageMovedToDeadLetterQueue()
        {
            return this.WithExpiredMessageMovedToDeadLetterQueue() as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that expired message should not be moved to dead-letter queue.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithExpiredMessageMovedToDeadLetterQueue.WithoutExpiredMessageMovedToDeadLetterQueue()
        {
            return this.WithoutExpiredMessageMovedToDeadLetterQueue() as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id;
            }
        }

        /// <summary>
        /// Specifies that the default batching should be disabled on this queue.
        /// With batching Service Bus can batch multiple message when it write or delete messages
        /// from it's internal store.
        /// </summary>
        /// <return>The next stage of queue definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithMessageBatching.WithoutMessageBatching()
        {
            return this.WithoutMessageBatching() as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that batching of messages should be disabled when Service Bus write messages to
        /// or delete messages from it's internal store.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithMessageBatching.WithoutMessageBatching()
        {
            return this.WithoutMessageBatching() as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that Service Bus can batch multiple message when it write messages to or delete
        /// messages from it's internal store. This increases the throughput.
        /// </summary>
        /// <return>The next stage of queue update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IWithMessageBatching.WithMessageBatching()
        {
            return this.WithMessageBatching() as Microsoft.Azure.Management.ServiceBus.Fluent.Queue.Update.IUpdate;
        }
    }
}