// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteCircuitData type. </summary>
    public partial class ExpressRouteCircuitData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.String GatewayManagerETag { get; set; }
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Int32> STag { get; }
    }
}
