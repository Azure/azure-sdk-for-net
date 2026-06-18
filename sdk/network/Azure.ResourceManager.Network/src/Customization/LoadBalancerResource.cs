// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the LoadBalancerResource type. </summary>
    public partial class LoadBalancerResource
    {
        /// <summary> Invokes the Get compatibility operation. </summary>
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource> Get(global::System.String p0, global::System.Threading.CancellationToken p1) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the MigrateToIPBased compatibility operation. </summary>
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.Models.MigrateLoadBalancerToIPBasedResult> MigrateToIPBased(global::Azure.ResourceManager.Network.Models.MigrateLoadBalancerToIPBasedContent p0, global::System.Threading.CancellationToken p1) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetAsync compatibility operation. </summary>
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetAsync(global::System.String p0, global::System.Threading.CancellationToken p1) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the MigrateToIPBasedAsync compatibility operation. </summary>
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.Models.MigrateLoadBalancerToIPBasedResult>> MigrateToIPBasedAsync(global::Azure.ResourceManager.Network.Models.MigrateLoadBalancerToIPBasedContent p0, global::System.Threading.CancellationToken p1) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
