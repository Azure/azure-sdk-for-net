// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> P2SConnectionConfiguration Resource. </summary>
    public partial class P2SConnectionConfiguration : NetworkResourceData
    {
        /// <summary> A list of address blocks reserved for this virtual network in CIDR notation. </summary>
        public IList<string> VpnClientAddressPrefixes
        {
            get
            {
                if (VpnClientAddressPool is null)
                    VpnClientAddressPool = new VirtualNetworkAddressSpace();
                return VpnClientAddressPool.AddressPrefixes;
            }
        }

        /// <summary> List of Configuration Policy Groups that this P2SConnectionConfiguration is attached to. </summary>
        public IReadOnlyList<WritableSubResource> ConfigurationPolicyGroupAssociations { get => (IReadOnlyList<WritableSubResource>)ConfigurationPolicyGroups; }
    }
}
