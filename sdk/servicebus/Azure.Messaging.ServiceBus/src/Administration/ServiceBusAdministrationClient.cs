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

namespace Azure.Messaging.ServiceBus.Administration
{
    /// <summary>
    /// The <see cref="ServiceBusAdministrationClient"/> is the client through which all Service Bus
    /// entities can be created, updated, fetched and deleted.
    /// </summary>
    public class ServiceBusAdministrationClient
    {
        private readonly string _fullyQualifiedNamespace;
        private readonly HttpRequestAndResponse _httpRequestAndResponse;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Path to get the namespace properties.
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
        protected ServiceBusAdministrationClient() { }

        /// <summary>
        /// Initializes a new <see cref="ServiceBusAdministrationClient"/> which can be used to perform administration operations on ServiceBus entities.
        /// </summary>
        ///
        /// <param name="connectionString">Namespace connection string.</param>
        public ServiceBusAdministrationClient(string connectionString)
            : this(connectionString, new ServiceBusAdministrationClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ServiceBusAdministrationClient"/> which can be used to perform administration operations on ServiceBus entities.
        /// </summary>
        ///
        /// <param name="connectionString">Namespace connection string.</param>
        /// <param name="options">A set of options to apply when configuring the connection.</param>
        public ServiceBusAdministrationClient(
            string connectionString,
            ServiceBusAdministrationClientOptions options)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            options ??= new ServiceBusAdministrationClientOptions();
            ServiceBusConnectionStringProperties connectionStringProperties = ServiceBusConnectionStringProperties.Parse(connectionString);

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
            _clientDiagnostics = new ClientDiagnostics(options);

            _httpRequestAndResponse = new HttpRequestAndResponse(
                pipeline,
                _clientDiagnostics,
                tokenCredential,
                _fullyQualifiedNamespace,
                options.Version);
        }

