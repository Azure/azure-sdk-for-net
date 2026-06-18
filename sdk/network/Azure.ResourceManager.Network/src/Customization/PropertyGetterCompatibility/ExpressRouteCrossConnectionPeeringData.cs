// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteCrossConnectionPeeringData type. </summary>
    public partial class ExpressRouteCrossConnectionPeeringData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.String GatewayManagerETag { get; set; }
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Network.Models.IPv6ExpressRouteCircuitPeeringConfig IPv6PeeringConfig { get; set; }
    }
}
