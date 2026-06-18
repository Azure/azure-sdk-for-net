// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the NetworkManagerDeploymentStatus type. </summary>
    public partial class NetworkManagerDeploymentStatus
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.NetworkManagerDeploymentState> DeploymentState => default;
    }
}
