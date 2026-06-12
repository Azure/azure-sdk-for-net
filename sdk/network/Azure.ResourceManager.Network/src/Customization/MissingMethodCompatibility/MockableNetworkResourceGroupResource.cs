// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Mocking
{
    public partial class MockableNetworkResourceGroupResource
    {
        public virtual global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService(global::Azure.WaitUntil p0, global::Azure.Core.AzureLocation p1, global::Azure.ResourceManager.Network.Models.CheckPrivateLinkServiceVisibilityRequest p2, global::System.Threading.CancellationToken p3) => default;
        public virtual global::Azure.ResourceManager.Network.CloudServiceSwapCollection GetCloudServiceSwaps(global::System.String p0)
            => Client.GetCloudServiceSwaps(new global::Azure.Core.ResourceIdentifier($"{Id}/providers/Microsoft.Compute/cloudServices/{p0}"));
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource> GetCloudServiceSwap(global::System.String p0, global::System.Threading.CancellationToken p1)
            => GetCloudServiceSwaps(p0).Get(p1);
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource> GetLoadBalancer(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(global::Azure.WaitUntil p0, global::Azure.Core.AzureLocation p1, global::Azure.ResourceManager.Network.Models.CheckPrivateLinkServiceVisibilityRequest p2, global::System.Threading.CancellationToken p3) => default;
        public virtual async global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource>> GetCloudServiceSwapAsync(global::System.String p0, global::System.Threading.CancellationToken p1)
            => await GetCloudServiceSwaps(p0).GetAsync(p1).ConfigureAwait(false);
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetLoadBalancerAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
    }
}
