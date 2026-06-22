// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteCircuitConnectionData type. </summary>
    public partial class ExpressRouteCircuitConnectionData
    {
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Network.Models.IPv6CircuitConnectionConfig IPv6CircuitConnectionConfig { get; set; }
    }
}
