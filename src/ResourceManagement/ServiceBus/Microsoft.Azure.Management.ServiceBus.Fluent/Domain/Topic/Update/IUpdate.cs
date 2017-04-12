// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent;
    using System;

    /// <summary>
    /// The stage of the topic definition allowing configure message batching behaviour.
    /// </summary>
    public interface IWithMessageBatching 
    {
        /// <summary>
        /// Specifies that service bus can batch multiple message when it write messages to or delete
        /// messages from it's internal store. This increases the throughput.
        /// </summary>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate WithMessageBatching();

        /// <summary>
        /// Specifies that batching of messages should be disabled when Service Bus write messages to
        /// or delete messages from it's internal store.
        /// </summary>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate WithoutMessageBatching();
    }

    /// <summary>
    /// The stage of the topic definition allowing to specify size.
    /// </summary>
    public interface IWithSize 
    {
        /// <summary>
        /// Specifies the maximum size of memory allocated for the topic.
        /// </summary>
        /// <param name="sizeInMB">Size in MB.</param>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate WithSizeInMB(long sizeInMB);
    }

    /// <summary>
    /// The template for a Service Bus topic update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.ServiceBus.Fluent.ITopic>,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithSize,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithDeleteOnIdle,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithDefaultMessageTTL,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithExpressMessage,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithMessageBatching,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithDuplicateMessageDetection,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithSubscription,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithAuthorizationRule
    {
    }

    /// <summary>
    /// The stage of the topic definition allowing to define default TTL for messages.
    /// </summary>
    public interface IWithDefaultMessageTTL 
    {
        /// <summary>
        /// Specifies the duration after which the message expires.
        /// </summary>
        /// <param name="ttl">Time to live duration.</param>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate WithDefaultMessageTTL(TimeSpan ttl);
    }

    /// <summary>
    /// The stage of the Service Bus namespace update allowing to manage subscriptions for the topic.
    /// </summary>
    public interface IWithSubscription 
    {
        /// <summary>
        /// Removes a subscription entity associated with the Service Bus topic.
        /// </summary>
        /// <param name="name">Subscription name.</param>
        /// <return>Next stage of the Service Bus topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate WithoutSubscription(string name);

        /// <summary>
        /// Creates a subscription entity for the Service Bus topic.
        /// </summary>
        /// <param name="name">Queue name.</param>
        /// <return>Next stage of the Service Bus topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate WithNewSubscription(string name);
    }

    /// <summary>
    /// The stage of the topic definition allowing to specify duration of the duplicate message
    /// detection history.
    /// </summary>
    public interface IWithDuplicateMessageDetection 
    {
        /// <summary>
        /// Specifies that duplicate message detection needs to be disabled.
        /// </summary>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate WithoutDuplicateMessageDetection();

        /// <summary>
        /// Specifies the duration of the duplicate message detection history.
        /// </summary>
        /// <param name="duration">Duration of the history.</param>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate WithDuplicateMessageDetectionHistoryDuration(TimeSpan duration);
    }

    /// <summary>
    /// The stage of the topic definition allowing to define auto delete behaviour.
    /// </summary>
    public interface IWithDeleteOnIdle 
    {
        /// <summary>
        /// The idle interval after which the topic is automatically deleted.
        /// </summary>
        /// <param name="durationInMinutes">Idle duration in minutes.</param>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate WithDeleteOnIdleDurationInMinutes(int durationInMinutes);
    }

    /// <summary>
    /// The stage of the topic definition allowing to mark it as either holding regular or express
    /// messages.
    /// </summary>
    public interface IWithExpressMessage 
    {
        /// <summary>
        /// Specifies that messages in this topic are not express hence they should be cached in memory.
        /// </summary>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate WithoutExpressMessage();

        /// <summary>
        /// Specifies that messages in this topic are express hence they can be cached in memory
        /// for some time before storing it in messaging store.
        /// </summary>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate WithExpressMessage();
    }

    /// <summary>
    /// The stage of the topic definition allowing to add an authorization rule for accessing
    /// the topic.
    /// </summary>
    public interface IWithAuthorizationRule 
    {
        /// <summary>
        /// Creates a listen authorization rule for the topic.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate WithNewListenRule(string name);

        /// <summary>
        /// Creates a manage authorization rule for the topic.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate WithNewManageRule(string name);

        /// <summary>
        /// Removes an authorization rule for the topic.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate WithoutAuthorizationRule(string name);

        /// <summary>
        /// Creates a send authorization rule for the topic.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate WithNewSendRule(string name);
    }
}