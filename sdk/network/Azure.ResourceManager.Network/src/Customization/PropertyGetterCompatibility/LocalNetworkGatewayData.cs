// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the LocalNetworkGatewayData type. </summary>
    public partial class LocalNetworkGatewayData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> LocalNetworkAddressPrefixes { get; } = new global::System.Collections.Generic.List<global::System.String>();
    }
}
