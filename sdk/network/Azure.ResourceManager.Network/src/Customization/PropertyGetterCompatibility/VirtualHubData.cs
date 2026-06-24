// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VirtualHubData type. </summary>
    public partial class VirtualHubData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> IPConfigurations { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Resources.Models.WritableSubResource>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.VirtualHubRoute> Routes { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.Models.VirtualHubRoute>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.VirtualHubRouteTableV2Data> VirtualHubRouteTableV2S { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.VirtualHubRouteTableV2Data>();
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::System.String> VirtualRouterIPs { get; } = new global::System.Collections.Generic.List<global::System.String>();
    }
}
