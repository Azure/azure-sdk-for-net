// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Subscription.Definition;
    using Subscription.Update;
    using System;

    internal partial class SubscriptionImpl 
    {
        /// <summary>
        /// The idle interval after which the subscription is automatically deleted.
        /// </summary>
        /// <param name="durationInMinutes">Idle duration in minutes.</param>
        /// <return>The next stage of subscription update.</return>
        Subscription.Update.IUpdate Subscription.Update.IWithDeleteOnIdle.WithDeleteOnIdleDurationInMinutes(int durationInMinutes)
        {
            return this.WithDeleteOnIdleDurationInMinutes(durationInMinutes) as Subscription.Update.IUpdate;
        }

        /// <summary>
        /// The idle interval after which the subscription is automatically deleted.
        /// Note: unless it is explicitly overridden the default delete on idle duration
        /// is infinite (TimeSpan.Max).
        /// </summary>
        /// <param name="durationInMinutes">Idle duration in minutes.</param>
        /// <return>The next stage of subscription definition.</return>
        Subscription.Definition.IWithCreate Subscription.Definition.IWithDeleteOnIdle.WithDeleteOnIdleDurationInMinutes(int durationInMinutes)
        {
            return this.WithDeleteOnIdleDurationInMinutes(durationInMinutes) as Subscription.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that service bus can batch multiple message when it write messages to or delete
        /// messages from it's internal store. This increases the throughput.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Subscription.Update.IUpdate Subscription.Update.IWithMessageBatching.WithMessageBatching()
        {
            return this.WithMessageBatching() as Subscription.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that batching of messages should be disabled when service bus write messages to
        /// or delete messages from it's internal store.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Subscription.Update.IUpdate Subscription.Update.IWithMessageBatching.WithoutMessageBatching()
        {
            return this.WithoutMessageBatching() as Subscription.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that the default batching should be disabled on this subscription.
        /// With batching service bus can batch multiple message when it write or delete messages
        /// from it's internal store.
        /// </summary>
        /// <return>The next stage of subscription definition.</return>
        Subscription.Definition.IWithCreate Subscription.Definition.IWithMessageBatching.WithoutMessageBatching()
        {
            return this.WithoutMessageBatching() as Subscription.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies maximum number of times a message can be delivered. Once this count has exceeded,
        /// message will be moved to dead-letter subscription.
        /// </summary>
        /// <param name="deliveryCount">Maximum delivery subscription.</param>
        /// <return>The next stage of subscription update.</return>
        Subscription.Update.IUpdate Subscription.Update.IWithMessageMovedToDeadLetterQueueOnMaxDeliveryCount.WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(int deliveryCount)
        {
            return this.WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(deliveryCount) as Subscription.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that expired message should not be moved to dead-letter subscription.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Subscription.Update.IUpdate Subscription.Update.IWithExpiredMessageMovedToDeadLetterSubscription.WithoutExpiredMessageMovedToDeadLetterSubscription()
        {
            return this.WithoutExpiredMessageMovedToDeadLetterSubscription() as Subscription.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that expired message must be moved to dead-letter subscription.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Subscription.Update.IUpdate Subscription.Update.IWithExpiredMessageMovedToDeadLetterSubscription.WithExpiredMessageMovedToDeadLetterSubscription()
        {
            return this.WithExpiredMessageMovedToDeadLetterSubscription() as Subscription.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that expired message should not be moved to dead-letter subscription.
        /// </summary>
        /// <return>The next stage of subscription definition.</return>
        Subscription.Definition.IWithCreate Subscription.Definition.IWithExpiredMessageMovedToDeadLetterSubscription.WithoutExpiredMessageMovedToDeadLetterSubscription()
        {
            return this.WithoutExpiredMessageMovedToDeadLetterSubscription() as Subscription.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that expired message must be moved to dead-letter subscription.
        /// </summary>
        /// <return>The next stage of subscription definition.</return>
        Subscription.Definition.IWithCreate Subscription.Definition.IWithExpiredMessageMovedToDeadLetterSubscription.WithExpiredMessageMovedToDeadLetterSubscription()
        {
            return this.WithExpiredMessageMovedToDeadLetterSubscription() as Subscription.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that filter evaluation failed message should not be moved to dead-letter subscription.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Subscription.Update.IUpdate Subscription.Update.IWithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException.WithoutMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException()
        {
            return this.WithoutMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException() as Subscription.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that filter evaluation failed message must be moved to dead-letter subscription.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Subscription.Update.IUpdate Subscription.Update.IWithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException.WithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException()
        {
            return this.WithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException() as Subscription.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that filter evaluation failed message must be moved to dead-letter subscription.
        /// </summary>
        /// <return>The next stage of subscription definition.</return>
        Subscription.Definition.IWithCreate Subscription.Definition.IWithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException.WithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException()
        {
            return this.WithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException() as Subscription.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the duration after which the message expires.
        /// </summary>
        /// <param name="ttl">Time to live duration.</param>
        /// <return>The next stage of subscription update.</return>
        Subscription.Update.IUpdate Subscription.Update.IWithDefaultMessageTTL.WithDefaultMessageTTL(TimeSpan ttl)
        {
            return this.WithDefaultMessageTTL(ttl) as Subscription.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the duration after which the message expires.
        /// Note: unless it is explicitly overridden the default ttl is infinite (TimeSpan.Max).
        /// </summary>
        /// <param name="ttl">Time to live duration.</param>
        /// <return>The next stage of subscription definition.</return>
        Subscription.Definition.IWithCreate Subscription.Definition.IWithDefaultMessageTTL.WithDefaultMessageTTL(TimeSpan ttl)
        {
            return this.WithDefaultMessageTTL(ttl) as Subscription.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies maximum number of times a message can be delivered. Once this count has exceeded,
        /// message will be moved to dead-letter subscription.
        /// </summary>
        /// <param name="deliveryCount">Maximum delivery count.</param>
        /// <return>The next stage of subscription definition.</return>
        Subscription.Definition.IWithCreate Subscription.Definition.IWithMessageMovedToDeadLetterSubscriptionOnMaxDeliveryCount.WithMessageMovedToDeadLetterSubscriptionOnMaxDeliveryCount(int deliveryCount)
        {
            return this.WithMessageMovedToDeadLetterSubscriptionOnMaxDeliveryCount(deliveryCount) as Subscription.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that session support should be enabled for the subscription.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Subscription.Update.IUpdate Subscription.Update.IWithSession.WithSession()
        {
            return this.WithSession() as Subscription.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that session support should be disabled for the subscription.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Subscription.Update.IUpdate Subscription.Update.IWithSession.WithoutSession()
        {
            return this.WithoutSession() as Subscription.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that session support should be enabled for the subscription.
        /// </summary>
        /// <return>The next stage of subscription definition.</return>
        Subscription.Definition.IWithCreate Subscription.Definition.IWithSession.WithSession()
        {
            return this.WithSession() as Subscription.Definition.IWithCreate;
        }

        /// <summary>
        /// Gets number of active messages in the subscription.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.ActiveMessageCount
        {
            get
            {
                return this.ActiveMessageCount();
            }
        }

        /// <summary>
        /// Gets the number of messages in the subscription.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.MessageCount
        {
            get
            {
                return this.MessageCount();
            }
        }

        /// <summary>
        /// Gets last time there was a receive request to this subscription.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.AccessedAt
        {
            get
            {
                return this.AccessedAt();
            }
        }

        /// <summary>
        /// Gets indicates whether the subscription supports sessions.
        /// </summary>
        bool Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.IsSessionEnabled
        {
            get
            {
                return this.IsSessionEnabled();
            }
        }

        /// <summary>
        /// Gets the duration after which the message expires, starting from when the message is sent to subscription.
        /// </summary>
        TimeSpan Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.DefaultMessageTtlDuration
        {
            get
            {
                return this.DefaultMessageTtlDuration() as TimeSpan;
            }
        }

        /// <summary>
        /// Gets the exact time the message was created.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.CreatedAt
        {
            get
            {
                return this.CreatedAt();
            }
        }

        /// <summary>
        /// Gets number of messages in the dead-letter subscription.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.DeadLetterMessageCount
        {
            get
            {
                return this.DeadLetterMessageCount();
            }
        }

        /// <summary>
        /// Gets number of messages transferred into dead letters.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.TransferDeadLetterMessageCount
        {
            get
            {
                return this.TransferDeadLetterMessageCount();
            }
        }

        /// <summary>
        /// Gets the duration of peek-lock which is the amount of time that the message is locked for other receivers.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.LockDurationInSeconds
        {
            get
            {
                return this.LockDurationInSeconds();
            }
        }

        /// <summary>
        /// Gets indicates whether server-side batched operations are enabled.
        /// </summary>
        bool Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.IsBatchedOperationsEnabled
        {
            get
            {
                return this.IsBatchedOperationsEnabled();
            }
        }

        /// <summary>
        /// Gets indicates whether this subscription has dead letter support when a message expires.
        /// </summary>
        bool Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.IsDeadLetteringEnabledForExpiredMessages
        {
            get
            {
                return this.IsDeadLetteringEnabledForExpiredMessages();
            }
        }

        /// <summary>
        /// Gets the exact time the message was updated.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.UpdatedAt
        {
            get
            {
                return this.UpdatedAt();
            }
        }

        /// <summary>
        /// Gets number of messages transferred to another queue, topic, or subscription.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.TransferMessageCount
        {
            get
            {
                return this.TransferMessageCount();
            }
        }

        /// <summary>
        /// Gets number of messages sent to the subscription that are yet to be released
        /// for consumption.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.ScheduledMessageCount
        {
            get
            {
                return this.ScheduledMessageCount();
            }
        }

        /// <summary>
        /// Gets the current status of the subscription.
        /// </summary>
        Management.Fluent.ServiceBus.Models.EntityStatus Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <summary>
        /// Gets the idle duration after which the subscription is automatically deleted.
        /// </summary>
        long Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.DeleteOnIdleDurationInMinutes
        {
            get
            {
                return this.DeleteOnIdleDurationInMinutes();
            }
        }

        /// <summary>
        /// Gets the maximum number of a message delivery before marking it as dead-lettered.
        /// </summary>
        int Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.MaxDeliveryCountBeforeDeadLetteringMessage
        {
            get
            {
                return this.MaxDeliveryCountBeforeDeadLetteringMessage();
            }
        }

        /// <summary>
        /// Gets indicates whether subscription has dead letter support on filter evaluation exceptions.
        /// </summary>
        bool Microsoft.Azure.Management.Servicebus.Fluent.ISubscription.IsDeadLetteringEnabledForFilterEvaluationFailedMessages
        {
            get
            {
                return this.IsDeadLetteringEnabledForFilterEvaluationFailedMessages();
            }
        }

        /// <summary>
        /// Specifies the amount of time that the message is locked for other receivers.
        /// </summary>
        /// <param name="durationInSeconds">Duration of a lock in seconds.</param>
        /// <return>The next stage of subscription update.</return>
        Subscription.Update.IUpdate Subscription.Update.IWithMessageLockDuration.WithMessageLockDurationInSeconds(int durationInSeconds)
        {
            return this.WithMessageLockDurationInSeconds(durationInSeconds) as Subscription.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the amount of time that the message is locked for other receivers.
        /// Note: unless it is explicitly overridden the default lock duration is 60 seconds,
        /// the maximum allowed value is 300 seconds.
        /// </summary>
        /// <param name="durationInSeconds">Duration of a lock in seconds.</param>
        /// <return>The next stage of subscription definition.</return>
        Subscription.Definition.IWithCreate Subscription.Definition.IWithMessageLockDuration.WithMessageLockDurationInSeconds(int durationInSeconds)
        {
            return this.WithMessageLockDurationInSeconds(durationInSeconds) as Subscription.Definition.IWithCreate;
        }
    }
}