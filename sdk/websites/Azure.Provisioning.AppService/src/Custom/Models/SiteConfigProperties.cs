// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

public partial class SiteConfigProperties
{
    // Preserve legacy property names while retaining the current generated API.

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

    /// <summary> Request tracing expiration time. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future release. Please use RequestTracingExpiresOn instead.", false)]
    public BicepValue<DateTimeOffset> RequestTracingExpirationOn
    {
        get => RequestTracingExpiresOn;
        set => RequestTracingExpiresOn = value;
    }
}
