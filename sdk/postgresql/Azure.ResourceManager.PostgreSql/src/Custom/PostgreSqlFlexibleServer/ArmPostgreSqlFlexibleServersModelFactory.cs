// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmPostgreSqlFlexibleServersModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="principalType"> The principal type used to represent the type of Active Directory Administrator. </param>
        /// <param name="principalName"> Active Directory administrator principal name. </param>
        /// <param name="objectId"> The objectId of the Active Directory administrator. </param>
        /// <param name="tenantId"> The tenantId of the Active Directory administrator. </param>
        /// <returns> A new <see cref="FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This class is deprecated. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorData' class instead.")]
        public static PostgreSqlFlexibleServerActiveDirectoryAdministratorData PostgreSqlFlexibleServerActiveDirectoryAdministratorData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, PostgreSqlFlexibleServerPrincipalType? principalType = null, string principalName = null, Guid? objectId = null, Guid? tenantId = null)
        {
            return new PostgreSqlFlexibleServerActiveDirectoryAdministratorData(
                id,
                name,
                resourceType,
                systemData,
                principalType,
                principalName,
                objectId,
                tenantId,
                serializedAdditionalRawData: null);
        }

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
        public static PostgreSqlFlexibleServerData PostgreSqlFlexibleServerData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, PostgreSqlFlexibleServerSku sku, PostgreSqlFlexibleServerUserAssignedIdentity identity, string administratorLogin, string administratorLoginPassword, PostgreSqlFlexibleServerVersion? version, string minorVersion, PostgreSqlFlexibleServerState? state, string fullyQualifiedDomainName, int? storageSizeInGB, PostgreSqlFlexibleServerAuthConfig authConfig, PostgreSqlFlexibleServerDataEncryption dataEncryption, PostgreSqlFlexibleServerBackupProperties backup, PostgreSqlFlexibleServerNetwork network, PostgreSqlFlexibleServerHighAvailability highAvailability, PostgreSqlFlexibleServerMaintenanceWindow maintenanceWindow, ResourceIdentifier sourceServerResourceId, DateTimeOffset? pointInTimeUtc, string availabilityZone, PostgreSqlFlexibleServerReplicationRole? replicationRole, int? replicaCapacity, PostgreSqlFlexibleServerCreateMode? createMode)
            => PostgreSqlFlexibleServerData(id, name, resourceType, systemData, tags, location, sku, identity, administratorLogin, administratorLoginPassword, version, minorVersion, state, fullyQualifiedDomainName, new PostgreSqlFlexibleServerStorage { StorageSizeInGB = storageSizeInGB }, authConfig, dataEncryption, backup, network, highAvailability, maintenanceWindow, sourceServerResourceId, pointInTimeUtc, availabilityZone, replicationRole, replicaCapacity, default, createMode, default);

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
        /// <param name="storage"> Storage properties of a server. </param>
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
        /// <param name="replica"> Replica properties of a server. These Replica properties are required to be passed only in case you want to Promote a server. </param>
        /// <param name="createMode"> The mode to create a new PostgreSQL server. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connections associated with the specified resource. </param>
        /// <returns> A new <see cref="FlexibleServers.PostgreSqlFlexibleServerData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerData PostgreSqlFlexibleServerData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, PostgreSqlFlexibleServerSku sku, PostgreSqlFlexibleServerUserAssignedIdentity identity, string administratorLogin, string administratorLoginPassword, PostgreSqlFlexibleServerVersion? version, string minorVersion, PostgreSqlFlexibleServerState? state, string fullyQualifiedDomainName, PostgreSqlFlexibleServerStorage storage, PostgreSqlFlexibleServerAuthConfig authConfig, PostgreSqlFlexibleServerDataEncryption dataEncryption, PostgreSqlFlexibleServerBackupProperties backup, PostgreSqlFlexibleServerNetwork network, PostgreSqlFlexibleServerHighAvailability highAvailability, PostgreSqlFlexibleServerMaintenanceWindow maintenanceWindow, ResourceIdentifier sourceServerResourceId, DateTimeOffset? pointInTimeUtc, string availabilityZone, PostgreSqlFlexibleServerReplicationRole? replicationRole, int? replicaCapacity, PostgreSqlFlexibleServersReplica replica, PostgreSqlFlexibleServerCreateMode? createMode, IEnumerable<PostgreSqlFlexibleServersPrivateEndpointConnectionData> privateEndpointConnections)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, administratorLogin: administratorLogin, administratorLoginPassword: administratorLoginPassword, version: version, minorVersion: minorVersion, state: state, fullyQualifiedDomainName: fullyQualifiedDomainName, storage: storage, authConfig: authConfig, dataEncryption: dataEncryption, backup: backup, network: network, highAvailability: highAvailability, maintenanceWindow: maintenanceWindow, sourceServerResourceId: sourceServerResourceId, pointInTimeUtc: pointInTimeUtc, availabilityZone: availabilityZone, replicationRole: replicationRole, replicaCapacity: replicaCapacity, replica: replica, createMode: createMode, privateEndpointConnections: privateEndpointConnections, sku: sku, identity: identity);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerCapabilityProperties"/>. </summary>
        /// <param name="zone"> zone name. </param>
        /// <param name="supportedHAModes"> Supported high availability mode. </param>
        /// <param name="isGeoBackupSupported"> A value indicating whether a new server in this region can have geo-backups to paired region. </param>
        /// <param name="isZoneRedundantHASupported"> A value indicating whether a new server in this region can support multi zone HA. </param>
        /// <param name="isZoneRedundantHAAndGeoBackupSupported"> A value indicating whether a new server in this region can have geo-backups to paired region. </param>
        /// <param name="supportedFlexibleServerEditions"></param>
        /// <param name="supportedHyperscaleNodeEditions"></param>
        /// <param name="fastProvisioningSupported"> A value indicating whether fast provisioning is supported in this region. </param>
        /// <param name="supportedFastProvisioningEditions"></param>
        /// <param name="status"> The status. </param>
        /// <returns> A new <see cref="Models.PostgreSqlFlexibleServerCapabilityProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerCapabilityProperties PostgreSqlFlexibleServerCapabilityProperties(
            string zone = null,
            IEnumerable<string> supportedHAModes = null,
            bool? isGeoBackupSupported = null,
            bool? isZoneRedundantHASupported = null,
            bool? isZoneRedundantHAAndGeoBackupSupported = null,
            IEnumerable<PostgreSqlFlexibleServerEditionCapability> supportedFlexibleServerEditions = null,
            IEnumerable<PostgreSqlFlexibleServerHyperscaleNodeEditionCapability> supportedHyperscaleNodeEditions = null,
            bool? fastProvisioningSupported = null,
            IEnumerable<PostgreSqlFlexibleServerFastProvisioningEditionCapability> supportedFastProvisioningEditions = null,
            string status = null)
        {
            supportedHAModes ??= new List<string>();
            supportedFlexibleServerEditions ??= new List<PostgreSqlFlexibleServerEditionCapability>();
            supportedHyperscaleNodeEditions ??= new List<PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>();
            supportedFastProvisioningEditions ??= new List<PostgreSqlFlexibleServerFastProvisioningEditionCapability>();

            Enum.TryParse<PostgreSqlFlexbileServerCapabilityStatus>(status, out var statusEnum);
            return new PostgreSqlFlexibleServerCapabilityProperties(
                capabilityStatus: statusEnum,
                reason: default,
                additionalBinaryDataProperties: default,
                name: default,
                supportedServerEditions: supportedFlexibleServerEditions.ToList(),
                supportedServerVersions: default,
                supportedFeatures: default,
                supportFastProvisioning: fastProvisioningSupported switch
                {
                    true => PostgreSqlFlexibleServerFastProvisioningSupported.Enabled,
                    false => PostgreSqlFlexibleServerFastProvisioningSupported.Disabled,
                    _ => default
                },
                supportedFastProvisioningEditions: supportedFastProvisioningEditions.ToList(),
                geoBackupSupported: isGeoBackupSupported == true ? PostgreSqlFlexibleServerGeoBackupSupported.Enabled :
                isGeoBackupSupported == false ? PostgreSqlFlexibleServerGeoBackupSupported.Disabled : default,
                zoneRedundantHaSupported: isZoneRedundantHASupported switch
                {
                    true => PostgreSqlFlexibleServerZoneRedundantHaSupported.Enabled,
                    false => PostgreSqlFlexibleServerZoneRedundantHaSupported.Disabled,
                    _ => default
                },
                zoneRedundantHaAndGeoBackupSupported: isZoneRedundantHAAndGeoBackupSupported switch
                {
                    true => PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported.Enabled,
                    false => PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported.Disabled,
                    _ => default
                },
                storageAutoGrowthSupported: default,
                onlineResizeSupported: default,
                restricted: default)
            {
                Zone = zone,
                SupportedHAModesInternal = supportedHAModes.ToList(),
                SupportedHyperscaleNodeEditionsInternal = supportedHyperscaleNodeEditions.ToList(),
            };
        }

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerSkuCapability"/>. </summary>
        /// <param name="capabilityStatus"> The status of the capability. </param>
        /// <param name="reason"> The reason for the capability not being available. </param>
        /// <param name="name"> Sku name. </param>
        /// <param name="vCores"> Supported vCores. </param>
        /// <param name="supportedIops"> Supported IOPS. </param>
        /// <param name="supportedMemoryPerVcoreMb"> Supported memory per vCore in MB. </param>
        /// <param name="supportedZones"> List of supported Availability Zones. E.g. "1", "2", "3". </param>
        /// <param name="supportedHaMode"> Supported high availability mode. </param>
        /// <returns> A new <see cref="Models.PostgreSqlFlexibleServerSkuCapability"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerSkuCapability PostgreSqlFlexibleServerSkuCapability(PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus, string reason, string name, int? vCores, int? supportedIops, long? supportedMemoryPerVcoreMb, IEnumerable<string> supportedZones, IEnumerable<PostgreSqlFlexibleServerHAMode> supportedHaMode)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerSkuCapability(capabilityStatus, reason, name, vCores, supportedIops, supportedMemoryPerVcoreMb, supportedZones, supportedHaMode, default, default);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerServerVersionCapability"/>. </summary>
        /// <param name="capabilityStatus"> The status of the capability. </param>
        /// <param name="reason"> The reason for the capability not being available. </param>
        /// <param name="name"> Server version. </param>
        /// <param name="supportedVersionsToUpgrade"> Supported servers versions to upgrade. </param>
        /// <returns> A new <see cref="Models.PostgreSqlFlexibleServerServerVersionCapability"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerServerVersionCapability PostgreSqlFlexibleServerServerVersionCapability(PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus, string reason, string name, IEnumerable<string> supportedVersionsToUpgrade)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerServerVersionCapability(capabilityStatus, reason, name, supportedVersionsToUpgrade, default);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerCapabilityProperties"/>. </summary>
        /// <param name="capabilityStatus"> The status of the capability. </param>
        /// <param name="reason"> The reason for the capability not being available. </param>
        /// <param name="name"> Name of flexible servers capability. </param>
        /// <param name="supportedServerEditions"> List of supported flexible server editions. </param>
        /// <param name="supportedServerVersions"> The list of server versions supported for this capability. </param>
        /// <param name="supportFastProvisioning"> Gets a value indicating whether fast provisioning is supported. "Enabled" means fast provisioning is supported. "Disabled" stands for fast provisioning is not supported. </param>
        /// <param name="supportedFastProvisioningEditions"> List of supported server editions for fast provisioning. </param>
        /// <param name="geoBackupSupported"> Determines if geo-backup is supported in this region. "Enabled" means geo-backup is supported. "Disabled" stands for geo-back is not supported. </param>
        /// <param name="zoneRedundantHaSupported"> A value indicating whether Zone Redundant HA is supported in this region. "Enabled" means zone redundant HA is supported. "Disabled" stands for zone redundant HA is not supported. </param>
        /// <param name="zoneRedundantHaAndGeoBackupSupported"> A value indicating whether Zone Redundant HA and Geo-backup is supported in this region. "Enabled" means zone redundant HA and geo-backup is supported. "Disabled" stands for zone redundant HA and geo-backup is not supported. </param>
        /// <param name="storageAutoGrowthSupported"> A value indicating whether storage auto-grow is supported in this region. "Enabled" means storage auto-grow is supported. "Disabled" stands for storage auto-grow is not supported. </param>
        /// <param name="onlineResizeSupported"> A value indicating whether online resize is supported in this region for the given subscription. "Enabled" means storage online resize is supported. "Disabled" means storage online resize is not supported. </param>
        /// <param name="restricted"> A value indicating whether this region is restricted. "Enabled" means region is restricted. "Disabled" stands for region is not restricted. </param>
        /// <returns> A new <see cref="Models.PostgreSqlFlexibleServerCapabilityProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerCapabilityProperties PostgreSqlFlexibleServerCapabilityProperties(PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = null, string reason = null, string name = null, IEnumerable<PostgreSqlFlexibleServerEditionCapability> supportedServerEditions = null, IEnumerable<PostgreSqlFlexibleServerServerVersionCapability> supportedServerVersions = null, PostgreSqlFlexibleServerFastProvisioningSupported? supportFastProvisioning = null, IEnumerable<PostgreSqlFlexibleServerFastProvisioningEditionCapability> supportedFastProvisioningEditions = null, PostgreSqlFlexibleServerGeoBackupSupported? geoBackupSupported = null, PostgreSqlFlexibleServerZoneRedundantHaSupported? zoneRedundantHaSupported = null, PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported? zoneRedundantHaAndGeoBackupSupported = null, PostgreSqlFlexibleServerStorageAutoGrowthSupported? storageAutoGrowthSupported = null, PostgreSqlFlexibleServerOnlineResizeSupported? onlineResizeSupported = null, PostgreSqlFlexibleServerZoneRedundantRestricted? restricted = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerCapabilityProperties(capabilityStatus, reason, name, supportedServerEditions, supportedServerVersions, default, supportFastProvisioning, supportedFastProvisioningEditions, geoBackupSupported, zoneRedundantHaSupported, zoneRedundantHaAndGeoBackupSupported, storageAutoGrowthSupported, onlineResizeSupported, restricted);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerEditionCapability"/>. </summary>
        /// <param name="name"> Server edition name. </param>
        /// <param name="supportedStorageEditions"> The list of editions supported by this server edition. </param>
        /// <param name="supportedServerVersions"> The list of server versions supported by this server edition. </param>
        /// <param name="status"> The status. </param>
        /// <returns> A new <see cref="Models.PostgreSqlFlexibleServerEditionCapability"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerEditionCapability PostgreSqlFlexibleServerEditionCapability(string name = null, IEnumerable<PostgreSqlFlexibleServerStorageEditionCapability> supportedStorageEditions = null, IEnumerable<PostgreSqlFlexibleServerServerVersionCapability> supportedServerVersions = null, string status = null)
        {
            supportedStorageEditions ??= new List<PostgreSqlFlexibleServerStorageEditionCapability>();
            supportedServerVersions ??= new List<PostgreSqlFlexibleServerServerVersionCapability>();

            Enum.TryParse<PostgreSqlFlexbileServerCapabilityStatus>(status, out var statusEnum);

            return new PostgreSqlFlexibleServerEditionCapability(
                capabilityStatus: statusEnum,
                reason: default,
                additionalBinaryDataProperties: default,
                name: name,
                defaultSkuName: default,
                supportedStorageEditions: supportedStorageEditions.ToList(),
                supportedServerSkus: default)
            {
                SupportedServerVersionsInternal = supportedServerVersions.ToList()
            };
        }

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability"/>. </summary>
        /// <param name="supportedSku"> Fast provisioning supported sku name. </param>
        /// <param name="supportedStorageGb"> Fast provisioning supported storage in Gb. </param>
        /// <param name="supportedServerVersions"> Fast provisioning supported version. </param>
        /// <returns> A new <see cref="Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerFastProvisioningEditionCapability PostgreSqlFlexibleServerFastProvisioningEditionCapability(string supportedSku = null, long? supportedStorageGb = null, string supportedServerVersions = null)
        {
            return new PostgreSqlFlexibleServerFastProvisioningEditionCapability(
                capabilityStatus: default,
                reason: default,
                additionalBinaryDataProperties: default,
                supportedTier: default,
                supportedSku: supportedSku,
                supportedStorageGb: supportedStorageGb,
                supportedServerVersions: supportedServerVersions,
                serverCount: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability"/>. </summary>
        /// <param name="name"> Server edition name. </param>
        /// <param name="supportedStorageEditions"> The list of editions supported by this server edition. </param>
        /// <param name="supportedServerVersions"> The list of server versions supported by this server edition. </param>
        /// <param name="supportedNodeTypes"> The list of Node Types supported by this server edition. </param>
        /// <param name="status"> The status. </param>
        /// <returns> A new <see cref="Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerHyperscaleNodeEditionCapability PostgreSqlFlexibleServerHyperscaleNodeEditionCapability(string name = null, IEnumerable<PostgreSqlFlexibleServerStorageEditionCapability> supportedStorageEditions = null, IEnumerable<PostgreSqlFlexibleServerServerVersionCapability> supportedServerVersions = null, IEnumerable<PostgreSqlFlexibleServerNodeTypeCapability> supportedNodeTypes = null, string status = null)
        {
            supportedStorageEditions ??= new List<PostgreSqlFlexibleServerStorageEditionCapability>();
            supportedServerVersions ??= new List<PostgreSqlFlexibleServerServerVersionCapability>();
            supportedNodeTypes ??= new List<PostgreSqlFlexibleServerNodeTypeCapability>();

            return new PostgreSqlFlexibleServerHyperscaleNodeEditionCapability(
                name,
                supportedStorageEditions.ToList(),
                supportedServerVersions.ToList(),
                supportedNodeTypes.ToList(),
                status,
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerNodeTypeCapability"/>. </summary>
        /// <param name="name"> note type name. </param>
        /// <param name="nodeType"> note type. </param>
        /// <param name="status"> The status. </param>
        /// <returns> A new <see cref="Models.PostgreSqlFlexibleServerNodeTypeCapability"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerNodeTypeCapability PostgreSqlFlexibleServerNodeTypeCapability(string name = null, string nodeType = null, string status = null)
        {
            return new PostgreSqlFlexibleServerNodeTypeCapability(name, nodeType, status, default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerServerVersionCapability"/>. </summary>
        /// <param name="name"> server version. </param>
        /// <param name="supportedVersionsToUpgrade"> Supported servers versions to upgrade. </param>
        /// <param name="supportedVCores"></param>
        /// <param name="status"> The status. </param>
        /// <returns> A new <see cref="Models.PostgreSqlFlexibleServerServerVersionCapability"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerServerVersionCapability PostgreSqlFlexibleServerServerVersionCapability(string name = null, IEnumerable<string> supportedVersionsToUpgrade = null, IEnumerable<PostgreSqlFlexibleServerVCoreCapability> supportedVCores = null, string status = null)
        {
            supportedVersionsToUpgrade ??= new List<string>();
            supportedVCores ??= new List<PostgreSqlFlexibleServerVCoreCapability>();

            Enum.TryParse<PostgreSqlFlexbileServerCapabilityStatus>(status, out var statusEnum);
            return new PostgreSqlFlexibleServerServerVersionCapability();
        }

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerStorageCapability"/>. </summary>
        /// <param name="name"> storage MB name. </param>
        /// <param name="supportedIops"> supported IOPS. </param>
        /// <param name="storageSizeInMB"> storage size in MB. </param>
        /// <param name="supportedUpgradableTierList"></param>
        /// <param name="status"> The status. </param>
        /// <returns> A new <see cref="Models.PostgreSqlFlexibleServerStorageCapability"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerStorageCapability PostgreSqlFlexibleServerStorageCapability(string name = null, long? supportedIops = null, long? storageSizeInMB = null, IEnumerable<PostgreSqlFlexibleServerStorageTierCapability> supportedUpgradableTierList = null, string status = null)
        {
            supportedUpgradableTierList ??= new List<PostgreSqlFlexibleServerStorageTierCapability>();
            Enum.TryParse<PostgreSqlFlexbileServerCapabilityStatus>(status, out var statusEnum);

            return new PostgreSqlFlexibleServerStorageCapability(
                statusEnum,
                default,
                default,
                supportedIops,
                default,
                storageSizeInMB,
                default,
                default,
                default,
                default,
                supportedUpgradableTierList.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerStorageEditionCapability"/>. </summary>
        /// <param name="name"> storage edition name. </param>
        /// <param name="supportedStorageCapabilities"></param>
        /// <param name="status"> The status. </param>
        /// <returns> A new <see cref="Models.PostgreSqlFlexibleServerStorageEditionCapability"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerStorageEditionCapability PostgreSqlFlexibleServerStorageEditionCapability(string name = null, IEnumerable<PostgreSqlFlexibleServerStorageCapability> supportedStorageCapabilities = null, string status = null)
        {
            supportedStorageCapabilities ??= new List<PostgreSqlFlexibleServerStorageCapability>();
            Enum.TryParse<PostgreSqlFlexbileServerCapabilityStatus>(status, out var statusEnum);

            return new PostgreSqlFlexibleServerStorageEditionCapability(statusEnum, default, default, name, default, supportedStorageCapabilities?.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerStorageTierCapability"/>. </summary>
        /// <param name="name"> Name to represent Storage tier capability. </param>
        /// <param name="tierName"> Storage tier name. </param>
        /// <param name="iops"> Supported IOPS for this storage tier. </param>
        /// <param name="isBaseline"> Indicates if this is a baseline storage tier or not. </param>
        /// <param name="status"> Status os this storage tier. </param>
        /// <returns> A new <see cref="Models.PostgreSqlFlexibleServerStorageTierCapability"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerStorageTierCapability PostgreSqlFlexibleServerStorageTierCapability(string name = null, string tierName = null, long? iops = null, bool? isBaseline = null, string status = null)
        {
            Enum.TryParse<PostgreSqlFlexbileServerCapabilityStatus>(status, out var statusEnum);

            return new PostgreSqlFlexibleServerStorageTierCapability(
                statusEnum,
                default,
                default,
                name,
                iops);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerVCoreCapability"/>. </summary>
        /// <param name="name"> vCore name. </param>
        /// <param name="vCores"> supported vCores. </param>
        /// <param name="supportedIops"> supported IOPS. </param>
        /// <param name="supportedMemoryPerVCoreInMB"> supported memory per vCore in MB. </param>
        /// <param name="status"> The status. </param>
        /// <returns> A new <see cref="Models.PostgreSqlFlexibleServerVCoreCapability"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerVCoreCapability PostgreSqlFlexibleServerVCoreCapability(string name = null, long? vCores = null, long? supportedIops = null, long? supportedMemoryPerVCoreInMB = null, string status = null)
        {
            return new PostgreSqlFlexibleServerVCoreCapability(
                name,
                vCores,
                supportedIops,
                supportedMemoryPerVCoreInMB,
                status,
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerNetwork"/>. </summary>
        /// <param name="publicNetworkAccess"> public network access is enabled or not. </param>
        /// <param name="delegatedSubnetResourceId"> Delegated subnet arm resource id. This is required to be passed during create, in case we want the server to be VNET injected, i.e. Private access server. During update, pass this only if we want to update the value for Private DNS zone. </param>
        /// <param name="privateDnsZoneArmResourceId"> Private dns zone arm resource id. This is required to be passed during create, in case we want the server to be VNET injected, i.e. Private access server. During update, pass this only if we want to update the value for Private DNS zone. </param>
        /// <returns> A new <see cref="Models.PostgreSqlFlexibleServerNetwork"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerNetwork PostgreSqlFlexibleServerNetwork(PostgreSqlFlexibleServerPublicNetworkAccessState? publicNetworkAccess = null, ResourceIdentifier delegatedSubnetResourceId = null, ResourceIdentifier privateDnsZoneArmResourceId = null)
        {
            return new PostgreSqlFlexibleServerNetwork(publicNetworkAccess, delegatedSubnetResourceId, privateDnsZoneArmResourceId, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerUserAssignedIdentity"/>. </summary>
        /// <param name="userAssignedIdentities"> represents user assigned identities map. </param>
        /// <param name="identityType"> the types of identities associated with this resource; currently restricted to 'None and UserAssigned'. </param>
        /// <param name="tenantId"> Tenant id of the server. </param>
        /// <returns> A new <see cref="Models.PostgreSqlFlexibleServerUserAssignedIdentity"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerUserAssignedIdentity PostgreSqlFlexibleServerUserAssignedIdentity(IDictionary<string, UserAssignedIdentity> userAssignedIdentities, PostgreSqlFlexibleServerIdentityType identityType = default, Guid? tenantId = null)
        {
            var converted = userAssignedIdentities?.ToDictionary(kvp => kvp.Key, kvp => new UserIdentity());
            return new PostgreSqlFlexibleServerUserAssignedIdentity(converted, default, identityType, tenantId, additionalBinaryDataProperties: null);
        }

        // ===== Backward-compatible factory methods =====

        /// <summary> Initializes a new instance of <see cref="Models.DbLevelValidationStatus"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DbLevelValidationStatus DbLevelValidationStatus(string databaseName = null, DateTimeOffset? startedOn = null, DateTimeOffset? endedOn = null, IEnumerable<ValidationSummaryItem> summary = null)
            => ArmPostgreSqlModelFactory.DbLevelValidationStatus(databaseName: databaseName, startedOn: startedOn, endedOn: endedOn, summary: summary);

        /// <summary> Initializes a new instance of <see cref="Models.DbMigrationStatus"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DbMigrationStatus DbMigrationStatus(string databaseName = null, MigrationDbState? migrationState = null, string migrationOperation = null, DateTimeOffset? startedOn = null, DateTimeOffset? endedOn = null, int? fullLoadQueuedTables = null, int? fullLoadErroredTables = null, int? fullLoadLoadingTables = null, int? fullLoadCompletedTables = null, int? cdcUpdateCounter = null, int? cdcDeleteCounter = null, int? cdcInsertCounter = null, int? appliedChanges = null, int? incomingChanges = null, int? latency = null, string message = null)
        {
            return new DbMigrationStatus(databaseName, migrationState, migrationOperation, startedOn, endedOn, fullLoadQueuedTables, fullLoadErroredTables, fullLoadLoadingTables, fullLoadCompletedTables, cdcUpdateCounter, cdcDeleteCounter, cdcInsertCounter, appliedChanges, incomingChanges, latency, message, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ObjectRecommendation"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ObjectRecommendation ObjectRecommendation(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string kind = null, DateTimeOffset? initialRecommendedOn = null, DateTimeOffset? lastRecommendedOn = null, int? timesRecommended = null, IEnumerable<long> improvedQueryIds = null, string recommendationReason = null, string currentState = null, PostgreSqlFlexibleServerRecommendationType? recommendationType = null, ObjectRecommendationImplementationDetails implementationDetails = null, ObjectRecommendationAnalyzedWorkload analyzedWorkload = null, IEnumerable<RecommendationImpactRecord> estimatedImpact = null, ObjectRecommendationDetails details = null)
            => ArmPostgreSqlModelFactory.ObjectRecommendation(id: id, name: name, resourceType: resourceType, systemData: systemData, kind: kind, initialRecommendedOn: initialRecommendedOn, lastRecommendedOn: lastRecommendedOn, timesRecommended: timesRecommended, improvedQueryIds: improvedQueryIds, recommendationReason: recommendationReason, currentState: currentState, recommendationType: recommendationType, implementationDetails: implementationDetails, analyzedWorkload: analyzedWorkload, estimatedImpact: estimatedImpact, details: details);

        /// <summary> Initializes a new instance of <see cref="Models.ObjectRecommendationDetails"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ObjectRecommendationDetails ObjectRecommendationDetails(string databaseName = null, string schema = null, string table = null, string indexType = null, string indexName = null, IEnumerable<string> indexColumns = null, IEnumerable<string> includedColumns = null)
            => ArmPostgreSqlModelFactory.ObjectRecommendationDetails(databaseName: databaseName, schema: schema, table: table, indexType: indexType, indexName: indexName, indexColumns: indexColumns, includedColumns: includedColumns);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlBaseCapability"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlBaseCapability PostgreSqlBaseCapability(PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = null, string reason = null)
            => ArmPostgreSqlModelFactory.PostgreSqlBaseCapability(capabilityStatus: capabilityStatus, reason: reason);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlCheckMigrationNameAvailabilityContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlCheckMigrationNameAvailabilityContent PostgreSqlCheckMigrationNameAvailabilityContent(string name = null, ResourceType resourceType = default, bool? isNameAvailable = null, PostgreSqlMigrationNameUnavailableReason? reason = null, string message = null)
            => ArmPostgreSqlModelFactory.PostgreSqlCheckMigrationNameAvailabilityContent(name: name, resourceType: resourceType, isNameAvailable: isNameAvailable, reason: reason, message: message);

        /// <summary> Initializes a new instance of <see cref="FlexibleServers.PostgreSqlFlexibleServerBackupData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerBackupData PostgreSqlFlexibleServerBackupData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, PostgreSqlFlexibleServerBackupOrigin? backupType = null, DateTimeOffset? completedOn = null, string source = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerBackupData(id: id, name: name, resourceType: resourceType, systemData: systemData, backupType: backupType, completedOn: completedOn, source: source);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerBackupProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerBackupProperties PostgreSqlFlexibleServerBackupProperties(int? backupRetentionDays = null, PostgreSqlFlexibleServerGeoRedundantBackupEnum? geoRedundantBackup = null, DateTimeOffset? earliestRestoreOn = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerBackupProperties(backupRetentionDays: backupRetentionDays, geoRedundantBackup: geoRedundantBackup, earliestRestoreOn: earliestRestoreOn);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerConfigurationCreateOrUpdateContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerConfigurationCreateOrUpdateContent PostgreSqlFlexibleServerConfigurationCreateOrUpdateContent(string value = null, string description = null, string defaultValue = null, PostgreSqlFlexibleServerConfigurationDataType? dataType = null, string allowedValues = null, string source = null, bool? isDynamicConfig = null, bool? isReadOnly = null, bool? isConfigPendingRestart = null, string unit = null, string documentationLink = null)
        {
            var properties = new ConfigurationProperties(value, description, defaultValue, dataType, allowedValues, source, isDynamicConfig, isReadOnly, isConfigPendingRestart, unit, documentationLink, null);
            return new PostgreSqlFlexibleServerConfigurationCreateOrUpdateContent(properties, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="FlexibleServers.PostgreSqlFlexibleServerConfigurationData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerConfigurationData PostgreSqlFlexibleServerConfigurationData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string value = null, string description = null, string defaultValue = null, PostgreSqlFlexibleServerConfigurationDataType? dataType = null, string allowedValues = null, string source = null, bool? isDynamicConfig = null, bool? isReadOnly = null, bool? isConfigPendingRestart = null, string unit = null, string documentationLink = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerConfigurationData(id: id, name: name, resourceType: resourceType, systemData: systemData, value: value, description: description, defaultValue: defaultValue, dataType: dataType, allowedValues: allowedValues, source: source, isDynamicConfig: isDynamicConfig, isReadOnly: isReadOnly, isConfigPendingRestart: isConfigPendingRestart, unit: unit, documentationLink: documentationLink);

        /// <summary> Initializes a new instance of <see cref="FlexibleServers.PostgreSqlFlexibleServerDatabaseData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerDatabaseData PostgreSqlFlexibleServerDatabaseData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string charset = null, string collation = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerDatabaseData(id: id, name: name, resourceType: resourceType, systemData: systemData, charset: charset, collation: collation);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerDelegatedSubnetUsage"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerDelegatedSubnetUsage PostgreSqlFlexibleServerDelegatedSubnetUsage(string subnetName = null, long? usage = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerDelegatedSubnetUsage(subnetName: subnetName, usage: usage);

        /// <summary> Initializes a new instance of <see cref="FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerFirewallRuleData PostgreSqlFlexibleServerFirewallRuleData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IPAddress startIPAddress = null, IPAddress endIPAddress = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerFirewallRuleData(id: id, name: name, resourceType: resourceType, systemData: systemData, startIPAddress: startIPAddress, endIPAddress: endIPAddress);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerHighAvailability"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerHighAvailability PostgreSqlFlexibleServerHighAvailability(PostgreSqlFlexibleServerHighAvailabilityMode? mode = null, PostgreSqlFlexibleServerHAState? state = null, string standbyAvailabilityZone = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerHighAvailability(mode: mode, state: state, standbyAvailabilityZone: standbyAvailabilityZone);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerLogFile"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerLogFile PostgreSqlFlexibleServerLogFile(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, DateTimeOffset? createdOn = null, DateTimeOffset? lastModifiedOn = null, long? sizeInKb = null, string typePropertiesType = null, Uri uri = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerLogFile(id: id, name: name, resourceType: resourceType, systemData: systemData, createdOn: createdOn, lastModifiedOn: lastModifiedOn, sizeInKb: sizeInKb, typePropertiesType: typePropertiesType, uri: uri);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerLtrBackupResult"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerLtrBackupResult PostgreSqlFlexibleServerLtrBackupResult(long? datasourceSizeInBytes = null, long? dataTransferredInBytes = null, string backupName = null, string backupMetadata = null, PostgreSqlExecutionStatus? status = null, DateTimeOffset? startOn = null, DateTimeOffset? endOn = null, double? percentComplete = null, string errorCode = null, string errorMessage = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerLtrBackupResult(datasourceSizeInBytes: datasourceSizeInBytes, dataTransferredInBytes: dataTransferredInBytes, backupName: backupName, backupMetadata: backupMetadata, status: status, startOn: startOn, endOn: endOn, percentComplete: percentComplete, errorCode: errorCode, errorMessage: errorMessage);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerLtrPreBackupResult"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerLtrPreBackupResult PostgreSqlFlexibleServerLtrPreBackupResult(int numberOfContainers = 0)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerLtrPreBackupResult(numberOfContainers: numberOfContainers);

        /// <summary> Initializes a new instance of <see cref="FlexibleServers.PostgreSqlFlexibleServerMicrosoftEntraAdministratorData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerMicrosoftEntraAdministratorData PostgreSqlFlexibleServerMicrosoftEntraAdministratorData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, PostgreSqlFlexibleServerPrincipalType? principalType = null, string principalName = null, Guid? objectId = null, Guid? tenantId = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerMicrosoftEntraAdministratorData(id: id, name: name, resourceType: resourceType, systemData: systemData, principalType: principalType, principalName: principalName, objectId: objectId, tenantId: tenantId);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerNameAvailabilityContent"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerNameAvailabilityContent PostgreSqlFlexibleServerNameAvailabilityContent(string name = null, ResourceType? resourceType = null)
        {
            var result = new PostgreSqlFlexibleServerNameAvailabilityContent() { Name = name };
            result.ResourceType = resourceType;
            return result;
        }

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerNameAvailabilityResponse"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerNameAvailabilityResponse PostgreSqlFlexibleServerNameAvailabilityResponse(bool? isNameAvailable = null, PostgreSqlFlexibleServerNameUnavailableReason? reason = null, string message = null)
            => new PostgreSqlFlexibleServerNameAvailabilityResponse(isNameAvailable, reason.HasValue ? new CheckNameAvailabilityReason(reason.Value.ToString()) : (CheckNameAvailabilityReason?)null, message, additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerNameAvailabilityResult"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerNameAvailabilityResult PostgreSqlFlexibleServerNameAvailabilityResult(bool? isNameAvailable = null, PostgreSqlFlexibleServerNameUnavailableReason? reason = null, string message = null, string name = null, ResourceType? resourceType = null)
            => new PostgreSqlFlexibleServerNameAvailabilityResult(isNameAvailable, reason.HasValue ? new CheckNameAvailabilityReason(reason.Value.ToString()) : (CheckNameAvailabilityReason?)null, message, additionalBinaryDataProperties: null, name, resourceType);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerQuotaUsage"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerQuotaUsage PostgreSqlFlexibleServerQuotaUsage(QuotaUsageNameProperty name = null, long? limit = null, string unit = null, long? currentValue = null, string id = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerQuotaUsage(name: name, limit: limit, unit: unit, currentValue: currentValue, id: id);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerSupportedFeature"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerSupportedFeature PostgreSqlFlexibleServerSupportedFeature(string name = null, PostgreSqlFlexibleServerFeatureStatus? status = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerSupportedFeature(name: name, status: status);

        /// <summary> Initializes a new instance of <see cref="FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServersPrivateEndpointConnectionData PostgreSqlFlexibleServersPrivateEndpointConnectionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IEnumerable<string> groupIds = null, ResourceIdentifier privateEndpointId = null, PostgreSqlFlexibleServersPrivateLinkServiceConnectionState connectionState = null, PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState? provisioningState = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServersPrivateEndpointConnectionData(id: id, name: name, resourceType: resourceType, systemData: systemData, groupIds: groupIds, privateLinkServiceConnectionState: connectionState, provisioningState: provisioningState, privateEndpointId: privateEndpointId);

        /// <summary> Initializes a new instance of <see cref="FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServersPrivateLinkResourceData PostgreSqlFlexibleServersPrivateLinkResourceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string groupId = null, IEnumerable<string> requiredMembers = null, IEnumerable<string> requiredZoneNames = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServersPrivateLinkResourceData(id: id, name: name, resourceType: resourceType, systemData: systemData, groupId: groupId, requiredMembers: requiredMembers, requiredZoneNames: requiredZoneNames);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServersReplica"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServersReplica PostgreSqlFlexibleServersReplica(PostgreSqlFlexibleServerReplicationRole? role = null, int? capacity = null, PostgreSqlFlexibleServersReplicationState? replicationState = null, ReadReplicaPromoteMode? promoteMode = null, ReplicationPromoteOption? promoteOption = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServersReplica(role: role, capacity: capacity, replicationState: replicationState, promoteMode: promoteMode, promoteOption: promoteOption);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServersServerSku"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServersServerSku PostgreSqlFlexibleServersServerSku(string name = null, PostgreSqlFlexibleServerSkuTier? tier = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServersServerSku(name: name, tier: tier);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServersValidationDetails"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServersValidationDetails PostgreSqlFlexibleServersValidationDetails(PostgreSqlFlexibleServersValidationState? status = null, DateTimeOffset? validationStartTimeInUtc = null, DateTimeOffset? validationEndTimeInUtc = null, IEnumerable<ValidationSummaryItem> serverLevelValidationDetails = null, IEnumerable<DbLevelValidationStatus> dbLevelValidationDetails = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServersValidationDetails(status: status, validationStartTimeInUtc: validationStartTimeInUtc, validationEndTimeInUtc: validationEndTimeInUtc, serverLevelValidationDetails: serverLevelValidationDetails, dbLevelValidationDetails: dbLevelValidationDetails);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServersValidationMessage"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServersValidationMessage PostgreSqlFlexibleServersValidationMessage(PostgreSqlFlexibleServersValidationState? state = null, string message = null)
        {
            return new PostgreSqlFlexibleServersValidationMessage(state, message, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="FlexibleServers.PostgreSqlFlexibleServerTuningOptionData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerTuningOptionData PostgreSqlFlexibleServerTuningOptionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerTuningOptionData(id: id, name: name, resourceType: resourceType, systemData: systemData);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult(IEnumerable<PostgreSqlFlexibleServerDelegatedSubnetUsage> delegatedSubnetsUsage = null, AzureLocation? location = null, string subscriptionId = null)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult(delegatedSubnetsUsage: delegatedSubnetsUsage, location: location, subscriptionId: subscriptionId);

        /// <summary> Initializes a new instance of <see cref="FlexibleServers.PostgreSqlLtrServerBackupOperationData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlLtrServerBackupOperationData PostgreSqlLtrServerBackupOperationData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, long? datasourceSizeInBytes = null, long? dataTransferredInBytes = null, string backupName = null, string backupMetadata = null, PostgreSqlExecutionStatus? status = null, DateTimeOffset? startOn = null, DateTimeOffset? endOn = null, double? percentComplete = null, string errorCode = null, string errorMessage = null)
            => ArmPostgreSqlModelFactory.PostgreSqlLtrServerBackupOperationData(id: id, name: name, resourceType: resourceType, systemData: systemData, datasourceSizeInBytes: datasourceSizeInBytes, dataTransferredInBytes: dataTransferredInBytes, backupName: backupName, backupMetadata: backupMetadata, status: status, startOn: startOn, endOn: endOn, percentComplete: percentComplete, errorCode: errorCode, errorMessage: errorMessage);

        /// <summary> Initializes a new instance of <see cref="FlexibleServers.PostgreSqlMigrationData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlMigrationData PostgreSqlMigrationData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string migrationId = null, PostgreSqlMigrationStatus currentStatus = null, ResourceIdentifier migrationInstanceResourceId = null, PostgreSqlMigrationMode? migrationMode = null, MigrationOption? migrationOption = null, PostgreSqlFlexibleServersSourceType? sourceType = null, PostgreSqlFlexibleServersSslMode? sslMode = null, PostgreSqlServerMetadata sourceDbServerMetadata = null, PostgreSqlServerMetadata targetDbServerMetadata = null, ResourceIdentifier sourceDbServerResourceId = null, string sourceDbServerFullyQualifiedDomainName = null, ResourceIdentifier targetDbServerResourceId = null, string targetDbServerFullyQualifiedDomainName = null, PostgreSqlMigrationSecretParameters secretParameters = null, IEnumerable<string> dbsToMigrate = null, PostgreSqlMigrationLogicalReplicationOnSourceDb? setupLogicalReplicationOnSourceDbIfNeeded = null, PostgreSqlMigrationOverwriteDbsInTarget? overwriteDbsInTarget = null, DateTimeOffset? migrationWindowStartTimeInUtc = null, DateTimeOffset? migrationWindowEndTimeInUtc = null, MigrateRolesEnum? migrateRoles = null, PostgreSqlMigrationStartDataMigration? startDataMigration = null, PostgreSqlMigrationTriggerCutover? triggerCutover = null, IEnumerable<string> dbsToTriggerCutoverOn = null, PostgreSqlMigrationCancel? cancel = null, IEnumerable<string> dbsToCancelMigrationOn = null)
            => ArmPostgreSqlModelFactory.PostgreSqlMigrationData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, migrationId: migrationId, currentStatus: currentStatus, migrationInstanceResourceId: migrationInstanceResourceId, migrationMode: migrationMode, migrationOption: migrationOption, sourceType: sourceType, sslMode: sslMode, sourceDbServerMetadata: sourceDbServerMetadata, targetDbServerMetadata: targetDbServerMetadata, sourceDbServerResourceId: sourceDbServerResourceId, sourceDbServerFullyQualifiedDomainName: sourceDbServerFullyQualifiedDomainName, targetDbServerResourceId: targetDbServerResourceId, targetDbServerFullyQualifiedDomainName: targetDbServerFullyQualifiedDomainName, secretParameters: secretParameters, dbsToMigrate: dbsToMigrate, setupLogicalReplicationOnSourceDbIfNeeded: setupLogicalReplicationOnSourceDbIfNeeded, overwriteDbsInTarget: overwriteDbsInTarget, migrationWindowStartTimeInUtc: migrationWindowStartTimeInUtc, migrationWindowEndTimeInUtc: migrationWindowEndTimeInUtc, migrateRoles: migrateRoles, startDataMigration: startDataMigration, triggerCutover: triggerCutover, dbsToTriggerCutoverOn: dbsToTriggerCutoverOn, cancel: cancel, dbsToCancelMigrationOn: dbsToCancelMigrationOn);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlMigrationStatus"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlMigrationStatus PostgreSqlMigrationStatus(PostgreSqlMigrationState? state = null, string error = null, PostgreSqlMigrationSubStateDetails currentSubStateDetails = null)
            => ArmPostgreSqlModelFactory.PostgreSqlMigrationStatus(state: state, error: error, currentSubStateDetails: currentSubStateDetails);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlMigrationSubStateDetails"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlMigrationSubStateDetails PostgreSqlMigrationSubStateDetails(PostgreSqlMigrationSubState? currentSubState = null, IReadOnlyDictionary<string, DbMigrationStatus> dbDetails = null, PostgreSqlFlexibleServersValidationDetails validationDetails = null)
            => ArmPostgreSqlModelFactory.PostgreSqlMigrationSubStateDetails(currentSubState: currentSubState, dbDetails: dbDetails?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value), validationDetails: validationDetails);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlServerMetadata"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlServerMetadata PostgreSqlServerMetadata(AzureLocation? location = null, string version = null, int? storageMb = null, PostgreSqlFlexibleServersServerSku sku = null)
            => ArmPostgreSqlModelFactory.PostgreSqlServerMetadata(location: location, version: version, storageMb: storageMb, sku: sku);

        /// <summary> Initializes a new instance of <see cref="Models.QuotaUsageNameProperty"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static QuotaUsageNameProperty QuotaUsageNameProperty(string value = null, string localizedValue = null)
            => ArmPostgreSqlModelFactory.QuotaUsageNameProperty(value: value, localizedValue: localizedValue);

        /// <summary> Initializes a new instance of <see cref="Models.RecommendationImpactRecord"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RecommendationImpactRecord RecommendationImpactRecord(string dimensionName = null, string unit = null, long? queryId = null, double? absoluteValue = null)
            => ArmPostgreSqlModelFactory.RecommendationImpactRecord(dimensionName: dimensionName, unit: unit, queryId: queryId, absoluteValue: absoluteValue);

        /// <summary> Initializes a new instance of <see cref="FlexibleServers.ServerThreatProtectionSettingsModelData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServerThreatProtectionSettingsModelData ServerThreatProtectionSettingsModelData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ThreatProtectionState? state = null, DateTimeOffset? createdOn = null)
            => ArmPostgreSqlModelFactory.ServerThreatProtectionSettingsModelData(id: id, name: name, resourceType: resourceType, systemData: systemData, state: state, createdOn: createdOn);

        /// <summary> Initializes a new instance of <see cref="Models.ValidationSummaryItem"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ValidationSummaryItem ValidationSummaryItem(string validationSummaryItemType = null, PostgreSqlFlexibleServersValidationState? state = null, IEnumerable<PostgreSqlFlexibleServersValidationMessage> messages = null)
            => ArmPostgreSqlModelFactory.ValidationSummaryItem(validationSummaryItemType: validationSummaryItemType, state: state, messages: messages);

        /// <summary> Initializes a new instance of <see cref="FlexibleServers.VirtualEndpointResourceData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualEndpointResourceData VirtualEndpointResourceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, VirtualEndpointType? endpointType = null, IEnumerable<string> members = null, IEnumerable<string> virtualEndpoints = null)
            => ArmPostgreSqlModelFactory.VirtualEndpointResourceData(id: id, name: name, resourceType: resourceType, systemData: systemData, endpointType: endpointType, members: members, virtualEndpoints: virtualEndpoints);

        /// <summary> Initializes a new instance of <see cref="Models.VirtualEndpointResourcePatch"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualEndpointResourcePatch VirtualEndpointResourcePatch(VirtualEndpointType? endpointType = null, IEnumerable<string> members = null, IEnumerable<string> virtualEndpoints = null)
        {
            return new VirtualEndpointResourcePatch(
                new VirtualEndpointResourceProperties(endpointType, members?.ToList(), virtualEndpoints?.ToList(), null),
                additionalBinaryDataProperties: null);
        }

        // ===== Missing backward-compatible factory method overloads (Group 10a) =====

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerCapabilityProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerCapabilityProperties PostgreSqlFlexibleServerCapabilityProperties(PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus, string reason, string name, IEnumerable<PostgreSqlFlexibleServerEditionCapability> supportedServerEditions, IEnumerable<PostgreSqlFlexibleServerServerVersionCapability> supportedServerVersions, IEnumerable<PostgreSqlFlexibleServerSupportedFeature> supportedFeatures, PostgreSqlFlexibleServerFastProvisioningSupported? supportFastProvisioning, IEnumerable<PostgreSqlFlexibleServerFastProvisioningEditionCapability> supportedFastProvisioningEditions, PostgreSqlFlexibleServerGeoBackupSupported? geoBackupSupported, PostgreSqlFlexibleServerZoneRedundantHaSupported? zoneRedundantHaSupported, PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported? zoneRedundantHaAndGeoBackupSupported, PostgreSqlFlexibleServerStorageAutoGrowthSupported? storageAutoGrowthSupported, PostgreSqlFlexibleServerOnlineResizeSupported? onlineResizeSupported, PostgreSqlFlexibleServerZoneRedundantRestricted? restricted)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerCapabilityProperties(capabilityStatus, reason, name, supportedServerEditions, supportedServerVersions, supportedFeatures, supportFastProvisioning, supportedFastProvisioningEditions, geoBackupSupported, zoneRedundantHaSupported, zoneRedundantHaAndGeoBackupSupported, storageAutoGrowthSupported, onlineResizeSupported, restricted);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerEditionCapability"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerEditionCapability PostgreSqlFlexibleServerEditionCapability(PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus, string reason, string name, string defaultSkuName, IEnumerable<PostgreSqlFlexibleServerStorageEditionCapability> supportedStorageEditions, IEnumerable<PostgreSqlFlexibleServerSkuCapability> supportedServerSkus)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerEditionCapability(capabilityStatus, reason, name, defaultSkuName, supportedStorageEditions, supportedServerSkus);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerFastProvisioningEditionCapability PostgreSqlFlexibleServerFastProvisioningEditionCapability(PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus, string reason, string supportedTier, string supportedSku, long? supportedStorageGb, string supportedServerVersions, int? serverCount)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerFastProvisioningEditionCapability(capabilityStatus, reason, supportedTier, supportedSku, supportedStorageGb, supportedServerVersions, serverCount);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerServerVersionCapability"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerServerVersionCapability PostgreSqlFlexibleServerServerVersionCapability(PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus, string reason, string name, IEnumerable<string> supportedVersionsToUpgrade, IEnumerable<PostgreSqlFlexibleServerSupportedFeature> supportedFeatures)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerServerVersionCapability(capabilityStatus, reason, name, supportedVersionsToUpgrade, supportedFeatures);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerSkuCapability"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerSkuCapability PostgreSqlFlexibleServerSkuCapability(PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus, string reason, string name, int? vCores, int? supportedIops, long? supportedMemoryPerVcoreMb, IEnumerable<string> supportedZones, IEnumerable<PostgreSqlFlexibleServerHAMode> supportedHaMode, IEnumerable<PostgreSqlFlexibleServerSupportedFeature> supportedFeatures, string securityProfile)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerSkuCapability(capabilityStatus, reason, name, vCores, supportedIops, supportedMemoryPerVcoreMb, supportedZones, supportedHaMode, supportedFeatures, securityProfile);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerStorageCapability"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerStorageCapability PostgreSqlFlexibleServerStorageCapability(PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus, string reason, long? supportedIops, int? supportedMaximumIops, long? storageSizeInMB, long? maximumStorageSizeMb, int? supportedThroughput, int? supportedMaximumThroughput, string defaultIopsTier, IEnumerable<PostgreSqlFlexibleServerStorageTierCapability> supportedIopsTiers)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerStorageCapability(capabilityStatus, reason, supportedIops, supportedMaximumIops, storageSizeInMB, maximumStorageSizeMb, supportedThroughput, supportedMaximumThroughput, defaultIopsTier, supportedIopsTiers);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerStorageEditionCapability"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerStorageEditionCapability PostgreSqlFlexibleServerStorageEditionCapability(PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus, string reason, string name, long? defaultStorageSizeMb, IEnumerable<PostgreSqlFlexibleServerStorageCapability> supportedStorageCapabilities)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerStorageEditionCapability(capabilityStatus, reason, name, defaultStorageSizeMb, supportedStorageCapabilities);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerStorageTierCapability"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerStorageTierCapability PostgreSqlFlexibleServerStorageTierCapability(PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus, string reason, string name, long? iops)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerStorageTierCapability(capabilityStatus, reason, name, iops);

        /// <summary> Initializes a new instance of <see cref="Models.PostgreSqlFlexibleServerUserAssignedIdentity"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerUserAssignedIdentity PostgreSqlFlexibleServerUserAssignedIdentity(IDictionary<string, UserAssignedIdentity> userAssignedIdentities, Guid? principalId, PostgreSqlFlexibleServerIdentityType identityType, Guid? tenantId)
        {
            var converted = userAssignedIdentities?.ToDictionary(kvp => kvp.Key, kvp => new UserIdentity());
            return new PostgreSqlFlexibleServerUserAssignedIdentity(converted, principalId, identityType, tenantId, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="FlexibleServers.PostgreSqlFlexibleServerData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerData PostgreSqlFlexibleServerData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, PostgreSqlFlexibleServerSku sku, PostgreSqlFlexibleServerUserAssignedIdentity identity, string administratorLogin, string administratorLoginPassword, PostgreSqlFlexibleServerVersion? version, string minorVersion, PostgreSqlFlexibleServerState? state, string fullyQualifiedDomainName, PostgreSqlFlexibleServerStorage storage, PostgreSqlFlexibleServerAuthConfig authConfig, PostgreSqlFlexibleServerDataEncryption dataEncryption, PostgreSqlFlexibleServerBackupProperties backup, PostgreSqlFlexibleServerNetwork network, PostgreSqlFlexibleServerHighAvailability highAvailability, PostgreSqlFlexibleServerMaintenanceWindow maintenanceWindow, ResourceIdentifier sourceServerResourceId, DateTimeOffset? pointInTimeUtc, string availabilityZone, PostgreSqlFlexibleServerReplicationRole? replicationRole, int? replicaCapacity, PostgreSqlFlexibleServersReplica replica, PostgreSqlFlexibleServerCreateMode? createMode, IEnumerable<PostgreSqlFlexibleServersPrivateEndpointConnectionData> privateEndpointConnections, PostgreSqlFlexibleServerClusterProperties cluster)
            => ArmPostgreSqlModelFactory.PostgreSqlFlexibleServerData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, administratorLogin: administratorLogin, administratorLoginPassword: administratorLoginPassword, version: version, minorVersion: minorVersion, state: state, fullyQualifiedDomainName: fullyQualifiedDomainName, storage: storage, authConfig: authConfig, dataEncryption: dataEncryption, backup: backup, network: network, highAvailability: highAvailability, maintenanceWindow: maintenanceWindow, sourceServerResourceId: sourceServerResourceId, pointInTimeUtc: pointInTimeUtc, availabilityZone: availabilityZone, replicationRole: replicationRole, replicaCapacity: replicaCapacity, replica: replica, createMode: createMode, privateEndpointConnections: privateEndpointConnections, cluster: cluster, sku: sku, identity: identity);
    }
}
