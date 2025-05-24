// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Core;
using Azure.Provisioning.Primitives;
using System;
using System.ComponentModel;

namespace Azure.Provisioning.EventHubs;

/// <summary>
/// Namespace replication properties.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public partial class NamespaceReplicaLocation : ProvisionableConstruct
{
    /// <summary>
    /// Azure regions where a replica of the namespace is maintained.
    /// </summary>
    public BicepValue<string> LocationName
    {
        get { Initialize(); return _locationName!; }
        set { Initialize(); _locationName!.Assign(value); }
    }
    private BicepValue<string>? _locationName;

    /// <summary>
    /// GeoDR Role Types.
    /// </summary>
    public BicepValue<NamespaceGeoDRRoleType> RoleType
    {
        get { Initialize(); return _roleType!; }
        set { Initialize(); _roleType!.Assign(value); }
    }
    private BicepValue<NamespaceGeoDRRoleType>? _roleType;

    /// <summary>
    /// Optional property that denotes the ARM ID of the Cluster. This is
    /// required, if a namespace replica should be placed in a Dedicated Event
    /// Hub Cluster.
    /// </summary>
    public BicepValue<ResourceIdentifier> ClusterArmId
    {
        get { Initialize(); return _clusterArmId!; }
        set { Initialize(); _clusterArmId!.Assign(value); }
    }
    private BicepValue<ResourceIdentifier>? _clusterArmId;

    /// <summary>
    /// Creates a new NamespaceReplicaLocation.
    /// </summary>
    public NamespaceReplicaLocation()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of NamespaceReplicaLocation.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _locationName = DefineProperty<string>("LocationName", ["locationName"]);
        _roleType = DefineProperty<NamespaceGeoDRRoleType>("RoleType", ["roleType"]);
        _clusterArmId = DefineProperty<ResourceIdentifier>("ClusterArmId", ["clusterArmId"]);
    }
}
