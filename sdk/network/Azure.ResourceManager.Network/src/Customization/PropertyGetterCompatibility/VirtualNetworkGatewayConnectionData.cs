// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VirtualNetworkGatewayConnectionData type. </summary>
    public partial class VirtualNetworkGatewayConnectionData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.GatewayCustomBgpIPAddressIPConfiguration> GatewayCustomBgpIPAddresses { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.GatewayCustomBgpIPAddressIPConfiguration>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.IPsecPolicy> IPsecPolicies { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.IPsecPolicy>();
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Boolean> UseLocalAzureIPAddress { get; set; }
    }
}
