// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class VpnClientConfiguration
    {
        // Lazily restore the supported flattened facade using the native change-tracking list.
        /// <summary> Gets the VPN client address prefixes. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> VpnClientAddressPrefixes
        {
            get
            {
                VpnClientAddressPool ??= new VirtualNetworkAddressSpace();
                return VpnClientAddressPool.AddressPrefixes;
            }
        }
    }
}
