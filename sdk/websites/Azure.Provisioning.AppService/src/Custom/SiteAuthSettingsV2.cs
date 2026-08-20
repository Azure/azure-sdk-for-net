// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Provisioning.AppService;

/// <summary>
/// Configuration settings for the Azure App Service Authentication / Authorization V2 feature.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This class is deprecated and it will be removed in a future version. Please use WebSiteAuthSettingsV2 instead.")]
public partial class SiteAuthSettingsV2 : WebSiteAuthSettingsV2
{
    /// <summary> Creates a new SiteAuthSettingsV2. </summary>
    /// <param name="bicepIdentifier"> The bicep identifier name. </param>
    /// <param name="resourceVersion"> The resource API version. </param>
    public SiteAuthSettingsV2(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, resourceVersion)
    {
    }

    /// <summary> Creates a reference to an existing SiteAuthSettingsV2. </summary>
    /// <param name="bicepIdentifier"> The bicep identifier name. </param>
    /// <param name="resourceVersion"> The resource API version. </param>
    public static new SiteAuthSettingsV2 FromExisting(string bicepIdentifier, string resourceVersion = null)
    {
        SiteAuthSettingsV2 result = new SiteAuthSettingsV2(bicepIdentifier, resourceVersion);
        result.IsExistingResource = true;
        return result;
    }
}
