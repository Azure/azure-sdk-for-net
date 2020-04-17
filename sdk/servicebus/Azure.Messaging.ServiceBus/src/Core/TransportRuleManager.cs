// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Filters;

namespace Azure.Messaging.ServiceBus.Core
{
    internal abstract class TransportRuleManager
    {
        /// <summary>
        /// Adds a rule to the current subscription to filter the messages reaching from topic to the subscription.
        /// </summary>
        ///
        /// <param name="description">The rule description that provides the rule to add.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        public abstract Task AddRuleAsync(
            RuleDescription description,
            CancellationToken cancellationToken);

        /// <summary>
        /// Removes the rule on the subscription identified by <paramref name="ruleName" />.
        /// </summary>
        ///
        /// <param name="ruleName">Name of the rule</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task instance that represents the asynchronous remove rule operation.</returns>
        public abstract Task RemoveRuleAsync(
            string ruleName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Get all rules associated with the subscription.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>Returns a list of rules description</returns>
        public abstract Task<IEnumerable<RuleDescription>> GetRulesAsync(CancellationToken cancellationToken);
    }
}
