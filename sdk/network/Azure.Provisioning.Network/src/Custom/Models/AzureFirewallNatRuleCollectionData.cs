// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.Provisioning.Network;

public partial class AzureFirewallNatRuleCollectionData
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

    partial void DefineAdditionalProperties()
    {
        _resourceType = DefineProperty<ResourceType>(nameof(ResourceType), new string[] { "type" }, isOutput: true);
    }
}
