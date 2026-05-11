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
        //
        // These public ArmClient extensions are the static counterparts to the virtual methods
        // in MockableNetAppArmClient. Keep this block aligned 1:1 with that mockable surface.
        // The generated resource types do not always get ArmClient ID-based extension methods;
        // keep these shims until https://github.com/Azure/azure-sdk-for-net/issues/59143 is fixed.

        /// <summary>
        /// Gets an object representing a <see cref="NetAppAccountBackupResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NetAppAccountBackupResource.CreateResourceIdentifier" /> to create a <see cref="NetAppAccountBackupResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NetAppAccountBackupResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppAccountBackupResource GetNetAppAccountBackupResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableNetAppArmClient(client).GetNetAppAccountBackupResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="NetAppVolumeBackupResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NetAppVolumeBackupResource.CreateResourceIdentifier" /> to create a <see cref="NetAppVolumeBackupResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NetAppVolumeBackupResource" /> object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetAppVolumeBackupResource GetNetAppVolumeBackupResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableNetAppArmClient(client).GetNetAppVolumeBackupResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="NetAppVolumeResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="NetAppVolumeResource.CreateResourceIdentifier" /> to create a <see cref="NetAppVolumeResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NetAppVolumeResource" /> object. </returns>
        // TODO: Remove when the generator emits this id-based getter.
        // https://github.com/Azure/azure-sdk-for-net/issues/59143
        public static NetAppVolumeResource GetNetAppVolumeResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableNetAppArmClient(client).GetNetAppVolumeResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="NetAppSubscriptionQuotaItemResource" /> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="NetAppSubscriptionQuotaItemResource" /> object. </returns>
        // TODO: Remove when the generator emits this id-based getter.
        // https://github.com/Azure/azure-sdk-for-net/issues/59143
        public static NetAppSubscriptionQuotaItemResource GetNetAppSubscriptionQuotaItemResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMockableNetAppArmClient(client).GetNetAppSubscriptionQuotaItemResource(id);
        }

        // ---- AzureLocation backward-compat extension methods ----
        //
        // The remaining blocks are the public static counterparts to the virtual shims in
        // MockableNetAppSubscriptionResource, not MockableNetAppArmClient. Some provider-action
        // methods should be generated by the emitter but are currently dropped; keep these shims
        // until https://github.com/Azure/azure-sdk-for-net/issues/59144 is fixed.

        // ---- Check Availability extension methods ----

        /// <summary> Check if a file path is available. </summary>
        public static async Task<Response<NetAppCheckAvailabilityResult>> CheckNetAppFilePathAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, NetAppFilePathAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).CheckNetAppFilePathAvailabilityAsync(location, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Check if a file path is available. </summary>
        public static Response<NetAppCheckAvailabilityResult> CheckNetAppFilePathAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, NetAppFilePathAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).CheckNetAppFilePathAvailability(location, content, cancellationToken);
        }

        /// <summary> Check if a resource name is available. </summary>
        public static async Task<Response<NetAppCheckAvailabilityResult>> CheckNetAppNameAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, NetAppNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).CheckNetAppNameAvailabilityAsync(location, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Check if a resource name is available. </summary>
        public static Response<NetAppCheckAvailabilityResult> CheckNetAppNameAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, NetAppNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).CheckNetAppNameAvailability(location, content, cancellationToken);
        }

        /// <summary> Check if a quota is available. </summary>
        public static async Task<Response<NetAppCheckAvailabilityResult>> CheckNetAppQuotaAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, NetAppQuotaAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).CheckNetAppQuotaAvailabilityAsync(location, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Check if a quota is available. </summary>
        public static Response<NetAppCheckAvailabilityResult> CheckNetAppQuotaAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, NetAppQuotaAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).CheckNetAppQuotaAvailability(location, content, cancellationToken);
        }

        // ---- Region Info extension methods ----

        /// <summary> Provides storage to network proximity and target region information. </summary>
        public static async Task<Response<NetAppRegionInfo>> QueryRegionInfoNetAppResourceAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).QueryRegionInfoNetAppResourceAsync(location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Provides storage to network proximity and target region information. </summary>
        public static Response<NetAppRegionInfo> QueryRegionInfoNetAppResource(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).QueryRegionInfoNetAppResource(location, cancellationToken);
        }

        /// <summary> Gets the region info resources for a subscription and location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetRegionInfoResources is not supported. Use GetRegionInfoResource instead.", false)]
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
        public static async Task<Response<NetworkSiblingSet>> QueryNetworkSiblingSetNetAppResourceAsync(this SubscriptionResource subscriptionResource, AzureLocation location, QueryNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).QueryNetworkSiblingSetNetAppResourceAsync(location, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get details of the specified network sibling set. </summary>
        public static Response<NetworkSiblingSet> QueryNetworkSiblingSetNetAppResource(this SubscriptionResource subscriptionResource, AzureLocation location, QueryNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).QueryNetworkSiblingSetNetAppResource(location, content, cancellationToken);
        }

        /// <summary> Update the network features of the specified network sibling set. </summary>
        public static async Task<ArmOperation<NetworkSiblingSet>> UpdateNetworkSiblingSetNetAppResourceAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, UpdateNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).UpdateNetworkSiblingSetNetAppResourceAsync(waitUntil, location, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Update the network features of the specified network sibling set. </summary>
        public static ArmOperation<NetworkSiblingSet> UpdateNetworkSiblingSetNetAppResource(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, AzureLocation location, UpdateNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableNetAppSubscriptionResource(subscriptionResource).UpdateNetworkSiblingSetNetAppResource(waitUntil, location, content, cancellationToken);
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
#pragma warning disable CS0618 // signatures intentionally reference the obsolete NetAppSubscriptionQuotaItemResource for back-compat
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
#pragma warning restore CS0618

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
    }
}
