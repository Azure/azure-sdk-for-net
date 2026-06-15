// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class ExpressRouteCrossConnectionData
    {
        /// <summary> The ExpressRouteCircuit. </summary>
        [WirePath("properties.expressRouteCircuit")]
        public ResourceIdentifier ExpressRouteCircuitId
        {
            get => ExpressRouteCircuit;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
