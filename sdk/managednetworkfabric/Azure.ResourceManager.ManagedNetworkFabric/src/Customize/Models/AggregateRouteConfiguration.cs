// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class AggregateRouteConfiguration
    {
        /// <summary> List of IPv4 Routes. </summary>
        public IList<AggregateRoute> IPv4Routes => Ipv4Routes;

        /// <summary> List of IPv6 Routes. </summary>
        public IList<AggregateRoute> IPv6Routes => Ipv6Routes;
    }
}
