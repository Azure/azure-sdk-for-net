// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class VpnSiteData
    {
        // AddressSpace now also contains IPAM allocations, so it can no longer be safely flattened.
        /// <summary> Gets the address prefixes of the VPN site. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.addressSpace.addressPrefixes")]
        public IList<string> AddressPrefixes
        {
            get
            {
                AddressSpace ??= new VirtualNetworkAddressSpace();
                return AddressSpace.AddressPrefixes;
            }
        }
    }
}
