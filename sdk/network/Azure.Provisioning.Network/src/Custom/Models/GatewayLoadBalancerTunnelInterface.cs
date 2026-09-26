// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Network;

public partial class GatewayLoadBalancerTunnelInterface
{
    // Preserve the pre-TypeSpec property name because it maps to the same Bicep property as the generated member.
    /// <inheritdoc cref="Type"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use Type instead.")]
    public BicepValue<GatewayLoadBalancerTunnelInterfaceType> InterfaceType
    {
        get => Type;
        set => Type = value;
    }
}
