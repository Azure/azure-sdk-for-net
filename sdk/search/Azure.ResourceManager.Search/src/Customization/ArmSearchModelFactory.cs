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
    /// <summary> Model factory for models. </summary>
    public static partial class ArmSearchModelFactory
    {
        // Backward-compat factory overload #1 for SearchServiceData
        // Uses SearchServiceSkuName + ManagedServiceIdentity + SearchServicePublicInternetAccess + ETag? (version 1.3.0 default-param signature)
        /// <summary> Initializes a new instance of SearchServiceData. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceData SearchServiceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SearchServiceSkuName? searchSkuName, ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, Uri endpoint, SearchServiceHostingMode? hostingMode, SearchServiceComputeType? computeType, SearchServicePublicInternetAccess? publicInternetAccess, SearchServiceStatus? status, string statusDetails, SearchServiceProvisioningState? provisioningState, SearchServiceNetworkRuleSet networkRuleSet, IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections, SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, SearchSemanticSearch? semanticSearch, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources, ETag? eTag, SearchServiceUpgradeAvailable? isUpgradeAvailable, DateTimeOffset? serviceUpgradedOn)
        {
            return SearchServiceData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                searchSkuName: searchSkuName,
                identity: default,
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
                serviceUpgradedOn: serviceUpgradedOn);
        }

        // Backward-compat factory overload #2 for SearchServiceData
        // Uses SearchSkuName + ManagedServiceIdentity + SearchServicePublicNetworkAccess + IEnumerable<SearchServiceIPRule> (compact, no endpoint/computeType/dataExfiltration)
        /// <summary> Initializes a new instance of SearchServiceData. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceData SearchServiceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName, ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, SearchServiceHostingMode? hostingMode, SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status, string statusDetails, SearchServiceProvisioningState? provisioningState, IEnumerable<SearchServiceIPRule> ipRules, SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, SearchSemanticSearch? semanticSearch, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources)
        {
            var networkRuleSet = ipRules != null ? new SearchServiceNetworkRuleSet() : null;
            if (networkRuleSet != null)
                foreach (var rule in ipRules)
                    networkRuleSet.IPRules.Add(rule);

            return SearchServiceData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                searchSkuName: skuName.HasValue ? new SearchServiceSkuName(skuName.Value.ToSerialString()) : default(SearchServiceSkuName?),
                identity: default,
                replicaCount: replicaCount,
                partitionCount: partitionCount,
                hostingMode: hostingMode,
                publicInternetAccess: publicNetworkAccess.HasValue ? new SearchServicePublicInternetAccess(publicNetworkAccess.Value.ToSerialString()) : default(SearchServicePublicInternetAccess?),
                status: status,
                statusDetails: statusDetails,
                provisioningState: provisioningState,
                networkRuleSet: networkRuleSet,
                encryptionWithCmk: encryptionWithCmk,
                isLocalAuthDisabled: isLocalAuthDisabled,
                authOptions: authOptions,
                semanticSearch: semanticSearch,
                privateEndpointConnections: privateEndpointConnections,
                sharedPrivateLinkResources: sharedPrivateLinkResources);
        }

        // Backward-compat factory overload #3 for SearchServiceData
        // Uses SearchSkuName + ManagedServiceIdentity + SearchServicePublicNetworkAccess + Uri + ComputeType + DataExfiltration + bool? upgradeAvailable
        /// <summary> Initializes a new instance of SearchServiceData. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceData SearchServiceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName, ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, Uri endpoint, SearchServiceHostingMode? hostingMode, SearchServiceComputeType? computeType, SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status, string statusDetails, SearchServiceProvisioningState? provisioningState, IEnumerable<SearchServiceIPRule> ipRules, IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections, SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, SearchSemanticSearch? semanticSearch, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources, bool? upgradeAvailable, DateTimeOffset? serviceUpgradeOn)
        {
            var networkRuleSet = ipRules != null ? new SearchServiceNetworkRuleSet() : null;
            if (networkRuleSet != null)
                foreach (var rule in ipRules)
                    networkRuleSet.IPRules.Add(rule);

            return SearchServiceData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                searchSkuName: skuName.HasValue ? new SearchServiceSkuName(skuName.Value.ToSerialString()) : default(SearchServiceSkuName?),
                identity: default,
                replicaCount: replicaCount,
                partitionCount: partitionCount,
                endpoint: endpoint,
                hostingMode: hostingMode,
                computeType: computeType,
                publicInternetAccess: publicNetworkAccess.HasValue ? new SearchServicePublicInternetAccess(publicNetworkAccess.Value.ToSerialString()) : default(SearchServicePublicInternetAccess?),
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
                isUpgradeAvailable: upgradeAvailable.HasValue ? (upgradeAvailable.Value ? new SearchServiceUpgradeAvailable("true") : new SearchServiceUpgradeAvailable("false")) : default(SearchServiceUpgradeAvailable?),
                serviceUpgradedOn: serviceUpgradeOn);
        }

        // Backward-compat factory overload #1 for SearchServicePatch
        // Uses SearchServiceSkuName + ManagedServiceIdentity + SearchServicePublicInternetAccess + ETag?
        /// <summary> Initializes a new instance of SearchServicePatch. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServicePatch SearchServicePatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SearchServiceSkuName? searchSkuName, ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, Uri endpoint, SearchServiceHostingMode? hostingMode, SearchServiceComputeType? computeType, SearchServicePublicInternetAccess? publicInternetAccess, SearchServiceStatus? status, string statusDetails, SearchServiceProvisioningState? provisioningState, SearchServiceNetworkRuleSet networkRuleSet, IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections, SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, SearchSemanticSearch? semanticSearch, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources, ETag? eTag, SearchServiceUpgradeAvailable? isUpgradeAvailable, DateTimeOffset? serviceUpgradedOn)
        {
            return SearchServicePatch(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                searchSkuName: searchSkuName,
                identity: default,
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
                tags: tags,
                location: location.ToString());
        }

        // Backward-compat factory overload #2 for SearchServicePatch
        // Uses SearchSkuName + ManagedServiceIdentity + SearchServicePublicNetworkAccess + IEnumerable<SearchServiceIPRule> (compact)
        /// <summary> Initializes a new instance of SearchServicePatch. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServicePatch SearchServicePatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName, ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, SearchServiceHostingMode? hostingMode, SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status, string statusDetails, SearchServiceProvisioningState? provisioningState, IEnumerable<SearchServiceIPRule> ipRules, SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, SearchSemanticSearch? semanticSearch, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources)
        {
            var networkRuleSet = ipRules != null ? new SearchServiceNetworkRuleSet() : null;
            if (networkRuleSet != null)
                foreach (var rule in ipRules)
                    networkRuleSet.IPRules.Add(rule);

            return SearchServicePatch(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                searchSkuName: skuName.HasValue ? new SearchServiceSkuName(skuName.Value.ToSerialString()) : default(SearchServiceSkuName?),
                identity: default,
                replicaCount: replicaCount,
                partitionCount: partitionCount,
                hostingMode: hostingMode,
                publicInternetAccess: publicNetworkAccess.HasValue ? new SearchServicePublicInternetAccess(publicNetworkAccess.Value.ToSerialString()) : default(SearchServicePublicInternetAccess?),
                status: status,
                statusDetails: statusDetails,
                provisioningState: provisioningState,
                networkRuleSet: networkRuleSet,
                encryptionWithCmk: encryptionWithCmk,
                isLocalAuthDisabled: isLocalAuthDisabled,
                authOptions: authOptions,
                semanticSearch: semanticSearch,
                privateEndpointConnections: privateEndpointConnections,
                sharedPrivateLinkResources: sharedPrivateLinkResources,
                tags: tags,
                location: location.ToString());
        }

        // Backward-compat factory overload #3 for SearchServicePatch
        // Uses SearchSkuName + ManagedServiceIdentity + SearchServicePublicNetworkAccess + Uri + ComputeType + DataExfiltration + bool? upgradeAvailable
        /// <summary> Initializes a new instance of SearchServicePatch. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServicePatch SearchServicePatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName, ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, Uri endpoint, SearchServiceHostingMode? hostingMode, SearchServiceComputeType? computeType, SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status, string statusDetails, SearchServiceProvisioningState? provisioningState, IEnumerable<SearchServiceIPRule> ipRules, IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections, SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, SearchSemanticSearch? semanticSearch, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources, bool? upgradeAvailable, DateTimeOffset? serviceUpgradeOn)
        {
            var networkRuleSet = ipRules != null ? new SearchServiceNetworkRuleSet() : null;
            if (networkRuleSet != null)
                foreach (var rule in ipRules)
                    networkRuleSet.IPRules.Add(rule);

            return SearchServicePatch(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                searchSkuName: skuName.HasValue ? new SearchServiceSkuName(skuName.Value.ToSerialString()) : default(SearchServiceSkuName?),
                identity: default,
                replicaCount: replicaCount,
                partitionCount: partitionCount,
                endpoint: endpoint,
                hostingMode: hostingMode,
                computeType: computeType,
                publicInternetAccess: publicNetworkAccess.HasValue ? new SearchServicePublicInternetAccess(publicNetworkAccess.Value.ToSerialString()) : default(SearchServicePublicInternetAccess?),
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
                isUpgradeAvailable: upgradeAvailable.HasValue ? (upgradeAvailable.Value ? new SearchServiceUpgradeAvailable("true") : new SearchServiceUpgradeAvailable("false")) : default(SearchServiceUpgradeAvailable?),
                serviceUpgradedOn: serviceUpgradeOn,
                tags: tags,
                location: location.ToString());
        }

        // Backward-compat factory overload for QuotaUsageResult
        // Uses ResourceIdentifier instead of string for id parameter
        /// <summary> Initializes a new instance of QuotaUsageResult. </summary>
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
