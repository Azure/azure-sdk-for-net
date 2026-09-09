// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

#nullable disable
#pragma warning disable CS1591 // Compatibility aliases preserve the released beta.1 API.

namespace Azure.Provisioning.SecurityCenter;

[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("Use CspmMonitorAzureDevOpsOffering instead.")]
public partial class DefenderForDevOpsAzureDevOpsOffering : SecurityCenterCloudOffering
{
    public DefenderForDevOpsAzureDevOpsOffering()
    {
        OfferingType.Assign(SecurityCenter.OfferingType.CspmMonitorAzureDevOps);
    }
}

[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("Use CspmMonitorGithubOffering instead.")]
public partial class DefenderForDevOpsGithubOffering : SecurityCenterCloudOffering
{
    public DefenderForDevOpsGithubOffering()
    {
        OfferingType.Assign(SecurityCenter.OfferingType.CspmMonitorGithub);
    }
}

[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("Use CspmMonitorGitLabOffering instead.")]
public partial class DefenderForDevOpsGitLabOffering : SecurityCenterCloudOffering
{
    public DefenderForDevOpsGitLabOffering()
    {
        OfferingType.Assign(SecurityCenter.OfferingType.CspmMonitorGitLab);
    }
}

[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("Use SecurityApplication instead.")]
public partial class SecurityConnectorApplication : SecurityApplication
{
    public SecurityConnectorApplication(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, resourceVersion)
    {
    }

    public static new SecurityConnectorApplication FromExisting(string bicepIdentifier, string resourceVersion = null)
    {
        SecurityConnectorApplication result = new(bicepIdentifier, resourceVersion);
        result.IsExistingResource = true;
        return result;
    }
}

[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("Use SecurityApplication instead.")]
public partial class SubscriptionSecurityApplication : SecurityApplication
{
    public SubscriptionSecurityApplication(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, resourceVersion)
    {
    }

    public static new SubscriptionSecurityApplication FromExisting(string bicepIdentifier, string resourceVersion = null)
    {
        SubscriptionSecurityApplication result = new(bicepIdentifier, resourceVersion);
        result.IsExistingResource = true;
        return result;
    }
}

[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("Use GovernanceRule instead.")]
public partial class SecurityConnectorGovernanceRule : GovernanceRule
{
    public SecurityConnectorGovernanceRule(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, resourceVersion)
    {
    }

    public static new SecurityConnectorGovernanceRule FromExisting(string bicepIdentifier, string resourceVersion = null)
    {
        SecurityConnectorGovernanceRule result = new(bicepIdentifier, resourceVersion);
        result.IsExistingResource = true;
        return result;
    }
}

[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("Use GovernanceRule instead.")]
public partial class SubscriptionGovernanceRule : GovernanceRule
{
    public SubscriptionGovernanceRule(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, resourceVersion)
    {
    }

    public static new SubscriptionGovernanceRule FromExisting(string bicepIdentifier, string resourceVersion = null)
    {
        SubscriptionGovernanceRule result = new(bicepIdentifier, resourceVersion);
        result.IsExistingResource = true;
        return result;
    }
}
