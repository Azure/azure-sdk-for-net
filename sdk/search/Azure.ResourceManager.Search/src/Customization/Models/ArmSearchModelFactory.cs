// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Search.Models
{
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    public static partial class ArmSearchModelFactory
    {
        /// <summary> Creates search service data for mocking, including extensible service statuses. </summary>
        public static SearchServiceData SearchServiceData(
            ResourceIdentifier id = default, string name = default, ResourceType resourceType = default,
            SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default,
            int? replicaCount = default, int? partitionCount = default, Uri endpoint = default,
            SearchServiceHostingMode? hostingMode = default, SearchServiceComputeType? computeType = default,
            SearchServicePublicInternetAccess? publicInternetAccess = default, SearchServiceState? status = default,
            string statusDetails = default, SearchServiceProvisioningState? provisioningState = default,
            SearchServiceNetworkRuleSet networkRuleSet = default,
            IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections = default,
            SearchEncryptionWithCmk encryptionWithCmk = default, bool? isLocalAuthDisabled = default,
            SearchAadAuthDataPlaneAuthOptions authOptions = default, SearchSemanticSearch? semanticSearch = default,
            SearchKnowledgeRetrieval? knowledgeRetrieval = default,
            IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections = default,
            IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources = default,
            ETag? eTag = default, SearchServiceUpgradeAvailable? isUpgradeAvailable = default,
            DateTimeOffset? serviceUpgradedOn = default, SearchServiceSkuName? searchSkuName = default,
            ManagedServiceIdentity identity = default)
        {
            return new SearchServiceData(
                id, name, resourceType, systemData, tags ?? new ChangeTrackingDictionary<string, string>(), location,
                replicaCount is null && partitionCount is null && endpoint is null && hostingMode is null &&
                computeType is null && publicInternetAccess is null && status is null && statusDetails is null &&
                provisioningState is null && networkRuleSet is null && dataExfiltrationProtections is null &&
                encryptionWithCmk is null && isLocalAuthDisabled is null && authOptions is null &&
                semanticSearch is null && knowledgeRetrieval is null && privateEndpointConnections is null &&
                sharedPrivateLinkResources is null && eTag is null && isUpgradeAvailable is null &&
                serviceUpgradedOn is null ? default : new SearchServiceProperties(
                    replicaCount, partitionCount, endpoint, hostingMode, computeType, publicInternetAccess, status,
                    statusDetails, provisioningState, networkRuleSet,
                    (dataExfiltrationProtections ?? new ChangeTrackingList<SearchDataExfiltrationProtection>()).ToList(),
                    encryptionWithCmk, isLocalAuthDisabled, authOptions, semanticSearch, knowledgeRetrieval,
                    (privateEndpointConnections ?? new ChangeTrackingList<SearchPrivateEndpointConnectionData>()).ToList(),
                    (sharedPrivateLinkResources ?? new ChangeTrackingList<SharedSearchServicePrivateLinkResourceData>()).ToList(),
                    eTag, isUpgradeAvailable, serviceUpgradedOn, default),
                searchSkuName is null ? default : new SearchSku(searchSkuName, default), identity, default);
        }

        /// <summary> Creates a search service patch for mocking, including extensible service statuses. </summary>
        public static SearchServicePatch SearchServicePatch(
            ResourceIdentifier id = default, string name = default, ResourceType resourceType = default,
            SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default,
            int? replicaCount = default, int? partitionCount = default, Uri endpoint = default,
            SearchServiceHostingMode? hostingMode = default, SearchServiceComputeType? computeType = default,
            SearchServicePublicInternetAccess? publicInternetAccess = default, SearchServiceState? status = default,
            string statusDetails = default, SearchServiceProvisioningState? provisioningState = default,
            SearchServiceNetworkRuleSet networkRuleSet = default,
            IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections = default,
            SearchEncryptionWithCmk encryptionWithCmk = default, bool? isLocalAuthDisabled = default,
            SearchAadAuthDataPlaneAuthOptions authOptions = default, SearchSemanticSearch? semanticSearch = default,
            SearchKnowledgeRetrieval? knowledgeRetrieval = default,
            IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections = default,
            IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources = default,
            ETag? eTag = default, SearchServiceUpgradeAvailable? isUpgradeAvailable = default,
            DateTimeOffset? serviceUpgradedOn = default, SearchServiceSkuName? searchSkuName = default,
            ManagedServiceIdentity identity = default)
        {
            return new SearchServicePatch(
                id, name, resourceType, systemData, tags ?? new ChangeTrackingDictionary<string, string>(), location,
                replicaCount is null && partitionCount is null && endpoint is null && hostingMode is null &&
                computeType is null && publicInternetAccess is null && status is null && statusDetails is null &&
                provisioningState is null && networkRuleSet is null && dataExfiltrationProtections is null &&
                encryptionWithCmk is null && isLocalAuthDisabled is null && authOptions is null &&
                semanticSearch is null && knowledgeRetrieval is null && privateEndpointConnections is null &&
                sharedPrivateLinkResources is null && eTag is null && isUpgradeAvailable is null &&
                serviceUpgradedOn is null ? default : new SearchServiceProperties(
                    replicaCount, partitionCount, endpoint, hostingMode, computeType, publicInternetAccess, status,
                    statusDetails, provisioningState, networkRuleSet,
                    (dataExfiltrationProtections ?? new ChangeTrackingList<SearchDataExfiltrationProtection>()).ToList(),
                    encryptionWithCmk, isLocalAuthDisabled, authOptions, semanticSearch, knowledgeRetrieval,
                    (privateEndpointConnections ?? new ChangeTrackingList<SearchPrivateEndpointConnectionData>()).ToList(),
                    (sharedPrivateLinkResources ?? new ChangeTrackingList<SharedSearchServicePrivateLinkResourceData>()).ToList(),
                    eTag, isUpgradeAvailable, serviceUpgradedOn, default),
                searchSkuName is null ? default : new SearchSku(searchSkuName, default), identity, default);
        }

        /// <summary> Creates search service data using the legacy model factory signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceData SearchServiceData(
            ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData,
            IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName,
            ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, Uri endpoint,
            SearchServiceHostingMode? hostingMode, SearchServiceComputeType? computeType,
            SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status,
            string statusDetails, SearchServiceProvisioningState? provisioningState,
            IEnumerable<SearchServiceIPRule> ipRules, IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections,
            SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions,
            SearchSemanticSearch? semanticSearch, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections,
            IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources,
            bool? upgradeAvailable, DateTimeOffset? serviceUpgradeOn)
        {
            return SearchServiceData(
                id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location,
                replicaCount: replicaCount, partitionCount: partitionCount, endpoint: endpoint, hostingMode: hostingMode,
                computeType: computeType,
                publicInternetAccess: publicNetworkAccess.HasValue ? new SearchServicePublicInternetAccess(publicNetworkAccess.Value.ToSerialString()) : (SearchServicePublicInternetAccess?)null,
                status: (SearchServiceState?)status, statusDetails: statusDetails,
                provisioningState: provisioningState, networkRuleSet: CreateNetworkRuleSet(ipRules),
                dataExfiltrationProtections: dataExfiltrationProtections, encryptionWithCmk: encryptionWithCmk,
                isLocalAuthDisabled: isLocalAuthDisabled, authOptions: authOptions, semanticSearch: semanticSearch,
                privateEndpointConnections: privateEndpointConnections, sharedPrivateLinkResources: sharedPrivateLinkResources,
                isUpgradeAvailable: upgradeAvailable.HasValue ? (upgradeAvailable.Value ? SearchServiceUpgradeAvailable.Available : SearchServiceUpgradeAvailable.NotAvailable) : (SearchServiceUpgradeAvailable?)null,
                serviceUpgradedOn: serviceUpgradeOn,
                searchSkuName: skuName.HasValue ? new SearchServiceSkuName(skuName.Value.ToSerialString()) : (SearchServiceSkuName?)null, identity: identity);
        }

        /// <summary> Creates search service data using the legacy model factory signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceData SearchServiceData(
            ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData,
            IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName,
            ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, SearchServiceHostingMode? hostingMode,
            SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status, string statusDetails,
            SearchServiceProvisioningState? provisioningState, IEnumerable<SearchServiceIPRule> ipRules,
            SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions,
            IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, SearchSemanticSearch? semanticSearch,
            IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources)
        {
            return SearchServiceData(
                id, name, resourceType, systemData, tags, location, skuName, identity, replicaCount, partitionCount,
                null, hostingMode, null, publicNetworkAccess, status, statusDetails, provisioningState, ipRules, null,
                encryptionWithCmk, isLocalAuthDisabled, authOptions, semanticSearch, privateEndpointConnections,
                sharedPrivateLinkResources, null, null);
        }

        /// <summary> Creates a search service patch using the legacy model factory signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServicePatch SearchServicePatch(
            ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData,
            IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName,
            ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, Uri endpoint,
            SearchServiceHostingMode? hostingMode, SearchServiceComputeType? computeType,
            SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status,
            string statusDetails, SearchServiceProvisioningState? provisioningState,
            IEnumerable<SearchServiceIPRule> ipRules, IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections,
            SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions,
            SearchSemanticSearch? semanticSearch, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections,
            IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources,
            bool? upgradeAvailable, DateTimeOffset? serviceUpgradeOn)
        {
            return SearchServicePatch(
                id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location,
                replicaCount: replicaCount, partitionCount: partitionCount, endpoint: endpoint, hostingMode: hostingMode,
                computeType: computeType,
                publicInternetAccess: publicNetworkAccess.HasValue ? new SearchServicePublicInternetAccess(publicNetworkAccess.Value.ToSerialString()) : (SearchServicePublicInternetAccess?)null,
                status: (SearchServiceState?)status, statusDetails: statusDetails,
                provisioningState: provisioningState, networkRuleSet: CreateNetworkRuleSet(ipRules),
                dataExfiltrationProtections: dataExfiltrationProtections, encryptionWithCmk: encryptionWithCmk,
                isLocalAuthDisabled: isLocalAuthDisabled, authOptions: authOptions, semanticSearch: semanticSearch,
                privateEndpointConnections: privateEndpointConnections, sharedPrivateLinkResources: sharedPrivateLinkResources,
                isUpgradeAvailable: upgradeAvailable.HasValue ? (upgradeAvailable.Value ? SearchServiceUpgradeAvailable.Available : SearchServiceUpgradeAvailable.NotAvailable) : (SearchServiceUpgradeAvailable?)null,
                serviceUpgradedOn: serviceUpgradeOn,
                searchSkuName: skuName.HasValue ? new SearchServiceSkuName(skuName.Value.ToSerialString()) : (SearchServiceSkuName?)null, identity: identity);
        }

        /// <summary> Creates a search service patch using the legacy model factory signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServicePatch SearchServicePatch(
            ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData,
            IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName,
            ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, SearchServiceHostingMode? hostingMode,
            SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status, string statusDetails,
            SearchServiceProvisioningState? provisioningState, IEnumerable<SearchServiceIPRule> ipRules,
            SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions,
            IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, SearchSemanticSearch? semanticSearch,
            IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources)
        {
            return SearchServicePatch(
                id, name, resourceType, systemData, tags, location, skuName, identity, replicaCount, partitionCount,
                null, hostingMode, null, publicNetworkAccess, status, statusDetails, provisioningState, ipRules, null,
                encryptionWithCmk, isLocalAuthDisabled, authOptions, semanticSearch, privateEndpointConnections,
                sharedPrivateLinkResources, null, null);
        }

        /// <summary> Creates search service data using the legacy status enum. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceData SearchServiceData(
            ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData,
            IDictionary<string, string> tags, AzureLocation location, SearchServiceSkuName? searchSkuName,
            ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, Uri endpoint,
            SearchServiceHostingMode? hostingMode, SearchServiceComputeType? computeType,
            SearchServicePublicInternetAccess? publicInternetAccess, SearchServiceStatus? status,
            string statusDetails, SearchServiceProvisioningState? provisioningState, SearchServiceNetworkRuleSet networkRuleSet,
            IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections, SearchEncryptionWithCmk encryptionWithCmk,
            bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, SearchSemanticSearch? semanticSearch,
            IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections,
            IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources,
            ETag? eTag, SearchServiceUpgradeAvailable? isUpgradeAvailable, DateTimeOffset? serviceUpgradedOn)
        {
            return SearchServiceData(
                id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location,
                replicaCount: replicaCount, partitionCount: partitionCount, endpoint: endpoint, hostingMode: hostingMode,
                computeType: computeType, publicInternetAccess: publicInternetAccess,
                status: (SearchServiceState?)status, statusDetails: statusDetails,
                provisioningState: provisioningState, networkRuleSet: networkRuleSet,
                dataExfiltrationProtections: dataExfiltrationProtections, encryptionWithCmk: encryptionWithCmk,
                isLocalAuthDisabled: isLocalAuthDisabled, authOptions: authOptions, semanticSearch: semanticSearch,
                privateEndpointConnections: privateEndpointConnections, sharedPrivateLinkResources: sharedPrivateLinkResources,
                eTag: eTag, isUpgradeAvailable: isUpgradeAvailable, serviceUpgradedOn: serviceUpgradedOn,
                searchSkuName: searchSkuName, identity: identity);
        }

        /// <summary> Creates a search service patch using the legacy status enum. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServicePatch SearchServicePatch(
            ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData,
            IDictionary<string, string> tags, AzureLocation location, SearchServiceSkuName? searchSkuName,
            ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, Uri endpoint,
            SearchServiceHostingMode? hostingMode, SearchServiceComputeType? computeType,
            SearchServicePublicInternetAccess? publicInternetAccess, SearchServiceStatus? status,
            string statusDetails, SearchServiceProvisioningState? provisioningState, SearchServiceNetworkRuleSet networkRuleSet,
            IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections, SearchEncryptionWithCmk encryptionWithCmk,
            bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, SearchSemanticSearch? semanticSearch,
            IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections,
            IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources,
            ETag? eTag, SearchServiceUpgradeAvailable? isUpgradeAvailable, DateTimeOffset? serviceUpgradedOn)
        {
            return SearchServicePatch(
                id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location,
                replicaCount: replicaCount, partitionCount: partitionCount, endpoint: endpoint, hostingMode: hostingMode,
                computeType: computeType, publicInternetAccess: publicInternetAccess,
                status: (SearchServiceState?)status, statusDetails: statusDetails,
                provisioningState: provisioningState, networkRuleSet: networkRuleSet,
                dataExfiltrationProtections: dataExfiltrationProtections, encryptionWithCmk: encryptionWithCmk,
                isLocalAuthDisabled: isLocalAuthDisabled, authOptions: authOptions, semanticSearch: semanticSearch,
                privateEndpointConnections: privateEndpointConnections, sharedPrivateLinkResources: sharedPrivateLinkResources,
                eTag: eTag, isUpgradeAvailable: isUpgradeAvailable, serviceUpgradedOn: serviceUpgradedOn,
                searchSkuName: searchSkuName, identity: identity);
        }

        private static SearchServiceNetworkRuleSet CreateNetworkRuleSet(IEnumerable<SearchServiceIPRule> ipRules)
        {
            if (ipRules is null)
            {
                return null;
            }

            var networkRuleSet = new SearchServiceNetworkRuleSet();
            foreach (SearchServiceIPRule ipRule in ipRules)
            {
                networkRuleSet.IPRules.Add(ipRule);
            }

            return networkRuleSet;
        }
    }
}
