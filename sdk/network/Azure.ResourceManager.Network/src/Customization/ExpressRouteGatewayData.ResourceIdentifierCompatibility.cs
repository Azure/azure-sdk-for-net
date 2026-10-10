// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteGatewayData type. </summary>
    public partial class ExpressRouteGatewayData
    {
        /// <summary> The Virtual Hub where the ExpressRoute gateway is or will be deployed. </summary>
        [WirePath("properties.virtualHub")]
        public ResourceIdentifier VirtualHubId
        {
            get => VirtualHub;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
