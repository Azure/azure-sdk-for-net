// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VirtualNetworkPeeringData type. </summary>
    public partial class VirtualNetworkPeeringData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Boolean> AreCompleteVnetsPeered { get; set; }
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> LocalAddressPrefixes { get; } = new global::System.Collections.Generic.List<global::System.String>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> LocalVirtualNetworkAddressPrefixes { get; } = new global::System.Collections.Generic.List<global::System.String>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> RemoteAddressPrefixes { get; } = new global::System.Collections.Generic.List<global::System.String>();
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource RemoteVirtualNetwork
        {
            get => RemoteVirtualNetworkId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = RemoteVirtualNetworkId };
            set => RemoteVirtualNetworkId = value?.Id;
        }
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> RemoteVirtualNetworkAddressPrefixes { get; } = new global::System.Collections.Generic.List<global::System.String>();
    }
}
