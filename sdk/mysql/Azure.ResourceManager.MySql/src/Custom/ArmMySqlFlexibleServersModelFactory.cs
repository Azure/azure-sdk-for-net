// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MySql.FlexibleServers.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMySqlFlexibleServersModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="FlexibleServers.MySqlFlexibleServerData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="identity"> The cmk identity for the server. Current supported identity types: UserAssigned. </param>
        /// <param name="sku"> The SKU (pricing tier) of the server. </param>
        /// <param name="administratorLogin"> The administrator's login name of a server. Can only be specified when the server is being created (and is required for creation). </param>
        /// <param name="administratorLoginPassword"> The password of the administrator login (required for server creation). </param>
        /// <param name="version"> Server version. </param>
        /// <param name="availabilityZone"> availability Zone information of the server. </param>
        /// <param name="createMode"> The mode to create a new MySQL server. </param>
        /// <param name="sourceServerResourceId"> The source MySQL server id. </param>
        /// <param name="restorePointInTime"> Restore point creation time (ISO8601 format), specifying the time to restore from. </param>
        /// <param name="replicationRole"> The replication role. </param>
        /// <param name="replicaCapacity"> The maximum number of replicas that a primary server can have. </param>
        /// <param name="dataEncryption"> The Data Encryption for CMK. </param>
        /// <param name="state"> The state of a server. </param>
        /// <param name="fullyQualifiedDomainName"> The fully qualified domain name of a server. </param>
        /// <param name="storage"> Storage related properties of a server. </param>
        /// <param name="backup"> Backup related properties of a server. </param>
        /// <param name="highAvailability"> High availability related properties of a server. </param>
        /// <param name="network"> Network related properties of a server. </param>
        /// <param name="privateEndpointConnections"> PrivateEndpointConnections related properties of a server. </param>
        /// <param name="maintenanceWindow"> Maintenance window of a server. </param>
        /// <param name="importSourceProperties"> Source properties for import from storage. </param>
        /// <returns> A new <see cref="FlexibleServers.MySqlFlexibleServerData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MySqlFlexibleServerData MySqlFlexibleServerData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity, MySqlFlexibleServerSku sku, string administratorLogin, string administratorLoginPassword, MySqlFlexibleServerVersion? version, string availabilityZone, MySqlFlexibleServerCreateMode? createMode, ResourceIdentifier sourceServerResourceId, DateTimeOffset? restorePointInTime, MySqlFlexibleServerReplicationRole? replicationRole, int? replicaCapacity, MySqlFlexibleServerDataEncryption dataEncryption, MySqlFlexibleServerState? state, string fullyQualifiedDomainName, MySqlFlexibleServerStorage storage, MySqlFlexibleServerBackupProperties backup, MySqlFlexibleServerHighAvailability highAvailability, MySqlFlexibleServerNetwork network, IEnumerable<MySqlFlexibleServersPrivateEndpointConnection> privateEndpointConnections, MySqlFlexibleServerMaintenanceWindow maintenanceWindow, ImportSourceProperties importSourceProperties)
        {
            tags ??= new Dictionary<string, string>();

            var list = new List<MySqlFlexibleServersPrivateEndpointConnectionData>();
            if (privateEndpointConnections != null)
            {
                foreach (var item in privateEndpointConnections)
                {
                    var model = new MySqlFlexibleServersPrivateEndpointConnectionData();
                    if (item.GroupIds != null && model.GroupIds is IList<string> modelGroupIds)
                    {
                        foreach (var gid in item.GroupIds)
                            modelGroupIds.Add(gid);
                    }
                    model.PrivateEndpoint = item.PrivateEndpoint;
                    model.PrivateLinkServiceConnectionState = item.ConnectionState;
                    list.Add(model);
                }
            }

            return new MySqlFlexibleServerData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                administratorLogin,
                administratorLoginPassword,
                version,
                null,
                availabilityZone,
                createMode,
                sourceServerResourceId,
                restorePointInTime,
                replicationRole,
                replicaCapacity,
                dataEncryption,
                state,
                fullyQualifiedDomainName,
                null,
                storage,
                backup,
                highAvailability,
                network,
                list.ToList(),
                null,
                maintenanceWindow,
                importSourceProperties,
                identity,
                sku,
                null);
        }

        /// <summary> Initializes a new instance of <see cref="FlexibleServers.MySqlFlexibleServersCapabilityData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="supportedGeoBackupRegions"> supported geo backup regions. </param>
        /// <param name="supportedFlexibleServerEditions"> A list of supported flexible server editions. </param>
        /// <param name="supportedServerVersions"> A list of supported server versions. </param>
        /// <returns> A new <see cref="FlexibleServers.MySqlFlexibleServersCapabilityData"/> instance for mocking. </returns>
        public static MySqlFlexibleServersCapabilityData MySqlFlexibleServersCapabilityData(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IEnumerable<string> supportedGeoBackupRegions, IEnumerable<ServerEditionCapabilityV2> supportedFlexibleServerEditions, IEnumerable<ServerVersionCapabilityV2> supportedServerVersions)
            => MySqlFlexibleServersCapabilityData(id, name, resourceType, systemData, supportedGeoBackupRegions, supportedFlexibleServerEditions, supportedServerVersions, supportedFeatures: null);

        /// <summary> Initializes a new instance of <see cref="Models.MySqlFlexibleServersPrivateEndpointConnection"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="groupIds"> The group ids for the private endpoint resource. </param>
        /// <param name="privateEndpointId"> The private endpoint resource. </param>
        /// <param name="connectionState"> A collection of information about the state of the connection between service consumer and provider. </param>
        /// <param name="provisioningState"> The provisioning state of the private endpoint connection resource. </param>
        /// <returns> A new <see cref="Models.MySqlFlexibleServersPrivateEndpointConnection"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MySqlFlexibleServersPrivateEndpointConnection MySqlFlexibleServersPrivateEndpointConnection(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IEnumerable<string> groupIds, ResourceIdentifier privateEndpointId, MySqlFlexibleServersPrivateLinkServiceConnectionState connectionState, MySqlFlexibleServersPrivateEndpointConnectionProvisioningState? provisioningState)
        {
            groupIds ??= new List<string>();

            return new MySqlFlexibleServersPrivateEndpointConnection(
                id,
                name,
                resourceType,
                systemData,
                groupIds?.ToList(),
                privateEndpointId != null ? ResourceManagerModelFactory.SubResource(privateEndpointId) : null,
                connectionState,
                provisioningState,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.MySqlFlexibleServerStorage"/>. </summary>
        /// <param name="storageSizeInGB"> Max storage size allowed for a server. </param>
        /// <param name="iops"> Storage IOPS for a server. </param>
        /// <param name="autoGrow"> Enable Storage Auto Grow or not. </param>
        /// <param name="logOnDisk"> Enable Log On Disk or not. </param>
        /// <param name="storageSku"> The sku name of the server storage. </param>
        /// <param name="autoIoScaling"> Enable IO Auto Scaling or not. </param>
        /// <returns> A new <see cref="Models.MySqlFlexibleServerStorage"/> instance for mocking. </returns>
        public static MySqlFlexibleServerStorage MySqlFlexibleServerStorage(int? storageSizeInGB, int? iops, MySqlFlexibleServerEnableStatusEnum? autoGrow, MySqlFlexibleServerEnableStatusEnum? logOnDisk, string storageSku, MySqlFlexibleServerEnableStatusEnum? autoIoScaling)
            => MySqlFlexibleServerStorage(storageSizeInGB, iops, autoGrow, logOnDisk, storageSku, autoIoScaling, null);
    }
}
