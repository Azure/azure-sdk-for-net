// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class VirtualNetworkData
    {
        // Native regeneration omits this released getter (CP0002); AddressSpace also contains IPAM allocations.
        /// <summary> A list of address blocks reserved for this virtual network in CIDR notation. </summary>
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
