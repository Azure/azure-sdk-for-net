// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the AzureFirewallData type. </summary>
    public partial class AzureFirewallData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.AzureFirewallIPConfiguration> IPConfigurations => IpConfigurations;
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.AzureFirewallIPGroups> IPGroups { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.AzureFirewallIPGroups>();
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Network.Models.AzureFirewallIPConfiguration ManagementIPConfiguration { get; set; }
    }
}
