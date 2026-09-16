// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

public partial class SiteConfigProperties
{
    // Preserve the legacy flattened API while retaining the current nested API definition model.

    /// <summary> The URL of the API definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<Uri> ApiDefinitionUri
    {
        get
        {
            return ApiDefinition is null ? default : ApiDefinition.ApiDefinitionUri;
        }
        set
        {
            if (ApiDefinition is null)
            {
                ApiDefinition = new AppServiceApiDefinitionInfo();
            }
            ApiDefinition.ApiDefinitionUri = value;
        }
    }
}
