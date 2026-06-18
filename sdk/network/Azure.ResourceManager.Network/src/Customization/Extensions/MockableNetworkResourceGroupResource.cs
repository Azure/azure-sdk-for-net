// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network.Mocking
{
    /// <summary> Compatibility declaration for the MockableNetworkResourceGroupResource type. </summary>
    public partial class MockableNetworkResourceGroupResource
    {
        /// <summary> Invokes the CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService compatibility operation. </summary>
        public virtual global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService(global::Azure.WaitUntil waitUntil, global::Azure.Core.AzureLocation location, global::Azure.ResourceManager.Network.Models.CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, global::System.Threading.CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetCloudServiceSwaps compatibility operation. </summary>
        public virtual global::Azure.ResourceManager.Network.CloudServiceSwapCollection GetCloudServiceSwaps(global::System.String cloudServiceName)
            => Client.GetCloudServiceSwaps(new global::Azure.Core.ResourceIdentifier($"{Id}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}"));
        /// <summary> Invokes the GetCloudServiceSwap compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource> GetCloudServiceSwap(global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken)
            => GetCloudServiceSwaps(cloudServiceName).Get(cancellationToken);
        /// <summary> Invokes the GetLoadBalancer compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource> GetLoadBalancer(global::System.String loadBalancerName, global::System.String frontendIPConfigurationName, global::System.Threading.CancellationToken cancellationToken) => default;
        /// <summary> Invokes the CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync compatibility operation. </summary>
        public virtual global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(global::Azure.WaitUntil waitUntil, global::Azure.Core.AzureLocation location, global::Azure.ResourceManager.Network.Models.CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, global::System.Threading.CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetCloudServiceSwapAsync compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual async global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource>> GetCloudServiceSwapAsync(global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken)
            => await GetCloudServiceSwaps(cloudServiceName).GetAsync(cancellationToken).ConfigureAwait(false);
        /// <summary> Invokes the GetLoadBalancerAsync compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetLoadBalancerAsync(global::System.String loadBalancerName, global::System.String frontendIPConfigurationName, global::System.Threading.CancellationToken cancellationToken) => default;
    }
}
