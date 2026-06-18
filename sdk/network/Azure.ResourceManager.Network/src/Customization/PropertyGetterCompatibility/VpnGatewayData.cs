// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VpnGatewayData type. </summary>
    public partial class VpnGatewayData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.VpnGatewayIPConfiguration> IPConfigurations { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.VpnGatewayIPConfiguration>();
    }
}
