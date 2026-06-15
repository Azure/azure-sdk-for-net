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

namespace Azure.ResourceManager.Network.Mocking
{
    public partial class MockableNetworkSubscriptionResource
    {
        public virtual AsyncPageable<ExpressRouteGatewayResource> GetExpressRouteGatewaysAsync(CancellationToken cancellationToken) => default;
        public virtual Pageable<ExpressRouteGatewayResource> GetExpressRouteGateways(CancellationToken cancellationToken) => default;
        public virtual AsyncPageable<ApplicationGatewayFirewallRuleSet> GetAppGatewayAvailableWafRuleSetsAsync(CancellationToken cancellationToken) => default;
        public virtual Pageable<ApplicationGatewayFirewallRuleSet> GetAppGatewayAvailableWafRuleSets(CancellationToken cancellationToken) => default;
        public virtual AsyncPageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsyncAsync(CancellationToken cancellationToken) => default;
        public virtual Pageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsync(CancellationToken cancellationToken) => default;
        [ForwardsClientCalls]
        public virtual AsyncPageable<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewayAvailableSslPredefinedPoliciesAsync(CancellationToken cancellationToken)
        {
            var resource = Client.GetApplicationGatewayAvailableSslOptionsInfoResource(ApplicationGatewayAvailableSslOptionsInfoResource.CreateResourceIdentifier(Id.SubscriptionId));
            return new AsyncPageableWrapper<ApplicationGatewaySslPredefinedPolicy, ApplicationGatewaySslPredefinedPolicy>(resource.GetAvailableSslPredefinedPoliciesAsync(cancellationToken), policy => NetworkExtensions.NormalizeApplicationGatewaySslPredefinedPolicy(policy, Id.SubscriptionId));
        }
        [ForwardsClientCalls]
        public virtual Pageable<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewayAvailableSslPredefinedPolicies(CancellationToken cancellationToken)
        {
            var resource = Client.GetApplicationGatewayAvailableSslOptionsInfoResource(ApplicationGatewayAvailableSslOptionsInfoResource.CreateResourceIdentifier(Id.SubscriptionId));
            return new PageableWrapper<ApplicationGatewaySslPredefinedPolicy, ApplicationGatewaySslPredefinedPolicy>(resource.GetAvailableSslPredefinedPolicies(cancellationToken), policy => NetworkExtensions.NormalizeApplicationGatewaySslPredefinedPolicy(policy, Id.SubscriptionId));
        }
    }
}
