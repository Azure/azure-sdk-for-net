// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    internal partial class VirtualNetworkPeeringPropertiesFormat
    {
        // Both this WritableSubResource facade and RemoteVirtualNetworkId shipped publicly in 1.17.
        // Keep one mutable reference for the two APIs and generated serialization.
        /// <summary> The reference to the remote virtual network. </summary>
        [CodeGenMember("RemoteVirtualNetwork")]
        public WritableSubResource RemoteVirtualNetwork { get; set; }
    }
}
