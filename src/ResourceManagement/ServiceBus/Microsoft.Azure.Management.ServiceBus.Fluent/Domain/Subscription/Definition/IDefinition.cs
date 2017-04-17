// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition
{
    using System;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;

    /// <summary>
    /// The stage of the subscription definition allowing specify batching behaviour.
    /// </summary>
    public interface IWithMessageBatching 
    {
        /// <summary>
        /// Specifies that the default batching should be disabled on this subscription.
        /// With batching service bus can batch multiple message when it write or delete messages
        /// from it's internal store.
        /// </summary>
        /// <return>The next stage of subscription definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithCreate WithoutMessageBatching();
    }

    /// <summary>
    /// The stage of the subscription definition allowing to specify maximum delivery count of message before
    /// moving it to dead-letter subscription.
    /// </summary>
    public interface IWithMessageMovedToDeadLetterSubscriptionOnMaxDeliveryCount 
    {
        /// <summary>
        /// Specifies maximum number of times a message can be delivered. Once this count has exceeded,
        /// message will be moved to dead-letter subscription.
        /// </summary>
        /// <param name="deliveryCount">Maximum delivery count.</param>
        /// <return>The next stage of subscription definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithCreate WithMessageMovedToDeadLetterSubscriptionOnMaxDeliveryCount(int deliveryCount);
    }

    /// <summary>
    /// The entirety of the subscription definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IBlank,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the subscription definition allowing to define default TTL for messages.
    /// </summary>
    public interface IWithDefaultMessageTTL 
    {
        /// <summary>
        /// Specifies the duration after which the message expires.
        /// Note: unless it is explicitly overridden the default ttl is infinite (TimeSpan.Max).
        /// </summary>
        /// <param name="ttl">Time to live duration.</param>
        /// <return>The next stage of subscription definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithCreate WithDefaultMessageTTL(TimeSpan ttl);
    }

    /// <summary>
    /// The stage of the subscription definition allowing to define duration for message lock.
    /// </summary>
    public interface IWithMessageLockDuration 
    {
        /// <summary>
        /// Specifies the amount of time that the message is locked for other receivers.
        /// Note: unless it is explicitly overridden the default lock duration is 60 seconds,
        /// the maximum allowed value is 300 seconds.
        /// </summary>
        /// <param name="durationInSeconds">Duration of a lock in seconds.</param>
        /// <return>The next stage of subscription definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithCreate WithMessageLockDurationInSeconds(int durationInSeconds);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.ServiceBus.Fluent.ISubscription>,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithDeleteOnIdle,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithMessageLockDuration,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithDefaultMessageTTL,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithSession,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithMessageBatching,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithExpiredMessageMovedToDeadLetterSubscription,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithMessageMovedToDeadLetterSubscriptionOnMaxDeliveryCount,
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException
    {
    }

    /// <summary>
    /// The stage of the subscription definition allowing to enable session support.
    /// </summary>
    public interface IWithSession 
    {
        /// <summary>
        /// Specifies that session support should be enabled for the subscription.
        /// </summary>
        /// <return>The next stage of subscription definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithCreate WithSession();
    }

    /// <summary>
    /// The stage of the subscription definition allowing to define auto delete behaviour.
    /// </summary>
    public interface IWithDeleteOnIdle 
    {
        /// <summary>
        /// The idle interval after which the subscription is automatically deleted.
        /// Note: unless it is explicitly overridden the default delete on idle duration
        /// is infinite (TimeSpan.Max).
        /// </summary>
        /// <param name="durationInMinutes">Idle duration in minutes.</param>
        /// <return>The next stage of subscription definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithCreate WithDeleteOnIdleDurationInMinutes(int durationInMinutes);
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
        /// <return>Next stage of the subscription definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithCreate WithNewAuthorizationRule(string name, params AccessRights[] rights);
    }

    /// <summary>
    /// The stage of the subscription definition allowing to specify whether message those are failed on
    /// filter evaluation can be moved to secondary dead-letter subscription.
    /// </summary>
    public interface IWithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException 
    {
        /// <summary>
        /// Specifies that filter evaluation failed message must be moved to dead-letter subscription.
        /// </summary>
        /// <return>The next stage of subscription definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithCreate WithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException();
    }

    /// <summary>
    /// The first stage of a subscription definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the subscription definition allowing to specify whether expired message can be moved
    /// to secondary dead-letter subscription.
    /// </summary>
    public interface IWithExpiredMessageMovedToDeadLetterSubscription 
    {
        /// <summary>
        /// Specifies that expired message must be moved to dead-letter subscription.
        /// </summary>
        /// <return>The next stage of subscription definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithCreate WithExpiredMessageMovedToDeadLetterSubscription();

        /// <summary>
        /// Specifies that expired message should not be moved to dead-letter subscription.
        /// </summary>
        /// <return>The next stage of subscription definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Subscription.Definition.IWithCreate WithoutExpiredMessageMovedToDeadLetterSubscription();
    }
}