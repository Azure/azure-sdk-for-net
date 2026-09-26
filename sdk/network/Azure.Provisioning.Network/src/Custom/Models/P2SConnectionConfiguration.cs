// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Network;

public partial class P2SConnectionConfiguration
{
    // Preserve the pre-TypeSpec property name because it maps to the same Bicep property as the generated member.
    /// <inheritdoc cref="ConfigurationPolicyGroupAssociations"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use ConfigurationPolicyGroupAssociations instead.")]
    public BicepList<WritableSubResource> ConfigurationPolicyGroups
    {
        get => ConfigurationPolicyGroupAssociations;
        set => ConfigurationPolicyGroupAssociations = value;
    }
}
