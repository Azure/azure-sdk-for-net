// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

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
    public static partial class NetworkExtensions
    {
        public static AsyncPageable<ExpressRouteGatewayResource> GetExpressRouteGatewaysAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetExpressRouteGatewaysAsync(cancellationToken);
        public static Pageable<ExpressRouteGatewayResource> GetExpressRouteGateways(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetExpressRouteGateways(cancellationToken);
        public static AsyncPageable<ApplicationGatewayFirewallRuleSet> GetAppGatewayAvailableWafRuleSetsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetAppGatewayAvailableWafRuleSetsAsync(cancellationToken);
        public static Pageable<ApplicationGatewayFirewallRuleSet> GetAppGatewayAvailableWafRuleSets(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetAppGatewayAvailableWafRuleSets(cancellationToken);
        public static AsyncPageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsyncAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewayAvailableWafRuleSetsAsyncAsync(cancellationToken);
        public static Pageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewayAvailableWafRuleSetsAsync(cancellationToken);
        public static AsyncPageable<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewayAvailableSslPredefinedPoliciesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new Mocking.MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewayAvailableSslPredefinedPoliciesAsync(cancellationToken);
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
