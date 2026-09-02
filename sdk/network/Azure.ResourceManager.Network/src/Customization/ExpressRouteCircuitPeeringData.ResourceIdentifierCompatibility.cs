// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteCircuitPeeringData type. </summary>
    public partial class ExpressRouteCircuitPeeringData
    {
        /// <summary> The ExpressRoute connection. </summary>
        [WirePath("properties.expressRouteConnection")]
        public ResourceIdentifier ExpressRouteConnectionId => ExpressRouteConnection;
    }
}
