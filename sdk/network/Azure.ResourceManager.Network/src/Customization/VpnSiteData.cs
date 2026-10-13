// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VpnSiteData type. </summary>
    public partial class VpnSiteData
    {
        // Lazily restore the supported flattened facade using the native change-tracking list.
        /// <summary> Gets the address prefixes of the VPN site. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
