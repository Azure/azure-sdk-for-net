// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Amqp.Framing;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;

namespace Azure.Messaging.ServiceBus.Amqp
{
#pragma warning disable CA1001 // Types that own disposable fields should be disposable. AmqpRuleManager does not own connection scope.
    internal class AmqpRuleManager : TransportRuleManager
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        /// <summary>
        /// The path of the Service Bus subscription to which the rule manager is bound.
        /// </summary>
        ///
        private readonly string _subscriptionPath;

        /// <summary>
        /// The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        private readonly ServiceBusRetryPolicy _retryPolicy;

        /// <summary>
        /// The identifier for the rule manager.
        /// </summary>
        private readonly string _identifier;

        /// <summary>
        /// The AMQP connection scope responsible for managing transport constructs for this instance.
        /// </summary>
        ///
        private readonly AmqpConnectionScope _connectionScope;

        /// <summary>
        /// Indicates whether or not this instance has been closed.
        /// </summary>
        private bool _closed;

        /// <summary>
        /// Indicates whether or not this rule manager has been closed.
        /// </summary>
        ///
        /// <value>
        /// <c>true</c> if the rule manager is closed; otherwise, <c>false</c>.
        /// </value>
        public override bool IsClosed => _closed;

        private readonly FaultTolerantAmqpObject<RequestResponseAmqpLink> _managementLink;

