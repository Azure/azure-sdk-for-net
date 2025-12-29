// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
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

        /// <summary> IP families are used to determine single-stack or dual-stack clusters. For single-stack, the expected value is IPv4. For dual-stack, the expected values are IPv4 and IPv6. </summary>
        [WirePath("ipFamilies")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This class is obsolete and will be removed in a future release, please use NetworkIPFamilies", false)]
        public IList<IPFamily> IPFamilies { get; }
    }
}