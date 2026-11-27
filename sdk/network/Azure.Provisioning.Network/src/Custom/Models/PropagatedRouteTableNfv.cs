// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

/// <summary> Legacy NFV route table propagation settings. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is deprecated and it will be removed in a future version. Please use PropagatedRouteTable instead.")]
public partial class PropagatedRouteTableNfv : ProvisionableConstruct
{
    /// <summary> Creates a new PropagatedRouteTableNfv. </summary>
    public PropagatedRouteTableNfv()
    {
    }

    /// <inheritdoc/>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
    }
}
