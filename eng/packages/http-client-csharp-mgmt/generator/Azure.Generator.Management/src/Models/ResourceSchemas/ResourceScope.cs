// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Generator.Management.Models;

/// <summary> Represents the ARM resource scope. </summary>
public enum ResourceScope
{
    /// <summary> Tenant scope. </summary>
    Tenant,
    /// <summary> Subscription scope. </summary>
    Subscription,
    /// <summary> Resource group scope. </summary>
    ResourceGroup,
    /// <summary> Management group scope. </summary>
    ManagementGroup,
    /// <summary> Extension resource scope. </summary>
    Extension,
}
