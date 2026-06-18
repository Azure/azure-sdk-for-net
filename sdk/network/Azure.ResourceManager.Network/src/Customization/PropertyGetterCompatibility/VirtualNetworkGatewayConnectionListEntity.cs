// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the VirtualNetworkGatewayConnectionListEntity type. </summary>
    public partial class VirtualNetworkGatewayConnectionListEntity
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.GatewayCustomBgpIPAddressIPConfiguration> GatewayCustomBgpIPAddresses { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.GatewayCustomBgpIPAddressIPConfiguration>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.IPsecPolicy> IPsecPolicies { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.IPsecPolicy>();
    }
}
