// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing the VirtualNetwork data model.
    /// Virtual Network resource.
    /// </summary>
    public partial class VirtualNetworkData : NetworkTrackedResourceData
    {
        /// <summary> A list of address blocks reserved for this virtual network in CIDR notation. </summary>
        public IList<string> AddressPrefixes
        {
            get
            {
                if (AddressSpace is null)
                    AddressSpace = new VirtualNetworkAddressSpace();
                return AddressSpace.AddressPrefixes;
            }
        }
    }
}
