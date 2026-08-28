// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteConnectionData type. </summary>
    public partial class ExpressRouteConnectionData
    {
        /// <summary> Gets or sets the RoutingConfiguration compatibility property. </summary>
        public Azure.ResourceManager.Network.Models.RoutingConfiguration RoutingConfiguration { get; set; }
    }
}
