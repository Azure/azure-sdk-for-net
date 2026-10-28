// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Suppresses generated factory methods whose signatures changed (parameter types differ)
// and provides overloads matching the prior GA API surface. Could not be replaced by spec changes
// because the parameter type differences stem from model restructuring (e.g. flattened properties).

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Model factory for models. </summary>
    // Suppress: generated method uses string groupId; prior GA used ResourceIdentifier groupId.
    [CodeGenSuppress("StoragePrivateLinkResourceData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(string), typeof(IEnumerable<string>), typeof(IEnumerable<string>))]
    [CodeGenSuppress("StorageTableAccessPolicy", typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string))]
    [CodeGenSuppress("StorageAccountCreateOrUpdateContent", typeof(StorageSku), typeof(StorageKind), typeof(AzureLocation), typeof(ExtendedLocation), typeof(IEnumerable<string>), typeof(StorageAccountZonePlacementPolicy?), typeof(IDictionary<string, string>), typeof(ManagedServiceIdentity), typeof(AllowedCopyScope?), typeof(StoragePublicNetworkAccess?), typeof(StorageAccountSasPolicy), typeof(StorageCustomDomain), typeof(StorageAccountEncryption), typeof(StorageAccountNetworkRuleSet), typeof(StorageAccountAccessTier?), typeof(TurboTier), typeof(FilesIdentityBasedAuthentication), typeof(bool?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(LargeFileSharesState?), typeof(StorageRoutingPreference), typeof(bool?), typeof(StorageMinimumTlsVersion?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(ImmutableStorageAccount), typeof(StorageDnsEndpointType?), typeof(StorageAccountSharedKeyAccessProperties), typeof(StorageDataCollaborationPolicyProperties), typeof(bool?), typeof(int?), typeof(bool?), typeof(bool?))]
    [CodeGenSuppress("StorageAccountPatch", typeof(StorageSku), typeof(IDictionary<string, string>), typeof(ManagedServiceIdentity), typeof(StorageCustomDomain), typeof(StorageAccountEncryption), typeof(StorageAccountSasPolicy), typeof(StorageAccountAccessTier?), typeof(TurboTier), typeof(FilesIdentityBasedAuthentication), typeof(bool?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(StorageAccountNetworkRuleSet), typeof(LargeFileSharesState?), typeof(StorageRoutingPreference), typeof(bool?), typeof(StorageMinimumTlsVersion?), typeof(bool?), typeof(bool?), typeof(bool?), typeof(StoragePublicNetworkAccess?), typeof(ImmutableStorageAccount), typeof(AllowedCopyScope?), typeof(StorageDnsEndpointType?), typeof(StorageAccountSharedKeyAccessProperties), typeof(StorageDataCollaborationPolicyProperties), typeof(bool?), typeof(int?), typeof(bool?), typeof(bool?), typeof(StorageKind?), typeof(IEnumerable<string>), typeof(StorageAccountZonePlacementPolicy?))]
    public static partial class ArmStorageModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Storage.FileServiceData"/> for mocking. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The resource system metadata. </param>
        /// <param name="sku"> The service SKU. </param>
        /// <param name="corsRules"> The CORS rules. </param>
        /// <param name="shareDeleteRetentionPolicy"> The share soft-delete retention policy. </param>
        /// <param name="protocolSettings"> The file service protocol settings. </param>
        /// <returns> A new <see cref="Storage.FileServiceData"/> instance for mocking. </returns>
        public static FileServiceData FileServiceData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, StorageSku sku = default, IEnumerable<StorageCorsRule> corsRules = default, DeleteRetentionPolicy shareDeleteRetentionPolicy = default, FileServiceProtocolSettings protocolSettings = default)
        {
            return new FileServiceData(
                id,
                name,
                resourceType,
                systemData,
                corsRules is null && shareDeleteRetentionPolicy is null && protocolSettings is null ? default : new FileServicePropertiesProperties(corsRules is null ? default : new StorageCorsRules((corsRules ?? new ChangeTrackingList<StorageCorsRule>()).ToList(), default), shareDeleteRetentionPolicy, protocolSettings, default),
                sku,
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.FileShareLimits"/> for mocking. </summary>
        /// <param name="minProvisionedStorageGiB"> The minimum provisioned storage quota in gibibytes. </param>
        /// <param name="maxProvisionedStorageGiB"> The maximum provisioned storage quota in gibibytes. </param>
        /// <param name="minProvisionedIops"> The minimum provisioned IOPS. </param>
        /// <param name="maxProvisionedIops"> The maximum provisioned IOPS. </param>
        /// <param name="minProvisionedBandwidthMiBPerSec"> The minimum provisioned bandwidth in mebibytes per second. </param>
        /// <param name="maxProvisionedBandwidthMiBPerSec"> The maximum provisioned bandwidth in mebibytes per second. </param>
        /// <returns> A new <see cref="Models.FileShareLimits"/> instance for mocking. </returns>
        public static FileShareLimits FileShareLimits(int? minProvisionedStorageGiB = default, int? maxProvisionedStorageGiB = default, int? minProvisionedIops = default, int? maxProvisionedIops = default, int? minProvisionedBandwidthMiBPerSec = default, int? maxProvisionedBandwidthMiBPerSec = default)
        {
            return FileShareLimits(minProvisionedStorageGiB, maxProvisionedStorageGiB, minProvisionedIops, maxProvisionedIops, minProvisionedBandwidthMiBPerSec, maxProvisionedBandwidthMiBPerSec, default, default);
        }

        /// <summary> Initializes a new instance of <see cref="Storage.StoragePrivateEndpointConnectionData"/> for mocking. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The resource system metadata. </param>
        /// <param name="connectionState"> The private link service connection state. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="privateEndpointId"> Retained for compatibility; this parameter was not used by the 1.8.0 factory. </param>
        /// <returns> A new <see cref="Storage.StoragePrivateEndpointConnectionData"/> instance for mocking. </returns>
        public static StoragePrivateEndpointConnectionData StoragePrivateEndpointConnectionData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, StoragePrivateLinkServiceConnectionState connectionState = default, StoragePrivateEndpointConnectionProvisioningState? provisioningState = default, string privateEndpointId = default)
        {
            return new StoragePrivateEndpointConnectionData(
                id,
                name,
                resourceType,
                systemData,
                connectionState is null && provisioningState is null ? default : new StoragePrivateEndpointConnectionProperties(default, connectionState, provisioningState, default),
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Storage.StorageAccountData"/> for mocking. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The resource system metadata. </param>
        /// <param name="tags"> The resource tags. </param>
        /// <param name="location"> The resource location. </param>
        /// <param name="provisioningState"> The account provisioning state. </param>
        /// <param name="primaryEndpoints"> The primary service endpoints. </param>
        /// <param name="primaryLocation"> The primary location. </param>
        /// <param name="statusOfPrimary"> The primary location status. </param>
        /// <param name="lastGeoFailoverOn"> The last geo-failover time. </param>
        /// <param name="secondaryLocation"> The secondary location. </param>
        /// <param name="statusOfSecondary"> The secondary location status. </param>
        /// <param name="createdOn"> The account creation time. </param>
        /// <param name="customDomain"> The custom domain. </param>
        /// <param name="sasPolicy"> The shared access signature policy. </param>
        /// <param name="keyCreationTime"> The key creation times. </param>
        /// <param name="secondaryEndpoints"> The secondary service endpoints. </param>
        /// <param name="encryption"> The encryption settings. </param>
        /// <param name="accessTier"> The access tier. </param>
        /// <param name="azureFilesIdentityBasedAuthentication"> The Azure Files identity-based authentication settings. </param>
        /// <param name="enableHttpsTrafficOnly"> Whether only HTTPS traffic is allowed. </param>
        /// <param name="networkRuleSet"> The network rule set. </param>
        /// <param name="isSftpEnabled"> Whether SFTP is enabled. </param>
        /// <param name="isLocalUserEnabled"> Whether local users are enabled. </param>
        /// <param name="isExtendedGroupEnabled"> Whether extended group support is enabled. </param>
        /// <param name="isHnsEnabled"> Whether hierarchical namespaces are enabled. </param>
        /// <param name="geoReplicationStats"> The geo-replication statistics. </param>
        /// <param name="isFailoverInProgress"> Whether a failover is in progress. </param>
        /// <param name="largeFileSharesState"> Whether large file shares are enabled. </param>
        /// <param name="privateEndpointConnections"> The private endpoint connections. </param>
        /// <param name="routingPreference"> The routing preference. </param>
        /// <param name="blobRestoreStatus"> The blob restore status. </param>
        /// <param name="allowBlobPublicAccess"> Whether public blob access is allowed. </param>
        /// <param name="minimumTlsVersion"> The minimum supported TLS version. </param>
        /// <param name="allowSharedKeyAccess"> Whether shared key access is allowed. </param>
        /// <param name="isNfsV3Enabled"> Whether NFS version 3 is enabled. </param>
        /// <param name="allowCrossTenantReplication"> Whether cross-tenant replication is allowed. </param>
        /// <param name="isDefaultToOAuthAuthentication"> Whether OAuth is the default authentication method. </param>
        /// <param name="publicNetworkAccess"> The public network access configuration. </param>
        /// <param name="immutableStorageWithVersioning"> The account-level immutability settings. </param>
        /// <param name="allowedCopyScope"> Restrictions on copying to and from the account. </param>
        /// <param name="storageAccountSkuConversionStatus"> The SKU conversion status. </param>
        /// <param name="dnsEndpointType"> The DNS endpoint type. </param>
        /// <param name="isSkuConversionBlocked"> Whether SKU conversion is blocked. </param>
        /// <param name="isAccountMigrationInProgress"> Whether account migration is in progress. </param>
        /// <param name="allowSharedKeyAccessForServices"> The shared key access settings for individual services. </param>
        /// <param name="dataCollaborationPolicyProperties"> The data collaboration policy. </param>
        /// <param name="keyExpirationPeriodInDays"> The key expiration period in days. </param>
        /// <param name="isIPv6EndpointToBePublished"> Whether IPv6 endpoints are published. </param>
        /// <param name="isBlobEnabled"> Whether Blob Geo Priority Replication is enabled. </param>
        /// <param name="sku"> The account SKU. </param>
        /// <param name="kind"> The account kind. </param>
        /// <param name="identity"> The account identity. </param>
        /// <param name="extendedLocation"> The extended location. </param>
        /// <param name="zones"> The availability zones. </param>
        /// <param name="zonePlacementPolicy"> The zone placement policy. </param>
        /// <returns> A new <see cref="Storage.StorageAccountData"/> instance for mocking. </returns>
        public static StorageAccountData StorageAccountData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, StorageAccountProvisioningState? provisioningState = default, StorageAccountEndpoints primaryEndpoints = default, AzureLocation? primaryLocation = default, StorageAccountStatus? statusOfPrimary = default, DateTimeOffset? lastGeoFailoverOn = default, AzureLocation? secondaryLocation = default, StorageAccountStatus? statusOfSecondary = default, DateTimeOffset? createdOn = default, StorageCustomDomain customDomain = default, StorageAccountSasPolicy sasPolicy = default, StorageAccountKeyCreationTime keyCreationTime = default, StorageAccountEndpoints secondaryEndpoints = default, StorageAccountEncryption encryption = default, StorageAccountAccessTier? accessTier = default, FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication = default, bool? enableHttpsTrafficOnly = default, StorageAccountNetworkRuleSet networkRuleSet = default, bool? isSftpEnabled = default, bool? isLocalUserEnabled = default, bool? isExtendedGroupEnabled = default, bool? isHnsEnabled = default, GeoReplicationStatistics geoReplicationStats = default, bool? isFailoverInProgress = default, LargeFileSharesState? largeFileSharesState = default, IEnumerable<StoragePrivateEndpointConnectionData> privateEndpointConnections = default, StorageRoutingPreference routingPreference = default, BlobRestoreStatus blobRestoreStatus = default, bool? allowBlobPublicAccess = default, StorageMinimumTlsVersion? minimumTlsVersion = default, bool? allowSharedKeyAccess = default, bool? isNfsV3Enabled = default, bool? allowCrossTenantReplication = default, bool? isDefaultToOAuthAuthentication = default, StoragePublicNetworkAccess? publicNetworkAccess = default, ImmutableStorageAccount immutableStorageWithVersioning = default, AllowedCopyScope? allowedCopyScope = default, StorageAccountSkuConversionStatus storageAccountSkuConversionStatus = default, StorageDnsEndpointType? dnsEndpointType = default, bool? isSkuConversionBlocked = default, bool? isAccountMigrationInProgress = default, StorageAccountSharedKeyAccessProperties allowSharedKeyAccessForServices = default, StorageDataCollaborationPolicyProperties dataCollaborationPolicyProperties = default, int? keyExpirationPeriodInDays = default, bool? isIPv6EndpointToBePublished = default, bool? isBlobEnabled = default, StorageSku sku = default, StorageKind? kind = default, ManagedServiceIdentity identity = default, ExtendedLocation extendedLocation = default, IEnumerable<string> zones = default, StorageAccountZonePlacementPolicy? zonePlacementPolicy = default)
        {
            return StorageAccountData(
                id, name, resourceType, systemData, tags, location, provisioningState,
                primaryEndpoints, primaryLocation, statusOfPrimary, lastGeoFailoverOn,
                secondaryLocation, statusOfSecondary, createdOn, customDomain, sasPolicy,
                keyCreationTime, secondaryEndpoints, encryption, accessTier,
                turboTier: default,
                azureFilesIdentityBasedAuthentication: azureFilesIdentityBasedAuthentication,
                enableHttpsTrafficOnly: enableHttpsTrafficOnly,
                networkRuleSet: networkRuleSet,
                isSftpEnabled: isSftpEnabled,
                isLocalUserEnabled: isLocalUserEnabled,
                isExtendedGroupEnabled: isExtendedGroupEnabled,
                isHnsEnabled: isHnsEnabled,
                geoReplicationStats: geoReplicationStats,
                isFailoverInProgress: isFailoverInProgress,
                largeFileSharesState: largeFileSharesState,
                privateEndpointConnections: privateEndpointConnections,
                routingPreference: routingPreference,
                blobRestoreStatus: blobRestoreStatus,
                allowBlobPublicAccess: allowBlobPublicAccess,
                minimumTlsVersion: minimumTlsVersion,
                allowSharedKeyAccess: allowSharedKeyAccess,
                isNfsV3Enabled: isNfsV3Enabled,
                allowCrossTenantReplication: allowCrossTenantReplication,
                isDefaultToOAuthAuthentication: isDefaultToOAuthAuthentication,
                publicNetworkAccess: publicNetworkAccess,
                immutableStorageWithVersioning: immutableStorageWithVersioning,
                allowedCopyScope: allowedCopyScope,
                storageAccountSkuConversionStatus: storageAccountSkuConversionStatus,
                dnsEndpointType: dnsEndpointType,
                isSkuConversionBlocked: isSkuConversionBlocked,
                isAccountMigrationInProgress: isAccountMigrationInProgress,
                allowSharedKeyAccessForServices: allowSharedKeyAccessForServices,
                dataCollaborationPolicyProperties: dataCollaborationPolicyProperties,
                allowCrossTenantDelegationSas: default,
                keyExpirationPeriodInDays: keyExpirationPeriodInDays,
                isIPv6EndpointToBePublished: isIPv6EndpointToBePublished,
                isBlobEnabled: isBlobEnabled,
                sku: sku,
                kind: kind,
                identity: identity,
                extendedLocation: extendedLocation,
                zones: zones,
                zonePlacementPolicy: zonePlacementPolicy);
        }

        /// <summary> Initializes a new instance of <see cref="Models.StorageAccountCreateOrUpdateContent"/> for mocking. </summary>
        /// <param name="sku"> The storage account SKU. </param>
        /// <param name="kind"> The storage account kind. </param>
        /// <param name="location"> The resource location. </param>
        /// <param name="extendedLocation"> The extended location of the resource. </param>
        /// <param name="zones"> The availability zones. </param>
        /// <param name="zonePlacementPolicy"> The zone placement policy. </param>
        /// <param name="tags"> The resource tags. </param>
        /// <param name="identity"> The identity of the resource. </param>
        /// <param name="allowedCopyScope"> Restrictions on copying to and from the account. </param>
        /// <param name="publicNetworkAccess"> The public network access configuration. </param>
        /// <param name="sasPolicy"> The shared access signature policy. </param>
        /// <param name="customDomain"> The custom domain assigned to the account. </param>
        /// <param name="encryption"> The storage account encryption settings. </param>
        /// <param name="networkRuleSet"> The network rule set. </param>
        /// <param name="accessTier"> The storage account access tier. </param>
        /// <param name="azureFilesIdentityBasedAuthentication"> The Azure Files identity-based authentication settings. </param>
        /// <param name="enableHttpsTrafficOnly"> Whether only HTTPS traffic is allowed. </param>
        /// <param name="isSftpEnabled"> Whether SFTP is enabled. </param>
        /// <param name="isLocalUserEnabled"> Whether local users are enabled. </param>
        /// <param name="isExtendedGroupEnabled"> Whether extended group support is enabled. </param>
        /// <param name="isHnsEnabled"> Whether hierarchical namespaces are enabled. </param>
        /// <param name="largeFileSharesState"> Whether large file shares are enabled. </param>
        /// <param name="routingPreference"> The routing preference. </param>
        /// <param name="allowBlobPublicAccess"> Whether public blob access is allowed. </param>
        /// <param name="minimumTlsVersion"> The minimum supported TLS version. </param>
        /// <param name="allowSharedKeyAccess"> Whether shared key access is allowed. </param>
        /// <param name="isNfsV3Enabled"> Whether NFS version 3 is enabled. </param>
        /// <param name="allowCrossTenantReplication"> Whether cross-tenant replication is allowed. </param>
        /// <param name="isDefaultToOAuthAuthentication"> Whether OAuth is the default authentication method. </param>
        /// <param name="immutableStorageWithVersioning"> The account-level immutability settings. </param>
        /// <param name="dnsEndpointType"> The DNS endpoint type. </param>
        /// <param name="allowSharedKeyAccessForServices"> The shared key access settings for individual services. </param>
        /// <param name="dataCollaborationPolicyProperties"> The data collaboration policy. </param>
        /// <param name="keyExpirationPeriodInDays"> The key expiration period in days. </param>
        /// <param name="isIPv6EndpointToBePublished"> Whether IPv6 endpoints are published. </param>
        /// <param name="isBlobEnabled"> Whether Blob Geo Priority Replication is enabled. </param>
        /// <param name="turboTier"> The Turbo Tier configuration. </param>
        /// <param name="allowCrossTenantDelegationSas"> Whether cross-tenant user delegation SAS is allowed. </param>
        /// <returns> A new <see cref="Models.StorageAccountCreateOrUpdateContent"/> instance for mocking. </returns>
        public static StorageAccountCreateOrUpdateContent StorageAccountCreateOrUpdateContent(StorageSku sku = default, StorageKind kind = default, AzureLocation location = default, ExtendedLocation extendedLocation = default, IEnumerable<string> zones = default, StorageAccountZonePlacementPolicy? zonePlacementPolicy = default, IDictionary<string, string> tags = default, ManagedServiceIdentity identity = default, AllowedCopyScope? allowedCopyScope = default, StoragePublicNetworkAccess? publicNetworkAccess = default, StorageAccountSasPolicy sasPolicy = default, StorageCustomDomain customDomain = default, StorageAccountEncryption encryption = default, StorageAccountNetworkRuleSet networkRuleSet = default, StorageAccountAccessTier? accessTier = default, FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication = default, bool? enableHttpsTrafficOnly = default, bool? isSftpEnabled = default, bool? isLocalUserEnabled = default, bool? isExtendedGroupEnabled = default, bool? isHnsEnabled = default, LargeFileSharesState? largeFileSharesState = default, StorageRoutingPreference routingPreference = default, bool? allowBlobPublicAccess = default, StorageMinimumTlsVersion? minimumTlsVersion = default, bool? allowSharedKeyAccess = default, bool? isNfsV3Enabled = default, bool? allowCrossTenantReplication = default, bool? isDefaultToOAuthAuthentication = default, ImmutableStorageAccount immutableStorageWithVersioning = default, StorageDnsEndpointType? dnsEndpointType = default, StorageAccountSharedKeyAccessProperties allowSharedKeyAccessForServices = default, StorageDataCollaborationPolicyProperties dataCollaborationPolicyProperties = default, int? keyExpirationPeriodInDays = default, bool? isIPv6EndpointToBePublished = default, bool? isBlobEnabled = default, TurboTier turboTier = default, bool? allowCrossTenantDelegationSas = default)
        {
            zones ??= new ChangeTrackingList<string>();
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new StorageAccountCreateOrUpdateContent(
                sku,
                kind,
                location,
                extendedLocation,
                zones.ToList(),
                zonePlacementPolicy is null ? default : new Placement(zonePlacementPolicy, default),
                tags,
                identity,
                allowedCopyScope is null && publicNetworkAccess is null && sasPolicy is null && keyExpirationPeriodInDays is null && customDomain is null && encryption is null && networkRuleSet is null && accessTier is null && turboTier is null && azureFilesIdentityBasedAuthentication is null && enableHttpsTrafficOnly is null && isSftpEnabled is null && isLocalUserEnabled is null && isExtendedGroupEnabled is null && isHnsEnabled is null && largeFileSharesState is null && routingPreference is null && isIPv6EndpointToBePublished is null && allowBlobPublicAccess is null && minimumTlsVersion is null && allowSharedKeyAccess is null && isNfsV3Enabled is null && allowCrossTenantReplication is null && isDefaultToOAuthAuthentication is null && immutableStorageWithVersioning is null && dnsEndpointType is null && isBlobEnabled is null && allowSharedKeyAccessForServices is null && dataCollaborationPolicyProperties is null && allowCrossTenantDelegationSas is null ? default : new StorageAccountPropertiesCreateParameters(
                    allowedCopyScope,
                    publicNetworkAccess,
                    sasPolicy,
                    keyExpirationPeriodInDays is null ? default : new KeyPolicy(keyExpirationPeriodInDays.GetValueOrDefault(), default),
                    customDomain,
                    encryption,
                    networkRuleSet,
                    accessTier,
                    turboTier,
                    azureFilesIdentityBasedAuthentication,
                    enableHttpsTrafficOnly,
                    isSftpEnabled,
                    isLocalUserEnabled,
                    isExtendedGroupEnabled,
                    isHnsEnabled,
                    largeFileSharesState,
                    routingPreference,
                    isIPv6EndpointToBePublished is null ? default : new DualStackEndpointPreference(isIPv6EndpointToBePublished, default),
                    allowBlobPublicAccess,
                    minimumTlsVersion,
                    allowSharedKeyAccess,
                    isNfsV3Enabled,
                    allowCrossTenantReplication,
                    isDefaultToOAuthAuthentication,
                    immutableStorageWithVersioning,
                    dnsEndpointType,
                    isBlobEnabled is null ? default : new GeoPriorityReplicationStatus(isBlobEnabled, default),
                    allowSharedKeyAccessForServices,
                    dataCollaborationPolicyProperties,
                    allowCrossTenantDelegationSas,
                    default),
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.StorageAccountPatch"/> for mocking. </summary>
        /// <param name="sku"> The storage account SKU. </param>
        /// <param name="tags"> The resource tags. </param>
        /// <param name="identity"> The identity of the resource. </param>
        /// <param name="customDomain"> The custom domain assigned to the account. </param>
        /// <param name="encryption"> The storage account encryption settings. </param>
        /// <param name="sasPolicy"> The shared access signature policy. </param>
        /// <param name="accessTier"> The storage account access tier. </param>
        /// <param name="azureFilesIdentityBasedAuthentication"> The Azure Files identity-based authentication settings. </param>
        /// <param name="enableHttpsTrafficOnly"> Whether only HTTPS traffic is allowed. </param>
        /// <param name="isSftpEnabled"> Whether SFTP is enabled. </param>
        /// <param name="isLocalUserEnabled"> Whether local users are enabled. </param>
        /// <param name="isExtendedGroupEnabled"> Whether extended group support is enabled. </param>
        /// <param name="networkRuleSet"> The network rule set. </param>
        /// <param name="largeFileSharesState"> Whether large file shares are enabled. </param>
        /// <param name="routingPreference"> The routing preference. </param>
        /// <param name="allowBlobPublicAccess"> Whether public blob access is allowed. </param>
        /// <param name="minimumTlsVersion"> The minimum supported TLS version. </param>
        /// <param name="allowSharedKeyAccess"> Whether shared key access is allowed. </param>
        /// <param name="allowCrossTenantReplication"> Whether cross-tenant replication is allowed. </param>
        /// <param name="isDefaultToOAuthAuthentication"> Whether OAuth is the default authentication method. </param>
        /// <param name="publicNetworkAccess"> The public network access configuration. </param>
        /// <param name="immutableStorageWithVersioning"> The account-level immutability settings. </param>
        /// <param name="allowedCopyScope"> Restrictions on copying to and from the account. </param>
        /// <param name="dnsEndpointType"> The DNS endpoint type. </param>
        /// <param name="allowSharedKeyAccessForServices"> The shared key access settings for individual services. </param>
        /// <param name="dataCollaborationPolicyProperties"> The data collaboration policy. </param>
        /// <param name="keyExpirationPeriodInDays"> The key expiration period in days. </param>
        /// <param name="isIPv6EndpointToBePublished"> Whether IPv6 endpoints are published. </param>
        /// <param name="isBlobEnabled"> Whether Blob Geo Priority Replication is enabled. </param>
        /// <param name="kind"> The storage account kind. </param>
        /// <param name="zones"> The availability zones. </param>
        /// <param name="zonePlacementPolicy"> The zone placement policy. </param>
        /// <param name="turboTier"> The Turbo Tier configuration. </param>
        /// <param name="allowCrossTenantDelegationSas"> Whether cross-tenant user delegation SAS is allowed. </param>
        /// <returns> A new <see cref="Models.StorageAccountPatch"/> instance for mocking. </returns>
        public static StorageAccountPatch StorageAccountPatch(StorageSku sku = default, IDictionary<string, string> tags = default, ManagedServiceIdentity identity = default, StorageCustomDomain customDomain = default, StorageAccountEncryption encryption = default, StorageAccountSasPolicy sasPolicy = default, StorageAccountAccessTier? accessTier = default, FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication = default, bool? enableHttpsTrafficOnly = default, bool? isSftpEnabled = default, bool? isLocalUserEnabled = default, bool? isExtendedGroupEnabled = default, StorageAccountNetworkRuleSet networkRuleSet = default, LargeFileSharesState? largeFileSharesState = default, StorageRoutingPreference routingPreference = default, bool? allowBlobPublicAccess = default, StorageMinimumTlsVersion? minimumTlsVersion = default, bool? allowSharedKeyAccess = default, bool? allowCrossTenantReplication = default, bool? isDefaultToOAuthAuthentication = default, StoragePublicNetworkAccess? publicNetworkAccess = default, ImmutableStorageAccount immutableStorageWithVersioning = default, AllowedCopyScope? allowedCopyScope = default, StorageDnsEndpointType? dnsEndpointType = default, StorageAccountSharedKeyAccessProperties allowSharedKeyAccessForServices = default, StorageDataCollaborationPolicyProperties dataCollaborationPolicyProperties = default, int? keyExpirationPeriodInDays = default, bool? isIPv6EndpointToBePublished = default, bool? isBlobEnabled = default, StorageKind? kind = default, IEnumerable<string> zones = default, StorageAccountZonePlacementPolicy? zonePlacementPolicy = default, TurboTier turboTier = default, bool? allowCrossTenantDelegationSas = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();
            zones ??= new ChangeTrackingList<string>();

            return new StorageAccountPatch(
                sku,
                tags,
                identity,
                customDomain is null && encryption is null && sasPolicy is null && keyExpirationPeriodInDays is null && accessTier is null && turboTier is null && azureFilesIdentityBasedAuthentication is null && enableHttpsTrafficOnly is null && isSftpEnabled is null && isLocalUserEnabled is null && isExtendedGroupEnabled is null && networkRuleSet is null && largeFileSharesState is null && routingPreference is null && isIPv6EndpointToBePublished is null && allowBlobPublicAccess is null && minimumTlsVersion is null && allowSharedKeyAccess is null && allowCrossTenantReplication is null && isDefaultToOAuthAuthentication is null && publicNetworkAccess is null && immutableStorageWithVersioning is null && allowedCopyScope is null && dnsEndpointType is null && isBlobEnabled is null && allowSharedKeyAccessForServices is null && dataCollaborationPolicyProperties is null && allowCrossTenantDelegationSas is null ? default : new StorageAccountPropertiesUpdateParameters(
                    customDomain,
                    encryption,
                    sasPolicy,
                    keyExpirationPeriodInDays is null ? default : new KeyPolicy(keyExpirationPeriodInDays.GetValueOrDefault(), default),
                    accessTier,
                    turboTier,
                    azureFilesIdentityBasedAuthentication,
                    enableHttpsTrafficOnly,
                    isSftpEnabled,
                    isLocalUserEnabled,
                    isExtendedGroupEnabled,
                    networkRuleSet,
                    largeFileSharesState,
                    routingPreference,
                    isIPv6EndpointToBePublished is null ? default : new DualStackEndpointPreference(isIPv6EndpointToBePublished, default),
                    allowBlobPublicAccess,
                    minimumTlsVersion,
                    allowSharedKeyAccess,
                    allowCrossTenantReplication,
                    isDefaultToOAuthAuthentication,
                    publicNetworkAccess,
                    immutableStorageWithVersioning,
                    allowedCopyScope,
                    dnsEndpointType,
                    isBlobEnabled is null ? default : new GeoPriorityReplicationStatus(isBlobEnabled, default),
                    allowSharedKeyAccessForServices,
                    dataCollaborationPolicyProperties,
                    allowCrossTenantDelegationSas,
                    default),
                kind,
                zones.ToList(),
                zonePlacementPolicy is null ? default : new Placement(zonePlacementPolicy, default),
                default);
        }

        /// <summary> Initializes a new instance of <see cref="StorageTableAccessPolicy" />. </summary>
        /// <param name="startOn"> Start time of the access policy. </param>
        /// <param name="expireOn"> Expiry time of the access policy. </param>
        /// <param name="permission"> Required. List of abbreviated permissions. Supported permission values include 'r','a','u','d'. </param>
        /// <returns> A new <see cref="StorageTableAccessPolicy" /> instance for mocking. </returns>
        public static StorageTableAccessPolicy StorageTableAccessPolicy(DateTimeOffset? startOn = default, DateTimeOffset? expireOn = default, string permission = default)
            => new StorageTableAccessPolicy(startOn, expireOn, permission, default);

        /// <summary> Initializes a new instance of StorageTaskAssignmentPatchProperties (backward-compat overload). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageTaskAssignmentPatchProperties StorageTaskAssignmentPatchProperties(string taskId, bool? isEnabled, string description, StorageTaskAssignmentUpdateExecutionContext executionContext, string reportPrefix, StorageProvisioningState? provisioningState, StorageTaskReportProperties runStatus)
        {
            return new StorageTaskAssignmentPatchProperties(
                taskId,
                isEnabled,
                description,
                executionContext,
                reportPrefix != null ? new StorageTaskAssignmentUpdateReport { Prefix = reportPrefix } : null,
                provisioningState,
                runStatus,
                additionalBinaryDataProperties: null);
        }
        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.Storage.StorageAccountData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> Gets the SKU. </param>
        /// <param name="kind"> Gets the Kind. </param>
        /// <param name="identity"> The identity of the resource. </param>
        /// <param name="extendedLocation"> The extendedLocation of the resource. </param>
        /// <param name="provisioningState"> Gets the status of the storage account at the time the operation was called. </param>
        /// <param name="primaryEndpoints"> Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object. Note that Standard_ZRS and Premium_LRS accounts only return the blob endpoint. </param>
        /// <param name="primaryLocation"> Gets the location of the primary data center for the storage account. </param>
        /// <param name="statusOfPrimary"> Gets the status indicating whether the primary location of the storage account is available or unavailable. </param>
        /// <param name="lastGeoFailoverOn"> Gets the timestamp of the most recent instance of a failover to the secondary location. Only the most recent timestamp is retained. This element is not returned if there has never been a failover instance. Only available if the accountType is Standard_GRS or Standard_RAGRS. </param>
        /// <param name="secondaryLocation"> Gets the location of the geo-replicated secondary for the storage account. Only available if the accountType is Standard_GRS or Standard_RAGRS. </param>
        /// <param name="statusOfSecondary"> Gets the status indicating whether the secondary location of the storage account is available or unavailable. Only available if the SKU name is Standard_GRS or Standard_RAGRS. </param>
        /// <param name="createdOn"> Gets the creation date and time of the storage account in UTC. </param>
        /// <param name="customDomain"> Gets the custom domain the user assigned to this storage account. </param>
        /// <param name="sasPolicy"> SasPolicy assigned to the storage account. </param>
        /// <param name="keyExpirationPeriodInDays"> KeyPolicy assigned to the storage account. </param>
        /// <param name="keyCreationTime"> Storage account keys creation time. </param>
        /// <param name="secondaryEndpoints"> Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object from the secondary location of the storage account. Only available if the SKU name is Standard_RAGRS. </param>
        /// <param name="encryption"> Encryption settings to be used for server-side encryption for the storage account. </param>
        /// <param name="accessTier"> Required for storage accounts where kind = BlobStorage. The access tier is used for billing. The 'Premium' access tier is the default value for premium block blobs storage account type and it cannot be changed for the premium block blobs storage account type. </param>
        /// <param name="azureFilesIdentityBasedAuthentication"> Provides the identity based authentication settings for Azure Files. </param>
        /// <param name="enableHttpsTrafficOnly"> Allows https traffic only to storage service if sets to true. </param>
        /// <param name="networkRuleSet"> Network rule set. </param>
        /// <param name="isSftpEnabled"> Enables Secure File Transfer Protocol, if set to true. </param>
        /// <param name="isLocalUserEnabled"> Enables local users feature, if set to true. </param>
        /// <param name="isHnsEnabled"> Account HierarchicalNamespace enabled if sets to true. </param>
        /// <param name="geoReplicationStats"> Geo Replication Stats. </param>
        /// <param name="isFailoverInProgress"> If the failover is in progress, the value will be true, otherwise, it will be null. </param>
        /// <param name="largeFileSharesState"> Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connection associated with the specified storage account. </param>
        /// <param name="routingPreference"> Maintains information about the network routing choice opted by the user for data transfer. </param>
        /// <param name="blobRestoreStatus"> Blob restore status. </param>
        /// <param name="allowBlobPublicAccess"> Allow or disallow public access to all blobs or containers in the storage account. The default interpretation is true for this property. </param>
        /// <param name="minimumTlsVersion"> Set the minimum TLS version to be permitted on requests to storage. The default interpretation is TLS 1.0 for this property. </param>
        /// <param name="allowSharedKeyAccess"> Indicates whether the storage account permits requests to be authorized with the account access key via Shared Key. If false, then all requests, including shared access signatures, must be authorized with Azure Active Directory (Azure AD). The default value is null, which is equivalent to true. </param>
        /// <param name="isNfsV3Enabled"> NFS 3.0 protocol support enabled if set to true. </param>
        /// <param name="allowCrossTenantReplication"> Allow or disallow cross AAD tenant object replication. The default interpretation is true for this property. </param>
        /// <param name="isDefaultToOAuthAuthentication"> A boolean flag which indicates whether the default authentication is OAuth or not. The default interpretation is false for this property. </param>
        /// <param name="publicNetworkAccess"> Allow or disallow public network access to Storage Account. Value is optional but if passed in, must be 'Enabled' or 'Disabled'. </param>
        /// <param name="immutableStorageWithVersioning"> The property is immutable and can only be set to true at the account creation time. When set to true, it enables object level immutability for all the containers in the account by default. </param>
        /// <param name="allowedCopyScope"> Restrict copy to and from Storage Accounts within an AAD tenant or with Private Links to the same VNet. </param>
        /// <param name="storageAccountSkuConversionStatus"> This property is readOnly and is set by server during asynchronous storage account sku conversion operations. </param>
        /// <param name="dnsEndpointType"> Allows you to specify the type of endpoint. Set this to AzureDNSZone to create a large number of accounts in a single subscription, which creates accounts in an Azure DNS Zone and the endpoint URL will have an alphanumeric DNS Zone identifier. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.Storage.StorageAccountData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageAccountData StorageAccountData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, StorageSku sku, StorageKind? kind, ManagedServiceIdentity identity, Resources.Models.ExtendedLocation extendedLocation, StorageProvisioningState? provisioningState, StorageAccountEndpoints primaryEndpoints, AzureLocation? primaryLocation, StorageAccountStatus? statusOfPrimary, DateTimeOffset? lastGeoFailoverOn, AzureLocation? secondaryLocation, StorageAccountStatus? statusOfSecondary, DateTimeOffset? createdOn, StorageCustomDomain customDomain, StorageAccountSasPolicy sasPolicy, int? keyExpirationPeriodInDays, StorageAccountKeyCreationTime keyCreationTime, StorageAccountEndpoints secondaryEndpoints, StorageAccountEncryption encryption, StorageAccountAccessTier? accessTier, FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication, bool? enableHttpsTrafficOnly, StorageAccountNetworkRuleSet networkRuleSet, bool? isSftpEnabled, bool? isLocalUserEnabled, bool? isHnsEnabled, GeoReplicationStatistics geoReplicationStats, bool? isFailoverInProgress, LargeFileSharesState? largeFileSharesState, IEnumerable<StoragePrivateEndpointConnectionData> privateEndpointConnections, StorageRoutingPreference routingPreference, BlobRestoreStatus blobRestoreStatus, bool? allowBlobPublicAccess, StorageMinimumTlsVersion? minimumTlsVersion, bool? allowSharedKeyAccess, bool? isNfsV3Enabled, bool? allowCrossTenantReplication, bool? isDefaultToOAuthAuthentication, StoragePublicNetworkAccess? publicNetworkAccess, ImmutableStorageAccount immutableStorageWithVersioning, AllowedCopyScope? allowedCopyScope, StorageAccountSkuConversionStatus storageAccountSkuConversionStatus, StorageDnsEndpointType? dnsEndpointType)
            => StorageAccountData(id, name, resourceType, systemData, tags, location, sku, kind, identity, extendedLocation, provisioningState, primaryEndpoints, primaryLocation, statusOfPrimary, lastGeoFailoverOn, secondaryLocation, statusOfSecondary, createdOn, customDomain, sasPolicy, keyExpirationPeriodInDays, keyCreationTime, secondaryEndpoints, encryption, accessTier, azureFilesIdentityBasedAuthentication, enableHttpsTrafficOnly, networkRuleSet, isSftpEnabled, isLocalUserEnabled, default, isHnsEnabled, geoReplicationStats, isFailoverInProgress, largeFileSharesState, privateEndpointConnections, routingPreference, blobRestoreStatus, allowBlobPublicAccess, minimumTlsVersion, allowSharedKeyAccess, isNfsV3Enabled, allowCrossTenantReplication, isDefaultToOAuthAuthentication, publicNetworkAccess, immutableStorageWithVersioning, allowedCopyScope, storageAccountSkuConversionStatus, dnsEndpointType, default, default);

        /// <summary> Initializes a new instance of <see cref="Storage.StorageAccountData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> Gets the SKU. </param>
        /// <param name="kind"> Gets the Kind. </param>
        /// <param name="identity"> The identity of the resource. </param>
        /// <param name="extendedLocation"> The extendedLocation of the resource. </param>
        /// <param name="provisioningState"> Gets the status of the storage account at the time the operation was called. </param>
        /// <param name="primaryEndpoints"> Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object. Note that Standard_ZRS and Premium_LRS accounts only return the blob endpoint. </param>
        /// <param name="primaryLocation"> Gets the location of the primary data center for the storage account. </param>
        /// <param name="statusOfPrimary"> Gets the status indicating whether the primary location of the storage account is available or unavailable. </param>
        /// <param name="lastGeoFailoverOn"> Gets the timestamp of the most recent instance of a failover to the secondary location. Only the most recent timestamp is retained. This element is not returned if there has never been a failover instance. Only available if the accountType is Standard_GRS or Standard_RAGRS. </param>
        /// <param name="secondaryLocation"> Gets the location of the geo-replicated secondary for the storage account. Only available if the accountType is Standard_GRS or Standard_RAGRS. </param>
        /// <param name="statusOfSecondary"> Gets the status indicating whether the secondary location of the storage account is available or unavailable. Only available if the SKU name is Standard_GRS or Standard_RAGRS. </param>
        /// <param name="createdOn"> Gets the creation date and time of the storage account in UTC. </param>
        /// <param name="customDomain"> Gets the custom domain the user assigned to this storage account. </param>
        /// <param name="sasPolicy"> SasPolicy assigned to the storage account. </param>
        /// <param name="keyExpirationPeriodInDays"> KeyPolicy assigned to the storage account. </param>
        /// <param name="keyCreationTime"> Storage account keys creation time. </param>
        /// <param name="secondaryEndpoints"> Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object from the secondary location of the storage account. Only available if the SKU name is Standard_RAGRS. </param>
        /// <param name="encryption"> Encryption settings to be used for server-side encryption for the storage account. </param>
        /// <param name="accessTier"> Required for storage accounts where kind = BlobStorage. The access tier is used for billing. The 'Premium' access tier is the default value for premium block blobs storage account type and it cannot be changed for the premium block blobs storage account type. </param>
        /// <param name="azureFilesIdentityBasedAuthentication"> Provides the identity based authentication settings for Azure Files. </param>
        /// <param name="enableHttpsTrafficOnly"> Allows https traffic only to storage service if sets to true. </param>
        /// <param name="networkRuleSet"> Network rule set. </param>
        /// <param name="isSftpEnabled"> Enables Secure File Transfer Protocol, if set to true. </param>
        /// <param name="isLocalUserEnabled"> Enables local users feature, if set to true. </param>
        /// <param name="isExtendedGroupEnabled"> Enables extended group support with local users feature, if set to true. </param>
        /// <param name="isHnsEnabled"> Account HierarchicalNamespace enabled if sets to true. </param>
        /// <param name="geoReplicationStats"> Geo Replication Stats. </param>
        /// <param name="isFailoverInProgress"> If the failover is in progress, the value will be true, otherwise, it will be null. </param>
        /// <param name="largeFileSharesState"> Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connection associated with the specified storage account. </param>
        /// <param name="routingPreference"> Maintains information about the network routing choice opted by the user for data transfer. </param>
        /// <param name="blobRestoreStatus"> Blob restore status. </param>
        /// <param name="allowBlobPublicAccess"> Allow or disallow public access to all blobs or containers in the storage account. The default interpretation is false for this property. </param>
        /// <param name="minimumTlsVersion"> Set the minimum TLS version to be permitted on requests to storage. The default interpretation is TLS 1.0 for this property. </param>
        /// <param name="allowSharedKeyAccess"> Indicates whether the storage account permits requests to be authorized with the account access key via Shared Key. If false, then all requests, including shared access signatures, must be authorized with Azure Active Directory (Azure AD). The default value is null, which is equivalent to true. </param>
        /// <param name="isNfsV3Enabled"> NFS 3.0 protocol support enabled if set to true. </param>
        /// <param name="allowCrossTenantReplication"> Allow or disallow cross AAD tenant object replication. Set this property to true for new or existing accounts only if object replication policies will involve storage accounts in different AAD tenants. The default interpretation is false for new accounts to follow best security practices by default. </param>
        /// <param name="isDefaultToOAuthAuthentication"> A boolean flag which indicates whether the default authentication is OAuth or not. The default interpretation is false for this property. </param>
        /// <param name="publicNetworkAccess"> Allow, disallow, or let Network Security Perimeter configuration to evaluate public network access to Storage Account. </param>
        /// <param name="immutableStorageWithVersioning"> The property is immutable and can only be set to true at the account creation time. When set to true, it enables object level immutability for all the containers in the account by default. </param>
        /// <param name="allowedCopyScope"> Restrict copy to and from Storage Accounts within an AAD tenant or with Private Links to the same VNet. </param>
        /// <param name="storageAccountSkuConversionStatus"> This property is readOnly and is set by server during asynchronous storage account sku conversion operations. </param>
        /// <param name="dnsEndpointType"> Allows you to specify the type of endpoint. Set this to AzureDNSZone to create a large number of accounts in a single subscription, which creates accounts in an Azure DNS Zone and the endpoint URL will have an alphanumeric DNS Zone identifier. </param>
        /// <param name="isSkuConversionBlocked"> This property will be set to true or false on an event of ongoing migration. Default value is null. </param>
        /// <param name="isAccountMigrationInProgress"> If customer initiated account migration is in progress, the value will be true else it will be null. </param>
        /// <returns> A new <see cref="Storage.StorageAccountData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageAccountData StorageAccountData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, StorageSku sku, StorageKind? kind, ManagedServiceIdentity identity, Resources.Models.ExtendedLocation extendedLocation, StorageProvisioningState? provisioningState, StorageAccountEndpoints primaryEndpoints, AzureLocation? primaryLocation, StorageAccountStatus? statusOfPrimary, DateTimeOffset? lastGeoFailoverOn, AzureLocation? secondaryLocation, StorageAccountStatus? statusOfSecondary, DateTimeOffset? createdOn, StorageCustomDomain customDomain, StorageAccountSasPolicy sasPolicy, int? keyExpirationPeriodInDays, StorageAccountKeyCreationTime keyCreationTime, StorageAccountEndpoints secondaryEndpoints, StorageAccountEncryption encryption, StorageAccountAccessTier? accessTier, FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication, bool? enableHttpsTrafficOnly, StorageAccountNetworkRuleSet networkRuleSet, bool? isSftpEnabled, bool? isLocalUserEnabled, bool? isExtendedGroupEnabled, bool? isHnsEnabled, GeoReplicationStatistics geoReplicationStats, bool? isFailoverInProgress, LargeFileSharesState? largeFileSharesState, IEnumerable<StoragePrivateEndpointConnectionData> privateEndpointConnections, StorageRoutingPreference routingPreference, BlobRestoreStatus blobRestoreStatus, bool? allowBlobPublicAccess, StorageMinimumTlsVersion? minimumTlsVersion, bool? allowSharedKeyAccess, bool? isNfsV3Enabled, bool? allowCrossTenantReplication, bool? isDefaultToOAuthAuthentication, StoragePublicNetworkAccess? publicNetworkAccess, ImmutableStorageAccount immutableStorageWithVersioning, AllowedCopyScope? allowedCopyScope, StorageAccountSkuConversionStatus storageAccountSkuConversionStatus, StorageDnsEndpointType? dnsEndpointType, bool? isSkuConversionBlocked, bool? isAccountMigrationInProgress)
            => StorageAccountData(id, name, resourceType, systemData, tags, location, sku, kind, identity, extendedLocation, ToAccountProvisioningState(provisioningState), primaryEndpoints, primaryLocation, statusOfPrimary, lastGeoFailoverOn, secondaryLocation, statusOfSecondary, createdOn, customDomain, sasPolicy, keyExpirationPeriodInDays, keyCreationTime, secondaryEndpoints, encryption, accessTier, azureFilesIdentityBasedAuthentication, enableHttpsTrafficOnly, networkRuleSet, isSftpEnabled, isLocalUserEnabled, isExtendedGroupEnabled, isHnsEnabled, geoReplicationStats, isFailoverInProgress, largeFileSharesState, privateEndpointConnections, routingPreference, blobRestoreStatus, allowBlobPublicAccess, minimumTlsVersion, allowSharedKeyAccess, isNfsV3Enabled, allowCrossTenantReplication, isDefaultToOAuthAuthentication, publicNetworkAccess, immutableStorageWithVersioning, allowedCopyScope, storageAccountSkuConversionStatus, dnsEndpointType, isSkuConversionBlocked, isAccountMigrationInProgress);

        /// <summary> Initializes a new instance of <see cref="Models.StorageTaskAssignmentProperties"/>. </summary>
        /// <param name="taskId"> Id of the corresponding storage task. </param>
        /// <param name="isEnabled"> Whether the storage task assignment is enabled or not. </param>
        /// <param name="description"> Text that describes the purpose of the storage task assignment. </param>
        /// <param name="executionContext"> The storage task assignment execution context. </param>
        /// <param name="reportPrefix"> The storage task assignment report. </param>
        /// <param name="provisioningState"> Represents the provisioning state of the storage task assignment. </param>
        /// <param name="runStatus"> Run status of storage task assignment. </param>
        /// <returns> A new <see cref="Models.StorageTaskAssignmentProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageTaskAssignmentProperties StorageTaskAssignmentProperties(ResourceIdentifier taskId, bool isEnabled, string description, StorageTaskAssignmentExecutionContext executionContext, string reportPrefix, StorageProvisioningState? provisioningState, StorageTaskReportProperties runStatus)
            => StorageTaskAssignmentProperties(taskId, isEnabled, description, executionContext, reportPrefix, provisioningState.HasValue ? new StorageTaskAssignmentProvisioningState(provisioningState.Value.ToSerialString()) : (StorageTaskAssignmentProvisioningState?)null, runStatus);

        /// <summary> Initializes a new instance of <see cref="Storage.FileServiceUsageData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> File service usage in storage account including account limits, file share limits and constants used in recommendations and bursting formula. </param>
        /// <returns> A new <see cref="Storage.FileServiceUsageData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        // The generator no longer emits this factory because the public Properties member is supplied by customization.
        // Keep this hidden overload to preserve the prior GA model factory surface.
        public static FileServiceUsageData FileServiceUsageData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, FileServiceUsageProperties properties)
        {
            return new FileServiceUsageData(
                id,
                name,
                resourceType,
                systemData,
                properties,
                additionalBinaryDataProperties: null);
        }

        private static StorageAccountProvisioningState? ToAccountProvisioningState(StorageProvisioningState? state)
        {
            if (!state.HasValue)
                return null;
            return state.Value switch
            {
                StorageProvisioningState.Creating => StorageAccountProvisioningState.Creating,
                StorageProvisioningState.ResolvingDns => StorageAccountProvisioningState.ResolvingDns,
                StorageProvisioningState.Succeeded => StorageAccountProvisioningState.Succeeded,
                _ => null
            };
        }

        /// <summary> Initializes a new instance of BlobContainerData for mocking. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobContainerData BlobContainerData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string version, bool? isDeleted, DateTimeOffset? deletedOn, int? remainingRetentionDays, string defaultEncryptionScope, bool? preventEncryptionScopeOverride, StoragePublicAccessType? publicAccess, DateTimeOffset? lastModifiedOn, StorageLeaseStatus? leaseStatus, StorageLeaseState? leaseState, StorageLeaseDurationType? leaseDuration, IDictionary<string, string> metadata, BlobContainerImmutabilityPolicy immutabilityPolicy, LegalHoldProperties legalHold, bool? hasLegalHold, bool? hasImmutabilityPolicy, ImmutableStorageWithVersioning immutableStorageWithVersioning, bool? enableNfsV3RootSquash, bool? enableNfsV3AllSquash, ETag? etag)
        {
            return new BlobContainerData(id, name, resourceType, systemData,
                new ContainerProperties(version, isDeleted, deletedOn, remainingRetentionDays, defaultEncryptionScope, preventEncryptionScopeOverride, publicAccess, lastModifiedOn, leaseStatus, leaseState, leaseDuration, metadata is null ? null : new ChangeTrackingDictionary<string, string>(metadata), immutabilityPolicy, legalHold, hasLegalHold, hasImmutabilityPolicy, immutableStorageWithVersioning, enableNfsV3RootSquash, enableNfsV3AllSquash, blobAccessPointConfiguration: null, additionalBinaryDataProperties: null),
                etag,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of FileShareData for mocking. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileShareData FileShareData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DateTimeOffset? lastModifiedOn, IDictionary<string, string> metadata, int? shareQuota, int? provisionedIops, int? provisionedBandwidthMibps, int? includedBurstIops, long? maxBurstCreditsForIops, DateTimeOffset? nextAllowedQuotaDowngradeOn, DateTimeOffset? nextAllowedProvisionedIopsDowngradeOn, DateTimeOffset? nextAllowedProvisionedBandwidthDowngradeOn, FileShareEnabledProtocol? enabledProtocol, RootSquashType? rootSquash, string version, bool? isDeleted, DateTimeOffset? deletedOn, int? remainingRetentionDays, FileShareAccessTier? accessTier, DateTimeOffset? accessTierChangeOn, string accessTierStatus, long? shareUsageBytes, StorageLeaseStatus? leaseStatus, StorageLeaseState? leaseState, StorageLeaseDurationType? leaseDuration, IEnumerable<StorageSignedIdentifier> signedIdentifiers, DateTimeOffset? snapshotOn, FileSharePropertiesFileSharePaidBursting fileSharePaidBursting, ETag? etag)
        {
            return new FileShareData(id, name, resourceType, systemData,
                new FileShareProperties(lastModifiedOn, metadata is null ? null : new ChangeTrackingDictionary<string, string>(metadata), shareQuota, provisionedIops, provisionedBandwidthMibps, includedBurstIops, maxBurstCreditsForIops, nextAllowedQuotaDowngradeOn, nextAllowedProvisionedIopsDowngradeOn, nextAllowedProvisionedBandwidthDowngradeOn, enabledProtocol, rootSquash, version, isDeleted, deletedOn, remainingRetentionDays, accessTier, accessTierChangeOn, accessTierStatus, shareUsageBytes, leaseStatus, leaseState, leaseDuration, signedIdentifiers?.ToList(), snapshotOn, fileSharePaidBursting, null),
                etag,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of ImmutabilityPolicyData for mocking. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ImmutabilityPolicyData ImmutabilityPolicyData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, int? immutabilityPeriodSinceCreationInDays, ImmutabilityPolicyState? state, bool? allowProtectedAppendWrites, bool? allowProtectedAppendWritesAll, ETag? etag)
        {
            return new ImmutabilityPolicyData(id, name, resourceType, systemData,
                new ImmutabilityPolicyProperty(immutabilityPeriodSinceCreationInDays, state, allowProtectedAppendWrites, allowProtectedAppendWritesAll, null),
                etag,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of NetworkSecurityPerimeter for mocking. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkSecurityPerimeter NetworkSecurityPerimeter(string id, Guid? perimeterGuid, AzureLocation? location)
        {
            return new NetworkSecurityPerimeter(id, perimeterGuid, location, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of StorageTaskReportProperties for mocking. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageTaskReportProperties StorageTaskReportProperties(ResourceIdentifier taskAssignmentId, ResourceIdentifier storageAccountId, DateTimeOffset? startedOn, DateTimeOffset? finishedOn, string objectsTargetedCount, string objectsOperatedOnCount, string objectFailedCount, string objectsSucceededCount, string runStatusError, StorageTaskRunStatus? runStatusEnum, string summaryReportPath, ResourceIdentifier taskId, string taskVersion, StorageTaskRunResult? runResult)
        {
            return new StorageTaskReportProperties(taskAssignmentId, storageAccountId, startedOn, finishedOn, objectsTargetedCount, objectsOperatedOnCount, objectFailedCount, objectsSucceededCount, runStatusError, runStatusEnum, summaryReportPath, taskId, taskVersion, runResult, additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.StorageTaskReportInstance"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> Storage task execution report for a run instance. </param>
        /// <returns> A new <see cref="Models.StorageTaskReportInstance"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        // The generator no longer emits this factory because the public Properties member is supplied by customization.
        // Keep this hidden overload to preserve the prior GA model factory surface.
        public static StorageTaskReportInstance StorageTaskReportInstance(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, StorageTaskReportProperties properties)
        {
            return new StorageTaskReportInstance(
                id,
                name,
                resourceType,
                systemData,
                properties,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of UpdateHistoryEntry for mocking. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UpdateHistoryEntry UpdateHistoryEntry(ImmutabilityPolicyUpdateType? updateType, int? immutabilityPeriodSinceCreationInDays, DateTimeOffset? timestamp, string objectIdentifier, Guid? tenantId, string upn, bool? allowProtectedAppendWrites, bool? allowProtectedAppendWritesAll)
        {
            return new UpdateHistoryEntry(updateType, immutabilityPeriodSinceCreationInDays, timestamp, objectIdentifier, tenantId, upn, allowProtectedAppendWrites, allowProtectedAppendWritesAll, additionalBinaryDataProperties: null);
        }

        // Backward-compat: pre-overhaul signature had baseSizeTiB and extendedCapacitySizeTiB as long? (nullable).
        // The mgmt generator's flatten/lift-to-nullable overhaul now exposes these as non-nullable long.
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="targetSkuName"> Target sku name for the account. </param>
        /// <param name="migrationStatus"> Current status of migration. </param>
        /// <param name="migrationFailedReason"> Error code for migration failure. </param>
        /// <param name="migrationFailedDetailedReason"> Reason for migration failure. </param>
        /// <param name="name0"> The name of the Storage Account Migration. It should always be 'default'. </param>
        /// <returns> A new <see cref="Storage.StorageAccountMigrationData"/> instance for mocking. </returns>
        public static StorageAccountMigrationData StorageAccountMigrationData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, StorageSkuName? targetSkuName = default, StorageAccountMigrationStatus? migrationStatus = default, string migrationFailedReason = null, string migrationFailedDetailedReason = null, string name0 = null)
            => StorageAccountMigrationData(id, name, resourceType, systemData, targetSkuName.GetValueOrDefault(), migrationStatus, migrationFailedReason, migrationFailedDetailedReason, name0);

        // Workaround: The generator has a bug that when an overload is created in customized code with the same parameter list, but the nullability of some parameters is different,
        // the generator somehow treat the overload as a duplicated method, and the generated overload with different nullability will no longer be generated.
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="targetSkuName"> Target sku name for the account. </param>
        /// <param name="migrationStatus"> Current status of migration. </param>
        /// <param name="migrationFailedReason"> Error code for migration failure. </param>
        /// <param name="migrationFailedDetailedReason"> Reason for migration failure. </param>
        /// <param name="name0"> The name of the Storage Account Migration. It should always be 'default'. </param>
        /// <returns> A new <see cref="Storage.StorageAccountMigrationData"/> instance for mocking. </returns>
        public static StorageAccountMigrationData StorageAccountMigrationData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, StorageSkuName targetSkuName = default, StorageAccountMigrationStatus? migrationStatus = default, string migrationFailedReason = default, string migrationFailedDetailedReason = default, string name0 = default)
        {
            return new StorageAccountMigrationData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                new StorageAccountMigrationProperties(targetSkuName, migrationStatus, migrationFailedReason, migrationFailedDetailedReason, null),
                name);
        }
    }
}
