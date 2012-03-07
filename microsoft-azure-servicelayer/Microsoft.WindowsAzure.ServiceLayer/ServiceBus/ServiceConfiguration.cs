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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Options of the service bus service.
    /// </summary>
    public class ServiceConfiguration
    {
        /// <summary>
        /// Gets the service namespace.
        /// </summary>
        public string ServiceNamespace { get; private set; }

        /// <summary>
        /// Gets the user name used for authentication.
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Gets the password used for authentication.
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Gets the service bus URI.
        /// </summary>
        internal Uri ServiceBusUri { get; private set; }

        /// <summary>
        /// Gets URI of the authentication service.
        /// </summary>
        internal Uri AuthenticationUri { get; private set; }

        /// <summary>
        /// Gets the host URI for authenticating requests.
        /// </summary>
        internal Uri ScopeHostUri { get; private set; }

        /// <summary>
        /// Constructor with explicitly specified options.
        /// </summary>
        /// <param name="serviceNamespace">Service namespace.</param>
        /// <param name="userName">User name for authentication.</param>
        /// <param name="password">Password for authentication.</param>
        internal ServiceConfiguration(string serviceNamespace, string userName, string password)
        {
            ServiceNamespace = serviceNamespace;
            UserName = userName;
            Password = password;

            string stringUri = string.Format(CultureInfo.InvariantCulture, Constants.ServiceBusServiceUri, ServiceNamespace);
            ServiceBusUri = new Uri(stringUri, UriKind.Absolute);

            stringUri = string.Format(CultureInfo.InvariantCulture, Constants.ServiceBusAuthenticationUri, ServiceNamespace);
            AuthenticationUri = new Uri(stringUri, UriKind.Absolute);

            stringUri = string.Format(CultureInfo.InvariantCulture, Constants.ServiceBusScopeUri, ServiceNamespace);
            ScopeHostUri = new Uri(stringUri);
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
        /// Gets URI of an unlocked message in the queue/topic.
        /// </summary>
        /// <param name="destination">Queue/topic name.</param>
        /// <param name="lockDuration">Duration of lock.</param>
        /// <returns>URI of the unlocked message.</returns>
        internal Uri GetUnlockedMessageUri(string destination, TimeSpan lockDuration)
        {
            return FormatUri(Constants.UnlockedMessagePath, destination, lockDuration.Seconds);
        }

        /// <summary>
        /// Gets URI to a locked message.
        /// </summary>
        /// <param name="destination">Queue/topic name.</param>
        /// <param name="sequenceNumber">Sequence number of the locked message.</param>
        /// <param name="lockId">Lock ID of the message.</param>
        /// <returns>URI of the locked message.</returns>
        internal Uri GetLockedMessageUri(string destination, int sequenceNumber, string lockId)
        {
            return FormatUri(Constants.LockedMessagePath, destination, sequenceNumber, lockId);
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
