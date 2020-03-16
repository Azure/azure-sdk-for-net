// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Filters;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///
    /// </summary>
    internal class ServiceBusRuleManager
    {
        /// <summary>
        /// TODO implement
        /// </summary>
        /// <param name="topicName"></param>
        /// <param name="subscriptionName"></param>
        internal ServiceBusRuleManager(string topicName, string subscriptionName) { }

        /// <summary>
        /// Adds a rule to the current subscription to filter the messages reaching from topic to the subscription.
        /// </summary>
        /// <param name="ruleName"></param>
        /// <param name="filter">The filter expression against which messages will be matched.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        /// <remarks>
        /// You can add rules to the subscription that decides which messages from the topic should reach the subscription.
        /// A default TrueFilter"/> rule named  RuleDescription.DefaultRuleName"/> is always added while creation of the Subscription.
        /// You can add multiple rules with distinct names to the same subscription.
        /// Multiple filters combine with each other using logical OR condition. i.e., If any filter succeeds, the message is passed on to the subscription.
        /// Max allowed length of rule name is 50 chars.
        /// </remarks>
        public virtual async Task AddRuleAsync(
            string ruleName,
            Filter filter,
            CancellationToken cancellationToken = default)
        {
            await Task.Delay(1).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a rule to the current subscription to filter the messages reaching from topic to the subscription.
        /// </summary>
        /// <param name="description">The rule description that provides the rule to add.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        /// <remarks>
        /// You can add rules to the subscription that decides which messages from the topic should reach the subscription.
        /// A default <see cref="TrueFilter"/> rule named <see cref="RuleDescription.DefaultRuleName"/> is always added while creation of the Subscription.
        /// You can add multiple rules with distinct names to the same subscription.
        /// Multiple filters combine with each other using logical OR condition. i.e., If any filter succeeds, the message is passed on to the subscription.
        /// </remarks>
        public virtual async Task AddRuleAsync(
            RuleDescription description,
            CancellationToken cancellationToken = default)
        {
            await Task.Delay(1).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the rule on the subscription identified by <paramref name="ruleName" />.
        /// </summary>
        /// <returns>A task instance that represents the asynchronous remove rule operation.</returns>
        public virtual async Task RemoveRuleAsync(
            string ruleName,
            CancellationToken cancellationToken = default)
        {
            await Task.Delay(1).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all rules associated with the subscription.
        /// </summary>
        public virtual async Task<IEnumerable<RuleDescription>> GetRulesAsync(
                CancellationToken cancellationToken = default)
        {
            return await PeekRangeAsync(10).ConfigureAwait(false);
        }

        private Task<IEnumerable<RuleDescription>> PeekRangeAsync(int v)
        {
            throw new NotImplementedException();
        }
    }
}
