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
using Azure.Messaging.ServiceBus.Primitives;

namespace Azure.Messaging.ServiceBus.Amqp
{
#pragma warning disable CA1001 // Types that own disposable fields should be disposable. AmqpRuleManager does not own connection scope.
    internal class AmqpRuleManager : TransportRuleManager
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        /// <summary>
        /// The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        private readonly ServiceBusRetryPolicy _retryPolicy;

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

            _connectionScope = connectionScope;
            _retryPolicy = retryPolicy;
            _managementLink = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(
                timeout => _connectionScope.OpenManagementLinkAsync(
                    subscriptionPath,
                    identifier,
                    timeout,
                    CancellationToken.None),
                link => _connectionScope.CloseLink(link, identifier));
        }

        /// <summary>
        /// Adds a rule to the current subscription to filter the messages reaching from topic to the subscription.
        /// </summary>
        ///
        /// <param name="properties">The rule description that provides the rule to add.</param>
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
        public override async Task CreateRuleAsync(
            RuleProperties properties,
            CancellationToken cancellationToken) =>
            await _retryPolicy.RunOperation(
                static async (value, timeout, token) =>
                {
                    var (manager, properties) = value;
                    await manager.AddRuleInternalAsync(
                        properties,
                        timeout).ConfigureAwait(false);
                },
                (this, properties),
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
            amqpRequestMessage.Map[ManagementConstants.Properties.RuleDescription] = GetRuleDescriptionMap(description);

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
        public override async Task DeleteRuleAsync(string ruleName, CancellationToken cancellationToken) =>
            await _retryPolicy.RunOperation(
                static async (value, timeout, token) =>
                {
                    var (manager, ruleName) = value;
                    await manager.DeleteRuleInternalAsync(ruleName, timeout).ConfigureAwait(false);
                },
                (this, ruleName),
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
        private async Task DeleteRuleInternalAsync(
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
        /// Get rules associated with the subscription.
        /// </summary>
        /// <param name="skip">The number of rules to skip when retrieving the next set of rules.</param>
        /// <param name="top">The number of rules to retrieve per service request.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>Returns a list of rules description</returns>
        public override async Task<List<RuleProperties>> GetRulesAsync(int skip, int top, CancellationToken cancellationToken) =>
            await _retryPolicy.RunOperation(
                static async (value, timeout, token) =>
                {
                    var (manager, skip, top) = value;
                    return await manager.GetRulesInternalAsync(timeout, skip, top).ConfigureAwait(false);
                },
                (this, skip, top),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);

        public static AmqpMap GetRuleDescriptionMap(RuleProperties description)
        {
            var ruleDescriptionMap = new AmqpMap();

            switch (description.Filter)
            {
                case SqlRuleFilter sqlRuleFilter:
                    var filterMap = GetSqlRuleFilterMap(sqlRuleFilter);
                    ruleDescriptionMap[ManagementConstants.Properties.SqlRuleFilter] = filterMap;
                    break;
                case CorrelationRuleFilter correlationFilter:
                    var correlationFilterMap = GetCorrelationRuleFilterMap(correlationFilter);
                    ruleDescriptionMap[ManagementConstants.Properties.CorrelationRuleFilter] = correlationFilterMap;
                    break;
                default:
                    throw new NotSupportedException(
                        Resources.RuleFilterNotSupported.FormatForUser(
                            description.Filter.GetType(),
                            nameof(SqlRuleFilter),
                            nameof(CorrelationRuleFilter)));
            }

            var amqpAction = GetRuleActionMap(description.Action as SqlRuleAction);
            ruleDescriptionMap[ManagementConstants.Properties.SqlRuleAction] = amqpAction;
            ruleDescriptionMap[ManagementConstants.Properties.RuleName] = description.Name;

            return ruleDescriptionMap;
        }

        public virtual RuleProperties GetRuleDescription(AmqpRuleDescriptionCodec amqpDescription)
        {
            var filter = GetFilter(amqpDescription.Filter);
            var ruleAction = GetRuleAction(amqpDescription.Action);

            var ruleDescription = new RuleProperties(amqpDescription.RuleName, filter)
            {
                Action = ruleAction
            };

            return ruleDescription;
        }

        internal static AmqpMap GetSqlRuleFilterMap(SqlRuleFilter sqlRuleFilter)
        {
            var amqpFilterMap = new AmqpMap
            {
                [ManagementConstants.Properties.Expression] = sqlRuleFilter.SqlExpression
            };
            return amqpFilterMap;
        }

        internal static AmqpMap GetCorrelationRuleFilterMap(CorrelationRuleFilter correlationRuleFilter)
        {
            var correlationRuleFilterMap = new AmqpMap
            {
                [ManagementConstants.Properties.CorrelationId] = correlationRuleFilter.CorrelationId,
                [ManagementConstants.Properties.MessageId] = correlationRuleFilter.MessageId,
                [ManagementConstants.Properties.To] = correlationRuleFilter.To,
                [ManagementConstants.Properties.ReplyTo] = correlationRuleFilter.ReplyTo,
                [ManagementConstants.Properties.Label] = correlationRuleFilter.Subject,
                [ManagementConstants.Properties.SessionId] = correlationRuleFilter.SessionId,
                [ManagementConstants.Properties.ReplyToSessionId] = correlationRuleFilter.ReplyToSessionId,
                [ManagementConstants.Properties.ContentType] = correlationRuleFilter.ContentType
            };

            var propertiesMap = new AmqpMap();
            foreach (var property in correlationRuleFilter.ApplicationProperties)
            {
                propertiesMap[new MapKey(property.Key)] = property.Value;
            }

            correlationRuleFilterMap[ManagementConstants.Properties.CorrelationRuleFilterProperties] = propertiesMap;

            return correlationRuleFilterMap;
        }

        internal static AmqpMap GetRuleActionMap(SqlRuleAction sqlRuleAction)
        {
            AmqpMap ruleActionMap = null;
            if (sqlRuleAction != null)
            {
                ruleActionMap = new AmqpMap { [ManagementConstants.Properties.Expression] = sqlRuleAction.SqlExpression };
            }

            return ruleActionMap;
        }

        private static RuleAction GetRuleAction(AmqpRuleActionCodec amqpAction)
        {
            RuleAction action;

            if (amqpAction.DescriptorCode == AmqpEmptyRuleActionCodec.Code)
            {
                action = null;
            }
            else if (amqpAction.DescriptorCode == AmqpSqlRuleActionCodec.Code)
            {
                var amqpSqlRuleAction = (AmqpSqlRuleActionCodec)amqpAction;
                var sqlRuleAction = new SqlRuleAction(amqpSqlRuleAction.SqlExpression);

                action = sqlRuleAction;
            }
            else
            {
                throw new NotSupportedException($"Unknown action descriptor code: {amqpAction.DescriptorCode}");
            }

            return action;
        }

        public virtual RuleFilter GetFilter(AmqpRuleFilterCodec amqpFilter)
        {
            RuleFilter filter;

            switch (amqpFilter.DescriptorCode)
            {
                case AmqpSqlRuleFilterCodec.Code:
                    var amqpSqlFilter = (AmqpSqlRuleFilterCodec)amqpFilter;
                    filter = new SqlRuleFilter(amqpSqlFilter.Expression);
                    break;

                case AmqpTrueRuleFilterCodec.Code:
                    filter = new TrueRuleFilter();
                    break;

                case AmqpFalseRuleFilterCodec.Code:
                    filter = new FalseRuleFilter();
                    break;

                case AmqpCorrelationRuleFilterCodec.Code:
                    var amqpCorrelationFilter = (AmqpCorrelationRuleFilterCodec)amqpFilter;
                    var correlationFilter = new CorrelationRuleFilter
                    {
                        CorrelationId = amqpCorrelationFilter.CorrelationId,
                        MessageId = amqpCorrelationFilter.MessageId,
                        To = amqpCorrelationFilter.To,
                        ReplyTo = amqpCorrelationFilter.ReplyTo,
                        Subject = amqpCorrelationFilter.Subject,
                        SessionId = amqpCorrelationFilter.SessionId,
                        ReplyToSessionId = amqpCorrelationFilter.ReplyToSessionId,
                        ContentType = amqpCorrelationFilter.ContentType
                    };

                    foreach (var property in amqpCorrelationFilter.Properties)
                    {
                        correlationFilter.ApplicationProperties.Add(property.Key.Key.ToString(), property.Value);
                    }

                    filter = correlationFilter;
                    break;

                default:
                    throw new NotSupportedException($"Unknown filter descriptor code: {amqpFilter.DescriptorCode}");
            }

            return filter;
        }

        /// <summary>
        /// Get rules associated with the subscription.
        /// </summary>
        /// <param name="timeout">The per-try timeout specified in the RetryOptions.</param>
        /// <param name="skip">The number of rules to skip when retrieving the next set of rules.</param>
        /// <param name="top">The number of rules to retrieve per service request.</param>
        /// <returns>Returns a list of rules description</returns>
        private async Task<List<RuleProperties>> GetRulesInternalAsync(TimeSpan timeout, int skip, int top)
        {
            var amqpRequestMessage = AmqpRequestMessage.CreateRequest(
                    ManagementConstants.Operations.EnumerateRulesOperation,
                    timeout,
                    null);
            amqpRequestMessage.Map[ManagementConstants.Properties.Top] = top;
            amqpRequestMessage.Map[ManagementConstants.Properties.Skip] = skip;

            var response = await ManagementUtilities.ExecuteRequestResponseAsync(
                _connectionScope,
                _managementLink,
                amqpRequestMessage,
                timeout).ConfigureAwait(false);
            List<RuleProperties> ruleDescriptions = null;
            if (response.StatusCode == AmqpResponseStatusCode.OK)
            {
                var ruleList = response.GetListValue<AmqpMap>(ManagementConstants.Properties.Rules);
                ruleDescriptions = new List<RuleProperties>(ruleList.Count);
                foreach (var entry in ruleList)
                {
                    var amqpRule = (AmqpRuleDescriptionCodec)entry[ManagementConstants.Properties.RuleDescription];
                    var ruleDescription = GetRuleDescription(amqpRule);
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

            return ruleDescriptions ?? new List<RuleProperties>(0);
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
                await _managementLink.CloseAsync(cancellationToken).ConfigureAwait(false);
            }

            _managementLink?.Dispose();
        }
    }
}
