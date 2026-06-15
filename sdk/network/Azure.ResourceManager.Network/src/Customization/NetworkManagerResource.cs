// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class NetworkManagerResource
    {
        public virtual global::Azure.AsyncPageable<global::Azure.ResourceManager.Network.Models.NetworkManagerDeploymentStatus> GetNetworkManagerDeploymentStatusAsync(global::Azure.ResourceManager.Network.Models.NetworkManagerDeploymentStatusContent p0, global::System.Nullable<global::System.Int32> p1, global::System.Threading.CancellationToken p2) => default;
        public virtual global::Azure.Pageable<global::Azure.ResourceManager.Network.Models.NetworkManagerDeploymentStatus> GetNetworkManagerDeploymentStatus(global::Azure.ResourceManager.Network.Models.NetworkManagerDeploymentStatusContent p0, global::System.Nullable<global::System.Int32> p1, global::System.Threading.CancellationToken p2) => default;
    }
}
