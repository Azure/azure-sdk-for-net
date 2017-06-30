// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.ServiceBus.Amqp;
    using Microsoft.Azure.ServiceBus.Core;
    using Microsoft.Azure.ServiceBus.Filters;
    using Microsoft.Azure.ServiceBus.Primitives;

    /// <summary>
    /// Used for all basic interactions with a Service Bus subscription.
    /// </summary>
    public class SubscriptionClient : ClientEntity, ISubscriptionClient
    {
        /// <summary>
        /// Gets the name of the default rule on the subscription.
        /// </summary>
        public const string DefaultRule = "$Default";
        int prefetchCount;
        readonly object syncLock;
        readonly bool ownsConnection;
        IInnerSubscriptionClient innerSubscriptionClient;
        SessionClient sessionClient;
        SessionPumpHost sessionPumpHost;

        /// <summary>
        /// Instantiates a new <see cref="SubscriptionClient"/> to perform operations on a subscription.
        /// </summary>
        /// <param name="connectionStringBuilder"><see cref="ServiceBusConnectionStringBuilder"/> having namespace and topic information.</param>
        /// <param name="subscriptionName">Name of the subscription.</param>
        /// <param name="receiveMode">Mode of receive of messages. Defaults to <see cref="ReceiveMode"/>.PeekLock.</param>
        /// <param name="retryPolicy">Retry policy for subscription operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        public SubscriptionClient(ServiceBusConnectionStringBuilder connectionStringBuilder, string subscriptionName, ReceiveMode receiveMode = ReceiveMode.PeekLock, RetryPolicy retryPolicy = null)
            : this(connectionStringBuilder?.GetNamespaceConnectionString(), connectionStringBuilder?.EntityPath, subscriptionName, receiveMode, retryPolicy)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="SubscriptionClient"/> to perform operations on a subscription.
        /// </summary>
        /// <param name="connectionString">Namespace connection string. <remarks>Should not contain topic information.</remarks></param>
        /// <param name="topicPath">Path to the topic.</param>
        /// <param name="subscriptionName">Name of the subscription.</param>
        /// <param name="receiveMode">Mode of receive of messages. Defaults to <see cref="ReceiveMode"/>.PeekLock.</param>
        /// <param name="retryPolicy">Retry policy for subscription operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        public SubscriptionClient(string connectionString, string topicPath, string subscriptionName, ReceiveMode receiveMode = ReceiveMode.PeekLock, RetryPolicy retryPolicy = null)
            : this(new ServiceBusNamespaceConnection(connectionString), topicPath, subscriptionName, receiveMode, retryPolicy ?? RetryPolicy.Default)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(connectionString);
            }
            if (string.IsNullOrWhiteSpace(topicPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(topicPath);
            }
            if (string.IsNullOrWhiteSpace(subscriptionName))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(subscriptionName);
            }

            this.ownsConnection = true;
        }

        SubscriptionClient(ServiceBusNamespaceConnection serviceBusConnection, string topicPath, string subscriptionName, ReceiveMode receiveMode, RetryPolicy retryPolicy)
            : base($"{nameof(SubscriptionClient)}{ClientEntity.GetNextId()}({subscriptionName})", retryPolicy)
        {
            this.ServiceBusConnection = serviceBusConnection ?? throw new ArgumentNullException(nameof(serviceBusConnection));
            this.syncLock = new object();
            this.TopicPath = topicPath;
            this.SubscriptionName = subscriptionName;
            this.Path = EntityNameHelper.FormatSubscriptionPath(this.TopicPath, this.SubscriptionName);
            this.ReceiveMode = receiveMode;
            this.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                serviceBusConnection.SasKeyName,
                serviceBusConnection.SasKey);
            this.CbsTokenProvider = new TokenProviderAdapter(this.TokenProvider, serviceBusConnection.OperationTimeout);
        }

        /// <summary>
        /// Gets the path of the corresponding topic.
        /// </summary>
        public string TopicPath { get; }

        /// <summary>
        /// Gets the path of the subscription client.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Gets the name of the subscription.
        /// </summary>
        public string SubscriptionName { get; }

        /// <summary>
        /// Gets the <see cref="ReceiveMode.ReceiveMode"/> for the SubscriptionClient.
        /// </summary>
        public ReceiveMode ReceiveMode { get; }

        /// <summary>
        /// Gets or sets the number of messages that the subscription client can simultaneously request.
        /// </summary>
        /// <value>The number of messages that the subscription client can simultaneously request.</value>
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
                if (this.innerSubscriptionClient != null)
                {
                    this.innerSubscriptionClient.PrefetchCount = value;
                }
            }
        }

        internal IInnerSubscriptionClient InnerSubscriptionClient
        {
            get
            {
                if (this.innerSubscriptionClient == null)
                {
                    lock (this.syncLock)
                    {
                        this.innerSubscriptionClient = new AmqpSubscriptionClient(
                            this.Path,
                            this.ServiceBusConnection,
                            this.RetryPolicy,
                            this.CbsTokenProvider,
                            this.PrefetchCount,
                            this.ReceiveMode);
                    }
                }

                return this.innerSubscriptionClient;
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
                                this.ClientId,
                                this.Path,
                                MessagingEntityType.Subscriber,
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

        internal ServiceBusNamespaceConnection ServiceBusConnection { get; }

        ICbsTokenProvider CbsTokenProvider { get; }

        TokenProvider TokenProvider { get; }

        /// <summary></summary>
        /// <returns></returns>
        protected override async Task OnClosingAsync()
        {
            if (this.innerSubscriptionClient != null)
            {
                await this.innerSubscriptionClient.CloseAsync().ConfigureAwait(false);
            }

            this.sessionPumpHost?.Close();

            if (this.ownsConnection)
            {
                await this.ServiceBusConnection.CloseAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Completes a <see cref="Message"/> using a lock token.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to complete.</param>
        /// <remarks>A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>, only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.</remarks>
        /// <returns>The asynchronous operation.</returns>
        public Task CompleteAsync(string lockToken)
        {
            return this.InnerSubscriptionClient.InnerReceiver.CompleteAsync(lockToken);
        }

        /// <summary>
        /// Abandons a <see cref="Message"/> using a lock token. This will make the message available again for processing.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to abandon.</param>
        /// <remarks>A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>, only when <see cref="ReceiveMode"/> is set to <see cref="ReceiveMode.PeekLock"/>.</remarks>
        /// <returns>The asynchronous operation.</returns>
        public Task AbandonAsync(string lockToken)
        {
            return this.InnerSubscriptionClient.InnerReceiver.AbandonAsync(lockToken);
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
            return this.InnerSubscriptionClient.InnerReceiver.DeadLetterAsync(lockToken);
        }

        /// <summary>Asynchronously processes a message.</summary>
        /// <param name="handler">A <see cref="Func{T1, T2, TResult}"/> that processes messages.</param>
        /// <param name="exceptionReceivedHandler">A <see cref="Func{T1, TResult}"/> that is used to notify exceptions.</param>
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, Func<ExceptionReceivedEventArgs, Task> exceptionReceivedHandler)
        {
            this.InnerSubscriptionClient.InnerReceiver.RegisterMessageHandler(handler, exceptionReceivedHandler);
        }

        /// <summary>Asynchronously processes a message.</summary>
        /// <param name="handler">A <see cref="Func{T1, T2, TResult}"/> that processes messages.</param>
        /// <param name="registerHandlerOptions">Calls a message option.</param>
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, MessageHandlerOptions registerHandlerOptions)
        {
            this.InnerSubscriptionClient.InnerReceiver.RegisterMessageHandler(handler, registerHandlerOptions);
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
        /// Asynchronously adds a rule to the current subscription with the specified name and filter expression.
        /// </summary>
        /// <param name="ruleName">The name of the rule to add.</param>
        /// <param name="filter">The filter expression against which messages will be matched.</param>
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        public Task AddRuleAsync(string ruleName, Filter filter)
        {
            return this.AddRuleAsync(new RuleDescription(name: ruleName, filter: filter));
        }

        /// <summary>
        /// Asynchronously adds a new rule to the subscription using the specified rule description.
        /// </summary>
        /// <param name="description">The rule description that provides metadata of the rule to add.</param>
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        public async Task AddRuleAsync(RuleDescription description)
        {
            if (description == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(description));
            }

            description.ValidateDescriptionName();
            MessagingEventSource.Log.AddRuleStart(this.ClientId, description.Name);

            try
            {
                await this.InnerSubscriptionClient.OnAddRuleAsync(description).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.AddRuleException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.AddRuleStop(this.ClientId);
        }

        /// <summary>
        /// Asynchronously removes the rule described by <paramref name="ruleName" />.
        /// </summary>
        /// <param name="ruleName">The name of the rule.</param>
        /// <returns>A task instance that represents the asynchronous remove rule operation.</returns>
        public async Task RemoveRuleAsync(string ruleName)
        {
            if (string.IsNullOrWhiteSpace(ruleName))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(ruleName));
            }

            MessagingEventSource.Log.RemoveRuleStart(this.ClientId, ruleName);

            try
            {
                await this.InnerSubscriptionClient.OnRemoveRuleAsync(ruleName).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.RemoveRuleException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.RemoveRuleStop(this.ClientId);
        }

        /// <summary>
        /// Registers a <see cref="ServiceBusPlugin"/> to be used for receiving messages from Service Bus.
        /// </summary>
        /// <param name="serviceBusPlugin">The <see cref="ServiceBusPlugin"/> to register</param>
        public void RegisterPlugin(ServiceBusPlugin serviceBusPlugin)
        {
            this.InnerSubscriptionClient.InnerReceiver.RegisterPlugin(serviceBusPlugin);
        }

        /// <summary>
        /// Unregisters a <see cref="ServiceBusPlugin"/>.
        /// </summary>
        /// <param name="serviceBusPluginName">The name <see cref="ServiceBusPlugin.Name"/> to be unregistered</param>
        public void UnregisterPlugin(string serviceBusPluginName)
        {
            this.InnerSubscriptionClient.InnerReceiver.UnregisterPlugin(serviceBusPluginName);
        }
    }
}