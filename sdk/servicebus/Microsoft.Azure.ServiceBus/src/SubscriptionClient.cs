// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.ServiceBus.Amqp;
    using Microsoft.Azure.ServiceBus.Core;
    using Microsoft.Azure.ServiceBus.Primitives;

    /// <summary>
    /// SubscriptionClient can be used for all basic interactions with a Service Bus Subscription.
    /// </summary>
    /// <example>
    /// Create a new SubscriptionClient
    /// <code>
    /// ISubscriptionClient subscriptionClient = new SubscriptionClient(
    ///     namespaceConnectionString,
    ///     topicName,
    ///     subscriptionName,
    ///     ReceiveMode.PeekLock,
    ///     RetryExponential);
    /// </code>
    ///
    /// Register a message handler which will be invoked every time a message is received.
    /// <code>
    /// subscriptionClient.RegisterMessageHandler(
    ///        async (message, token) =&gt;
    ///        {
    ///            // Process the message
    ///            Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
    ///
    ///            // Complete the message so that it is not received again.
    ///            // This can be done only if the subscriptionClient is opened in ReceiveMode.PeekLock mode.
    ///            await subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
    ///        },
    ///        async (exceptionEvent) =&gt;
    ///        {
    ///            // Process the exception
    ///            Console.WriteLine("Exception = " + exceptionEvent.Exception);
    ///            return Task.CompletedTask;
    ///        });
    /// </code>
    /// </example>
    /// <remarks>It uses AMQP protocol for communicating with service bus. Use <see cref="MessageReceiver"/> for advanced set of functionality.</remarks>
    public class SubscriptionClient : ClientEntity, ISubscriptionClient
    {
        int prefetchCount;
        readonly object syncLock;
        readonly ServiceBusDiagnosticSource diagnosticSource;

        IInnerSubscriptionClient innerSubscriptionClient;
        SessionClient sessionClient;
        SessionPumpHost sessionPumpHost;

        /// <summary>
        /// Instantiates a new <see cref="SubscriptionClient"/> to perform operations on a subscription.
        /// </summary>
        /// <param name="connectionStringBuilder"><see cref="ServiceBusConnectionStringBuilder"/> having namespace and topic information.</param>
        /// <param name="receiveMode">Mode of receive of messages. Defaults to <see cref="ReceiveMode"/>.PeekLock.</param>
        /// <param name="retryPolicy">Retry policy for subscription operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <remarks>Creates a new connection to the subscription, which is opened during the first receive operation.</remarks>
        public SubscriptionClient(ServiceBusConnectionStringBuilder connectionStringBuilder, string subscriptionName, ReceiveMode receiveMode = ReceiveMode.PeekLock, RetryPolicy retryPolicy = null)
            : this(connectionStringBuilder?.GetNamespaceConnectionString(), connectionStringBuilder?.EntityPath, subscriptionName, receiveMode, retryPolicy)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="SubscriptionClient"/> to perform operations on a subscription.
        /// </summary>
        /// <param name="connectionString">Namespace connection string. Must not contain topic or subscription information.</param>
        /// <param name="receiveMode">Mode of receive of messages. Defaults to <see cref="ReceiveMode"/>.PeekLock.</param>
        /// <param name="retryPolicy">Retry policy for subscription operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <remarks>Creates a new connection to the subscription, which is opened during the first receive operation.</remarks>
        public SubscriptionClient(string connectionString, string topicPath, string subscriptionName, ReceiveMode receiveMode = ReceiveMode.PeekLock, RetryPolicy retryPolicy = null)
            : this(new ServiceBusConnection(connectionString), topicPath, subscriptionName, receiveMode, retryPolicy ?? RetryPolicy.Default)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(connectionString);
            }

            this.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new instance of the Subscription client using the specified endpoint, entity path, and token provider.
        /// </summary>
        /// <param name="endpoint">Fully qualified domain name for Service Bus. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="topicPath">Topic path.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        /// <param name="transportType">Transport type.</param>
        /// <param name="receiveMode">Mode of receive of messages. Defaults to <see cref="ReceiveMode"/>.PeekLock.</param>
        /// <param name="retryPolicy">Retry policy for subscription operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        /// <remarks>Creates a new connection to the subscription, which is opened during the first receive operation.</remarks>
        public SubscriptionClient(
            string endpoint,
            string topicPath,
            string subscriptionName,
            ITokenProvider tokenProvider,
            TransportType transportType = TransportType.Amqp,
            ReceiveMode receiveMode = ReceiveMode.PeekLock,
            RetryPolicy retryPolicy = null)
            : this(new ServiceBusConnection(endpoint, transportType, retryPolicy) {TokenProvider = tokenProvider}, topicPath, subscriptionName, receiveMode, retryPolicy)
        {
            this.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new instance of the Subscription client on a given <see cref="ServiceBusConnection"/>
        /// </summary>
        /// <param name="serviceBusConnection">Connection object to the service bus namespace.</param>
        /// <param name="topicPath">Topic path.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        /// <param name="receiveMode">Mode of receive of messages. Defaults to <see cref="ReceiveMode"/>.PeekLock.</param>
        /// <param name="retryPolicy">Retry policy for subscription operations. Defaults to <see cref="RetryPolicy.Default"/></param>
        public SubscriptionClient(ServiceBusConnection serviceBusConnection, string topicPath, string subscriptionName, ReceiveMode receiveMode, RetryPolicy retryPolicy)
            : base(nameof(SubscriptionClient), $"{topicPath}/{subscriptionName}", retryPolicy)
        {
            if (string.IsNullOrWhiteSpace(topicPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(topicPath);
            }
            if (string.IsNullOrWhiteSpace(subscriptionName))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(subscriptionName);
            }

            MessagingEventSource.Log.SubscriptionClientCreateStart(serviceBusConnection?.Endpoint.Authority, topicPath, subscriptionName, receiveMode.ToString());

            this.ServiceBusConnection = serviceBusConnection ?? throw new ArgumentNullException(nameof(serviceBusConnection));
            this.syncLock = new object();
            this.TopicPath = topicPath;
            this.SubscriptionName = subscriptionName;
            this.Path = EntityNameHelper.FormatSubscriptionPath(this.TopicPath, this.SubscriptionName);
            this.ReceiveMode = receiveMode;
            this.diagnosticSource = new ServiceBusDiagnosticSource(this.Path, serviceBusConnection.Endpoint);
            this.OwnsConnection = false;
            this.ServiceBusConnection.ThrowIfClosed();

            if (this.ServiceBusConnection.TokenProvider != null)
            {
                this.CbsTokenProvider = new TokenProviderAdapter(this.ServiceBusConnection.TokenProvider, this.ServiceBusConnection.OperationTimeout);
            }
            else
            {
                throw new ArgumentNullException($"{nameof(ServiceBusConnection)} doesn't have a valid token provider");
            }

            MessagingEventSource.Log.SubscriptionClientCreateStop(serviceBusConnection.Endpoint.Authority, topicPath, subscriptionName, this.ClientId);
        }

        /// <summary>
        /// Gets the path of the corresponding topic.
        /// </summary>
        public string TopicPath { get; }

        /// <summary>
        /// Gets the formatted path of the subscription client.
        /// </summary>
        /// <seealso cref="EntityNameHelper.FormatSubscriptionPath(string, string)"/>
        public override string Path { get; }

        /// <summary>
        /// Gets the name of the subscription.
        /// </summary>
        public string SubscriptionName { get; }

        /// <summary>
        /// Gets the <see cref="ServiceBus.ReceiveMode"/> for the SubscriptionClient.
        /// </summary>
        public ReceiveMode ReceiveMode { get; }

        /// <summary>
        /// Duration after which individual operations will timeout.
        /// </summary>
        public override TimeSpan OperationTimeout
        {
            get => this.ServiceBusConnection.OperationTimeout;
            set => this.ServiceBusConnection.OperationTimeout = value;
        }

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
                if (this.innerSubscriptionClient != null)
                {
                    this.innerSubscriptionClient.PrefetchCount = value;
                }
                if (this.sessionClient != null)
                {
                    this.sessionClient.PrefetchCount = value;
                }
            }
        }

        /// <summary>
        /// Connection object to the service bus namespace.
        /// </summary>
        public override ServiceBusConnection ServiceBusConnection { get; }

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
                                this.RetryPolicy,
                                this.RegisteredPlugins);
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
                                this.ServiceBusConnection.Endpoint);
                        }
                    }
                }

                return this.sessionPumpHost;
            }
        }

        ICbsTokenProvider CbsTokenProvider { get; }

        /// <summary>
        /// Completes a <see cref="Message"/> using its lock token. This will delete the message from the subscription.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to complete.</param>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// This operation can only be performed on messages that were received by this client.
        /// </remarks>
        public Task CompleteAsync(string lockToken)
        {
            this.ThrowIfClosed();
            return this.InnerSubscriptionClient.InnerReceiver.CompleteAsync(lockToken);
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
        public Task AbandonAsync(string lockToken, IDictionary<string, object> propertiesToModify = null)
        {
            this.ThrowIfClosed();
            return this.InnerSubscriptionClient.InnerReceiver.AbandonAsync(lockToken, propertiesToModify);
        }

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// In order to receive a message from the deadletter sub-queue, you will need a new <see cref="IMessageReceiver"/> or <see cref="ISubscriptionClient"/>, with the corresponding path.
        /// You can use <see cref="EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.
        /// This operation can only be performed on messages that were received by this client.
        /// </remarks>
        public Task DeadLetterAsync(string lockToken)
        {
            this.ThrowIfClosed();
            return this.InnerSubscriptionClient.InnerReceiver.DeadLetterAsync(lockToken);
        }

        /// <summary>
        /// Moves a message to the deadletter sub-queue.
        /// </summary>
        /// <param name="lockToken">The lock token of the corresponding message to deadletter.</param>
        /// <param name="propertiesToModify">The properties of the message to modify while moving to sub-queue.</param>
        /// <remarks>
        /// A lock token can be found in <see cref="Message.SystemPropertiesCollection.LockToken"/>,
        /// only when <see cref="ReceiveMode"/> is set to <see cref="ServiceBus.ReceiveMode.PeekLock"/>.
        /// In order to receive a message from the deadletter queue, you will need a new <see cref="IMessageReceiver"/>, with the corresponding path.
        /// You can use <see cref="EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public Task DeadLetterAsync(string lockToken, IDictionary<string, object> propertiesToModify)
        {
            this.ThrowIfClosed();
            return this.InnerSubscriptionClient.InnerReceiver.DeadLetterAsync(lockToken, propertiesToModify);
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
        /// In order to receive a message from the deadletter queue, you will need a new <see cref="IMessageReceiver"/>, with the corresponding path.
        /// You can use <see cref="EntityNameHelper.FormatDeadLetterPath(string)"/> to help with this.
        /// This operation can only be performed on messages that were received by this receiver.
        /// </remarks>
        public Task DeadLetterAsync(string lockToken, string deadLetterReason, string deadLetterErrorDescription = null)
        {
            this.ThrowIfClosed();
            return this.InnerSubscriptionClient.InnerReceiver.DeadLetterAsync(lockToken, deadLetterReason, deadLetterErrorDescription);
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
            this.ThrowIfClosed();
            this.InnerSubscriptionClient.InnerReceiver.RegisterMessageHandler(handler, exceptionReceivedHandler);
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
            this.ThrowIfClosed();
            this.InnerSubscriptionClient.InnerReceiver.RegisterMessageHandler(handler, messageHandlerOptions);
        }

        /// <summary>
        /// Unregister messgae hander from the receiver if there is active message handler registered. 
        /// </summary>
        public async Task UnregisterMessageHandler()
        {
            this.ThrowIfClosed();
            await this.InnerSubscriptionClient.InnerReceiver.UnregisterMessageHandler();
        }

        /// <summary>
        /// Receive session messages continuously from the queue. Registers a message handler and begins a new thread to receive session-messages.
        /// This handler(<see cref="Func{IMessageSession, Message, CancellationToken, Task}"/>) is awaited on every time a new message is received by the subscription client.
        /// </summary>
        /// <param name="handler">A <see cref="Func{IMessageSession, Message, CancellationToken, Task}"/> that processes messages.
        /// <see cref="IMessageSession"/> contains the session information, and must be used to perform Complete/Abandon/Deadletter or other such operations on the <see cref="Message"/></param>
        /// <param name="exceptionReceivedHandler">A <see cref="Func{T1, TResult}"/> that is invoked during exceptions.
        /// <see cref="ExceptionReceivedEventArgs"/> contains contextual information regarding the exception.</param>
        /// <remarks>  Enable prefetch to speed up the receive rate.
        /// Use <see cref="RegisterSessionHandler(Func{IMessageSession,Message,CancellationToken,Task}, SessionHandlerOptions)"/> to configure the settings of the pump.</remarks>
        public void RegisterSessionHandler(Func<IMessageSession, Message, CancellationToken, Task> handler, Func<ExceptionReceivedEventArgs, Task> exceptionReceivedHandler)
        {
            var sessionHandlerOptions = new SessionHandlerOptions(exceptionReceivedHandler);
            this.RegisterSessionHandler(handler, sessionHandlerOptions);
        }

        /// <summary>
        /// Receive session messages continuously from the queue. Registers a message handler and begins a new thread to receive session-messages.
        /// This handler(<see cref="Func{IMessageSession, Message, CancellationToken, Task}"/>) is awaited on every time a new message is received by the subscription client.
        /// </summary>
        /// <param name="handler">A <see cref="Func{IMessageSession, Message, CancellationToken, Task}"/> that processes messages.
        /// <see cref="IMessageSession"/> contains the session information, and must be used to perform Complete/Abandon/Deadletter or other such operations on the <see cref="Message"/></param>
        /// <param name="sessionHandlerOptions">Options used to configure the settings of the session pump.</param>
        /// <remarks>Enable prefetch to speed up the receive rate. </remarks>
        public void RegisterSessionHandler(Func<IMessageSession, Message, CancellationToken, Task> handler, SessionHandlerOptions sessionHandlerOptions)
        {
            this.ThrowIfClosed();
            this.SessionPumpHost.OnSessionHandler(handler, sessionHandlerOptions);
        }

        /// <summary>
        /// Adds a rule to the current subscription to filter the messages reaching from topic to the subscription.
        /// </summary>
        /// <param name="filter">The filter expression against which messages will be matched.</param>
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        /// <remarks>
        /// You can add rules to the subscription that decides which messages from the topic should reach the subscription.
        /// A default <see cref="TrueFilter"/> rule named <see cref="RuleDescription.DefaultRuleName"/> is always added while creation of the Subscription.
        /// You can add multiple rules with distinct names to the same subscription.
        /// Multiple filters combine with each other using logical OR condition. i.e., If any filter succeeds, the message is passed on to the subscription.
        /// Max allowed length of rule name is 50 chars.
        /// </remarks>
        public Task AddRuleAsync(string ruleName, Filter filter)
        {
            return this.AddRuleAsync(new RuleDescription(name: ruleName, filter: filter));
        }

        /// <summary>
        /// Adds a rule to the current subscription to filter the messages reaching from topic to the subscription.
        /// </summary>
        /// <param name="description">The rule description that provides the rule to add.</param>
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        /// <remarks>
        /// You can add rules to the subscription that decides which messages from the topic should reach the subscription.
        /// A default <see cref="TrueFilter"/> rule named <see cref="RuleDescription.DefaultRuleName"/> is always added while creation of the Subscription.
        /// You can add multiple rules with distinct names to the same subscription.
        /// Multiple filters combine with each other using logical OR condition. i.e., If any filter succeeds, the message is passed on to the subscription.
        /// </remarks>
        public async Task AddRuleAsync(RuleDescription description)
        {
            this.ThrowIfClosed();

            if (description == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(description));
            }

            EntityNameHelper.CheckValidRuleName(description.Name);
            MessagingEventSource.Log.AddRuleStart(this.ClientId, description.Name);

            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.AddRuleStart(description) : null;
            Task addRuleTask = null;

            try
            {
                addRuleTask = this.InnerSubscriptionClient.OnAddRuleAsync(description);
                await addRuleTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.AddRuleException(this.ClientId, exception);
                throw;
            }
            finally
            {
                this.diagnosticSource.AddRuleStop(activity, description, addRuleTask?.Status);
            }

            MessagingEventSource.Log.AddRuleStop(this.ClientId);
        }

        /// <summary>
        /// Removes the rule on the subscription identified by <paramref name="ruleName" />.
        /// </summary>
        /// <returns>A task instance that represents the asynchronous remove rule operation.</returns>
        public async Task RemoveRuleAsync(string ruleName)
        {
            this.ThrowIfClosed();

            if (string.IsNullOrWhiteSpace(ruleName))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(ruleName));
            }

            MessagingEventSource.Log.RemoveRuleStart(this.ClientId, ruleName);
            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.RemoveRuleStart(ruleName) : null;
            Task removeRuleTask = null;

            try
            {
                removeRuleTask = this.InnerSubscriptionClient.OnRemoveRuleAsync(ruleName);
                await removeRuleTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.RemoveRuleException(this.ClientId, exception);

                throw;
            }
            finally
            {
                this.diagnosticSource.RemoveRuleStop(activity, ruleName, removeRuleTask?.Status);
            }

            MessagingEventSource.Log.RemoveRuleStop(this.ClientId);
        }

        /// <summary>
        /// Get all rules associated with the subscription.
        /// </summary>
        public async Task<IEnumerable<RuleDescription>> GetRulesAsync()
        {
            this.ThrowIfClosed();

            MessagingEventSource.Log.GetRulesStart(this.ClientId);
            bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
            Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.GetRulesStart() : null;
            Task<IList<RuleDescription>> getRulesTask = null;

            var skip = 0;
            var top = int.MaxValue;
            IList<RuleDescription> rules = null;

            try
            {
                getRulesTask = this.InnerSubscriptionClient.OnGetRulesAsync(top, skip);
                rules = await getRulesTask.ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                if (isDiagnosticSourceEnabled)
                {
                    this.diagnosticSource.ReportException(exception);
                }

                MessagingEventSource.Log.GetRulesException(this.ClientId, exception);

                throw;
            }
            finally
            {
                this.diagnosticSource.GetRulesStop(activity, rules, getRulesTask?.Status);
            }

            MessagingEventSource.Log.GetRulesStop(this.ClientId);
            return rules;
        }

        /// <summary>
        /// Gets a list of currently registered plugins for this SubscriptionClient.
        /// </summary>
        public override IList<ServiceBusPlugin> RegisteredPlugins => this.InnerSubscriptionClient.InnerReceiver.RegisteredPlugins;

        /// <summary>
        /// Registers a <see cref="ServiceBusPlugin"/> to be used for receiving messages from Service Bus.
        /// </summary>
        /// <param name="serviceBusPlugin">The <see cref="ServiceBusPlugin"/> to register</param>
        public override void RegisterPlugin(ServiceBusPlugin serviceBusPlugin)
        {
            this.ThrowIfClosed();
            this.InnerSubscriptionClient.InnerReceiver.RegisterPlugin(serviceBusPlugin);
        }

        /// <summary>
        /// Unregisters a <see cref="ServiceBusPlugin"/>.
        /// </summary>
        /// <param name="serviceBusPluginName">The name <see cref="ServiceBusPlugin.Name"/> to be unregistered</param>
        public override void UnregisterPlugin(string serviceBusPluginName)
        {
            this.ThrowIfClosed();
            this.InnerSubscriptionClient.InnerReceiver.UnregisterPlugin(serviceBusPluginName);
        }

        protected override async Task OnClosingAsync()
        {
            if (this.innerSubscriptionClient != null)
            {
                await this.innerSubscriptionClient.CloseAsync().ConfigureAwait(false);
            }

            this.sessionPumpHost?.Close();

            if (this.sessionClient != null)
            {
                await this.sessionClient.CloseAsync().ConfigureAwait(false);
            }
        }
    }
}