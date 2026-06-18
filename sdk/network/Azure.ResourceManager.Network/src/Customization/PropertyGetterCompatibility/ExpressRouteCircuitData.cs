// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteCircuitData type. </summary>
    public partial class ExpressRouteCircuitData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.String GatewayManagerETag
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Int32> STag => default;
    }
}
