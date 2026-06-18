// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the LoadBalancerCollection type. </summary>
    public partial class LoadBalancerCollection
    {
        /// <summary> Invokes the GetIfExists compatibility operation. </summary>
        public virtual global::Azure.NullableResponse<global::Azure.ResourceManager.Network.LoadBalancerResource> GetIfExists(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        /// <summary> Invokes the Get compatibility operation. </summary>
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource> Get(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        /// <summary> Invokes the Exists compatibility operation. </summary>
        public virtual global::Azure.Response<global::System.Boolean> Exists(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        /// <summary> Invokes the GetIfExistsAsync compatibility operation. </summary>
        public virtual global::System.Threading.Tasks.Task<global::Azure.NullableResponse<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetIfExistsAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        /// <summary> Invokes the GetAsync compatibility operation. </summary>
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
        /// <summary> Invokes the ExistsAsync compatibility operation. </summary>
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::System.Boolean>> ExistsAsync(global::System.String p0, global::System.String p1, global::System.Threading.CancellationToken p2) => default;
    }
}
