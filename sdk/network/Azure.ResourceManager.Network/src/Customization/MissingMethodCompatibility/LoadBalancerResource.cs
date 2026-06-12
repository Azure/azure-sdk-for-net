// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class LoadBalancerResource
    {
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource> Get(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.Models.MigrateLoadBalancerToIPBasedResult> MigrateToIPBased(global::Azure.ResourceManager.Network.Models.MigrateLoadBalancerToIPBasedContent p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetAsync(global::System.String p0, global::System.Threading.CancellationToken p1) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.MigrateLoadBalancerToIPBasedResult>> MigrateToIPBasedAsync(global::Azure.ResourceManager.Network.Models.MigrateLoadBalancerToIPBasedContent p0, global::System.Threading.CancellationToken p1) => default;
    }
}
