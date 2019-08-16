// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Azure.Messaging.ServiceBus.Core;
    using Azure.Messaging.ServiceBus.Primitives;

    /// <summary>
    /// TopicClient can be used for all basic interactions with a Service Bus topic.
    /// </summary>
    /// <example>
    /// Create a new TopicClient
    /// <code>
    /// TopicClient topicClient = new TopicClient(
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
    public class TopicClient: IAsyncDisposable
    {
        internal ClientEntity ClientEntity { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="TopicClient"/> to perform operations on a topic.
        /// </summary>
        /// <param name="connectionStringBuilder"><see cref="ServiceBusConnectionStringBuilder"/> having namespace and topic information.</param>
        /// <remarks>Creates a new connection to the topic, which is opened during the first send operation.</remarks>
        internal TopicClient(ServiceBusConnectionStringBuilder connectionStringBuilder, AmqpClientOptions options = null)
            : this(connectionStringBuilder?.GetNamespaceConnectionString(), connectionStringBuilder?.EntityPath, options)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="TopicClient"/> to perform operations on a topic.
        /// </summary>
        /// <param name="connectionString">Namespace connection string. Must not contain topic information.</param>
        /// <param name="entityPath">Path to the topic</param>
        /// <remarks>Creates a new connection to the topic, which is opened during the first send operation.</remarks>
        public TopicClient(string connectionString, string entityPath, AmqpClientOptions options = null)
            : this(new ServiceBusConnection(new ServiceBusConnectionStringBuilder(connectionString), options), entityPath, options)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(connectionString);
            }

            ClientEntity.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new instance of the Topic client using the specified endpoint, entity path, and token provider.
        /// </summary>
        /// <param name="endpoint">Fully qualified domain name for Service Bus. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="entityPath">Topic path.</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        /// <remarks>Creates a new connection to the topic, which is opened during the first send operation.</remarks>
        public TopicClient(
            string endpoint,
            string entityPath,
            TokenCredential tokenProvider,
            AmqpClientOptions options = null)
            : this(new ServiceBusConnection(endpoint, tokenProvider, options), entityPath, options)
        {
            ClientEntity.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new instance of the Topic client on a given <see cref="ServiceBusConnection"/>
        /// </summary>
        /// <param name="serviceBusConnection">Connection object to the service bus namespace.</param>
        /// <param name="entityPath">Topic path.</param>
        public TopicClient(ServiceBusConnection serviceBusConnection, string entityPath, AmqpClientOptions options)
        {
            ClientEntity = new ClientEntity(options, entityPath);
            MessagingEventSource.Log.TopicClientCreateStart(serviceBusConnection?.Endpoint.Authority, entityPath);

            if (string.IsNullOrWhiteSpace(entityPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(entityPath);
            }
            ClientEntity.ServiceBusConnection = serviceBusConnection ?? throw new ArgumentNullException(nameof(serviceBusConnection));
            this.TopicName = entityPath;
            ClientEntity.OwnsConnection = false;
            ClientEntity.ServiceBusConnection.ThrowIfClosed();

            if (ClientEntity.ServiceBusConnection.TokenCredential != null)
            {
                this.CbsTokenProvider = new TokenProviderAdapter(ClientEntity.ServiceBusConnection.TokenCredential, ClientEntity.ServiceBusConnection.OperationTimeout);
            }
            else
            {
                throw new ArgumentNullException($"{nameof(ServiceBusConnection)} doesn't have a valid token provider");
            }

            MessagingEventSource.Log.TopicClientCreateStop(serviceBusConnection.Endpoint.Authority, entityPath, ClientEntity.ClientId);
        }

        /// <summary>
        /// Gets the name of the topic.
        /// </summary>
        public string TopicName { get; }

        /// <summary>
        /// Gets the name of the topic.
        /// </summary>
        public string Path => this.TopicName;


        public MessageSender CreateSender()
        {
            return new MessageSender(
                                this.TopicName,
                                null,
                                MessagingEntityType.Topic,
                                ClientEntity.ServiceBusConnection,
                                this.CbsTokenProvider,
                                ClientEntity.Options);
        }

        private ICbsTokenProvider CbsTokenProvider { get; }

        public async ValueTask DisposeAsync()
        {
            await ClientEntity.CloseAsync(() => Task.CompletedTask);
        }
    }
}