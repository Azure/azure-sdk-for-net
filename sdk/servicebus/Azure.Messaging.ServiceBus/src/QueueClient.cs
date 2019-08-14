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
    ///            Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
    ///
    ///            // Complete the message so that it is not received again.
    ///            // This can be done only if the queueClient is opened in ReceiveMode.PeekLock mode.
    ///            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
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
        readonly object syncLock;

        int prefetchCount;
        MessageSender innerSender;
        MessageReceiver innerReceiver;
        SessionClient sessionClient;
        SessionPumpHost sessionPumpHost;
        internal ClientEntity ClientEntity { get; set; }

        /// <summary>
        /// Instantiates a new <see cref="QueueClient"/> to perform operations on a queue.
        /// </summary>
        /// <param name="connectionStringBuilder"><see cref="ServiceBusConnectionStringBuilder"/> having namespace and queue information.</param>
        /// <param name="receiveMode">Mode of receive of messages. Defaults to <see cref="ReceiveMode"/>.PeekLock.</param>
        /// <remarks>Creates a new connection to the queue, which is opened during the first send/receive operation.</remarks>
        internal QueueClient(ServiceBusConnectionStringBuilder connectionStringBuilder, ReceiveMode receiveMode = ReceiveMode.PeekLock, AmqpClientOptions options = null)
            : this(connectionStringBuilder?.GetNamespaceConnectionString(), connectionStringBuilder?.EntityPath, receiveMode, options)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="QueueClient"/> to perform operations on a queue.
        /// </summary>
        /// <param name="connectionString">Namespace connection string. Must not contain queue information.</param>
        /// <param name="entityPath">Name of the queue</param>
        /// <param name="receiveMode">Mode of receive of messages. Defaults to <see cref="ReceiveMode"/>.PeekLock.</param>
        /// <remarks>Creates a new connection to the queue, which is opened during the first send/receive operation.</remarks>
        public QueueClient(string connectionString, string entityPath, ReceiveMode receiveMode = ReceiveMode.PeekLock, AmqpClientOptions options = null)
            : this(new ServiceBusConnection(new ServiceBusConnectionStringBuilder(connectionString), options), entityPath, receiveMode, options)
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
        /// <param name="receiveMode">Mode of receive of messages. Defaults to <see cref="ReceiveMode"/>.PeekLock.</param>
        /// <remarks>Creates a new connection to the queue, which is opened during the first send/receive operation.</remarks>
        public QueueClient(
            string endpoint,
            string entityPath,
            TokenCredential tokenProvider,
            ReceiveMode receiveMode = ReceiveMode.PeekLock,
            AmqpClientOptions options = null)
            : this(new ServiceBusConnection(endpoint, tokenProvider, options), entityPath, receiveMode, options)
        {
            ClientEntity.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new instance of the Queue client on a given <see cref="ServiceBusConnection"/>
        /// </summary>
        /// <param name="serviceBusConnection">Connection object to the service bus namespace.</param>
        /// <param name="entityPath">Queue path.</param>
        /// <param name="receiveMode">Mode of receive of messages. Default to <see cref="ReceiveMode"/>.PeekLock.</param>
        public QueueClient(ServiceBusConnection serviceBusConnection, string entityPath, ReceiveMode receiveMode, AmqpClientOptions options)
        {
            ClientEntity = new ClientEntity(options, entityPath);
            MessagingEventSource.Log.QueueClientCreateStart(serviceBusConnection?.Endpoint.Authority, entityPath, receiveMode.ToString());

            if (string.IsNullOrWhiteSpace(entityPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(entityPath);
            }

            ClientEntity.ServiceBusConnection = serviceBusConnection ?? throw new ArgumentNullException(nameof(serviceBusConnection));
            this.syncLock = new object();
            this.QueueName = entityPath;
            this.ReceiveMode = receiveMode;
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
        /// Gets the <see cref="ServiceBus.ReceiveMode"/> for the QueueClient.
        /// </summary>
        public ReceiveMode ReceiveMode { get; }

        /// <summary>
        /// Gets the name of the queue.
        /// </summary>
        public string Path => this.QueueName;

        /// <summary>
        /// Prefetch speeds up the message flow by aiming to have a message readily available for local retrieval when and before the application asks for one using Receive.
        /// Setting a non-zero value prefetches PrefetchCount number of messages.
        /// Setting the value to zero turns prefetch off.
        /// Defaults to 0.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When Prefetch is enabled, the client will quietly acquire more messages, up to the PrefetchCount limit, than what the application
        /// immediately asks for. The message pump will therefore acquire a message for immediate consumption
        /// that will be returned as soon as available, and the client will proceed to acquire further messages to fill the prefetch buffer in the background.
        /// </para>
        /// <para>
        /// While messages are available in the prefetch buffer, any subsequent ReceiveAsync calls will be immediately satisfied from the buffer, and the buffer is
        /// replenished in the background as space becomes available.If there are no messages available for delivery, the receive operation will drain the
        /// buffer and then wait or block as expected.
        /// </para>
        /// <para>Updates to this value take effect on the next receive call to the service.</para>
        /// </remarks>
        public int PrefetchCount
        {
            get => this.prefetchCount;
            set
            {
                if (value < 0)
                {
                    throw Fx.Exception.ArgumentOutOfRange(nameof(this.PrefetchCount), value, "Value cannot be less than 0.");
                }
                this.prefetchCount = value;
                if (this.innerReceiver != null)
                {
                    this.innerReceiver.PrefetchCount = value;
                }
                if (this.sessionClient != null)
                {
                    this.sessionClient.PrefetchCount = value;
                }
            }
        }

        internal MessageSender InnerSender
        {
            get
            {
                if (this.innerSender == null)
                {
                    lock (this.syncLock)
                    {
                        if (this.innerSender == null)
                        {
                            this.innerSender = new MessageSender(
                                this.QueueName,
                                null,
                                MessagingEntityType.Queue,
                                ClientEntity.ServiceBusConnection,
                                this.CbsTokenProvider,
                                ClientEntity.Options);
                        }
                    }
                }

                return this.innerSender;
            }
        }

        internal MessageReceiver InnerReceiver
        {
            get
            {
                if (this.innerReceiver == null)
                {
                    lock (this.syncLock)
                    {
                        if (this.innerReceiver == null)
                        {
                            this.innerReceiver = new MessageReceiver(
                                this.QueueName,
                                MessagingEntityType.Queue,
                                this.ReceiveMode,
                                ClientEntity.ServiceBusConnection,
                                this.CbsTokenProvider,
                                ClientEntity.Options,
                                this.PrefetchCount);
                        }
                    }
                }

                return this.innerReceiver;
            }
        }

        internal SessionClient SessionClient
        {
            get
            {
                if (this.sessionClient == null)
                {
                    lock (this.syncLock)
                    {
                        if (this.sessionClient == null)
                        {
                            this.sessionClient = new SessionClient(
                                ClientEntity.ClientId,
                                this.Path,
                                MessagingEntityType.Queue,
                                this.ReceiveMode,
                                this.PrefetchCount,
                                ClientEntity.ServiceBusConnection,
                                this.CbsTokenProvider,
                                ClientEntity.Options);
                        }
                    }
                }

                return this.sessionClient;
            }
        }

        internal SessionPumpHost SessionPumpHost
        {
            get
            {
                if (this.sessionPumpHost == null)
                {
                    lock (this.syncLock)
                    {
                        if (this.sessionPumpHost == null)
                        {
                            this.sessionPumpHost = new SessionPumpHost(
                                ClientEntity.ClientId,
                                this.ReceiveMode,
                                this.SessionClient,
                                ClientEntity.ServiceBusConnection.Endpoint);
                        }
                    }
                }

                return this.sessionPumpHost;
            }
        }

        ICbsTokenProvider CbsTokenProvider { get; }

        /// <summary>
        /// Sends a message to Service Bus.
        /// </summary>
        public Task SendAsync(Message message)
        {
            return this.SendAsync(new[] { message });
        }

        /// <summary>
        /// Sends a list of messages to Service Bus.
        /// </summary>
        public Task SendAsync(IList<Message> messageList)
        {
            ClientEntity.ThrowIfClosed();

            return this.InnerSender.SendAsync(messageList);
        }

        /// <summary>
        /// Completes a <see cref="Message"/> using its lock token. This will delete the message from the queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to complete.</param>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// This operation can only be performed on messages that were received by this client.
        /// </remarks>
        public Task CompleteAsync(string lockToken)
        {
            ClientEntity.ThrowIfClosed();
            return this.InnerReceiver.CompleteAsync(lockToken);
        }

        /// <summary>
        /// Abandons a <see cref="Message"/> using a lock token. This will make the message available again for processing.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to abandon.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while abandoning the message.</param>
        /// <remarks>A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// Abandoning a message will increase the delivery count on the message.
        /// This operation can only be performed on messages that were received by this client.
        /// </remarks>
        /// This operation can only be performed on messages that were received by this client.
        public Task AbandonAsync(string lockToken, IDictionary<string, object> propertiesToModify = null)
        {
            ClientEntity.ThrowIfClosed();
            return this.InnerReceiver.AbandonAsync(lockToken, propertiesToModify);
        }

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to sub-queue.</param>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// In order to receive a message from the deadletter queue, you will need a new <see cref="MessageReceiver"/>, with the corresponding path.
        /// You can use <see cref="EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public Task DeadLetterAsync(string lockToken, IDictionary<string, object> propertiesToModify = null)
        {
            ClientEntity.ThrowIfClosed();
            return this.InnerReceiver.DeadLetterAsync(lockToken, propertiesToModify);
        }

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <param name="deadLetterReason">The reason for deadlettering the message.</param>
        /// <param name="deadLetterErrorDescription">The error description for deadlettering the message.</param>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// In order to receive a message from the deadletter queue, you will need a new <see cref="MessageReceiver"/>, with the corresponding path.
        /// You can use <see cref="EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public Task DeadLetterAsync(string lockToken, string deadLetterReason, string deadLetterErrorDescription = null)
        {
            ClientEntity.ThrowIfClosed();
            return this.InnerReceiver.DeadLetterAsync(lockToken, deadLetterReason, deadLetterErrorDescription);
        }

        /// <summary>
        /// Receive messages continuously from the entity. Registers a message handler and begins a new thread to receive messages.
        /// This handler(<see cref="Func{Message, CancellationToken, Task}"/>) is awaited on every time a new message is received by the receiver.
        /// </summary>
        /// <param name="handler">A <see cref="Func{Message, CancellationToken, Task}"/> that processes messages.</param>
        /// <param name="exceptionReceivedHandler">A <see cref="Func{T1, TResult}"/> that is invoked during exceptions.
        /// <see cref="ExceptionReceivedEventArgs"/> contains contextual information regarding the exception.</param>
        /// <remarks>Enable prefetch to speed up the receive rate.
        /// Use <see cref="RegisterMessageHandler(Func{Message,CancellationToken,Task}, MessageHandlerOptions)"/> to configure the settings of the pump.</remarks>
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, Func<ExceptionReceivedEventArgs, Task> exceptionReceivedHandler)
        {
            this.RegisterMessageHandler(handler, new MessageHandlerOptions(exceptionReceivedHandler));
        }

        /// <summary>
        /// Receive messages continuously from the entity. Registers a message handler and begins a new thread to receive messages.
        /// This handler(<see cref="Func{Message, CancellationToken, Task}"/>) is awaited on every time a new message is received by the receiver.
        /// </summary>
        /// <param name="handler">A <see cref="Func{Message, CancellationToken, Task}"/> that processes messages.</param>
        /// <param name="messageHandlerOptions">The <see cref="MessageHandlerOptions"/> options used to configure the settings of the pump.</param>
        /// <remarks>Enable prefetch to speed up the receive rate.</remarks>
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, MessageHandlerOptions messageHandlerOptions)
        {
            ClientEntity.ThrowIfClosed();
            this.InnerReceiver.RegisterMessageHandler(handler, messageHandlerOptions);
        }

        /// <summary>
        /// Receive session messages continuously from the queue. Registers a message handler and begins a new thread to receive session-messages.
        /// This handler(<see cref="Func{MessageSession, Message, CancellationToken, Task}"/>) is awaited on every time a new message is received by the queue client.
        /// </summary>
        /// <param name="handler">A <see cref="Func{MessageSession, Message, CancellationToken, Task}"/> that processes messages.
        /// <see cref="MessageSession"/> contains the session information, and must be used to perform Complete/Abandon/Deadletter or other such operations on the <see cref="Message"/></param>
        /// <param name="exceptionReceivedHandler">A <see cref="Func{T1, TResult}"/> that is invoked during exceptions.
        /// <see cref="ExceptionReceivedEventArgs"/> contains contextual information regarding the exception.</param>
        /// <remarks>Enable prefetch to speed up the receive rate.
        /// Use <see cref="RegisterSessionHandler(Func{MessageSession,Message,CancellationToken,Task}, SessionHandlerOptions)"/> to configure the settings of the pump.</remarks>
        public void RegisterSessionHandler(Func<MessageSession, Message, CancellationToken, Task> handler, Func<ExceptionReceivedEventArgs, Task> exceptionReceivedHandler)
        {
            var sessionHandlerOptions = new SessionHandlerOptions(exceptionReceivedHandler);
            this.RegisterSessionHandler(handler, sessionHandlerOptions);
        }

        /// <summary>
        /// Receive session messages continuously from the queue. Registers a message handler and begins a new thread to receive session-messages.
        /// This handler(<see cref="Func{MessageSession, Message, CancellationToken, Task}"/>) is awaited on every time a new message is received by the queue client.
        /// </summary>
        /// <param name="handler">A <see cref="Func{MessageSession, Message, CancellationToken, Task}"/> that processes messages.
        /// <see cref="MessageSession"/> contains the session information, and must be used to perform Complete/Abandon/Deadletter or other such operations on the <see cref="Message"/></param>
        /// <param name="sessionHandlerOptions">Options used to configure the settings of the session pump.</param>
        /// <remarks>Enable prefetch to speed up the receive rate. </remarks>
        public void RegisterSessionHandler(Func<MessageSession, Message, CancellationToken, Task> handler, SessionHandlerOptions sessionHandlerOptions)
        {
            ClientEntity.ThrowIfClosed();
            this.SessionPumpHost.OnSessionHandler(handler, sessionHandlerOptions);
        }

        /// <summary>
        /// Schedules a message to appear on Service Bus at a later time.
        /// </summary>
        /// <param name="scheduleEnqueueTimeUtc">The UTC time at which the message should be available for processing</param>
        /// <returns>The sequence number of the message that was scheduled.</returns>
        public Task<long> ScheduleMessageAsync(Message message, DateTimeOffset scheduleEnqueueTimeUtc)
        {
            ClientEntity.ThrowIfClosed();
            return this.InnerSender.ScheduleMessageAsync(message, scheduleEnqueueTimeUtc);
        }

        /// <summary>
        /// Cancels a message that was scheduled.
        /// </summary>
        /// <param name="sequenceNumber">The <see cref="Message.SystemPropertiesCollection.SequenceNumber"/> of the message to be cancelled.</param>
        public Task CancelScheduledMessageAsync(long sequenceNumber)
        {
            ClientEntity.ThrowIfClosed();
            return this.InnerSender.CancelScheduledMessageAsync(sequenceNumber);
        }
        
        public Task CloseAsync() => ClientEntity.CloseAsync(OnClosingAsync);

        internal async Task OnClosingAsync()
        {
            if (this.innerSender != null)
            {
                await this.innerSender.CloseAsync().ConfigureAwait(false);
            }

            if (this.innerReceiver != null)
            {
                await this.innerReceiver.CloseAsync().ConfigureAwait(false);
            }

            this.sessionPumpHost?.Close();

            if (this.sessionClient != null)
            {
                await this.sessionClient.CloseAsync().ConfigureAwait(false);
            }
        }
    }
}
