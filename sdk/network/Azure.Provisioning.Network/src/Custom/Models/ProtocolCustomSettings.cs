// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

/// <summary> Legacy DDoS custom policy properties. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is deprecated and is no longer used.")]
public partial class ProtocolCustomSettings : ProvisionableConstruct
{
    /// <summary> Creates a new ProtocolCustomSettings. </summary>
    public ProtocolCustomSettings()
    {
    }

    /// <inheritdoc/>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
    }
}
