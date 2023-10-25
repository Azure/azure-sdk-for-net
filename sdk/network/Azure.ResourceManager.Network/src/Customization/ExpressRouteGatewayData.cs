// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing the ExpressRouteGateway data model.
    /// ExpressRoute gateway resource.
    /// </summary>
    public partial class ExpressRouteGatewayData : NetworkTrackedResourceData
    {
        /// <summary> List of ExpressRoute connections to the ExpressRoute gateway. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<ExpressRouteConnectionData> ExpressRouteConnections => (IReadOnlyList<ExpressRouteConnectionData>)ExpressRouteConnectionList;
    }
}
