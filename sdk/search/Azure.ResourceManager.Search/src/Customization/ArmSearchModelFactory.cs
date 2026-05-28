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
        /// <summary> Initializes a new instance of <see cref="Search.SearchServiceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="skuName"> The SKU of the search service, which determines billing rate and capacity limits. This property is required when creating a new search service. </param>
        /// <param name="identity"> The identity of the resource. Current supported identity types: None, SystemAssigned. </param>
        /// <param name="replicaCount"> The number of replicas in the search service. If specified, it must be a value between 1 and 12 inclusive for standard SKUs or between 1 and 3 inclusive for basic SKU. </param>
        /// <param name="partitionCount"> The number of partitions in the search service; if specified, it can be 1, 2, 3, 4, 6, or 12. Values greater than 1 are only valid for standard SKUs. For 'standard3' services with hostingMode set to 'highDensity', the allowed values are between 1 and 3. </param>
        /// <param name="endpoint"> The endpoint of the Azure AI Search service. </param>
        /// <param name="hostingMode"> Applicable only for the standard3 SKU. You can set this property to enable up to 3 high density partitions that allow up to 1000 indexes, which is much higher than the maximum indexes allowed for any other SKU. For the standard3 SKU, the value is either 'default' or 'highDensity'. For all other SKUs, this value must be 'default'. </param>
        /// <param name="computeType"> Configure this property to support the search service using either the default compute or Azure Confidential Compute. </param>
        /// <param name="publicNetworkAccess"> This value can be set to 'enabled' to avoid breaking changes on existing customer resources and templates. If set to 'disabled', traffic over public interface is not allowed, and private endpoint connections would be the exclusive access method. </param>
        /// <param name="status"> The status of the search service. Possible values include: 'running': The search service is running and no provisioning operations are underway. 'provisioning': The search service is being provisioned or scaled up or down. 'deleting': The search service is being deleted. 'degraded': The search service is degraded. This can occur when the underlying search units are not healthy. The search service is most likely operational, but performance might be slow and some requests might be dropped. 'disabled': The search service is disabled. In this state, the service will reject all API requests. 'error': The search service is in an error state. If your service is in the degraded, disabled, or error states, Microsoft is actively investigating the underlying issue. Dedicated services in these states are still chargeable based on the number of search units provisioned. </param>
        /// <param name="statusDetails"> The details of the search service status. </param>
        /// <param name="provisioningState"> The state of the last provisioning operation performed on the search service. Provisioning is an intermediate state that occurs while service capacity is being established. After capacity is set up, provisioningState changes to either 'succeeded' or 'failed'. Client applications can poll provisioning status (the recommended polling interval is from 30 seconds to one minute) by using the Get Search Service operation to see when an operation is completed. If you are using the free service, this value tends to come back as 'succeeded' directly in the call to Create search service. This is because the free service uses capacity that is already set up. </param>
        /// <param name="ipRules"> Network-specific rules that determine how the search service may be reached. </param>
        /// <param name="dataExfiltrationProtections"> A list of data exfiltration scenarios that are explicitly disallowed for the search service. Currently, the only supported value is 'All' to disable all possible data export scenarios with more fine grained controls planned for the future. </param>
        /// <param name="encryptionWithCmk"> Specifies any policy regarding encryption of resources (such as indexes) using customer manager keys within a search service. </param>
        /// <param name="isLocalAuthDisabled"> When set to true, calls to the search service will not be permitted to utilize API keys for authentication. This cannot be set to true if 'dataPlaneAuthOptions' are defined. </param>
        /// <param name="authOptions"> Defines the options for how the data plane API of a search service authenticates requests. This cannot be set if 'disableLocalAuth' is set to true. </param>
        /// <param name="privateEndpointConnections"> The list of private endpoint connections to the search service. </param>
        /// <param name="semanticSearch"> Sets options that control the availability of semantic search. This configuration is only possible for certain search SKUs in certain locations. </param>
        /// <param name="sharedPrivateLinkResources"> The list of shared private link resources managed by the search service. </param>
        /// <param name="upgradeAvailable"> Indicates whether or not the search service has an upgrade available. </param>
        /// <param name="serviceUpgradeOn"> The date and time the search service was last upgraded. This field will be null until the service gets upgraded for the first time. </param>
        public static SearchServiceData SearchServiceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName, ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, Uri endpoint, SearchServiceHostingMode? hostingMode, SearchServiceComputeType? computeType, SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status, string statusDetails, SearchServiceProvisioningState? provisioningState, IEnumerable<SearchServiceIPRule> ipRules, IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections, SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, SearchSemanticSearch? semanticSearch, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources, bool? upgradeAvailable, DateTimeOffset? serviceUpgradeOn)
        {
            return SearchServiceData(id,
                                     name,
                                     resourceType,
                                     systemData,
                                     tags,
                                     location,
                                     // ternary operator must use a nullable instance of the type to avoid triggering the implicit cast on the null
                                     skuName.HasValue ? new SearchServiceSkuName?(skuName.Value.ToSerialString()) : null,
                                     identity,
                                     replicaCount,
                                     partitionCount,
                                     endpoint,
                                     hostingMode,
                                     computeType,
                                     // ternary operator must use a nullable instance of the type to avoid triggering the implicit cast on the null
                                     publicNetworkAccess.HasValue ? new SearchServicePublicInternetAccess?(publicNetworkAccess.Value.ToSerialString()) : null,
                                     status,
                                     statusDetails,
                                     provisioningState,
                                     ipRules != null ? new SearchServiceNetworkRuleSet(ipRules?.ToList(), null, null) : null,
                                     dataExfiltrationProtections,
                                     encryptionWithCmk,
                                     isLocalAuthDisabled,
                                     authOptions,
                                     semanticSearch,
                                     privateEndpointConnections,
                                     sharedPrivateLinkResources,
                                     null);
        }

        /// <summary> Initializes a new instance of <see cref="Search.SearchServiceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="skuName"> The SKU of the search service, which determines billing rate and capacity limits. This property is required when creating a new search service. </param>
        /// <param name="identity"> The identity of the resource. Current supported identity types: None, SystemAssigned. </param>
        /// <param name="replicaCount"> The number of replicas in the search service. If specified, it must be a value between 1 and 12 inclusive for standard SKUs or between 1 and 3 inclusive for basic SKU. </param>
        /// <param name="partitionCount"> The number of partitions in the search service; if specified, it can be 1, 2, 3, 4, 6, or 12. Values greater than 1 are only valid for standard SKUs. For 'standard3' services with hostingMode set to 'highDensity', the allowed values are between 1 and 3. </param>
        /// <param name="hostingMode"> Applicable only for the standard3 SKU. You can set this property to enable up to 3 high density partitions that allow up to 1000 indexes, which is much higher than the maximum indexes allowed for any other SKU. For the standard3 SKU, the value is either 'default' or 'highDensity'. For all other SKUs, this value must be 'default'. </param>
        /// <param name="publicNetworkAccess"> This value can be set to 'enabled' to avoid breaking changes on existing customer resources and templates. If set to 'disabled', traffic over public interface is not allowed, and private endpoint connections would be the exclusive access method. </param>
        /// <param name="status"> The status of the search service. Possible values include: 'running': The search service is running and no provisioning operations are underway. 'provisioning': The search service is being provisioned or scaled up or down. 'deleting': The search service is being deleted. 'degraded': The search service is degraded. This can occur when the underlying search units are not healthy. The search service is most likely operational, but performance might be slow and some requests might be dropped. 'disabled': The search service is disabled. In this state, the service will reject all API requests. 'error': The search service is in an error state. If your service is in the degraded, disabled, or error states, Microsoft is actively investigating the underlying issue. Dedicated services in these states are still chargeable based on the number of search units provisioned. </param>
        /// <param name="statusDetails"> The details of the search service status. </param>
        /// <param name="provisioningState"> The state of the last provisioning operation performed on the search service. Provisioning is an intermediate state that occurs while service capacity is being established. After capacity is set up, provisioningState changes to either 'succeeded' or 'failed'. Client applications can poll provisioning status (the recommended polling interval is from 30 seconds to one minute) by using the Get Search Service operation to see when an operation is completed. If you are using the free service, this value tends to come back as 'succeeded' directly in the call to Create search service. This is because the free service uses capacity that is already set up. </param>
        /// <param name="ipRules"> Network-specific rules that determine how the search service may be reached. </param>
        /// <param name="encryptionWithCmk"> Specifies any policy regarding encryption of resources (such as indexes) using customer manager keys within a search service. </param>
        /// <param name="isLocalAuthDisabled"> When set to true, calls to the search service will not be permitted to utilize API keys for authentication. This cannot be set to true if 'dataPlaneAuthOptions' are defined. </param>
        /// <param name="authOptions"> Defines the options for how the data plane API of a search service authenticates requests. This cannot be set if 'disableLocalAuth' is set to true. </param>
        /// <param name="privateEndpointConnections"> The list of private endpoint connections to the search service. </param>
        /// <param name="semanticSearch"> Sets options that control the availability of semantic search. This configuration is only possible for certain search SKUs in certain locations. </param>
        /// <param name="sharedPrivateLinkResources"> The list of shared private link resources managed by the search service. </param>
        /// <returns> A new <see cref="Search.SearchServiceData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceData SearchServiceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName, ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, SearchServiceHostingMode? hostingMode, SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status, string statusDetails, SearchServiceProvisioningState? provisioningState, IEnumerable<SearchServiceIPRule> ipRules, SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, SearchSemanticSearch? semanticSearch, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources)
        {
            return SearchServiceData(id,
                                     name,
                                     resourceType,
                                     systemData,
                                     tags,
                                     location,
                                     // ternary operator must use a nullable instance of the type to avoid triggering the implicit cast on the null
                                     skuName.HasValue ? new SearchServiceSkuName?(skuName.Value.ToSerialString()) : null,
                                     identity,
                                     replicaCount,
                                     partitionCount,
                                     null,
                                     hostingMode,
                                     null,
                                     // ternary operator must use a nullable instance of the type to avoid triggering the implicit cast on the null
                                     publicNetworkAccess.HasValue ? new SearchServicePublicInternetAccess?(publicNetworkAccess.Value.ToSerialString()) : null,
                                     status,
                                     statusDetails,
                                     provisioningState,
                                     ipRules != null ? new SearchServiceNetworkRuleSet(ipRules?.ToList(), null, null) : null,
                                     null,
                                     encryptionWithCmk,
                                     isLocalAuthDisabled,
                                     authOptions,
                                     semanticSearch,
                                     privateEndpointConnections,
                                     sharedPrivateLinkResources,
                                     null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SearchServicePatch"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="skuName"> The SKU of the search service, which determines billing rate and capacity limits. This property is required when creating a new search service. </param>
        /// <param name="identity"> Details about the search service identity. A null value indicates that the search service has no identity assigned. </param>
        /// <param name="replicaCount"> The number of replicas in the search service. If specified, it must be a value between 1 and 12 inclusive for standard SKUs or between 1 and 3 inclusive for basic SKU. </param>
        /// <param name="partitionCount"> The number of partitions in the search service; if specified, it can be 1, 2, 3, 4, 6, or 12. Values greater than 1 are only valid for standard SKUs. For 'standard3' services with hostingMode set to 'highDensity', the allowed values are between 1 and 3. </param>
        /// <param name="endpoint"> The endpoint of the Azure AI Search service. </param>
        /// <param name="hostingMode"> Applicable only for the standard3 SKU. You can set this property to enable up to 3 high density partitions that allow up to 1000 indexes, which is much higher than the maximum indexes allowed for any other SKU. For the standard3 SKU, the value is either 'default' or 'highDensity'. For all other SKUs, this value must be 'default'. </param>
        /// <param name="computeType"> Configure this property to support the search service using either the default compute or Azure Confidential Compute. </param>
        /// <param name="publicNetworkAccess"> This value can be set to 'enabled' to avoid breaking changes on existing customer resources and templates. If set to 'disabled', traffic over public interface is not allowed, and private endpoint connections would be the exclusive access method. </param>
        /// <param name="status"> The status of the search service. Possible values include: 'running': The search service is running and no provisioning operations are underway. 'provisioning': The search service is being provisioned or scaled up or down. 'deleting': The search service is being deleted. 'degraded': The search service is degraded. This can occur when the underlying search units are not healthy. The search service is most likely operational, but performance might be slow and some requests might be dropped. 'disabled': The search service is disabled. In this state, the service will reject all API requests. 'error': The search service is in an error state. 'stopped': The search service is in a subscription that's disabled. If your service is in the degraded, disabled, or error states, it means the Azure AI Search team is actively investigating the underlying issue. Dedicated services in these states are still chargeable based on the number of search units provisioned. </param>
        /// <param name="statusDetails"> The details of the search service status. </param>
        /// <param name="provisioningState"> The state of the last provisioning operation performed on the search service. Provisioning is an intermediate state that occurs while service capacity is being established. After capacity is set up, provisioningState changes to either 'Succeeded' or 'Failed'. Client applications can poll provisioning status (the recommended polling interval is from 30 seconds to one minute) by using the Get Search Service operation to see when an operation is completed. If you are using the free service, this value tends to come back as 'Succeeded' directly in the call to Create search service. This is because the free service uses capacity that is already set up. </param>
        /// <param name="ipRules"> Network-specific rules that determine how the search service may be reached. </param>
        /// <param name="dataExfiltrationProtections"> A list of data exfiltration scenarios that are explicitly disallowed for the search service. Currently, the only supported value is 'All' to disable all possible data export scenarios with more fine grained controls planned for the future. </param>
        /// <param name="encryptionWithCmk"> Specifies any policy regarding encryption of resources (such as indexes) using customer manager keys within a search service. </param>
        /// <param name="isLocalAuthDisabled"> When set to true, calls to the search service will not be permitted to utilize API keys for authentication. This cannot be set to true if 'dataPlaneAuthOptions' are defined. </param>
        /// <param name="authOptions"> Defines the options for how the data plane API of a search service authenticates requests. This cannot be set if 'disableLocalAuth' is set to true. </param>
        /// <param name="semanticSearch"> Sets options that control the availability of semantic search. This configuration is only possible for certain Azure AI Search SKUs in certain locations. </param>
        /// <param name="privateEndpointConnections"> The list of private endpoint connections to the Azure AI Search service. </param>
        /// <param name="sharedPrivateLinkResources"> The list of shared private link resources managed by the Azure AI Search service. </param>
        /// <param name="upgradeAvailable"> Indicates whether or not the search service has an upgrade available. </param>
        /// <param name="serviceUpgradeOn"> The date and time the search service was last upgraded. This field will be null until the service gets upgraded for the first time. </param>
        /// <returns> A new <see cref="Models.SearchServicePatch"/> instance for mocking. </returns>
        public static SearchServicePatch SearchServicePatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName, ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, Uri endpoint, SearchServiceHostingMode? hostingMode, SearchServiceComputeType? computeType, SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status, string statusDetails, SearchServiceProvisioningState? provisioningState, IEnumerable<SearchServiceIPRule> ipRules, IEnumerable<SearchDataExfiltrationProtection> dataExfiltrationProtections, SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, SearchSemanticSearch? semanticSearch, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources, bool? upgradeAvailable, DateTimeOffset? serviceUpgradeOn)
        {
            tags ??= new Dictionary<string, string>();
            dataExfiltrationProtections ??= new List<SearchDataExfiltrationProtection>();
            privateEndpointConnections ??= new List<SearchPrivateEndpointConnectionData>();
            sharedPrivateLinkResources ??= new List<SharedSearchServicePrivateLinkResourceData>();

            return SearchServicePatch(id,
                                      name,
                                      resourceType,
                                      systemData,
                                      tags,
                                      location,
                                      skuName.ToString(),
                                      identity,
                                      replicaCount,
                                      partitionCount,
                                      endpoint,
                                      hostingMode,
                                      computeType,
                                      publicNetworkAccess.ToString(),
                                      status,
                                      statusDetails,
                                      provisioningState,
                                      (ipRules != null ? new SearchServiceNetworkRuleSet(ipRules?.ToList(), null, null) : null),
                                      dataExfiltrationProtections,
                                      encryptionWithCmk,
                                      isLocalAuthDisabled,
                                      authOptions,
                                      semanticSearch,
                                      privateEndpointConnections,
                                      sharedPrivateLinkResources,
                                      null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SearchServicePatch"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="skuName"> The SKU of the search service, which determines the billing rate and capacity limits. This property is required when creating a new search service. </param>
        /// <param name="identity"> The identity of the resource. Current supported identity types: None, SystemAssigned. </param>
        /// <param name="replicaCount"> The number of replicas in the search service. If specified, it must be a value between 1 and 12 inclusive for standard SKUs or between 1 and 3 inclusive for basic SKU. </param>
        /// <param name="partitionCount"> The number of partitions in the search service; if specified, it can be 1, 2, 3, 4, 6, or 12. Values greater than 1 are only valid for standard SKUs. For 'standard3' services with hostingMode set to 'highDensity', the allowed values are between 1 and 3. </param>
        /// <param name="hostingMode"> Applicable only for the standard3 SKU. You can set this property to enable up to 3 high density partitions that allow up to 1000 indexes, which is much higher than the maximum indexes allowed for any other SKU. For the standard3 SKU, the value is either 'default' or 'highDensity'. For all other SKUs, this value must be 'default'. </param>
        /// <param name="publicNetworkAccess"> This value can be set to 'enabled' to avoid breaking changes on existing customer resources and templates. If set to 'disabled', traffic over public interface is not allowed, and private endpoint connections would be the exclusive access method. </param>
        /// <param name="status"> The status of the search service. Possible values include: 'running': The search service is running and no provisioning operations are underway. 'provisioning': The search service is being provisioned or scaled up or down. 'deleting': The search service is being deleted. 'degraded': The search service is degraded. This can occur when the underlying search units are not healthy. The search service is most likely operational, but performance might be slow and some requests might be dropped. 'disabled': The search service is disabled. In this state, the service will reject all API requests. 'error': The search service is in an error state. If your service is in the degraded, disabled, or error states, Microsoft is actively investigating the underlying issue. Dedicated services in these states are still chargeable based on the number of search units provisioned. </param>
        /// <param name="statusDetails"> The details of the search service status. </param>
        /// <param name="provisioningState"> The state of the last provisioning operation performed on the search service. Provisioning is an intermediate state that occurs while service capacity is being established. After capacity is set up, provisioningState changes to either 'succeeded' or 'failed'. Client applications can poll provisioning status (the recommended polling interval is from 30 seconds to one minute) by using the Get Search Service operation to see when an operation is completed. If you are using the free service, this value tends to come back as 'succeeded' directly in the call to Create search service. This is because the free service uses capacity that is already set up. </param>
        /// <param name="ipRules"> Network-specific rules that determine how the search service may be reached. </param>
        /// <param name="encryptionWithCmk"> Specifies any policy regarding encryption of resources (such as indexes) using customer manager keys within a search service. </param>
        /// <param name="isLocalAuthDisabled"> When set to true, calls to the search service will not be permitted to utilize API keys for authentication. This cannot be set to true if 'dataPlaneAuthOptions' are defined. </param>
        /// <param name="authOptions"> Defines the options for how the data plane API of a search service authenticates requests. This cannot be set if 'disableLocalAuth' is set to true. </param>
        /// <param name="privateEndpointConnections"> The list of private endpoint connections to the search service. </param>
        /// <param name="semanticSearch"> Sets options that control the availability of semantic search. This configuration is only possible for certain search SKUs in certain locations. </param>
        /// <param name="sharedPrivateLinkResources"> The list of shared private link resources managed by the search service. </param>
        /// <returns> A new <see cref="Models.SearchServicePatch"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServicePatch SearchServicePatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, SearchSkuName? skuName, ManagedServiceIdentity identity, int? replicaCount, int? partitionCount, SearchServiceHostingMode? hostingMode, SearchServicePublicNetworkAccess? publicNetworkAccess, SearchServiceStatus? status, string statusDetails, SearchServiceProvisioningState? provisioningState, IEnumerable<SearchServiceIPRule> ipRules, SearchEncryptionWithCmk encryptionWithCmk, bool? isLocalAuthDisabled, SearchAadAuthDataPlaneAuthOptions authOptions, IEnumerable<SearchPrivateEndpointConnectionData> privateEndpointConnections, SearchSemanticSearch? semanticSearch, IEnumerable<SharedSearchServicePrivateLinkResourceData> sharedPrivateLinkResources)
        {
            return SearchServicePatch(id,
                                      name,
                                      resourceType,
                                      systemData,
                                      tags,
                                      location,
                                      skuName.ToString(),
                                      identity,
                                      replicaCount,
                                      partitionCount,
                                      null,
                                      hostingMode,
                                      null,
                                      publicNetworkAccess.ToString(),
                                      status,
                                      statusDetails,
                                      provisioningState,
                                      (ipRules != null ? new SearchServiceNetworkRuleSet(ipRules?.ToList(), null, null) : null),
                                      null,
                                      encryptionWithCmk,
                                      isLocalAuthDisabled,
                                      authOptions,
                                      semanticSearch,
                                      privateEndpointConnections,
                                      sharedPrivateLinkResources,
                                      null);
        }
    }
}
