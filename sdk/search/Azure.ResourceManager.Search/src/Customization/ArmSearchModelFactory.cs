// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Search;

namespace Azure.ResourceManager.Search.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmSearchModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Search.SearchServiceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="searchSkuName"> The SKU name. </param>
        /// <param name="identity"> The identity (ignored — type changed from ManagedServiceIdentity to Identity). </param>
        /// <param name="replicaCount"> The replica count. </param>
        /// <param name="partitionCount"> The partition count. </param>
        /// <param name="endpoint"> The endpoint. </param>
        /// <param name="hostingMode"> The hosting mode. </param>
        /// <param name="computeType"> The compute type. </param>
        /// <param name="publicInternetAccess"> The public internet access setting. </param>
        /// <param name="status"> The status. </param>
        /// <param name="statusDetails"> The status details. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="networkRuleSet"> The network rule set. </param>
        /// <param name="dataExfiltrationProtections"> The data exfiltration protections. </param>
        /// <param name="encryptionWithCmk"> The encryption with CMK setting. </param>
        /// <param name="isLocalAuthDisabled"> Whether local auth is disabled. </param>
        /// <param name="authOptions"> The auth options. </param>
        /// <param name="semanticSearch"> The semantic search setting. </param>
        /// <param name="privateEndpointConnections"> The private endpoint connections. </param>
        /// <param name="sharedPrivateLinkResources"> The shared private link resources. </param>
        /// <param name="eTag"> The ETag. </param>
        /// <param name="isUpgradeAvailable"> Whether upgrade is available. </param>
        /// <param name="serviceUpgradedOn"> The service upgrade date. </param>
        /// <returns> A new <see cref="Search.SearchServiceData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceData SearchServiceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, SearchServiceSkuName? searchSkuName = default, ManagedServiceIdentity identity = null, int? replicaCount = default, int? partitionCount = default, Uri endpoint = null, SearchServiceHostingMode? hostingMode = default, SearchServiceComputeType? computeType = default, SearchServicePublicInternetAccess? publicInternetAccess = default, SearchServiceStatus? status = default, string statusDetails = null, SearchServiceProvisioningState? provisioningState = default, SearchServiceNetworkRuleSet networkRuleSet = null, IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections = null, SearchEncryptionWithCmk encryptionWithCmk = null, bool? isLocalAuthDisabled = default, SearchAadAuthDataPlaneAuthOptions authOptions = null, SearchSemanticSearch? semanticSearch = default, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections = null, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources = null, ETag? eTag = default, SearchServiceUpgradeAvailable? isUpgradeAvailable = default, DateTimeOffset? serviceUpgradedOn = default)
        {
            return SearchServiceData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                replicaCount: replicaCount,
                partitionCount: partitionCount,
                endpoint: endpoint,
                hostingMode: hostingMode,
                computeType: computeType,
                publicInternetAccess: publicInternetAccess,
                status: status,
                statusDetails: statusDetails,
                provisioningState: provisioningState,
                networkRuleSet: networkRuleSet,
                dataExfiltrationProtections: dataExfiltrationProtections,
                encryptionWithCmk: encryptionWithCmk,
                isLocalAuthDisabled: isLocalAuthDisabled,
                authOptions: authOptions,
                semanticSearch: semanticSearch,
                privateEndpointConnections: privateEndpointConnections,
                sharedPrivateLinkResources: sharedPrivateLinkResources,
                etag: eTag?.ToString(),
                isUpgradeAvailable: isUpgradeAvailable,
                serviceUpgradedOn: serviceUpgradedOn,
                searchSkuName: searchSkuName,
                identity: default(Identity));
        }

        /// <summary> Initializes a new instance of <see cref="Search.SearchServiceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="skuName"> The SKU of the search service. </param>
        /// <param name="identity"> The identity (ignored — type changed from ManagedServiceIdentity to Identity). </param>
        /// <param name="replicaCount"> The replica count. </param>
        /// <param name="partitionCount"> The partition count. </param>
        /// <param name="hostingMode"> The hosting mode. </param>
        /// <param name="publicNetworkAccess"> The public network access setting. </param>
        /// <param name="status"> The status. </param>
        /// <param name="statusDetails"> The status details. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="ipRules"> Network-specific rules that determine how the search service may be reached. </param>
        /// <param name="encryptionWithCmk"> The encryption with CMK setting. </param>
        /// <param name="isLocalAuthDisabled"> Whether local auth is disabled. </param>
        /// <param name="authOptions"> The auth options. </param>
        /// <param name="privateEndpointConnections"> The private endpoint connections. </param>
        /// <param name="semanticSearch"> The semantic search setting. </param>
        /// <param name="sharedPrivateLinkResources"> The shared private link resources. </param>
        /// <returns> A new <see cref="Search.SearchServiceData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceData SearchServiceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName, ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, SearchServiceHostingMode? hostingMode, SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status, string statusDetails, SearchServiceProvisioningState? provisioningState, IEnumerable<SearchServiceIPRule> ipRules, SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, SearchSemanticSearch? semanticSearch, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources)
        {
            return SearchServiceData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                replicaCount: replicaCount,
                partitionCount: partitionCount,
                hostingMode: hostingMode,
                // ternary operator must use a nullable instance of the type to avoid triggering the implicit cast on the null
                publicInternetAccess: publicNetworkAccess.HasValue ? new SearchServicePublicInternetAccess?(publicNetworkAccess.Value.ToSerialString()) : null,
                status: status,
                statusDetails: statusDetails,
                provisioningState: provisioningState,
                networkRuleSet: ipRules != null ? new SearchServiceNetworkRuleSet(ipRules.ToList(), null, null) : null,
                encryptionWithCmk: encryptionWithCmk,
                isLocalAuthDisabled: isLocalAuthDisabled,
                authOptions: authOptions,
                semanticSearch: semanticSearch,
                privateEndpointConnections: privateEndpointConnections,
                sharedPrivateLinkResources: sharedPrivateLinkResources,
                // ternary operator must use a nullable instance of the type to avoid triggering the implicit cast on the null
                searchSkuName: skuName.HasValue ? new SearchServiceSkuName?(skuName.Value.ToSerialString()) : null,
                identity: default(Identity));
        }

        /// <summary> Initializes a new instance of <see cref="Search.SearchServiceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="skuName"> The SKU of the search service. </param>
        /// <param name="identity"> The identity (ignored — type changed from ManagedServiceIdentity to Identity). </param>
        /// <param name="replicaCount"> The replica count. </param>
        /// <param name="partitionCount"> The partition count. </param>
        /// <param name="endpoint"> The endpoint. </param>
        /// <param name="hostingMode"> The hosting mode. </param>
        /// <param name="computeType"> The compute type. </param>
        /// <param name="publicNetworkAccess"> The public network access setting. </param>
        /// <param name="status"> The status. </param>
        /// <param name="statusDetails"> The status details. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="ipRules"> Network-specific rules that determine how the search service may be reached. </param>
        /// <param name="dataExfiltrationProtections"> The data exfiltration protections. </param>
        /// <param name="encryptionWithCmk"> The encryption with CMK setting. </param>
        /// <param name="isLocalAuthDisabled"> Whether local auth is disabled. </param>
        /// <param name="authOptions"> The auth options. </param>
        /// <param name="semanticSearch"> The semantic search setting. </param>
        /// <param name="privateEndpointConnections"> The private endpoint connections. </param>
        /// <param name="sharedPrivateLinkResources"> The shared private link resources. </param>
        /// <param name="upgradeAvailable"> Indicates whether or not the search service has an upgrade available. </param>
        /// <param name="serviceUpgradeOn"> The date and time the search service was last upgraded. </param>
        /// <returns> A new <see cref="Search.SearchServiceData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceData SearchServiceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName, ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, Uri endpoint, SearchServiceHostingMode? hostingMode, SearchServiceComputeType? computeType, SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status, string statusDetails, SearchServiceProvisioningState? provisioningState, IEnumerable<SearchServiceIPRule> ipRules, IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections, SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, SearchSemanticSearch? semanticSearch, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources, bool? upgradeAvailable, DateTimeOffset? serviceUpgradeOn)
        {
            return SearchServiceData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                replicaCount: replicaCount,
                partitionCount: partitionCount,
                endpoint: endpoint,
                hostingMode: hostingMode,
                computeType: computeType,
                // ternary operator must use a nullable instance of the type to avoid triggering the implicit cast on the null
                publicInternetAccess: publicNetworkAccess.HasValue ? new SearchServicePublicInternetAccess?(publicNetworkAccess.Value.ToSerialString()) : null,
                status: status,
                statusDetails: statusDetails,
                provisioningState: provisioningState,
                networkRuleSet: ipRules != null ? new SearchServiceNetworkRuleSet(ipRules.ToList(), null, null) : null,
                dataExfiltrationProtections: dataExfiltrationProtections,
                encryptionWithCmk: encryptionWithCmk,
                isLocalAuthDisabled: isLocalAuthDisabled,
                authOptions: authOptions,
                semanticSearch: semanticSearch,
                privateEndpointConnections: privateEndpointConnections,
                sharedPrivateLinkResources: sharedPrivateLinkResources,
                isUpgradeAvailable: upgradeAvailable.HasValue
                    ? (upgradeAvailable.Value ? SearchServiceUpgradeAvailable.Available : SearchServiceUpgradeAvailable.NotAvailable)
                    : (SearchServiceUpgradeAvailable?)null,
                serviceUpgradedOn: serviceUpgradeOn,
                // ternary operator must use a nullable instance of the type to avoid triggering the implicit cast on the null
                searchSkuName: skuName.HasValue ? new SearchServiceSkuName?(skuName.Value.ToSerialString()) : null,
                identity: default(Identity));
        }

        /// <summary> Initializes a new instance of <see cref="Models.SearchServicePatch"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="searchSkuName"> The SKU name. </param>
        /// <param name="identity"> The identity (ignored — type changed from ManagedServiceIdentity to Identity). </param>
        /// <param name="replicaCount"> The replica count. </param>
        /// <param name="partitionCount"> The partition count. </param>
        /// <param name="endpoint"> The endpoint. </param>
        /// <param name="hostingMode"> The hosting mode. </param>
        /// <param name="computeType"> The compute type. </param>
        /// <param name="publicInternetAccess"> The public internet access setting. </param>
        /// <param name="status"> The status. </param>
        /// <param name="statusDetails"> The status details. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="networkRuleSet"> The network rule set. </param>
        /// <param name="dataExfiltrationProtections"> The data exfiltration protections. </param>
        /// <param name="encryptionWithCmk"> The encryption with CMK setting. </param>
        /// <param name="isLocalAuthDisabled"> Whether local auth is disabled. </param>
        /// <param name="authOptions"> The auth options. </param>
        /// <param name="semanticSearch"> The semantic search setting. </param>
        /// <param name="privateEndpointConnections"> The private endpoint connections. </param>
        /// <param name="sharedPrivateLinkResources"> The shared private link resources. </param>
        /// <param name="eTag"> The ETag. </param>
        /// <param name="isUpgradeAvailable"> Whether upgrade is available. </param>
        /// <param name="serviceUpgradedOn"> The service upgrade date. </param>
        /// <returns> A new <see cref="Models.SearchServicePatch"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServicePatch SearchServicePatch(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, SearchServiceSkuName? searchSkuName = default, ManagedServiceIdentity identity = null, int? replicaCount = default, int? partitionCount = default, Uri endpoint = null, SearchServiceHostingMode? hostingMode = default, SearchServiceComputeType? computeType = default, SearchServicePublicInternetAccess? publicInternetAccess = default, SearchServiceStatus? status = default, string statusDetails = null, SearchServiceProvisioningState? provisioningState = default, SearchServiceNetworkRuleSet networkRuleSet = null, IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections = null, SearchEncryptionWithCmk encryptionWithCmk = null, bool? isLocalAuthDisabled = default, SearchAadAuthDataPlaneAuthOptions authOptions = null, SearchSemanticSearch? semanticSearch = default, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections = null, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources = null, ETag? eTag = default, SearchServiceUpgradeAvailable? isUpgradeAvailable = default, DateTimeOffset? serviceUpgradedOn = default)
        {
            return SearchServicePatch(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                replicaCount: replicaCount,
                partitionCount: partitionCount,
                endpoint: endpoint,
                hostingMode: hostingMode,
                computeType: computeType,
                publicInternetAccess: publicInternetAccess,
                status: status,
                statusDetails: statusDetails,
                provisioningState: provisioningState,
                networkRuleSet: networkRuleSet,
                dataExfiltrationProtections: dataExfiltrationProtections,
                encryptionWithCmk: encryptionWithCmk,
                isLocalAuthDisabled: isLocalAuthDisabled,
                authOptions: authOptions,
                semanticSearch: semanticSearch,
                privateEndpointConnections: privateEndpointConnections,
                sharedPrivateLinkResources: sharedPrivateLinkResources,
                etag: eTag?.ToString(),
                isUpgradeAvailable: isUpgradeAvailable,
                serviceUpgradedOn: serviceUpgradedOn,
                searchSkuName: searchSkuName,
                location: location.ToString(),
                tags: tags,
                identity: default(Identity));
        }

        /// <summary> Initializes a new instance of <see cref="Models.SearchServicePatch"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="skuName"> The SKU of the search service. </param>
        /// <param name="identity"> The identity (ignored — type changed from ManagedServiceIdentity to Identity). </param>
        /// <param name="replicaCount"> The replica count. </param>
        /// <param name="partitionCount"> The partition count. </param>
        /// <param name="hostingMode"> The hosting mode. </param>
        /// <param name="publicNetworkAccess"> The public network access setting. </param>
        /// <param name="status"> The status. </param>
        /// <param name="statusDetails"> The status details. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="ipRules"> Network-specific rules that determine how the search service may be reached. </param>
        /// <param name="encryptionWithCmk"> The encryption with CMK setting. </param>
        /// <param name="isLocalAuthDisabled"> Whether local auth is disabled. </param>
        /// <param name="authOptions"> The auth options. </param>
        /// <param name="privateEndpointConnections"> The private endpoint connections. </param>
        /// <param name="semanticSearch"> The semantic search setting. </param>
        /// <param name="sharedPrivateLinkResources"> The shared private link resources. </param>
        /// <returns> A new <see cref="Models.SearchServicePatch"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServicePatch SearchServicePatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName, ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, SearchServiceHostingMode? hostingMode, SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status, string statusDetails, SearchServiceProvisioningState? provisioningState, IEnumerable<SearchServiceIPRule> ipRules, SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, SearchSemanticSearch? semanticSearch, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources)
        {
            return SearchServicePatch(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                replicaCount: replicaCount,
                partitionCount: partitionCount,
                hostingMode: hostingMode,
                // ternary operator must use a nullable instance of the type to avoid triggering the implicit cast on the null
                publicInternetAccess: publicNetworkAccess.HasValue ? new SearchServicePublicInternetAccess?(publicNetworkAccess.Value.ToSerialString()) : null,
                status: status,
                statusDetails: statusDetails,
                provisioningState: provisioningState,
                networkRuleSet: ipRules != null ? new SearchServiceNetworkRuleSet(ipRules.ToList(), null, null) : null,
                encryptionWithCmk: encryptionWithCmk,
                isLocalAuthDisabled: isLocalAuthDisabled,
                authOptions: authOptions,
                semanticSearch: semanticSearch,
                privateEndpointConnections: privateEndpointConnections,
                sharedPrivateLinkResources: sharedPrivateLinkResources,
                // ternary operator must use a nullable instance of the type to avoid triggering the implicit cast on the null
                searchSkuName: skuName.HasValue ? new SearchServiceSkuName?(skuName.Value.ToSerialString()) : null,
                location: location.ToString(),
                tags: tags,
                identity: default(Identity));
        }

        /// <summary> Initializes a new instance of <see cref="Models.SearchServicePatch"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="skuName"> The SKU of the search service. </param>
        /// <param name="identity"> The identity (ignored — type changed from ManagedServiceIdentity to Identity). </param>
        /// <param name="replicaCount"> The replica count. </param>
        /// <param name="partitionCount"> The partition count. </param>
        /// <param name="endpoint"> The endpoint. </param>
        /// <param name="hostingMode"> The hosting mode. </param>
        /// <param name="computeType"> The compute type. </param>
        /// <param name="publicNetworkAccess"> The public network access setting. </param>
        /// <param name="status"> The status. </param>
        /// <param name="statusDetails"> The status details. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="ipRules"> Network-specific rules that determine how the search service may be reached. </param>
        /// <param name="dataExfiltrationProtections"> The data exfiltration protections. </param>
        /// <param name="encryptionWithCmk"> The encryption with CMK setting. </param>
        /// <param name="isLocalAuthDisabled"> Whether local auth is disabled. </param>
        /// <param name="authOptions"> The auth options. </param>
        /// <param name="semanticSearch"> The semantic search setting. </param>
        /// <param name="privateEndpointConnections"> The private endpoint connections. </param>
        /// <param name="sharedPrivateLinkResources"> The shared private link resources. </param>
        /// <param name="upgradeAvailable"> Indicates whether or not the search service has an upgrade available. </param>
        /// <param name="serviceUpgradeOn"> The date and time the search service was last upgraded. </param>
        /// <returns> A new <see cref="Models.SearchServicePatch"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServicePatch SearchServicePatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName, ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, Uri endpoint, SearchServiceHostingMode? hostingMode, SearchServiceComputeType? computeType, SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status, string statusDetails, SearchServiceProvisioningState? provisioningState, IEnumerable<SearchServiceIPRule> ipRules, IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections, SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, SearchSemanticSearch? semanticSearch, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources, bool? upgradeAvailable, DateTimeOffset? serviceUpgradeOn)
        {
            return SearchServicePatch(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                replicaCount: replicaCount,
                partitionCount: partitionCount,
                endpoint: endpoint,
                hostingMode: hostingMode,
                computeType: computeType,
                // ternary operator must use a nullable instance of the type to avoid triggering the implicit cast on the null
                publicInternetAccess: publicNetworkAccess.HasValue ? new SearchServicePublicInternetAccess?(publicNetworkAccess.Value.ToSerialString()) : null,
                status: status,
                statusDetails: statusDetails,
                provisioningState: provisioningState,
                networkRuleSet: ipRules != null ? new SearchServiceNetworkRuleSet(ipRules.ToList(), null, null) : null,
                dataExfiltrationProtections: dataExfiltrationProtections,
                encryptionWithCmk: encryptionWithCmk,
                isLocalAuthDisabled: isLocalAuthDisabled,
                authOptions: authOptions,
                semanticSearch: semanticSearch,
                privateEndpointConnections: privateEndpointConnections,
                sharedPrivateLinkResources: sharedPrivateLinkResources,
                isUpgradeAvailable: upgradeAvailable.HasValue
                    ? (upgradeAvailable.Value ? SearchServiceUpgradeAvailable.Available : SearchServiceUpgradeAvailable.NotAvailable)
                    : (SearchServiceUpgradeAvailable?)null,
                serviceUpgradedOn: serviceUpgradeOn,
                // ternary operator must use a nullable instance of the type to avoid triggering the implicit cast on the null
                searchSkuName: skuName.HasValue ? new SearchServiceSkuName?(skuName.Value.ToSerialString()) : null,
                location: location.ToString(),
                tags: tags,
                identity: default(Identity));
        }

        /// <summary> Initializes a new instance of <see cref="Models.QuotaUsageResult"/>. </summary>
        /// <param name="id"> The resource ID of the quota usage SKU endpoint. </param>
        /// <param name="unit"> The unit of measurement for the search SKU. </param>
        /// <param name="currentValue"> The currently used up value for the particular search SKU. </param>
        /// <param name="limit"> The quota limit for the particular search SKU. </param>
        /// <param name="name"> The name of the SKU supported by Azure AI Search. </param>
        /// <returns> A new <see cref="Models.QuotaUsageResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static QuotaUsageResult QuotaUsageResult(ResourceIdentifier id, string unit, int? currentValue, int? limit, QuotaUsageResultName name)
        {
            return QuotaUsageResult(
                id: id?.ToString(),
                unit: unit,
                currentValue: currentValue,
                limit: limit,
                name: name);
        }
    }
}
