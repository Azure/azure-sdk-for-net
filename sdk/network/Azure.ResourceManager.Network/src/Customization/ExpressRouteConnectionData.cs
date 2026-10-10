// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteConnectionData type. </summary>
    public partial class ExpressRouteConnectionData
    {
        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="ExpressRouteCircuitPeeringId"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use ExpressRouteCircuitPeeringId instead.")]
        [WirePath("properties.expressRouteCircuitPeering")]
        public ResourceIdentifier ExpressRouteCircuitPeering
        {
            get => ExpressRouteCircuitPeeringId;
            set => ExpressRouteCircuitPeeringId = value;
        }
    }
}
