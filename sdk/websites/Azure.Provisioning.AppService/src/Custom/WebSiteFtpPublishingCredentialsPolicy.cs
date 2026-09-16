// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.AppService;

/// <summary> The FTP basic publishing credentials policy for a web site. </summary>
public partial class WebSiteFtpPublishingCredentialsPolicy : SiteBasicPublishingCredentialsPolicy
{
    /// <summary> Creates a new WebSiteFtpPublishingCredentialsPolicy. </summary>
    public WebSiteFtpPublishingCredentialsPolicy(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, resourceVersion)
    {
        Name = "ftp";
    }

    /// <summary> Creates a reference to an existing WebSiteFtpPublishingCredentialsPolicy. </summary>
    public static new WebSiteFtpPublishingCredentialsPolicy FromExisting(string bicepIdentifier, string resourceVersion = null)
    {
        WebSiteFtpPublishingCredentialsPolicy result = new(bicepIdentifier, resourceVersion);
        result.IsExistingResource = true;
        return result;
    }
}
