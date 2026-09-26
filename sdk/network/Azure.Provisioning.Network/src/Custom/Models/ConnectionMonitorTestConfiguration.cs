// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Network;

public partial class ConnectionMonitorTestConfiguration
{
    // Preserve the pre-TypeSpec property name because it maps to the same Bicep property as the generated member.
    /// <inheritdoc cref="IcmpDisableTraceRoute"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use IcmpDisableTraceRoute instead.")]
    public BicepValue<bool> DisableTraceRoute
    {
        get => IcmpDisableTraceRoute;
        set => IcmpDisableTraceRoute = value;
    }
}
