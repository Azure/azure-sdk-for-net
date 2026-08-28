// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the VpnClientConfiguration type. </summary>
    public partial class VpnClientConfiguration
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> VpnClientAddressPrefixes { get; } = new global::System.Collections.Generic.List<global::System.String>();
    }
}
