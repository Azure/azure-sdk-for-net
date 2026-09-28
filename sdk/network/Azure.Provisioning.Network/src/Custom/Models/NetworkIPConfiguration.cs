// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.Provisioning.Network;

public partial class NetworkIPConfiguration
{
    private BicepValue<ResourceType> _resourceType;

    // TypeSpec does not mark name as read-only, and management exposes a setter.
    // Preserve the released setter despite provisioning's model-level writable-usage gate.
    /// <summary> The name of the IP configuration. </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name; }
        set { Initialize(); _name.Assign(value); }
    }
    private BicepValue<string> _name;

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
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" });
        _resourceType = DefineProperty<ResourceType>(nameof(ResourceType), new string[] { "type" }, isOutput: true);
    }
}
