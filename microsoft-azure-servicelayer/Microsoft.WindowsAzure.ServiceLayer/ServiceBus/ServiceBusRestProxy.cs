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
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceLayer.Http;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Web.Syndication;


namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// REST proxy for the service bus interface.
    /// </summary>
    internal class ServiceBusRestProxy: IServiceBusService
    {
        // Extra types used for serialization operations with rules.
        private static readonly Type[] ExtraRuleTypes = 
        {
            typeof(CorrelationRuleFilter),
            typeof(FalseRuleFilter),
            typeof(SqlRuleFilter),
            typeof(TrueRuleFilter),
            typeof(EmptyRuleAction),
            typeof(SqlRuleAction),
        };

        private HttpChannel _channel;                       // HTTP processing channel.

        /// <summary>
        /// Gets the service options.
        /// </summary>
        private ServiceConfiguration ServiceConfig { get; set; }

        /// <summary>
        /// Initializes the service bus service.
        /// </summary>
        /// <param name="config">Service configuration.</param>
        /// <param name="httpHandler">Handler for processing HTTP requests.</param>
        internal ServiceBusRestProxy(ServiceConfiguration config, IHttpHandler httpHandler)
        {
            Debug.Assert(config != null);
            Debug.Assert(httpHandler != null);

            ServiceConfig = config;
            _channel = new HttpChannel(httpHandler);
        }

        /// <summary>
        /// Gets all available queues in the namespace.
        /// </summary>
        /// <returns>All queues in the namespace.</returns>
        IAsyncOperation<IEnumerable<QueueInfo>> IServiceBusService.ListQueuesAsync()
        {
            return GetItemsAsync<QueueInfo>(
                ServiceConfig.GetQueuesContainerUri(), 
                InitQueue);
        }

        /// <summary>
        /// Gets HTTP handler used by the service.
        /// </summary>
        IHttpHandler IServiceBusService.HttpHandler
        {
            get { return _channel.Handler; }
        }

        /// <summary>
        /// Clones the service and assigns a given handler to it.
        /// </summary>
        /// <param name="handler">HTTP handler to assign to the cloned service.</param>
        /// <returns>Cloned service.</returns>
        IServiceBusService IServiceBusService.AssignHandler(IHttpHandler handler)
        {
            Validator.ArgumentIsNotNull("handler", handler);

            return new ServiceBusRestProxy(ServiceConfig, handler);
        }

        /// <summary>
        /// Creates a message receiver for the given queue.
        /// </summary>
        /// <param name="queueName">Queue name.</param>
        /// <returns>Message receiver.</returns>
        MessageReceiver IServiceBusService.CreateMessageReceiver(string queueName)
        {
            Validator.ArgumentIsNotNullOrEmptyString("queueName", queueName);

            return new MessageReceiver(ServiceConfig, _channel, queueName);
        }

        /// <summary>
        /// Creates a message receiver for the given subscripiton.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        /// <returns>Message receiver.</returns>
        MessageReceiver IServiceBusService.CreateMessageReceiver(string topicName, string subscriptionName)
        {
            Validator.ArgumentIsNotNullOrEmptyString("topicName", topicName);
            Validator.ArgumentIsNotNullOrEmptyString("subscriptionName", subscriptionName);

            string path = string.Format(CultureInfo.InvariantCulture, Constants.SubscriptionPath, topicName, subscriptionName);
            return new MessageReceiver(ServiceConfig, _channel, path);
        }

        /// <summary>
        /// Gets available queues in the given range.
        /// </summary>
        /// <param name="firstItem">Index of the first item in range.</param>
        /// <param name="count">Number of items to return.</param>
        /// <returns>Collection of queues.</returns>
        IAsyncOperation<IEnumerable<QueueInfo>> IServiceBusService.ListQueuesAsync(int firstItem, int count)
        {
            Validator.ArgumentIsNonNegative("firstItem", firstItem);
            Validator.ArgumentIsPositive("count", count);

            return GetItemsAsync<QueueInfo>(
                ServiceConfig.GetQueuesContainerUri(),
                firstItem, count,
                InitQueue);
        }

        /// <summary>
        /// Gets the queue with the given name.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <returns>Queue data.</returns>
        IAsyncOperation<QueueInfo> IServiceBusService.GetQueueAsync(string queueName)
        {
            Validator.ArgumentIsValidPath("queueName", queueName);

            return GetItemAsync<QueueInfo>(
                ServiceConfig.GetQueueUri(queueName),
                InitQueue);
        }

        /// <summary>
        /// Deletes a queue with the given name.
        /// </summary>
        /// <param name="queueName">Queue name.</param>
        /// <returns>Asycnrhonous action.</returns>
        IAsyncAction IServiceBusService.DeleteQueueAsync(string queueName)
        {
            Validator.ArgumentIsValidPath("queueName", queueName);

            return DeleteItemAsync(
                ServiceConfig.GetQueueUri(queueName));
        }

        /// <summary>
        /// Creates a queue with the given name and default settings.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <returns>Queue data.</returns>
        IAsyncOperation<QueueInfo> IServiceBusService.CreateQueueAsync(string queueName)
        {
            Validator.ArgumentIsValidPath("queueName", queueName);

            return CreateItemAsync<QueueInfo, QueueSettings>(
                ServiceConfig.GetQueueUri(queueName),
                new QueueSettings(),
                InitQueue);
        }

        /// <summary>
        /// Creates a queue with the given parameters.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <param name="queueSettings">Parameters of the queue.</param>
        /// <returns>Created queue.</returns>
        IAsyncOperation<QueueInfo> IServiceBusService.CreateQueueAsync(string queueName, QueueSettings queueSettings)
        {
            Validator.ArgumentIsValidPath("queueName", queueName);
            Validator.ArgumentIsNotNull("queueSettings", queueSettings);

            return CreateItemAsync<QueueInfo, QueueSettings>(
                ServiceConfig.GetQueueUri(queueName),
                queueSettings,
                InitQueue);
        }

        /// <summary>
        /// Lists all topics in the namespace.
        /// </summary>
        /// <returns>A collection of topics.</returns>
        IAsyncOperation<IEnumerable<TopicInfo>> IServiceBusService.ListTopicsAsync()
        {
            return GetItemsAsync<TopicInfo>(
                ServiceConfig.GetTopicsContainerUri(),
                InitTopic);
        }

        /// <summary>
        /// Lists topics in the given range.
        /// </summary>
        /// <param name="firstItem">Index of the first topic.</param>
        /// <param name="count">Number of topics in the range.</param>
        /// <returns>Collection of topics.</returns>
        IAsyncOperation<IEnumerable<TopicInfo>> IServiceBusService.ListTopicsAsync(int firstItem, int count)
        {
            Validator.ArgumentIsNonNegative("firstItem", firstItem);
            Validator.ArgumentIsPositive("count", count);

            return GetItemsAsync<TopicInfo>(
                ServiceConfig.GetTopicsContainerUri(),
                firstItem, count,
                InitTopic);
        }

        /// <summary>
        /// Creates a topic with the given name and default settings.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <returns>Created topic.</returns>
        IAsyncOperation<TopicInfo> IServiceBusService.CreateTopicAsync(string topicName)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);

            return CreateItemAsync<TopicInfo, TopicSettings>(
                ServiceConfig.GetTopicUri(topicName),
                new TopicSettings(), 
                InitTopic);
        }

        /// <summary>
        /// Creates a topic with the given name and settings.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="topicSettings">Topic settings.</param>
        /// <returns>Created topic.</returns>
        IAsyncOperation<TopicInfo> IServiceBusService.CreateTopicAsync(string topicName, TopicSettings topicSettings)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsNotNull("topicSettings", topicSettings);

            return CreateItemAsync<TopicInfo, TopicSettings>(
                ServiceConfig.GetTopicUri(topicName),
                topicSettings,
                InitTopic);
        }

        /// <summary>
        /// Gets a topic with the given name.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <returns>Topic information.</returns>
        IAsyncOperation<TopicInfo> IServiceBusService.GetTopicAsync(string topicName)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);

            return GetItemAsync<TopicInfo>(
                ServiceConfig.GetTopicUri(topicName),
                InitTopic);
        }

        /// <summary>
        /// Deletes a topic with the given name.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <returns>Deletion result.</returns>
        IAsyncAction IServiceBusService.DeleteTopicAsync(string topicName)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);

            return DeleteItemAsync(
                ServiceConfig.GetTopicUri(topicName));
        }

        /// <summary>
        /// Creates a subscription with the given name for the given topic and 
        /// default settings.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        /// <returns>Created subscription.</returns>
        IAsyncOperation<SubscriptionInfo> IServiceBusService.CreateSubscriptionAsync(string topicName, string subscriptionName)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsValidPath("subscriptionName", subscriptionName);

            return CreateItemAsync<SubscriptionInfo, SubscriptionSettings>(
                ServiceConfig.GetSubscriptionUri(topicName, subscriptionName),
                new SubscriptionSettings(), 
                InitSubscription);
        }

        /// <summary>
        /// Creates a subscription with the given name for the given topic with
        /// the specified settings.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        /// <param name="subscriptionSettings">Subscription settings.</param>
        /// <returns>Created subscription.</returns>
        IAsyncOperation<SubscriptionInfo> IServiceBusService.CreateSubscriptionAsync(
            string topicName, 
            string subscriptionName, 
            SubscriptionSettings subscriptionSettings)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsValidPath("subscriptionName", subscriptionName);
            Validator.ArgumentIsNotNull("subscriptionSettings", subscriptionSettings);

            return CreateItemAsync<SubscriptionInfo, SubscriptionSettings>(
                ServiceConfig.GetSubscriptionUri(topicName, subscriptionName), 
                subscriptionSettings, 
                InitSubscription);
        }

        /// <summary>
        /// Gets all subscriptions for the given topic.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <returns>Collection of subscriptions.</returns>
        IAsyncOperation<IEnumerable<SubscriptionInfo>> IServiceBusService.ListSubscriptionsAsync(string topicName)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);

            return GetItemsAsync<SubscriptionInfo>(
                ServiceConfig.GetSubscriptionsContainerUri(topicName), 
                InitSubscription);
        }

        /// <summary>
        /// Gets subscription in the given range for the topic.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="firstItem">Index of the first rule.</param>
        /// <param name="count">Number of rules in the range.</param>
        /// <returns>Collection of subscriptions.</returns>
        IAsyncOperation<IEnumerable<SubscriptionInfo>> IServiceBusService.ListSubscriptionsAsync(string topicName, int firstItem, int count)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsNonNegative("firstItem", firstItem);
            Validator.ArgumentIsPositive("count", count);

            return GetItemsAsync<SubscriptionInfo>(
                ServiceConfig.GetSubscriptionsContainerUri(topicName),
                firstItem, count,
                InitSubscription);
        }

        /// <summary>
        /// Gets a subscription with the given name for the given topic.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        /// <returns>Subscription information.</returns>
        IAsyncOperation<SubscriptionInfo> IServiceBusService.GetSubscriptionAsync(string topicName, string subscriptionName)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsValidPath("subscriptionName", subscriptionName);

            return GetItemAsync<SubscriptionInfo>(
                ServiceConfig.GetSubscriptionUri(topicName, subscriptionName), 
                InitSubscription);
        }

        /// <summary>
        /// Deletes a subscription with the given name from the given topic.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        /// <returns>Result of the operation.</returns>
        IAsyncAction IServiceBusService.DeleteSubscriptionAsync(string topicName, string subscriptionName)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsValidPath("subscriptionName", subscriptionName);

            return DeleteItemAsync(
                ServiceConfig.GetSubscriptionUri(topicName, subscriptionName));
        }

        /// <summary>
        /// Creates a rule.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription inside the topic.</param>
        /// <param name="ruleName">Name of the rule to be created.</param>
        /// <param name="ruleSettings">Rule's settings.</param>
        /// <returns></returns>
        IAsyncOperation<RuleInfo> IServiceBusService.CreateRuleAsync(string topicName, string subscriptionName, string ruleName, RuleSettings ruleSettings)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsValidPath("subscriptionName", subscriptionName);
            Validator.ArgumentIsValidPath("ruleName", ruleName);
            Validator.ArgumentIsNotNull("ruleSettings", ruleSettings);

            return CreateItemAsync<RuleInfo, RuleSettings>(
                ServiceConfig.GetRuleUri(topicName, subscriptionName, ruleName),
                ruleSettings,
                InitRule);
        }

        /// <summary>
        /// Lists all rules in the given subscription.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription inside the topic.</param>
        /// <returns>A collection of rules.</returns>
        IAsyncOperation<IEnumerable<RuleInfo>> IServiceBusService.ListRulesAsync(string topicName, string subscriptionName)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsValidPath("subscriptionName", subscriptionName);

            return GetItemsAsync<RuleInfo>(
                ServiceConfig.GetRulesContainerUri(topicName, subscriptionName),
                InitRule,
                ExtraRuleTypes);
        }

        /// <summary>
        /// Lists rules in the given range for a subscription.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        /// <param name="firstItem">Index of the first rule in the range.</param>
        /// <param name="count">Number of rules in the range.</param>
        /// <returns>Collection of rules.</returns>
        IAsyncOperation<IEnumerable<RuleInfo>> IServiceBusService.ListRulesAsync(string topicName, string subscriptionName, int firstItem, int count)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsValidPath("subscriptionName", subscriptionName);
            Validator.ArgumentIsNonNegative("firstItem", firstItem);
            Validator.ArgumentIsPositive("count", count);

            return GetItemsAsync<RuleInfo>(
                ServiceConfig.GetRulesContainerUri(topicName, subscriptionName),
                firstItem, count,
                InitRule,
                ExtraRuleTypes);
        }

        /// <summary>
        /// Gets a subscription rule with the given name.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription.</param>
        /// <param name="ruleName">Name of the rule.</param>
        /// <returns>Rule information.</returns>
        IAsyncOperation<RuleInfo> IServiceBusService.GetRuleAsync(string topicName, string subscriptionName, string ruleName)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsValidPath("subscriptionName", subscriptionName);
            Validator.ArgumentIsValidPath("ruleName", ruleName);

            return GetItemAsync<RuleInfo>(
                ServiceConfig.GetRuleUri(topicName, subscriptionName, ruleName),
                InitRule,
                ExtraRuleTypes);
        }

        /// <summary>
        /// Deletes a rule with the given name.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription.</param>
        /// <param name="ruleName">Name of the rule.</param>
        /// <returns>Result of the operation.</returns>
        IAsyncAction IServiceBusService.DeleteRuleAsync(string topicName, string subscriptionName, string ruleName)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsValidPath("subscriptionName", subscriptionName);
            Validator.ArgumentIsValidPath("ruleName", ruleName);

            return DeleteItemAsync(
                ServiceConfig.GetRuleUri(topicName, subscriptionName, ruleName));
        }

        /// <summary>
        /// Sends a brokered message to the queue or the topic.
        /// </summary>
        /// <param name="destination">Topic/queue name.</param>
        /// <param name="message">Message to send.</param>
        /// <returns>Result of the operation.</returns>
        IAsyncAction IServiceBusService.SendMessageAsync(string destination, BrokeredMessageSettings message)
        {
            Validator.ArgumentIsValidPath("destination", destination);
            Validator.ArgumentIsNotNull("message", message);

            Uri uri = ServiceConfig.GetDestinationUri(destination);
            HttpRequest request = new HttpRequest(HttpMethod.Post, uri);
            message.SubmitTo(request);

            return _channel.SendAsync(request).AsAsyncAction();
        }
        /// <summary>
        /// Gets service bus items of the given type.
        /// </summary>
        /// <typeparam name="TInfo">Item type.</typeparam>
        /// <param name="containerUri">URI of a container with items.</param>
        /// <param name="initAction">Initialization action for a single item.</param>
        /// <param name="extraTypes">Extra types for deserialization.</param>
        /// <returns>A collection of items.</returns>
        private IAsyncOperation<IEnumerable<TInfo>> GetItemsAsync<TInfo>(Uri containerUri, Action<SyndicationItem, TInfo> initAction, params Type[] extraTypes)
        {
            HttpRequest request = new HttpRequest(HttpMethod.Get, containerUri);

            return _channel.SendAsync(request, HttpChannel.CheckNoContent)
                .ContinueWith<IEnumerable<TInfo>>(r => GetItems<TInfo>(r.Result, initAction, extraTypes), TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation<IEnumerable<TInfo>>();
        }

        /// <summary>
        /// Gets service bus items of the given type in the specified range.
        /// </summary>
        /// <typeparam name="TInfo">Item type.</typeparam>
        /// <param name="containerUri">URI of a container with items.</param>
        /// <param name="firstItem">Index of the first item.</param>
        /// <param name="count">Number of items to return.</param>
        /// <param name="initAction">Initialization item for a single item.</param>
        /// <param name="extraTypes">Extra types for deserialization.</param>
        /// <returns>A collection of items.</returns>
        private IAsyncOperation<IEnumerable<TInfo>> GetItemsAsync<TInfo>(
            Uri containerUri,
            int firstItem,
            int count,
            Action<SyndicationItem, TInfo> initAction,
            params Type[] extraTypes)
        {
            containerUri = ServiceConfig.GetItemsRangeQuery(containerUri, firstItem, count);
            return GetItemsAsync(containerUri, initAction, extraTypes);
        }

        /// <summary>
        /// Deserializes collection of items of the given type from an atom 
        /// feed contained in the specified response.
        /// </summary>
        /// <typeparam name="TInfo">Item type.</typeparam>
        /// <param name="response">Source HTTP response.</param>
        /// <param name="initAction">Initialization action.</param>
        /// <param name="extraTypes">Extra types for deserialization.</param>
        /// <returns>Collection of deserialized items.</returns>
        private IEnumerable<TInfo> GetItems<TInfo>(HttpResponse response, Action<SyndicationItem, TInfo> initAction, params Type[] extraTypes)
        {
            Debug.Assert(response.IsSuccessStatusCode);
            SyndicationFeed feed = new SyndicationFeed();
            feed.Load(response.Content.ReadAsStringAsync().AsTask().Result);

            return SerializationHelper.DeserializeCollection<TInfo>(feed, initAction, extraTypes);
        }

        /// <summary>
        /// Obtains a service bus item of the given name and type.
        /// </summary>
        /// <typeparam name="TInfo">Item type</typeparam>
        /// <param name="itemUri">URI of the item.</param>
        /// <param name="initAction">Initialization action for the deserialized item.</param>
        /// <param name="extraTypes">Extra types for deserialization.</param>
        /// <returns>Item data</returns>
        private IAsyncOperation<TInfo> GetItemAsync<TInfo>(Uri itemUri, Action<SyndicationItem, TInfo> initAction, params Type[] extraTypes)
        {
            HttpRequest request = new HttpRequest(HttpMethod.Get, itemUri);

            return _channel.SendAsync(request, HttpChannel.CheckNoContent)
                .ContinueWith<TInfo>(tr => GetItem<TInfo>(tr.Result, initAction, extraTypes), TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation<TInfo>();
        }

        /// <summary>
        /// Deserializes a service bus item of the specified type from the 
        /// given HTTP response.
        /// </summary>
        /// <typeparam name="TInfo">Type of the object to deserialize.</typeparam>
        /// <param name="response">Source HTTP response.</param>
        /// <param name="initAction">Initialization action for deserialized items.</param>
        /// <param name="extraTypes">Extra types for deserialization.</param>
        /// <returns>Deserialized object.</returns>
        private TInfo GetItem<TInfo>(HttpResponse response, Action<SyndicationItem, TInfo> initAction, params Type[] extraTypes)
        {
            Debug.Assert(response.IsSuccessStatusCode);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response.Content.ReadAsStringAsync().AsTask().Result);

            SyndicationItem feedItem = new SyndicationItem();
            feedItem.LoadFromXml(doc);

            return SerializationHelper.DeserializeItem<TInfo>(feedItem, initAction, extraTypes);
        }

        /// <summary>
        /// Deletes given item.
        /// </summary>
        /// <param name="itemUri">URI of the item.</param>
        /// <returns>Deletion result.</returns>
        private IAsyncAction DeleteItemAsync(Uri itemUri)
        {
            HttpRequest request = new HttpRequest(HttpMethod.Delete, itemUri);

            return _channel.SendAsync(request)
                .AsAsyncAction();
        }

        /// <summary>
        /// Creates a service bus object with the given name and parameters.
        /// </summary>
        /// <typeparam name="TInfo">Service bus object type (queue, topic, etc.).</typeparam>
        /// <typeparam name="TSettings">Settings for the given object type.</typeparam>
        /// <param name="itemUri">URI of the item.</param>
        /// <param name="itemSettings">Settings of the object.</param>
        /// <param name="initAction">Initialization action</param>
        /// <returns>Created object.</returns>
        private IAsyncOperation<TInfo> CreateItemAsync<TInfo, TSettings>(
            Uri itemUri, 
            TSettings itemSettings, 
            Action<SyndicationItem, TInfo> initAction) where TSettings: class
        {
            HttpRequest request = new HttpRequest(HttpMethod.Put, itemUri);

            return Task.Factory
                .StartNew(() => SetBody(request, itemSettings, ExtraRuleTypes))
                .ContinueWith<HttpResponse>(tr => _channel.SendAsync(request).Result, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith<TInfo>(tr => GetItem<TInfo>(tr.Result, initAction, ExtraRuleTypes), TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation<TInfo>();
        }

        /// <summary>
        /// Serializes given object and sets the request's body.
        /// </summary>
        /// <param name="request">Target request.</param>
        /// <param name="bodyObject">Object to serialize.</param>
        /// <param name="supportedTypes">Supported types.</param>
        private void SetBody(HttpRequest request, object bodyObject, params Type[] supportedTypes)
        {
            string content = SerializationHelper.Serialize(bodyObject, supportedTypes);
            request.Content = HttpContent.CreateFromText(content, Constants.BodyContentType);
            request.Headers.Add("type", "entry");
        }

        /// <summary>
        /// Initializes a topic after its deserialization.
        /// </summary>
        /// <param name="feedItem">Source Atom item.</param>
        /// <param name="topicInfo">Deserialized topic.</param>
        private static void InitTopic(SyndicationItem feedItem, TopicInfo topicInfo)
        {
            topicInfo.Initialize(feedItem);
        }

        /// <summary>
        /// Initializes a queue after its deserialization.
        /// </summary>
        /// <param name="feedItem">Source Atom item.</param>
        /// <param name="queueInfo">Deserialized queue.</param>
        private static void InitQueue(SyndicationItem feedItem, QueueInfo queueInfo)
        {
            queueInfo.Initialize(feedItem);
        }

        /// <summary>
        /// Initializes a subscription after its deserialization.
        /// </summary>
        /// <param name="feedItem">Source Atom item.</param>
        /// <param name="subscriptionInfo">Deserialized subscription.</param>
        private static void InitSubscription(SyndicationItem feedItem, SubscriptionInfo subscriptionInfo)
        {
            subscriptionInfo.Initialize(feedItem);
        }

        /// <summary>
        /// Initializes a rule after its deserialization.
        /// </summary>
        /// <param name="feedItem">Source Atom item.</param>
        /// <param name="ruleInfo">Deserialized rule.</param>
        private static void InitRule(SyndicationItem feedItem, RuleInfo ruleInfo)
        {
            ruleInfo.Initialize(feedItem);
        }
    }
}
