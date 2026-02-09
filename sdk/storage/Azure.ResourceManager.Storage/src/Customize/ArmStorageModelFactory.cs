// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmStorageModelFactory
    {
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
        public static StorageAccountData StorageAccountData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, StorageSku sku, StorageKind? kind, ManagedServiceIdentity identity, ExtendedLocation extendedLocation, StorageProvisioningState? provisioningState, StorageAccountEndpoints primaryEndpoints, AzureLocation? primaryLocation, StorageAccountStatus? statusOfPrimary, DateTimeOffset? lastGeoFailoverOn, AzureLocation? secondaryLocation, StorageAccountStatus? statusOfSecondary, DateTimeOffset? createdOn, StorageCustomDomain customDomain, StorageAccountSasPolicy sasPolicy, int? keyExpirationPeriodInDays, StorageAccountKeyCreationTime keyCreationTime, StorageAccountEndpoints secondaryEndpoints, StorageAccountEncryption encryption, StorageAccountAccessTier? accessTier, FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication, bool? enableHttpsTrafficOnly, StorageAccountNetworkRuleSet networkRuleSet, bool? isSftpEnabled, bool? isLocalUserEnabled, bool? isHnsEnabled, GeoReplicationStatistics geoReplicationStats, bool? isFailoverInProgress, LargeFileSharesState? largeFileSharesState, IEnumerable<StoragePrivateEndpointConnectionData> privateEndpointConnections, StorageRoutingPreference routingPreference, BlobRestoreStatus blobRestoreStatus, bool? allowBlobPublicAccess, StorageMinimumTlsVersion? minimumTlsVersion, bool? allowSharedKeyAccess, bool? isNfsV3Enabled, bool? allowCrossTenantReplication, bool? isDefaultToOAuthAuthentication, StoragePublicNetworkAccess? publicNetworkAccess, ImmutableStorageAccount immutableStorageWithVersioning, AllowedCopyScope? allowedCopyScope, StorageAccountSkuConversionStatus storageAccountSkuConversionStatus, StorageDnsEndpointType? dnsEndpointType)
            => StorageAccountData(id, name, resourceType, systemData, tags, location, sku, kind, identity, extendedLocation, provisioningState.ToString(), primaryEndpoints, primaryLocation, statusOfPrimary, lastGeoFailoverOn, secondaryLocation, statusOfSecondary, createdOn, customDomain, sasPolicy, keyExpirationPeriodInDays, keyCreationTime, secondaryEndpoints, encryption, accessTier, azureFilesIdentityBasedAuthentication, enableHttpsTrafficOnly, networkRuleSet, isSftpEnabled, isLocalUserEnabled, default, isHnsEnabled, geoReplicationStats, isFailoverInProgress, largeFileSharesState, privateEndpointConnections, routingPreference, blobRestoreStatus, allowBlobPublicAccess, minimumTlsVersion, allowSharedKeyAccess, isNfsV3Enabled, allowCrossTenantReplication, isDefaultToOAuthAuthentication, publicNetworkAccess, immutableStorageWithVersioning, allowedCopyScope, storageAccountSkuConversionStatus, dnsEndpointType, default, default);

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
        public static StorageAccountData StorageAccountData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, StorageSku sku, StorageKind? kind, ManagedServiceIdentity identity, ExtendedLocation extendedLocation, StorageProvisioningState? provisioningState, StorageAccountEndpoints primaryEndpoints, AzureLocation? primaryLocation, StorageAccountStatus? statusOfPrimary, DateTimeOffset? lastGeoFailoverOn, AzureLocation? secondaryLocation, StorageAccountStatus? statusOfSecondary, DateTimeOffset? createdOn, StorageCustomDomain customDomain, StorageAccountSasPolicy sasPolicy, int? keyExpirationPeriodInDays, StorageAccountKeyCreationTime keyCreationTime, StorageAccountEndpoints secondaryEndpoints, StorageAccountEncryption encryption, StorageAccountAccessTier? accessTier, FilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication, bool? enableHttpsTrafficOnly, StorageAccountNetworkRuleSet networkRuleSet, bool? isSftpEnabled, bool? isLocalUserEnabled, bool? isExtendedGroupEnabled, bool? isHnsEnabled, GeoReplicationStatistics geoReplicationStats, bool? isFailoverInProgress, LargeFileSharesState? largeFileSharesState, IEnumerable<StoragePrivateEndpointConnectionData> privateEndpointConnections, StorageRoutingPreference routingPreference, BlobRestoreStatus blobRestoreStatus, bool? allowBlobPublicAccess, StorageMinimumTlsVersion? minimumTlsVersion, bool? allowSharedKeyAccess, bool? isNfsV3Enabled, bool? allowCrossTenantReplication, bool? isDefaultToOAuthAuthentication, StoragePublicNetworkAccess? publicNetworkAccess, ImmutableStorageAccount immutableStorageWithVersioning, AllowedCopyScope? allowedCopyScope, StorageAccountSkuConversionStatus storageAccountSkuConversionStatus, StorageDnsEndpointType? dnsEndpointType, bool? isSkuConversionBlocked, bool? isAccountMigrationInProgress)
            => StorageAccountData(id, name, resourceType, systemData, tags, location, sku, kind, identity, extendedLocation, provisioningState.ToString(), primaryEndpoints, primaryLocation, statusOfPrimary, lastGeoFailoverOn, secondaryLocation, statusOfSecondary, createdOn, customDomain, sasPolicy, keyExpirationPeriodInDays, keyCreationTime, secondaryEndpoints, encryption, accessTier, azureFilesIdentityBasedAuthentication, enableHttpsTrafficOnly, networkRuleSet, isSftpEnabled, isLocalUserEnabled, isExtendedGroupEnabled, isHnsEnabled, geoReplicationStats, isFailoverInProgress, largeFileSharesState, privateEndpointConnections, routingPreference, blobRestoreStatus, allowBlobPublicAccess, minimumTlsVersion, allowSharedKeyAccess, isNfsV3Enabled, allowCrossTenantReplication, isDefaultToOAuthAuthentication, publicNetworkAccess, immutableStorageWithVersioning, allowedCopyScope, storageAccountSkuConversionStatus, dnsEndpointType, isSkuConversionBlocked, isAccountMigrationInProgress);

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
            => StorageTaskAssignmentProperties(taskId, isEnabled, description, executionContext, reportPrefix, provisioningState.ToString(), runStatus);

        /// <summary> Initializes a new instance of <see cref="Models.StorageTaskAssignmentPatchProperties"/>. </summary>
        /// <param name="taskId"> Id of the corresponding storage task. </param>
        /// <param name="isEnabled"> Whether the storage task assignment is enabled or not. </param>
        /// <param name="description"> Text that describes the purpose of the storage task assignment. </param>
        /// <param name="executionContext"> The storage task assignment execution context. </param>
        /// <param name="reportPrefix"> The storage task assignment report. </param>
        /// <param name="provisioningState"> Represents the provisioning state of the storage task assignment. </param>
        /// <param name="runStatus"> Run status of storage task assignment. </param>
        /// <returns> A new <see cref="Models.StorageTaskAssignmentPatchProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageTaskAssignmentPatchProperties StorageTaskAssignmentPatchProperties(string taskId, bool? isEnabled, string description, StorageTaskAssignmentUpdateExecutionContext executionContext, string reportPrefix, StorageProvisioningState? provisioningState, StorageTaskReportProperties runStatus)
            => StorageTaskAssignmentPatchProperties(taskId, isEnabled, description, executionContext, reportPrefix, provisioningState.ToString(), runStatus);

        /// <summary> Initializes a new instance of <see cref="Storage.FileServiceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="sku"> Sku name and tier. </param>
        /// <param name="corsRules"> Specifies CORS rules for the File service. You can include up to five CorsRule elements in the request. If no CorsRule elements are included in the request body, all CORS rules will be deleted, and CORS will be disabled for the File service. </param>
        /// <param name="shareDeleteRetentionPolicy"> The file service properties for share soft delete. </param>
        /// <param name="protocolSmbSetting"> Protocol settings for file service. </param>
        /// <returns> A new <see cref="Storage.FileServiceData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileServiceData FileServiceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, StorageSku sku, IEnumerable<StorageCorsRule> corsRules, DeleteRetentionPolicy shareDeleteRetentionPolicy, SmbSetting protocolSmbSetting)
            => FileServiceData(id, name, resourceType, systemData, sku, corsRules, shareDeleteRetentionPolicy, new FileServiceProtocolSettings(protocolSmbSetting, null, null));
    }
}
