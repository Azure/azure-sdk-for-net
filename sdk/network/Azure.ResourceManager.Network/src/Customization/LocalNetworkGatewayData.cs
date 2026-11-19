// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class LocalNetworkGatewayData
    {
        // 1.15.0 exposes this custom convenience list alongside public LocalNetworkAddressSpace; flattening would remove that contract.
        /// <summary> Gets the local network address prefixes in CIDR notation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> LocalNetworkAddressPrefixes
        {
            get
            {
                LocalNetworkAddressSpace ??= new VirtualNetworkAddressSpace();
                return LocalNetworkAddressSpace.AddressPrefixes;
            }
        }
    }
}
