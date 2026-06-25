// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the SubnetData type. </summary>
    public partial class SubnetData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> IPAllocations { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Resources.Models.WritableSubResource>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.NetworkIPConfigurationProfile> IPConfigurationProfiles { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.NetworkIPConfigurationProfile>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.Models.NetworkIPConfiguration> IPConfigurations => Properties is null ? default : Properties.IpConfigurations;
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.VirtualNetworkPrivateEndpointNetworkPolicy> PrivateEndpointNetworkPolicy { get; set; }
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.VirtualNetworkPrivateLinkServiceNetworkPolicy> PrivateLinkServiceNetworkPolicy { get; set; }
    }
}
