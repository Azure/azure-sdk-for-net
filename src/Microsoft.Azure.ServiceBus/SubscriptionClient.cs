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
    using Primitives;

    public sealed class SubscriptionClient : ClientEntity, ISubscriptionClient
    {
        public const string DefaultRule = "$Default";

        public SubscriptionClient(string connectionString, string topicPath, string subscriptionName, ReceiveMode receiveMode = ReceiveMode.PeekLock)
            : this(new ServiceBusNamespaceConnection(connectionString), topicPath, subscriptionName, receiveMode)
        {
        }

        private SubscriptionClient(ServiceBusNamespaceConnection serviceBusConnection, string topicPath, string subscriptionName, ReceiveMode receiveMode)
            : base($"{nameof(SubscriptionClient)}{ClientEntity.GetNextId()}({subscriptionName})")
        {
            this.TopicPath = topicPath;
            this.SubscriptionName = subscriptionName;
            this.Path = EntityNameHelper.FormatSubscriptionPath(this.TopicPath, this.SubscriptionName);
            this.ReceiveMode = receiveMode;
            this.InnerSubscriptionClient = new AmqpSubscriptionClient(serviceBusConnection, this.Path, MessagingEntityType.Subscriber, receiveMode);
        }

        public string TopicPath { get; }

        public string Path { get; }

        public string SubscriptionName { get; }

        public ReceiveMode ReceiveMode { get; }

        internal IInnerSubscriptionClient InnerSubscriptionClient { get; }

        public override async Task CloseAsync()
        {
            await this.InnerSubscriptionClient.CloseAsync().ConfigureAwait(false);
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
        public void RegisterMessageHandler(Func<Message, CancellationToken, Task> handler, RegisterHandlerOptions registerHandlerOptions)
        {
            this.InnerSubscriptionClient.InnerReceiver.RegisterMessageHandler(handler, registerHandlerOptions);
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