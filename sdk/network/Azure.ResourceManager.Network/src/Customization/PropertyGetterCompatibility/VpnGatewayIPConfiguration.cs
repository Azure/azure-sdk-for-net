// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the VpnGatewayIPConfiguration type. </summary>
    public partial class VpnGatewayIPConfiguration
    {
        /// <summary> Compatibility member. </summary>
        public global::System.String PrivateIPAddress { get; }
        /// <summary> Compatibility member. </summary>
        public global::System.String PublicIPAddress { get; }
    }
}
