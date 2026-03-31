// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: Baseline ModelFactory methods had non-nullable enum/struct parameters and different method names
// (without "Data" suffix) for sub-resource types. This provides backward-compatible overloads.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public static partial class ArmDataBoxEdgeModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.BandwidthScheduleData"/>. </summary>
        public static BandwidthScheduleData BandwidthScheduleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, TimeSpan startOn, TimeSpan stopOn, int rateInMbps, IEnumerable<DataBoxEdgeDayOfWeek> days)
        {
            return BandwidthScheduleData(id, name, resourceType, systemData, (TimeSpan?)startOn, (TimeSpan?)stopOn, (int?)rateInMbps, days);
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
            return DataBoxEdgeShareData(id, name, resourceType, systemData, description, (ShareStatus?)shareStatus, (DataBoxEdgeShareMonitoringStatus?)monitoringStatus, azureContainerInfo, (ShareAccessProtocol?)accessProtocol, userAccessRights, clientAccessRights, refreshDetails, shareMappings, dataPolicy);
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeStorageAccountCredentialData"/>. </summary>
        public static DataBoxEdgeStorageAccountCredentialData DataBoxEdgeStorageAccountCredentialData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string @alias, string userName, AsymmetricEncryptedSecret accountKey, string connectionString, DataBoxEdgeStorageAccountSslStatus sslStatus, string blobDomainName, DataBoxEdgeStorageAccountType accountType, ResourceIdentifier storageAccountId)
        {
            return DataBoxEdgeStorageAccountCredentialData(id, name, resourceType, systemData, @alias, userName, accountKey, connectionString, (DataBoxEdgeStorageAccountSslStatus?)sslStatus, blobDomainName, (DataBoxEdgeStorageAccountType?)accountType, storageAccountId);
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeStorageAccountData"/>. </summary>
        public static DataBoxEdgeStorageAccountData DataBoxEdgeStorageAccountData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string description, DataBoxEdgeStorageAccountStatus? storageAccountStatus, DataBoxEdgeDataPolicy dataPolicy, ResourceIdentifier storageAccountCredentialId, string blobEndpoint, int? containerCount)
        {
            return DataBoxEdgeStorageAccountData(id, name, resourceType, systemData, description, storageAccountStatus, (DataBoxEdgeDataPolicy?)dataPolicy, storageAccountCredentialId, blobEndpoint, containerCount);
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeStorageContainerData"/>. </summary>
        public static DataBoxEdgeStorageContainerData DataBoxEdgeStorageContainerData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DataBoxEdgeStorageContainerStatus? containerStatus, DataBoxEdgeStorageContainerDataFormat dataFormat, DataBoxEdgeRefreshDetails refreshDetails, DateTimeOffset? createdOn)
        {
            return DataBoxEdgeStorageContainerData(id, name, resourceType, systemData, containerStatus, (DataBoxEdgeStorageContainerDataFormat?)dataFormat, refreshDetails, createdOn);
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeUserData"/>. </summary>
        public static DataBoxEdgeUserData DataBoxEdgeUserData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AsymmetricEncryptedSecret encryptedPassword, IEnumerable<ShareAccessRight> shareAccessRights, DataBoxEdgeUserType userType)
        {
            return DataBoxEdgeUserData(id, name, resourceType, systemData, encryptedPassword, shareAccessRights, (DataBoxEdgeUserType?)userType);
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DiagnosticProactiveLogCollectionSettingData"/>. </summary>
        public static DiagnosticProactiveLogCollectionSettingData DiagnosticProactiveLogCollectionSettingData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ProactiveDiagnosticsConsent userConsent)
        {
            return DiagnosticProactiveLogCollectionSettingData(id, name, resourceType, systemData, (ProactiveDiagnosticsConsent?)userConsent);
        }

        /// <summary> Initializes a new instance of <see cref="Models.EdgeArcAddon"/>. </summary>
        public static EdgeArcAddon EdgeArcAddon(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string subscriptionId, string resourceGroupName, string resourceName, AzureLocation resourceLocation, string version, DataBoxEdgeOSPlatformType? hostPlatform, HostPlatformType? hostPlatformType, DataBoxEdgeRoleAddonProvisioningState? provisioningState)
        {
            return EdgeArcAddon(id, name, resourceType, systemData, subscriptionId, resourceGroupName, resourceName, (AzureLocation?)resourceLocation, version, hostPlatform, hostPlatformType, provisioningState);
        }
    }
}
