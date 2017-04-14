// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update
{
    using System;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;

    /// <summary>
    /// The stage of the subscription definition allowing to specify maximum delivery count of message before
    /// moving it to dead-letter queue.
    /// </summary>
    public interface IWithMessageMovedToDeadLetterQueueOnMaxDeliveryCount 
    {
        /// <summary>
        /// Specifies maximum number of times a message can be delivered. Once this count has exceeded,
        /// message will be moved to dead-letter subscription.
        /// </summary>
        /// <param name="deliveryCount">Maximum delivery subscription.</param>
        /// <return>The next stage of subscription update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IUpdate WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(int deliveryCount);
    }

    /// <summary>
    /// The stage of the subscription definition allowing configure message batching behaviour.
    /// </summary>
    public interface IWithMessageBatching 
    {
        /// <summary>
        /// Specifies that service bus can batch multiple message when it write messages to or delete
        /// messages from it's internal store. This increases the throughput.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IUpdate WithMessageBatching();

        /// <summary>
        /// Specifies that batching of messages should be disabled when service bus write messages to
        /// or delete messages from it's internal store.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IUpdate WithoutMessageBatching();
    }

    /// <summary>
    /// The stage of the subscription definition allowing to define default TTL for messages.
    /// </summary>
    public interface IWithDefaultMessageTTL 
    {
        /// <summary>
        /// Specifies the duration after which the message expires.
        /// </summary>
        /// <param name="ttl">Time to live duration.</param>
        /// <return>The next stage of subscription update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IUpdate WithDefaultMessageTTL(TimeSpan ttl);
    }

    /// <summary>
    /// The template for a subscription update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ServiceBus.Fluent.ISubscription>,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IWithDeleteOnIdle,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IWithMessageLockDuration,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IWithDefaultMessageTTL,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IWithSession,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IWithMessageBatching,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IWithExpiredMessageMovedToDeadLetterSubscription,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IWithMessageMovedToDeadLetterQueueOnMaxDeliveryCount,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IWithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException
    {
    }

    /// <summary>
    /// The stage of the queue definition allowing to add an authorization rule for accessing
    /// the subscription.
    /// </summary>
    public interface IWithAuthorizationRule 
    {
        /// <summary>
        /// Creates an authorization rule for the subscription.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <param name="rights">Rule rights.</param>
        /// <return>Next stage of the subscription update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IUpdate WithNewAuthorizationRule(string name, params AccessRights[] rights);

        /// <summary>
        /// Removes an authorization rule for the subscription.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the subscription update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IUpdate WithoutNewAuthorizationRule(string name);
    }

    /// <summary>
    /// The stage of the subscription definition allowing to define duration for message lock.
    /// </summary>
    public interface IWithMessageLockDuration 
    {
        /// <summary>
        /// Specifies the amount of time that the message is locked for other receivers.
        /// </summary>
        /// <param name="durationInSeconds">Duration of a lock in seconds.</param>
        /// <return>The next stage of subscription update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IUpdate WithMessageLockDurationInSeconds(int durationInSeconds);
    }

    /// <summary>
    /// The stage of the subscription definition allowing to define auto delete behaviour.
    /// </summary>
    public interface IWithDeleteOnIdle 
    {
        /// <summary>
        /// The idle interval after which the subscription is automatically deleted.
        /// </summary>
        /// <param name="durationInMinutes">Idle duration in minutes.</param>
        /// <return>The next stage of subscription update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IUpdate WithDeleteOnIdleDurationInMinutes(int durationInMinutes);
    }

    /// <summary>
    /// The stage of the subscription update allowing to specify whether expired message can be moved
    /// to secondary dead-letter subscription.
    /// </summary>
    public interface IWithExpiredMessageMovedToDeadLetterSubscription 
    {
        /// <summary>
        /// Specifies that expired message must be moved to dead-letter subscription.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IUpdate WithExpiredMessageMovedToDeadLetterSubscription();

        /// <summary>
        /// Specifies that expired message should not be moved to dead-letter subscription.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IUpdate WithoutExpiredMessageMovedToDeadLetterSubscription();
    }

    /// <summary>
    /// The stage of the subscription definition allowing to enable session support.
    /// </summary>
    public interface IWithSession 
    {
        /// <summary>
        /// Specifies that session support should be disabled for the subscription.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IUpdate WithoutSession();

        /// <summary>
        /// Specifies that session support should be enabled for the subscription.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IUpdate WithSession();
    }

    /// <summary>
    /// The stage of the subscription definition allowing to specify whether message those are failed on
    /// filter evaluation can be moved to secondary dead-letter subscription.
    /// </summary>
    public interface IWithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException 
    {
        /// <summary>
        /// Specifies that filter evaluation failed message should not be moved to dead-letter subscription.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IUpdate WithoutMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException();

        /// <summary>
        /// Specifies that filter evaluation failed message must be moved to dead-letter subscription.
        /// </summary>
        /// <return>The next stage of subscription update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Update.IUpdate WithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException();
    }
}