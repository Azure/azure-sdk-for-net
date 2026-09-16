// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.AppService;

/// <summary> The SCM basic publishing credentials policy for a web site slot. </summary>
public partial class ScmSiteSlotBasicPublishingCredentialsPolicy : SiteSlotBasicPublishingCredentialsPolicy
{
    /// <summary> Creates a new ScmSiteSlotBasicPublishingCredentialsPolicy. </summary>
    public ScmSiteSlotBasicPublishingCredentialsPolicy(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, resourceVersion)
    {
        Name = "scm";
    }

    /// <summary> Creates a reference to an existing ScmSiteSlotBasicPublishingCredentialsPolicy. </summary>
    public static new ScmSiteSlotBasicPublishingCredentialsPolicy FromExisting(string bicepIdentifier, string resourceVersion = null)
    {
        ScmSiteSlotBasicPublishingCredentialsPolicy result = new(bicepIdentifier, resourceVersion);
        result.IsExistingResource = true;
        return result;
    }
}
