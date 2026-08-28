// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkPrivateEndpointConnectionData type. </summary>
    public partial class NetworkPrivateEndpointConnectionData
    {
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Network.Models.NetworkPrivateLinkServiceConnectionState ConnectionState { get; set; }
    }
}
