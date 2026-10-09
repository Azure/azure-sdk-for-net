// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Network;

public partial class ExpressRouteGateway
{
    // Preserve the pre-TypeSpec property name because it maps to the same Bicep property as the generated member.
    /// <inheritdoc cref="ExpressRouteConnections"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use ExpressRouteConnections instead.")]
    public BicepList<ExpressRouteConnection> ExpressRouteConnectionList
    {
        get => ExpressRouteConnections;
        set => ExpressRouteConnections = value;
    }
}
