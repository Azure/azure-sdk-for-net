// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Models
{
    public partial class VirtualNetworkGatewayConnectionListEntity
    {
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.GatewayCustomBgpIPAddressIPConfiguration> GatewayCustomBgpIPAddresses => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.IPsecPolicy> IPsecPolicies => default;
    }
}
