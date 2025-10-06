// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> A vpn client connection configuration for client connection configuration. </summary>
    public partial class VngClientConnectionConfiguration : NetworkResourceData
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
    }
}
