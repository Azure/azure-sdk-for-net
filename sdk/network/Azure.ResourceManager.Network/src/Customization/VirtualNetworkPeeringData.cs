// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class VirtualNetworkPeeringData
    {
        // Preserve the flattened API because the address-space model now has multiple properties and is no longer flattened.
        /// <summary> A list of address blocks reserved for this virtual network in CIDR notation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.localAddressSpace.addressPrefixes")]
        public IList<string> LocalAddressPrefixes
        {
            get
            {
                LocalAddressSpace ??= new VirtualNetworkAddressSpace();
                return LocalAddressSpace.AddressPrefixes;
            }
        }

        // Preserve the flattened API because the address-space model now has multiple properties and is no longer flattened.
        /// <summary> A list of address blocks reserved for this virtual network in CIDR notation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.localVirtualNetworkAddressSpace.addressPrefixes")]
        public IList<string> LocalVirtualNetworkAddressPrefixes
        {
            get
            {
                LocalVirtualNetworkAddressSpace ??= new VirtualNetworkAddressSpace();
                return LocalVirtualNetworkAddressSpace.AddressPrefixes;
            }
        }

        // Preserve the flattened API because the address-space model now has multiple properties and is no longer flattened.
        /// <summary> A list of address blocks reserved for this virtual network in CIDR notation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.remoteAddressSpace.addressPrefixes")]
        public IList<string> RemoteAddressPrefixes
        {
            get
            {
                RemoteAddressSpace ??= new VirtualNetworkAddressSpace();
                return RemoteAddressSpace.AddressPrefixes;
            }
        }

        // Preserve the flattened API because the address-space model now has multiple properties and is no longer flattened.
        /// <summary> A list of address blocks reserved for this virtual network in CIDR notation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.remoteVirtualNetworkAddressSpace.addressPrefixes")]
        public IList<string> RemoteVirtualNetworkAddressPrefixes
        {
            get
            {
                RemoteVirtualNetworkAddressSpace ??= new VirtualNetworkAddressSpace();
                return RemoteVirtualNetworkAddressSpace.AddressPrefixes;
            }
        }
    }
}
