// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmPostgreSqlFlexibleServersModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="FlexibleServers.PostgreSqlFlexibleServerData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> The SKU (pricing tier) of the server. </param>
        /// <param name="identity"> Describes the identity of the application. </param>
        /// <param name="administratorLogin"> The administrator's login name of a server. Can only be specified when the server is being created (and is required for creation). </param>
        /// <param name="administratorLoginPassword"> The administrator login password (required for server creation). </param>
        /// <param name="version"> PostgreSQL Server version. </param>
        /// <param name="minorVersion"> The minor version of the server. </param>
        /// <param name="state"> A state of a server that is visible to user. </param>
        /// <param name="fullyQualifiedDomainName"> The fully qualified domain name of a server. </param>
        /// <param name="storageSizeInGB"> Storage size in GB. </param>
        /// <param name="authConfig"> AuthConfig properties of a server. </param>
        /// <param name="dataEncryption"> Data encryption properties of a server. </param>
        /// <param name="backup"> Backup properties of a server. </param>
        /// <param name="network"> Network properties of a server. This Network property is required to be passed only in case you want the server to be Private access server. </param>
        /// <param name="highAvailability"> High availability properties of a server. </param>
        /// <param name="maintenanceWindow"> Maintenance window properties of a server. </param>
        /// <param name="sourceServerResourceId"> The source server resource ID to restore from. It's required when 'createMode' is 'PointInTimeRestore' or 'GeoRestore' or 'Replica' or 'ReviveDropped'. This property is returned only for Replica server. </param>
        /// <param name="pointInTimeUtc"> Restore point creation time (ISO8601 format), specifying the time to restore from. It's required when 'createMode' is 'PointInTimeRestore' or 'GeoRestore' or 'ReviveDropped'. </param>
        /// <param name="availabilityZone"> availability zone information of the server. </param>
        /// <param name="replicationRole"> Replication role of the server. </param>
        /// <param name="replicaCapacity"> Replicas allowed for a server. </param>
        /// <param name="createMode"> The mode to create a new PostgreSQL server. </param>
        /// <returns> A new <see cref="FlexibleServers.PostgreSqlFlexibleServerData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerData PostgreSqlFlexibleServerData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, PostgreSqlFlexibleServerSku sku, PostgreSqlFlexibleServerUserAssignedIdentity identity, string administratorLogin, string administratorLoginPassword, PostgreSqlFlexibleServerVersion? version, string minorVersion, PostgreSqlFlexibleServerState? state, string fullyQualifiedDomainName, int? storageSizeInGB, PostgreSqlFlexibleServerAuthConfig authConfig, PostgreSqlFlexibleServerDataEncryption dataEncryption, PostgreSqlFlexibleServerBackupProperties backup, PostgreSqlFlexibleServerNetwork network, PostgreSqlFlexibleServerHighAvailability highAvailability, PostgreSqlFlexibleServerMaintenanceWindow maintenanceWindow, ResourceIdentifier sourceServerResourceId, DateTimeOffset? pointInTimeUtc, string availabilityZone, PostgreSqlFlexibleServerReplicationRole? replicationRole, int? replicaCapacity, PostgreSqlFlexibleServerCreateMode? createMode)
        {
            tags ??= new Dictionary<string, string>();

            return new PostgreSqlFlexibleServerData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                sku,
                identity,
                administratorLogin,
                administratorLoginPassword,
                version,
                minorVersion,
                state,
                fullyQualifiedDomainName,
                new PostgreSqlFlexibleServerStorage { StorageSizeInGB = storageSizeInGB },
                authConfig,
                dataEncryption,
                backup,
                network,
                highAvailability,
                maintenanceWindow,
                sourceServerResourceId,
                pointInTimeUtc,
                availabilityZone,
                replicationRole,
                replicaCapacity,
                createMode,
                serializedAdditionalRawData: null);
        }
    }
}
