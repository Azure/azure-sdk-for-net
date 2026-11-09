// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Network;

public partial class VirtualNetworkGateway
{
    /// <inheritdoc cref="IsActive"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use IsActive instead.")]
    public BicepValue<bool> Active
    {
        get => IsActive;
        set => IsActive = value;
    }
}
