// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    public partial class VirtualNetworkGatewayConnectionListEntity
    {
        /// <summary> Initializes a new instance of <see cref="VirtualNetworkGatewayConnectionListEntity"/>. </summary>
        /// <param name="virtualNetworkGateway1"> The reference to virtual network gateway resource. </param>
        /// <param name="connectionType"> The gateway connection type. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualNetworkGateway1"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VirtualNetworkGatewayConnectionListEntity(WritableSubResource virtualNetworkGateway1, VirtualNetworkGatewayConnectionType connectionType)
        {
            Argument.AssertNotNull(virtualNetworkGateway1, nameof(virtualNetworkGateway1));

            ConnectionType = connectionType;
            // The released overload allows a non-null reference whose ID is null.
            Properties.VirtualNetworkGateway1 = new VirtualNetworkConnectionGatewayReference(virtualNetworkGateway1.Id, additionalBinaryDataProperties: null);
        }
    }
}
