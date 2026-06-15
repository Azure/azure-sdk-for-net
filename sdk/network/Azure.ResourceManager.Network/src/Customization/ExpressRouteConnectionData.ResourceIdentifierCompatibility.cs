// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class ExpressRouteConnectionData
    {
        /// <summary> The ExpressRoute circuit peering. </summary>
        [WirePath("properties.expressRouteCircuitPeering")]
        public ResourceIdentifier ExpressRouteCircuitPeeringId
        {
            get => ExpressRouteCircuitPeering;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
