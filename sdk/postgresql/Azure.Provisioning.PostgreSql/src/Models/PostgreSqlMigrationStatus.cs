// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// Migration status.
/// </summary>
public partial class PostgreSqlMigrationStatus
{
    /// <summary>
    /// Migration sub state.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)] // Moved
    public BicepValue<PostgreSqlMigrationSubState> CurrentSubState
    {
        get => CurrentSubStateDetails.CurrentSubState;
    }
}
