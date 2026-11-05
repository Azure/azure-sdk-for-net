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
        // Keep the released overloads dispatching to the same signatures on the mockable client.
        /// <summary>
        /// Gets the specified load balancer.
        /// To mock this method, mock <see cref="MockableNetworkResourceGroupResource.GetLoadBalancerAsync(string, string, CancellationToken)"/> instead.
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="loadBalancerName"> The name of the load balancer. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
#pragma warning disable AZC0002 // Making the trailing CancellationToken optional would introduce an ambiguous call with the new overload.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<LoadBalancerResource>> GetLoadBalancerAsync(this ResourceGroupResource resourceGroupResource, string loadBalancerName, string expand, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetLoadBalancerAsync(loadBalancerName, expand, cancellationToken);
        }
#pragma warning restore AZC0002

        /// <summary>
        /// Gets the specified load balancer.
        /// To mock this method, mock <see cref="MockableNetworkResourceGroupResource.GetLoadBalancer(string, string, CancellationToken)"/> instead.
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="loadBalancerName"> The name of the load balancer. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceGroupResource"/> is null. </exception>
#pragma warning disable AZC0002 // Making the trailing CancellationToken optional would introduce an ambiguous call with the new overload.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<LoadBalancerResource> GetLoadBalancer(this ResourceGroupResource resourceGroupResource, string loadBalancerName, string expand, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetLoadBalancer(loadBalancerName, expand, cancellationToken);
        }
