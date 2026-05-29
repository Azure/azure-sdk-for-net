// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This file exists for two reasons:
//
// 1. GROUP 1 — Type-shim backward-compat (3 methods, EBNever):
//    The spec models DataBoxEdgeDeviceCapacityInfo, DataBoxEdgeDeviceNetworkSettings and
//    DataBoxEdgeDeviceUpdateSummary as ARM sub-resources (@parentResource on ProxyResource),
//    so the generator creates dedicated resource classes instead of plain model types. The old
//    baseline exposed factory methods returning the wrapper types without the "Data" suffix.
//    These overloads restore that surface for ApiCompat.
//
// 2. GROUP 2 — Nullable-param backward-compat (8 methods × 2 overloads):
//    The generator now emits nullable enum/value-type params (e.g. TimeSpan?, ShareStatus?),
//    but the baseline had non-nullable equivalents — a different CLR signature that breaks ApiCompat.
//    Because the generator suppresses ALL overloads for a method name whenever any custom method
//    with that name exists (it compares by name + param count + type names, ignoring nullability),
//    this file must also own the nullable implementations that would otherwise be generated.
//    Each of the 8 methods therefore appears twice:
//      a) A nullable overload (no EBNever) — owns the implementation, replaces the generated one.
//      b) A non-nullable overload (EBNever)  — backward-compat, delegates to (a).

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.DataBoxEdge;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public static partial class ArmDataBoxEdgeModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.DataBoxEdgeDeviceCapacityInfo"/>. </summary>
        [Obsolete("Use ArmDataBoxEdgeModelFactory.DataBoxEdgeDeviceCapacityInfoData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataBoxEdgeDeviceCapacityInfo DataBoxEdgeDeviceCapacityInfo(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, DateTimeOffset? timeStamp = default, EdgeClusterStorageViewInfo clusterStorageCapacityInfo = default, EdgeClusterCapacityViewInfo clusterComputeCapacityInfo = default, IDictionary<string, HostCapacity> nodeCapacityInfos = default)
            => throw new NotSupportedException("Use ArmDataBoxEdgeModelFactory.DataBoxEdgeDeviceCapacityInfoData instead.");

        /// <summary> Initializes a new instance of <see cref="Models.DataBoxEdgeDeviceNetworkSettings"/>. </summary>
        [Obsolete("Use ArmDataBoxEdgeModelFactory.DataBoxEdgeDeviceNetworkSettingsData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataBoxEdgeDeviceNetworkSettings DataBoxEdgeDeviceNetworkSettings(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IEnumerable<DataBoxEdgeNetworkAdapter> networkAdapters = default)
            => throw new NotSupportedException("Use ArmDataBoxEdgeModelFactory.DataBoxEdgeDeviceNetworkSettingsData instead.");

        /// <summary> Initializes a new instance of <see cref="Models.DataBoxEdgeDeviceUpdateSummary"/>. </summary>
        [Obsolete("Use ArmDataBoxEdgeModelFactory.DataBoxEdgeDeviceUpdateSummaryData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataBoxEdgeDeviceUpdateSummary DataBoxEdgeDeviceUpdateSummary(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string deviceVersionNumber = default, string friendlyDeviceVersionName = default, DateTimeOffset? deviceLastScannedOn = default, DateTimeOffset? lastCompletedScanJobOn = default, DateTimeOffset? lastSuccessfulScanJobOn = default, DateTimeOffset? lastCompletedDownloadJobOn = default, ResourceIdentifier lastCompletedDownloadJobId = default, DataBoxEdgeJobStatus? lastDownloadJobStatus = default, DateTimeOffset? lastSuccessfulInstallJobOn = default, DateTimeOffset? lastCompletedInstallJobOn = default, ResourceIdentifier lastCompletedInstallJobId = default, DataBoxEdgeJobStatus? lastInstallJobStatus = default, int? totalNumberOfUpdatesAvailable = default, int? totalNumberOfUpdatesPendingDownload = default, int? totalNumberOfUpdatesPendingInstall = default, InstallRebootBehavior? rebootBehavior = default, DataBoxEdgeUpdateOperation? ongoingUpdateOperation = default, ResourceIdentifier inProgressDownloadJobId = default, ResourceIdentifier inProgressInstallJobId = default, DateTimeOffset? inProgressDownloadJobStartedOn = default, DateTimeOffset? inProgressInstallJobStartedOn = default, IEnumerable<string> updateTitles = default, IEnumerable<DataBoxEdgeUpdateDetails> updates = default, double? totalUpdateSizeInBytes = default, int? totalTimeInMinutes = default)
            => throw new NotSupportedException("Use ArmDataBoxEdgeModelFactory.DataBoxEdgeDeviceUpdateSummaryData instead.");

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.BandwidthScheduleData"/>. </summary>
        public static BandwidthScheduleData BandwidthScheduleData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, TimeSpan? startOn = default, TimeSpan? stopOn = default, int? rateInMbps = default, IEnumerable<DataBoxEdgeDayOfWeek> days = default)
        {
            return new BandwidthScheduleData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                startOn is null && stopOn is null && rateInMbps is null && days is null ? default : new BandwidthScheduleProperties(startOn.Value, stopOn.Value, rateInMbps.Value, (days ?? new ChangeTrackingList<DataBoxEdgeDayOfWeek>()).ToList(), null));
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeShareData"/>. </summary>
        public static DataBoxEdgeShareData DataBoxEdgeShareData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string description = default, ShareStatus? shareStatus = default, DataBoxEdgeShareMonitoringStatus? monitoringStatus = default, DataBoxEdgeStorageContainerInfo azureContainerInfo = default, ShareAccessProtocol? accessProtocol = default, IEnumerable<UserAccessRight> userAccessRights = default, IEnumerable<ClientAccessRight> clientAccessRights = default, DataBoxEdgeRefreshDetails refreshDetails = default, IEnumerable<DataBoxEdgeMountPointMap> shareMappings = default, DataBoxEdgeDataPolicy? dataPolicy = default)
        {
            return new DataBoxEdgeShareData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                description is null && shareStatus is null && monitoringStatus is null && azureContainerInfo is null && accessProtocol is null && userAccessRights is null && clientAccessRights is null && refreshDetails is null && shareMappings is null && dataPolicy is null ? default : new ShareProperties(
                    description,
                    shareStatus.Value,
                    monitoringStatus.Value,
                    azureContainerInfo,
                    accessProtocol.Value,
                    (userAccessRights ?? new ChangeTrackingList<UserAccessRight>()).ToList(),
                    (clientAccessRights ?? new ChangeTrackingList<ClientAccessRight>()).ToList(),
                    refreshDetails,
                    (shareMappings ?? new ChangeTrackingList<DataBoxEdgeMountPointMap>()).ToList(),
                    dataPolicy,
                    null));
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeStorageAccountCredentialData"/>. </summary>
        public static DataBoxEdgeStorageAccountCredentialData DataBoxEdgeStorageAccountCredentialData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string @alias = default, string userName = default, AsymmetricEncryptedSecret accountKey = default, string connectionString = default, DataBoxEdgeStorageAccountSslStatus? sslStatus = default, string blobDomainName = default, DataBoxEdgeStorageAccountType? accountType = default, ResourceIdentifier storageAccountId = default)
        {
            return new DataBoxEdgeStorageAccountCredentialData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                @alias is null && userName is null && accountKey is null && connectionString is null && sslStatus is null && blobDomainName is null && accountType is null && storageAccountId is null ? default : new StorageAccountCredentialProperties(
                    @alias,
                    userName,
                    accountKey,
                    connectionString,
                    sslStatus.Value,
                    blobDomainName,
                    accountType.Value,
                    storageAccountId,
                    null));
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeStorageAccountData"/>. </summary>
        public static DataBoxEdgeStorageAccountData DataBoxEdgeStorageAccountData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string description = default, DataBoxEdgeStorageAccountStatus? storageAccountStatus = default, DataBoxEdgeDataPolicy? dataPolicy = default, ResourceIdentifier storageAccountCredentialId = default, string blobEndpoint = default, int? containerCount = default)
        {
            return new DataBoxEdgeStorageAccountData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                description is null && storageAccountStatus is null && dataPolicy is null && storageAccountCredentialId is null && blobEndpoint is null && containerCount is null ? default : new StorageAccountProperties(
                    description,
                    storageAccountStatus,
                    dataPolicy.Value,
                    storageAccountCredentialId,
                    blobEndpoint,
                    containerCount,
                    null));
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeStorageContainerData"/>. </summary>
        public static DataBoxEdgeStorageContainerData DataBoxEdgeStorageContainerData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, DataBoxEdgeStorageContainerStatus? containerStatus = default, DataBoxEdgeStorageContainerDataFormat? dataFormat = default, DataBoxEdgeRefreshDetails refreshDetails = default, DateTimeOffset? createdOn = default)
        {
            return new DataBoxEdgeStorageContainerData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                containerStatus is null && dataFormat is null && refreshDetails is null && createdOn is null ? default : new ContainerProperties(containerStatus, dataFormat.Value, refreshDetails, createdOn, null));
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeUserData"/>. </summary>
        public static DataBoxEdgeUserData DataBoxEdgeUserData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, AsymmetricEncryptedSecret encryptedPassword = default, IEnumerable<ShareAccessRight> shareAccessRights = default, DataBoxEdgeUserType? userType = default)
        {
            return new DataBoxEdgeUserData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                encryptedPassword is null && shareAccessRights is null && userType is null ? default : new UserProperties(encryptedPassword, (shareAccessRights ?? new ChangeTrackingList<ShareAccessRight>()).ToList(), userType.Value, null));
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DiagnosticProactiveLogCollectionSettingData"/>. </summary>
        public static DiagnosticProactiveLogCollectionSettingData DiagnosticProactiveLogCollectionSettingData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ProactiveDiagnosticsConsent? userConsent = default)
        {
            return new DiagnosticProactiveLogCollectionSettingData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                userConsent is null ? default : new ProactiveLogCollectionSettingsProperties(userConsent.Value, null));
        }

        /// <summary> Initializes a new instance of <see cref="Models.EdgeArcAddon"/>. </summary>
        public static EdgeArcAddon EdgeArcAddon(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string subscriptionId = default, string resourceGroupName = default, string resourceName = default, AzureLocation? resourceLocation = default, string version = default, DataBoxEdgeOSPlatformType? hostPlatform = default, HostPlatformType? hostPlatformType = default, DataBoxEdgeRoleAddonProvisioningState? provisioningState = default)
        {
            return new EdgeArcAddon(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                AddonType.ArcForKubernetes,
                subscriptionId is null && resourceGroupName is null && resourceName is null && resourceLocation is null && version is null && hostPlatform is null && hostPlatformType is null && provisioningState is null ? default : new ArcAddonProperties(
                    subscriptionId,
                    resourceGroupName,
                    resourceName,
                    resourceLocation.Value,
                    version,
                    hostPlatform,
                    hostPlatformType,
                    provisioningState,
                    null));
        }

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.BandwidthScheduleData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BandwidthScheduleData BandwidthScheduleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, TimeSpan startOn, TimeSpan stopOn, int rateInMbps, IEnumerable<DataBoxEdgeDayOfWeek> days)
            => BandwidthScheduleData(id, name, resourceType, systemData, (TimeSpan?)startOn, (TimeSpan?)stopOn, (int?)rateInMbps, days);

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeShareData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataBoxEdgeShareData DataBoxEdgeShareData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string description, ShareStatus shareStatus, DataBoxEdgeShareMonitoringStatus monitoringStatus, DataBoxEdgeStorageContainerInfo azureContainerInfo, ShareAccessProtocol accessProtocol, IEnumerable<UserAccessRight> userAccessRights, IEnumerable<ClientAccessRight> clientAccessRights, DataBoxEdgeRefreshDetails refreshDetails, IEnumerable<DataBoxEdgeMountPointMap> shareMappings, DataBoxEdgeDataPolicy? dataPolicy)
            => DataBoxEdgeShareData(id, name, resourceType, systemData, description, (ShareStatus?)shareStatus, (DataBoxEdgeShareMonitoringStatus?)monitoringStatus, azureContainerInfo, (ShareAccessProtocol?)accessProtocol, userAccessRights, clientAccessRights, refreshDetails, shareMappings, dataPolicy);

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeStorageAccountCredentialData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataBoxEdgeStorageAccountCredentialData DataBoxEdgeStorageAccountCredentialData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string @alias, string userName, AsymmetricEncryptedSecret accountKey, string connectionString, DataBoxEdgeStorageAccountSslStatus sslStatus, string blobDomainName, DataBoxEdgeStorageAccountType accountType, ResourceIdentifier storageAccountId)
            => DataBoxEdgeStorageAccountCredentialData(id, name, resourceType, systemData, @alias, userName, accountKey, connectionString, (DataBoxEdgeStorageAccountSslStatus?)sslStatus, blobDomainName, (DataBoxEdgeStorageAccountType?)accountType, storageAccountId);

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeStorageAccountData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataBoxEdgeStorageAccountData DataBoxEdgeStorageAccountData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string description, DataBoxEdgeStorageAccountStatus? storageAccountStatus, DataBoxEdgeDataPolicy dataPolicy, ResourceIdentifier storageAccountCredentialId, string blobEndpoint, int? containerCount)
            => DataBoxEdgeStorageAccountData(id, name, resourceType, systemData, description, storageAccountStatus, (DataBoxEdgeDataPolicy?)dataPolicy, storageAccountCredentialId, blobEndpoint, containerCount);

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeStorageContainerData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataBoxEdgeStorageContainerData DataBoxEdgeStorageContainerData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DataBoxEdgeStorageContainerStatus? containerStatus, DataBoxEdgeStorageContainerDataFormat dataFormat, DataBoxEdgeRefreshDetails refreshDetails, DateTimeOffset? createdOn)
            => DataBoxEdgeStorageContainerData(id, name, resourceType, systemData, containerStatus, (DataBoxEdgeStorageContainerDataFormat?)dataFormat, refreshDetails, createdOn);

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DataBoxEdgeUserData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataBoxEdgeUserData DataBoxEdgeUserData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AsymmetricEncryptedSecret encryptedPassword, IEnumerable<ShareAccessRight> shareAccessRights, DataBoxEdgeUserType userType)
            => DataBoxEdgeUserData(id, name, resourceType, systemData, encryptedPassword, shareAccessRights, (DataBoxEdgeUserType?)userType);

        /// <summary> Initializes a new instance of <see cref="DataBoxEdge.DiagnosticProactiveLogCollectionSettingData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DiagnosticProactiveLogCollectionSettingData DiagnosticProactiveLogCollectionSettingData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ProactiveDiagnosticsConsent userConsent)
            => DiagnosticProactiveLogCollectionSettingData(id, name, resourceType, systemData, (ProactiveDiagnosticsConsent?)userConsent);

        /// <summary> Initializes a new instance of <see cref="Models.EdgeArcAddon"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EdgeArcAddon EdgeArcAddon(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string subscriptionId, string resourceGroupName, string resourceName, AzureLocation resourceLocation, string version, DataBoxEdgeOSPlatformType? hostPlatform, HostPlatformType? hostPlatformType, DataBoxEdgeRoleAddonProvisioningState? provisioningState)
            => EdgeArcAddon(id, name, resourceType, systemData, subscriptionId, resourceGroupName, resourceName, (AzureLocation?)resourceLocation, version, hostPlatform, hostPlatformType, provisioningState);
    }
}
