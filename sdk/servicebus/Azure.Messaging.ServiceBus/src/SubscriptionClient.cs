// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Azure.Messaging.ServiceBus.Amqp;
    using Azure.Messaging.ServiceBus.Core;
    using Azure.Messaging.ServiceBus.Primitives;

    /// <summary>
    /// SubscriptionClient can be used for all basic interactions with a Service Bus Subscription.
    /// </summary>
    /// <example>
    /// Create a new SubscriptionClient
    /// <code>
    /// SubscriptionClient subscriptionClient = new SubscriptionClient(
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
    ///            Console.WriteLine($"Received message: SequenceNumber:{message.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
    ///
    ///            // Complete the message so that it is not received again.
    ///            // This can be done only if the subscriptionClient is opened in ReceiveMode.PeekLock mode.
    ///            await subscriptionClient.CompleteAsync(message.LockToken);
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
    public class SubscriptionClient: IAsyncDisposable
    {
        private readonly object syncLock;

        private readonly ServiceBusDiagnosticSource diagnosticSource;

        private AmqpSubscriptionClient innerSubscriptionClient;

        internal ClientEntity ClientEntity { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="SubscriptionClient"/> to perform operations on a subscription.
        /// </summary>
        /// <param name="connectionStringBuilder"><see cref="ServiceBusConnectionStringBuilder"/> having namespace and topic information.</param>
        /// <remarks>Creates a new connection to the subscription, which is opened during the first receive operation.</remarks>
        internal SubscriptionClient(ServiceBusConnectionStringBuilder connectionStringBuilder, string subscriptionName, AmqpClientOptions options = null)
            : this(connectionStringBuilder?.GetNamespaceConnectionString(), connectionStringBuilder?.EntityPath, subscriptionName, options)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="SubscriptionClient"/> to perform operations on a subscription.
        /// </summary>
        /// <param name="connectionString">Namespace connection string. Must not contain topic or subscription information.</param>
        /// <remarks>Creates a new connection to the subscription, which is opened during the first receive operation.</remarks>
        public SubscriptionClient(string connectionString, string topicPath, string subscriptionName, AmqpClientOptions options = null)
            : this(new ServiceBusConnection(new ServiceBusConnectionStringBuilder(connectionString), options), topicPath, subscriptionName, options)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(connectionString);
            }

            ClientEntity.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new instance of the Subscription client using the specified endpoint, entity path, and token provider.
        /// </summary>
        /// <param name="endpoint">Fully qualified domain name for Service Bus. Most likely, {yournamespace}.servicebus.windows.net</param>
        /// <param name="topicPath">Topic path.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        /// <param name="tokenProvider">Token provider which will generate security tokens for authorization.</param>
        /// <remarks>Creates a new connection to the subscription, which is opened during the first receive operation.</remarks>
        public SubscriptionClient(
            string endpoint,
            string topicPath,
            string subscriptionName,
            TokenCredential tokenProvider,
            AmqpClientOptions options)
            : this(new ServiceBusConnection(endpoint, tokenProvider, options), topicPath, subscriptionName, options)
        {
            ClientEntity.OwnsConnection = true;
        }

        /// <summary>
        /// Creates a new instance of the Subscription client on a given <see cref="ServiceBusConnection"/>
        /// </summary>
        /// <param name="serviceBusConnection">Connection object to the service bus namespace.</param>
        /// <param name="topicPath">Topic path.</param>
        /// <param name="subscriptionName">Subscription name.</param>
        internal SubscriptionClient(ServiceBusConnection serviceBusConnection, string topicPath, string subscriptionName, AmqpClientOptions options)
        {
            ClientEntity = new ClientEntity(options, $"{topicPath}/{subscriptionName}");
            if (string.IsNullOrWhiteSpace(topicPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(topicPath);
            }
            if (string.IsNullOrWhiteSpace(subscriptionName))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(subscriptionName);
            }

            MessagingEventSource.Log.SubscriptionClientCreateStart(serviceBusConnection?.Endpoint.Authority, topicPath, subscriptionName, "Unknows");

            ClientEntity.ServiceBusConnection = serviceBusConnection ?? throw new ArgumentNullException(nameof(serviceBusConnection));
            this.syncLock = new object();
            this.TopicPath = topicPath;
            this.SubscriptionName = subscriptionName;
            this.Path = EntityNameHelper.FormatSubscriptionPath(this.TopicPath, this.SubscriptionName);
            this.diagnosticSource = new ServiceBusDiagnosticSource(this.Path, serviceBusConnection.Endpoint);
            ClientEntity.OwnsConnection = false;
            ClientEntity.ServiceBusConnection.ThrowIfClosed();

            MessagingEventSource.Log.SubscriptionClientCreateStop(serviceBusConnection.Endpoint.Authority, topicPath, subscriptionName, ClientEntity.ClientId);
        }

        /// <summary>
        /// Gets the path of the corresponding topic.
        /// </summary>
        public string TopicPath { get; }

        /// <summary>
        /// Gets the formatted path of the subscription client.
        /// </summary>
        /// <seealso cref="EntityNameHelper.FormatSubscriptionPath(string, string)"/>
        public string Path { get; }

        /// <summary>
        /// Gets the name of the subscription.
        /// </summary>
        public string SubscriptionName { get; }

        internal AmqpSubscriptionClient InnerSubscriptionClient
        {
            get
            {
                if (this.innerSubscriptionClient == null)
                {
                    lock (this.syncLock)
                    {
                        this.innerSubscriptionClient = new AmqpSubscriptionClient(
                            this.Path,
                            ClientEntity.ServiceBusConnection,
                            ClientEntity.Options,
                            // TODO: if should matter
                            0, // 
                            ReceiveMode.PeekLock);
                    }
                }

                return this.innerSubscriptionClient;
            }
        }

        public MessageReceiver CreateReceiver(ReceiveMode receiveMode = ReceiveMode.PeekLock, ReceiveOptions receiveOptions = null)
        {
            receiveOptions ??= ReceiveOptions.Default;

            return new MessageReceiver(
                this.Path,
                MessagingEntityType.Subscriber,
                receiveMode,
                ClientEntity.ServiceBusConnection,
                ClientEntity.Options,
                receiveOptions.PrefetchCount);
        }

        internal SessionClient CreateSessionClient(ReceiveMode receiveMode = ReceiveMode.PeekLock, ReceiveOptions receiveOptions = null)
        {            
            receiveOptions ??= ReceiveOptions.Default;

            return new SessionClient(
                ClientEntity.ClientId,
                this.Path,
                MessagingEntityType.Subscriber,
                receiveMode,
                receiveOptions.PrefetchCount,
                ClientEntity.ServiceBusConnection,
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
            ClientEntity.ThrowIfClosed();

            if (description == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(description));
            }

            EntityNameHelper.CheckValidRuleName(description.Name);
            MessagingEventSource.Log.AddRuleStart(ClientEntity.ClientId, description.Name);

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

                MessagingEventSource.Log.AddRuleException(ClientEntity.ClientId, exception);
                throw;
            }
            finally
            {
                this.diagnosticSource.AddRuleStop(activity, description, addRuleTask?.Status);
            }

            MessagingEventSource.Log.AddRuleStop(ClientEntity.ClientId);
        }

        /// <summary>
        /// Removes the rule on the subscription identified by <paramref name="ruleName" />.
        /// </summary>
        /// <returns>A task instance that represents the asynchronous remove rule operation.</returns>
        public async Task RemoveRuleAsync(string ruleName)
        {
            ClientEntity.ThrowIfClosed();

            if (string.IsNullOrWhiteSpace(ruleName))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(ruleName));
            }

            MessagingEventSource.Log.RemoveRuleStart(ClientEntity.ClientId, ruleName);
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

                MessagingEventSource.Log.RemoveRuleException(ClientEntity.ClientId, exception);

                throw;
            }
            finally
            {
                this.diagnosticSource.RemoveRuleStop(activity, ruleName, removeRuleTask?.Status);
            }

            MessagingEventSource.Log.RemoveRuleStop(ClientEntity.ClientId);
        }

        /// <summary>
        /// Get all rules associated with the subscription.
        /// </summary>
        public async Task<IEnumerable<RuleDescription>> GetRulesAsync()
        {
            ClientEntity.ThrowIfClosed();

            MessagingEventSource.Log.GetRulesStart(ClientEntity.ClientId);
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

                MessagingEventSource.Log.GetRulesException(ClientEntity.ClientId, exception);

                throw;
            }
            finally
            {
                this.diagnosticSource.GetRulesStop(activity, rules, getRulesTask?.Status);
            }

            MessagingEventSource.Log.GetRulesStop(ClientEntity.ClientId);
            return rules;
        }
        
        internal async Task OnClosingAsync()
        {
            if (this.innerSubscriptionClient != null)
            {
                await this.innerSubscriptionClient.DisposeAsync().ConfigureAwait(false);
            }

        }

        public async ValueTask DisposeAsync()
        {
            await ClientEntity.CloseAsync(OnClosingAsync);
        }
    }
}