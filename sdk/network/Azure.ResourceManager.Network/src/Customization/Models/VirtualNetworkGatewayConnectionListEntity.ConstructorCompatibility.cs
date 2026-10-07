// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the VirtualNetworkGatewayConnectionListEntity type. </summary>
    [CodeGenSuppress("VirtualNetworkGatewayConnectionListEntity", typeof(WritableSubResource), typeof(VirtualNetworkGatewayConnectionType))]
    public partial class VirtualNetworkGatewayConnectionListEntity
    {
        /// <summary> Initializes a new instance of the VirtualNetworkGatewayConnectionListEntity class. </summary>
        public VirtualNetworkGatewayConnectionListEntity(WritableSubResource localNetworkGateway2, VirtualNetworkGatewayConnectionType connectionType)
            : this(new VirtualNetworkGatewayConnectionListEntityPropertiesFormat(
                null,
                null,
                null,
                new VirtualNetworkConnectionGatewayReference(localNetworkGateway2?.Id),
                connectionType,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null))
        {
        }
    }
}
