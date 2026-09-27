// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Network;

public partial class P2SConnectionConfiguration
{
    // Preserve the previous TypeSpec name while recommending the restored generated name used by management.
    /// <inheritdoc cref="ConfigurationPolicyGroups"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use ConfigurationPolicyGroups instead.")]
    public BicepList<WritableSubResource> ConfigurationPolicyGroupAssociations
    {
        get => ConfigurationPolicyGroups;
        set => ConfigurationPolicyGroups = value;
    }
}
