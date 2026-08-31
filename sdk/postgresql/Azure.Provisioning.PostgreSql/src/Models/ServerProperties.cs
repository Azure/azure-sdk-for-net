// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.PostgreSql;

[CodeGenSuppress("DefineProvisionableProperties")]
internal partial class ServerProperties
{
    private BicepValue<int> _replicaCapacity;

    /// <summary>
    /// Maximum number of replicas that a primary server can have.
    /// </summary>
    [CodeGenMember("ReplicaCapacity")]
    public BicepValue<int> ReplicaCapacity
    {
        get { Initialize(); return _replicaCapacity; }
        set { Initialize(); _replicaCapacity.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _replicaCapacity = DefineProperty<int>(nameof(ReplicaCapacity), ["replicaCapacity"], isOutput: true);
    }

    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _administratorLogin = DefineProperty<string>(nameof(AdministratorLogin), ["administratorLogin"]);
        _administratorLoginPassword = DefineProperty<string>(nameof(AdministratorLoginPassword), ["administratorLoginPassword"]);
        _authConfig = DefineModelProperty<PostgreSqlFlexibleServerAuthConfig>(nameof(AuthConfig), ["authConfig"]);
        _availabilityZone = DefineProperty<string>(nameof(AvailabilityZone), ["availabilityZone"]);
        _backup = DefineModelProperty<PostgreSqlFlexibleServerBackupProperties>(nameof(Backup), ["backup"]);
        _cluster = DefineModelProperty<PostgreSqlFlexibleServerClusterProperties>(nameof(Cluster), ["cluster"]);
        _createMode = DefineProperty<PostgreSqlFlexibleServerCreateMode>(nameof(CreateMode), ["createMode"]);
        _dataEncryption = DefineModelProperty<PostgreSqlFlexibleServerDataEncryption>(nameof(DataEncryption), ["dataEncryption"]);
        _highAvailability = DefineModelProperty<PostgreSqlFlexibleServerHighAvailability>(nameof(HighAvailability), ["highAvailability"]);
        _maintenanceWindow = DefineModelProperty<PostgreSqlFlexibleServerMaintenanceWindow>(nameof(MaintenanceWindow), ["maintenanceWindow"]);
        _network = DefineModelProperty<PostgreSqlFlexibleServerNetwork>(nameof(Network), ["network"]);
        _pointInTimeUtc = DefineProperty<DateTimeOffset>(nameof(PointInTimeUtc), ["pointInTimeUTC"], format: "O");
        _replica = DefineModelProperty<PostgreSqlFlexibleServersReplica>(nameof(Replica), ["replica"]);
        _replicaCapacity = DefineProperty<int>(nameof(ReplicaCapacity), ["replicaCapacity"], isOutput: true);
        _replicationRole = DefineProperty<PostgreSqlFlexibleServerReplicationRole>(nameof(ReplicationRole), ["replicationRole"]);
        _sourceServerResourceId = DefineProperty<ResourceIdentifier>(nameof(SourceServerResourceId), ["sourceServerResourceId"]);
        _storage = DefineModelProperty<PostgreSqlFlexibleServerStorage>(nameof(Storage), ["storage"]);
        _version = DefineProperty<PostgreSqlFlexibleServerVersion>(nameof(Version), ["version"]);
        _fullyQualifiedDomainName = DefineProperty<string>(nameof(FullyQualifiedDomainName), ["fullyQualifiedDomainName"], isOutput: true);
        _minorVersion = DefineProperty<string>(nameof(MinorVersion), ["minorVersion"], isOutput: true);
        _privateEndpointConnections = DefineListProperty<PostgreSqlFlexibleServersPrivateEndpointConnection>(nameof(PrivateEndpointConnections), ["privateEndpointConnections"], isOutput: true);
        _state = DefineProperty<PostgreSqlFlexibleServerState>(nameof(State), ["state"], isOutput: true);
    }
}