        static AmqpRuleManager()
        {
            AmqpCodec.RegisterKnownTypes(AmqpTrueRuleFilterCodec.Name, AmqpTrueRuleFilterCodec.Code, () => new AmqpTrueRuleFilterCodec());
            AmqpCodec.RegisterKnownTypes(AmqpFalseRuleFilterCodec.Name, AmqpFalseRuleFilterCodec.Code, () => new AmqpFalseRuleFilterCodec());
            AmqpCodec.RegisterKnownTypes(AmqpCorrelationRuleFilterCodec.Name, AmqpCorrelationRuleFilterCodec.Code, () => new AmqpCorrelationRuleFilterCodec());
            AmqpCodec.RegisterKnownTypes(AmqpSqlRuleFilterCodec.Name, AmqpSqlRuleFilterCodec.Code, () => new AmqpSqlRuleFilterCodec());
            AmqpCodec.RegisterKnownTypes(AmqpEmptyRuleActionCodec.Name, AmqpEmptyRuleActionCodec.Code, () => new AmqpEmptyRuleActionCodec());
            AmqpCodec.RegisterKnownTypes(AmqpSqlRuleActionCodec.Name, AmqpSqlRuleActionCodec.Code, () => new AmqpSqlRuleActionCodec());
            AmqpCodec.RegisterKnownTypes(AmqpRuleDescriptionCodec.Name, AmqpRuleDescriptionCodec.Code, () => new AmqpRuleDescriptionCodec());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AmqpRuleManager"/> class.
        /// </summary>
        ///
        /// <param name="subscriptionPath">The path of the Service Bus subscription to which the rule manager is bound.</param>
        /// <param name="connectionScope">The AMQP connection context for operations.</param>
        /// <param name="retryPolicy">The retry policy to consider when an operation fails.</param>
        /// <param name="identifier">The identifier for the rule manager.</param>
        ///
        /// <remarks>
        /// As an internal type, this class performs only basic sanity checks against its arguments.  It
        /// is assumed that callers are trusted and have performed deep validation.
        ///
        /// Any parameters passed are assumed to be owned by this instance and safe to mutate or dispose;
        /// creation of clones or otherwise protecting the parameters is assumed to be the purview of the
        /// caller.
        /// </remarks>
        public AmqpRuleManager(
            string subscriptionPath,
            AmqpConnectionScope connectionScope,
            ServiceBusRetryPolicy retryPolicy,
            string identifier)
        {
            Argument.AssertNotNullOrEmpty(subscriptionPath, nameof(subscriptionPath));
            Argument.AssertNotNull(connectionScope, nameof(connectionScope));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            _subscriptionPath = subscriptionPath;
            _connectionScope = connectionScope;
            _retryPolicy = retryPolicy;
            _identifier = identifier;

            _managementLink = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(
                timeout => _connectionScope.OpenManagementLinkAsync(
                    _subscriptionPath,
                    _identifier,
                    timeout,
                    CancellationToken.None),
                link =>
                {
                    link.Session?.SafeClose();
                    link.SafeClose();
                });
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
        public override async Task AddRuleAsync(
            RuleProperties description,
            CancellationToken cancellationToken = default) =>
            await _retryPolicy.RunOperation(
                async (timeout) =>
                await AddRuleInternalAsync(
                    description,
                    timeout).ConfigureAwait(false),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Adds a rule to the current subscription to filter the messages reaching from topic to the subscription.
        /// </summary>
        ///
        /// <param name="description">The rule description that provides the rule to add.</param>
        /// <param name="timeout">The per-try timeout specified in the RetryOptions.</param>
        ///
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        private async Task AddRuleInternalAsync(
            RuleProperties description,
            TimeSpan timeout)
        {
            // Create an AmqpRequest Message to add rule
            var amqpRequestMessage = AmqpRequestMessage.CreateRequest(
                     ManagementConstants.Operations.AddRuleOperation,
                     timeout,
                     null);
            amqpRequestMessage.Map[ManagementConstants.Properties.RuleName] = description.Name;
            amqpRequestMessage.Map[ManagementConstants.Properties.RuleDescription] = AmqpMessageConverter.GetRuleDescriptionMap(description);

            AmqpResponseMessage response = await ManagementUtilities.ExecuteRequestResponseAsync(
                    _connectionScope,
                    _managementLink,
                    amqpRequestMessage,
                    timeout).ConfigureAwait(false);

            if (response.StatusCode != AmqpResponseStatusCode.OK)
            {
                throw response.ToMessagingContractException();
            }
        }

        /// <summary>
        /// Removes the rule on the subscription identified by <paramref name="ruleName" />.
        /// </summary>
        ///
        /// <param name="ruleName">Name of the rule</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task instance that represents the asynchronous remove rule operation.</returns>
        public override async Task RemoveRuleAsync(
            string ruleName,
            CancellationToken cancellationToken = default) =>
            await _retryPolicy.RunOperation(
                async (timeout) =>
                await RemoveRuleInternalAsync(
                    ruleName,
                    timeout).ConfigureAwait(false),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Removes the rule on the subscription identified by <paramref name="ruleName" />.
        /// </summary>
        ///
        /// <param name="ruleName">Name of the rule</param>
        /// <param name="timeout">The per-try timeout specified in the RetryOptions.</param>
        ///
        /// <returns>A task instance that represents the asynchronous remove rule operation.</returns>
        private async Task RemoveRuleInternalAsync(
            string ruleName,
            TimeSpan timeout)
        {
            // Create an AmqpRequest Message to remove rule
            var amqpRequestMessage = AmqpRequestMessage.CreateRequest(
                        ManagementConstants.Operations.RemoveRuleOperation,
                        timeout,
                        null);
            amqpRequestMessage.Map[ManagementConstants.Properties.RuleName] = ruleName;

            AmqpResponseMessage response = await ManagementUtilities.ExecuteRequestResponseAsync(
                    _connectionScope,
                    _managementLink,
                    amqpRequestMessage,
                    timeout).ConfigureAwait(false);

            if (response.StatusCode != AmqpResponseStatusCode.OK)
            {
                throw response.ToMessagingContractException();
            }
        }

        /// <summary>
        /// Get all rules associated with the subscription.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>Returns a list of rules description</returns>
        public override async Task<IList<RuleProperties>> GetRulesAsync(CancellationToken cancellationToken = default)
        {
            IList<RuleProperties> rulesDescription = null;

            await _retryPolicy.RunOperation(
                async (timeout) =>
                rulesDescription = await GetRulesInternalAsync(timeout).ConfigureAwait(false),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);

            return rulesDescription;
        }

        /// <summary>
        /// Get all rules associated with the subscription.
        /// </summary>
        ///
        /// <param name="timeout">The per-try timeout specified in the RetryOptions.</param>
        ///
        /// <returns>Returns a list of rules description</returns>
        private async Task<IList<RuleProperties>> GetRulesInternalAsync(TimeSpan timeout)
        {
            var amqpRequestMessage = AmqpRequestMessage.CreateRequest(
                    ManagementConstants.Operations.EnumerateRulesOperation,
                    timeout,
                    null);
            amqpRequestMessage.Map[ManagementConstants.Properties.Top] = int.MaxValue;
            amqpRequestMessage.Map[ManagementConstants.Properties.Skip] = 0;

            var response = await ManagementUtilities.ExecuteRequestResponseAsync(
                _connectionScope,
                _managementLink,
                amqpRequestMessage,
                timeout).ConfigureAwait(false);
            var ruleDescriptions = new List<RuleProperties>();
            if (response.StatusCode == AmqpResponseStatusCode.OK)
            {
                var ruleList = response.GetListValue<AmqpMap>(ManagementConstants.Properties.Rules);
                foreach (var entry in ruleList)
                {
                    var amqpRule = (AmqpRuleDescriptionCodec)entry[ManagementConstants.Properties.RuleDescription];
                    var ruleDescription = AmqpMessageConverter.GetRuleDescription(amqpRule);
                    ruleDescriptions.Add(ruleDescription);
                }
            }
            else if (response.StatusCode == AmqpResponseStatusCode.NoContent)
            {
                // Do nothing. Return empty list;
            }
            else
            {
                throw response.ToMessagingContractException();
            }

            return ruleDescriptions;
        }

        /// <summary>
        /// Closes the connection to the transport rule manager instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        public override async Task CloseAsync(CancellationToken cancellationToken)
        {
            if (_closed)
            {
                return;
            }

            _closed = true;

            if (_managementLink?.TryGetOpenedObject(out var _) == true)
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                await _managementLink.CloseAsync().ConfigureAwait(false);
            }

            _managementLink?.Dispose();
        }
    }
}
