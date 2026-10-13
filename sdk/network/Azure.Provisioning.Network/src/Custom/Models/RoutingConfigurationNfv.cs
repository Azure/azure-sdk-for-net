// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

/// <summary> Legacy NFV routing configuration. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is deprecated and it will be removed in a future version. Please use RoutingConfiguration instead.")]
public partial class RoutingConfigurationNfv : ProvisionableConstruct
{
    /// <summary> Creates a new RoutingConfigurationNfv. </summary>
    public RoutingConfigurationNfv()
    {
    }

    /// <inheritdoc/>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
    }
}
