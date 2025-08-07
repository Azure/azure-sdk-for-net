// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary>
    /// Profile of network configuration.
    /// Serialized Name: ContainerServiceNetworkProfile
    /// </summary>
    public partial class ContainerServiceNetworkProfile
    {
        /// <summary> A CIDR notation IP range assigned to the Docker bridge network. It must not overlap with any Subnet IP ranges or the Kubernetes service address range. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DockerBridgeCidr { get; set; }
    }
}