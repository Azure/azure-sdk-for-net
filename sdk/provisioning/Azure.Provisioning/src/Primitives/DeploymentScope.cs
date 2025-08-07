// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Target scope to use when deploying resources.
/// </summary>
public enum DeploymentScope
{
    /// <summary>
    /// Scope to a resource group.
    /// </summary>
    ResourceGroup = 0,

    /// <summary>
    /// Scope to a subscription.
    /// </summary>
    Subscription,

    /// <summary>
    /// Scope to a management group.
    /// </summary>
    ManagementGroup,

    /// <summary>
    /// Scope to a tenant.
    /// </summary>
    Tenant
}
