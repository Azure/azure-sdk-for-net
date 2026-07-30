// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkExtensions type. </summary>
    public static partial class NetworkExtensions
    {
        /// <summary> Invokes the GetExpressRouteGatewaysAsync compatibility operation. </summary>
        public static AsyncPageable<ExpressRouteGatewayResource> GetExpressRouteGatewaysAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetExpressRouteGatewaysAsync(cancellationToken);
        /// <summary> Invokes the GetExpressRouteGateways compatibility operation. </summary>
        public static Pageable<ExpressRouteGatewayResource> GetExpressRouteGateways(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetExpressRouteGateways(cancellationToken);
        /// <summary> Invokes the GetAppGatewayAvailableWafRuleSetsAsync compatibility operation. </summary>
        public static AsyncPageable<ApplicationGatewayFirewallRuleSet> GetAppGatewayAvailableWafRuleSetsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetAppGatewayAvailableWafRuleSetsAsync(cancellationToken);
        /// <summary> Invokes the GetAppGatewayAvailableWafRuleSets compatibility operation. </summary>
        public static Pageable<ApplicationGatewayFirewallRuleSet> GetAppGatewayAvailableWafRuleSets(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetAppGatewayAvailableWafRuleSets(cancellationToken);
        /// <summary> Invokes the GetApplicationGatewayAvailableWafRuleSetsAsyncAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsoleted and will be removed in a future release, please use `GetAppGatewayAvailableWafRuleSetsAsync` instead", false)]
        public static AsyncPageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsyncAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetAppGatewayAvailableWafRuleSetsAsync(subscriptionResource, cancellationToken);
        /// <summary> Invokes the GetApplicationGatewayAvailableWafRuleSetsAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsoleted and will be removed in a future release, please use `GetAppGatewayAvailableWafRuleSets` instead", false)]
        public static Pageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetAppGatewayAvailableWafRuleSets(subscriptionResource, cancellationToken);
        /// <summary> Invokes the GetApplicationGatewayAvailableSslPredefinedPoliciesAsync compatibility operation. </summary>
        public static AsyncPageable<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewayAvailableSslPredefinedPoliciesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewayAvailableSslPredefinedPoliciesAsync(cancellationToken);
        /// <summary> Invokes the GetApplicationGatewayAvailableSslPredefinedPolicies compatibility operation. </summary>
        public static Pageable<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewayAvailableSslPredefinedPolicies(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewayAvailableSslPredefinedPolicies(cancellationToken);

        internal static ApplicationGatewaySslPredefinedPolicy NormalizeApplicationGatewaySslPredefinedPolicy(ApplicationGatewaySslPredefinedPolicy policy, string subscriptionId)
        {
            if (policy is not null)
            {
                policy.Id = CreateApplicationGatewaySslPredefinedPolicyIdentifier(subscriptionId, policy.Name);
            }
            return policy;
        }

        internal static ResourceIdentifier CreateApplicationGatewaySslPredefinedPolicyIdentifier(string subscriptionId, string policyName)
            => new ResourceIdentifier($"/subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default/ApplicationGatewaySslPredefinedPolicy/{policyName}");
    }
}
