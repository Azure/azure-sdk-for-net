// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the BastionHostData type. </summary>
    public partial class BastionHostData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Boolean> EnableIPConnect { get; set; }
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.BastionHostIPConfiguration> IPConfigurations => IpConfigurations;
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.BastionHostIPRule> NetworkAclsIPRules { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.BastionHostIPRule>();
    }
}
