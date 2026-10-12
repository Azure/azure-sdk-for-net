// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Network;

public partial class P2SConnectionConfiguration
{
    private BicepValue<ResourceType> _resourceType;

    // Preserve the output-only resource type and Bicep path shipped in 1.1.0.
    /// <summary> Resource type. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<ResourceType> ResourceType
    {
        get
        {
            Initialize();
            return _resourceType;
        }
    }

    // Preserve the previous TypeSpec name while recommending the restored generated name used by management.
    /// <inheritdoc cref="ConfigurationPolicyGroups"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use ConfigurationPolicyGroups instead.")]
    public BicepList<WritableSubResource> ConfigurationPolicyGroupAssociations
    {
        get => ConfigurationPolicyGroups;
        set => ConfigurationPolicyGroups = value;
    }

    partial void DefineAdditionalProperties()
    {
        _resourceType = DefineProperty<ResourceType>(nameof(ResourceType), new string[] { "type" }, isOutput: true);
    }
}
