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
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Services.ServiceBus
{
    /// <summary>
    /// Options of the service bus service.
    /// </summary>
    internal class ServiceConfiguration
    {
        /// <summary>
        /// Gets the service bus URI.
        /// </summary>
        internal Uri ServiceBusUri { get; private set; }

        /// <summary>
        /// Initializes the configuration object.
        /// </summary>
        /// <param name="uri">Endpoint URI.</param>
        internal ServiceConfiguration(Uri uri)
        {
            Debug.Assert(uri != null);

            ServiceBusUri = uri;
        }

        /// <summary>
        /// Gets URI for a queue.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <returns>Queue's URI.</returns>
        internal Uri GetQueueUri(string queueName)
        {
            return FormatUri(Constants.QueuePath, queueName);
        }

        /// <summary>
        /// Gets URI of a container with all queues.
        /// </summary>
        /// <returns>URI of the container with all queues.</returns>
        internal Uri GetQueuesContainerUri()
        {
            return FormatUri(Constants.QueuesPath);
        }


        /// <summary>
        /// Gets URI for a topic.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <returns>Topic's URI.</returns>
        internal Uri GetTopicUri(string topicName)
        {
            return FormatUri(Constants.TopicPath, topicName);
        }

        /// <summary>
        /// Gets URI of a container with all topics.
        /// </summary>
        /// <returns>URI of the container with all topics.</returns>
        internal Uri GetTopicsContainerUri()
        {
            return FormatUri(Constants.TopicsPath);
        }

        /// <summary>
        /// Gets a URI for a subscription.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription inside the topic.</param>
        /// <returns>Subscription's URI.</returns>
        internal Uri GetSubscriptionUri(string topicName, string subscriptionName)
        {
            return FormatUri(Constants.SubscriptionPath, topicName, subscriptionName);
        }

        /// <summary>
        /// Gets a URI of a container with all subscriptions for the topic.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <returns>URI of the container with all subscriptions.</returns>
        internal Uri GetSubscriptionsContainerUri(string topicName)
        {
            return FormatUri(Constants.SubscriptionsPath, topicName);
        }

        /// <summary>
        /// Gets a URI for a rule.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription inside the topic.</param>
        /// <param name="ruleName">Name of the rule.</param>
        /// <returns>Rule's URI.</returns>
        internal Uri GetRuleUri(string topicName, string subscriptionName, string ruleName)
        {
            return FormatUri(Constants.RulePath, topicName, subscriptionName, ruleName);
        }

        /// <summary>
        /// Gets a URI of a container with all rules.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription inside the topic.</param>
        /// <returns>Uri of the container with all rules.</returns>
        internal Uri GetRulesContainerUri(string topicName, string subscriptionName)
        {
            return FormatUri(Constants.RulesPath, topicName, subscriptionName);
        }

        /// <summary>
        /// Gets a URI for sending messages to the given destination.
        /// </summary>
        /// <param name="destination">Destination path (queue/topic name).</param>
        /// <returns>URI of the destination.</returns>
        internal Uri GetDestinationUri(string destination)
        {
            return FormatUri(Constants.MessageDestination, destination);
        }

        /// <summary>
        /// Gets URI of a top-level message in the given message source.
        /// </summary>
        /// <param name="path">Local path to the message source.</param>
        /// <param name="lockDuration">Lock duration for the message.</param>
        /// <returns>URI of the message.</returns>
        internal Uri GetTopMessageUri(string path, TimeSpan lockDuration)
        {
            return FormatUri(Constants.UnlockedMessagePath, path, lockDuration.Seconds);
        }

        /// <summary>
        /// Gets URI of an unlocked message in the queue.
        /// </summary>
        /// <param name="destination">Queue/topic name.</param>
        /// <param name="lockDuration">Duration of lock.</param>
        /// <returns>URI of the unlocked message.</returns>
        internal Uri GetUnlockedMessageUri(string destination, TimeSpan lockDuration)
        {
            return FormatUri(Constants.UnlockedMessagePath, destination, lockDuration.Seconds);
        }

        /// <summary>
        /// Gets URI of an unlocked message in the subscription.
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        /// <param name="lockDuration"></param>
        /// <returns></returns>
        internal Uri GetUnlockedSubscriptionMessageUri(string topicName, string subscriptionName, TimeSpan lockDuration)
        {
            return FormatUri(Constants.UnlockedSubscriptionMessagePath, topicName, subscriptionName, lockDuration.Seconds);
        }

        /// <summary>
        /// Gets URI to a locked message.
        /// </summary>
        /// <param name="destination">Queue/topic name.</param>
        /// <param name="sequenceNumber">Sequence number of the locked message.</param>
        /// <param name="lockToken">Lock ID of the message.</param>
        /// <returns>URI of the locked message.</returns>
        internal Uri GetLockedMessageUri(string destination, long sequenceNumber, string lockToken)
        {
            return FormatUri(Constants.LockedMessagePath, destination, sequenceNumber, lockToken);
        }

        /// <summary>
        /// Gets URI of a locked subscription message.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        /// <param name="sequenceNumber">Sequence number of the locked message.</param>
        /// <param name="lockToken">Lock ID of the message.</param>
        /// <returns>URI of the locked message.</returns>
        internal Uri GetLockedSubscriptionMessageUri(string topicName, string subscriptionName, long sequenceNumber, string lockToken)
        {
            return FormatUri(Constants.LockedSubscriptionMessagePath, topicName, subscriptionName, sequenceNumber, lockToken);
        }

        /// <summary>
        /// Gets a query for obtaining a range of items from the given 
        /// container.
        /// </summary>
        /// <param name="containerUri"></param>
        /// <param name="firstItem">Index of the first item.</param>
        /// <param name="count">Number of items to return.</param>
        /// <returns>Uri for the given range.</returns>
        internal Uri GetItemsRangeQuery(Uri containerUri, int firstItem, int count)
        {
            return FormatUri(Constants.RangeQueryUri, containerUri.ToString(), firstItem, count);
        }

        /// <summary>
        /// Generates URI with the given parameters.
        /// </summary>
        /// <param name="format">Format string for the path.</param>
        /// <param name="args">Optional arguments for formatting.</param>
        /// <returns>URI.</returns>
        private Uri FormatUri(string format, params object[] args)
        {
            string path = string.Format(CultureInfo.InvariantCulture, format, args);
            return new Uri(ServiceBusUri, path);
        }
    }
}
