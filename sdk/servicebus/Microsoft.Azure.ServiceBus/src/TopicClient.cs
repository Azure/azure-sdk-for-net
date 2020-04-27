// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Core;
    using Primitives;

    /// <summary>
    /// TopicClient can be used for all basic interactions with a Service Bus topic.
    /// </summary>
    /// <example>
    /// Create a new TopicClient
    /// <code>
    /// ITopicClient topicClient = new TopicClient(
    ///     namespaceConnectionString,
    ///     topicName,
    ///     RetryExponential);
    /// </code>
    ///
    /// Send a message to the topic:
    /// <code>
    /// byte[] data = GetData();
    /// await topicClient.SendAsync(data);
    /// </code>
    /// </example>
    /// <remarks>It uses AMQP protocol for communicating with servicebus.</remarks>
    public class TopicClient : ClientEntity, ITopicClient
    {
        readonly object syncLock;
        MessageSender innerSender;

        /// <summary>
        /// Instantiates a new <see cref="TopicClient"/> to perform operations on a topic.
        /// </summary>
        /// <param name="connectionStringBuilder"><see cref="ServiceBusConnectionStringBuilder"/> having namespace and topic information.</param>
        /// <param name="retryPolicy">Retry policy for topic operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <remarks>Creates a new connection to the topic, which is opened during the first send operation.</remarks>
        public TopicClient(ServiceBusConnectionStringBuilder connectionStringBuilder, RetryPolicy retryPolicy = null)
            : this(connectionStringBuilder?.GetNamespaceConnectionString(), connectionStringBuilder?.EntityPath, retryPolicy)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="TopicClient"/> to perform operations on a topic.
        /// </summary>
        /// <param name="connectionString">Namespace connection string. Must not contain topic information.</param>
        /// <param name="entityPath">Path to the topic</param>
        /// <param name="retryPolicy">Retry policy for topic operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <remarks>Creates a new connection to the topic, which is opened during the first send operation.</remarks>
        public TopicClient(string connectionString, string entityPath, RetryPolicy retryPolicy = null)
            : this(new ServiceBusConnection(connectionString), entityPath, retryPolicy ?? RetryPolicy.Default)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(connectionString);
            }

            OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new instance of the Topic client using the specified endpoint, entity path, and token provider.
        /// </summary>
        /// <param name="endpoint">Fully qualified domain name for Service Bus. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="entityPath">Topic path.</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        /// <param name="transportType">Transport type.</param>
        /// <param name="retryPolicy">Retry policy for topic operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <remarks>Creates a new connection to the topic, which is opened during the first send operation.</remarks>
        public TopicClient(
            string endpoint,
            string entityPath,
            ITokenProvider tokenProvider,
            TransportType transportType = TransportType.Amqp,
            RetryPolicy retryPolicy = null)
            : this(new ServiceBusConnection(endpoint, transportType, retryPolicy) {TokenProvider = tokenProvider}, entityPath, retryPolicy)
        {
            OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new instance of the Topic client on a given <see cref="ServiceBusConnection"/>
        /// </summary>
        /// <param name="serviceBusConnection">Connection object to the service bus namespace.</param>
        /// <param name="entityPath">Topic path.</param>
        /// <param name="retryPolicy">Retry policy for topic operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        public TopicClient(ServiceBusConnection serviceBusConnection, string entityPath, RetryPolicy retryPolicy)
            : base(nameof(TopicClient), entityPath, retryPolicy)
        {
            MessagingEventSource.Log.TopicClientCreateStart(serviceBusConnection?.Endpoint.Authority, entityPath);

            if (string.IsNullOrWhiteSpace(entityPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(entityPath);
            }
            ServiceBusConnection = serviceBusConnection ?? throw new ArgumentNullException(nameof(serviceBusConnection));
            syncLock = new object();
            TopicName = entityPath;
            OwnsConnection = false;
            ServiceBusConnection.ThrowIfClosed();

            if (ServiceBusConnection.TokenProvider != null)
            {
                CbsTokenProvider = new TokenProviderAdapter(ServiceBusConnection.TokenProvider, ServiceBusConnection.OperationTimeout);
            }
            else
            {
                throw new ArgumentNullException($"{nameof(ServiceBusConnection)} doesn't have a valid token provider");
            }

            MessagingEventSource.Log.TopicClientCreateStop(serviceBusConnection.Endpoint.Authority, entityPath, ClientId);
        }

        /// <summary>
        /// Gets the name of the topic.
        /// </summary>
        public string TopicName { get; }

        /// <summary>
        /// Duration after which individual operations will timeout.
        /// </summary>
        public override TimeSpan OperationTimeout
        {
            get => ServiceBusConnection.OperationTimeout;
            set => ServiceBusConnection.OperationTimeout = value;
        }

        /// <summary>
        /// Gets the name of the topic.
        /// </summary>
        public override string Path => TopicName;

        /// <summary>
        /// Connection object to the service bus namespace.
        /// </summary>
        public override ServiceBusConnection ServiceBusConnection { get; }

        internal MessageSender InnerSender
        {
            get
            {
                if (innerSender == null)
                {
                    lock (syncLock)
                    {
                        if (innerSender == null)
                        {
                            innerSender = new MessageSender(
                                TopicName,
                                null,
                                MessagingEntityType.Topic,
                                ServiceBusConnection,
                                CbsTokenProvider,
                                RetryPolicy);
                        }
                    }
                }

                return innerSender;
            }
        }
        
        ICbsTokenProvider CbsTokenProvider { get; }

        /// <summary>
        /// Sends a message to Service Bus.
        /// </summary>
        public Task SendAsync(Message message)
        {
            return SendAsync(new[] { message });
        }

        /// <summary>
        /// Sends a list of messages to Service Bus.
        /// When called on partitioned entities, messages meant for different partitions cannot be batched together.
        /// </summary>
        public Task SendAsync(IList<Message> messageList)
        {
            ThrowIfClosed();
            return InnerSender.SendAsync(messageList);
        }

        /// <summary>
        /// Schedules a message to appear on Service Bus at a later time.
        /// </summary>
        /// <param name="message">The <see cref="Message"/> that needs to be scheduled.</param>
        /// <param name="scheduleEnqueueTimeUtc">The UTC time at which the message should be available for processing.</param>
        /// <returns>The sequence number of the message that was scheduled.</returns>
        public Task<long> ScheduleMessageAsync(Message message, DateTimeOffset scheduleEnqueueTimeUtc)
        {
            ThrowIfClosed();
            return InnerSender.ScheduleMessageAsync(message, scheduleEnqueueTimeUtc);
        }

        /// <summary>
        /// Cancels a message that was scheduled.
        /// </summary>
        /// <param name="sequenceNumber">The <see cref="Message.SystemPropertiesCollection.SequenceNumber"/> of the message to be cancelled.</param>
        public Task CancelScheduledMessageAsync(long sequenceNumber)
        {
            ThrowIfClosed();
            return InnerSender.CancelScheduledMessageAsync(sequenceNumber);
        }

        /// <summary>
        /// Gets a list of currently registered plugins for this TopicClient.
        /// </summary>
        public override IList<ServiceBusPlugin> RegisteredPlugins => InnerSender.RegisteredPlugins;

        /// <summary>
        /// Registers a <see cref="ServiceBusPlugin"/> to be used with this topic client.
        /// </summary>
        public override void RegisterPlugin(ServiceBusPlugin serviceBusPlugin)
        {
            ThrowIfClosed();
            InnerSender.RegisterPlugin(serviceBusPlugin);
        }

        /// <summary>
        /// Unregisters a <see cref="ServiceBusPlugin"/>.
        /// </summary>
        /// <param name="serviceBusPluginName">The name <see cref="ServiceBusPlugin.Name"/> to be unregistered</param>
        public override void UnregisterPlugin(string serviceBusPluginName)
        {
            ThrowIfClosed();
            InnerSender.UnregisterPlugin(serviceBusPluginName);
        }

        protected override async Task OnClosingAsync()
        {
            if (innerSender != null)
            {
                await innerSender.CloseAsync().ConfigureAwait(false);
            }
        }
    }
}