// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus.Management
{
    /// <summary>
    /// The <see cref="ServiceBusManagementClient"/> is the client through which all Service Bus
    /// entities can be created, updated, fetched and deleted.
    /// </summary>
    public class ServiceBusManagementClient
    {
        private readonly string _fullyQualifiedNamespace;
        private readonly HttpRequestAndResponse _httpRequestAndResponse;

        /// <summary>
        /// Path to get the namespce properties.
        /// </summary>
        private const string NamespacePath = "$namespaceinfo";

        /// <summary>
        /// Path to get the list of queues.
        /// </summary>
        private const string QueuesPath = "$Resources/queues";

        /// <summary>
        /// Path to get the list of topics.
        /// </summary>
        private const string TopicsPath = "$Resources/topics";

        /// <summary>
        /// Path to get the list of subscriptions for a given topic.
        /// </summary>
        private const string SubscriptionsPath = "{0}/Subscriptions";

        /// <summary>
        /// Path to get the list of rules for a given subscription and topic.
        /// </summary>
        private const string RulesPath = "{0}/Subscriptions/{1}/rules";

        /// <summary>
        /// Parameterless constructor to allow mocking.
        /// </summary>
        protected ServiceBusManagementClient() { }

        /// <summary>
        /// Initializes a new <see cref="ServiceBusManagementClient"/> which can be used to perform management operations on ServiceBus entities.
        /// </summary>
        ///
        /// <param name="connectionString">Namespace connection string.</param>
        public ServiceBusManagementClient(string connectionString)
            : this(connectionString, new ServiceBusManagementClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ServiceBusManagementClient"/> which can be used to perform management operations on ServiceBus entities.
        /// </summary>
        ///
        /// <param name="connectionString">Namespace connection string.</param>
        /// <param name="options"></param>
        public ServiceBusManagementClient(
            string connectionString,
            ServiceBusManagementClientOptions options)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            options ??= new ServiceBusManagementClientOptions();

            ConnectionStringProperties connectionStringProperties = ConnectionStringParser.Parse(connectionString);

            if (string.IsNullOrEmpty(connectionStringProperties.Endpoint?.Host)
                || string.IsNullOrEmpty(connectionStringProperties.SharedAccessKeyName)
                || string.IsNullOrEmpty(connectionStringProperties.SharedAccessKey))
            {
                throw new ArgumentException(Resources.MissingConnectionInformation, nameof(connectionString));
            }

            _fullyQualifiedNamespace = connectionStringProperties.Endpoint.Host;

            var sharedAccessSignature = new SharedAccessSignature
          (
               BuildAudienceResource(connectionStringProperties.Endpoint.Host),
              connectionStringProperties.SharedAccessKeyName,
               connectionStringProperties.SharedAccessKey
          );

            var sharedCredential = new SharedAccessSignatureCredential(sharedAccessSignature);
            var tokenCredential = new ServiceBusTokenCredential(
                sharedCredential,
                BuildAudienceResource(connectionStringProperties.Endpoint.Host));

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options);
            _httpRequestAndResponse = new HttpRequestAndResponse(
                pipeline,
                tokenCredential,
                _fullyQualifiedNamespace);
        }

        /// <summary>
        /// Initializes a new <see cref="ServiceBusManagementClient"/> which can be used to perform management operations on ServiceBus entities.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        public ServiceBusManagementClient(
            string fullyQualifiedNamespace,
            TokenCredential credential)
            : this(fullyQualifiedNamespace, credential, new ServiceBusManagementClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ServiceBusManagementClient"/> which can be used to perform management operations on ServiceBus entities.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="options">A set of options to apply when configuring the connection.</param>
        public ServiceBusManagementClient(
            string fullyQualifiedNamespace,
            TokenCredential credential,
            ServiceBusManagementClientOptions options)
        {
            Argument.AssertWellFormedServiceBusNamespace(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new ServiceBusManagementClientOptions();
            _fullyQualifiedNamespace = fullyQualifiedNamespace;

            switch (credential)
            {
                case SharedAccessSignatureCredential _:
                    break;

                case ServiceBusSharedKeyCredential sharedKeyCredential:
                    credential = sharedKeyCredential.AsSharedAccessSignatureCredential(BuildAudienceResource(fullyQualifiedNamespace));
                    break;
            }
            var tokenCredential = new ServiceBusTokenCredential(credential, BuildAudienceResource(fullyQualifiedNamespace));

            var authenticationPolicy = new BearerTokenAuthenticationPolicy(credential, Constants.DefaultScope);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(
                options,
                 authenticationPolicy);

            _httpRequestAndResponse = new HttpRequestAndResponse(
                pipeline,
                tokenCredential,
                _fullyQualifiedNamespace);
        }

        /// <summary>
        /// Gets information related to the currently used namespace.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Works with any claim (Send/Listen/Manage).</remarks>
        /// <returns><see cref="NamespaceProperties"/> containing namespace information.</returns>
        public virtual async Task<Response<NamespaceProperties>> GetNamespacePropertiesAsync(CancellationToken cancellationToken = default)
        {
            Response response = await _httpRequestAndResponse.GetEntityAsync(
                NamespacePath,
                null,
                false,
                cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);
            NamespaceProperties properties = NamespacePropertiesExtensions.ParseFromContent(result);

            return Response.FromValue(properties, response);

        }

        #region DeleteEntity

        /// <summary>
        /// Deletes the queue described by the name relative to the service namespace base address.
        /// </summary>
        ///
        /// <param name="name">The name of the queue relative to the service namespace base address.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty or null, or name starts or ends with "/".</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of name is greater than 260.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Queue with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual Task<Response> DeleteQueueAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidQueueName(name);
            return _httpRequestAndResponse.DeleteEntityAsync(name, cancellationToken);
        }

        /// <summary>
        /// Deletes the topic described by the name relative to the service namespace base address.
        /// </summary>
        ///
        /// <param name="name">The name of the topic relative to the service namespace base address.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty or null, or name starts or ends with "/".</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Topic with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual Task<Response> DeleteTopicAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(name);
            return _httpRequestAndResponse.DeleteEntityAsync(name, cancellationToken);
        }

        /// <summary>
        /// Deletes the subscription with the specified topic and subscription name.
        /// </summary>
        ///
        /// <param name="topicName">The name of the topic relative to the service namespace base address.</param>
        /// <param name="subscriptionName">The name of the subscription to delete.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <exception cref="ArgumentException"><paramref name="topicName"/> or <paramref name="subscriptionName"/> is empty or null, or path starts or ends with "/".</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260 or length of subscription name is greater than 50.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Subscription with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual Task<Response> DeleteSubscriptionAsync(
            string topicName,
            string subscriptionName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);

            return _httpRequestAndResponse.DeleteEntityAsync(EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName), cancellationToken);
        }

        /// <summary>
        /// Deletes the rule described by <paramref name="ruleName"/> from <paramref name="subscriptionName"/> under <paramref name="topicName"/>./>
        /// </summary>
        ///
        /// <param name="topicName">The name of the topic relative to the service namespace base address.</param>
        /// <param name="subscriptionName">The name of the subscription to delete.</param>
        /// <param name="ruleName">The name of the rule to delete.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicName"/>, <paramref name="subscriptionName"/>, or <paramref name="ruleName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260 or length of subscription-name/rule-name is greater than 50.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Rule with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual Task<Response> DeleteRuleAsync(
            string topicName,
            string subscriptionName,
            string ruleName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            EntityNameFormatter.CheckValidRuleName(ruleName);

            return _httpRequestAndResponse.DeleteEntityAsync(EntityNameFormatter.FormatRulePath(topicName, subscriptionName, ruleName), cancellationToken);
        }

        #endregion

        #region GetEntity

        /// <summary>
        /// Retrieves a queue from the service namespace.
        /// </summary>
        ///
        /// <param name="name">The name of the queue relative to service bus namespace.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns><see cref="QueueDescription"/> containing information about the queue.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of queue name is greater than 260.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Queue with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response<QueueDescription>> GetQueueAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidQueueName(name);

            Response response = await _httpRequestAndResponse.GetEntityAsync(name, null, false, cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);
            QueueDescription description = QueueDescriptionExtensions.ParseFromContent(result);

            return Response.FromValue(description, response);
        }

        /// <summary>
        /// Retrieves a topic from the service namespace.
        /// </summary>
        ///
        /// <param name="name">The name of the topic relative to service bus namespace.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns><see cref="TopicDescription"/> containing information about the topic.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Topic with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response<TopicDescription>> GetTopicAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(name);

            Response response = await _httpRequestAndResponse.GetEntityAsync(name, null, false, cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);
            TopicDescription description = TopicDescriptionExtensions.ParseFromContent(result);

            return Response.FromValue(description, response);
        }

        /// <summary>
        /// Retrieves a subscription from the service namespace.
        /// </summary>
        ///
        /// <param name="topicName">The name of the topic relative to service bus namespace.</param>
        /// <param name="subscriptionName">The subscription name.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns><see cref="SubscriptionDescription"/> containing information about the subscription.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicName"/>, <paramref name="subscriptionName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260 or length of subscription-name is greater than 50.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Topic or Subscription with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response<SubscriptionDescription>> GetSubscriptionAsync(
            string topicName,
            string subscriptionName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);

            Response response = await _httpRequestAndResponse.GetEntityAsync(EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName), null, false, cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);
            SubscriptionDescription description = SubscriptionDescriptionExtensions.ParseFromContent(topicName, result);

            return Response.FromValue(description, response);
        }

        /// <summary>
        /// Retrieves a rule from the service namespace.
        /// </summary>
        ///
        /// <param name="topicName">The name of the topic relative to service bus namespace.</param>
        /// <param name="subscriptionName">The subscription name the rule belongs to.</param>
        /// <param name="ruleName">The name of the rule to retrieve.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Note - Only following data types are deserialized in Filters and Action parameters - string,int,long,bool,double,DateTime.
        /// Other data types would return its string value.</remarks>
        /// <returns><see cref="RuleDescription"/> containing information about the rule.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicName"/>, <paramref name="subscriptionName"/> or <paramref name="ruleName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260 or length of subscription-name/rule-name is greater than 50.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Topic/Subscription/Rule with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response<RuleDescription>> GetRuleAsync(
            string topicName,
            string subscriptionName,
            string ruleName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            EntityNameFormatter.CheckValidRuleName(ruleName);

            Response response = await _httpRequestAndResponse.GetEntityAsync(EntityNameFormatter.FormatRulePath(topicName, subscriptionName, ruleName), null, false, cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);
            RuleDescription description = RuleDescriptionExtensions.ParseFromContent(result);

            return Response.FromValue(description, response);
        }

        #endregion

        #region GetRuntimeInfo
        /// <summary>
        /// Retrieves the runtime information of a queue.
        /// </summary>
        ///
        /// <param name="name">The name of the queue relative to service bus namespace.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns><see cref="QueueRuntimeInfo"/> containing runtime information about the queue.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of queue name is greater than 260.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Queue with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response<QueueRuntimeInfo>> GetQueueRuntimeInfoAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidQueueName(name);

            Response response = await _httpRequestAndResponse.GetEntityAsync(name, null, true, cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);
            QueueRuntimeInfo runtimeInfo = QueueRuntimeInfoExtensions.ParseFromContent(result);

            return Response.FromValue(runtimeInfo, response);
        }

        /// <summary>
        /// Retrieves the runtime information of a topic.
        /// </summary>
        /// <param name="name">The name of the topic relative to service bus namespace.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns><see cref="TopicRuntimeInfo"/> containing runtime information about the topic.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Topic with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response<TopicRuntimeInfo>> GetTopicRuntimeInfoAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(name);

            Response response = await _httpRequestAndResponse.GetEntityAsync(name, null, true, cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);
            TopicRuntimeInfo runtimeInfo = TopicRuntimeInfoExtensions.ParseFromContent(result);

            return Response.FromValue(runtimeInfo, response);
        }

        /// <summary>
        /// Retrieves the runtime information of a subscription.
        /// </summary>
        ///
        /// <param name="topicName">The name of the topic relative to service bus namespace.</param>
        /// <param name="subscriptionName">The subscription name.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns><see cref="SubscriptionRuntimeInfo"/> containing runtime information about the subscription.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicName"/>, <paramref name="subscriptionName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260 or length of subscription-name is greater than 50.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Topic or Subscription with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response<SubscriptionRuntimeInfo>> GetSubscriptionRuntimeInfoAsync(
            string topicName,
            string subscriptionName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);

            Response response = await _httpRequestAndResponse.GetEntityAsync(EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName), null, true, cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);
            SubscriptionRuntimeInfo runtimeInfo = SubscriptionRuntimeInfoExtensions.ParseFromContent(topicName, result);

            return Response.FromValue(runtimeInfo, response);
        }

        #endregion

        #region GetEntities
        /// <summary>
        /// Retrieves the list of queues present in the namespace.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="AsyncPageable{T}"/> describing the queues.</returns>
        /// <remarks>Maximum value allowed is 100 per page.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual AsyncPageable<QueueDescription> GetQueuesAsync(CancellationToken cancellationToken = default) =>
            PageResponseEnumerator.CreateAsyncEnumerable(nextSkip => _httpRequestAndResponse.GetEntitiesPageAsync(
                QueuesPath,
                nextSkip,
                rawResult => QueueDescriptionExtensions.ParseCollectionFromContent(rawResult),
                cancellationToken));

        /// <summary>
        /// Retrieves the list of topics present in the namespace.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="AsyncPageable{T}"/> describing the topics.</returns>
        /// <remarks>Maximum value allowed is 100 per page.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual AsyncPageable<TopicDescription> GetTopicsAsync(CancellationToken cancellationToken = default) =>
            PageResponseEnumerator.CreateAsyncEnumerable(nextSkip => _httpRequestAndResponse.GetEntitiesPageAsync(
                TopicsPath,
                nextSkip,
                rawResult => TopicDescriptionExtensions.ParseCollectionFromContent(rawResult),
                cancellationToken));

        /// <summary>
        /// Retrieves the list of subscriptions present in the topic.
        /// </summary>
        ///
        /// <param name="topicName">The topic name under which all the subscriptions need to be retrieved.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="AsyncPageable{T}"/> describing the subscriptions.</returns>
        /// <remarks>Maximum value allowed is 100 per page.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual AsyncPageable<SubscriptionDescription> GetSubscriptionsAsync(
            string topicName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextSkip => _httpRequestAndResponse.GetEntitiesPageAsync(
                string.Format(CultureInfo.CurrentCulture, SubscriptionsPath, topicName),
                nextSkip,
                rawResult => SubscriptionDescriptionExtensions.ParseCollectionFromContent(topicName, rawResult),
                cancellationToken));
        }

        /// <summary>
        /// Retrieves the list of rules for a given subscription in a topic.
        /// </summary>
        ///
        /// <param name="topicName">The topic name.</param>
        /// <param name="subscriptionName"> The subscription for which all the rules need to be retrieved.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="AsyncPageable{T}"/> describing the rules.</returns>
        /// <remarks>Maximum value allowed is 100 per page.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual AsyncPageable<RuleDescription> GetRulesAsync(
            string topicName,
            string subscriptionName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextSkip => _httpRequestAndResponse.GetEntitiesPageAsync(
                string.Format(CultureInfo.CurrentCulture, RulesPath, topicName, subscriptionName),
                nextSkip,
                rawResult => RuleDescriptionExtensions.ParseCollectionFromContent(rawResult),
                cancellationToken));
        }

        #endregion

        #region GetEntitesRuntimeInfo
        /// <summary>
        /// Retrieves the list of runtime information for queues present in the namespace.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="AsyncPageable{T}"/> describing the queues runtime information.</returns>
        /// <remarks>Maximum value allowed is 100 per page.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual AsyncPageable<QueueRuntimeInfo> GetQueuesRuntimeInfoAsync(CancellationToken cancellationToken = default) =>
            PageResponseEnumerator.CreateAsyncEnumerable(nextSkip => _httpRequestAndResponse.GetEntitiesPageAsync(
                QueuesPath,
                nextSkip,
                rawResult => QueueRuntimeInfoExtensions.ParseCollectionFromContent(rawResult),
                cancellationToken));

        /// <summary>
        /// Retrieves the list of runtime information for topics present in the namespace.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="AsyncPageable{T}"/> describing the topics runtime information.</returns>
        /// <remarks>Maximum value allowed is 100 per page.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual AsyncPageable<TopicRuntimeInfo> GetTopicsRuntimeInfoAsync(CancellationToken cancellationToken = default) =>
            PageResponseEnumerator.CreateAsyncEnumerable(nextSkip => _httpRequestAndResponse.GetEntitiesPageAsync(
                TopicsPath,
                nextSkip,
                rawResult => TopicRuntimeInfoExtensions.ParseCollectionFromContent(rawResult),
                cancellationToken));

        /// <summary>
        /// Retrieves the list of runtime information for subscriptions present in the namespace.
        /// </summary>
        ///
        /// <param name="topicName">The name of the topic relative to service bus namespace.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        ///  <returns>An <see cref="AsyncPageable{T}"/> describing the subscriptions runtime information.</returns>
        /// <remarks>Maximum value allowed is 100 per page.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual AsyncPageable<SubscriptionRuntimeInfo> GetSubscriptionsRuntimeInfoAsync(
            string topicName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextSkip => _httpRequestAndResponse.GetEntitiesPageAsync(
                string.Format(CultureInfo.CurrentCulture, SubscriptionsPath, topicName),
                nextSkip,
                rawResult => SubscriptionRuntimeInfoExtensions.ParseCollectionFromContent(topicName, rawResult),
                cancellationToken));
        }

        #endregion

        #region CreateEntity

        /// <summary>
        /// Creates a new queue in the service namespace with the given name.
        /// </summary>
        ///
        /// <param name="name">The name of the queue relative to the service namespace base address.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Throws if a queue already exists. <see cref="QueueDescription"/> for default values of queue properties.</remarks>
        /// <returns>The <see cref="QueueDescription"/> of the newly created queue.</returns>
        /// <exception cref="ArgumentNullException">Queue name is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="name"/> is greater than 260 characters.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">An entity with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<QueueDescription>> CreateQueueAsync(
            string name,
            CancellationToken cancellationToken = default) =>
            await CreateQueueAsync(
                new QueueDescription(name),
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a new queue in the service namespace with the given name.
        /// </summary>
        ///
        /// <param name="queue">A <see cref="QueueDescription"/> object describing the attributes with which the new queue will be created.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Throws if a queue already exists.</remarks>
        /// <returns>The <see cref="QueueDescription"/> of the newly created queue.</returns>
        /// <exception cref="ArgumentNullException">Queue name is null or empty.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">An entity with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<QueueDescription>> CreateQueueAsync(
            QueueDescription queue,
            CancellationToken cancellationToken = default)
        {
            queue = queue ?? throw new ArgumentNullException(nameof(queue));
            queue.NormalizeDescription(_fullyQualifiedNamespace);
            var atomRequest = queue.Serialize().ToString();
            Response response = await _httpRequestAndResponse.PutEntityAsync(
                queue.Name,
                atomRequest,
                false,
                queue.ForwardTo,
                queue.ForwardDeadLetteredMessagesTo,
                cancellationToken).ConfigureAwait(false);

            var result = await ReadAsString(response).ConfigureAwait(false);
            QueueDescription description = QueueDescriptionExtensions.ParseFromContent(result);
            return Response.FromValue(description, response);
        }

        /// <summary>
        /// Creates a new topic in the service namespace with the given name.
        /// </summary>
        ///
        /// <param name="name">The name of the topic relative to the service namespace base address.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Throws if a topic already exists. <see cref="TopicDescription"/> for default values of topic properties.</remarks>
        /// <returns>The <see cref="TopicDescription"/> of the newly created topic.</returns>
        /// <exception cref="ArgumentNullException">Topic name is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="name"/> is greater than 260 characters.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">A topic with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<TopicDescription>> CreateTopicAsync(
            string name,
            CancellationToken cancellationToken = default) =>
            await CreateTopicAsync(
                new TopicDescription(name),
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a new topic in the service namespace with the given name.
        /// </summary>
        ///
        /// <param name="topic">A <see cref="TopicDescription"/> object describing the attributes with which the new topic will be created.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Throws if a topic already exists. <see cref="TopicDescription"/> for default values of topic properties.</remarks>
        /// <returns>The <see cref="TopicDescription"/> of the newly created topic.</returns>
        /// <exception cref="ArgumentNullException">Topic description is null.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">A topic with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<TopicDescription>> CreateTopicAsync(
            TopicDescription topic,
            CancellationToken cancellationToken = default)
        {
            topic = topic ?? throw new ArgumentNullException(nameof(topic));
            var atomRequest = topic.Serialize().ToString();

            Response response = await _httpRequestAndResponse.PutEntityAsync(
                topic.Name,
                atomRequest,
                false,
                null,
                null,
                cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);
            TopicDescription description = TopicDescriptionExtensions.ParseFromContent(result);

            return Response.FromValue(description, response);
        }

        /// <summary>
        /// Creates a new subscription within a topic in the service namespace with the given name.
        /// </summary>
        ///
        /// <param name="topicName">The name of the topic relative to the service namespace base address.</param>
        /// <param name="subscriptionName">The name of the subscription.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Throws if a subscription already exists. <see cref="SubscriptionDescription"/> for default values of subscription description.
        /// By default, A "pass-through" filter is created for this subscription, which means it will allow all messages to go to this subscription. The name of the filter is represented by <see cref="RuleDescription.DefaultRuleName"/>.
        /// <see cref="CreateSubscriptionAsync(SubscriptionDescription, RuleDescription, CancellationToken)"/> for creating subscription with a different filter.</remarks>
        /// <returns>The <see cref="SubscriptionDescription"/> of the newly created subscription.</returns>
        /// <exception cref="ArgumentNullException">Topic name or subscription name is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="topicName"/> is greater than 260 characters or <paramref name="subscriptionName"/> is greater than 50 characters.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<SubscriptionDescription>> CreateSubscriptionAsync(
            string topicName,
            string subscriptionName,
            CancellationToken cancellationToken = default) =>
            await CreateSubscriptionAsync(
                new SubscriptionDescription(topicName, subscriptionName),
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a new subscription within a topic in the service namespace with the given name.
        /// </summary>
        ///
        /// <param name="subscription">A <see cref="SubscriptionDescription"/> object describing the attributes with which the new subscription will be created.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Throws if a subscription already exists.
        /// Be default, A "pass-through" filter is created for this subscription, which means it will allow all messages to go to this subscription. The name of the filter is represented by <see cref="RuleDescription.DefaultRuleName"/>.
        /// <see cref="CreateSubscriptionAsync(SubscriptionDescription, RuleDescription, CancellationToken)"/> for creating subscription with a different filter.</remarks>
        /// <returns>The <see cref="SubscriptionDescription"/> of the newly created subscription.</returns>
        /// <exception cref="ArgumentNullException">Subscription description is null.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual Task<Response<SubscriptionDescription>> CreateSubscriptionAsync(
            SubscriptionDescription subscription,
            CancellationToken cancellationToken = default)
        {
            subscription = subscription ?? throw new ArgumentNullException(nameof(subscription));
            return CreateSubscriptionAsync(subscription, null, cancellationToken);
        }

        /// <summary>
        /// Creates a new subscription within a topic with the provided default rule.
        /// </summary>
        ///
        /// <param name="subscription">A <see cref="SubscriptionDescription"/> object describing the attributes with which the new subscription will be created.</param>
        /// <param name="rule"> A <see cref="RuleDescription"/> object describing the default rule. If null, then pass-through filter with name <see cref="RuleDescription.DefaultRuleName"/> will be created.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Throws if a subscription already exists. </remarks>
        /// <returns>The <see cref="SubscriptionDescription"/> of the newly created subscription.</returns>
        /// <exception cref="ArgumentNullException">Subscription description is null.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<SubscriptionDescription>> CreateSubscriptionAsync(
            SubscriptionDescription subscription,
            RuleDescription rule,
            CancellationToken cancellationToken = default)
        {
            subscription = subscription ?? throw new ArgumentNullException(nameof(subscription));
            subscription.NormalizeDescription(_fullyQualifiedNamespace);
            subscription.Rule = rule;
            var atomRequest = subscription.Serialize().ToString();

            Response response = await _httpRequestAndResponse.PutEntityAsync(
                EntityNameFormatter.FormatSubscriptionPath(subscription.TopicName, subscription.SubscriptionName),
                atomRequest,
                false,
                subscription.ForwardTo,
                subscription.ForwardDeadLetteredMessagesTo,
                cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);
            SubscriptionDescription description = SubscriptionDescriptionExtensions.ParseFromContent(subscription.TopicName, result);

            return Response.FromValue(description, response);
        }

        /// <summary>
        /// Adds a new rule to the subscription under given topic.
        /// </summary>
        ///
        /// <param name="topicName">The topic name relative to the service namespace base address.</param>
        /// <param name="subscriptionName">The name of the subscription.</param>
        /// <param name="rule">A <see cref="RuleDescription"/> object describing the attributes with which the messages are matched and acted upon.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <exception cref="ArgumentNullException">Subscription or rule description is null.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        /// <returns><see cref="RuleDescription"/> of the recently created rule.</returns>
        public virtual async Task<Response<RuleDescription>> CreateRuleAsync(
            string topicName,
            string subscriptionName,
            RuleDescription rule,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            rule = rule ?? throw new ArgumentNullException(nameof(rule));
            var atomRequest = rule.Serialize().ToString();

            Response response = await _httpRequestAndResponse.PutEntityAsync(
                EntityNameFormatter.FormatRulePath(topicName, subscriptionName, rule.Name),
                atomRequest,
                false,
                null,
                null,
                cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);
            RuleDescription description = RuleDescriptionExtensions.ParseFromContent(result);

            return Response.FromValue(description, response);
        }

        #endregion CreateEntity

        #region UpdateEntity
        /// <summary>
        /// Updates an existing queue.
        /// </summary>
        ///
        /// <param name="queue">A <see cref="QueueDescription"/> object describing the attributes with which the queue will be updated.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The <see cref="QueueDescription"/> of the updated queue.</returns>
        /// <exception cref="ArgumentNullException">Queue descriptor is null.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Described queue was not found.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<QueueDescription>> UpdateQueueAsync(
            QueueDescription queue,
            CancellationToken cancellationToken = default)
        {
            queue = queue ?? throw new ArgumentNullException(nameof(queue));
            queue.NormalizeDescription(_fullyQualifiedNamespace);
            var atomRequest = queue.Serialize().ToString();

            Response response = await _httpRequestAndResponse.PutEntityAsync(
                queue.Name,
                atomRequest,
                true,
                queue.ForwardTo,
                queue.ForwardDeadLetteredMessagesTo,
                cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);
            QueueDescription description = QueueDescriptionExtensions.ParseFromContent(result);

            return Response.FromValue(description, response);
        }

        /// <summary>
        /// Updates an existing topic.
        /// </summary>
        ///
        /// <param name="topic">A <see cref="TopicDescription"/> object describing the attributes with which the topic will be updated.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The <see cref="TopicDescription"/> of the updated topic.</returns>
        /// <exception cref="ArgumentNullException">Topic descriptor is null.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Described topic was not found.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<TopicDescription>> UpdateTopicAsync(
            TopicDescription topic,
            CancellationToken cancellationToken = default)
        {
            topic = topic ?? throw new ArgumentNullException(nameof(topic));
            var atomRequest = topic.Serialize().ToString();

            Response response = await _httpRequestAndResponse.PutEntityAsync(topic.Name, atomRequest, true, null, null, cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);
            TopicDescription description = TopicDescriptionExtensions.ParseFromContent(result);

            return Response.FromValue(description, response);
        }

        /// <summary>
        /// Updates an existing subscription under a topic.
        /// </summary>
        ///
        /// <param name="subscription">A <see cref="SubscriptionDescription"/> object describing the attributes with which the subscription will be updated.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The <see cref="SubscriptionDescription"/> of the updated subscription.</returns>
        /// <exception cref="ArgumentNullException">subscription descriptor is null.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Described subscription was not found.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<SubscriptionDescription>> UpdateSubscriptionAsync(
            SubscriptionDescription subscription,
            CancellationToken cancellationToken = default)
        {
            subscription = subscription ?? throw new ArgumentNullException(nameof(subscription));
            subscription.NormalizeDescription(_fullyQualifiedNamespace);
            var atomRequest = subscription.Serialize().ToString();

            Response response = await _httpRequestAndResponse.PutEntityAsync(
                EntityNameFormatter.FormatSubscriptionPath(subscription.TopicName, subscription.SubscriptionName),
                atomRequest,
                true,
                subscription.ForwardTo,
                subscription.ForwardDeadLetteredMessagesTo,
                cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);
            SubscriptionDescription description = SubscriptionDescriptionExtensions.ParseFromContent(subscription.TopicName, result);

            return Response.FromValue(description, response);
        }

        /// <summary>
        /// Updates an existing rule for a topic-subscription.
        /// </summary>
        ///
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription.</param>
        /// <param name="rule">A <see cref="RuleDescription"/> object describing the attributes with which the rule will be updated.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The <see cref="RuleDescription"/> of the updated rule.</returns>
        /// <exception cref="ArgumentNullException">rule descriptor is null.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Described topic/subscription/rule was not found.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<RuleDescription>> UpdateRuleAsync(
            string topicName,
            string subscriptionName,
            RuleDescription rule,
            CancellationToken cancellationToken = default)
        {
            rule = rule ?? throw new ArgumentNullException(nameof(rule));
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);

            var atomRequest = rule.Serialize().ToString();
            Response response = await _httpRequestAndResponse.PutEntityAsync(
                EntityNameFormatter.FormatRulePath(topicName, subscriptionName, rule.Name),
                atomRequest,
                true,
                null, null,
                cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);
            RuleDescription description = RuleDescriptionExtensions.ParseFromContent(result);

            return Response.FromValue(description, response);
        }

        #endregion

        #region Exists
        /// <summary>
        /// Checks whether a given queue exists or not.
        /// </summary>
        ///
        /// <param name="name">Name of the queue entity to check.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>True if queue exists, false otherwise.</returns>
        /// <exception cref="ArgumentException">Queue name provided is not valid.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<bool>> QueueExistsAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidQueueName(name);
            Response response = null;

            try
            {
                response = await _httpRequestAndResponse.GetEntityAsync(name, null, false, cancellationToken).ConfigureAwait(false);
                var result = await ReadAsString(response).ConfigureAwait(false);
                QueueDescription description = QueueDescriptionExtensions.ParseFromContent(result);
            }
            catch (ServiceBusException ex) when (ex.Reason == ServiceBusException.FailureReason.MessagingEntityNotFound)
            {
                return Response.FromValue(false, response);
            }

            return Response.FromValue(true, response);
        }

        /// <summary>
        /// Checks whether a given topic exists or not.
        /// </summary>
        ///
        /// <param name="name">Name of the topic entity to check.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>True if topic exists, false otherwise.</returns>
        /// <exception cref="ArgumentException">topic name provided is not valid.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<bool>> TopicExistsAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(name);
            Response response = null;

            try
            {
                response = await _httpRequestAndResponse.GetEntityAsync(name, null, false, cancellationToken).ConfigureAwait(false);
                var result = await ReadAsString(response).ConfigureAwait(false);
                TopicDescription description = TopicDescriptionExtensions.ParseFromContent(result);
            }
            catch (ServiceBusException ex) when (ex.Reason == ServiceBusException.FailureReason.MessagingEntityNotFound)
            {
                return Response.FromValue(false, response);
            }

            return Response.FromValue(true, response);
        }

        /// <summary>
        /// Checks whether a given subscription exists or not.
        /// </summary>
        ///
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription to check.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>True if subscription exists, false otherwise.</returns>
        /// <exception cref="ArgumentException">topic or subscription name provided is not valid.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<bool>> SubscriptionExistsAsync(
            string topicName,
            string subscriptionName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            Response response = null;

            try
            {
                response = await _httpRequestAndResponse.GetEntityAsync(EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName), null, false, cancellationToken).ConfigureAwait(false);
                var result = await ReadAsString(response).ConfigureAwait(false);
                SubscriptionDescription description = SubscriptionDescriptionExtensions.ParseFromContent(topicName, result);
            }
            catch (ServiceBusException ex) when (ex.Reason == ServiceBusException.FailureReason.MessagingEntityNotFound)
            {
                return Response.FromValue(false, response);
            }

            return Response.FromValue(true, response);
        }

        /// <summary>
        /// Checks whether a given rule exists or not.
        /// </summary>
        ///
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription to check.</param>
        /// <param name="ruleName">The name of the rule to retrieve.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>True if subscription exists, false otherwise.</returns>
        /// <exception cref="ArgumentException">topic or subscription name provided is not valid.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<bool>> RuleExistsAsync(
            string topicName,
            string subscriptionName,
            string ruleName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            Response response = null;

            try
            {
                response = await _httpRequestAndResponse.GetEntityAsync(EntityNameFormatter.FormatRulePath(topicName, subscriptionName, ruleName), null, false, cancellationToken).ConfigureAwait(false);
                var result = await ReadAsString(response).ConfigureAwait(false);
                RuleDescription description = RuleDescriptionExtensions.ParseFromContent(result);
            }
            catch (ServiceBusException ex) when (ex.Reason == ServiceBusException.FailureReason.MessagingEntityNotFound)
            {
                return Response.FromValue(false, response);
            }

            return Response.FromValue(true, response);
        }

        #endregion

        private static async Task<string> ReadAsString(Response response)
        {
            string exceptionMessage;
            using StreamReader reader = new StreamReader(response.ContentStream);
            exceptionMessage = await reader.ReadToEndAsync().ConfigureAwait(false);
            return exceptionMessage;
        }

        /// <summary>
        /// Builds the audience for use in the signature.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        ///
        /// <returns>The value to use as the audience of the signature.</returns>
        private static string BuildAudienceResource(string fullyQualifiedNamespace)
        {
            var builder = new UriBuilder(fullyQualifiedNamespace)
            {
                Scheme = Uri.UriSchemeHttps,
                Port = -1,
                Fragment = string.Empty,
                Password = string.Empty,
                UserName = string.Empty,
            };

            if (builder.Path.EndsWith("/", StringComparison.InvariantCultureIgnoreCase))
            {
                builder.Path = builder.Path.TrimEnd('/');
            }

            return builder.Uri.AbsoluteUri.ToLowerInvariant();
        }
    }

}
