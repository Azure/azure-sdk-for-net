// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Filters;
    using Microsoft.Azure.ServiceBus.Primitives;

    public abstract class SubscriptionClient : ClientEntity
    {
        public const string DefaultRule = "$Default";
        MessageReceiver innerReceiver;

        protected SubscriptionClient(ServiceBusConnection serviceBusConnection, string topicPath, string name, ReceiveMode receiveMode)
            : base($"{nameof(SubscriptionClient)}{ClientEntity.GetNextId()}({name})")
        {
            this.ServiceBusConnection = serviceBusConnection;
            this.TopicPath = topicPath;
            this.Name = name;
            this.SubscriptionPath = EntityNameHelper.FormatSubscriptionPath(this.TopicPath, this.Name);
            this.Mode = receiveMode;
        }

        public string TopicPath { get; private set; }

        public string Name { get; }

        public ReceiveMode Mode { get; private set; }

        public int PrefetchCount
        {
            get
            {
                return this.InnerReceiver.PrefetchCount;
            }

            set
            {
                this.InnerReceiver.PrefetchCount = value;
            }
        }

        internal string SubscriptionPath { get; private set; }

        internal MessageReceiver InnerReceiver
        {
            get
            {
                if (this.innerReceiver == null)
                {
                    lock (this.ThisLock)
                    {
                        if (this.innerReceiver == null)
                        {
                            this.innerReceiver = this.CreateMessageReceiver();
                        }
                    }
                }

                return this.innerReceiver;
            }
        }

        protected object ThisLock { get; } = new object();

        protected ServiceBusConnection ServiceBusConnection { get; }

        public static SubscriptionClient CreateFromConnectionString(string topicEntityConnectionString, string subscriptionName)
        {
            return CreateFromConnectionString(topicEntityConnectionString, subscriptionName, ReceiveMode.PeekLock);
        }

        public static SubscriptionClient CreateFromConnectionString(string topicEntityConnectionString, string subscriptionName, ReceiveMode mode)
        {
            if (string.IsNullOrWhiteSpace(topicEntityConnectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(topicEntityConnectionString));
            }

            ServiceBusEntityConnection topicConnection = new ServiceBusEntityConnection(topicEntityConnectionString);
            return topicConnection.CreateSubscriptionClient(topicConnection.EntityPath, subscriptionName, mode);
        }

        public static SubscriptionClient Create(ServiceBusNamespaceConnection namespaceConnection, string topicPath, string subscriptionName)
        {
            return SubscriptionClient.Create(namespaceConnection, topicPath, subscriptionName, ReceiveMode.PeekLock);
        }

        public static SubscriptionClient Create(ServiceBusNamespaceConnection namespaceConnection, string topicPath, string subscriptionName, ReceiveMode mode)
        {
            if (namespaceConnection == null)
            {
                throw Fx.Exception.Argument(nameof(namespaceConnection), "Namespace Connection is null. Create a connection using the NamespaceConnection class");
            }

            if (string.IsNullOrWhiteSpace(topicPath))
            {
                throw Fx.Exception.Argument(nameof(namespaceConnection), "Topic Path is null");
            }

            return namespaceConnection.CreateSubscriptionClient(topicPath, subscriptionName, mode);
        }

        public static SubscriptionClient Create(ServiceBusEntityConnection topicConnection, string subscriptionName)
        {
            return SubscriptionClient.Create(topicConnection, subscriptionName, ReceiveMode.PeekLock);
        }

        public static SubscriptionClient Create(ServiceBusEntityConnection topicConnection, string subscriptionName, ReceiveMode mode)
        {
            if (topicConnection == null)
            {
                throw Fx.Exception.Argument(nameof(topicConnection), "Namespace Connection is null. Create a connection using the NamespaceConnection class");
            }

            return topicConnection.CreateSubscriptionClient(topicConnection.EntityPath, subscriptionName, mode);
        }

        public sealed override async Task CloseAsync()
        {
            await this.OnCloseAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Receives a message using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <returns>The asynchronous operation.</returns>
        public Task<BrokeredMessage> ReceiveAsync()
        {
            return this.InnerReceiver.ReceiveAsync();
        }

        /// <summary>
        /// Receives a message using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <param name="serverWaitTime">The time span the server waits for receiving a message before it times out.</param>
        /// <returns>The asynchronous operation.</returns>
        public Task<BrokeredMessage> ReceiveAsync(TimeSpan serverWaitTime)
        {
            return this.InnerReceiver.ReceiveAsync(serverWaitTime);
        }

        /// <summary>
        /// Receives a message using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <param name="maxMessageCount">The maximum number of messages that will be received.</param>
        /// <returns>The asynchronous operation.</returns>
        public Task<IList<BrokeredMessage>> ReceiveAsync(int maxMessageCount)
        {
            return this.InnerReceiver.ReceiveAsync(maxMessageCount);
        }

        /// <summary>
        /// Receives a message using the <see cref="MessageReceiver" />.
        /// </summary>
        /// <param name="maxMessageCount">The maximum number of messages that will be received.</param>
        /// <param name="serverWaitTime">The time span the server waits for receiving a message before it times out.</param>
        /// <returns>The asynchronous operation.</returns>
        public Task<IList<BrokeredMessage>> ReceiveAsync(int maxMessageCount, TimeSpan serverWaitTime)
        {
            return this.InnerReceiver.ReceiveAsync(maxMessageCount, serverWaitTime);
        }

        public async Task<BrokeredMessage> ReceiveBySequenceNumberAsync(long sequenceNumber)
        {
            IList<BrokeredMessage> messages = await this.ReceiveBySequenceNumberAsync(new[] { sequenceNumber });
            if (messages != null && messages.Count > 0)
            {
                return messages[0];
            }

            return null;
        }

        public Task<IList<BrokeredMessage>> ReceiveBySequenceNumberAsync(IEnumerable<long> sequenceNumbers)
        {
            return this.InnerReceiver.ReceiveBySequenceNumberAsync(sequenceNumbers);
        }

        /// <summary>
        /// Asynchronously reads the next message without changing the state of the receiver or the message source.
        /// </summary>
        /// <returns>The asynchronous operation that returns the <see cref="Microsoft.Azure.ServiceBus.BrokeredMessage" /> that represents the next message to be read.</returns>
        public Task<BrokeredMessage> PeekAsync()
        {
            return this.InnerReceiver.PeekAsync();
        }

        /// <summary>
        /// Asynchronously reads the next batch of message without changing the state of the receiver or the message source.
        /// </summary>
        /// <param name="maxMessageCount">The number of messages.</param>
        /// <returns>The asynchronous operation that returns a list of <see cref="Microsoft.Azure.ServiceBus.BrokeredMessage" /> to be read.</returns>
        public Task<IList<BrokeredMessage>> PeekAsync(int maxMessageCount)
        {
            return this.InnerReceiver.PeekAsync(maxMessageCount);
        }

        /// <summary>
        /// Asynchronously reads the next message without changing the state of the receiver or the message source.
        /// </summary>
        /// <param name="fromSequenceNumber">The sequence number from where to read the message.</param>
        /// <returns>The asynchronous operation that returns the <see cref="Microsoft.Azure.ServiceBus.BrokeredMessage" /> that represents the next message to be read.</returns>
        public Task<BrokeredMessage> PeekBySequenceNumberAsync(long fromSequenceNumber)
        {
            return this.InnerReceiver.PeekBySequenceNumberAsync(fromSequenceNumber);
        }

        /// <summary>Peeks a batch of messages.</summary>
        /// <param name="fromSequenceNumber">The starting point from which to browse a batch of messages.</param>
        /// <param name="messageCount">The number of messages.</param>
        /// <returns>A batch of messages peeked.</returns>
        public Task<IList<BrokeredMessage>> PeekBySequenceNumberAsync(long fromSequenceNumber, int messageCount)
        {
            return this.InnerReceiver.PeekBySequenceNumberAsync(fromSequenceNumber, messageCount);
        }

        public Task CompleteAsync(Guid lockToken)
        {
            return this.CompleteAsync(new[] { lockToken });
        }

        public Task CompleteAsync(IEnumerable<Guid> lockTokens)
        {
            return this.InnerReceiver.CompleteAsync(lockTokens);
        }

        public Task AbandonAsync(Guid lockToken)
        {
            return this.InnerReceiver.AbandonAsync(new[] { lockToken });
        }

        public Task<MessageSession> AcceptMessageSessionAsync()
        {
            return this.AcceptMessageSessionAsync(null);
        }

        public Task<MessageSession> AcceptMessageSessionAsync(TimeSpan serverWaitTime)
        {
            return this.AcceptMessageSessionAsync(null, serverWaitTime);
        }

        public Task<MessageSession> AcceptMessageSessionAsync(string sessionId)
        {
            return this.AcceptMessageSessionAsync(sessionId, this.InnerReceiver.OperationTimeout);
        }

        public async Task<MessageSession> AcceptMessageSessionAsync(string sessionId, TimeSpan serverWaitTime)
        {
            MessageSession session;

            MessagingEventSource.Log.AcceptMessageSessionStart(this.ClientId, sessionId);

            try
            {
                session = await this.OnAcceptMessageSessionAsync(sessionId, serverWaitTime).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.AcceptMessageSessionException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.AcceptMessageSessionStop(this.ClientId);
            return session;
        }

        public Task DeferAsync(Guid lockToken)
        {
            return this.InnerReceiver.DeferAsync(new[] { lockToken });
        }

        public Task DeadLetterAsync(Guid lockToken)
        {
            return this.InnerReceiver.DeadLetterAsync(new[] { lockToken });
        }

        public Task<DateTime> RenewMessageLockAsync(Guid lockToken)
        {
            return this.InnerReceiver.RenewLockAsync(lockToken);
        }

        /// <summary>Asynchronously processes a message.</summary>
        /// <param name="callback">The method to invoke when the operation is complete.</param>
        public void OnMessageAsync(Func<BrokeredMessage, CancellationToken, Task> callback)
        {
            this.InnerReceiver.OnMessageAsync(callback);
        }

        /// <summary>Asynchronously processes a message.</summary>
        /// <param name="callback">The method to invoke when the operation is complete.</param>
        /// <param name="onMessageOptions">Calls a message option.</param>
        public void OnMessageAsync(Func<BrokeredMessage, CancellationToken, Task> callback, OnMessageOptions onMessageOptions)
        {
            this.InnerReceiver.OnMessageAsync(callback, onMessageOptions);
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
                await this.OnAddRuleAsync(description).ConfigureAwait(false);
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
                await this.OnRemoveRuleAsync(ruleName).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.RemoveRuleException(this.ClientId, exception);
                throw;
            }

            MessagingEventSource.Log.RemoveRuleStop(this.ClientId);
        }

        protected MessageReceiver CreateMessageReceiver()
        {
            return this.OnCreateMessageReceiver();
        }

        protected abstract MessageReceiver OnCreateMessageReceiver();

        protected abstract Task<MessageSession> OnAcceptMessageSessionAsync(string sessionId, TimeSpan serverWaitTime);

        protected abstract Task OnCloseAsync();

        protected abstract Task OnAddRuleAsync(RuleDescription description);

        protected abstract Task OnRemoveRuleAsync(string ruleName);
    }
}