// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.NetApp. </summary>
    public static partial class NetAppExtensions
    {
        // ---- ArmClient resource getters ----

        /// <summary>
        /// Gets an object representing a <see cref="NetAppAccountBackupResource" /> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppAccountBackupResource GetNetAppAccountBackupResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableNetAppArmClient(client).GetNetAppAccountBackupResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="NetAppVolumeBackupResource" /> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeBackupResource GetNetAppVolumeBackupResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableNetAppArmClient(client).GetNetAppVolumeBackupResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="NetAppVolumeResource" /> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeResource GetNetAppVolumeResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableNetAppArmClient(client).GetNetAppVolumeResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="NetAppSubscriptionQuotaItemResource" /> along with the instance operations that can be performed on it but with no data.
        /// This type has been replaced by <see cref="NetAppResourceQuotaLimitResource" />.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppSubscriptionQuotaItemResource GetNetAppSubscriptionQuotaItemResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableNetAppArmClient(client).GetNetAppSubscriptionQuotaItemResource(id);
        }

        // ---- Check Availability extension methods ----

        /// <summary> Check if a file path is available. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<NetAppCheckAvailabilityResult>> CheckNetAppFilePathAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, NetAppFilePathAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).CheckFilePathAvailabilityAsync(location.ToString(), content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Check if a file path is available. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<NetAppCheckAvailabilityResult> CheckNetAppFilePathAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, NetAppFilePathAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).CheckFilePathAvailability(location.ToString(), content, cancellationToken);
        }

        /// <summary> Check if a resource name is available. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<NetAppCheckAvailabilityResult>> CheckNetAppNameAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, NetAppNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).CheckNameAvailabilityAsync(location.ToString(), content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Check if a resource name is available. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<NetAppCheckAvailabilityResult> CheckNetAppNameAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, NetAppNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).CheckNameAvailability(location.ToString(), content, cancellationToken);
        }

        /// <summary> Check if a quota is available. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<NetAppCheckAvailabilityResult>> CheckNetAppQuotaAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, NetAppQuotaAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).CheckQuotaAvailabilityAsync(location.ToString(), content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Check if a quota is available. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<NetAppCheckAvailabilityResult> CheckNetAppQuotaAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, NetAppQuotaAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).CheckQuotaAvailability(location.ToString(), content, cancellationToken);
        }

        // ---- Region Info extension methods ----

        /// <summary> Provides storage to network proximity and target region information. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<NetAppRegionInfo>> QueryRegionInfoNetAppResourceAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).QueryRegionInfoAsync(location.ToString(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Provides storage to network proximity and target region information. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<NetAppRegionInfo> QueryRegionInfoNetAppResource(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).QueryRegionInfo(location.ToString(), cancellationToken);
        }

        /// <summary> Gets the region info resources for a subscription and location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RegionInfoResourceCollection GetRegionInfoResources(this SubscriptionResource subscriptionResource, AzureLocation location)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetRegionInfoResources(location);
        }

        /// <summary> Gets a region info resource. </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<RegionInfoResource>> GetRegionInfoResourceAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).GetRegionInfoResourceAsync(location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a region info resource. </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<RegionInfoResource> GetRegionInfoResource(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetRegionInfoResource(location, cancellationToken);
        }

        // ---- Network Sibling Set extension methods ----

        /// <summary> Get details of the specified network sibling set. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<NetworkSiblingSet>> QueryNetworkSiblingSetNetAppResourceAsync(this SubscriptionResource subscriptionResource, AzureLocation location, QueryNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).QueryNetworkSiblingSetAsync(location.ToString(), content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get details of the specified network sibling set. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<NetworkSiblingSet> QueryNetworkSiblingSetNetAppResource(this SubscriptionResource subscriptionResource, AzureLocation location, QueryNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).QueryNetworkSiblingSet(location.ToString(), content, cancellationToken);
        }

        /// <summary> Update the network features of the specified network sibling set. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<ArmOperation<NetworkSiblingSet>> UpdateNetworkSiblingSetNetAppResourceAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, UpdateNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).UpdateNetworkSiblingSetAsync(waitUntil, location.ToString(), content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Update the network features of the specified network sibling set. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation<NetworkSiblingSet> UpdateNetworkSiblingSetNetAppResource(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, UpdateNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).UpdateNetworkSiblingSet(waitUntil, location.ToString(), content, cancellationToken);
        }

        // ---- Quota Limit extension methods ----

        /// <summary> Gets the default and current quota limit. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<NetAppSubscriptionQuotaItem>> GetNetAppSubscriptionQuotaLimitAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppSubscriptionQuotaLimitAsync(location, quotaLimitName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the default and current quota limit. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimit(this SubscriptionResource subscriptionResource, AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppSubscriptionQuotaLimit(location, quotaLimitName, cancellationToken);
        }

        /// <summary> Lists quota limits for a subscription and location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimitsAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppSubscriptionQuotaLimitsAsync(location, cancellationToken);
        }

        /// <summary> Lists quota limits for a subscription and location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimits(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppSubscriptionQuotaLimits(location, cancellationToken);
        }

        /// <summary> Gets the default and current quota limit (old name). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<NetAppSubscriptionQuotaItem>> GetNetAppQuotaLimitAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppQuotaLimitAsync(location, quotaLimitName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the default and current quota limit (old name). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimit(this SubscriptionResource subscriptionResource, AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppQuotaLimit(location, quotaLimitName, cancellationToken);
        }

        /// <summary> Gets a quota limit resource (old name, returns old resource type). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<NetAppSubscriptionQuotaItemResource> GetNetAppQuotaLimitAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string quotaLimitName)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppQuotaLimitAsync(location, quotaLimitName).ConfigureAwait(false);
        }

        /// <summary> Lists quota limits (old name, returns old resource type). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<NetAppSubscriptionQuotaItemResource> GetNetAppQuotaLimitsAsync(this SubscriptionResource subscriptionResource, AzureLocation location)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppQuotaLimitsAsync(location);
        }

        /// <summary> Lists quota limits (old name). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimitsAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppQuotaLimitsAsync(location, cancellationToken);
        }

        /// <summary> Lists quota limits (old name). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimits(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppQuotaLimits(location, cancellationToken);
        }

        // ---- Resource Usage extension methods ----

        /// <summary> Gets the resource usages for a subscription and location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<NetAppUsageResult>> GetNetAppResourceUsageAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string usageType, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppResourceUsageAsync(location, usageType, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the resource usages for a subscription and location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<NetAppUsageResult> GetNetAppResourceUsage(this SubscriptionResource subscriptionResource, AzureLocation location, string usageType, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppResourceUsage(location, usageType, cancellationToken);
        }

        /// <summary> Lists the resource usages for a subscription and location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<NetAppUsageResult> GetNetAppResourceUsagesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppResourceUsagesAsync(location, cancellationToken);
        }

        /// <summary> Lists the resource usages for a subscription and location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<NetAppUsageResult> GetNetAppResourceUsages(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppResourceUsages(location, cancellationToken);
        }
    }
}
