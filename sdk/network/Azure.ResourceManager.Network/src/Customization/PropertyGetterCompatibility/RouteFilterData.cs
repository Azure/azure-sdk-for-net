// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the RouteFilterData type. </summary>
    public partial class RouteFilterData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IReadOnlyList<global::Azure.ResourceManager.Network.ExpressRouteCircuitPeeringData> IPv6Peerings { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.ExpressRouteCircuitPeeringData>();
    }
}
