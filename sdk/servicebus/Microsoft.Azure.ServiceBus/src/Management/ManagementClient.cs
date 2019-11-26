// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Microsoft.Azure.ServiceBus.Primitives;

    public class ManagementClient
    {
        private HttpClient httpClient;
        private readonly string endpointFQDN;
        private readonly ITokenProvider tokenProvider;
        private readonly int port;
        private readonly string clientId;

        /// <summary>
        /// Initializes a new <see cref="ManagementClient"/> which can be used to perform management opertions on ServiceBus entities.
        /// </summary>
        /// <param name="connectionString">Namespace connection string.</param>
        public ManagementClient(string connectionString)
            : this(new ServiceBusConnectionStringBuilder(connectionString))
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ManagementClient"/> which can be used to perform management opertions on ServiceBus entities.
        /// </summary>
        /// <param name="endpoint">Fully qualified domain name for Service Bus. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        public ManagementClient(string endpoint, ITokenProvider tokenProvider)
            : this(new ServiceBusConnectionStringBuilder {Endpoint = endpoint}, tokenProvider)
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ManagementClient"/> which can be used to perform management opertions on ServiceBus entities.
        /// </summary>
        /// <param name="connectionStringBuilder"><see cref="ServiceBusConnectionStringBuilder"/> having endpoint information.</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        public ManagementClient(ServiceBusConnectionStringBuilder connectionStringBuilder, ITokenProvider tokenProvider = default)
        {
            this.httpClient = new HttpClient { Timeout = connectionStringBuilder.OperationTimeout };
            this.endpointFQDN = connectionStringBuilder.Endpoint;
            this.tokenProvider = tokenProvider ?? CreateTokenProvider(connectionStringBuilder);
            this.port = GetPort(connectionStringBuilder.Endpoint);
            this.clientId = nameof(ManagementClient) + Guid.NewGuid().ToString("N").Substring(0, 6);

            MessagingEventSource.Log.ManagementClientCreated(this.clientId, this.httpClient.Timeout.TotalSeconds, this.tokenProvider.ToString());
        }

        public static HttpRequestMessage CloneRequest(HttpRequestMessage req)
        {
            HttpRequestMessage clone = new HttpRequestMessage(req.Method, req.RequestUri);

            clone.Content = req.Content;
            clone.Version = req.Version;

            foreach (KeyValuePair<string, object> prop in req.Properties)
            {
                clone.Properties.Add(prop);
            }

            foreach (KeyValuePair<string, IEnumerable<string>> header in req.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return clone;
        }

        /// <summary>
        /// Gets information related to the currently used namespace.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="NamespaceInfo"/> containing namespace information.</returns>
        /// <remarks>Works with any claim (Send/Listen/Manage).</remarks>
        public virtual async Task<NamespaceInfo> GetNamespaceInfoAsync(CancellationToken cancellationToken = default)
        {
            var content = await GetEntity("$namespaceinfo", null, false, cancellationToken).ConfigureAwait(false);
            return NamespaceInfoExtensions.ParseFromContent(content);
        }

        #region DeleteEntity

        /// <summary>
        /// Deletes the queue described by the path relative to the service namespace base address.
        /// </summary>
        /// <param name="queuePath">The name of the queue relative to the service namespace base address.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentException"><paramref name="queuePath"/> is empty or null, or path starts or ends with "/".</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of path is greater than 260.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="MessagingEntityNotFoundException">Queue with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual Task DeleteQueueAsync(string queuePath, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidQueueName(queuePath);
            return DeleteEntity(queuePath, cancellationToken);
        }

        /// <summary>
        /// Deletes the topic described by the name relative to the service namespace base address.
        /// </summary>
        /// <param name="topicPath">The name of the topic relative to the service namespace base address.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentException"><paramref name="topicPath"/> is empty or null, or path starts or ends with "/".</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic path is greater than 260.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="MessagingEntityNotFoundException">Topic with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual Task DeleteTopicAsync(string topicPath, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidTopicName(topicPath);
            return DeleteEntity(topicPath, cancellationToken);
        }

        /// <summary>
        /// Deletes the subscription with the specified topic and subscription name.
        /// </summary>
        /// <param name="topicPath">The name of the topic relative to the service namespace base address.</param>
        /// <param name="subscriptionName">The name of the subscription to delete.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentException"><paramref name="topicPath"/> or <paramref name="subscriptionName"/> is empty or null, or path starts or ends with "/".</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic path is greater than 260 or length of subscription name is greater than 50.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="MessagingEntityNotFoundException">Subscription with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual Task DeleteSubscriptionAsync(string topicPath, string subscriptionName, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidTopicName(topicPath);
            EntityNameHelper.CheckValidSubscriptionName(subscriptionName);

            return DeleteEntity(EntityNameHelper.FormatSubscriptionPath(topicPath, subscriptionName), cancellationToken);
        }

        /// <summary>
        /// Deletes the rule described by <paramref name="ruleName"/> from <paramref name="subscriptionName"/> under <paramref name="topicPath"/>./>
        /// </summary>
        /// <param name="topicPath">The name of the topic relative to the service namespace base address.</param>
        /// <param name="subscriptionName">The name of the subscription to delete.</param>
        /// <param name="ruleName">The name of the rule to delete.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicPath"/>, <paramref name="subscriptionName"/>, or <paramref name="ruleName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic path is greater than 260 or length of subscription-name/rule-name is greater than 50.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="MessagingEntityNotFoundException">Rule with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual Task DeleteRuleAsync(string topicPath, string subscriptionName, string ruleName, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidTopicName(topicPath);
            EntityNameHelper.CheckValidSubscriptionName(subscriptionName);
            EntityNameHelper.CheckValidRuleName(ruleName);

            return DeleteEntity(EntityNameHelper.FormatRulePath(topicPath, subscriptionName, ruleName), cancellationToken);
        }

        #endregion

        #region GetEntity

        /// <summary>
        /// Retrieves a queue from the service namespace.
        /// </summary>
        /// <param name="queuePath">The path of the queue relative to service bus namespace.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="QueueDescription"/> containing information about the queue.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="queuePath"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of queue path is greater than 260.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="MessagingEntityNotFoundException">Queue with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<QueueDescription> GetQueueAsync(string queuePath, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidQueueName(queuePath);

            var content = await GetEntity(queuePath, null, false, cancellationToken).ConfigureAwait(false);

            return QueueDescriptionExtensions.ParseFromContent(content);
        }

        /// <summary>
        /// Retrieves a topic from the service namespace.
        /// </summary>
        /// <param name="topicPath">The path of the topic relative to service bus namespace.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="TopicDescription"/> containing information about the topic.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicPath"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic path is greater than 260.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="MessagingEntityNotFoundException">Topic with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<TopicDescription> GetTopicAsync(string topicPath, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidTopicName(topicPath);

            var content = await GetEntity(topicPath, null, false, cancellationToken).ConfigureAwait(false);

            return TopicDescriptionExtensions.ParseFromContent(content);
        }

        /// <summary>
        /// Retrieves a subscription from the service namespace.
        /// </summary>
        /// <param name="topicPath">The path of the topic relative to service bus namespace.</param>
        /// <param name="subscriptionName">The subscription name.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="SubscriptionDescription"/> containing information about the subscription.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicPath"/>, <paramref name="subscriptionName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic path is greater than 260 or length of subscription-name is greater than 50.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="MessagingEntityNotFoundException">Topic or Subscription with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<SubscriptionDescription> GetSubscriptionAsync(string topicPath, string subscriptionName, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidTopicName(topicPath);
            EntityNameHelper.CheckValidSubscriptionName(subscriptionName);

            var content = await GetEntity(EntityNameHelper.FormatSubscriptionPath(topicPath, subscriptionName), null, false, cancellationToken).ConfigureAwait(false);

            return SubscriptionDescriptionExtensions.ParseFromContent(topicPath, content);
        }

        /// <summary>
        /// Retrieves a rule from the service namespace.
        /// </summary>
        /// <param name="topicPath">The path of the topic relative to service bus namespace.</param>
        /// <param name="subscriptionName">The subscription name the rule belongs to.</param>
        /// <param name="ruleName">The name of the rule to retrieve.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="RuleDescription"/> containing information about the rule.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicPath"/>, <paramref name="subscriptionName"/> or <paramref name="ruleName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic path is greater than 260 or length of subscription-name/rule-name is greater than 50.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="MessagingEntityNotFoundException">Topic/Subscription/Rule with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        /// <remarks>Note - Only following data types are deserialized in Filters and Action parameters - string,int,long,bool,double,DateTime.
        /// Other data types would return its string value.</remarks>
        public virtual async Task<RuleDescription> GetRuleAsync(string topicPath, string subscriptionName, string ruleName, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidTopicName(topicPath);
            EntityNameHelper.CheckValidSubscriptionName(subscriptionName);
            EntityNameHelper.CheckValidRuleName(ruleName);

            var content = await GetEntity(EntityNameHelper.FormatRulePath(topicPath, subscriptionName, ruleName), null, false, cancellationToken).ConfigureAwait(false);

            return RuleDescriptionExtensions.ParseFromContent(content);
        }

        #endregion

        #region GetRuntimeInfo
        /// <summary>
        /// Retrieves the runtime information of a queue.
        /// </summary>
        /// <param name="queuePath">The path of the queue relative to service bus namespace.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="QueueRuntimeInfo"/> containing runtime information about the queue.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="queuePath"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of queue path is greater than 260.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="MessagingEntityNotFoundException">Queue with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<QueueRuntimeInfo> GetQueueRuntimeInfoAsync(string queuePath, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidQueueName(queuePath);

            var content = await GetEntity(queuePath, null, true, cancellationToken).ConfigureAwait(false);

            return QueueRuntimeInfoExtensions.ParseFromContent(content);
        }

        /// <summary>
        /// Retrieves the runtime information of a topic.
        /// </summary>
        /// <param name="topicPath">The path of the topic relative to service bus namespace.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="TopicRuntimeInfo"/> containing runtime information about the topic.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicPath"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic path is greater than 260.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="MessagingEntityNotFoundException">Topic with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<TopicRuntimeInfo> GetTopicRuntimeInfoAsync(string topicPath, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidTopicName(topicPath);

            var content = await GetEntity(topicPath, null, true, cancellationToken).ConfigureAwait(false);

            return TopicRuntimeInfoExtensions.ParseFromContent(content);
        }

        /// <summary>
        /// Retrieves the runtime information of a subscription.
        /// </summary>
        /// <param name="topicPath">The path of the topic relative to service bus namespace.</param>
        /// <param name="subscriptionName">The subscription name.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="SubscriptionRuntimeInfo"/> containing runtime information about the subscription.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicPath"/>, <paramref name="subscriptionName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic path is greater than 260 or length of subscription-name is greater than 50.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="MessagingEntityNotFoundException">Topic or Subscription with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<SubscriptionRuntimeInfo> GetSubscriptionRuntimeInfoAsync(string topicPath, string subscriptionName, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidTopicName(topicPath);
            EntityNameHelper.CheckValidSubscriptionName(subscriptionName);

            var content = await GetEntity(EntityNameHelper.FormatSubscriptionPath(topicPath, subscriptionName), null, true, cancellationToken).ConfigureAwait(false);

            return SubscriptionRuntimeInfoExtensions.ParseFromContent(topicPath, content);
        }

        #endregion

        #region GetEntities
        /// <summary>
        /// Retrieves the list of queues present in the namespace.
        /// </summary>
        /// <param name="count">The number of queues to fetch. Defaults to 100. Maximum value allowed is 100.</param>
        /// <param name="skip">The number of queues to skip. Defaults to 0. Cannot be negative.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="IList&lt;QueueDescription&gt;"/> containing list of queues.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        /// <remarks>You can simulate pages of list of entities by manipulating <paramref name="count"/> and <paramref name="skip"/>.
        /// skip(0)+count(100) gives first 100 entities. skip(100)+count(100) gives the next 100 entities.</remarks>
        public virtual async Task<IList<QueueDescription>> GetQueuesAsync(int count = 100, int skip = 0, CancellationToken cancellationToken = default)
        {
            if (count > 100 || count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Value should be between 1 and 100");
            }
            if (skip < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skip), "Value cannot be negative");
            }

            var content = await GetEntity("$Resources/queues", $"$skip={skip}&$top={count}", false, cancellationToken).ConfigureAwait(false);
            return QueueDescriptionExtensions.ParseCollectionFromContent(content);
        }

        /// <summary>
        /// Retrieves the list of topics present in the namespace.
        /// </summary>
        /// <param name="count">The number of topics to fetch. Defaults to 100. Maximum value allowed is 100.</param>
        /// <param name="skip">The number of topics to skip. Defaults to 0. Cannot be negative.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="IList&lt;TopicDescription&gt;"/> containing list of topics.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        /// <remarks>You can simulate pages of list of entities by manipulating <paramref name="count"/> and <paramref name="skip"/>.
        /// skip(0)+count(100) gives first 100 entities. skip(100)+count(100) gives the next 100 entities.</remarks>
        public virtual async Task<IList<TopicDescription>> GetTopicsAsync(int count = 100, int skip = 0, CancellationToken cancellationToken = default)
        {
            if (count > 100 || count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Value should be between 1 and 100");
            }
            if (skip < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skip), "Value cannot be negative");
            }

            var content = await GetEntity("$Resources/topics", $"$skip={skip}&$top={count}", false, cancellationToken).ConfigureAwait(false);
            return TopicDescriptionExtensions.ParseCollectionFromContent(content);
        }

        /// <summary>
        /// Retrieves the list of subscriptions present in the topic.
        /// </summary>
        /// <param name="topicPath">The topic path under which all the subscriptions need to be retrieved.</param>
        /// <param name="count">The number of subscriptions to fetch. Defaults to 100. Maximum value allowed is 100.</param>
        /// <param name="skip">The number of subscriptions to skip. Defaults to 0. Cannot be negative.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="IList&lt;SubscriptionDescription&gt;"/> containing list of subscriptions.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        /// <remarks>You can simulate pages of list of entities by manipulating <paramref name="count"/> and <paramref name="skip"/>.
        /// skip(0)+count(100) gives first 100 entities. skip(100)+count(100) gives the next 100 entities.</remarks>
        public virtual async Task<IList<SubscriptionDescription>> GetSubscriptionsAsync(string topicPath, int count = 100, int skip = 0, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidTopicName(topicPath);
            if (count > 100 || count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Value should be between 1 and 100");
            }
            if (skip < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skip), "Value cannot be negative");
            }

            var content = await GetEntity($"{topicPath}/Subscriptions", $"$skip={skip}&$top={count}", false, cancellationToken).ConfigureAwait(false);
            return SubscriptionDescriptionExtensions.ParseCollectionFromContent(topicPath, content);
        }

        /// <summary>
        /// Retrieves the list of rules for a given subscription in a topic.
        /// </summary>
        /// <param name="topicPath">The topic path.</param>
        /// <param name="subscriptionName"> The subscription for which all the rules need to be retrieved.</param>
        /// <param name="count">The number of rules to fetch. Defaults to 100. Maximum value allowed is 100.</param>
        /// <param name="skip">The number of rules to skip. Defaults to 0. Cannot be negative.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="IList&lt;RuleDescription&gt;"/> containing list of rules.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        /// <remarks>You can simulate pages of list of entities by manipulating <paramref name="count"/> and <paramref name="skip"/>.
        /// skip(0)+count(100) gives first 100 entities. skip(100)+count(100) gives the next 100 entities.
        /// Note - Only following data types are deserialized in Filters and Action parameters - string,int,long,bool,double,DateTime.
        /// Other data types would return its string value.</remarks>
        public virtual async Task<IList<RuleDescription>> GetRulesAsync(string topicPath, string subscriptionName, int count = 100, int skip = 0, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidTopicName(topicPath);
            EntityNameHelper.CheckValidSubscriptionName(subscriptionName);
            if (count > 100 || count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Value should be between 1 and 100");
            }
            if (skip < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skip), "Value cannot be negative");
            }

            var content = await GetEntity($"{topicPath}/Subscriptions/{subscriptionName}/rules", $"$skip={skip}&$top={count}", false, cancellationToken).ConfigureAwait(false);
            return RuleDescriptionExtensions.ParseCollectionFromContent(content);
        }

        #endregion

        #region CreateEntity

        /// <summary>
        /// Creates a new queue in the service namespace with the given name.
        /// </summary>
        /// <remarks>Throws if a queue already exists. <see cref="QueueDescription"/> for default values of queue properties.</remarks>
        /// <param name="queuePath">The name of the queue relative to the service namespace base address.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="QueueDescription"/> of the newly created queue.</returns>
        /// <exception cref="ArgumentNullException">Queue name is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="queuePath"/> is greater than 260 characters.</exception>
        /// <exception cref="MessagingEntityAlreadyExistsException">An entity with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="QuotaExceededException">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual Task<QueueDescription> CreateQueueAsync(string queuePath, CancellationToken cancellationToken = default)
        {
            return this.CreateQueueAsync(new QueueDescription(queuePath), cancellationToken);
        }

        /// <summary>
        /// Creates a new queue in the service namespace with the given name.
        /// </summary>
        /// <remarks>Throws if a queue already exists.</remarks>
        /// <param name="queueDescription">A <see cref="QueueDescription"/> object describing the attributes with which the new queue will be created.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="QueueDescription"/> of the newly created queue.</returns>
        /// <exception cref="ArgumentNullException">Queue name is null or empty.</exception>
        /// <exception cref="MessagingEntityAlreadyExistsException">A queue with the same nameexists under the same service namespace.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="QuotaExceededException">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<QueueDescription> CreateQueueAsync(QueueDescription queueDescription, CancellationToken cancellationToken = default)
        {
            queueDescription = queueDescription ?? throw new ArgumentNullException(nameof(queueDescription));
            queueDescription.NormalizeDescription(this.endpointFQDN);
            var atomRequest = queueDescription.Serialize().ToString();
            var content = await PutEntity(
                queueDescription.Path,
                atomRequest,
                false,
                queueDescription.ForwardTo,
                queueDescription.ForwardDeadLetteredMessagesTo,
                cancellationToken).ConfigureAwait(false);
            return QueueDescriptionExtensions.ParseFromContent(content);
        }

        /// <summary>
        /// Creates a new topic in the service namespace with the given name.
        /// </summary>
        /// <remarks>Throws if a topic already exists. <see cref="TopicDescription"/> for default values of topic properties.</remarks>
        /// <param name="topicPath">The name of the topic relative to the service namespace base address.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="TopicDescription"/> of the newly created topic.</returns>
        /// <exception cref="ArgumentNullException">Topic name is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="topicPath"/> is greater than 260 characters.</exception>
        /// <exception cref="MessagingEntityAlreadyExistsException">A topic with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="QuotaExceededException">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual Task<TopicDescription> CreateTopicAsync(string topicPath, CancellationToken cancellationToken = default)
        {
            return this.CreateTopicAsync(new TopicDescription(topicPath), cancellationToken);
        }

        /// <summary>
        /// Creates a new topic in the service namespace with the given name.
        /// </summary>
        /// <remarks>Throws if a topic already exists. <see cref="TopicDescription"/> for default values of topic properties.</remarks>
        /// <param name="topicDescription">A <see cref="TopicDescription"/> object describing the attributes with which the new topic will be created.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="TopicDescription"/> of the newly created topic.</returns>
        /// <exception cref="ArgumentNullException">Topic description is null.</exception>
        /// <exception cref="MessagingEntityAlreadyExistsException">A topic with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="QuotaExceededException">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<TopicDescription> CreateTopicAsync(TopicDescription topicDescription, CancellationToken cancellationToken = default)
        {
            topicDescription = topicDescription ?? throw new ArgumentNullException(nameof(topicDescription));
            var atomRequest = topicDescription.Serialize().ToString();

            var content = await PutEntity(topicDescription.Path, atomRequest, false, null, null, cancellationToken).ConfigureAwait(false);

            return TopicDescriptionExtensions.ParseFromContent(content);
        }

        /// <summary>
        /// Creates a new subscription within a topic in the service namespace with the given name.
        /// </summary>
        /// <remarks>Throws if a subscription already exists. <see cref="SubscriptionDescription"/> for default values of subscription properties.
        /// Be default, A "pass-through" filter is created for this subscription, which means it will allow all messages to go to this subscription. The name of the filter is represented by <see cref="RuleDescription.DefaultRuleName"/>.
        /// <see cref="CreateSubscriptionAsync(SubscriptionDescription, RuleDescription, CancellationToken)"/> for creating subscription with a different filter.</remarks>
        /// <param name="topicPath">The path of the topic relative to the service namespace base address.</param>
        /// <param name="subscriptionName">The name of the subscription.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="SubscriptionDescription"/> of the newly created subscription.</returns>
        /// <exception cref="ArgumentNullException">Topic path or subscription name is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="topicPath"/> is greater than 260 characters or <paramref name="subscriptionName"/> is greater than 50 characters.</exception>
        /// <exception cref="MessagingEntityAlreadyExistsException">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="QuotaExceededException">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual Task<SubscriptionDescription> CreateSubscriptionAsync(string topicPath, string subscriptionName, CancellationToken cancellationToken = default)
        {
            return this.CreateSubscriptionAsync(new SubscriptionDescription(topicPath, subscriptionName), cancellationToken);
        }

        /// <summary>
        /// Creates a new subscription within a topic in the service namespace with the given name.
        /// </summary>
        /// <remarks>Throws if a subscription already exists.
        /// Be default, A "pass-through" filter is created for this subscription, which means it will allow all messages to go to this subscription. The name of the filter is represented by <see cref="RuleDescription.DefaultRuleName"/>.
        /// <see cref="CreateSubscriptionAsync(SubscriptionDescription, RuleDescription, CancellationToken)"/> for creating subscription with a different filter.</remarks>
        /// <param name="subscriptionDescription">A <see cref="SubscriptionDescription"/> object describing the attributes with which the new subscription will be created.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="SubscriptionDescription"/> of the newly created subscription.</returns>
        /// <exception cref="ArgumentNullException">Subscription description is null.</exception>
        /// <exception cref="MessagingEntityAlreadyExistsException">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="QuotaExceededException">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual Task<SubscriptionDescription> CreateSubscriptionAsync(SubscriptionDescription subscriptionDescription, CancellationToken cancellationToken = default)
        {
            subscriptionDescription = subscriptionDescription ?? throw new ArgumentNullException(nameof(subscriptionDescription));
            return this.CreateSubscriptionAsync(subscriptionDescription, null, cancellationToken);
        }

        /// <summary>
        /// Creates a new subscription within a topic with the provided default rule.
        /// </summary>
        /// <remarks>Throws if a subscription already exists. </remarks>
        /// <param name="subscriptionDescription">A <see cref="SubscriptionDescription"/> object describing the attributes with which the new subscription will be created.</param>
        /// <param name="defaultRule"> A <see cref="RuleDescription"/> object describing the default rule. If null, then pass-through filter with name <see cref="RuleDescription.DefaultRuleName"/> will be created.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="SubscriptionDescription"/> of the newly created subscription.</returns>
        /// <exception cref="ArgumentNullException">Subscription description is null.</exception>
        /// <exception cref="MessagingEntityAlreadyExistsException">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="QuotaExceededException">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<SubscriptionDescription> CreateSubscriptionAsync(SubscriptionDescription subscriptionDescription, RuleDescription defaultRule, CancellationToken cancellationToken = default)
        {
            subscriptionDescription = subscriptionDescription ?? throw new ArgumentNullException(nameof(subscriptionDescription));
            subscriptionDescription.NormalizeDescription(this.endpointFQDN);
            subscriptionDescription.DefaultRuleDescription = defaultRule;
            var atomRequest = subscriptionDescription.Serialize().ToString();
            var content = await PutEntity(
                EntityNameHelper.FormatSubscriptionPath(subscriptionDescription.TopicPath, subscriptionDescription.SubscriptionName),
                atomRequest,
                false,
                subscriptionDescription.ForwardTo,
                subscriptionDescription.ForwardDeadLetteredMessagesTo,
                cancellationToken).ConfigureAwait(false);
            return SubscriptionDescriptionExtensions.ParseFromContent(subscriptionDescription.TopicPath, content);
        }

        /// <summary>
        /// Adds a new rule to the subscription under given topic.
        /// </summary>
        /// <param name="topicPath">The topic path relative to the service namespace base address.</param>
        /// <param name="subscriptionName">The name of the subscription.</param>
        /// <param name="ruleDescription">A <see cref="RuleDescription"/> object describing the attributes with which the messages are matched and acted upon.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException">Subscription or rule description is null.</exception>
        /// <exception cref="MessagingEntityAlreadyExistsException">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="QuotaExceededException">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        /// <returns><see cref="RuleDescription"/> of the recently created rule.</returns>
        public virtual async Task<RuleDescription> CreateRuleAsync(string topicPath, string subscriptionName, RuleDescription ruleDescription, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidTopicName(topicPath);
            EntityNameHelper.CheckValidSubscriptionName(subscriptionName);
            ruleDescription = ruleDescription ?? throw new ArgumentNullException(nameof(ruleDescription));

            var atomRequest = ruleDescription.Serialize().ToString();

            var content = await PutEntity(
                EntityNameHelper.FormatRulePath(topicPath, subscriptionName, ruleDescription.Name),
                atomRequest,
                false,
                null,
                null,
                cancellationToken).ConfigureAwait(false);

            return RuleDescriptionExtensions.ParseFromContent(content);
        }

        #endregion CreateEntity

        #region UpdateEntity
        /// <summary>
        /// Updates an existing queue.
        /// </summary>
        /// <param name="queueDescription">A <see cref="QueueDescription"/> object describing the attributes with which the queue will be updated.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="QueueDescription"/> of the updated queue.</returns>
        /// <exception cref="ArgumentNullException">Queue descriptor is null.</exception>
        /// <exception cref="MessagingEntityNotFoundException">Described queue was not found.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="QuotaExceededException">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<QueueDescription> UpdateQueueAsync(QueueDescription queueDescription, CancellationToken cancellationToken = default)
        {
            queueDescription = queueDescription ?? throw new ArgumentNullException(nameof(queueDescription));
            queueDescription.NormalizeDescription(this.endpointFQDN);

            var atomRequest = queueDescription.Serialize().ToString();

            var content = await PutEntity(
                queueDescription.Path,
                atomRequest,
                true,
                queueDescription.ForwardTo,
                queueDescription.ForwardDeadLetteredMessagesTo,
                cancellationToken).ConfigureAwait(false);

            return QueueDescriptionExtensions.ParseFromContent(content);
        }

        /// <summary>
        /// Updates an existing topic.
        /// </summary>
        /// <param name="topicDescription">A <see cref="TopicDescription"/> object describing the attributes with which the topic will be updated.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="TopicDescription"/> of the updated topic.</returns>
        /// <exception cref="ArgumentNullException">Topic descriptor is null.</exception>
        /// <exception cref="MessagingEntityNotFoundException">Described topic was not found.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="QuotaExceededException">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<TopicDescription> UpdateTopicAsync(TopicDescription topicDescription, CancellationToken cancellationToken = default)
        {
            topicDescription = topicDescription ?? throw new ArgumentNullException(nameof(topicDescription));
            var atomRequest = topicDescription.Serialize().ToString();

            var content = await PutEntity(topicDescription.Path, atomRequest, true, null, null, cancellationToken).ConfigureAwait(false);

            return TopicDescriptionExtensions.ParseFromContent(content);
        }

        /// <summary>
        /// Updates an existing subscription under a topic.
        /// </summary>
        /// <param name="subscriptionDescription">A <see cref="SubscriptionDescription"/> object describing the attributes with which the subscription will be updated.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="SubscriptionDescription"/> of the updated subscription.</returns>
        /// <exception cref="ArgumentNullException">subscription descriptor is null.</exception>
        /// <exception cref="MessagingEntityNotFoundException">Described subscription was not found.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="QuotaExceededException">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<SubscriptionDescription> UpdateSubscriptionAsync(SubscriptionDescription subscriptionDescription, CancellationToken cancellationToken = default)
        {
            subscriptionDescription = subscriptionDescription ?? throw new ArgumentNullException(nameof(subscriptionDescription));
            subscriptionDescription.NormalizeDescription(this.endpointFQDN);
            var atomRequest = subscriptionDescription.Serialize().ToString();
            var content = await PutEntity(
                EntityNameHelper.FormatSubscriptionPath(subscriptionDescription.TopicPath, subscriptionDescription.SubscriptionName),
                atomRequest,
                true,
                subscriptionDescription.ForwardTo,
                subscriptionDescription.ForwardDeadLetteredMessagesTo,
                cancellationToken).ConfigureAwait(false);
            return SubscriptionDescriptionExtensions.ParseFromContent(subscriptionDescription.TopicPath, content);
        }

        /// <summary>
        /// Updates an existing rule for a topic-subscription.
        /// </summary>
        /// <param name="topicPath">Path of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription.</param>
        /// <param name="ruleDescription">A <see cref="RuleDescription"/> object describing the attributes with which the rule will be updated.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="RuleDescription"/> of the updated rule.</returns>
        /// <exception cref="ArgumentNullException">rule descriptor is null.</exception>
        /// <exception cref="MessagingEntityNotFoundException">Described topic/subscription/rule was not found.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="QuotaExceededException">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<RuleDescription> UpdateRuleAsync(string topicPath, string subscriptionName, RuleDescription ruleDescription, CancellationToken cancellationToken = default)
        {
            ruleDescription = ruleDescription ?? throw new ArgumentNullException(nameof(ruleDescription));
            EntityNameHelper.CheckValidTopicName(topicPath);
            EntityNameHelper.CheckValidSubscriptionName(subscriptionName);

            var atomRequest = ruleDescription.Serialize().ToString();
            var content = await PutEntity(
                EntityNameHelper.FormatRulePath(topicPath, subscriptionName, ruleDescription.Name),
                atomRequest,
                true,
                null, null,
                cancellationToken).ConfigureAwait(false);

            return RuleDescriptionExtensions.ParseFromContent(content);
        }

        #endregion

        #region Exists
        /// <summary>
        /// Checks whether a given queue exists or not.
        /// </summary>
        /// <param name="queuePath">Path of the queue entity to check.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if queue exists, false otherwise.</returns>
        /// <exception cref="ArgumentException">Queue path provided is not valid.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<bool> QueueExistsAsync(string queuePath, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidQueueName(queuePath);

            try
            {
                // TODO: Optimize by removing deserialization costs.
                var qd = await GetQueueAsync(queuePath, cancellationToken).ConfigureAwait(false);
            }
            catch (MessagingEntityNotFoundException)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks whether a given topic exists or not.
        /// </summary>
        /// <param name="topicPath">Path of the topic entity to check.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if topic exists, false otherwise.</returns>
        /// <exception cref="ArgumentException">topic path provided is not valid.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<bool> TopicExistsAsync(string topicPath, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidTopicName(topicPath);

            try
            {
                // TODO: Optimize by removing deserialization costs.
                var td = await GetTopicAsync(topicPath, cancellationToken).ConfigureAwait(false);
            }
            catch (MessagingEntityNotFoundException)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks whether a given subscription exists or not.
        /// </summary>
        /// <param name="topicPath">Path of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription to check.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if subscription exists, false otherwise.</returns>
        /// <exception cref="ArgumentException">topic or subscription path provided is not valid.</exception>
        /// <exception cref="ServiceBusTimeoutException">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenProvider"/> credentials to perform this operation.</exception>
        /// <exception cref="ServerBusyException">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<bool> SubscriptionExistsAsync(string topicPath, string subscriptionName, CancellationToken cancellationToken = default)
        {
            EntityNameHelper.CheckValidTopicName(topicPath);
            EntityNameHelper.CheckValidSubscriptionName(subscriptionName);

            try
            {
                // TODO: Optimize by removing deserialization costs.
                var sd = await GetSubscriptionAsync(topicPath, subscriptionName, cancellationToken).ConfigureAwait(false);
            }
            catch (MessagingEntityNotFoundException)
            {
                return false;
            }

            return true;
        }

        public Task CloseAsync()
        {
            httpClient?.Dispose();
            httpClient = null;

            return Task.CompletedTask;
        }

        #endregion

        private static int GetPort(string endpoint)
        {
            // used for internal testing
            if (endpoint.EndsWith("onebox.windows-int.net", StringComparison.InvariantCultureIgnoreCase))
            {
                return 4446;
            }

            return -1;
        }

        private static async Task<Exception> ValidateHttpResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return null;
            }

            var exceptionMessage = await (response.Content?.ReadAsStringAsync() ?? Task.FromResult(string.Empty));
            exceptionMessage = ParseDetailIfAvailable(exceptionMessage) ?? response.ReasonPhrase;

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return new UnauthorizedException(exceptionMessage);
            }

            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.NoContent)
            {
                return new MessagingEntityNotFoundException(exceptionMessage);
            }

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                if (response.RequestMessage.Method.Equals(HttpMethod.Delete))
                {
                    return new ServiceBusException(true, exceptionMessage);
                }

                if (response.RequestMessage.Method.Equals(HttpMethod.Put) && response.RequestMessage.Headers.IfMatch.Count > 0)
                {
                    // response.RequestMessage.Headers.IfMatch.Count > 0 is true for UpdateEntity scenario
                    return new ServiceBusException(true, exceptionMessage);
                }

                if (exceptionMessage.Contains(ManagementClientConstants.ConflictOperationInProgressSubCode))
                {
                    return new ServiceBusException(true, exceptionMessage);
                }

                return new MessagingEntityAlreadyExistsException(exceptionMessage);
            }

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                if (exceptionMessage.Contains(ManagementClientConstants.ForbiddenInvalidOperationSubCode))
                {
                    return new InvalidOperationException(exceptionMessage);
                }

                return new QuotaExceededException(exceptionMessage);
            }

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return new ServiceBusException(false, new ArgumentException(exceptionMessage));
            }

            if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                return new ServerBusyException(exceptionMessage);
            }

            return new ServiceBusException(true, exceptionMessage + "; response status code: " + response.StatusCode);
        }

        private static string ParseDetailIfAvailable(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return null;
            }

            try
            {
                var errorContentXml = XElement.Parse(content);
                var detail = errorContentXml.Element("Detail");

                return detail?.Value ?? content;
            }
            catch (Exception)
            {
                return content;
            }
        }

        private static ITokenProvider CreateTokenProvider(ServiceBusConnectionStringBuilder builder)
        {
            if (builder.SasToken != null)
            {
                return new SharedAccessSignatureTokenProvider(builder.SasToken);
            }
            else if (builder.SasKeyName != null && builder.SasKey != null)
            {
                return new SharedAccessSignatureTokenProvider(builder.SasKeyName, builder.SasKey);
            }
            else if (builder.Authentication.Equals(ServiceBusConnectionStringBuilder.AuthenticationType.ManagedIdentity))
            {
                return new ManagedIdentityTokenProvider();
            }

            throw new ArgumentException("Could not create token provider. Either ITokenProvider has to be passed into constructor or connection string should contain SAS token OR SAS key name and SAS key OR Authentication = Managed Identity.");
        }

        private Task<string> GetToken(Uri requestUri)
        {
            return this.GetToken(requestUri.GetLeftPart(UriPartial.Path));
        }

        private async Task<string> GetToken(string requestUri)
        {
            var token = await this.tokenProvider.GetTokenAsync(requestUri, TimeSpan.FromHours(1)).ConfigureAwait(false);
            return token.TokenValue;
        }

        private async Task<string> GetEntity(string path, string query, bool enrich, CancellationToken cancellationToken)
        {
            MessagingEventSource.Log.ManagementOperationStart(this.clientId, nameof(GetEntity), $"path:{path},query:{query},enrich:{enrich}");

            var queryString = $"{ManagementClientConstants.apiVersionQuery}&enrich={enrich}";
            if (query != null)
            {
                queryString = queryString + "&" + query;
            }
            var uri = new UriBuilder(this.endpointFQDN)
            {
                Path = path,
                Scheme = Uri.UriSchemeHttps,
                Port = this.port,
                Query = queryString
            }.Uri;

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            HttpResponseMessage response = await SendHttpRequest(request, cancellationToken).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            MessagingEventSource.Log.ManagementOperationEnd(this.clientId, nameof(GetEntity), $"path:{path},query:{query},enrich:{enrich}");
            return result;
        }

        private async Task<string> PutEntity(string path, string requestBody, bool isUpdate, string forwardTo, string fwdDeadLetterTo, CancellationToken cancellationToken)
        {
            MessagingEventSource.Log.ManagementOperationStart(this.clientId, nameof(PutEntity), $"path:{path},isUpdate:{isUpdate}");

            var uri = new UriBuilder(this.endpointFQDN)
            {
                Path = path,
                Port = this.port,
                Scheme = Uri.UriSchemeHttps,
                Query = $"{ManagementClientConstants.apiVersionQuery}"
            }.Uri;

            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            request.Content = new StringContent(
                requestBody,
                Encoding.UTF8,
                ManagementClientConstants.AtomContentType
            );

            if (isUpdate)
            {
                request.Headers.Add("If-Match", "*");
            }

            if (!string.IsNullOrWhiteSpace(forwardTo))
            {
                var token = await this.GetToken(forwardTo).ConfigureAwait(false);
                request.Headers.Add(ManagementClientConstants.ServiceBusSupplementartyAuthorizationHeaderName, token);
            }

            if (!string.IsNullOrWhiteSpace(fwdDeadLetterTo))
            {
                var token = await this.GetToken(fwdDeadLetterTo).ConfigureAwait(false);
                request.Headers.Add(ManagementClientConstants.ServiceBusDlqSupplementaryAuthorizationHeaderName, token);
            }

            HttpResponseMessage response = await SendHttpRequest(request, cancellationToken).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            MessagingEventSource.Log.ManagementOperationEnd(this.clientId, nameof(PutEntity), $"path:{path},isUpdate:{isUpdate}");
            return result;
        }

        private async Task DeleteEntity(string path, CancellationToken cancellationToken)
        {
            MessagingEventSource.Log.ManagementOperationStart(this.clientId, nameof(DeleteEntity), path);

            var uri = new UriBuilder(this.endpointFQDN)
            {
                Path = path,
                Scheme = Uri.UriSchemeHttps,
                Port = this.port,
                Query = ManagementClientConstants.apiVersionQuery
            }.Uri;

            var request = new HttpRequestMessage(HttpMethod.Delete, uri);
            await SendHttpRequest(request, cancellationToken).ConfigureAwait(false);
            MessagingEventSource.Log.ManagementOperationEnd(this.clientId, nameof(DeleteEntity), path);
        }

        private async Task<HttpResponseMessage> SendHttpRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.Authorization == null)
            {
                // First attempt.
                var token = await this.GetToken(request.RequestUri).ConfigureAwait(false);
                request.Headers.Add("Authorization", token);
                request.Headers.Add("UserAgent", $"SERVICEBUS/{ManagementClientConstants.ApiVersion}(api-origin={ClientInfo.Framework};os={ClientInfo.Platform};version={ClientInfo.Version};product={ClientInfo.Product})");
            }
            else
            {
                // This is a retried request.
                request = CloneRequest(request);
            }

            HttpResponseMessage response;
            try
            {
                response = await this.httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                MessagingEventSource.Log.ManagementOperationException(this.clientId, nameof(SendHttpRequest), exception);
                throw new ServiceBusException(true, exception);
            }

            var exceptionReturned = await ValidateHttpResponse(response).ConfigureAwait(false);
            if (exceptionReturned == null)
            {
                return response;
            }
            else
            {
                MessagingEventSource.Log.ManagementOperationException(this.clientId, nameof(SendHttpRequest), exceptionReturned);
                throw exceptionReturned;
            }
        }
    }
}