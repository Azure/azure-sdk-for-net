// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableSecurityCenterSubscriptionResource : ArmResource
    {
        /// <summary> Gets a collection of SubscriptionGovernanceRuleResources in the SubscriptionResource. </summary>
        /// <returns> An object representing collection of SubscriptionGovernanceRuleResources and their operations over a SubscriptionGovernanceRuleResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public virtual SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules()
        {
            return GetCachedClient(Client => new SubscriptionGovernanceRuleCollection(Client, Id));
        }

        /// <summary>
        /// Get a specific governanceRule for the requested scope by ruleId
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GovernanceRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public virtual async Task<Response<SubscriptionGovernanceRuleResource>> GetSubscriptionGovernanceRuleAsync(string ruleId, CancellationToken cancellationToken = default)
        {
            return await GetSubscriptionGovernanceRules().GetAsync(ruleId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a specific governanceRule for the requested scope by ruleId
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GovernanceRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public virtual Response<SubscriptionGovernanceRuleResource> GetSubscriptionGovernanceRule(string ruleId, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionGovernanceRules().Get(ruleId, cancellationToken);
        }
    }
}
