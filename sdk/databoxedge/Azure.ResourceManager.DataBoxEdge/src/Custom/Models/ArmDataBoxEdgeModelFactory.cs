// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Baseline ModelFactory methods used non-nullable value-type/enum parameters (e.g. TimeSpan, ShareStatus),
// but the new generator produces nullable versions (TimeSpan?, ShareStatus?). These are different CLR
// signatures, so backward-compat overloads with the original non-nullable signatures are required.
// The 3 type-shim methods (CapacityInfo, NetworkSettings, UpdateSummary) also return backward-compat
// wrapper types (without "Data" suffix).

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public static partial class ArmDataBoxEdgeModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.BandwidthScheduleData"/>. </summary>
        public static BandwidthScheduleData BandwidthScheduleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, TimeSpan startOn, TimeSpan stopOn, int rateInMbps, IEnumerable<DataBoxEdgeDayOfWeek> days)
        {
            return new BandwidthScheduleData(id, name, resourceType, systemData, additionalBinaryDataProperties: null, new BandwidthScheduleProperties(startOn, stopOn, rateInMbps, days?.ToList(), null));
        }

        /// <summary> Initializes a new instance of <see cref="Models.DataBoxEdgeDeviceCapacityInfo"/>. </summary>
        public static DataBoxEdgeDeviceCapacityInfo DataBoxEdgeDeviceCapacityInfo(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, DateTimeOffset? timeStamp = default, EdgeClusterStorageViewInfo clusterStorageCapacityInfo = default, EdgeClusterCapacityViewInfo clusterComputeCapacityInfo = default, IDictionary<string, HostCapacity> nodeCapacityInfos = default)
        {
            var data = DataBoxEdgeDeviceCapacityInfoData(id, name, resourceType, systemData, timeStamp, clusterStorageCapacityInfo, clusterComputeCapacityInfo, nodeCapacityInfos);
            return new DataBoxEdgeDeviceCapacityInfo(data);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DataBoxEdgeDeviceNetworkSettings"/>. </summary>
        public static DataBoxEdgeDeviceNetworkSettings DataBoxEdgeDeviceNetworkSettings(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IEnumerable<DataBoxEdgeNetworkAdapter> networkAdapters = default)
        {
            var data = DataBoxEdgeDeviceNetworkSettingsData(id, name, resourceType, systemData, networkAdapters);
            return new DataBoxEdgeDeviceNetworkSettings(data);
        }

        /// <summary> Initializes a new instance of <see cref="Models.DataBoxEdgeDeviceUpdateSummary"/>. </summary>
        public static DataBoxEdgeDeviceUpdateSummary DataBoxEdgeDeviceUpdateSummary(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string deviceVersionNumber = default, string friendlyDeviceVersionName = default, DateTimeOffset? deviceLastScannedOn = default, DateTimeOffset? lastCompletedScanJobOn = default, DateTimeOffset? lastSuccessfulScanJobOn = default, DateTimeOffset? lastCompletedDownloadJobOn = default, ResourceIdentifier lastCompletedDownloadJobId = default, DataBoxEdgeJobStatus? lastDownloadJobStatus = default, DateTimeOffset? lastSuccessfulInstallJobOn = default, DateTimeOffset? lastCompletedInstallJobOn = default, ResourceIdentifier lastCompletedInstallJobId = default, DataBoxEdgeJobStatus? lastInstallJobStatus = default, int? totalNumberOfUpdatesAvailable = default, int? totalNumberOfUpdatesPendingDownload = default, int? totalNumberOfUpdatesPendingInstall = default, InstallRebootBehavior? rebootBehavior = default, DataBoxEdgeUpdateOperation? ongoingUpdateOperation = default, ResourceIdentifier inProgressDownloadJobId = default, ResourceIdentifier inProgressInstallJobId = default, DateTimeOffset? inProgressDownloadJobStartedOn = default, DateTimeOffset? inProgressInstallJobStartedOn = default, IEnumerable<string> updateTitles = default, IEnumerable<DataBoxEdgeUpdateDetails> updates = default, double? totalUpdateSizeInBytes = default, int? totalTimeInMinutes = default)
        {
            var data = DataBoxEdgeDeviceUpdateSummaryData(id, name, resourceType, systemData, deviceVersionNumber, friendlyDeviceVersionName, deviceLastScannedOn, lastCompletedScanJobOn, lastSuccessfulScanJobOn, lastCompletedDownloadJobOn, lastCompletedDownloadJobId, lastDownloadJobStatus, lastSuccessfulInstallJobOn, lastCompletedInstallJobOn, lastCompletedInstallJobId, lastInstallJobStatus, totalNumberOfUpdatesAvailable, totalNumberOfUpdatesPendingDownload, totalNumberOfUpdatesPendingInstall, rebootBehavior, ongoingUpdateOperation, inProgressDownloadJobId, inProgressInstallJobId, inProgressDownloadJobStartedOn, inProgressInstallJobStartedOn, updateTitles, updates, totalUpdateSizeInBytes, totalTimeInMinutes);
            return new DataBoxEdgeDeviceUpdateSummary(data);
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeShareData"/>. </summary>
        public static DataBoxEdgeShareData DataBoxEdgeShareData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string description, ShareStatus shareStatus, DataBoxEdgeShareMonitoringStatus monitoringStatus, DataBoxEdgeStorageContainerInfo azureContainerInfo, ShareAccessProtocol accessProtocol, IEnumerable<UserAccessRight> userAccessRights, IEnumerable<ClientAccessRight> clientAccessRights, DataBoxEdgeRefreshDetails refreshDetails, IEnumerable<DataBoxEdgeMountPointMap> shareMappings, DataBoxEdgeDataPolicy? dataPolicy)
        {
            return new DataBoxEdgeShareData(id, name, resourceType, systemData, additionalBinaryDataProperties: null, new ShareProperties(description, shareStatus, monitoringStatus, azureContainerInfo, accessProtocol, userAccessRights?.ToList(), clientAccessRights?.ToList(), refreshDetails, shareMappings?.ToList(), dataPolicy, null));
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeStorageAccountCredentialData"/>. </summary>
        public static DataBoxEdgeStorageAccountCredentialData DataBoxEdgeStorageAccountCredentialData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string @alias, string userName, AsymmetricEncryptedSecret accountKey, string connectionString, DataBoxEdgeStorageAccountSslStatus sslStatus, string blobDomainName, DataBoxEdgeStorageAccountType accountType, ResourceIdentifier storageAccountId)
        {
            return new DataBoxEdgeStorageAccountCredentialData(id, name, resourceType, systemData, additionalBinaryDataProperties: null, new StorageAccountCredentialProperties(@alias, userName, accountKey, connectionString, sslStatus, blobDomainName, accountType, storageAccountId, null));
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeStorageAccountData"/>. </summary>
        public static DataBoxEdgeStorageAccountData DataBoxEdgeStorageAccountData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string description, DataBoxEdgeStorageAccountStatus? storageAccountStatus, DataBoxEdgeDataPolicy dataPolicy, ResourceIdentifier storageAccountCredentialId, string blobEndpoint, int? containerCount)
        {
            return new DataBoxEdgeStorageAccountData(id, name, resourceType, systemData, additionalBinaryDataProperties: null, new StorageAccountProperties(description, storageAccountStatus, dataPolicy, storageAccountCredentialId, blobEndpoint, containerCount, null));
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeStorageContainerData"/>. </summary>
        public static DataBoxEdgeStorageContainerData DataBoxEdgeStorageContainerData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DataBoxEdgeStorageContainerStatus? containerStatus, DataBoxEdgeStorageContainerDataFormat dataFormat, DataBoxEdgeRefreshDetails refreshDetails, DateTimeOffset? createdOn)
        {
            return new DataBoxEdgeStorageContainerData(id, name, resourceType, systemData, additionalBinaryDataProperties: null, new ContainerProperties(containerStatus, dataFormat, refreshDetails, createdOn, null));
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeUserData"/>. </summary>
        public static DataBoxEdgeUserData DataBoxEdgeUserData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AsymmetricEncryptedSecret encryptedPassword, IEnumerable<ShareAccessRight> shareAccessRights, DataBoxEdgeUserType userType)
        {
            return new DataBoxEdgeUserData(id, name, resourceType, systemData, additionalBinaryDataProperties: null, new UserProperties(encryptedPassword, shareAccessRights?.ToList(), userType, null));
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DiagnosticProactiveLogCollectionSettingData"/>. </summary>
        public static DiagnosticProactiveLogCollectionSettingData DiagnosticProactiveLogCollectionSettingData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ProactiveDiagnosticsConsent userConsent)
        {
            return new DiagnosticProactiveLogCollectionSettingData(id, name, resourceType, systemData, additionalBinaryDataProperties: null, new ProactiveLogCollectionSettingsProperties(userConsent, null));
        }

        /// <summary> Initializes a new instance of <see cref="Models.EdgeArcAddon"/>. </summary>
        public static EdgeArcAddon EdgeArcAddon(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string subscriptionId, string resourceGroupName, string resourceName, AzureLocation resourceLocation, string version, DataBoxEdgeOSPlatformType? hostPlatform, HostPlatformType? hostPlatformType, DataBoxEdgeRoleAddonProvisioningState? provisioningState)
        {
            return new EdgeArcAddon(id, name, resourceType, systemData, additionalBinaryDataProperties: null, AddonType.ArcForKubernetes, new ArcAddonProperties(subscriptionId, resourceGroupName, resourceName, resourceLocation, version, hostPlatform, hostPlatformType, provisioningState, null));
        }
    }
}
