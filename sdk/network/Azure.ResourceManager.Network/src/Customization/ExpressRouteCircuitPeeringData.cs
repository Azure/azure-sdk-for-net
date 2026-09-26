// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteCircuitPeeringData type. </summary>
    public partial class ExpressRouteCircuitPeeringData
    {
        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="ExpressRouteConnectionId"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use ExpressRouteConnectionId instead.")]
        [WirePath("properties.expressRouteConnection")]
        public ResourceIdentifier ExpressRouteConnection
        {
            get => ExpressRouteConnectionId;
            set => ExpressRouteConnectionId = value;
        }
    }
}
