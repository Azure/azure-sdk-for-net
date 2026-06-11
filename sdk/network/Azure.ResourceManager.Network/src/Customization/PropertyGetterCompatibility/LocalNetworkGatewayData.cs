// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class LocalNetworkGatewayData
    {
        public global::System.String GatewayIPAddress
        {
            get => GatewayIpAddress;
            set => GatewayIpAddress = value;
        }
        public global::System.Collections.Generic.IList<global::System.String> LocalNetworkAddressPrefixes => default;
    }
}
