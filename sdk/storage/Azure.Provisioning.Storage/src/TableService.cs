// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Storage;

// TypeSpec suppresses the singleton Name when this shipped get-only property is present.
// Define it manually with the required "default" value to preserve the existing API and Bicep.
public partial class TableService
{
    private BicepValue<string>? _name;

    /// <summary>
    /// Gets the Name.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
    }

    partial void DefineAdditionalProperties()
    {
        _name = DefineProperty<string>(nameof(Name), ["name"], isRequired: true, defaultValue: "default");
    }
}
