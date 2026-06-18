// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the PrivateLinkServiceData type. </summary>
    public partial class PrivateLinkServiceData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceIPConfiguration> IPConfigurations { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceIPConfiguration>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.FrontendIPConfigurationData> LoadBalancerFrontendIPConfigurations { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.FrontendIPConfigurationData>();
    }
}
