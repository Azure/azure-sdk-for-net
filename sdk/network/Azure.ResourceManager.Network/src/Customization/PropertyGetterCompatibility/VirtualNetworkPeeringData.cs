// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VirtualNetworkPeeringData type. </summary>
    public partial class VirtualNetworkPeeringData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Boolean> AreCompleteVnetsPeered
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> LocalAddressPrefixes => default;
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> LocalVirtualNetworkAddressPrefixes => default;
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> RemoteAddressPrefixes => default;
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource RemoteVirtualNetwork
        {
            get => RemoteVirtualNetworkId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = RemoteVirtualNetworkId };
            set => RemoteVirtualNetworkId = value?.Id;
        }
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> RemoteVirtualNetworkAddressPrefixes => default;
    }
}
