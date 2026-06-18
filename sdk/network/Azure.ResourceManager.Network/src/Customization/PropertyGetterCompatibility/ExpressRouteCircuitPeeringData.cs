// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteCircuitPeeringData type. </summary>
    public partial class ExpressRouteCircuitPeeringData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.String GatewayManagerETag
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Network.Models.IPv6ExpressRouteCircuitPeeringConfig IPv6PeeringConfig
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }

        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource RouteFilter
        {
            get => RouteFilterId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = RouteFilterId };
            set => RouteFilterId = value?.Id;
        }
    }
}
