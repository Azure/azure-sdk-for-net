// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    public static partial class NetworkExtensions
    {
        /// <summary>
        /// Lists all available web application firewall rule sets.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableWafRuleSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApplicationGateways_ListAvailableWafRuleSets</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApplicationGatewayFirewallRuleSet" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future release, please use `GetAppGatewayAvailableWafRuleSetsAsync` instead", false)]
        public static AsyncPageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsyncAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAppGatewayAvailableWafRuleSetsAsync(cancellationToken);
        }

        /// <summary>
        /// Lists all available web application firewall rule sets.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableWafRuleSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApplicationGateways_ListAvailableWafRuleSets</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApplicationGatewayFirewallRuleSet" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future release, please use `GetAppGatewayAvailableWafRuleSets` instead", false)]
        public static Pageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetAppGatewayAvailableWafRuleSets(cancellationToken);
        }
    }
}
