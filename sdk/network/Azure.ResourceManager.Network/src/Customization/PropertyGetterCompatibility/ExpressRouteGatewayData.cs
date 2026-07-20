// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteGatewayData type. </summary>
    public partial class ExpressRouteGatewayData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.ExpressRouteConnectionData> ExpressRouteConnectionList { get; } = new global::System.Collections.Generic.List<global::Azure.ResourceManager.Network.ExpressRouteConnectionData>();
    }
}
