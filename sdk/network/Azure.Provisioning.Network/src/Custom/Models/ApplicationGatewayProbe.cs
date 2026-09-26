// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Network;

public partial class ApplicationGatewayProbe
{
    // Preserve the pre-TypeSpec property name because it maps to the same Bicep property as the generated member.
    /// <inheritdoc cref="Interval"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use Interval instead.")]
    public BicepValue<int> IntervalInSeconds
    {
        get => Interval;
        set => Interval = value;
    }

    // Preserve the pre-TypeSpec property name because it maps to the same Bicep property as the generated member.
    /// <inheritdoc cref="EnableProbeProxyProtocolHeader"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use EnableProbeProxyProtocolHeader instead.")]
    public BicepValue<bool> IsProbeProxyProtocolHeaderEnabled
    {
        get => EnableProbeProxyProtocolHeader;
        set => EnableProbeProxyProtocolHeader = value;
    }

    // Preserve the pre-TypeSpec property name because it maps to the same Bicep property as the generated member.
    /// <inheritdoc cref="Timeout"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use Timeout instead.")]
    public BicepValue<int> TimeoutInSeconds
    {
        get => Timeout;
        set => Timeout = value;
    }
}
