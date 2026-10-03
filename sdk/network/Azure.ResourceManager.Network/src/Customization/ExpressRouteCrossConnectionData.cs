// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteCrossConnectionData type. </summary>
    public partial class ExpressRouteCrossConnectionData
    {
        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="ExpressRouteCircuitId"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use ExpressRouteCircuitId instead.")]
        [WirePath("properties.expressRouteCircuit")]
        public ResourceIdentifier ExpressRouteCircuit
        {
            get => ExpressRouteCircuitId;
            set => ExpressRouteCircuitId = value;
        }
    }
}
