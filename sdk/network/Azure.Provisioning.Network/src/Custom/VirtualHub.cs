// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Network;

public partial class VirtualHub
{
    // Preserve the pre-TypeSpec property name because it maps to the same Bicep property as the generated member.
    /// <inheritdoc cref="RouteTableRoutes"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use RouteTableRoutes instead.")]
    public BicepList<VirtualHubRoute> Routes
    {
        get => RouteTableRoutes;
        set => RouteTableRoutes = value;
    }
}
