// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing the LocalNetworkGateway data model.
    /// A common class for general resource information.
    /// </summary>
    public partial class LocalNetworkGatewayData : NetworkTrackedResourceData
    {
        /// <summary> A list of address blocks reserved for this virtual network in CIDR notation. </summary>
        public IList<string> LocalNetworkAddressPrefixes
        {
            get
            {
                if (LocalNetworkAddressSpace is null)
                    LocalNetworkAddressSpace = new VirtualNetworkAddressSpace();
                return LocalNetworkAddressSpace.AddressPrefixes;
            }
        }
   }
}
