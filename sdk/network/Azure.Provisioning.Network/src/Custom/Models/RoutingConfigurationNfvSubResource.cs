// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

/// <summary> Legacy NFV routing subresource reference. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is deprecated and it will be removed in a future version. Please use NetworkSubResource instead.")]
public partial class RoutingConfigurationNfvSubResource : ProvisionableConstruct
{
    /// <summary> Creates a new RoutingConfigurationNfvSubResource. </summary>
    public RoutingConfigurationNfvSubResource()
    {
    }

    /// <inheritdoc/>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
    }
}
