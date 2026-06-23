// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the IpamPoolProperties type. </summary>
    public partial class IpamPoolProperties
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.IpamIPType> IPAddressType { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.IpamIPType>();
    }
}
