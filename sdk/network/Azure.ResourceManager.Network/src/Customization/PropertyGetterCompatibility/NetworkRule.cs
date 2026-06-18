// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the NetworkRule type. </summary>
    public partial class NetworkRule
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> DestinationIPGroups { get; } = new global::System.Collections.Generic.List<global::System.String>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.FirewallPolicyRuleNetworkProtocol> IPProtocols { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.FirewallPolicyRuleNetworkProtocol>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> SourceIPGroups { get; } = new global::System.Collections.Generic.List<global::System.String>();
    }
}
