// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.SecurityCenter. </summary>
    public static partial class SecurityCenterExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="SubscriptionGovernanceRuleResource" /> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SubscriptionGovernanceRuleResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release. Please use GetGovernanceRuleResource.", false)]
        public static SubscriptionGovernanceRuleResource GetSubscriptionGovernanceRuleResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableSecurityCenterArmClient(client).GetSubscriptionGovernanceRuleResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="SecurityConnectorGovernanceRuleResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SecurityConnectorGovernanceRuleResource.CreateResourceIdentifier" /> to create a <see cref="SecurityConnectorGovernanceRuleResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SecurityConnectorGovernanceRuleResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public static SecurityConnectorGovernanceRuleResource GetSecurityConnectorGovernanceRuleResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableSecurityCenterArmClient(client).GetSecurityConnectorGovernanceRuleResource(id);
        }

        /// <summary> Gets a collection of SubscriptionGovernanceRuleResources in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of SubscriptionGovernanceRuleResources and their operations over a SubscriptionGovernanceRuleResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public static SubscriptionGovernanceRuleCollection GetSubscriptionGovernanceRules(this SubscriptionResource subscriptionResource)
        {
            return GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSubscriptionGovernanceRules();
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
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public static async Task<Response<SubscriptionGovernanceRuleResource>> GetSubscriptionGovernanceRuleAsync(this SubscriptionResource subscriptionResource, string ruleId, CancellationToken cancellationToken = default)
        {
            return await GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSubscriptionGovernanceRuleAsync(ruleId, cancellationToken).ConfigureAwait(false);
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
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="ruleId"> The security GovernanceRule key - unique key for the standard GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleId"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public static Response<SubscriptionGovernanceRuleResource> GetSubscriptionGovernanceRule(this SubscriptionResource subscriptionResource, string ruleId, CancellationToken cancellationToken = default)
        {
            return GetMockableSecurityCenterSubscriptionResource(subscriptionResource).GetSubscriptionGovernanceRule(ruleId, cancellationToken);
        }
    }
}
