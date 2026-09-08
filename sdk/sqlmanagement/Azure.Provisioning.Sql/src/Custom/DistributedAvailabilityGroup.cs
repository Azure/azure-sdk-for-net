// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Sql;

/// <summary>
/// Distributed availability group.
/// Please use <see cref="SqlDistributedAvailabilityGroup"/> instead.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is obsolete and will be removed in a future release. Please use SqlDistributedAvailabilityGroup instead.", false)]
public partial class DistributedAvailabilityGroup : ProvisionableResource
{
    private BicepValue<string>? _name;
    private BicepValue<string>? _primaryAvailabilityGroupName;
    private BicepValue<DistributedAvailabilityGroupReplicationMode>? _replicationMode;
    private BicepValue<string>? _secondaryAvailabilityGroupName;
    private BicepValue<string>? _sourceEndpoint;
    private BicepValue<string>? _targetDatabase;
    private BicepValue<Guid>? _distributedAvailabilityGroupId;
    private BicepValue<ResourceIdentifier>? _id;
    private BicepValue<string>? _lastHardenedLsn;
    private BicepValue<string>? _linkState;
    private BicepValue<Guid>? _sourceReplicaId;
    private SystemData? _systemData;
    private BicepValue<Guid>? _targetReplicaId;
    private ResourceReference<ManagedInstance>? _parent;

    /// <summary>
    /// The distributed availability group name.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
        set { Initialize(); _name!.Assign(value); }
    }

    /// <summary>
    /// The primary availability group name.
    /// </summary>
    public BicepValue<string> PrimaryAvailabilityGroupName
    {
        get { Initialize(); return _primaryAvailabilityGroupName!; }
        set { Initialize(); _primaryAvailabilityGroupName!.Assign(value); }
    }

    /// <summary>
    /// The replication mode of a distributed availability group. The parameter
    /// is ignored during link creation.
    /// </summary>
    public BicepValue<DistributedAvailabilityGroupReplicationMode> ReplicationMode
    {
        get { Initialize(); return _replicationMode!; }
        set { Initialize(); _replicationMode!.Assign(value); }
    }

    /// <summary>
    /// The secondary availability group name.
    /// </summary>
    public BicepValue<string> SecondaryAvailabilityGroupName
    {
        get { Initialize(); return _secondaryAvailabilityGroupName!; }
        set { Initialize(); _secondaryAvailabilityGroupName!.Assign(value); }
    }

    /// <summary>
    /// The source endpoint.
    /// </summary>
    public BicepValue<string> SourceEndpoint
    {
        get { Initialize(); return _sourceEndpoint!; }
        set { Initialize(); _sourceEndpoint!.Assign(value); }
    }

    /// <summary>
    /// The name of the target database.
    /// </summary>
    public BicepValue<string> TargetDatabase
    {
        get { Initialize(); return _targetDatabase!; }
        set { Initialize(); _targetDatabase!.Assign(value); }
    }

    /// <summary>
    /// The distributed availability group ID.
    /// </summary>
    public BicepValue<Guid> DistributedAvailabilityGroupId
    {
        get { Initialize(); return _distributedAvailabilityGroupId!; }
    }

    /// <summary>
    /// Gets the resource ID.
    /// </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }

    /// <summary>
    /// The last hardened LSN.
    /// </summary>
    public BicepValue<string> LastHardenedLsn
    {
        get { Initialize(); return _lastHardenedLsn!; }
    }

    /// <summary>
    /// The link state.
    /// </summary>
    public BicepValue<string> LinkState
    {
        get { Initialize(); return _linkState!; }
    }

    /// <summary>
    /// The source replica ID.
    /// </summary>
    public BicepValue<Guid> SourceReplicaId
    {
        get { Initialize(); return _sourceReplicaId!; }
    }

    /// <summary>
    /// Gets the system metadata.
    /// </summary>
    public SystemData SystemData
    {
        get { Initialize(); return _systemData!; }
    }

    /// <summary>
    /// The target replica ID.
    /// </summary>
    public BicepValue<Guid> TargetReplicaId
    {
        get { Initialize(); return _targetReplicaId!; }
    }

    /// <summary>
    /// Gets or sets a reference to the parent managed instance.
    /// </summary>
    public ManagedInstance? Parent
    {
        get { Initialize(); return _parent!.Value; }
        set { Initialize(); _parent!.Value = value; }
    }

    /// <summary>
    /// Creates a new <see cref="DistributedAvailabilityGroup"/>.
    /// </summary>
    /// <param name="bicepIdentifier">The Bicep identifier name.</param>
    /// <param name="resourceVersion">The resource API version.</param>
    public DistributedAvailabilityGroup(string bicepIdentifier, string? resourceVersion = default)
        : base(bicepIdentifier, "Microsoft.Sql/managedInstances/distributedAvailabilityGroups", resourceVersion ?? "2023-08-01")
    {
    }

    /// <summary>
    /// Defines the provisionable properties of <see cref="DistributedAvailabilityGroup"/>.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isRequired: true);
        _primaryAvailabilityGroupName = DefineProperty<string>(nameof(PrimaryAvailabilityGroupName), new string[] { "properties", "primaryAvailabilityGroupName" });
        _replicationMode = DefineProperty<DistributedAvailabilityGroupReplicationMode>(nameof(ReplicationMode), new string[] { "properties", "replicationMode" });
        _secondaryAvailabilityGroupName = DefineProperty<string>(nameof(SecondaryAvailabilityGroupName), new string[] { "properties", "secondaryAvailabilityGroupName" });
        _sourceEndpoint = DefineProperty<string>(nameof(SourceEndpoint), new string[] { "properties", "sourceEndpoint" });
        _targetDatabase = DefineProperty<string>(nameof(TargetDatabase), new string[] { "properties", "targetDatabase" });
        _distributedAvailabilityGroupId = DefineProperty<Guid>(nameof(DistributedAvailabilityGroupId), new string[] { "properties", "distributedAvailabilityGroupId" }, isOutput: true);
        _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" }, isOutput: true);
        _lastHardenedLsn = DefineProperty<string>(nameof(LastHardenedLsn), new string[] { "properties", "lastHardenedLsn" }, isOutput: true);
        _linkState = DefineProperty<string>(nameof(LinkState), new string[] { "properties", "linkState" }, isOutput: true);
        _sourceReplicaId = DefineProperty<Guid>(nameof(SourceReplicaId), new string[] { "properties", "sourceReplicaId" }, isOutput: true);
        _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
        _targetReplicaId = DefineProperty<Guid>(nameof(TargetReplicaId), new string[] { "properties", "targetReplicaId" }, isOutput: true);
        _parent = DefineResource<ManagedInstance>(nameof(Parent), new string[] { "parent" }, isRequired: true);
    }

    /// <summary>
    /// Creates a reference to an existing <see cref="DistributedAvailabilityGroup"/>.
    /// </summary>
    /// <param name="bicepIdentifier">The Bicep identifier name.</param>
    /// <param name="resourceVersion">The resource API version.</param>
    /// <returns>The existing resource.</returns>
    public static DistributedAvailabilityGroup FromExisting(string bicepIdentifier, string? resourceVersion = default) =>
        new(bicepIdentifier, resourceVersion) { IsExistingResource = true };

    /// <summary>
    /// Supported resource versions.
    /// </summary>
    public static partial class ResourceVersions
    {
        /// <summary> API version "2021-11-01". </summary>
        public static readonly string V2021_11_01 = "2021-11-01";

        /// <summary> API version "2023-08-01". </summary>
        public static readonly string V2023_08_01 = "2023-08-01";
    }
}
