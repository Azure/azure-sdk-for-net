// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

public partial class WebSiteConfig
{
    // Preserve the legacy flattened API while retaining the current nested API definition model.

    /// <summary> The URL of the API definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<Uri> ApiDefinitionUri
    {
        get
        {
            return Properties is null ? default : Properties.ApiDefinitionUri;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new SiteConfigProperties();
            }
            Properties.ApiDefinitionUri = value;
        }
    }
}
