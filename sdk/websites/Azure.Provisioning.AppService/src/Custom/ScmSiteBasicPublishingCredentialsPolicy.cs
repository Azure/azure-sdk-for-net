// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.AppService;

/// <summary> The SCM basic publishing credentials policy for a web site. </summary>
public partial class ScmSiteBasicPublishingCredentialsPolicy : SiteBasicPublishingCredentialsPolicy
{
    /// <summary> Creates a new ScmSiteBasicPublishingCredentialsPolicy. </summary>
    public ScmSiteBasicPublishingCredentialsPolicy(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, resourceVersion)
    {
        Name = "scm";
    }

    /// <summary> Creates a reference to an existing ScmSiteBasicPublishingCredentialsPolicy. </summary>
    public static new ScmSiteBasicPublishingCredentialsPolicy FromExisting(string bicepIdentifier, string resourceVersion = null)
    {
        ScmSiteBasicPublishingCredentialsPolicy result = new(bicepIdentifier, resourceVersion);
        result.IsExistingResource = true;
        return result;
    }
}
