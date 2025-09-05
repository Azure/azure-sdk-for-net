// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.StorageSync.Models
{
    public static partial class ArmStorageSyncModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.StorageSync.Models.StorageSyncServiceCreateOrUpdateContent" />. </summary>
        /// <param name="location"> Required. Gets or sets the location of the resource. This will be one of the supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). The geo region of a resource cannot be changed once it is created, but if an identical geo region is specified on update, the request will succeed. </param>
        /// <param name="tags"> Gets or sets a list of key value pairs that describe the resource. These tags can be used for viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key with a length no greater than 128 characters and a value with a length no greater than 256 characters. </param>
        /// <param name="incomingTrafficPolicy"> Incoming Traffic Policy. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.StorageSync.Models.StorageSyncServiceCreateOrUpdateContent" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSyncServiceCreateOrUpdateContent StorageSyncServiceCreateOrUpdateContent(AzureLocation location, IDictionary<string, string> tags, IncomingTrafficPolicy? incomingTrafficPolicy)
        {
            return StorageSyncServiceCreateOrUpdateContent(id: default, name: default, resourceType: default, systemData: default, tags: tags, location: location, identity: default, incomingTrafficPolicy: incomingTrafficPolicy, useIdentity: default);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="privateEndpointId"> The resource of private end point. </param>
        /// <param name="connectionState"> A collection of information about the state of the connection between service consumer and provider. </param>
        /// <param name="provisioningState"> The provisioning state of the private endpoint connection resource. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.StorageSync.StorageSyncPrivateEndpointConnectionData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSyncPrivateEndpointConnectionData StorageSyncPrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ResourceIdentifier privateEndpointId, StorageSyncPrivateLinkServiceConnectionState connectionState, StorageSyncPrivateEndpointConnectionProvisioningState? provisioningState)
        {
            return StorageSyncPrivateEndpointConnectionData(id: id, name: name, resourceType: resourceType, systemData: systemData, groupIds: default, privateEndpointId: privateEndpointId, connectionState: connectionState, provisioningState: provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.StorageSync.Models.StorageSyncRegisteredServerCreateOrUpdateContent" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="serverCertificate"> Registered Server Certificate. </param>
        /// <param name="agentVersion"> Registered Server Agent Version. </param>
        /// <param name="serverOSVersion"> Registered Server OS Version. </param>
        /// <param name="lastHeartbeat"> Registered Server last heart beat. </param>
        /// <param name="serverRole"> Registered Server serverRole. </param>
        /// <param name="clusterId"> Registered Server clusterId. </param>
        /// <param name="clusterName"> Registered Server clusterName. </param>
        /// <param name="serverId"> Registered Server serverId. </param>
        /// <param name="friendlyName"> Friendly Name. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.StorageSync.Models.StorageSyncRegisteredServerCreateOrUpdateContent" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSyncRegisteredServerCreateOrUpdateContent StorageSyncRegisteredServerCreateOrUpdateContent(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, BinaryData serverCertificate, string agentVersion, string serverOSVersion, string lastHeartbeat, string serverRole, Guid? clusterId, string clusterName, Guid? serverId, string friendlyName)
        {
            return StorageSyncRegisteredServerCreateOrUpdateContent(id: id, name: name, resourceType: resourceType, systemData: systemData, serverCertificate: serverCertificate, agentVersion: agentVersion, serverOSVersion: serverOSVersion, lastHeartbeat: lastHeartbeat, serverRole: serverRole, clusterId: clusterId, clusterName: clusterName, serverId: serverId, friendlyName: friendlyName, applicationId: default, useIdentity: default);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="serverCertificate"> Registered Server Certificate. </param>
        /// <param name="agentVersion"> Registered Server Agent Version. </param>
        /// <param name="agentVersionStatus"> Registered Server Agent Version Status. </param>
        /// <param name="agentVersionExpireOn"> Registered Server Agent Version Expiration Date. </param>
        /// <param name="serverOSVersion"> Registered Server OS Version. </param>
        /// <param name="serverManagementErrorCode"> Registered Server Management Error Code. </param>
        /// <param name="lastHeartbeat"> Registered Server last heart beat. </param>
        /// <param name="provisioningState"> Registered Server Provisioning State. </param>
        /// <param name="serverRole"> Registered Server serverRole. </param>
        /// <param name="clusterId"> Registered Server clusterId. </param>
        /// <param name="clusterName"> Registered Server clusterName. </param>
        /// <param name="serverId"> Registered Server serverId. </param>
        /// <param name="storageSyncServiceUid"> Registered Server storageSyncServiceUid. </param>
        /// <param name="lastWorkflowId"> Registered Server lastWorkflowId. </param>
        /// <param name="lastOperationName"> Resource Last Operation Name. </param>
        /// <param name="discoveryEndpointUri"> Resource discoveryEndpointUri. </param>
        /// <param name="resourceLocation"> Resource Location. </param>
        /// <param name="serviceLocation"> Service Location. </param>
        /// <param name="friendlyName"> Friendly Name. </param>
        /// <param name="managementEndpointUri"> Management Endpoint Uri. </param>
        /// <param name="monitoringEndpointUri"> Telemetry Endpoint Uri. </param>
        /// <param name="monitoringConfiguration"> Monitoring Configuration. </param>
        /// <param name="serverName"> Server name. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.StorageSync.StorageSyncRegisteredServerData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSyncRegisteredServerData StorageSyncRegisteredServerData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, BinaryData serverCertificate, string agentVersion, RegisteredServerAgentVersionStatus? agentVersionStatus, DateTimeOffset? agentVersionExpireOn, string serverOSVersion, int? serverManagementErrorCode, string lastHeartbeat, string provisioningState, string serverRole, Guid? clusterId, string clusterName, Guid? serverId, Guid? storageSyncServiceUid, string lastWorkflowId, string lastOperationName, Uri discoveryEndpointUri, AzureLocation? resourceLocation, AzureLocation? serviceLocation, string friendlyName, Uri managementEndpointUri, Uri monitoringEndpointUri, string monitoringConfiguration, string serverName)
        {
            return StorageSyncRegisteredServerData(id: id, name: name, resourceType: resourceType, systemData: systemData, serverCertificate: serverCertificate, agentVersion: agentVersion, agentVersionStatus: agentVersionStatus, agentVersionExpireOn: agentVersionExpireOn, serverOSVersion: serverOSVersion, serverManagementErrorCode: serverManagementErrorCode, lastHeartbeat: lastHeartbeat, provisioningState: provisioningState, serverRole: serverRole, clusterId: clusterId, clusterName: clusterName, serverId: serverId, storageSyncServiceUid: storageSyncServiceUid, lastWorkflowId: lastWorkflowId, lastOperationName: lastOperationName, discoveryEndpointUri: discoveryEndpointUri, resourceLocation: resourceLocation, serviceLocation: serviceLocation, friendlyName: friendlyName, managementEndpointUri: managementEndpointUri, monitoringEndpointUri: monitoringEndpointUri, monitoringConfiguration: monitoringConfiguration, serverName: serverName, applicationId: default, useIdentity: default, latestApplicationId: default, activeAuthType: default);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.StorageSync.StorageSyncServerEndpointData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="serverLocalPath"> Server Local path. </param>
        /// <param name="cloudTiering"> Cloud Tiering. </param>
        /// <param name="volumeFreeSpacePercent"> Level of free space to be maintained by Cloud Tiering if it is enabled. </param>
        /// <param name="tierFilesOlderThanDays"> Tier files older than days. </param>
        /// <param name="friendlyName"> Friendly Name. </param>
        /// <param name="serverResourceId"> Server Resource Id. </param>
        /// <param name="provisioningState"> ServerEndpoint Provisioning State. </param>
        /// <param name="lastWorkflowId"> ServerEndpoint lastWorkflowId. </param>
        /// <param name="lastOperationName"> Resource Last Operation Name. </param>
        /// <param name="syncStatus"> Server Endpoint sync status. </param>
        /// <param name="offlineDataTransfer"> Offline data transfer. </param>
        /// <param name="offlineDataTransferStorageAccountResourceId"> Offline data transfer storage account resource ID. </param>
        /// <param name="offlineDataTransferStorageAccountTenantId"> Offline data transfer storage account tenant ID. </param>
        /// <param name="offlineDataTransferShareName"> Offline data transfer share name. </param>
        /// <param name="cloudTieringStatus"> Cloud tiering status. Only populated if cloud tiering is enabled. </param>
        /// <param name="recallStatus"> Recall status. Only populated if cloud tiering is enabled. </param>
        /// <param name="initialDownloadPolicy"> Policy for how namespace and files are recalled during FastDr. </param>
        /// <param name="localCacheMode"> Policy for enabling follow-the-sun business models: link local cache to cloud behavior to pre-populate before local access. </param>
        /// <param name="initialUploadPolicy"> Policy for how the initial upload sync session is performed. </param>
        /// <param name="serverName"> Server name. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.StorageSync.StorageSyncServerEndpointData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSyncServerEndpointData StorageSyncServerEndpointData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string serverLocalPath, StorageSyncFeatureStatus? cloudTiering, int? volumeFreeSpacePercent, int? tierFilesOlderThanDays, string friendlyName, ResourceIdentifier serverResourceId, string provisioningState, string lastWorkflowId, string lastOperationName, ServerEndpointSyncStatus syncStatus, StorageSyncFeatureStatus? offlineDataTransfer, ResourceIdentifier offlineDataTransferStorageAccountResourceId, Guid? offlineDataTransferStorageAccountTenantId, string offlineDataTransferShareName, ServerEndpointCloudTieringStatus cloudTieringStatus, ServerEndpointRecallStatus recallStatus, InitialDownloadPolicy? initialDownloadPolicy, LocalCacheMode? localCacheMode, InitialUploadPolicy? initialUploadPolicy, string serverName)
        {
            return StorageSyncServerEndpointData(id: id, name: name, resourceType: resourceType, systemData: systemData, serverLocalPath: serverLocalPath, cloudTiering: cloudTiering, volumeFreeSpacePercent: volumeFreeSpacePercent, tierFilesOlderThanDays: tierFilesOlderThanDays, friendlyName: friendlyName, serverResourceId: serverResourceId, provisioningState: provisioningState, lastWorkflowId: lastWorkflowId, lastOperationName: lastOperationName, syncStatus: syncStatus, offlineDataTransfer: offlineDataTransfer, offlineDataTransferStorageAccountResourceId: offlineDataTransferStorageAccountResourceId, offlineDataTransferStorageAccountTenantId: offlineDataTransferStorageAccountTenantId, offlineDataTransferShareName: offlineDataTransferShareName, cloudTieringStatus: cloudTieringStatus, recallStatus: recallStatus, initialDownloadPolicy: initialDownloadPolicy, localCacheMode: localCacheMode, initialUploadPolicy: initialUploadPolicy, serverName: serverName, serverEndpointProvisioningStatus: default);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.StorageSync.StorageSyncServiceData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="incomingTrafficPolicy"> Incoming Traffic Policy. </param>
        /// <param name="storageSyncServiceStatus"> Storage Sync service status. </param>
        /// <param name="storageSyncServiceUid"> Storage Sync service Uid. </param>
        /// <param name="provisioningState"> StorageSyncService Provisioning State. </param>
        /// <param name="lastWorkflowId"> StorageSyncService lastWorkflowId. </param>
        /// <param name="lastOperationName"> Resource Last Operation Name. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connection associated with the specified storage sync service. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.StorageSync.StorageSyncServiceData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSyncServiceData StorageSyncServiceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IncomingTrafficPolicy? incomingTrafficPolicy, int? storageSyncServiceStatus, Guid? storageSyncServiceUid, string provisioningState, string lastWorkflowId, string lastOperationName, IEnumerable<StorageSyncPrivateEndpointConnectionData> privateEndpointConnections)
        {
            return StorageSyncServiceData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, identity: default, incomingTrafficPolicy: incomingTrafficPolicy, storageSyncServiceStatus: storageSyncServiceStatus, storageSyncServiceUid: storageSyncServiceUid, provisioningState: provisioningState, useIdentity: default, lastWorkflowId: lastWorkflowId, lastOperationName: lastOperationName, privateEndpointConnections: privateEndpointConnections);
        }
    }
}
