// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    internal partial class VirtualNetworkPeeringPropertiesFormat
    {
        // Replace the internal reference type so the flattened API preserves the released WritableSubResource property.
        /// <summary> The reference to the remote virtual network. </summary>
        public WritableSubResource RemoteVirtualNetwork { get; set; }
    }
}
