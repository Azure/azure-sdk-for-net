// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class ExpressRouteCircuitPeeringData
    {
        /// <summary> The ExpressRoute connection. </summary>
        [WirePath("properties.expressRouteConnection")]
        public ResourceIdentifier ExpressRouteConnectionId => ExpressRouteConnection;
    }
}
