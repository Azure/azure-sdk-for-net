// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Network;

public partial class ApplicationGatewayBackendSettings
{
    // Preserve the pre-TypeSpec property name because it maps to the same Bicep property as the generated member.
    /// <inheritdoc cref="EnableL4ClientIPPreservation"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use EnableL4ClientIPPreservation instead.")]
    public BicepValue<bool> IsL4ClientIPPreservationEnabled
    {
        get => EnableL4ClientIPPreservation;
        set => EnableL4ClientIPPreservation = value;
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
