// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.AppService;

public partial class FunctionAppStorage
{
    /// <summary>
    /// Property to set the URL for the selected Azure Storage type.
    /// </summary>
    [CodeGenMember("AzureStorageUriStringValue")]
    public BicepValue<Uri> Value
    {
        get { Initialize(); return _value!; }
        set { Initialize(); _value!.Assign(value); }
    }
    private BicepValue<Uri>? _value;

    partial void DefineAdditionalProperties()
    {
        _value = DefineProperty<Uri>(nameof(Value), ["value"]);
    }
}
