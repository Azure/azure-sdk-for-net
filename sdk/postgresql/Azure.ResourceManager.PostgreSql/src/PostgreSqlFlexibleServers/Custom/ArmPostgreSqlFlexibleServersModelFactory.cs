// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
                default,
                createMode,
                default,
                serializedAdditionalRawData: null);
        }

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
                serializedAdditionalRawData: default,
                name: default,
                supportedServerEditions: supportedFlexibleServerEditions.ToList(),
                supportedServerVersions: default,
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
                serializedAdditionalRawData: default,
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
                serializedAdditionalRawData: default,
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
            return new PostgreSqlFlexibleServerServerVersionCapability(statusEnum, default, null, name,
                supportedVersionsToUpgrade.ToList()) { SupportedVCoresInternal = supportedVCores.ToList() };
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
            return new PostgreSqlFlexibleServerNetwork(publicNetworkAccess, delegatedSubnetResourceId, privateDnsZoneArmResourceId, serializedAdditionalRawData: null);
        }
    }
}
