// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Amqp;
    using Core;
    using Microsoft.Azure.Amqp;
    using Primitives;

    /// <summary>
    /// Used for all basic interactions with a Service Bus queue.
    /// </summary>
    public class QueueClient : ClientEntity, IQueueClient
    {
        readonly bool ownsConnection;
        readonly object syncLock;
        int prefetchCount;
        MessageSender innerSender;
        MessageReceiver innerReceiver;
        AmqpSessionClient sessionClient;
        SessionPumpHost sessionPumpHost;

        /// <summary>
        /// Instantiates a new <see cref="QueueClient"/> to perform operations on a queue.
        /// </summary>
        /// <param name="connectionStringBuilder"><see cref="ServiceBusConnectionStringBuilder"/> having namespace and queue information.</param>
        /// <param name="receiveMode">Mode of receive of messages. Defaults to <see cref="ReceiveMode"/>.PeekLock.</param>
        /// <param name="retryPolicy">Retry policy for queue operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        public QueueClient(ServiceBusConnectionStringBuilder connectionStringBuilder, ReceiveMode receiveMode = ReceiveMode.PeekLock, RetryPolicy retryPolicy = null)
            : this(connectionStringBuilder?.GetNamespaceConnectionString(), connectionStringBuilder?.EntityPath, receiveMode, retryPolicy)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="QueueClient"/> to perform operations on a queue.
        /// </summary>
        /// <param name="connectionString">Namespace connection string. <remarks>Should not contain queue information.</remarks></param>
        /// <param name="entityPath">Path to the queue</param>
        /// <param name="receiveMode">Mode of receive of messages. Defaults to <see cref="ReceiveMode"/>.PeekLock.</param>
        /// <param name="retryPolicy">Retry policy for queue operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        public QueueClient(string connectionString, string entityPath, ReceiveMode receiveMode = ReceiveMode.PeekLock, RetryPolicy retryPolicy = null)
            : this(new ServiceBusNamespaceConnection(connectionString), entityPath, receiveMode, retryPolicy ?? RetryPolicy.Default)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(connectionString);
            }
            if (string.IsNullOrWhiteSpace(entityPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(entityPath);
            }

            this.ownsConnection = true;
        }

        QueueClient(ServiceBusNamespaceConnection serviceBusConnection, string entityPath, ReceiveMode receiveMode, RetryPolicy retryPolicy)
            : base($"{nameof(QueueClient)}{ClientEntity.GetNextId()}({entityPath})", retryPolicy)
        {
            this.ServiceBusConnection = serviceBusConnection ?? throw new ArgumentNullException(nameof(serviceBusConnection));
            this.syncLock = new object();
            this.QueueName = entityPath;
            this.ReceiveMode = receiveMode;
            this.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                serviceBusConnection.SasKeyName,
                serviceBusConnection.SasKey);
            this.CbsTokenProvider = new TokenProviderAdapter(this.TokenProvider, serviceBusConnection.OperationTimeout);
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
        /// Gets or sets the number of messages that the queue client can simultaneously request.
        /// </summary>
        /// <value>The number of messages that the queue client can simultaneously request.</value>
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
                                MessagingEntityType.Queue,
                                this.ServiceBusConnection,
                                this.CbsTokenProvider,
                                this.RetryPolicy);
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
                                this.ServiceBusConnection,
                                this.CbsTokenProvider,
                                this.RetryPolicy,
                                this.PrefetchCount);
                        }
                    }
                }

                return this.innerReceiver;
            }
        }

        internal AmqpSessionClient SessionClient
        {
            get
            {
                if (this.sessionClient == null)
                {
                    lock (this.syncLock)
                    {
                        if (this.sessionClient == null)
                        {
                            this.sessionClient = new AmqpSessionClient(
                                this.ClientId,
                                this.Path,
                                MessagingEntityType.Queue,
                                this.ReceiveMode,
                                this.PrefetchCount,
                                this.ServiceBusConnection,
                                this.CbsTokenProvider,
                                this.RetryPolicy);
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
                                this.ClientId,
                                this.ReceiveMode,
                                this.SessionClient,
                                this.ServiceBusConnection.Endpoint.Authority);
                        }
                    }
                }

                return this.sessionPumpHost;
            }
        }

        internal ServiceBusConnection ServiceBusConnection { get; }

        ICbsTokenProvider CbsTokenProvider { get; }

        TokenProvider TokenProvider { get; }

        /// <summary></summary>
        /// <returns></returns>
        protected override async Task OnClosingAsync()
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

            if (this.ownsConnection)
            {
                await this.ServiceBusConnection.CloseAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Sends a message to Service Bus.
        /// </summary>
        /// <param name="message">The <see cref="Message"/></param>
        /// <returns>An asynchronous operation</returns>
        public Task SendAsync(Message message)
        {
            return this.SendAsync(new[] { message });
        }

        /// <summary>
        /// Sends a list of messages to Service Bus.
        /// </summary>
        /// <param name="messageList">The list of messages</param>
        /// <returns>An asynchronous operation</returns>
        public Task SendAsync(IList<Message> messageList)
        {
            return this.InnerSender.SendAsync(messageList);
        }

        /// <summary>
        /// Completes a <see cref="Message"/> using a lock token.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to complete.</param>
        /// <remarks>A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>, only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.</remarks>
        /// <returns>The asynchronous operation.</returns>
        public Task CompleteAsync(string lockToken)
        {
            return this.InnerReceiver.CompleteAsync(lockToken);
        }

        /// <summary>
        /// Abandons a <see cref="Message"/> using a lock token. This will make the message available again for processing.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to abandon.</param>
        /// <remarks>A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>, only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.</remarks>
        /// <returns>The asynchronous operation.</returns>
        public Task AbandonAsync(string lockToken)
        {
            return this.InnerReceiver.AbandonAsync(lockToken);
        }

        /// <summary>
        /// Moves a message to the deadletter queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <remarks>A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>, only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>. 
        /// In order to receive a message from the deadletter queue, you will need a new <see cref="IMessageReceiver"/>, with the corresponding path. You can use <see cref="EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.</remarks>
        /// <returns>The asynchronous operation.</returns>
        public Task DeadLetterAsync(string lockToken)
        {
            return this.InnerReceiver.DeadLetterAsync(lockToken);
        }

        /// <summary>Asynchronously processes a message.</summary>
        /// <param name="handler">A <see cref="Func{T1, T2, TResult}"/> that processes messages.</param>
        /// <param name="exceptionReceivedHandler">A <see cref="Func{T1, TResult}"/> that is used to notify exceptions.</param>
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, Func<ExceptionReceivedEventArgs, Task> exceptionReceivedHandler)
        {
            this.InnerReceiver.RegisterMessageHandler(handler, new MessageHandlerOptions(exceptionReceivedHandler));
        }

        /// <summary>Asynchronously processes a message.</summary>
        /// <param name="handler">A <see cref="Func{T1, T2, TResult}"/> that processes messages.</param>
        /// <param name="messageHandlerOptions">Options associated with message pump processing.</param>
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, MessageHandlerOptions messageHandlerOptions)
        {
            this.InnerReceiver.RegisterMessageHandler(handler, messageHandlerOptions);
        }

        /// <summary>Register a session handler.</summary>
        /// <param name="handler">A <see cref="Func{T1, T2, TResult}"/> that processes sessions.</param>
        /// <param name="exceptionReceivedHandler">A <see cref="Func{T1, TResult}"/> that is used to notify exceptions.</param>
        public void RegisterSessionHandler(Func<IMessageSession, Message, CancellationToken, Task> handler, Func<ExceptionReceivedEventArgs, Task> exceptionReceivedHandler)
        {
            var sessionHandlerOptions = new SessionHandlerOptions(exceptionReceivedHandler);
            this.RegisterSessionHandler(handler, sessionHandlerOptions);
        }

        /// <summary>Register a session handler.</summary>
        /// <param name="handler">A <see cref="Func{T1, T2, TResult}"/> that processes sessions.</param>
        /// <param name="sessionHandlerOptions">Options associated with session pump processing.</param>
        public void RegisterSessionHandler(Func<IMessageSession, Message, CancellationToken, Task> handler, SessionHandlerOptions sessionHandlerOptions)
        {
            this.SessionPumpHost.OnSessionHandler(handler, sessionHandlerOptions);
        }

        /// <summary>
        /// Sends a scheduled message
        /// </summary>
        /// <param name="message">Message to be scheduled</param>
        /// <param name="scheduleEnqueueTimeUtc">Time of enqueue</param>
        /// <returns>Sequence number that is needed for cancelling.</returns>
        public Task<long> ScheduleMessageAsync(Message message, DateTimeOffset scheduleEnqueueTimeUtc)
        {
            return this.InnerSender.ScheduleMessageAsync(message, scheduleEnqueueTimeUtc);
        }

        /// <summary>
        /// Cancels a scheduled message
        /// </summary>
        /// <param name="sequenceNumber">Returned on scheduling a message.</param>
        /// <returns></returns>
        public Task CancelScheduledMessageAsync(long sequenceNumber)
        {
            return this.InnerSender.CancelScheduledMessageAsync(sequenceNumber);
        }

        /// <summary>
        /// Registers a <see cref="ServiceBusPlugin"/> to be used for sending and receiving messages from Service Bus.
        /// </summary>
        /// <param name="serviceBusPlugin">The <see cref="ServiceBusPlugin"/> to register</param>
        public void RegisterPlugin(ServiceBusPlugin serviceBusPlugin)
        {
            this.InnerSender.RegisterPlugin(serviceBusPlugin);
            this.InnerReceiver.RegisterPlugin(serviceBusPlugin);
        }

        /// <summary>
        /// Unregisters a <see cref="ServiceBusPlugin"/>.
        /// </summary>
        /// <param name="serviceBusPluginName">The name <see cref="ServiceBusPlugin.Name"/> to be unregistered</param>
        public void UnregisterPlugin(string serviceBusPluginName)
        {
            this.InnerSender.UnregisterPlugin(serviceBusPluginName);
            this.InnerReceiver.UnregisterPlugin(serviceBusPluginName);
        }
    }
}