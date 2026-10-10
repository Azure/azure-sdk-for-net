// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the P2SConnectionConfiguration type. </summary>
    public partial class P2SConnectionConfiguration : NetworkResourceData
    {
        // Preserve the flattened API because the address-space model now has multiple properties and is no longer flattened.
        /// <summary> A list of address blocks reserved for P2S VPN clients in CIDR notation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.vpnClientAddressPool.addressPrefixes")]
        public IList<string> VpnClientAddressPrefixes
        {
            get
            {
                VpnClientAddressPool ??= new VirtualNetworkAddressSpace();
                return VpnClientAddressPool.AddressPrefixes;
            }
        }

        /// <summary> Gets or sets the RoutingConfiguration compatibility property. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and no longer functions.")]
        public RoutingConfiguration RoutingConfiguration { get; set; }

        /// <summary> Gets a read-only view of the configuration policy groups. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use ConfigurationPolicyGroups instead.")]
        public IReadOnlyList<WritableSubResource> ConfigurationPolicyGroupAssociations => new ReadOnlyCollection<WritableSubResource>(ConfigurationPolicyGroups);
    }
}
