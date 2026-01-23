// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Profile of the managed cluster load balancer. </summary>
    public partial class ManagedClusterLoadBalancerProfile
    {
        /// <summary> The effective outbound IP resources of the cluster load balancer. </summary>
        [WirePath("effectiveOutboundIPs")]
        public IList<WritableSubResource> EffectiveOutboundIPs { get; }
    }
}
