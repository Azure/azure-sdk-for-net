// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Administration;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Manages rules for subscriptions.
    /// </summary>
    internal class ServiceBusRuleManager : IAsyncDisposable
    {
        /// <summary>
        /// The path of the Service Bus subscription that the rule manager is connected to, specific to the
        /// Service Bus namespace that contains it.
        /// </summary>
        public string SubscriptionPath { get; private set; }

        /// <summary>
        /// Gets the ID to identify this client. This can be used to correlate logs and exceptions.
        /// </summary>
        /// <remarks>Every new client has a unique ID.</remarks>
        internal string Identifier { get; private set; }

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusRuleManager"/> has been disposed.
        /// </summary>
        ///
        /// <value>
        /// <c>true</c> if the rule manager is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// The active connection to the Azure Service Bus service, enabling client communications for metadata
        /// about the associated Service Bus entity and access to transport-aware rule manager.
        /// </summary>
        ///
        private readonly ServiceBusConnection _connection;

        /// <summary>
        /// An abstracted Service Bus transport-specific rule manager that is associated with the
        /// Service Bus entity gateway; intended to perform delegated operations.
        /// </summary>
        internal readonly TransportRuleManager InnerRuleManager;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusRuleManager"/> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Service Bus service.</param>
        /// <param name="subscriptionPath">The path of the Service Bus subscription to which the rule manager is bound.</param>
        ///
        internal ServiceBusRuleManager(
            ServiceBusConnection connection,
            string subscriptionPath)
        {
            Argument.AssertNotNull(connection, nameof(connection));
            Argument.AssertNotNull(connection.RetryOptions, nameof(connection.RetryOptions));
            Argument.AssertNotNullOrWhiteSpace(subscriptionPath, nameof(subscriptionPath));
            connection.ThrowIfClosed();

            Identifier = DiagnosticUtilities.GenerateIdentifier(subscriptionPath);
            _connection = connection;
            SubscriptionPath = subscriptionPath;
            InnerRuleManager = _connection.CreateTransportRuleManager(
                subscriptionPath: SubscriptionPath,
                retryPolicy: connection.RetryOptions.ToRetryPolicy(),
                identifier: Identifier);
        }

        /// <summary>
        /// Adds a rule to the current subscription to filter the messages reaching from topic to the subscription.
        /// </summary>
        ///
        /// <param name="ruleName">Name of the rule</param>
        /// <param name="filter">The filter expression against which messages will be matched.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// You can add rules to the subscription that decides which messages from the topic should reach the subscription.
        /// A default <see cref="TrueRuleFilter"/> rule named <see cref="RuleProperties.DefaultRuleName"/> is always added while creation of the Subscription.
        /// You can add multiple rules with distinct names to the same subscription.
        /// Multiple filters combine with each other using logical OR condition. i.e., If any filter succeeds, the message is passed on to the subscription.
        /// </remarks>
        ///
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        public virtual async Task AddRuleAsync(
            string ruleName,
            RuleFilter filter,
            CancellationToken cancellationToken = default)
        {
            await AddRuleAsync(new RuleProperties(name: ruleName, filter: filter), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds a rule to the current subscription to filter the messages reaching from topic to the subscription.
        /// </summary>
        ///
        /// <param name="description">The rule description that provides the rule to add.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>
        /// You can add rules to the subscription that decides which messages from the topic should reach the subscription.
        /// A default <see cref="TrueRuleFilter"/> rule named <see cref="RuleProperties.DefaultRuleName"/> is always added while creation of the Subscription.
        /// You can add multiple rules with distinct names to the same subscription.
        /// Multiple filters combine with each other using logical OR condition. i.e., If any filter succeeds, the message is passed on to the subscription.
        /// </remarks>
        ///
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        public virtual async Task AddRuleAsync(
            RuleProperties description,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsDisposed, nameof(ServiceBusRuleManager));
            Argument.AssertNotNull(description, nameof(description));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            EntityNameFormatter.CheckValidRuleName(description.Name);
            ServiceBusEventSource.Log.AddRuleStart(Identifier, description.Name);

            try
            {
                await InnerRuleManager.AddRuleAsync(
                    description,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                ServiceBusEventSource.Log.AddRuleException(Identifier, exception.ToString());
                throw;
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.AddRuleComplete(Identifier);
        }

        /// <summary>
        /// Removes the rule on the subscription identified by <paramref name="ruleName" />.
        /// </summary>
        ///
        /// <param name="ruleName">Name of the rule</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task instance that represents the asynchronous remove rule operation.</returns>
        public virtual async Task RemoveRuleAsync(
            string ruleName,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsDisposed, nameof(ServiceBusRuleManager));
            Argument.AssertNotNullOrEmpty(ruleName, nameof(ruleName));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.RemoveRuleStart(Identifier, ruleName);

            try
            {
                await InnerRuleManager.RemoveRuleAsync(
                    ruleName,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                ServiceBusEventSource.Log.RemoveRuleException(Identifier, exception.ToString());
                throw;
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.RemoveRuleComplete(Identifier);
        }

        /// <summary>
        /// Get all rules associated with the subscription.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>Returns a list of rules description</returns>
        public virtual async Task<IList<RuleProperties>> GetRulesAsync(CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsDisposed, nameof(ServiceBusRuleManager));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.GetRuleStart(Identifier);
            IList<RuleProperties> rulesDescription;

            try
            {
                rulesDescription = await InnerRuleManager.GetRulesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                ServiceBusEventSource.Log.GetRuleException(Identifier, exception.ToString());
                throw;
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.GetRuleComplete(Identifier);
            return rulesDescription;
        }

        /// <summary>
        /// Performs the task needed to clean up resources used by the <see cref="ServiceBusRuleManager" />.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public virtual async ValueTask DisposeAsync()
        {
            IsDisposed = true;

            ServiceBusEventSource.Log.ClientCloseStart(typeof(ServiceBusRuleManager), Identifier);
            try
            {
                await InnerRuleManager.CloseAsync(CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.ClientCloseException(typeof(ServiceBusRuleManager), Identifier, ex);
                throw;
            }

            ServiceBusEventSource.Log.ClientCloseComplete(typeof(ServiceBusRuleManager), Identifier);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
