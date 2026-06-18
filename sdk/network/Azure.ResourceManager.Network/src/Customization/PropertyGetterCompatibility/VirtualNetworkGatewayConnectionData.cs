// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VirtualNetworkGatewayConnectionData type. </summary>
    public partial class VirtualNetworkGatewayConnectionData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.GatewayCustomBgpIPAddressIPConfiguration> GatewayCustomBgpIPAddresses => default;
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.IPsecPolicy> IPsecPolicies => default;
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Boolean> UseLocalAzureIPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
