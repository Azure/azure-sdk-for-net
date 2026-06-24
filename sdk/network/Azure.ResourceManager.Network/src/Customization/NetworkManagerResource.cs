// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkManagerResource type. </summary>
    public partial class NetworkManagerResource
    {
        /// <summary> Invokes the GetNetworkManagerDeploymentStatusAsync compatibility operation. </summary>
        public virtual global::Azure.AsyncPageable<global::Azure.ResourceManager.Network.Models.NetworkManagerDeploymentStatus> GetNetworkManagerDeploymentStatusAsync(global::Azure.ResourceManager.Network.Models.NetworkManagerDeploymentStatusContent p0, global::System.Nullable<global::System.Int32> p1, global::System.Threading.CancellationToken p2) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetNetworkManagerDeploymentStatus compatibility operation. </summary>
        public virtual global::Azure.Pageable<global::Azure.ResourceManager.Network.Models.NetworkManagerDeploymentStatus> GetNetworkManagerDeploymentStatus(global::Azure.ResourceManager.Network.Models.NetworkManagerDeploymentStatusContent p0, global::System.Nullable<global::System.Int32> p1, global::System.Threading.CancellationToken p2) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
