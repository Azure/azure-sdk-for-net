// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// The type of administrator.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use PostgreSqlFlexibleServerMicrosoftEntraAdministrator.PrincipalType with PostgreSqlFlexibleServerPrincipalType instead.")]
public enum PostgreSqlAdministratorType
{
    /// <summary>
    /// ActiveDirectory.
    /// </summary>
    ActiveDirectory,
}
