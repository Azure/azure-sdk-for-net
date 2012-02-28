//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Windows.Foundation;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Service bus service.
    /// </summary>
    public interface IServiceBusService
    {
        /// <summary>
        /// Lists all available queues in the namespace.
        /// </summary>
        /// <returns>Collection of queues.</returns>
        IAsyncOperation<IEnumerable<QueueInfo>> ListQueuesAsync();

        /// <summary>
        /// Gets a queue with the given name.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <returns>Queue data.</returns>
        IAsyncOperation<QueueInfo> GetQueueAsync(string queueName);

        /// <summary>
        /// Deletes a queue with the given name.
        /// </summary>
        /// <param name="queueName">Queue name.</param>
        /// <returns>Asynchronous operation.</returns>
        IAsyncAction DeleteQueueAsync(string queueName);

        /// <summary>
        /// Creates a queue with the given name and default settings.
        /// </summary>
        /// <param name="queueName">Queue name.</param>
        /// <returns>Created queue.</returns>
        IAsyncOperation<QueueInfo> CreateQueueAsync(string queueName);

        /// <summary>
        /// Creates a queue with the given parameters.
        /// </summary>
        /// <param name="queueName">Queue name.</param>
        /// <param name="queueSettings">Queue parameters.</param>
        /// <returns>Created queue.</returns>
        IAsyncOperation<QueueInfo> CreateQueueAsync(string queueName, QueueSettings queueSettings);

        /// <summary>
        /// Lists all existing topics in the namespace.
        /// </summary>
        /// <returns>Collection of topics.</returns>
        IAsyncOperation<IEnumerable<TopicInfo>> ListTopicsAsync();

        /// <summary>
        /// Creates a topic with the given name and default settings.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <returns>Created topic.</returns>
        IAsyncOperation<TopicInfo> CreateTopicAsync(string topicName);

        /// <summary>
        /// Creates a topic with the given name and settings.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="topicSettings">Topic settings.</param>
        /// <returns>Created topics.</returns>
        IAsyncOperation<TopicInfo> CreateTopicAsync(string topicName, TopicSettings topicSettings);

        /// <summary>
        /// Gets a topic with the given name.
        /// </summary>
        /// <param name="topicName">Topic name</param>
        /// <returns>Topic data</returns>
        IAsyncOperation<TopicInfo> GetTopicAsync(string topicName);

        /// <summary>
        /// Deletes a topic with the given name.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <returns>Result of the operation.</returns>
        IAsyncAction DeleteTopicAsync(string topicName);

        /// <summary>
        /// Creates a subscription with the given name for the given topic with default settings.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        /// <returns>Created subscription.</returns>
        IAsyncOperation<SubscriptionInfo> CreateSubscriptionAsync(string topicName, string subscriptionName);

        /// <summary>
        /// Creates a subscription with the given name for the given topic with specified settings.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        /// <param name="subscriptionSettings">Subscription settings.</param>
        /// <returns>Created subscription.</returns>
        IAsyncOperation<SubscriptionInfo> CreateSubscriptionAsync(string topicName, string subscriptionName, SubscriptionSettings subscriptionSettings);

        /// <summary>
        /// Gets subscriptions for the given topic.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <returns>Collection of subscriptions.</returns>
        IAsyncOperation<IEnumerable<SubscriptionInfo>> ListSubscriptionsAsync(string topicName);

        /// <summary>
        /// Gets a subsciption with the given name for the given topic.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        /// <returns>Subscription information.</returns>
        IAsyncOperation<SubscriptionInfo> GetSubscriptionAsync(string topicName, string subscriptionName);

        /// <summary>
        /// Deletes a subscription with the given name for the given topic.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        /// <returns>Result of the operation.</returns>
        IAsyncAction DeleteSubscriptionAsync(string topicName, string subscriptionName);

        /// <summary>
        /// Creates a subscription rule with the given characteristics.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription inside the topic.</param>
        /// <param name="ruleName">Name of the rule to be created.</param>
        /// <param name="ruleSettings">Rule settings.</param>
        /// <returns>Rule description.</returns>
        IAsyncOperation<RuleInfo> CreateRuleAsync(string topicName, string subscriptionName, string ruleName, RuleSettings ruleSettings);

        /// <summary>
        /// Lists all rules for the given subscription.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription inside the topic.</param>
        /// <returns>All rules for the subscription.</returns>
        IAsyncOperation<IEnumerable<RuleInfo>> ListRulesAsync(string topicName, string subscriptionName);

        /// <summary>
        /// Gets a subscription rule with the given name.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription inside the topic.</param>
        /// <param name="ruleName">Name of the rule.</param>
        /// <returns>Rule information.</returns>
        IAsyncOperation<RuleInfo> GetRuleAsync(string topicName, string subscriptionName, string ruleName);

        /// <summary>
        /// Deletes a rule with the given name.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription inside the topic.</param>
        /// <param name="ruleName">Name of the rule.</param>
        /// <returns>Result of the operation.</returns>
        IAsyncAction DeleteRuleAsync(string topicName, string subscriptionName, string ruleName);
    }
}
