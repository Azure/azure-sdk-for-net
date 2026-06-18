// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the VpnClientIPsecParameters type. </summary>
    public partial class VpnClientIPsecParameters
    {
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Network.Models.IPsecEncryption IPsecEncryption { get; set; }
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Network.Models.IPsecIntegrity IPsecIntegrity { get; set; }
    }
}
