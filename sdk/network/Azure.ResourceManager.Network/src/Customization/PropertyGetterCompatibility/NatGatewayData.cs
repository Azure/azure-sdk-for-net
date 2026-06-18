// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NatGatewayData type. </summary>
    public partial class NatGatewayData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> PublicIPAddresses { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Resources.Models.WritableSubResource>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> PublicIPAddressesV6 { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Resources.Models.WritableSubResource>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> PublicIPPrefixes { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Resources.Models.WritableSubResource>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> PublicIPPrefixesV6 { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Resources.Models.WritableSubResource>();
    }
}
