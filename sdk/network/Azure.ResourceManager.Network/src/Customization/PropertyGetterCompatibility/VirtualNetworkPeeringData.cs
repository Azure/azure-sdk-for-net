// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class VirtualNetworkPeeringData
    {
        public global::System.Nullable<global::System.Boolean> AreCompleteVnetsPeered
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        public global::System.Collections.Generic.IList<global::System.String> LocalAddressPrefixes => default;
        public global::System.Collections.Generic.IList<global::System.String> LocalVirtualNetworkAddressPrefixes => default;
        public global::System.Collections.Generic.IList<global::System.String> RemoteAddressPrefixes => default;
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource RemoteVirtualNetwork
        {
            get => RemoteVirtualNetworkId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = RemoteVirtualNetworkId };
            set => RemoteVirtualNetworkId = value?.Id;
        }
        public global::System.Collections.Generic.IList<global::System.String> RemoteVirtualNetworkAddressPrefixes => default;
    }
}
