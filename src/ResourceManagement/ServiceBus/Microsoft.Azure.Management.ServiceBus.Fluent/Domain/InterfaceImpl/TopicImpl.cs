// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Models;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition;
    using Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update;
    using System.Collections.Generic;
    using System;

    internal partial class TopicImpl 
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
        /// The idle interval after which the topic is automatically deleted.
        /// Note: unless it is explicitly overridden the default delete on idle duration
        /// is infinite (TimeSpan.Max).
        /// </summary>
        /// <param name="durationInMinutes">Idle duration in minutes.</param>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithDeleteOnIdle.WithDeleteOnIdleDurationInMinutes(int durationInMinutes)
        {
            return this.WithDeleteOnIdleDurationInMinutes(durationInMinutes) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate;
        }

        /// <summary>
        /// The idle interval after which the topic is automatically deleted.
        /// </summary>
        /// <param name="durationInMinutes">Idle duration in minutes.</param>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithDeleteOnIdle.WithDeleteOnIdleDurationInMinutes(int durationInMinutes)
        {
            return this.WithDeleteOnIdleDurationInMinutes(durationInMinutes) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that the default batching should be disabled on this topic.
        /// With batching Service Bus can batch multiple message when it write or delete messages
        /// from it's internal store.
        /// </summary>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithMessageBatching.WithoutMessageBatching()
        {
            return this.WithoutMessageBatching() as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that batching of messages should be disabled when Service Bus write messages to
        /// or delete messages from it's internal store.
        /// </summary>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithMessageBatching.WithoutMessageBatching()
        {
            return this.WithoutMessageBatching() as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that service bus can batch multiple message when it write messages to or delete
        /// messages from it's internal store. This increases the throughput.
        /// </summary>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithMessageBatching.WithMessageBatching()
        {
            return this.WithMessageBatching() as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the duration of the duplicate message detection history.
        /// </summary>
        /// <param name="duplicateDetectionHistoryDuration">Duration of the history.</param>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithDuplicateMessageDetection.WithDuplicateMessageDetection(TimeSpan duplicateDetectionHistoryDuration)
        {
            return this.WithDuplicateMessageDetection(duplicateDetectionHistoryDuration) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that duplicate message detection needs to be disabled.
        /// </summary>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithDuplicateMessageDetection.WithoutDuplicateMessageDetection()
        {
            return this.WithoutDuplicateMessageDetection() as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the duration of the duplicate message detection history.
        /// </summary>
        /// <param name="duration">Duration of the history.</param>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithDuplicateMessageDetection.WithDuplicateMessageDetectionHistoryDuration(TimeSpan duration)
        {
            return this.WithDuplicateMessageDetectionHistoryDuration(duration) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that partitioning should be enabled on this topic.
        /// </summary>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithPartitioning.WithPartitioning()
        {
            return this.WithPartitioning() as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that the default partitioning should be disabled on this topic.
        /// Note: if the parent Service Bus is Premium SKU then partition cannot be
        /// disabled.
        /// </summary>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithPartitioning.WithoutPartitioning()
        {
            return this.WithoutPartitioning() as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a send authorization rule for the topic.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithAuthorizationRule.WithNewSendRule(string name)
        {
            return this.WithNewSendRule(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a manage authorization rule for the topic.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithAuthorizationRule.WithNewManageRule(string name)
        {
            return this.WithNewManageRule(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a listen authorization rule for the topic.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithAuthorizationRule.WithNewListenRule(string name)
        {
            return this.WithNewListenRule(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a send authorization rule for the topic.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithAuthorizationRule.WithNewSendRule(string name)
        {
            return this.WithNewSendRule(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate;
        }

        /// <summary>
        /// Creates a manage authorization rule for the topic.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithAuthorizationRule.WithNewManageRule(string name)
        {
            return this.WithNewManageRule(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate;
        }

        /// <summary>
        /// Creates a listen authorization rule for the topic.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithAuthorizationRule.WithNewListenRule(string name)
        {
            return this.WithNewListenRule(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate;
        }

        /// <summary>
        /// Removes an authorization rule for the topic.
        /// </summary>
        /// <param name="name">Rule name.</param>
        /// <return>Next stage of the topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithAuthorizationRule.WithoutAuthorizationRule(string name)
        {
            return this.WithoutAuthorizationRule(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate;
        }

        /// <summary>
        /// Creates a subscription entity for the Service Bus topic.
        /// </summary>
        /// <param name="name">Queue name.</param>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithSubscription.WithNewSubscription(string name)
        {
            return this.WithNewSubscription(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a subscription entity for the Service Bus topic.
        /// </summary>
        /// <param name="name">Queue name.</param>
        /// <return>Next stage of the Service Bus topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithSubscription.WithNewSubscription(string name)
        {
            return this.WithNewSubscription(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate;
        }

        /// <summary>
        /// Removes a subscription entity associated with the Service Bus topic.
        /// </summary>
        /// <param name="name">Subscription name.</param>
        /// <return>Next stage of the Service Bus topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithSubscription.WithoutSubscription(string name)
        {
            return this.WithoutSubscription(name) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the duration after which the message expires.
        /// Note: unless it is explicitly overridden the default ttl is infinite (TimeSpan.Max).
        /// </summary>
        /// <param name="ttl">Time to live duration.</param>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithDefaultMessageTTL.WithDefaultMessageTTL(TimeSpan ttl)
        {
            return this.WithDefaultMessageTTL(ttl) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the duration after which the message expires.
        /// </summary>
        /// <param name="ttl">Time to live duration.</param>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithDefaultMessageTTL.WithDefaultMessageTTL(TimeSpan ttl)
        {
            return this.WithDefaultMessageTTL(ttl) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate;
        }

        /// <summary>
        /// Gets number of subscriptions for the topic.
        /// </summary>
        int Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.SubscriptionCount
        {
            get
            {
                return this.SubscriptionCount();
            }
        }

        /// <summary>
        /// Gets number of messages transferred to another topic, topic, or subscription.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.TransferMessageCount
        {
            get
            {
                return this.TransferMessageCount();
            }
        }

        /// <summary>
        /// Gets the maximum size of memory allocated for the topic in megabytes.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.MaxSizeInMB
        {
            get
            {
                return this.MaxSizeInMB();
            }
        }

        /// <summary>
        /// Gets the exact time the topic was created.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.CreatedAt
        {
            get
            {
                return this.CreatedAt();
            }
        }

        /// <summary>
        /// Gets number of messages sent to the topic that are yet to be released
        /// for consumption.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.ScheduledMessageCount
        {
            get
            {
                return this.ScheduledMessageCount();
            }
        }

        /// <summary>
        /// Gets indicates whether express entities are enabled.
        /// </summary>
        bool Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.IsExpressEnabled
        {
            get
            {
                return this.IsExpressEnabled();
            }
        }

        /// <summary>
        /// Gets current size of the topic, in bytes.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.CurrentSizeInBytes
        {
            get
            {
                return this.CurrentSizeInBytes();
            }
        }

        /// <summary>
        /// Gets number of active messages in the topic.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.ActiveMessageCount
        {
            get
            {
                return this.ActiveMessageCount();
            }
        }

        /// <summary>
        /// Gets entry point to manage subscriptions associated with the topic.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.ISubscriptions Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.Subscriptions
        {
            get
            {
                return this.Subscriptions() as Microsoft.Azure.Management.ServiceBus.Fluent.ISubscriptions;
            }
        }

        /// <summary>
        /// Gets the current status of the topic.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.Models.EntityStatus Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <summary>
        /// Gets the duration after which the message expires, starting from when the message is sent to topic.
        /// </summary>
        System.TimeSpan Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.DefaultMessageTtlDuration
        {
            get
            {
                return this.DefaultMessageTtlDuration();
            }
        }

        /// <summary>
        /// Gets entry point to manage authorization rules for the Service Bus topic.
        /// </summary>
        Microsoft.Azure.Management.ServiceBus.Fluent.ITopicAuthorizationRules Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.AuthorizationRules
        {
            get
            {
                return this.AuthorizationRules() as Microsoft.Azure.Management.ServiceBus.Fluent.ITopicAuthorizationRules;
            }
        }

        /// <summary>
        /// Gets last time a message was sent, or the last time there was a receive request to this topic.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.AccessedAt
        {
            get
            {
                return this.AccessedAt();
            }
        }

        /// <summary>
        /// Gets indicates whether the topic is to be partitioned across multiple message brokers.
        /// </summary>
        bool Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.IsPartitioningEnabled
        {
            get
            {
                return this.IsPartitioningEnabled();
            }
        }

        /// <summary>
        /// Gets number of messages transferred into dead letters.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.TransferDeadLetterMessageCount
        {
            get
            {
                return this.TransferDeadLetterMessageCount();
            }
        }

        /// <summary>
        /// Gets the idle duration after which the topic is automatically deleted.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.DeleteOnIdleDurationInMinutes
        {
            get
            {
                return this.DeleteOnIdleDurationInMinutes();
            }
        }

        /// <summary>
        /// Gets indicates whether server-side batched operations are enabled.
        /// </summary>
        bool Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.IsBatchedOperationsEnabled
        {
            get
            {
                return this.IsBatchedOperationsEnabled();
            }
        }

        /// <summary>
        /// Gets indicates if this topic requires duplicate detection.
        /// </summary>
        bool Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.IsDuplicateDetectionEnabled
        {
            get
            {
                return this.IsDuplicateDetectionEnabled();
            }
        }

        /// <summary>
        /// Gets number of messages in the dead-letter topic.
        /// </summary>
        long Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.DeadLetterMessageCount
        {
            get
            {
                return this.DeadLetterMessageCount();
            }
        }

        /// <summary>
        /// Gets the exact time the topic was updated.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.UpdatedAt
        {
            get
            {
                return this.UpdatedAt();
            }
        }

        /// <summary>
        /// Gets the duration of the duplicate detection history.
        /// </summary>
        System.TimeSpan Microsoft.Azure.Management.ServiceBus.Fluent.ITopic.DuplicateMessageDetectionHistoryDuration
        {
            get
            {
                return this.DuplicateMessageDetectionHistoryDuration();
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
        /// Specifies the maximum size of memory allocated for the topic.
        /// </summary>
        /// <param name="sizeInMB">Size in MB.</param>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithSize.WithSizeInMB(long sizeInMB)
        {
            return this.WithSizeInMB(sizeInMB) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the maximum size of memory allocated for the topic.
        /// </summary>
        /// <param name="sizeInMB">Size in MB.</param>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithSize.WithSizeInMB(long sizeInMB)
        {
            return this.WithSizeInMB(sizeInMB) as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that messages in this topic are express hence they can be cached in memory
        /// for some time before storing it in messaging store.
        /// Note: By default topic is not express.
        /// </summary>
        /// <return>The next stage of topic definition.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithExpressMessage.WithExpressMessage()
        {
            return this.WithExpressMessage() as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that messages in this topic are not express hence they should be cached in memory.
        /// </summary>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithExpressMessage.WithoutExpressMessage()
        {
            return this.WithoutExpressMessage() as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that messages in this topic are express hence they can be cached in memory
        /// for some time before storing it in messaging store.
        /// </summary>
        /// <return>The next stage of topic update.</return>
        Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IWithExpressMessage.WithExpressMessage()
        {
            return this.WithExpressMessage() as Microsoft.Azure.Management.ServiceBus.Fluent.Topic.Update.IUpdate;
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
    }
}