// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Amqp;
    using Core;
    using Filters;
    using Microsoft.Azure.Amqp;
    using Primitives;

    public sealed class SubscriptionClient : ClientEntity, ISubscriptionClient
    {
        public const string DefaultRule = "$Default";
        readonly object syncLock;
        readonly bool ownsConnection;
        IInnerSubscriptionClient innerSubscriptionClient;
        AmqpSessionClient sessionClient;
        SessionPumpHost sessionPumpHost;

        public SubscriptionClient(string connectionString, string topicPath, string subscriptionName, ReceiveMode receiveMode = ReceiveMode.PeekLock, RetryPolicy retryPolicy = null)
            : this(new ServiceBusNamespaceConnection(connectionString), topicPath, subscriptionName, receiveMode, retryPolicy ?? RetryPolicy.Default)
        {
            this.ownsConnection = true;
        }

        SubscriptionClient(ServiceBusNamespaceConnection serviceBusConnection, string topicPath, string subscriptionName, ReceiveMode receiveMode, RetryPolicy retryPolicy)
            : base($"{nameof(SubscriptionClient)}{ClientEntity.GetNextId()}({subscriptionName})", retryPolicy)
        {
            this.syncLock = new object();
            this.TopicPath = topicPath;
            this.ServiceBusConnection = serviceBusConnection;
            this.SubscriptionName = subscriptionName;
            this.Path = EntityNameHelper.FormatSubscriptionPath(this.TopicPath, this.SubscriptionName);
            this.ReceiveMode = receiveMode;
            this.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                serviceBusConnection.SasKeyName,
                serviceBusConnection.SasKey);
            this.CbsTokenProvider = new TokenProviderAdapter(this.TokenProvider, serviceBusConnection.OperationTimeout);
        }

        public string TopicPath { get; }

        public string Path { get; }

        public string SubscriptionName { get; }

        public ReceiveMode ReceiveMode { get; }

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
                            this.ReceiveMode);
                    }
                }

                return this.innerSubscriptionClient;
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
                                MessagingEntityType.Subscriber,
                                this.ReceiveMode,
                                this.ServiceBusConnection.PrefetchCount,
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
                                this.SessionClient);
                        }
                    }
                }

                return this.sessionPumpHost;
            }
        }

        ServiceBusNamespaceConnection ServiceBusConnection { get; }

        ICbsTokenProvider CbsTokenProvider { get; }

        TokenProvider TokenProvider { get; }

        public override async Task OnClosingAsync()
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

        public Task CompleteAsync(string lockToken)
        {
            return this.InnerSubscriptionClient.InnerReceiver.CompleteAsync(lockToken);
        }

        public Task AbandonAsync(string lockToken)
        {
            return this.InnerSubscriptionClient.InnerReceiver.AbandonAsync(lockToken);
        }

        public Task DeadLetterAsync(string lockToken)
        {
            return this.InnerSubscriptionClient.InnerReceiver.DeadLetterAsync(lockToken);
        }

        /// <summary>Asynchronously processes a message.</summary>
        /// <param name="handler"></param>
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler)
        {
            this.InnerSubscriptionClient.InnerReceiver.RegisterMessageHandler(handler);
        }

        /// <summary>Asynchronously processes a message.</summary>
        /// <param name="handler"></param>
        /// <param name="registerHandlerOptions">Calls a message option.</param>
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, RegisterMessageHandlerOptions registerHandlerOptions)
        {
            this.InnerSubscriptionClient.InnerReceiver.RegisterMessageHandler(handler, registerHandlerOptions);
        }

        /// <summary>Register a session handler.</summary>
        /// <param name="handler"></param>
        public void RegisterSessionHandler(Func<IMessageSession, Message, CancellationToken, Task> handler)
        {
            var sessionHandlerOptions = new RegisterSessionHandlerOptions();
            this.RegisterSessionHandler(handler, sessionHandlerOptions);
        }

        /// <summary>Register a session handler.</summary>
        /// <param name="handler"></param>
        /// <param name="registerSessionHandlerOptions">Options associated with session pump processing.</param>
        public void RegisterSessionHandler(Func<IMessageSession, Message, CancellationToken, Task> handler, RegisterSessionHandlerOptions registerSessionHandlerOptions)
        {
            this.SessionPumpHost.OnSessionHandlerAsync(handler, registerSessionHandlerOptions).GetAwaiter().GetResult();
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
    }
}