// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class VirtualNetworkGatewayData
    {
        public global::System.Nullable<global::System.Boolean> Active
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Collections.Generic.IList<global::System.String> CustomRoutesAddressPrefixes => default;
        public global::System.Nullable<global::System.Boolean> EnablePrivateIPAddress
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.VirtualNetworkGatewayIPConfiguration> IPConfigurations => Properties is null ? default : Properties.IpConfigurations;
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource GatewayDefaultSite
        {
            get => GatewayDefaultSiteId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = GatewayDefaultSiteId };
            set => GatewayDefaultSiteId = value?.Id;
        }
    }
}
