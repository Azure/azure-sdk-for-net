// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing the VirtualNetworkPeering data model.
    /// Peerings in a virtual network resource.
    /// </summary>
    public partial class VirtualNetworkPeeringData : NetworkWritableResourceData
    {
        /// <summary> A list of address blocks reserved for this virtual network in CIDR notation. </summary>
        public IList<string> LocalAddressPrefixes
        {
            get
            {
                if (LocalAddressSpace is null)
                    LocalAddressSpace = new VirtualNetworkAddressSpace();
                return LocalAddressSpace.AddressPrefixes;
            }
        }

        /// <summary> A list of address blocks reserved for this virtual network in CIDR notation. </summary>
        public IList<string> LocalVirtualNetworkAddressPrefixes
        {
            get
            {
                if (LocalVirtualNetworkAddressSpace is null)
                    LocalVirtualNetworkAddressSpace = new VirtualNetworkAddressSpace();
                return LocalVirtualNetworkAddressSpace.AddressPrefixes;
            }
        }

        /// <summary> A list of address blocks reserved for this virtual network in CIDR notation. </summary>
        public IList<string> RemoteAddressPrefixes
        {
            get
            {
                if (RemoteAddressSpace is null)
                    RemoteAddressSpace = new VirtualNetworkAddressSpace();
                return RemoteAddressSpace.AddressPrefixes;
            }
        }

        /// <summary> A list of address blocks reserved for this virtual network in CIDR notation. </summary>
        public IList<string> RemoteVirtualNetworkAddressPrefixes
        {
            get
            {
                if (RemoteVirtualNetworkAddressSpace is null)
                    RemoteVirtualNetworkAddressSpace = new VirtualNetworkAddressSpace();
                return RemoteVirtualNetworkAddressSpace.AddressPrefixes;
            }
        }
    }
}
