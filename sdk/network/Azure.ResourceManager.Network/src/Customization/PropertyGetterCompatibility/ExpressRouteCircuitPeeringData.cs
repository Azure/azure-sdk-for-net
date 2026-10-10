// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteCircuitPeeringData type. </summary>
    public partial class ExpressRouteCircuitPeeringData
    {
        /// <summary> Compatibility member. </summary>
        public global::Azure.ResourceManager.Resources.Models.WritableSubResource RouteFilter
        {
            get => RouteFilterId is null ? default : new global::Azure.ResourceManager.Resources.Models.WritableSubResource { Id = RouteFilterId };
            set => RouteFilterId = value?.Id;
        }
    }
}
