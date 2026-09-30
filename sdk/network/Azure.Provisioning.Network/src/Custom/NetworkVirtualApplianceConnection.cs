// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Network;

public partial class NetworkVirtualApplianceConnection
{
    // Preserve the pre-TypeSpec property name because it maps to the same Bicep property as the generated member.
    /// <inheritdoc cref="RoutingConfiguration"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use RoutingConfiguration instead.")]
    public RoutingConfiguration ConnectionRoutingConfiguration
    {
        get => RoutingConfiguration;
        set => RoutingConfiguration = value;
    }
}
