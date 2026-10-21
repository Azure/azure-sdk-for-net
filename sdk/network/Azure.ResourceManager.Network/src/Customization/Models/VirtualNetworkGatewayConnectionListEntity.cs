// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    public partial class VirtualNetworkGatewayConnectionListEntity
    {
        // Preserve the released overload without depending on the generated serialization constructor.
        /// <summary> Initializes a new instance of <see cref="VirtualNetworkGatewayConnectionListEntity"/>. </summary>
        /// <param name="localNetworkGateway2"> The local network gateway reference. </param>
        /// <param name="connectionType"> The gateway connection type. </param>
        public VirtualNetworkGatewayConnectionListEntity(WritableSubResource localNetworkGateway2, VirtualNetworkGatewayConnectionType connectionType)
        {
            ConnectionType = connectionType;
            LocalNetworkGateway2Id = localNetworkGateway2?.Id;
        }
    }
}
