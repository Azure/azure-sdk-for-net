// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VirtualNetworkGatewayData type. </summary>
    public partial class VirtualNetworkGatewayData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Boolean> Active
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> CustomRoutesAddressPrefixes => default;
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Boolean> EnablePrivateIPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
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
