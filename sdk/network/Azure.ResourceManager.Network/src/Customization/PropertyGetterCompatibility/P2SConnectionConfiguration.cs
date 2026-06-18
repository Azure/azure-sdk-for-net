// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the P2SConnectionConfiguration type. </summary>
    public partial class P2SConnectionConfiguration
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> ConfigurationPolicyGroups => default;
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> VpnClientAddressPrefixes => default;
    }
}
