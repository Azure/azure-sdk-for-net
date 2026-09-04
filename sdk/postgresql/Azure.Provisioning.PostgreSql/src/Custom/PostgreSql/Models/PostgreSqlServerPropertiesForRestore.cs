// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// The properties used to create a new server by restoring from a backup.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use PostgreSqlFlexibleServer with CreateMode, SourceServerResourceId, and PointInTimeUtc for restore scenarios instead.")]
public partial class PostgreSqlServerPropertiesForRestore : PostgreSqlServerPropertiesForCreate
{
    /// <summary>
    /// The source server id to restore from.
    /// </summary>
    public BicepValue<ResourceIdentifier> SourceServerId
    {
        get { Initialize(); return _sourceServerId!; }
    }
    private BicepValue<ResourceIdentifier> _sourceServerId;

    /// <summary>
    /// Restore point creation time (ISO8601 format), specifying the time to
    /// restore from.
    /// </summary>
    public BicepValue<DateTimeOffset> RestorePointInTime
    {
        get { Initialize(); return _restorePointInTime!; }
    }
    private BicepValue<DateTimeOffset> _restorePointInTime;

    /// <summary>
    /// Creates a new PostgreSqlServerPropertiesForRestore.
    /// </summary>
    public PostgreSqlServerPropertiesForRestore() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// PostgreSqlServerPropertiesForRestore.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("createMode", ["createMode"], defaultValue: "PointInTimeRestore");
        _sourceServerId = DefineProperty<ResourceIdentifier>("SourceServerId", ["sourceServerId"], isOutput: true);
        _restorePointInTime = DefineProperty<DateTimeOffset>("RestorePointInTime", ["restorePointInTime"], isOutput: true);
    }
}
