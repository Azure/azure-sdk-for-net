// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.PostgreSql;

public partial class DbMigrationStatus : ProvisionableConstruct
{
    /// <summary>
    /// Number of tables queued for the migration of a DB.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<int> NumFullLoadQueuedTables => FullLoadQueuedTables;

    /// <summary>
    /// Number of tables errored out during the migration of a DB.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<int> NumFullLoadErroredTables => FullLoadErroredTables;

    /// <summary>
    /// Number of tables loading during the migration of a DB.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<int> NumFullLoadLoadingTables => FullLoadLoadingTables;

    /// <summary>
    /// Number of tables loaded during the migration of a DB.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<int> NumFullLoadCompletedTables => FullLoadCompletedTables;
}
