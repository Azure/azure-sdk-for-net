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

namespace Azure.ResourceManager.Network.Mocking
{
    /// <summary> Compatibility declaration for the MockableNetworkSubscriptionResource type. </summary>
    public partial class MockableNetworkSubscriptionResource
    {
        /// <summary> Invokes the GetExpressRouteGatewaysAsync compatibility operation. </summary>
        public virtual AsyncPageable<ExpressRouteGatewayResource> GetExpressRouteGatewaysAsync(CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetExpressRouteGateways compatibility operation. </summary>
        public virtual Pageable<ExpressRouteGatewayResource> GetExpressRouteGateways(CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetAppGatewayAvailableWafRuleSetsAsync compatibility operation. </summary>
        public virtual AsyncPageable<ApplicationGatewayFirewallRuleSet> GetAppGatewayAvailableWafRuleSetsAsync(CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetAppGatewayAvailableWafRuleSets compatibility operation. </summary>
        public virtual Pageable<ApplicationGatewayFirewallRuleSet> GetAppGatewayAvailableWafRuleSets(CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetApplicationGatewayAvailableWafRuleSetsAsyncAsync compatibility operation. </summary>
        public virtual AsyncPageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsyncAsync(CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetApplicationGatewayAvailableWafRuleSetsAsync compatibility operation. </summary>
        public virtual Pageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsync(CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetApplicationGatewayAvailableSslPredefinedPoliciesAsync compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual AsyncPageable<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewayAvailableSslPredefinedPoliciesAsync(CancellationToken cancellationToken)
        {
            var resource = Client.GetApplicationGatewayAvailableSslOptionsInfoResource(ApplicationGatewayAvailableSslOptionsInfoResource.CreateResourceIdentifier(Id.SubscriptionId));
            return new AsyncPageableWrapper<ApplicationGatewaySslPredefinedPolicy, ApplicationGatewaySslPredefinedPolicy>(resource.GetAvailableSslPredefinedPoliciesAsync(cancellationToken), policy => NetworkExtensions.NormalizeApplicationGatewaySslPredefinedPolicy(policy, Id.SubscriptionId));
        }
        /// <summary> Invokes the GetApplicationGatewayAvailableSslPredefinedPolicies compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual Pageable<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewayAvailableSslPredefinedPolicies(CancellationToken cancellationToken)
        {
            var resource = Client.GetApplicationGatewayAvailableSslOptionsInfoResource(ApplicationGatewayAvailableSslOptionsInfoResource.CreateResourceIdentifier(Id.SubscriptionId));
            return new PageableWrapper<ApplicationGatewaySslPredefinedPolicy, ApplicationGatewaySslPredefinedPolicy>(resource.GetAvailableSslPredefinedPolicies(cancellationToken), policy => NetworkExtensions.NormalizeApplicationGatewaySslPredefinedPolicy(policy, Id.SubscriptionId));
        }
    }
}
