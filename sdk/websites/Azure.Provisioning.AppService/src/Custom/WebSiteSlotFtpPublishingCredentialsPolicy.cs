// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.AppService;

/// <summary> The FTP basic publishing credentials policy for a web site slot. </summary>
public partial class WebSiteSlotFtpPublishingCredentialsPolicy : SiteSlotBasicPublishingCredentialsPolicy
{
    /// <summary> Creates a new WebSiteSlotFtpPublishingCredentialsPolicy. </summary>
    public WebSiteSlotFtpPublishingCredentialsPolicy(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, resourceVersion)
    {
        Name = "ftp";
    }

    /// <summary> Creates a reference to an existing WebSiteSlotFtpPublishingCredentialsPolicy. </summary>
    public static new WebSiteSlotFtpPublishingCredentialsPolicy FromExisting(string bicepIdentifier, string resourceVersion = null)
    {
        WebSiteSlotFtpPublishingCredentialsPolicy result = new(bicepIdentifier, resourceVersion);
        result.IsExistingResource = true;
        return result;
    }
}
