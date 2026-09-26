// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Provisioning.Network;

public partial class ExpressRouteConnection
{
    // Preserve the pre-TypeSpec property name because it maps to the same Bicep property as the generated member.
    /// <inheritdoc cref="ExpressRouteCircuitPeering"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use ExpressRouteCircuitPeering instead.")]
    public BicepValue<ResourceIdentifier> ExpressRouteCircuitPeeringId
    {
        get => ExpressRouteCircuitPeering;
        set => ExpressRouteCircuitPeering = value;
    }
}
