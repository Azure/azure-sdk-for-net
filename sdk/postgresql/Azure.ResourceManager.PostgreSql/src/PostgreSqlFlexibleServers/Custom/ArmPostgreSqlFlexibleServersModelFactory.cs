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
        /// <param name="sku"> Compute tier and size of a server. </param>
        /// <param name="identity"> User assigned managed identities assigned to the server. </param>
        /// <param name="administratorLogin"> Name of the login designated as the first password based administrator assigned to your instance of PostgreSQL. Must be specified the first time that you enable password based authentication on a server. Once set to a given value, it cannot be changed for the rest of the life of a server. If you disable password based authentication on a server which had it enabled, this password based role isn't deleted. </param>
        /// <param name="administratorLoginPassword"> Password assigned to the administrator login. As long as password authentication is enabled, this password can be changed at any time. </param>
        /// <param name="version"> Major version of PostgreSQL database engine. </param>
        /// <param name="minorVersion"> Minor version of PostgreSQL database engine. </param>
        /// <param name="state"> Possible states of a server. </param>
        /// <param name="fullyQualifiedDomainName"> Fully qualified domain name of a server. </param>
        /// <param name="storage"> Storage properties of a server. </param>
        /// <param name="authConfig"> Authentication configuration properties of a server. </param>
        /// <param name="dataEncryption"> Data encryption properties of a server. </param>
        /// <param name="backup"> Backup properties of a server. </param>
        /// <param name="network"> Network properties of a server. Only required if you want your server to be integrated into a virtual network provided by customer. </param>
        /// <param name="highAvailability"> High availability properties of a server. </param>
        /// <param name="maintenanceWindow"> Maintenance window properties of a server. </param>
        /// <param name="sourceServerResourceId"> Identifier of the server to be used as the source of the new server. Required when 'createMode' is 'PointInTimeRestore', 'GeoRestore', 'Replica', or 'ReviveDropped'. This property is returned only when the target server is a read replica. </param>
        /// <param name="pointInTimeUtc"> Creation time (in ISO8601 format) of the backup which you want to restore in the new server. It's required when 'createMode' is 'PointInTimeRestore', 'GeoRestore', or 'ReviveDropped'. </param>
        /// <param name="availabilityZone"> Availability zone of a server. </param>
        /// <param name="replicationRole"> Role of the server in a replication set. </param>
        /// <param name="replicaCapacity"> Maximum number of read replicas allowed for a server. </param>
        /// <param name="replica"> Read replica properties of a server. Required only in case that you want to promote a server. </param>
        /// <param name="createMode"> Creation mode of a new server. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connections associated with the specified server. </param>
        /// <param name="cluster"> Cluster properties of a server. </param>
        /// <returns> A new <see cref="FlexibleServers.PostgreSqlFlexibleServerData"/> instance for mocking. </returns>
        public static PostgreSqlFlexibleServerData PostgreSqlFlexibleServerData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, PostgreSqlFlexibleServerSku sku = null, PostgreSqlFlexibleServerUserAssignedIdentity identity = null, string administratorLogin = null, string administratorLoginPassword = null, PostgresMajorVersion? version = null, string minorVersion = null, PostgreSqlFlexibleServerState? state = null, string fullyQualifiedDomainName = null, PostgreSqlFlexibleServerStorage storage = null, PostgreSqlFlexibleServerAuthConfig authConfig = null, PostgreSqlFlexibleServerDataEncryption dataEncryption = null, PostgreSqlFlexibleServerBackupProperties backup = null, PostgreSqlFlexibleServerNetwork network = null, PostgreSqlFlexibleServerHighAvailability highAvailability = null, PostgreSqlFlexibleServerMaintenanceWindow maintenanceWindow = null, ResourceIdentifier sourceServerResourceId = null, DateTimeOffset? pointInTimeUtc = null, string availabilityZone = null, PostgreSqlFlexibleServerReplicationRole? replicationRole = null, int? replicaCapacity = null, PostgreSqlFlexibleServersReplica replica = null, PostgreSqlFlexibleServerCreateMode? createMode = null, IEnumerable<PostgreSqlFlexibleServersPrivateEndpointConnectionData> privateEndpointConnections = null, Cluster cluster = null)
        {
            tags ??= new Dictionary<string, string>();
            privateEndpointConnections ??= new List<PostgreSqlFlexibleServersPrivateEndpointConnectionData>();
            identity ??= new PostgreSqlFlexibleServerUserAssignedIdentity();

            return new PostgreSqlFlexibleServerData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                sku,
                default,
                administratorLogin,
                administratorLoginPassword,
                version,
                minorVersion,
                state,
                fullyQualifiedDomainName,
                storage,
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
                replica,
                createMode,
                privateEndpointConnections?.ToList(),
                cluster,
                serializedAdditionalRawData: null);
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
