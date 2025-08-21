// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

/// <summary>
/// Parameters used for restore operations.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public partial class MongoClusterRestoreParameters : ProvisionableConstruct
{
    /// <summary>
    /// UTC point in time to restore a mongo cluster.
    /// </summary>
    public BicepValue<DateTimeOffset> PointInTimeUTC
    {
        get { Initialize(); return _pointInTimeUTC!; }
        set { Initialize(); _pointInTimeUTC!.Assign(value); }
    }
    private BicepValue<DateTimeOffset>? _pointInTimeUTC;

    /// <summary>
    /// Resource ID to locate the source cluster to restore.
    /// </summary>
    public BicepValue<string> SourceResourceId
    {
        get { Initialize(); return _sourceResourceId!; }
        set { Initialize(); _sourceResourceId!.Assign(value); }
    }
    private BicepValue<string>? _sourceResourceId;

    /// <summary>
    /// Creates a new MongoClusterRestoreParameters.
    /// </summary>
    public MongoClusterRestoreParameters()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// MongoClusterRestoreParameters.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _pointInTimeUTC = DefineProperty<DateTimeOffset>("PointInTimeUTC", ["pointInTimeUTC"]);
        _sourceResourceId = DefineProperty<string>("SourceResourceId", ["sourceResourceId"]);
    }
}
