// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition
{
    using System;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent;

    /// <summary>
    /// The stage of the topic definition allowing to define default TTL for messages.
    /// </summary>
    public interface IWithDefaultMessageTTL 
    {
        /// <summary>
        /// Specifies the duration after which the message expires.
        /// Note: unless it is explicitly overridden the default ttl is infinite (TimeSpan.Max).
        /// </summary>
        /// <param name="ttl">Time to live duration.</param>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate WithDefaultMessageTTL(TimeSpan ttl);
    }

    /// <summary>
    /// The stage of the topic definition allowing to specify duration of the duplicate message
    /// detection history.
    /// </summary>
    public interface IWithDuplicateMessageDetection 
    {
        /// <summary>
        /// Specifies the duration of the duplicate message detection history.
        /// </summary>
        /// <param name="duplicateDetectionHistoryDuration">Duration of the history.</param>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate WithDuplicateMessageDetection(TimeSpan duplicateDetectionHistoryDuration);
    }

    /// <summary>
    /// The stage of the topic definition allowing to define auto delete behaviour.
    /// </summary>
    public interface IWithDeleteOnIdle 
    {
        /// <summary>
        /// The idle interval after which the topic is automatically deleted.
        /// Note: unless it is explicitly overridden the default delete on idle duration
        /// is infinite (TimeSpan.Max).
        /// </summary>
        /// <param name="durationInMinutes">Idle duration in minutes.</param>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate WithDeleteOnIdleDurationInMinutes(int durationInMinutes);
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
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate WithSizeInMB(long sizeInMB);
    }

    /// <summary>
    /// The stage of the Service Bus namespace update allowing to manage subscriptions for the topic.
    /// </summary>
    public interface IWithSubscription 
    {
        /// <summary>
        /// Creates a subscription entity for the Service Bus topic.
        /// </summary>
        /// <param name="name">Queue name.</param>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate WithNewSubscription(string name);
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
        /// <return>Next stage of the topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate WithNewListenRule(string name);

        /// <summary>
        /// Creates a manage authorization rule for the topic.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate WithNewManageRule(string name);

        /// <summary>
        /// Creates a send authorization rule for the topic.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate WithNewSendRule(string name);
    }

    /// <summary>
    /// The stage of the topic definition allowing to mark messages as express messages.
    /// </summary>
    public interface IWithExpressMessage 
    {
        /// <summary>
        /// Specifies that messages in this topic are express hence they can be cached in memory
        /// for some time before storing it in messaging store.
        /// Note: By default topic is not express.
        /// </summary>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate WithExpressMessage();
    }

    /// <summary>
    /// The stage of the topic definition allowing specify batching behaviour.
    /// </summary>
    public interface IWithMessageBatching 
    {
        /// <summary>
        /// Specifies that the default batching should be disabled on this topic.
        /// With batching Service Bus can batch multiple message when it write or delete messages
        /// from it's internal store.
        /// </summary>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate WithoutMessageBatching();
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created (via  WithCreate.create()), but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.ServiceBus.Fluent.ITopic>,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithSize,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithPartitioning,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithDeleteOnIdle,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithDefaultMessageTTL,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithExpressMessage,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithMessageBatching,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithDuplicateMessageDetection,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithSubscription,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithAuthorizationRule
    {
    }

    /// <summary>
    /// The entirety of the Service Bus topic definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IBlank,
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The first stage of a topic definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the topic definition allowing to specify partitioning behaviour.
    /// </summary>
    public interface IWithPartitioning 
    {
        /// <summary>
        /// Specifies that the default partitioning should be disabled on this topic.
        /// Note: if the parent Service Bus is Premium SKU then partition cannot be
        /// disabled.
        /// </summary>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate WithoutPartitioning();

        /// <summary>
        /// Specifies that partitioning should be enabled on this topic.
        /// </summary>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate WithPartitioning();
    }
}