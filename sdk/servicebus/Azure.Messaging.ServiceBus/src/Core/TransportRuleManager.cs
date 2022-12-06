// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Administration;

namespace Azure.Messaging.ServiceBus.Core
{
    internal abstract class TransportRuleManager
    {
        /// <summary>
        /// Indicates whether or not this rule manager has been closed.
        /// </summary>
        ///
        /// <value>
        /// <c>true</c> if the rule manager is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public abstract bool IsClosed { get; }

        /// <summary>
        /// Adds a rule to the current subscription to filter the messages reaching from topic to the subscription.
        /// </summary>
        ///
        /// <param name="properties">The rule properties for the rule to add.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        public abstract Task CreateRuleAsync(
            RuleProperties properties,
            CancellationToken cancellationToken);

        /// <summary>
        /// Removes the rule on the subscription identified by <paramref name="ruleName" />.
        /// </summary>
        ///
        /// <param name="ruleName">Name of the rule</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task instance that represents the asynchronous remove rule operation.</returns>
        public abstract Task DeleteRuleAsync(
            string ruleName,
            CancellationToken cancellationToken);

        /// <summary>
        /// Get all rules associated with the subscription.
        /// </summary>
        /// <param name="skip">The number of rules to skip when retrieving the next set of rules.</param>
        /// <param name="top">The number of rules to retrieve per service request.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>Returns a list of rules description</returns>
        public abstract Task<List<RuleProperties>> GetRulesAsync(int skip, int top, CancellationToken cancellationToken);

        /// <summary>
        /// Closes the connection to the transport rule manager instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        public abstract Task CloseAsync(CancellationToken cancellationToken);
    }
}