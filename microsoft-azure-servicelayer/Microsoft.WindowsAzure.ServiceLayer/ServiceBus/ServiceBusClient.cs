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
    /// Service bus client.
    /// </summary>
    /// <remarks>The class serves as an entry point to the Service Bus
    /// functionality. Explicitly disposing the class will close its underlying
    /// connection and will make all other classes that are using that
    /// connection unusable. Therefore, if you have created multiple instance
    /// of this object by specifying HTTP handlers in the constructor, you
    /// should dispose only one of them and only when it is no longer used.</remarks>
    public sealed class ServiceBusClient: IDisposable
    {
        private HttpChannel _channel;                       // HTTP channel.

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

        /// <summary>
        /// Gets the service options.
        /// </summary>
        private ServiceConfiguration ServiceConfig { get; set; }

        /// <summary>
        /// Initializes a service bus client.
        /// </summary>
        /// <param name="serviceNamespace">Service namespace.</param>
        /// <param name="issuerName">Issuer name.</param>
        /// <param name="issuerPassword">Password.</param>
        /// <remarks>This constructor is used to initialize a new service bus 
        /// client with the default HTTP pipeline. It is the most appropriate
        /// for scenarios that do not require custom HTTP pipelines.</remarks>
        public ServiceBusClient(string serviceNamespace, string issuerName, string issuerPassword)
        {
            Validator.ArgumentIsValidPath("serviceNamespace", serviceNamespace);
            Validator.ArgumentIsNotNullOrEmptyString("issuerName", issuerName);
            Validator.ArgumentIsNotNull("issuerPassword", issuerPassword);

            ServiceConfig = new ServiceConfiguration(serviceNamespace);

            // Create the default HTTP channel.
            _channel = HttpChannel.CreateDefault(serviceNamespace, issuerName, issuerPassword);
        }

        /// <summary>
        /// Initializes a new service bus client by cloning an existing one and
        /// adding extra HTTP handlers at the head of the processing channel.
        /// </summary>
        /// <param name="client">Source service bus client.</param>
        /// <param name="handlers">Extra HTTP handlers.</param>
        public ServiceBusClient(ServiceBusClient client, params IHttpHandler[] handlers)
        {
            Validator.ArgumentIsNotNull("client", client);
            Validator.ArgumentIsNotNull("handlers", handlers);

            ServiceConfig = client.ServiceConfig;
            _channel = new HttpChannel(client._channel, handlers);
        }

        /// <summary>
        /// Gets all available queues in the namespace.
        /// </summary>
        /// <returns>All queues in the namespace.</returns>
        public IAsyncOperation<IEnumerable<QueueDescription>> ListQueuesAsync()
        {
            return GetItemsAsync<QueueDescription>(
                ServiceConfig.GetQueuesContainerUri(), 
                InitQueue);
        }

        /// <summary>
        /// Creates a message receiver for the given queue.
        /// </summary>
        /// <param name="queueName">Queue name.</param>
        /// <returns>Message receiver.</returns>
        public MessageReceiver CreateMessageReceiver(string queueName)
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
        public MessageReceiver CreateMessageReceiver(string topicName, string subscriptionName)
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
        public IAsyncOperation<IEnumerable<QueueDescription>> ListQueuesAsync(int firstItem, int count)
        {
            Validator.ArgumentIsNonNegative("firstItem", firstItem);
            Validator.ArgumentIsPositive("count", count);

            return GetItemsAsync<QueueDescription>(
                ServiceConfig.GetQueuesContainerUri(),
                firstItem, count,
                InitQueue);
        }

        /// <summary>
        /// Gets the queue with the given name.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <returns>Queue data.</returns>
        public IAsyncOperation<QueueDescription> GetQueueAsync(string queueName)
        {
            Validator.ArgumentIsValidPath("queueName", queueName);

            return GetItemAsync<QueueDescription>(
                ServiceConfig.GetQueueUri(queueName),
                InitQueue);
        }

        /// <summary>
        /// Deletes a queue with the given name.
        /// </summary>
        /// <param name="queueName">Queue name.</param>
        /// <returns>Asycnrhonous action.</returns>
        public IAsyncAction DeleteQueueAsync(string queueName)
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
        public IAsyncOperation<QueueDescription> CreateQueueAsync(string queueName)
        {
            Validator.ArgumentIsValidPath("queueName", queueName);

            return CreateItemAsync<QueueDescription, QueueSettings>(
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
        public IAsyncOperation<QueueDescription> CreateQueueAsync(string queueName, QueueSettings queueSettings)
        {
            Validator.ArgumentIsValidPath("queueName", queueName);
            Validator.ArgumentIsNotNull("queueSettings", queueSettings);

            return CreateItemAsync<QueueDescription, QueueSettings>(
                ServiceConfig.GetQueueUri(queueName),
                queueSettings,
                InitQueue);
        }

        /// <summary>
        /// Lists all topics in the namespace.
        /// </summary>
        /// <returns>A collection of topics.</returns>
        public IAsyncOperation<IEnumerable<TopicDescription>> ListTopicsAsync()
        {
            return GetItemsAsync<TopicDescription>(
                ServiceConfig.GetTopicsContainerUri(),
                InitTopic);
        }

        /// <summary>
        /// Lists topics in the given range.
        /// </summary>
        /// <param name="firstItem">Index of the first topic.</param>
        /// <param name="count">Number of topics in the range.</param>
        /// <returns>Collection of topics.</returns>
        public IAsyncOperation<IEnumerable<TopicDescription>> ListTopicsAsync(int firstItem, int count)
        {
            Validator.ArgumentIsNonNegative("firstItem", firstItem);
            Validator.ArgumentIsPositive("count", count);

            return GetItemsAsync<TopicDescription>(
                ServiceConfig.GetTopicsContainerUri(),
                firstItem, count,
                InitTopic);
        }

        /// <summary>
        /// Creates a topic with the given name and default settings.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <returns>Created topic.</returns>
        public IAsyncOperation<TopicDescription> CreateTopicAsync(string topicName)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);

            return CreateItemAsync<TopicDescription, TopicSettings>(
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
        public IAsyncOperation<TopicDescription> CreateTopicAsync(string topicName, TopicSettings topicSettings)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsNotNull("topicSettings", topicSettings);

            return CreateItemAsync<TopicDescription, TopicSettings>(
                ServiceConfig.GetTopicUri(topicName),
                topicSettings,
                InitTopic);
        }

        /// <summary>
        /// Gets a topic with the given name.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <returns>Topic information.</returns>
        public IAsyncOperation<TopicDescription> GetTopicAsync(string topicName)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);

            return GetItemAsync<TopicDescription>(
                ServiceConfig.GetTopicUri(topicName),
                InitTopic);
        }

        /// <summary>
        /// Deletes a topic with the given name.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <returns>Deletion result.</returns>
        public IAsyncAction DeleteTopicAsync(string topicName)
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
        public IAsyncOperation<SubscriptionDescription> CreateSubscriptionAsync(string topicName, string subscriptionName)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsValidPath("subscriptionName", subscriptionName);

            return CreateItemAsync<SubscriptionDescription, SubscriptionSettings>(
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
        public IAsyncOperation<SubscriptionDescription> CreateSubscriptionAsync(
            string topicName, 
            string subscriptionName, 
            SubscriptionSettings subscriptionSettings)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsValidPath("subscriptionName", subscriptionName);
            Validator.ArgumentIsNotNull("subscriptionSettings", subscriptionSettings);

            return CreateItemAsync<SubscriptionDescription, SubscriptionSettings>(
                ServiceConfig.GetSubscriptionUri(topicName, subscriptionName), 
                subscriptionSettings, 
                InitSubscription);
        }

        /// <summary>
        /// Gets all subscriptions for the given topic.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <returns>Collection of subscriptions.</returns>
        public IAsyncOperation<IEnumerable<SubscriptionDescription>> ListSubscriptionsAsync(string topicName)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);

            return GetItemsAsync<SubscriptionDescription>(
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
        public IAsyncOperation<IEnumerable<SubscriptionDescription>> ListSubscriptionsAsync(string topicName, int firstItem, int count)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsNonNegative("firstItem", firstItem);
            Validator.ArgumentIsPositive("count", count);

            return GetItemsAsync<SubscriptionDescription>(
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
        public IAsyncOperation<SubscriptionDescription> GetSubscriptionAsync(string topicName, string subscriptionName)
        {
            Validator.ArgumentIsValidPath("topicName", topicName);
            Validator.ArgumentIsValidPath("subscriptionName", subscriptionName);

            return GetItemAsync<SubscriptionDescription>(
                ServiceConfig.GetSubscriptionUri(topicName, subscriptionName), 
                InitSubscription);
        }

        /// <summary>
        /// Deletes a subscription with the given name from the given topic.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        /// <returns>Result of the operation.</returns>
        public IAsyncAction DeleteSubscriptionAsync(string topicName, string subscriptionName)
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
        public IAsyncOperation<RuleInfo> CreateRuleAsync(string topicName, string subscriptionName, string ruleName, RuleSettings ruleSettings)
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
        public IAsyncOperation<IEnumerable<RuleInfo>> ListRulesAsync(string topicName, string subscriptionName)
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
        public IAsyncOperation<IEnumerable<RuleInfo>> ListRulesAsync(string topicName, string subscriptionName, int firstItem, int count)
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
        public IAsyncOperation<RuleInfo> GetRuleAsync(string topicName, string subscriptionName, string ruleName)
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
        public IAsyncAction DeleteRuleAsync(string topicName, string subscriptionName, string ruleName)
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
        public IAsyncAction SendMessageAsync(string destination, BrokeredMessageSettings message)
        {
            Validator.ArgumentIsValidPath("destination", destination);
            Validator.ArgumentIsNotNull("message", message);

            Uri uri = ServiceConfig.GetDestinationUri(destination);
            HttpRequest request = new HttpRequest(HttpMethod.Post, uri);
            message.SubmitTo(request);

            return _channel.SendAsyncInternal(request).AsAsyncAction();
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

            return _channel.SendAsyncInternal(request, HttpChannel.CheckNoContent)
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

            return _channel.SendAsyncInternal(request, HttpChannel.CheckNoContent)
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

            return _channel.SendAsyncInternal(request)
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
                .ContinueWith<HttpResponse>(tr => _channel.SendAsyncInternal(request).Result, TaskContinuationOptions.OnlyOnRanToCompletion)
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
        private static void InitTopic(SyndicationItem feedItem, TopicDescription topicInfo)
        {
            topicInfo.Initialize(feedItem);
        }

        /// <summary>
        /// Initializes a queue after its deserialization.
        /// </summary>
        /// <param name="feedItem">Source Atom item.</param>
        /// <param name="queueInfo">Deserialized queue.</param>
        private static void InitQueue(SyndicationItem feedItem, QueueDescription queueInfo)
        {
            queueInfo.Initialize(feedItem);
        }

        /// <summary>
        /// Initializes a subscription after its deserialization.
        /// </summary>
        /// <param name="feedItem">Source Atom item.</param>
        /// <param name="subscriptionInfo">Deserialized subscription.</param>
        private static void InitSubscription(SyndicationItem feedItem, SubscriptionDescription subscriptionInfo)
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

        /// <summary>
        /// Disposes the client by closing underlying connection.
        /// </summary>
        public void Dispose()
        {
            _channel.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
