// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Azure.Messaging.ServiceBus.Core;
    using Azure.Messaging.ServiceBus.Primitives;

    /// <summary>
    /// QueueClient can be used for all basic interactions with a Service Bus Queue.
    /// </summary>
    /// <example>
    /// Create a new QueueClient
    /// <code>
    /// QueueClient queueClient = new QueueClient(
    ///     namespaceConnectionString,
    ///     queueName,
    ///     ReceiveMode.PeekLock,
    ///     RetryExponential);
    /// </code>
    ///
    /// Send a message to the queue:
    /// <code>
    /// byte[] data = GetData();
    /// await queueClient.SendAsync(data);
    /// </code>
    ///
    /// Register a message handler which will be invoked every time a message is received.
    /// <code>
    /// queueClient.RegisterMessageHandler(
    ///        async (message, token) =&gt;
    ///        {
    ///            // Process the message
    ///            Console.WriteLine($"Received message: SequenceNumber:{message.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
    ///
    ///            // Complete the message so that it is not received again.
    ///            // This can be done only if the queueClient is opened in ReceiveMode.PeekLock mode.
    ///            await queueClient.CompleteAsync(message.LockToken);
    ///        },
    ///        async (exceptionEvent) =&gt;
    ///        {
    ///            // Process the exception
    ///            Console.WriteLine("Exception = " + exceptionEvent.Exception);
    ///            return Task.CompletedTask;
    ///        });
    /// </code>
    /// </example>
    /// <remarks>Use <see cref="MessageSender"/> or <see cref="MessageReceiver"/> for advanced set of functionality.
    /// It uses AMQP protocol for communicating with servicebus.</remarks>
    public class QueueClient
    {
        internal ClientEntity ClientEntity { get; set; }

        /// <summary>
        /// Instantiates a new <see cref="QueueClient"/> to perform operations on a queue.
        /// </summary>
        /// <param name="connectionStringBuilder"><see cref="ServiceBusConnectionStringBuilder"/> having namespace and queue information.</param>
        /// <remarks>Creates a new connection to the queue, which is opened during the first send/receive operation.</remarks>
        internal QueueClient(ServiceBusConnectionStringBuilder connectionStringBuilder, AmqpClientOptions options = null)
            : this(connectionStringBuilder?.GetNamespaceConnectionString(), connectionStringBuilder?.EntityPath, options)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="QueueClient"/> to perform operations on a queue.
        /// </summary>
        /// <param name="connectionString">Namespace connection string. Must not contain queue information.</param>
        /// <param name="entityPath">Name of the queue</param>
        /// <remarks>Creates a new connection to the queue, which is opened during the first send/receive operation.</remarks>
        public QueueClient(string connectionString, string entityPath, AmqpClientOptions options = null)
            : this(new ServiceBusConnection(new ServiceBusConnectionStringBuilder(connectionString), options), entityPath, options)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(connectionString);
            }

            ClientEntity.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new instance of the Queue client using the specified endpoint, entity path, and token provider.
        /// </summary>
        /// <param name="endpoint">Fully qualified domain name for Service Bus. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="entityPath">Queue path.</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        /// <remarks>Creates a new connection to the queue, which is opened during the first send/receive operation.</remarks>
        public QueueClient(
            string endpoint,
            string entityPath,
            TokenCredential tokenProvider,
            AmqpClientOptions options = null)
            : this(new ServiceBusConnection(endpoint, tokenProvider, options), entityPath, options)
        {
            ClientEntity.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new instance of the Queue client on a given <see cref="ServiceBusConnection"/>
        /// </summary>
        /// <param name="serviceBusConnection">Connection object to the service bus namespace.</param>
        /// <param name="entityPath">Queue path.</param>
        public QueueClient(ServiceBusConnection serviceBusConnection, string entityPath, AmqpClientOptions options)
        {
            ClientEntity = new ClientEntity(options, entityPath);
            MessagingEventSource.Log.QueueClientCreateStart(serviceBusConnection?.Endpoint.Authority, entityPath, "unknown");

            if (string.IsNullOrWhiteSpace(entityPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(entityPath);
            }

            ClientEntity.ServiceBusConnection = serviceBusConnection ?? throw new ArgumentNullException(nameof(serviceBusConnection));
            this.QueueName = entityPath;
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

            MessagingEventSource.Log.QueueClientCreateStop(serviceBusConnection.Endpoint.Authority, entityPath, ClientEntity.ClientId);
        }

        /// <summary>
        /// Gets the name of the queue.
        /// </summary>
        public string QueueName { get; }


        /// <summary>
        /// Gets the name of the queue.
        /// </summary>
        public string Path => this.QueueName;

        
        public MessageSender CreateSender()
        {
           return new MessageSender(
                                this.QueueName,
                                null,
                                MessagingEntityType.Queue,
                                ClientEntity.ServiceBusConnection,
                                this.CbsTokenProvider,
                                ClientEntity.Options);
        }

        public MessageReceiver CreateReceiver(ReceiveMode receiveMode = ReceiveMode.PeekLock, ReceiveOptions receiveOptions = null)
        {
            receiveOptions ??= ReceiveOptions.Default;

            return new MessageReceiver(
                                this.QueueName,
                                MessagingEntityType.Queue,
                                receiveMode,
                                ClientEntity.ServiceBusConnection,
                                this.CbsTokenProvider,
                                ClientEntity.Options,
                                receiveOptions.PrefetchCount);
        }

        internal SessionClient CreateSessionClient(ReceiveMode receiveMode = ReceiveMode.PeekLock, ReceiveOptions receiveOptions = null)
        {            
            receiveOptions ??= ReceiveOptions.Default;

            return new SessionClient(
                ClientEntity.ClientId,
                this.Path,
                MessagingEntityType.Queue,
                receiveMode,
                receiveOptions.PrefetchCount,
                ClientEntity.ServiceBusConnection,
                this.CbsTokenProvider,
                ClientEntity.Options);
        }

        internal SessionPumpHost CreateSessionPumpHost(ReceiveMode mode = ReceiveMode.PeekLock, ReceiveOptions receiveOptions = null)
        {
            return new SessionPumpHost(
                ClientEntity.ClientId,
                mode,
                CreateSessionClient(mode, receiveOptions),
                ClientEntity.ServiceBusConnection.Endpoint);
        }

        private ICbsTokenProvider CbsTokenProvider { get; }

        public Task CloseAsync() => ClientEntity.CloseAsync(() => Task.CompletedTask);
    }
}
