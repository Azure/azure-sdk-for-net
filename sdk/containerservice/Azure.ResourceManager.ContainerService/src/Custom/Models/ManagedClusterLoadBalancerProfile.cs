// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class ManagedClusterLoadBalancerProfile
    {
        /// <summary> Whether to enable multiple standard load balancers. </summary>
        [WirePath("enableMultipleStandardLoadBalancers")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableMultipleStandardLoadBalancers { get => IsMultipleStandardLoadBalancersEnabled; set => IsMultipleStandardLoadBalancersEnabled = value; }

        /// <summary> The effective outbound IP resources of the cluster load balancer. </summary>
        [WirePath("effectiveOutboundIPs")]
        public IList<WritableSubResource> EffectiveOutboundIPs { get; }  // Make the EffectiveOutboundIPs as IList for backward compatibility.
    }
}
