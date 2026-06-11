// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network
{
    public partial class VirtualHubData
    {
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Resources.Models.WritableSubResource> IPConfigurations => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.VirtualHubRoute> Routes => default;
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.VirtualHubRouteTableV2Data> VirtualHubRouteTableV2S => default;
        public global::System.Collections.Generic.IList<global::System.String> VirtualRouterIPs => default;
    }
}
