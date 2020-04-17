// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Filters;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// Manages rules for subscriptions.
    /// </summary>
    public class ServiceBusRuleManager
    {
        /// <summary>
        /// The path of the Service Bus entity that the rule manager is connected to, specific to the
        /// Service Bus namespace that contains it.
        /// </summary>
        public string EntityPath { get; private set; }

        /// <summary>
        /// Gets the ID to identify this client. This can be used to correlate logs and exceptions.
        /// </summary>
        /// <remarks>Every new client has a unique ID.</remarks>
        internal string Identifier { get; private set; }

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
        /// <param name="entityPath"></param>
        ///
        internal ServiceBusRuleManager(
            ServiceBusConnection connection,
            string entityPath)
        {
            Argument.AssertNotNull(connection, nameof(connection));
            Argument.AssertNotNull(connection.RetryOptions, nameof(connection.RetryOptions));
            Argument.AssertNotNullOrWhiteSpace(entityPath, nameof(entityPath));
            connection.ThrowIfClosed();

            Identifier = DiagnosticUtilities.GenerateIdentifier(entityPath);
            _connection = connection;
            EntityPath = entityPath;
            InnerRuleManager = _connection.CreateTransportRuleManager(
                entityPath: EntityPath,
                retryPolicy: connection.RetryOptions.ToRetryPolicy());
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
        /// A default <see cref="TrueFilter"/> rule named <see cref="RuleDescription.DefaultRuleName"/> is always added while creation of the Subscription.
        /// You can add multiple rules with distinct names to the same subscription.
        /// Multiple filters combine with each other using logical OR condition. i.e., If any filter succeeds, the message is passed on to the subscription.
        /// </remarks>
        ///
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        public virtual async Task AddRuleAsync(
            string ruleName,
            Filter filter,
            CancellationToken cancellationToken = default)
        {
            await AddRuleAsync(new RuleDescription(name: ruleName, filter: filter), cancellationToken).ConfigureAwait(false);
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
        /// A default <see cref="TrueFilter"/> rule named <see cref="RuleDescription.DefaultRuleName"/> is always added while creation of the Subscription.
        /// You can add multiple rules with distinct names to the same subscription.
        /// Multiple filters combine with each other using logical OR condition. i.e., If any filter succeeds, the message is passed on to the subscription.
        /// </remarks>
        ///
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        public virtual async Task AddRuleAsync(
            RuleDescription description,
            CancellationToken cancellationToken = default)
        {
            //  Argument.AssertNotClosed(IsDisposed, nameof(ServiceBusRuleManager));
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
                ServiceBusEventSource.Log.AddRuleException(Identifier, exception);
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
            //  Argument.AssertNotClosed(IsDisposed, nameof(ServiceBusRuleManager));
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
                ServiceBusEventSource.Log.RemoveRuleException(Identifier, exception);
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
        public virtual async Task<IEnumerable<RuleDescription>> GetRulesAsync(CancellationToken cancellationToken = default)
        {

            //  Argument.AssertNotClosed(IsDisposed, nameof(ServiceBusRuleManager));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.GetRuleStart(Identifier);
            IEnumerable<RuleDescription> rulesDescription;

            try
            {
                rulesDescription = await InnerRuleManager.GetRulesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                ServiceBusEventSource.Log.GetRuleException(Identifier, exception);
                throw;
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.GetRuleComplete(Identifier);
            return rulesDescription;
        }
    }
}
