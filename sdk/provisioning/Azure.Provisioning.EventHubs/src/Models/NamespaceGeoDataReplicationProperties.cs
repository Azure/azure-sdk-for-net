// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.EventHubs;

/// <summary>
/// GeoDR Replication properties.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public partial class NamespaceGeoDataReplicationProperties : ProvisionableConstruct
{
    /// <summary>
    /// The maximum acceptable lag for data replication operations from the
    /// primary replica to a quorum of secondary replicas.  When the lag
    /// exceeds the configured amount, operations on the primary replica will
    /// be failed. The allowed values are 0 and 5 minutes to 1 day.
    /// </summary>
    public BicepValue<int> MaxReplicationLagDurationInSeconds
    {
        get { Initialize(); return _maxReplicationLagDurationInSeconds!; }
        set { Initialize(); _maxReplicationLagDurationInSeconds!.Assign(value); }
    }
    private BicepValue<int>? _maxReplicationLagDurationInSeconds;

    /// <summary>
    /// A list of regions where replicas of the namespace are maintained.
    /// </summary>
    public BicepList<NamespaceReplicaLocation> Locations
    {
        get { Initialize(); return _locations!; }
        set { Initialize(); _locations!.Assign(value); }
    }
    private BicepList<NamespaceReplicaLocation>? _locations;

    /// <summary>
    /// Creates a new NamespaceGeoDataReplicationProperties.
    /// </summary>
    public NamespaceGeoDataReplicationProperties()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// NamespaceGeoDataReplicationProperties.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _maxReplicationLagDurationInSeconds = DefineProperty<int>("MaxReplicationLagDurationInSeconds", ["maxReplicationLagDurationInSeconds"]);
        _locations = DefineListProperty<NamespaceReplicaLocation>("Locations", ["locations"]);
    }
}
