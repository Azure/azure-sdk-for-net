// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class ManagedClusterNatGatewayProfile
    {
        /// <summary> The effective outbound IP resources of the cluster NAT gateway. </summary>
        [WirePath("effectiveOutboundIPs")]
        public IList<WritableSubResource> EffectiveOutboundIPs { get; }     // Make the EffectiveOutboundIPs as IList for backward compatibility.

        /// <summary> The desired number of outbound IPs created/managed by Azure. Allowed values must be in the range of 1 to 16 (inclusive). The default value is 1. </summary>
        [WirePath("managedOutboundIPProfile.count")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? ManagedOutboundIPCount
        {
            get => ManagedOutboundIPProfile is null ? default : ManagedOutboundIPProfile.Count;
            set
            {
                if (ManagedOutboundIPProfile is null)
                    ManagedOutboundIPProfile = new ManagedClusterManagedOutboundIPProfile();
                ManagedOutboundIPProfile.Count = value;
            }
        }
    }
}
