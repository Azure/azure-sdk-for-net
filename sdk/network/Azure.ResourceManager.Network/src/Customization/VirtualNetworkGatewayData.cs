// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing the VirtualNetworkGateway data model.
    /// A common class for general resource information.
    /// </summary>
    public partial class VirtualNetworkGatewayData : NetworkTrackedResourceData
    {
        /// <summary> A list of address blocks reserved for this virtual network in CIDR notation. </summary>
        public IList<string> CustomRoutesAddressPrefixes
        {
            get
            {
                if (CustomRoutes is null)
                    CustomRoutes = new VirtualNetworkAddressSpace();
                return CustomRoutes.AddressPrefixes;
            }
        }
    }
}
