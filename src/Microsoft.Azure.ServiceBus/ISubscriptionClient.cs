// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System.Threading.Tasks;
    using Core;
    using Filters;

    /// <summary>
    /// An interface used to describe the <see cref="SubscriptionClient"/>.
    /// </summary>
    public interface ISubscriptionClient : IReceiverClient
    {
        /// <summary>
        /// Gets the path of the topic, for this subscription.
        /// </summary>
        string TopicPath { get; }

        /// <summary>
        /// Gets the name of subscription.
        /// </summary>
        string SubscriptionName { get; }

        /// <summary>
        /// Asynchronously adds a rule to the current subscription with the specified name and filter expression.
        /// </summary>
        /// <param name="ruleName">The name of the rule to add.</param>
        /// <param name="filter">The filter expression against which messages will be matched.</param>
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        Task AddRuleAsync(string ruleName, Filter filter);

        /// <summary>
        /// Asynchronously adds a new rule to the subscription using the specified rule description.
        /// </summary>
        /// <param name="description">The rule description that provides metadata of the rule to add.</param>
        /// <returns>A task instance that represents the asynchronous add rule operation.</returns>
        Task AddRuleAsync(RuleDescription description);

        /// <summary>
        /// Asynchronously removes the rule described by <paramref name="ruleName" />.
        /// </summary>
        /// <param name="ruleName">The name of the rule.</param>
        /// <returns>A task instance that represents the asynchronous remove rule operation.</returns>
        Task RemoveRuleAsync(string ruleName);
    }
}