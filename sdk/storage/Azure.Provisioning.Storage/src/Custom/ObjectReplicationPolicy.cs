// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Storage;

public partial class ObjectReplicationPolicy
{
    // TypeSpec makes the ARM resource name settable. Preserve the shipped output-only accessor.
    private BicepValue<string> _compatName;

    /// <summary> Gets the resource name. </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _compatName; }
    }

    partial void DefineAdditionalProperties()
    {
        _compatName = DefineProperty<string>(nameof(Name), ["name"], isOutput: true);
    }
}
