// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Primitives;
using Azure.Messaging.ServiceBus.Filters;

namespace Azure.Messaging.ServiceBus.Management
{
    /// <summary>
    ///
    /// </summary>
    public class ManagementClient
    {
        private HttpPipeline _pipeline;
        private string _fullyQualifiedNamespace;
        private readonly TokenCredential _tokenCredential;
        private readonly int _port;
        private readonly string _clientId;

        /// <summary>
        /// Parameterless constructor to allow mocking.
        /// </summary>
        protected ManagementClient() { }

        /// <summary>
        /// Initializes a new <see cref="ManagementClient"/> which can be used to perform management opertions on ServiceBus entities.
        /// </summary>
        /// <param name="connectionString">Namespace connection string.</param>
        public ManagementClient(string connectionString)
            : this(connectionString, new ManagementClientOptions())
        {
        }
        /// <summary>
        /// Initializes a new <see cref="ManagementClient"/> which can be used to perform management opertions on ServiceBus entities.
        /// </summary>
        /// <param name="connectionString">Namespace connection string.</param>
        /// <param name="options"></param>
        public ManagementClient(
            string connectionString,
            ManagementClientOptions options)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));

            options = options?.Clone() ?? new ManagementClientOptions();

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
            _tokenCredential = new ServiceBusTokenCredential(
                sharedCredential,
                BuildAudienceResource(connectionStringProperties.Endpoint.Host));

            _pipeline = HttpPipelineBuilder.Build(new ManagementClientOptions());
            _port = GetPort(_fullyQualifiedNamespace);
            _clientId = nameof(ManagementClient) + Guid.NewGuid().ToString("N").Substring(0, 6);
        }

        /// <summary>
        /// Initializes a new <see cref="ManagementClient"/> which can be used to perform management opertions on ServiceBus entities.
        /// </summary>
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        public ManagementClient(
            string fullyQualifiedNamespace,
            TokenCredential credential)
            : this(fullyQualifiedNamespace, credential, new ManagementClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new <see cref="ManagementClient"/> which can be used to perform management opertions on ServiceBus entities.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="options">A set of options to apply when configuring the connection.</param>
        public ManagementClient(
            string fullyQualifiedNamespace,
            TokenCredential credential,
            ManagementClientOptions options)
        {
            Argument.AssertWellFormedServiceBusNamespace(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNull(credential, nameof(credential));

            options = options?.Clone() ?? new ManagementClientOptions();
            switch (credential)
            {
                case SharedAccessSignatureCredential _:
                    break;

                case ServiceBusSharedKeyCredential sharedKeyCredential:
                    credential = sharedKeyCredential.AsSharedAccessSignatureCredential(BuildAudienceResource(fullyQualifiedNamespace));
                    break;
            }

            Argument.AssertWellFormedServiceBusNamespace(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNull(credential, nameof(credential));

            options = options?.Clone() ?? new ManagementClientOptions();
            switch (credential)
            {
                case SharedAccessSignatureCredential _:
                    break;

                case ServiceBusSharedKeyCredential sharedKeyCredential:
                    credential = sharedKeyCredential.AsSharedAccessSignatureCredential(BuildAudienceResource(fullyQualifiedNamespace));
                    break;
            }
            _tokenCredential = new ServiceBusTokenCredential(credential, BuildAudienceResource(fullyQualifiedNamespace));

            _fullyQualifiedNamespace = fullyQualifiedNamespace;
            _pipeline = HttpPipelineBuilder.Build(new ManagementClientOptions());
            _port = GetPort(_fullyQualifiedNamespace);
            _clientId = nameof(ManagementClient) + Guid.NewGuid().ToString("N").Substring(0, 6);
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
        /// Deletes the queue described by the name relative to the service namespace base address.
        /// </summary>
        /// <param name="queueName">The name of the queue relative to the service namespace base address.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentException"><paramref name="queueName"/> is empty or null, or name starts or ends with "/".</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of name is greater than 260.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Queue with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual Task<Response> DeleteQueueAsync(string queueName, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidQueueName(queueName);
            return DeleteEntity(queueName, cancellationToken);
        }

        /// <summary>
        /// Deletes the topic described by the name relative to the service namespace base address.
        /// </summary>
        /// <param name="topicName">The name of the topic relative to the service namespace base address.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentException"><paramref name="topicName"/> is empty or null, or name starts or ends with "/".</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Topic with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual Task<Response> DeleteTopicAsync(string topicName, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            return DeleteEntity(topicName, cancellationToken);
        }

        /// <summary>
        /// Deletes the subscription with the specified topic and subscription name.
        /// </summary>
        /// <param name="topicName">The name of the topic relative to the service namespace base address.</param>
        /// <param name="subscriptionName">The name of the subscription to delete.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentException"><paramref name="topicName"/> or <paramref name="subscriptionName"/> is empty or null, or path starts or ends with "/".</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260 or length of subscription name is greater than 50.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Subscription with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual Task<Response> DeleteSubscriptionAsync(string topicName, string subscriptionName, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);

            return DeleteEntity(EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName), cancellationToken);
        }

        /// <summary>
        /// Deletes the rule described by <paramref name="ruleName"/> from <paramref name="subscriptionName"/> under <paramref name="topicName"/>./>
        /// </summary>
        /// <param name="topicName">The name of the topic relative to the service namespace base address.</param>
        /// <param name="subscriptionName">The name of the subscription to delete.</param>
        /// <param name="ruleName">The name of the rule to delete.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicName"/>, <paramref name="subscriptionName"/>, or <paramref name="ruleName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260 or length of subscription-name/rule-name is greater than 50.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Rule with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual Task<Response> DeleteRuleAsync(string topicName, string subscriptionName, string ruleName, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            EntityNameFormatter.CheckValidRuleName(ruleName);

            return DeleteEntity(EntityNameFormatter.FormatRulePath(topicName, subscriptionName, ruleName), cancellationToken);
        }

        #endregion

        #region GetEntity

        /// <summary>
        /// Retrieves a queue from the service namespace.
        /// </summary>
        /// <param name="queueName">The name of the queue relative to service bus namespace.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="QueueDescription"/> containing information about the queue.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="queueName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of queue name is greater than 260.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Queue with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<QueueDescription> GetQueueAsync(string queueName, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidQueueName(queueName);

            var content = await GetEntity(queueName, null, false, cancellationToken).ConfigureAwait(false);

            return QueueDescriptionExtensions.ParseFromContent(content);
        }

        /// <summary>
        /// Retrieves a topic from the service namespace.
        /// </summary>
        /// <param name="topicName">The name of the topic relative to service bus namespace.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="TopicDescription"/> containing information about the topic.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Topic with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<TopicDescription> GetTopicAsync(string topicName, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);

            var content = await GetEntity(topicName, null, false, cancellationToken).ConfigureAwait(false);

            return TopicDescriptionExtensions.ParseFromContent(content);
        }

        /// <summary>
        /// Retrieves a subscription from the service namespace.
        /// </summary>
        /// <param name="topicName">The name of the topic relative to service bus namespace.</param>
        /// <param name="subscriptionName">The subscription name.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="SubscriptionDescription"/> containing information about the subscription.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicName"/>, <paramref name="subscriptionName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260 or length of subscription-name is greater than 50.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Topic or Subscription with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<SubscriptionDescription> GetSubscriptionAsync(string topicName, string subscriptionName, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);

            var content = await GetEntity(EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName), null, false, cancellationToken).ConfigureAwait(false);

            return SubscriptionDescriptionExtensions.ParseFromContent(topicName, content);
        }

        /// <summary>
        /// Retrieves a rule from the service namespace.
        /// </summary>
        /// <param name="topicName">The name of the topic relative to service bus namespace.</param>
        /// <param name="subscriptionName">The subscription name the rule belongs to.</param>
        /// <param name="ruleName">The name of the rule to retrieve.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="RuleDescription"/> containing information about the rule.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicName"/>, <paramref name="subscriptionName"/> or <paramref name="ruleName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260 or length of subscription-name/rule-name is greater than 50.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Topic/Subscription/Rule with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        /// <remarks>Note - Only following data types are deserialized in Filters and Action parameters - string,int,long,bool,double,DateTime.
        /// Other data types would return its string value.</remarks>
        public virtual async Task<RuleDescription> GetRuleAsync(string topicName, string subscriptionName, string ruleName, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            EntityNameFormatter.CheckValidRuleName(ruleName);

            var content = await GetEntity(EntityNameFormatter.FormatRulePath(topicName, subscriptionName, ruleName), null, false, cancellationToken).ConfigureAwait(false);

            return RuleDescriptionExtensions.ParseFromContent(content);
        }

        #endregion

        #region GetRuntimeInfo
        /// <summary>
        /// Retrieves the runtime information of a queue.
        /// </summary>
        /// <param name="queueName">The name of the queue relative to service bus namespace.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="QueueRuntimeInfo"/> containing runtime information about the queue.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="queueName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of queue name is greater than 260.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Queue with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<QueueRuntimeInfo> GetQueueRuntimeInfoAsync(string queueName, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidQueueName(queueName);

            var content = await GetEntity(queueName, null, true, cancellationToken).ConfigureAwait(false);

            return QueueRuntimeInfoExtensions.ParseFromContent(content);
        }

        /// <summary>
        /// Retrieves the runtime information of a topic.
        /// </summary>
        /// <param name="topicName">The name of the topic relative to service bus namespace.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="TopicRuntimeInfo"/> containing runtime information about the topic.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Topic with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<TopicRuntimeInfo> GetTopicRuntimeInfoAsync(string topicName, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);

            var content = await GetEntity(topicName, null, true, cancellationToken).ConfigureAwait(false);

            return TopicRuntimeInfoExtensions.ParseFromContent(content);
        }

        /// <summary>
        /// Retrieves the runtime information of a subscription.
        /// </summary>
        /// <param name="topicName">The name of the topic relative to service bus namespace.</param>
        /// <param name="subscriptionName">The subscription name.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="SubscriptionRuntimeInfo"/> containing runtime information about the subscription.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="topicName"/>, <paramref name="subscriptionName"/> is null, white space empty or not in the right format.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of topic name is greater than 260 or length of subscription-name is greater than 50.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Topic or Subscription with this name does not exist.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        public virtual async Task<SubscriptionRuntimeInfo> GetSubscriptionRuntimeInfoAsync(string topicName, string subscriptionName, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);

            var content = await GetEntity(EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName), null, true, cancellationToken).ConfigureAwait(false);

            return SubscriptionRuntimeInfoExtensions.ParseFromContent(topicName, content);
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
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
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
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
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
        /// <param name="topicName">The topic name under which all the subscriptions need to be retrieved.</param>
        /// <param name="count">The number of subscriptions to fetch. Defaults to 100. Maximum value allowed is 100.</param>
        /// <param name="skip">The number of subscriptions to skip. Defaults to 0. Cannot be negative.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="IList&lt;SubscriptionDescription&gt;"/> containing list of subscriptions.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        /// <remarks>You can simulate pages of list of entities by manipulating <paramref name="count"/> and <paramref name="skip"/>.
        /// skip(0)+count(100) gives first 100 entities. skip(100)+count(100) gives the next 100 entities.</remarks>
        public virtual async Task<IList<SubscriptionDescription>> GetSubscriptionsAsync(string topicName, int count = 100, int skip = 0, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            if (count > 100 || count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Value should be between 1 and 100");
            }
            if (skip < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skip), "Value cannot be negative");
            }

            var content = await GetEntity($"{topicName}/Subscriptions", $"$skip={skip}&$top={count}", false, cancellationToken).ConfigureAwait(false);
            return SubscriptionDescriptionExtensions.ParseCollectionFromContent(topicName, content);
        }

        /// <summary>
        /// Retrieves the list of rules for a given subscription in a topic.
        /// </summary>
        /// <param name="topicName">The topic name.</param>
        /// <param name="subscriptionName"> The subscription for which all the rules need to be retrieved.</param>
        /// <param name="count">The number of rules to fetch. Defaults to 100. Maximum value allowed is 100.</param>
        /// <param name="skip">The number of rules to skip. Defaults to 0. Cannot be negative.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="IList&lt;RuleDescription&gt;"/> containing list of rules.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        /// <remarks>You can simulate pages of list of entities by manipulating <paramref name="count"/> and <paramref name="skip"/>.
        /// skip(0)+count(100) gives first 100 entities. skip(100)+count(100) gives the next 100 entities.
        /// Note - Only following data types are deserialized in Filters and Action parameters - string,int,long,bool,double,DateTime.
        /// Other data types would return its string value.</remarks>
        public virtual async Task<IList<RuleDescription>> GetRulesAsync(string topicName, string subscriptionName, int count = 100, int skip = 0, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            if (count > 100 || count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Value should be between 1 and 100");
            }
            if (skip < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skip), "Value cannot be negative");
            }

            var content = await GetEntity($"{topicName}/Subscriptions/{subscriptionName}/rules", $"$skip={skip}&$top={count}", false, cancellationToken).ConfigureAwait(false);
            return RuleDescriptionExtensions.ParseCollectionFromContent(content);
        }

        #endregion

        #region GetEntitesRuntimeInfo
        /// <summary>
        /// Retrieves the list of runtime information for queues present in the namespace.
        /// </summary>
        /// <param name="count">The number of queues to fetch. Defaults to 100. Maximum value allowed is 100.</param>
        /// <param name="skip">The number of queues to skip. Defaults to 0. Cannot be negative.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="IList&lt;QueueRuntimeInfo&gt;"/> containing list of queue runtime information.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        /// <remarks>You can simulate pages of list of entities by manipulating <paramref name="count"/> and <paramref name="skip"/>.
        /// skip(0)+count(100) gives first 100 entities. skip(100)+count(100) gives the next 100 entities.</remarks>
        public virtual async Task<IList<QueueRuntimeInfo>> GetQueuesRuntimeInfoAsync(int count = 100, int skip = 0, CancellationToken cancellationToken = default)
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
            return QueueRuntimeInfoExtensions.ParseCollectionFromContent(content);
        }

        /// <summary>
        /// Retrieves the list of runtime information for topics present in the namespace.
        /// </summary>
        /// <param name="count">The number of topics to fetch. Defaults to 100. Maximum value allowed is 100.</param>
        /// <param name="skip">The number of topics to skip. Defaults to 0. Cannot be negative.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="IList&lt;TopicRuntimeInfo&gt;"/> containing list of topics.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        /// <remarks>You can simulate pages of list of entities by manipulating <paramref name="count"/> and <paramref name="skip"/>.
        /// skip(0)+count(100) gives first 100 entities. skip(100)+count(100) gives the next 100 entities.</remarks>
        public virtual async Task<IList<TopicRuntimeInfo>> GetTopicsRuntimeInfoAsync(int count = 100, int skip = 0, CancellationToken cancellationToken = default)
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

            return TopicRuntimeInfoExtensions.ParseCollectionFromContent(content);
        }

        /// <summary>
        /// Retrieves the list of runtime information for subscriptions present in the namespace.
        /// </summary>
        /// <param name="topicName">The name of the topic relative to service bus namespace.</param>
        /// <param name="count">The number of subscriptions to fetch. Defaults to 100. Maximum value allowed is 100.</param>
        /// <param name="skip">The number of subscriptions to skip. Defaults to 0. Cannot be negative.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="IList&lt;SubscriptionRuntimeInfo&gt;"/> containing list of topics.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the parameters are out of range.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or an unexpected exception occured.</exception>
        /// <remarks>You can simulate pages of list of entities by manipulating <paramref name="count"/> and <paramref name="skip"/>.
        /// skip(0)+count(100) gives first 100 entities. skip(100)+count(100) gives the next 100 entities.</remarks>
        public virtual async Task<IList<SubscriptionRuntimeInfo>> GetSubscriptionsRuntimeInfoAsync(string topicName, int count = 100, int skip = 0, CancellationToken cancellationToken = default)
        {
            if (count > 100 || count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Value should be between 1 and 100");
            }
            if (skip < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skip), "Value cannot be negative");
            }

            var content = await GetEntity($"{topicName}/Subscriptions", $"$skip={skip}&$top={count}", false, cancellationToken).ConfigureAwait(false);

            return SubscriptionRuntimeInfoExtensions.ParseCollectionFromContent(topicName, content);
        }

        #endregion

        #region CreateEntity

        /// <summary>
        /// Creates a new queue in the service namespace with the given name.
        /// </summary>
        /// <remarks>Throws if a queue already exists. <see cref="QueueDescription"/> for default values of queue properties.</remarks>
        /// <param name="queueName">The name of the queue relative to the service namespace base address.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="QueueDescription"/> of the newly created queue.</returns>
        /// <exception cref="ArgumentNullException">Queue name is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="queueName"/> is greater than 260 characters.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">An entity with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual Task<QueueDescription> CreateQueueAsync(string queueName, CancellationToken cancellationToken = default)
        {
            return this.CreateQueueAsync(new QueueDescription(queueName), cancellationToken);
        }

        /// <summary>
        /// Creates a new queue in the service namespace with the given name.
        /// </summary>
        /// <remarks>Throws if a queue already exists.</remarks>
        /// <param name="queueDescription">A <see cref="QueueDescription"/> object describing the attributes with which the new queue will be created.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="QueueDescription"/> of the newly created queue.</returns>
        /// <exception cref="ArgumentNullException">Queue name is null or empty.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">An entity with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<QueueDescription> CreateQueueAsync(QueueDescription queueDescription, CancellationToken cancellationToken = default)
        {
            queueDescription = queueDescription ?? throw new ArgumentNullException(nameof(queueDescription));
            queueDescription.NormalizeDescription(_fullyQualifiedNamespace);
            var atomRequest = queueDescription.Serialize().ToString();
            var content = await PutEntity(
                queueDescription.QueueName,
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
        /// <param name="topicName">The name of the topic relative to the service namespace base address.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="TopicDescription"/> of the newly created topic.</returns>
        /// <exception cref="ArgumentNullException">Topic name is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="topicName"/> is greater than 260 characters.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">A topic with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual Task<TopicDescription> CreateTopicAsync(string topicName, CancellationToken cancellationToken = default)
        {
            return CreateTopicAsync(new TopicDescription(topicName), cancellationToken);
        }

        /// <summary>
        /// Creates a new topic in the service namespace with the given name.
        /// </summary>
        /// <remarks>Throws if a topic already exists. <see cref="TopicDescription"/> for default values of topic properties.</remarks>
        /// <param name="topicDescription">A <see cref="TopicDescription"/> object describing the attributes with which the new topic will be created.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="TopicDescription"/> of the newly created topic.</returns>
        /// <exception cref="ArgumentNullException">Topic description is null.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">A topic with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<TopicDescription> CreateTopicAsync(TopicDescription topicDescription, CancellationToken cancellationToken = default)
        {
            topicDescription = topicDescription ?? throw new ArgumentNullException(nameof(topicDescription));
            var atomRequest = topicDescription.Serialize().ToString();

            var content = await PutEntity(topicDescription.TopicName, atomRequest, false, null, null, cancellationToken).ConfigureAwait(false);

            return TopicDescriptionExtensions.ParseFromContent(content);
        }

        /// <summary>
        /// Creates a new subscription within a topic in the service namespace with the given name.
        /// </summary>
        /// <remarks>Throws if a subscription already exists. <see cref="SubscriptionDescription"/> for default values of subscription properties.
        /// By default, A "pass-through" filter is created for this subscription, which means it will allow all messages to go to this subscription. The name of the filter is represented by <see cref="RuleDescription.DefaultRuleName"/>.
        /// <see cref="CreateSubscriptionAsync(SubscriptionDescription, RuleDescription, CancellationToken)"/> for creating subscription with a different filter.</remarks>
        /// <param name="topicName">The name of the topic relative to the service namespace base address.</param>
        /// <param name="subscriptionName">The name of the subscription.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="SubscriptionDescription"/> of the newly created subscription.</returns>
        /// <exception cref="ArgumentNullException">Topic name or subscription name is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="topicName"/> is greater than 260 characters or <paramref name="subscriptionName"/> is greater than 50 characters.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual Task<SubscriptionDescription> CreateSubscriptionAsync(string topicName, string subscriptionName, CancellationToken cancellationToken = default)
        {
            return CreateSubscriptionAsync(new SubscriptionDescription(topicName, subscriptionName), cancellationToken);
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
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual Task<SubscriptionDescription> CreateSubscriptionAsync(SubscriptionDescription subscriptionDescription, CancellationToken cancellationToken = default)
        {
            subscriptionDescription = subscriptionDescription ?? throw new ArgumentNullException(nameof(subscriptionDescription));
            return CreateSubscriptionAsync(subscriptionDescription, null, cancellationToken);
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
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<SubscriptionDescription> CreateSubscriptionAsync(SubscriptionDescription subscriptionDescription, RuleDescription defaultRule, CancellationToken cancellationToken = default)
        {
            subscriptionDescription = subscriptionDescription ?? throw new ArgumentNullException(nameof(subscriptionDescription));
            subscriptionDescription.NormalizeDescription(_fullyQualifiedNamespace);
            subscriptionDescription.DefaultRuleDescription = defaultRule;
            var atomRequest = subscriptionDescription.Serialize().ToString();
            var content = await PutEntity(
                EntityNameFormatter.FormatSubscriptionPath(subscriptionDescription.TopicName, subscriptionDescription.SubscriptionName),
                atomRequest,
                false,
                subscriptionDescription.ForwardTo,
                subscriptionDescription.ForwardDeadLetteredMessagesTo,
                cancellationToken).ConfigureAwait(false);
            return SubscriptionDescriptionExtensions.ParseFromContent(subscriptionDescription.TopicName, content);
        }

        /// <summary>
        /// Adds a new rule to the subscription under given topic.
        /// </summary>
        /// <param name="topicName">The topic name relative to the service namespace base address.</param>
        /// <param name="subscriptionName">The name of the subscription.</param>
        /// <param name="ruleDescription">A <see cref="RuleDescription"/> object describing the attributes with which the messages are matched and acted upon.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException">Subscription or rule description is null.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityAlreadyExists">A subscription with the same name exists under the same service namespace.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out. The timeout period is initialized through the <see cref="ServiceBusConnection"/> class. You may need to increase the value of timeout to avoid this exception if the timeout value is relatively low.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        /// <returns><see cref="RuleDescription"/> of the recently created rule.</returns>
        public virtual async Task<RuleDescription> CreateRuleAsync(string topicName, string subscriptionName, RuleDescription ruleDescription, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);
            ruleDescription = ruleDescription ?? throw new ArgumentNullException(nameof(ruleDescription));

            var atomRequest = ruleDescription.Serialize().ToString();

            var content = await PutEntity(
                EntityNameFormatter.FormatRulePath(topicName, subscriptionName, ruleDescription.Name),
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
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Described queue was not found.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<QueueDescription> UpdateQueueAsync(QueueDescription queueDescription, CancellationToken cancellationToken = default)
        {
            queueDescription = queueDescription ?? throw new ArgumentNullException(nameof(queueDescription));
            queueDescription.NormalizeDescription(_fullyQualifiedNamespace);

            var atomRequest = queueDescription.Serialize().ToString();

            var content = await PutEntity(
                queueDescription.QueueName,
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
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Described topic was not found.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<TopicDescription> UpdateTopicAsync(TopicDescription topicDescription, CancellationToken cancellationToken = default)
        {
            topicDescription = topicDescription ?? throw new ArgumentNullException(nameof(topicDescription));
            var atomRequest = topicDescription.Serialize().ToString();

            var content = await PutEntity(topicDescription.TopicName, atomRequest, true, null, null, cancellationToken).ConfigureAwait(false);

            return TopicDescriptionExtensions.ParseFromContent(content);
        }

        /// <summary>
        /// Updates an existing subscription under a topic.
        /// </summary>
        /// <param name="subscriptionDescription">A <see cref="SubscriptionDescription"/> object describing the attributes with which the subscription will be updated.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="SubscriptionDescription"/> of the updated subscription.</returns>
        /// <exception cref="ArgumentNullException">subscription descriptor is null.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Described subscription was not found.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<SubscriptionDescription> UpdateSubscriptionAsync(SubscriptionDescription subscriptionDescription, CancellationToken cancellationToken = default)
        {
            subscriptionDescription = subscriptionDescription ?? throw new ArgumentNullException(nameof(subscriptionDescription));
            subscriptionDescription.NormalizeDescription(_fullyQualifiedNamespace);
            var atomRequest = subscriptionDescription.Serialize().ToString();
            var content = await PutEntity(
                EntityNameFormatter.FormatSubscriptionPath(subscriptionDescription.TopicName, subscriptionDescription.SubscriptionName),
                atomRequest,
                true,
                subscriptionDescription.ForwardTo,
                subscriptionDescription.ForwardDeadLetteredMessagesTo,
                cancellationToken).ConfigureAwait(false);
            return SubscriptionDescriptionExtensions.ParseFromContent(subscriptionDescription.TopicName, content);
        }

        /// <summary>
        /// Updates an existing rule for a topic-subscription.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription.</param>
        /// <param name="ruleDescription">A <see cref="RuleDescription"/> object describing the attributes with which the rule will be updated.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The <see cref="RuleDescription"/> of the updated rule.</returns>
        /// <exception cref="ArgumentNullException">rule descriptor is null.</exception>
        /// <exception cref="ServiceBusException.FailureReason.MessagingEntityNotFound">Described topic/subscription/rule was not found.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.QuotaExceeded">Either the specified size in the description is not supported or the maximum allowable quota has been reached. You must specify one of the supported size values, delete existing entities, or increase your quota size.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<RuleDescription> UpdateRuleAsync(string topicName, string subscriptionName, RuleDescription ruleDescription, CancellationToken cancellationToken = default)
        {
            ruleDescription = ruleDescription ?? throw new ArgumentNullException(nameof(ruleDescription));
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);

            var atomRequest = ruleDescription.Serialize().ToString();
            var content = await PutEntity(
                EntityNameFormatter.FormatRulePath(topicName, subscriptionName, ruleDescription.Name),
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
        /// <param name="queueName">Name of the queue entity to check.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if queue exists, false otherwise.</returns>
        /// <exception cref="ArgumentException">Queue name provided is not valid.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<bool> QueueExistsAsync(string queueName, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidQueueName(queueName);

            try
            {
                QueueDescription qd = await GetQueueAsync(queueName, cancellationToken).ConfigureAwait(false);
            }
            catch (ServiceBusException ex) when (ex.Reason == ServiceBusException.FailureReason.MessagingEntityNotFound)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks whether a given topic exists or not.
        /// </summary>
        /// <param name="topicName">Name of the topic entity to check.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if topic exists, false otherwise.</returns>
        /// <exception cref="ArgumentException">topic name provided is not valid.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<bool> TopicExistsAsync(string topicName, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);

            try
            {
                // TODO: Optimize by removing deserialization costs.
                var td = await GetTopicAsync(topicName, cancellationToken).ConfigureAwait(false);
            }
            catch (ServiceBusException ex) when (ex.Reason == ServiceBusException.FailureReason.MessagingEntityNotFound)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks whether a given subscription exists or not.
        /// </summary>
        /// <param name="topicName">Name of the topic.</param>
        /// <param name="subscriptionName">Name of the subscription to check.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>True if subscription exists, false otherwise.</returns>
        /// <exception cref="ArgumentException">topic or subscription name provided is not valid.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceTimeout">The operation times out.</exception>
        /// <exception cref="UnauthorizedAccessException">No sufficient permission to perform this operation. You should check to ensure that your <see cref="ManagementClient"/> has the correct <see cref="TokenCredential"/> credentials to perform this operation.</exception>
        /// <exception cref="ServiceBusException.FailureReason.ServiceBusy">The server is busy. You should wait before you retry the operation.</exception>
        /// <exception cref="ServiceBusException">An internal error or unexpected exception occurs.</exception>
        public virtual async Task<bool> SubscriptionExistsAsync(string topicName, string subscriptionName, CancellationToken cancellationToken = default)
        {
            EntityNameFormatter.CheckValidTopicName(topicName);
            EntityNameFormatter.CheckValidSubscriptionName(subscriptionName);

            try
            {
                // TODO: Optimize by removing deserialization costs.
                var sd = await GetSubscriptionAsync(topicName, subscriptionName, cancellationToken).ConfigureAwait(false);
            }
            catch (ServiceBusException ex) when (ex.Reason == ServiceBusException.FailureReason.MessagingEntityNotFound)
            {
                return false;
            }

            return true;
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

        private static async Task<Exception> ValidateHttpResponse(Response response, Request request)
        {
            if ((response.Status >= 200) && (response.Status < 400))
            {
                return null;
            }

            string exceptionMessage = string.Empty;
            if (response.ContentStream != null)
            {
                exceptionMessage = await ReadAsString(response).ConfigureAwait(false);
            }
            exceptionMessage = ParseDetailIfAvailable(exceptionMessage) ?? response.ReasonPhrase;

            if (response.Status == (int)HttpStatusCode.Unauthorized)
            {
                return new ServiceBusException(exceptionMessage, ServiceBusException.FailureReason.Unauthorized);
            }

            if (response.Status == (int)HttpStatusCode.NotFound || response.Status == (int)HttpStatusCode.NoContent)
            {
                return new ServiceBusException(exceptionMessage, ServiceBusException.FailureReason.MessagingEntityNotFound);
            }

            if (response.Status == (int)HttpStatusCode.Conflict)
            {
                if (request.Method.Equals(RequestMethod.Delete))
                {
                    return new ServiceBusException(true, exceptionMessage);
                }

                if (request.Method.Equals(RequestMethod.Put) && request.Headers.TryGetValue("If-Match", out _))
                {
                    // response.RequestMessage.Headers.IfMatch.Count > 0 is true for UpdateEntity scenario
                    return new ServiceBusException(true, exceptionMessage);
                }

                if (exceptionMessage.Contains(ManagementClientConstants.ConflictOperationInProgressSubCode))
                {
                    return new ServiceBusException(true, exceptionMessage);
                }

                return new ServiceBusException(exceptionMessage, ServiceBusException.FailureReason.MessagingEntityAlreadyExists);
            }

            if (response.Status == (int)HttpStatusCode.Forbidden)
            {
                if (exceptionMessage.Contains(ManagementClientConstants.ForbiddenInvalidOperationSubCode))
                {
                    return new InvalidOperationException(exceptionMessage);
                }

                return new ServiceBusException(exceptionMessage, ServiceBusException.FailureReason.QuotaExceeded);
            }

            if (response.Status == (int)HttpStatusCode.BadRequest)
            {
                return new ArgumentException(exceptionMessage);
            }

            if (response.Status == (int)HttpStatusCode.ServiceUnavailable)
            {
                return new ServiceBusException(exceptionMessage, ServiceBusException.FailureReason.ServiceBusy);
            }

            return new ServiceBusException(true, exceptionMessage + "; response status code: " + response.Status);
        }

        private static async Task<string> ReadAsString(Response response)
        {
            string exceptionMessage;
            using StreamReader reader = new StreamReader(response.ContentStream);
            exceptionMessage = await reader.ReadToEndAsync().ConfigureAwait(false);
            return exceptionMessage;
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

        private Task<string> GetToken(Uri requestUri)
        {
            return GetToken(requestUri.GetLeftPart(UriPartial.Path));
        }

        private async Task<string> GetToken(string requestUri)
        {
            var scope = requestUri;
            var credential = (ServiceBusTokenCredential)_tokenCredential;
            if (!credential.IsSharedAccessSignatureCredential)
            {
                scope = "https://servicebus.azure.net/.default";
            }
            AccessToken token = await _tokenCredential.GetTokenAsync(new TokenRequestContext(new[] { scope }), CancellationToken.None).ConfigureAwait(false);
            return token.Token;
        }

        private async Task<string> GetEntity(string entityName, string query, bool enrich, CancellationToken cancellationToken)
        {
            MessagingEventSource.Log.ManagementOperationStart(_clientId, nameof(GetEntity), $"path:{entityName},query:{query},enrich:{enrich}");

            var queryString = $"{ManagementClientConstants.apiVersionQuery}&enrich={enrich}";
            if (query != null)
            {
                queryString = queryString + "&" + query;
            }
            var uri = new UriBuilder(_fullyQualifiedNamespace)
            {
                Path = entityName,
                Scheme = Uri.UriSchemeHttps,
                Port = _port,
                Query = queryString
            }.Uri;

            var requestUriBuilder = new RequestUriBuilder();
            requestUriBuilder.Reset(uri);

            var request = _pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri = requestUriBuilder;
            Response response = await SendHttpRequest(request, cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);

            MessagingEventSource.Log.ManagementOperationEnd(_clientId, nameof(GetEntity), $"path:{entityName},query:{query},enrich:{enrich}");
            return result;
        }

        private async Task<string> PutEntity(string entityName, string requestBody, bool isUpdate, string forwardTo, string fwdDeadLetterTo, CancellationToken cancellationToken)
        {
            MessagingEventSource.Log.ManagementOperationStart(_clientId, nameof(PutEntity), $"path:{entityName},isUpdate:{isUpdate}");

            var uri = new UriBuilder(_fullyQualifiedNamespace)
            {
                Path = entityName,
                Port = _port,
                Scheme = Uri.UriSchemeHttps,
                Query = $"{ManagementClientConstants.apiVersionQuery}"
            }.Uri;
            var requestUriBuilder = new RequestUriBuilder();
            requestUriBuilder.Reset(uri);

            var request = _pipeline.CreateRequest();
            request.Method = RequestMethod.Put;
            request.Uri = requestUriBuilder;
            request.Content = RequestContent.Create(Encoding.UTF8.GetBytes(requestBody));
            request.Headers.Add("Content-Type", ManagementClientConstants.AtomContentType);

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

            Response response = await SendHttpRequest(request, cancellationToken).ConfigureAwait(false);
            var result = await ReadAsString(response).ConfigureAwait(false);

            MessagingEventSource.Log.ManagementOperationEnd(_clientId, nameof(PutEntity), $"path:{entityName},isUpdate:{isUpdate}");
            return result;
        }

        private async Task<Response> DeleteEntity(string entityName, CancellationToken cancellationToken)
        {
            MessagingEventSource.Log.ManagementOperationStart(_clientId, nameof(DeleteEntity), entityName);

            var uri = new UriBuilder(_fullyQualifiedNamespace)
            {
                Path = entityName,
                Scheme = Uri.UriSchemeHttps,
                Port = _port,
                Query = ManagementClientConstants.apiVersionQuery
            }.Uri;
            var requestUriBuilder = new RequestUriBuilder();
            requestUriBuilder.Reset(uri);

            var request = _pipeline.CreateRequest();
            request.Uri = requestUriBuilder;
            request.Method = RequestMethod.Delete;

            var response = await SendHttpRequest(request, cancellationToken).ConfigureAwait(false);
            MessagingEventSource.Log.ManagementOperationEnd(_clientId, nameof(DeleteEntity), entityName);
            return response;
        }

        private async Task<Response> SendHttpRequest(Request request, CancellationToken cancellationToken)
        {

            var token = await GetToken(request.Uri.ToUri()).ConfigureAwait(false);
            var credential = (ServiceBusTokenCredential)_tokenCredential;
            if (credential.IsSharedAccessSignatureCredential)
            {
                request.Headers.Add("Authorization", token);
            }
            else
            {
                request.Headers.Add("Authorization", $"Bearer { token }");
            }
            request.Headers.Add("UserAgent", $"SERVICEBUS/{ManagementClientConstants.ApiVersion}(api-origin={ClientInfo.Framework};os={ClientInfo.Platform};version={ClientInfo.Version};product={ClientInfo.Product})");

            Response response;
            try
            {
                response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                MessagingEventSource.Log.ManagementOperationException(_clientId, nameof(SendHttpRequest), exception);
                throw new ServiceBusException(true, exception.Message);
            }

            var exceptionReturned = await ValidateHttpResponse(response, request).ConfigureAwait(false);
            if (exceptionReturned == null)
            {
                return response;
            }
            else
            {
                MessagingEventSource.Log.ManagementOperationException(_clientId, nameof(SendHttpRequest), exceptionReturned);
                throw exceptionReturned;
            }
        }

        /// <summary>
        ///   Builds the audience for use in the signature.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        ///
        /// <returns>The value to use as the audience of the signature.</returns>
        ///
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

            if (builder.Path.EndsWith("/"))
            {
                builder.Path = builder.Path.TrimEnd('/');
            }

            return builder.Uri.AbsoluteUri.ToLowerInvariant();
        }
    }

}
