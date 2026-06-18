// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VpnServerConfigurationData type. </summary>
    public partial class VpnServerConfigurationData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.IPsecPolicy> VpnClientIPsecPolicies { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.IPsecPolicy>();
    }
}
