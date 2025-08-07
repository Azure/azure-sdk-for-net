// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Sql;

/// <summary>
/// LongTermRetentionPolicy.
/// </summary>
public partial class LongTermRetentionPolicy
{
    /// <summary>
    /// The BackupStorageAccessTier for the LTR backups.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)] // Only in preview
    public BicepValue<SqlBackupStorageAccessTier> BackupStorageAccessTier
    {
        get => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
        set => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
    }

    /// <summary>
    /// The setting whether to make LTR backups immutable.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)] // Only in preview
    public BicepValue<bool> MakeBackupsImmutable
    {
        get => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
        set => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
    }
}
