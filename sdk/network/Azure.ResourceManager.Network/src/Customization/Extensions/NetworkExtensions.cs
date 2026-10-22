// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Network.Mocking;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    public static partial class NetworkExtensions
    {
        /// <summary> Invokes the SwapPublicIPAddressesLoadBalancer compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future version. Please use SwapPublicIPAddresses instead.")]
        public static ArmOperation SwapPublicIPAddressesLoadBalancer(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, LoadBalancerVipSwapContent content, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).SwapPublicIPAddresses(waitUntil, location, content, cancellationToken);
        /// <summary> Invokes the GetCloudServiceSwaps compatibility operation. </summary>
        public static CloudServiceSwapCollection GetCloudServiceSwaps(this ResourceGroupResource resourceGroupResource, string cloudServiceName)
            => resourceGroupResource.GetCachedClient(client => new MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServiceSwaps(cloudServiceName);
        /// <summary> Invokes the GetVirtualMachineScaleSetNetworkResource compatibility operation. </summary>
        public static VirtualMachineScaleSetNetworkResource GetVirtualMachineScaleSetNetworkResource(this ArmClient client, ResourceIdentifier id)
            => client.GetCachedClient(armClient => new MockableNetworkArmClient(armClient, id)).GetVirtualMachineScaleSetNetworkResource(id);
        /// <summary> Invokes the GetVirtualMachineScaleSetVmNetworkResource compatibility operation. </summary>
        public static VirtualMachineScaleSetVmNetworkResource GetVirtualMachineScaleSetVmNetworkResource(this ArmClient client, ResourceIdentifier id)
            => client.GetCachedClient(armClient => new MockableNetworkArmClient(armClient, id)).GetVirtualMachineScaleSetVmNetworkResource(id);
        /// <summary> Invokes the GetCloudServiceSwap compatibility operation. </summary>
        [ForwardsClientCalls]
        public static Response<CloudServiceSwapResource> GetCloudServiceSwap(this ResourceGroupResource resourceGroupResource, string cloudServiceName, CancellationToken cancellationToken)
            => resourceGroupResource.GetCachedClient(client => new MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServiceSwap(cloudServiceName, cancellationToken);
        /// <summary> Invokes the GetApplicationGatewayAvailableSslOptions compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetApplicationGatewayAvailableSslOptionsInfo().Get() instead.")]
        public static Response<ApplicationGatewayAvailableSslOptionsInfo> GetApplicationGatewayAvailableSslOptions(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewayAvailableSslOptions(cancellationToken);
        /// <summary> Invokes the GetApplicationGatewaySslPredefinedPolicy compatibility operation. </summary>
        public static Response<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewaySslPredefinedPolicy(this SubscriptionResource subscriptionResource, string predefinedPolicyName, CancellationToken cancellationToken)
            => subscriptionResource.GetCachedClient(client => new MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewaySslPredefinedPolicy(predefinedPolicyName, cancellationToken);
        /// <summary> Invokes the SwapPublicIPAddressesLoadBalancerAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future version. Please use SwapPublicIPAddressesAsync instead.")]
        public static Task<ArmOperation> SwapPublicIPAddressesLoadBalancerAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, LoadBalancerVipSwapContent content, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).SwapPublicIPAddressesAsync(waitUntil, location, content, cancellationToken);
        /// <summary> Invokes the GetCloudServiceSwapAsync compatibility operation. </summary>
        [ForwardsClientCalls]
        public static Task<Response<CloudServiceSwapResource>> GetCloudServiceSwapAsync(this ResourceGroupResource resourceGroupResource, string cloudServiceName, CancellationToken cancellationToken)
            => resourceGroupResource.GetCachedClient(client => new MockableNetworkResourceGroupResource(client, resourceGroupResource.Id)).GetCloudServiceSwapAsync(cloudServiceName, cancellationToken);
        /// <summary> Invokes the GetApplicationGatewayAvailableSslOptionsAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetApplicationGatewayAvailableSslOptionsInfo().GetAsync() instead.")]
        public static async Task<Response<ApplicationGatewayAvailableSslOptionsInfo>> GetApplicationGatewayAvailableSslOptionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => await subscriptionResource.GetCachedClient(client => new MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewayAvailableSslOptionsAsync(cancellationToken).ConfigureAwait(false);
        /// <summary> Invokes the GetApplicationGatewaySslPredefinedPolicyAsync compatibility operation. </summary>
        public static async Task<Response<ApplicationGatewaySslPredefinedPolicy>> GetApplicationGatewaySslPredefinedPolicyAsync(this SubscriptionResource subscriptionResource, string predefinedPolicyName, CancellationToken cancellationToken)
            => await subscriptionResource.GetCachedClient(client => new MockableNetworkSubscriptionResource(client, subscriptionResource.Id)).GetApplicationGatewaySslPredefinedPolicyAsync(predefinedPolicyName, cancellationToken).ConfigureAwait(false);

        // Preserve the released token-only signatures: adding an optional filter changes the binary signature.
        // The mockable adapters supply the default filter to the generated overloads.
        /// <summary> Gets all express route cross connections in a subscription. </summary>
        public static AsyncPageable<ExpressRouteCrossConnectionResource> GetExpressRouteCrossConnectionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetExpressRouteCrossConnectionsAsync(cancellationToken);

        /// <summary> Gets all express route cross connections in a subscription. </summary>
        public static Pageable<ExpressRouteCrossConnectionResource> GetExpressRouteCrossConnections(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetExpressRouteCrossConnections(cancellationToken);

        // Preserve the released signatures from before the optional detailLevel parameter was introduced.
        // The mockable adapters supply the default detail level to the generated overloads.
        /// <summary> Gets the specified load balancer. </summary>
        [ForwardsClientCalls]
        public static async Task<Response<LoadBalancerResource>> GetLoadBalancerAsync(this ResourceGroupResource resourceGroupResource, string loadBalancerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableNetworkResourceGroupResource(resourceGroupResource).GetLoadBalancerAsync(loadBalancerName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the specified load balancer. </summary>
        [ForwardsClientCalls]
        public static Response<LoadBalancerResource> GetLoadBalancer(this ResourceGroupResource resourceGroupResource, string loadBalancerName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetLoadBalancer(loadBalancerName, expand, cancellationToken);
        }

        // Keep the previously released, misleading names for binary compatibility.
        // These operations list policies across the subscription; GetServiceEndpointPolicies[Async] correctly describes that scope.
        /// <summary> Gets service endpoint policies. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetServiceEndpointPoliciesAsync instead.")]
        public static AsyncPageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicyAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetServiceEndpointPoliciesAsync(cancellationToken);

        /// <summary> Gets service endpoint policies. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use GetServiceEndpointPolicies instead.")]
        public static Pageable<ServiceEndpointPolicyResource> GetServiceEndpointPoliciesByServiceEndpointPolicy(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetServiceEndpointPolicies(cancellationToken);

        // Keep the released historical names for binary compatibility.
        // The PrivateLinkService suffix repeats what is already in the name; prefer the shorter generated names for the same operations.
        /// <summary> Checks private link service visibility by resource group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibilityAsync instead.")]
        public static Task<ArmOperation<PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, CancellationToken cancellationToken = default)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).CheckPrivateLinkServiceVisibilityAsync(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);

        /// <summary> Checks private link service visibility by resource group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibility instead.")]
        public static ArmOperation<PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, CancellationToken cancellationToken = default)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).CheckPrivateLinkServiceVisibility(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);

        /// <summary> Checks private link service visibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibilityAsync instead.")]
        public static Task<ArmOperation<PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityPrivateLinkServiceAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).CheckPrivateLinkServiceVisibilityAsync(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);

        /// <summary> Checks private link service visibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibility instead.")]
        public static ArmOperation<PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityPrivateLinkService(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).CheckPrivateLinkServiceVisibility(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);

        // Preserve the released regional facade; native subscription access does not retain a location.
        // The collection still performs true listing, for which no equivalent native public API exists.
        /// <summary> Gets the regional application gateway WAF manifest collection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This collection facade is deprecated and retained for backward compatibility. There is no equivalent native public listing API.")]
        public static ApplicationGatewayWafDynamicManifestCollection GetApplicationGatewayWafDynamicManifests(this SubscriptionResource subscriptionResource, AzureLocation location)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetApplicationGatewayWafDynamicManifests(location);
        }

        /// <summary> Gets the regional application gateway WAF singleton manifest. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ArmClient.GetApplicationGatewayWafDynamicManifestResource(ApplicationGatewayWafDynamicManifestResource.CreateResourceIdentifier(subscriptionId, location)).GetAsync(cancellationToken) instead.")]
        [ForwardsClientCalls]
        public static Task<Response<ApplicationGatewayWafDynamicManifestResource>> GetApplicationGatewayWafDynamicManifestAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetApplicationGatewayWafDynamicManifestAsync(location, cancellationToken);
        }

        /// <summary> Gets the regional application gateway WAF singleton manifest. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use ArmClient.GetApplicationGatewayWafDynamicManifestResource(ApplicationGatewayWafDynamicManifestResource.CreateResourceIdentifier(subscriptionId, location)).Get(cancellationToken) instead.")]
        [ForwardsClientCalls]
        public static Response<ApplicationGatewayWafDynamicManifestResource> GetApplicationGatewayWafDynamicManifest(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetworkSubscriptionResource(subscriptionResource).GetApplicationGatewayWafDynamicManifest(location, cancellationToken);
        }
    }
}