#pragma warning restore AZC0002

        // Preserve the obsolete 1.15.0 AsyncAsync spelling; the active pageable API is generated natively.
        /// <summary> Gets the available application gateway WAF rule sets. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future release, please use `GetAppGatewayAvailableWafRuleSetsAsync` instead", false)]
        public static AsyncPageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsyncAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAppGatewayAvailableWafRuleSetsAsync(cancellationToken);

        // Preserve the obsolete 1.15.0 synchronous Async spelling without inventing an alias on the mockable class.
        /// <summary> Gets the available application gateway WAF rule sets. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future release, please use `GetAppGatewayAvailableWafRuleSets` instead", false)]
        public static Pageable<ApplicationGatewayFirewallRuleSet> GetApplicationGatewayAvailableWafRuleSetsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetAppGatewayAvailableWafRuleSets(cancellationToken);

        // Preserve the 1.15.0 subscription listing; the native operation belongs to the SSL-options resource.
        /// <summary> Gets the predefined application gateway SSL policies. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static AsyncPageable<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewayAvailableSslPredefinedPoliciesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetApplicationGatewayAvailableSslPredefinedPoliciesAsync(cancellationToken);

        // Preserve the 1.15.0 subscription receiver and its virtual mockable dispatch for native policy pages.
        /// <summary> Gets the predefined application gateway SSL policies. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Pageable<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewayAvailableSslPredefinedPolicies(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetApplicationGatewayAvailableSslPredefinedPolicies(cancellationToken);

        // 1.15.0 returns subscription-qualified policy IDs even when the service omits or changes the ID.
        internal static ApplicationGatewaySslPredefinedPolicy NormalizeApplicationGatewaySslPredefinedPolicy(ApplicationGatewaySslPredefinedPolicy policy, string subscriptionId)
        {
            if (policy is not null)
            {
                policy.Id = CreateApplicationGatewaySslPredefinedPolicyIdentifier(subscriptionId, policy.Name);
            }
            return policy;
        }

        // Keep the released policy identifier shape shared by both retained list and get operations.
        internal static ResourceIdentifier CreateApplicationGatewaySslPredefinedPolicyIdentifier(string subscriptionId, string policyName)
            => new ResourceIdentifier($"/subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default/ApplicationGatewaySslPredefinedPolicy/{policyName}");

        /// <summary> Invokes the SwapPublicIPAddressesLoadBalancer compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future version. Please use SwapPublicIPAddresses instead.")]
        public static ArmOperation SwapPublicIPAddressesLoadBalancer(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, LoadBalancerVipSwapContent content, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).SwapPublicIPAddresses(waitUntil, location, content, cancellationToken);

        // Native CloudSwap entry points are ArmClient-scoped, not resource-group methods.
        // Retain the released receiver and dispatch through its cached virtual mockable surface.
        /// <summary> Gets the swap collection for the specified cloud service. </summary>
        public static CloudServiceSwapCollection GetCloudServiceSwaps(this ResourceGroupResource resourceGroupResource, string resourceName)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).GetCloudServiceSwaps(resourceName);

        // Preserve the 1.15 ArmClient accessor for the custom aggregate VMSS facade, not a generated child resource.
        // Dispatch through MockableNetworkArmClient.GetVirtualMachineScaleSetNetworkResource; no HTTP is issued.
        /// <summary> Gets an object representing a virtual machine scale set with its network operations but no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetNetworkResource"/> object. </returns>
        public static VirtualMachineScaleSetNetworkResource GetVirtualMachineScaleSetNetworkResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableNetworkArmClient(client).GetVirtualMachineScaleSetNetworkResource(id);
        }

        // Preserve the 1.15 ArmClient accessor for the custom aggregate VM facade, not a generated child resource.
        // Dispatch through MockableNetworkArmClient.GetVirtualMachineScaleSetVmNetworkResource; no HTTP is issued.
        /// <summary> Gets an object representing a virtual machine scale set virtual machine with its network operations but no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> Returns a <see cref="VirtualMachineScaleSetVmNetworkResource"/> object. </returns>
        public static VirtualMachineScaleSetVmNetworkResource GetVirtualMachineScaleSetVmNetworkResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableNetworkArmClient(client).GetVirtualMachineScaleSetVmNetworkResource(id);
        }
        /// <summary> Gets the swap resource for the specified cloud service. </summary>
        [ForwardsClientCalls]
        public static Response<CloudServiceSwapResource> GetCloudServiceSwap(this ResourceGroupResource resourceGroupResource, string resourceName, CancellationToken cancellationToken = default)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).GetCloudServiceSwap(resourceName, cancellationToken);

        // The released subscription methods return the legacy model, not the native SSL-options resource.
        /// <summary> Gets the available SSL options in the released model shape. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetApplicationGatewayAvailableSslOptionsInfo().Get() instead.")]
        public static Response<ApplicationGatewayAvailableSslOptionsInfo> GetApplicationGatewayAvailableSslOptions(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetApplicationGatewayAvailableSslOptions(cancellationToken);

        // Native policy actions belong to the SSL-options resource; preserve subscription ownership and mock dispatch.
        /// <summary> Gets the specified SSL predefined policy. </summary>
        public static Response<ApplicationGatewaySslPredefinedPolicy> GetApplicationGatewaySslPredefinedPolicy(this SubscriptionResource subscriptionResource, string predefinedPolicyName, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetApplicationGatewaySslPredefinedPolicy(predefinedPolicyName, cancellationToken);

        /// <summary> Invokes the SwapPublicIPAddressesLoadBalancerAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsoleted and will be removed in a future version. Please use SwapPublicIPAddressesAsync instead.")]
        public static Task<ArmOperation> SwapPublicIPAddressesLoadBalancerAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, LoadBalancerVipSwapContent content, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).SwapPublicIPAddressesAsync(waitUntil, location, content, cancellationToken);

        /// <summary> Gets the swap resource for the specified cloud service. </summary>
        [ForwardsClientCalls]
        public static Task<Response<CloudServiceSwapResource>> GetCloudServiceSwapAsync(this ResourceGroupResource resourceGroupResource, string resourceName, CancellationToken cancellationToken = default)
            => GetMockableNetworkResourceGroupResource(resourceGroupResource).GetCloudServiceSwapAsync(resourceName, cancellationToken);

        /// <summary> Gets the available SSL options in the released model shape. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetApplicationGatewayAvailableSslOptionsInfo().GetAsync() instead.")]
        public static Task<Response<ApplicationGatewayAvailableSslOptionsInfo>> GetApplicationGatewayAvailableSslOptionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetApplicationGatewayAvailableSslOptionsAsync(cancellationToken);

        /// <summary> Gets the specified SSL predefined policy. </summary>
        public static Task<Response<ApplicationGatewaySslPredefinedPolicy>> GetApplicationGatewaySslPredefinedPolicyAsync(this SubscriptionResource subscriptionResource, string predefinedPolicyName, CancellationToken cancellationToken = default)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetApplicationGatewaySslPredefinedPolicyAsync(predefinedPolicyName, cancellationToken);

        // Preserve the released token-only signatures: adding an optional filter changes the binary signature.
        // The mockable adapters supply the default filter to the generated overloads.
        /// <summary> Gets all express route cross connections in a subscription. </summary>
        public static AsyncPageable<ExpressRouteCrossConnectionResource> GetExpressRouteCrossConnectionsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetExpressRouteCrossConnectionsAsync(cancellationToken);

        /// <summary> Gets all express route cross connections in a subscription. </summary>
        public static Pageable<ExpressRouteCrossConnectionResource> GetExpressRouteCrossConnections(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetMockableNetworkSubscriptionResource(subscriptionResource).GetExpressRouteCrossConnections(cancellationToken);

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
