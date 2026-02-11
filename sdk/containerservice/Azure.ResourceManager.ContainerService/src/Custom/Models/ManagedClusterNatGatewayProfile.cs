// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Profile of the managed cluster NAT gateway. </summary>
    public partial class ManagedClusterNatGatewayProfile
    {
        /// <summary> The effective outbound IP resources of the cluster NAT gateway. </summary>
        [WirePath("effectiveOutboundIPs")]
        public IList<WritableSubResource> EffectiveOutboundIPs { get; }
    }
}
