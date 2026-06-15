// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class LoadBalancerCollection
    {
        public virtual global::Azure.NullableResponse<global::Azure.ResourceManager.Network.LoadBalancerResource> GetIfExists(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource> Get(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::Azure.Response<global::System.Boolean> Exists(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.NullableResponse<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetIfExistsAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::System.Boolean>> ExistsAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
    }
}
