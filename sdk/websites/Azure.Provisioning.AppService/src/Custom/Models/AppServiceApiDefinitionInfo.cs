// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

internal partial class AppServiceApiDefinitionInfo
{
    // Preserve the legacy URI-typed wire binding for flattened ApiDefinitionUri compatibility properties.

    /// <summary> The URL of the API definition. </summary>
    internal BicepValue<Uri> ApiDefinitionUri
    {
        get { Initialize(); return _apiDefinitionUri; }
        set { Initialize(); _apiDefinitionUri.Assign(value); }
    }
    private BicepValue<Uri> _apiDefinitionUri;

    partial void DefineAdditionalProperties()
    {
        _apiDefinitionUri = DefineProperty<Uri>(nameof(ApiDefinitionUri), ["url"]);
    }
}