        /// <summary>
        /// Initializes a new <see cref="ServiceBusAdministrationClient"/> which can be used to perform administration operations on ServiceBus entities.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The <see cref="ServiceBusSharedAccessKeyCredential"/> to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        internal ServiceBusAdministrationClient(
            string fullyQualifiedNamespace,
            ServiceBusSharedAccessKeyCredential credential)
            : this(fullyQualifiedNamespace, credential, new ServiceBusAdministrationClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ServiceBusAdministrationClient"/> which can be used to perform administration operations on ServiceBus entities.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The <see cref="ServiceBusSharedAccessKeyCredential"/> to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="options">A set of options to apply when configuring the connection.</param>
        internal ServiceBusAdministrationClient(
            string fullyQualifiedNamespace,
            ServiceBusSharedAccessKeyCredential credential,
            ServiceBusAdministrationClientOptions options)
        {
            Argument.AssertWellFormedServiceBusNamespace(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new ServiceBusAdministrationClientOptions();
            _fullyQualifiedNamespace = fullyQualifiedNamespace;

            var audience = BuildAudienceResource(fullyQualifiedNamespace);
            var tokenCredential = new ServiceBusTokenCredential(credential.AsSharedAccessSignatureCredential(audience), audience);

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options);
            _clientDiagnostics = new ClientDiagnostics(options);

            _httpRequestAndResponse = new HttpRequestAndResponse(
                pipeline,
                _clientDiagnostics,
                tokenCredential,
                _fullyQualifiedNamespace,
                options.Version);
        }

        /// <summary>
        /// Initializes a new <see cref="ServiceBusAdministrationClient"/> which can be used to perform administration operations on ServiceBus entities.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        public ServiceBusAdministrationClient(
            string fullyQualifiedNamespace,
            TokenCredential credential)
            : this(fullyQualifiedNamespace, credential, new ServiceBusAdministrationClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ServiceBusAdministrationClient"/> which can be used to perform administration operations on ServiceBus entities.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="options">A set of options to apply when configuring the connection.</param>
        public ServiceBusAdministrationClient(
            string fullyQualifiedNamespace,
            TokenCredential credential,
            ServiceBusAdministrationClientOptions options)
        {
            Argument.AssertWellFormedServiceBusNamespace(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new ServiceBusAdministrationClientOptions();
            _fullyQualifiedNamespace = fullyQualifiedNamespace;

            var tokenCredential = new ServiceBusTokenCredential(credential, BuildAudienceResource(fullyQualifiedNamespace));

            var authenticationPolicy = new BearerTokenAuthenticationPolicy(credential, Constants.DefaultScope);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(
                options,
                 authenticationPolicy);
            _clientDiagnostics = new ClientDiagnostics(options);

            _httpRequestAndResponse = new HttpRequestAndResponse(
                pipeline,
                _clientDiagnostics,
                tokenCredential,
                _fullyQualifiedNamespace,
                options.Version);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.GetNamespaceProperties");
            scope.Start();

            try
            {
                Response response = await _httpRequestAndResponse.GetEntityAsync(
                    NamespacePath,
                    null,
                    false,
                    cancellationToken).ConfigureAwait(false);
                NamespaceProperties properties = await NamespacePropertiesExtensions.ParseResponseAsync(response, _clientDiagnostics).ConfigureAwait(false);

                return Response.FromValue(properties, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
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
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityNotFound">Queue with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response> DeleteQueueAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidQueueName(name);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.DeleteQueue");
            scope.Start();

            try
            {
                return await _httpRequestAndResponse.DeleteEntityAsync(name, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
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
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityNotFound">Topic with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response> DeleteTopicAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(name);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.DeleteTopic");
            scope.Start();

            try
            {
                return await _httpRequestAndResponse.DeleteEntityAsync(name, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
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
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityNotFound">Subscription with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response> DeleteSubscriptionAsync(
            string topicName,
            string subscriptionName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.DeleteSubscription");
            scope.Start();

            try
            {
                return await _httpRequestAndResponse.DeleteEntityAsync(EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
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
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityNotFound">Rule with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response> DeleteRuleAsync(
            string topicName,
            string subscriptionName,
            string ruleName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            EntityNameFormatter.CheckValidRuleName(ruleName);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.DeleteRule");
            scope.Start();

            try
            {
                return await _httpRequestAndResponse.DeleteEntityAsync(EntityNameFormatter.FormatRulePath(topicName, subscriptionName, ruleName), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
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
        /// <returns><see cref="QueueProperties"/> containing information about the queue.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of queue name is greater than 260.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityNotFound">Queue with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response<QueueProperties>> GetQueueAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidQueueName(name);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.GetQueue");
            scope.Start();

            try
            {
                Response response = await _httpRequestAndResponse.GetEntityAsync(name, null, false, cancellationToken).ConfigureAwait(false);
                QueueProperties properties = await QueuePropertiesExtensions.ParseResponseAsync(response, _clientDiagnostics).ConfigureAwait(false);
                return Response.FromValue(properties, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves a topic from the service namespace.
        /// </summary>
        ///
        /// <param name="name">The name of the topic relative to service bus namespace.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns><see cref="TopicProperties"/> containing information about the topic.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityNotFound">Topic with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response<TopicProperties>> GetTopicAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(name);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.GetTopic");
            scope.Start();

            try
            {
                Response response = await _httpRequestAndResponse.GetEntityAsync(name, null, false, cancellationToken).ConfigureAwait(false);
                TopicProperties properties = await TopicPropertiesExtensions.ParseResponseAsync(response, _clientDiagnostics).ConfigureAwait(false);

                return Response.FromValue(properties, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves a subscription from the service namespace.
        /// </summary>
        ///
        /// <param name="topicName">The name of the topic relative to service bus namespace.</param>
        /// <param name="subscriptionName">The subscription name.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns><see cref="SubscriptionProperties"/> containing information about the subscription.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicName"/>, <paramref name="subscriptionName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260 or length of subscription-name is greater than 50.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityNotFound">Topic or Subscription with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response<SubscriptionProperties>> GetSubscriptionAsync(
            string topicName,
            string subscriptionName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.GetSubscription");
            scope.Start();
            try
            {
                Response response = await _httpRequestAndResponse.GetEntityAsync(EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName), null, false, cancellationToken).ConfigureAwait(false);
                SubscriptionProperties properties = await SubscriptionPropertiesExtensions.ParseResponseAsync(topicName, response, _clientDiagnostics).ConfigureAwait(false);

                return Response.FromValue(properties, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
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
        /// <returns><see cref="RuleProperties"/> containing information about the rule.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicName"/>, <paramref name="subscriptionName"/> or <paramref name="ruleName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260 or length of subscription-name/rule-name is greater than 50.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityNotFound">Topic/Subscription/Rule with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response<RuleProperties>> GetRuleAsync(
            string topicName,
            string subscriptionName,
            string ruleName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            EntityNameFormatter.CheckValidRuleName(ruleName);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.GetRule");
            scope.Start();

            try
            {
                Response response = await _httpRequestAndResponse.GetEntityAsync(EntityNameFormatter.FormatRulePath(topicName, subscriptionName, ruleName), null, false, cancellationToken).ConfigureAwait(false);
                RuleProperties rule = await RuleDescriptionExtensions.ParseResponseAsync(response, _clientDiagnostics).ConfigureAwait(false);

                return Response.FromValue(rule, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion

        #region GetRuntimeProperties
        /// <summary>
        /// Retrieves the runtime properties of a queue.
        /// </summary>
        ///
        /// <param name="name">The name of the queue relative to service bus namespace.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns><see cref="QueueRuntimeProperties"/> containing runtime properties about the queue.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of queue name is greater than 260.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityNotFound">Queue with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response<QueueRuntimeProperties>> GetQueueRuntimePropertiesAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidQueueName(name);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.GetQueueRuntimeProperties");
            scope.Start();

            try
            {
                Response response = await _httpRequestAndResponse.GetEntityAsync(name, null, true, cancellationToken).ConfigureAwait(false);
                QueueRuntimeProperties runtimeProperties = await QueueRuntimePropertiesExtensions.ParseResponseAsync(response, _clientDiagnostics).ConfigureAwait(false);

                return Response.FromValue(runtimeProperties, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the runtime properties of a topic.
        /// </summary>
        /// <param name="name">The name of the topic relative to service bus namespace.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns><see cref="TopicRuntimeProperties"/> containing runtime properties about the topic.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityNotFound">Topic with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response<TopicRuntimeProperties>> GetTopicRuntimePropertiesAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(name);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.GetTopicRuntimeProperties");
            scope.Start();

            try
            {
                Response response = await _httpRequestAndResponse.GetEntityAsync(name, null, true, cancellationToken).ConfigureAwait(false);
                TopicRuntimeProperties runtimeProperties = await TopicRuntimePropertiesExtensions.ParseResponseAsync(response, _clientDiagnostics).ConfigureAwait(false);

                return Response.FromValue(runtimeProperties, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the runtime properties of a subscription.
        /// </summary>
        ///
        /// <param name="topicName">The name of the topic relative to service bus namespace.</param>
        /// <param name="subscriptionName">The subscription name.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns><see cref="SubscriptionRuntimeProperties"/> containing runtime properties about the subscription.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicName"/>, <paramref name="subscriptionName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260 or length of subscription-name is greater than 50.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityNotFound">Topic or Subscription with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<Response<SubscriptionRuntimeProperties>> GetSubscriptionRuntimePropertiesAsync(
            string topicName,
            string subscriptionName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.GetSubscriptionRuntimeProperties");
            scope.Start();

            try
            {
                Response response = await _httpRequestAndResponse.GetEntityAsync(EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName), null, true, cancellationToken).ConfigureAwait(false);
                SubscriptionRuntimeProperties runtimeProperties = await SubscriptionRuntimePropertiesExtensions.ParseResponseAsync(topicName, response, _clientDiagnostics).ConfigureAwait(false);

                return Response.FromValue(runtimeProperties, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
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
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual AsyncPageable<QueueProperties> GetQueuesAsync(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(nextSkip =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.GetQueues");
                scope.Start();

                try
                {
                    return _httpRequestAndResponse.GetEntitiesPageAsync<QueueProperties>(
                        QueuesPath,
                        nextSkip,
                        async response => await QueuePropertiesExtensions.ParsePagedResponseAsync(response, _clientDiagnostics).ConfigureAwait(false),
                        cancellationToken);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary>
        /// Retrieves the list of topics present in the namespace.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="AsyncPageable{T}"/> describing the topics.</returns>
        /// <remarks>Maximum value allowed is 100 per page.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual AsyncPageable<TopicProperties> GetTopicsAsync(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(nextSkip =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.GetTopics");
                scope.Start();
                try
                {
                    return _httpRequestAndResponse.GetEntitiesPageAsync<TopicProperties>(
                        TopicsPath,
                        nextSkip,
                        async response => await TopicPropertiesExtensions.ParsePagedResponseAsync(response, _clientDiagnostics).ConfigureAwait(false),
                        cancellationToken);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

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
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual AsyncPageable<SubscriptionProperties> GetSubscriptionsAsync(
            string topicName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextSkip =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.GetSubscriptions");
                scope.Start();
                try
                {
                    return _httpRequestAndResponse.GetEntitiesPageAsync<SubscriptionProperties>(
                        string.Format(CultureInfo.CurrentCulture, SubscriptionsPath, topicName),
                        nextSkip,
                        async response => await SubscriptionPropertiesExtensions.ParsePagedResponseAsync(topicName, response, _clientDiagnostics).ConfigureAwait(false),
                        cancellationToken);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
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
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual AsyncPageable<RuleProperties> GetRulesAsync(
            string topicName,
            string subscriptionName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            return PageResponseEnumerator.CreateAsyncEnumerable(nextSkip =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.GetRules");
                scope.Start();
                try
                {
                    return _httpRequestAndResponse.GetEntitiesPageAsync<RuleProperties>(
                    string.Format(CultureInfo.CurrentCulture, RulesPath, topicName, subscriptionName),
                    nextSkip,
                    async response => await RuleDescriptionExtensions.ParsePagedResponseAsync(response, _clientDiagnostics).ConfigureAwait(false),
                    cancellationToken);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        #endregion

        #region GetEntitiesRuntimeProperties
        /// <summary>
        /// Retrieves the list of runtime properties for queues present in the namespace.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="AsyncPageable{T}"/> describing the queues runtime properties.</returns>
        /// <remarks>Maximum value allowed is 100 per page.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual AsyncPageable<QueueRuntimeProperties> GetQueuesRuntimePropertiesAsync(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(nextSkip =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.GetQueuesRuntimeProperties");
                scope.Start();
                try
                {
                    return _httpRequestAndResponse.GetEntitiesPageAsync<QueueRuntimeProperties>(
                            QueuesPath,
                            nextSkip,
                            async response => await QueueRuntimePropertiesExtensions.ParsePagedResponseAsync(response, _clientDiagnostics).ConfigureAwait(false),
                            cancellationToken);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary>
        /// Retrieves the list of runtime properties for topics present in the namespace.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="AsyncPageable{T}"/> describing the topics runtime properties.</returns>
        /// <remarks>Maximum value allowed is 100 per page.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual AsyncPageable<TopicRuntimeProperties> GetTopicsRuntimePropertiesAsync(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(nextSkip =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.GetTopicsRuntimeProperties");
                scope.Start();
                try
                {
                    return _httpRequestAndResponse.GetEntitiesPageAsync<TopicRuntimeProperties>(
                        TopicsPath,
                        nextSkip,
                        async response => await TopicRuntimePropertiesExtensions.ParsePagedResponseAsync(response, _clientDiagnostics).ConfigureAwait(false),
                        cancellationToken);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary>
        /// Retrieves the list of runtime properties for subscriptions present in the namespace.
        /// </summary>
        ///
        /// <param name="topicName">The name of the topic relative to service bus namespace.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        ///  <returns>An <see cref="AsyncPageable{T}"/> describing the subscriptions runtime properties.</returns>
        /// <remarks>Maximum value allowed is 100 per page.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual AsyncPageable<SubscriptionRuntimeProperties> GetSubscriptionsRuntimePropertiesAsync(
            string topicName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            return PageResponseEnumerator.CreateAsyncEnumerable(nextSkip =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.GetSubscriptionsRuntimeProperties");
                scope.Start();
                try
                {
                    return _httpRequestAndResponse.GetEntitiesPageAsync<SubscriptionRuntimeProperties>(
                    string.Format(CultureInfo.CurrentCulture, SubscriptionsPath, topicName),
                    nextSkip,
                    async response => await SubscriptionRuntimePropertiesExtensions.ParsePagedResponseAsync(topicName, response, _clientDiagnostics).ConfigureAwait(false),
                    cancellationToken);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
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
        /// <remarks>Throws if a queue already exists. <see cref="QueueProperties"/> for default values of queue properties.</remarks>
        /// <returns>The <see cref="QueueProperties"/> of the newly created queue.</returns>
        /// <exception cref="ArgumentNullException">Queue name is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="name"/> is greater than 260 characters.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityAlreadyExists">An entity with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<QueueProperties>> CreateQueueAsync(
            string name,
            CancellationToken cancellationToken = default) =>
            await CreateQueueAsync(
                new CreateQueueOptions(name),
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a new queue in the service namespace with the given name.
        /// </summary>
        /// <param name="options">A <see cref="CreateQueueOptions"/> object describing the attributes with which the new queue will be created.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Throws if a queue already exists.</remarks>
        /// <returns>The <see cref="QueueProperties"/> of the newly created queue.</returns>
        /// <exception cref="ArgumentNullException">Queue name is null or empty.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityAlreadyExists">An entity with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<QueueProperties>> CreateQueueAsync(
            CreateQueueOptions options,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.CreateQueue");
            scope.Start();
            try
            {
                var queue = new QueueProperties(options);
                queue.NormalizeDescription(_fullyQualifiedNamespace);
                var atomRequest = queue.Serialize().ToString();
                Response response = await _httpRequestAndResponse.PutEntityAsync(
                    queue.Name,
                    atomRequest,
                    false,
                    queue.ForwardTo,
                    queue.ForwardDeadLetteredMessagesTo,
                    cancellationToken).ConfigureAwait(false);

                QueueProperties description = await QueuePropertiesExtensions.ParseResponseAsync(response, _clientDiagnostics).ConfigureAwait(false);
                return Response.FromValue(description, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new topic in the service namespace with the given name.
        /// </summary>
        ///
        /// <param name="name">The name of the topic relative to the service namespace base address.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Throws if a topic already exists. <see cref="TopicProperties"/> for default values of topic properties.</remarks>
        /// <returns>The <see cref="TopicProperties"/> of the newly created topic.</returns>
        /// <exception cref="ArgumentNullException">Topic name is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="name"/> is greater than 260 characters.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityAlreadyExists">A topic with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<TopicProperties>> CreateTopicAsync(
            string name,
            CancellationToken cancellationToken = default) =>
            await CreateTopicAsync(
                new CreateTopicOptions(name),
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a new topic in the service namespace with the given name.
        /// </summary>
        ///
        /// <param name="options">A <see cref="TopicProperties"/> object describing the attributes with which the new topic will be created.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Throws if a topic already exists. <see cref="TopicProperties"/> for default values of topic properties.</remarks>
        /// <returns>The <see cref="TopicProperties"/> of the newly created topic.</returns>
        /// <exception cref="ArgumentNullException">Topic description is null.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityAlreadyExists">A topic with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<TopicProperties>> CreateTopicAsync(
            CreateTopicOptions options,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.CreateTopic");
            scope.Start();

            try
            {
                var topic = new TopicProperties(options);
                var atomRequest = topic.Serialize().ToString();

                Response response = await _httpRequestAndResponse.PutEntityAsync(
                    topic.Name,
                    atomRequest,
                    false,
                    null,
                    null,
                    cancellationToken).ConfigureAwait(false);
                TopicProperties description = await TopicPropertiesExtensions.ParseResponseAsync(response, _clientDiagnostics).ConfigureAwait(false);

                return Response.FromValue(description, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new subscription within a topic in the service namespace with the given name.
        /// </summary>
        ///
        /// <param name="topicName">The name of the topic relative to the service namespace base address.</param>
        /// <param name="subscriptionName">The name of the subscription.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Throws if a subscription already exists. <see cref="SubscriptionProperties"/> for default values of subscription description.
        /// By default, A "pass-through" filter is created for this subscription, which means it will allow all messages to go to this subscription. The name of the filter is represented by <see cref="RuleProperties.DefaultRuleName"/>.
        /// <see cref="CreateSubscriptionAsync(CreateSubscriptionOptions, CreateRuleOptions, CancellationToken)"/> for creating subscription with a different filter.</remarks>
        /// <returns>The <see cref="SubscriptionProperties"/> of the newly created subscription.</returns>
        /// <exception cref="ArgumentNullException">Topic name or subscription name is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="topicName"/> is greater than 260 characters or <paramref name="subscriptionName"/> is greater than 50 characters.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityAlreadyExists">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<SubscriptionProperties>> CreateSubscriptionAsync(
            string topicName,
            string subscriptionName,
            CancellationToken cancellationToken = default) =>
            await CreateSubscriptionAsync(
                new CreateSubscriptionOptions(topicName, subscriptionName),
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a new subscription within a topic in the service namespace with the given name.
        /// </summary>
        ///
        /// <param name="options">A <see cref="SubscriptionProperties"/> object describing the attributes with which the new subscription will be created.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Throws if a subscription already exists.
        /// Be default, A "pass-through" filter is created for this subscription, which means it will allow all messages to go to this subscription. The name of the filter is represented by <see cref="RuleProperties.DefaultRuleName"/>.
        /// <see cref="CreateSubscriptionAsync(CreateSubscriptionOptions, CreateRuleOptions, CancellationToken)"/> for creating subscription with a different filter.</remarks>
        /// <returns>The <see cref="SubscriptionProperties"/> of the newly created subscription.</returns>
        /// <exception cref="ArgumentNullException">Subscription description is null.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityAlreadyExists">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual Task<Response<SubscriptionProperties>> CreateSubscriptionAsync(
            CreateSubscriptionOptions options,
            CancellationToken cancellationToken = default)
        {
            options = options ?? throw new ArgumentNullException(nameof(options));
            return CreateSubscriptionAsync(options, new CreateRuleOptions(), cancellationToken);
        }

        /// <summary>
        /// Creates a new subscription within a topic with the provided default rule.
        /// </summary>
        ///
        /// <param name="options">A <see cref="SubscriptionProperties"/> object describing the attributes with which the new subscription will be created.</param>
        /// <param name="rule"> A <see cref="RuleProperties"/> object describing the default rule. If null, then pass-through filter with name <see cref="RuleProperties.DefaultRuleName"/> will be created.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Throws if a subscription already exists. </remarks>
        /// <returns>The <see cref="SubscriptionProperties"/> of the newly created subscription.</returns>
        /// <exception cref="ArgumentNullException">Subscription description is null.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityAlreadyExists">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<SubscriptionProperties>> CreateSubscriptionAsync(
            CreateSubscriptionOptions options,
            CreateRuleOptions rule,
            CancellationToken cancellationToken = default)
        {
            options = options ?? throw new ArgumentNullException(nameof(options));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.CreateSubscription");
            scope.Start();

            try
            {
                var subscription = new SubscriptionProperties(options);
                subscription.NormalizeDescription(_fullyQualifiedNamespace);
                subscription.Rule = new RuleProperties(rule);
                var atomRequest = subscription.Serialize().ToString();

                Response response = await _httpRequestAndResponse.PutEntityAsync(
                    EntityNameFormatter.FormatSubscriptionPath(subscription.TopicName, subscription.SubscriptionName),
                    atomRequest,
                    false,
                    subscription.ForwardTo,
                    subscription.ForwardDeadLetteredMessagesTo,
                    cancellationToken).ConfigureAwait(false);
                SubscriptionProperties description = await SubscriptionPropertiesExtensions.ParseResponseAsync(subscription.TopicName, response, _clientDiagnostics).ConfigureAwait(false);

                return Response.FromValue(description, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Adds a new rule to the subscription under given topic.
        /// </summary>
        ///
        /// <param name="topicName">The topic name relative to the service namespace base address.</param>
        /// <param name="subscriptionName">The name of the subscription.</param>
        /// <param name="options">A <see cref="CreateRuleOptions"/> object describing the attributes with which the messages are matched and acted upon.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <exception cref="ArgumentNullException">Subscription or rule description is null.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityAlreadyExists">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        /// <returns><see cref="RuleProperties"/> of the recently created rule.</returns>
        public virtual async Task<Response<RuleProperties>> CreateRuleAsync(
            string topicName,
            string subscriptionName,
            CreateRuleOptions options,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            options = options ?? throw new ArgumentNullException(nameof(options));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.CreateRule");
            scope.Start();

            try
            {
                var rule = new RuleProperties(options);
                var atomRequest = rule.Serialize().ToString();

                Response response = await _httpRequestAndResponse.PutEntityAsync(
                    EntityNameFormatter.FormatRulePath(topicName, subscriptionName, rule.Name),
                    atomRequest,
                    false,
                    null,
                    null,
                    cancellationToken).ConfigureAwait(false);
                RuleProperties description = await RuleDescriptionExtensions.ParseResponseAsync(response, _clientDiagnostics).ConfigureAwait(false);

                return Response.FromValue(description, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion CreateEntity

        #region UpdateEntity
        /// <summary>
        /// Updates an existing queue.
        /// </summary>
        ///
        /// <param name="queue">A <see cref="QueueProperties"/> object describing the attributes with which the queue will be updated.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The <see cref="QueueProperties"/> of the updated queue.</returns>
        /// <exception cref="ArgumentNullException">Queue descriptor is null.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityNotFound">Described queue was not found.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<QueueProperties>> UpdateQueueAsync(
            QueueProperties queue,
            CancellationToken cancellationToken = default)
        {
            queue = queue ?? throw new ArgumentNullException(nameof(queue));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.UpdateQueue");
            scope.Start();

            try
            {
                queue.NormalizeDescription(_fullyQualifiedNamespace);
                var atomRequest = queue.Serialize().ToString();

                Response response = await _httpRequestAndResponse.PutEntityAsync(
                    queue.Name,
                    atomRequest,
                    true,
                    queue.ForwardTo,
                    queue.ForwardDeadLetteredMessagesTo,
                    cancellationToken).ConfigureAwait(false);
                QueueProperties description = await QueuePropertiesExtensions.ParseResponseAsync(response, _clientDiagnostics).ConfigureAwait(false);

                return Response.FromValue(description, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing topic.
        /// </summary>
        ///
        /// <param name="topic">A <see cref="TopicProperties"/> object describing the attributes with which the topic will be updated.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The <see cref="TopicProperties"/> of the updated topic.</returns>
        /// <exception cref="ArgumentNullException">Topic descriptor is null.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityNotFound">Described topic was not found.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<TopicProperties>> UpdateTopicAsync(
            TopicProperties topic,
            CancellationToken cancellationToken = default)
        {
            topic = topic ?? throw new ArgumentNullException(nameof(topic));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.UpdateTopic");
            scope.Start();

            try
            {
                var atomRequest = topic.Serialize().ToString();

                Response response = await _httpRequestAndResponse.PutEntityAsync(
                    topic.Name,
                    atomRequest,
                    true,
                    forwardTo: null,
                    fwdDeadLetterTo: null,
                    cancellationToken).ConfigureAwait(false);
                TopicProperties description = await TopicPropertiesExtensions.ParseResponseAsync(response, _clientDiagnostics).ConfigureAwait(false);

                return Response.FromValue(description, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing subscription under a topic.
        /// </summary>
        ///
        /// <param name="subscription">A <see cref="SubscriptionProperties"/> object describing the attributes with which the subscription will be updated.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The <see cref="SubscriptionProperties"/> of the updated subscription.</returns>
        /// <exception cref="ArgumentNullException">subscription descriptor is null.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityNotFound">Described subscription was not found.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<SubscriptionProperties>> UpdateSubscriptionAsync(
            SubscriptionProperties subscription,
            CancellationToken cancellationToken = default)
        {
            subscription = subscription ?? throw new ArgumentNullException(nameof(subscription));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.UpdateSubscription");
            scope.Start();

            try
            {
                subscription.NormalizeDescription(_fullyQualifiedNamespace);
                var atomRequest = subscription.Serialize().ToString();

                Response response = await _httpRequestAndResponse.PutEntityAsync(
                    EntityNameFormatter.FormatSubscriptionPath(subscription.TopicName, subscription.SubscriptionName),
                    atomRequest,
                    true,
                    subscription.ForwardTo,
                    subscription.ForwardDeadLetteredMessagesTo,
                    cancellationToken).ConfigureAwait(false);
                SubscriptionProperties description = await SubscriptionPropertiesExtensions.ParseResponseAsync(subscription.TopicName, response, _clientDiagnostics).ConfigureAwait(false);

                return Response.FromValue(description, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing rule for a topic-subscription.
        /// </summary>
        ///
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription.</param>
        /// <param name="rule">A <see cref="RuleProperties"/> object describing the attributes with which the rule will be updated.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The <see cref="RuleProperties"/> of the updated rule.</returns>
        /// <exception cref="ArgumentNullException">rule descriptor is null.</exception>
        /// <exception cref="ServiceBusFailureReason.MessagingEntityNotFound">Described topic/subscription/rule was not found.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<RuleProperties>> UpdateRuleAsync(
            string topicName,
            string subscriptionName,
            RuleProperties rule,
            CancellationToken cancellationToken = default)
        {
            rule = rule ?? throw new ArgumentNullException(nameof(rule));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.UpdateRule");
            scope.Start();

            try
            {
                EntityNameFormatter.CheckValidTopicName(topicName);
                EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);

                var atomRequest = rule.Serialize().ToString();
                Response response = await _httpRequestAndResponse.PutEntityAsync(
                    EntityNameFormatter.FormatRulePath(topicName, subscriptionName, rule.Name),
                    atomRequest,
                    true,
                    null,
                    null,
                    cancellationToken).ConfigureAwait(false);
                RuleProperties description = await RuleDescriptionExtensions.ParseResponseAsync(response, _clientDiagnostics).ConfigureAwait(false);

                return Response.FromValue(description, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
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
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<bool>> QueueExistsAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidQueueName(name);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.QueueExists");
            scope.Start();
            try
            {
                Response response = null;
                try
                {
                    response = await _httpRequestAndResponse.GetEntityAsync(name, null, false, cancellationToken).ConfigureAwait(false);
                    QueueProperties description = await QueuePropertiesExtensions.ParseResponseAsync(response, _clientDiagnostics).ConfigureAwait(false);
                }
                catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityNotFound)
                {
                    return Response.FromValue(false, response);
                }

                return Response.FromValue(true, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
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
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<bool>> TopicExistsAsync(
            string name,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(name);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.TopicExists");
            scope.Start();

            try
            {
                Response response = null;

                try
                {
                    response = await _httpRequestAndResponse.GetEntityAsync(name, null, false, cancellationToken).ConfigureAwait(false);
                    TopicProperties description = await TopicPropertiesExtensions.ParseResponseAsync(response, _clientDiagnostics).ConfigureAwait(false);
                }
                catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityNotFound)
                {
                    return Response.FromValue(false, response);
                }

                return Response.FromValue(true, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
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
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<bool>> SubscriptionExistsAsync(
            string topicName,
            string subscriptionName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.SubscriptionExists");
            scope.Start();

            try
            {
                Response response = null;

                try
                {
                    response = await _httpRequestAndResponse.GetEntityAsync(EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName), null, false, cancellationToken).ConfigureAwait(false);
                    SubscriptionProperties description = await SubscriptionPropertiesExtensions.ParseResponseAsync(topicName, response, _clientDiagnostics).ConfigureAwait(false);
                }
                catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityNotFound)
                {
                    return Response.FromValue(false, response);
                }

                return Response.FromValue(true, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
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
        /// <exception cref="ServiceBusFailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ServiceBusAdministrationClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusFailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<Response<bool>> RuleExistsAsync(
            string topicName,
            string subscriptionName,
            string ruleName,
            CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServiceBusAdministrationClient)}.RuleExists");
            scope.Start();

            try
            {
                Response response = null;

                try
                {
                    response = await _httpRequestAndResponse.GetEntityAsync(EntityNameFormatter.FormatRulePath(topicName, subscriptionName, ruleName), null, false, cancellationToken).ConfigureAwait(false);
                    RuleProperties description = await RuleDescriptionExtensions.ParseResponseAsync(response, _clientDiagnostics).ConfigureAwait(false);
                }
                catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.MessagingEntityNotFound)
                {
                    return Response.FromValue(false, response);
                }

                return Response.FromValue(true, response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion

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
