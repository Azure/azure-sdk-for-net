// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Mocking
{
    public partial class MockableNetworkResourceGroupResource
    {
        public virtual global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService(global::Azure.WaitUntil waitUntil, global::Azure.Core.AzureLocation location, global::Azure.ResourceManager.Network.Models.CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, global::System.Threading.CancellationToken cancellationToken) => default;
        public virtual global::Azure.ResourceManager.Network.CloudServiceSwapCollection GetCloudServiceSwaps(global::System.String cloudServiceName)
            => Client.GetCloudServiceSwaps(new global::Azure.Core.ResourceIdentifier($"{Id}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}"));
        [global::Azure.Core.ForwardsClientCalls]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource> GetCloudServiceSwap(global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken)
            => GetCloudServiceSwaps(cloudServiceName).Get(cancellationToken);
        [global::Azure.Core.ForwardsClientCalls]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource> GetLoadBalancer(global::System.String loadBalancerName, global::System.String frontendIPConfigurationName, global::System.Threading.CancellationToken cancellationToken) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(global::Azure.WaitUntil waitUntil, global::Azure.Core.AzureLocation location, global::Azure.ResourceManager.Network.Models.CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, global::System.Threading.CancellationToken cancellationToken) => default;
        [global::Azure.Core.ForwardsClientCalls]
        public virtual async global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource>> GetCloudServiceSwapAsync(global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken)
            => await GetCloudServiceSwaps(cloudServiceName).GetAsync(cancellationToken).ConfigureAwait(false);
        [global::Azure.Core.ForwardsClientCalls]
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetLoadBalancerAsync(global::System.String loadBalancerName, global::System.String frontendIPConfigurationName, global::System.Threading.CancellationToken cancellationToken) => default;
    }
}
