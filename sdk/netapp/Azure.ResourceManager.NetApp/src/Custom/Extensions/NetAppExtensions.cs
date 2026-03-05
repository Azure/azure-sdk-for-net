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
    }
}
