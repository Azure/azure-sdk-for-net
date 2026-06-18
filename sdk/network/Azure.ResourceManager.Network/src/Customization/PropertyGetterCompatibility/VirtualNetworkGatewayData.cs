// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VirtualNetworkGatewayData type. </summary>
    public partial class VirtualNetworkGatewayData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Boolean> Active { get; set; }
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> CustomRoutesAddressPrefixes { get; } = new global::System.Collections.Generic.List<global::System.String>();
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Boolean> EnablePrivateIPAddress { get; set; }
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.VirtualNetworkGatewayIPConfiguration> IPConfigurations => Properties is null ? default : Properties.IpConfigurations;
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource GatewayDefaultSite
        {
            get => GatewayDefaultSiteId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = GatewayDefaultSiteId };
            set => GatewayDefaultSiteId = value?.Id;
        }
    }
}
