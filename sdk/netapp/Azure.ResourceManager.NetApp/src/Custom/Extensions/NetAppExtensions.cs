// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

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
        /// Gets the default and current quota limit for a subscription and location.
        /// </summary>
        /// <param name="subscriptionResource">The subscription resource.</param>
        /// <param name="location">The Azure region.</param>
        /// <param name="quotaLimitName">The name of the quota limit.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A quota item response mapped to <see cref="NetAppSubscriptionQuotaItem"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<NetAppSubscriptionQuotaItem>> GetNetAppSubscriptionQuotaLimitAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppSubscriptionQuotaLimitAsync(location, quotaLimitName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the default and current quota limit for a subscription and location.
        /// </summary>
        /// <param name="subscriptionResource">The subscription resource.</param>
        /// <param name="location">The Azure region.</param>
        /// <param name="quotaLimitName">The name of the quota limit.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A quota item response mapped to <see cref="NetAppSubscriptionQuotaItem"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimit(this SubscriptionResource subscriptionResource, AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppSubscriptionQuotaLimit(location, quotaLimitName, cancellationToken);
        }

        /// <summary>
        /// Lists quota limits for a subscription and location.
        /// </summary>
        /// <param name="subscriptionResource">The subscription resource.</param>
        /// <param name="location">The Azure region.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An async collection of <see cref="NetAppSubscriptionQuotaItem"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimitsAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppSubscriptionQuotaLimitsAsync(location, cancellationToken);
        }

        /// <summary>
        /// Lists quota limits for a subscription and location.
        /// </summary>
        /// <param name="subscriptionResource">The subscription resource.</param>
        /// <param name="location">The Azure region.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A pageable collection of <see cref="NetAppSubscriptionQuotaItem"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimits(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppSubscriptionQuotaLimits(location, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<NetAppSubscriptionQuotaItemResource> GetNetAppQuotaLimitAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string quotaLimitName)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return await GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppQuotaLimitAsync(location, quotaLimitName).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<NetAppSubscriptionQuotaItemResource> GetNetAppQuotaLimitsAsync(this SubscriptionResource subscriptionResource, AzureLocation location)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppQuotaLimitsAsync(location);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<NetAppSubscriptionQuotaItem>> GetNetAppQuotaLimitAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
            => GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppQuotaLimitAsync(location, quotaLimitName, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimit(this SubscriptionResource subscriptionResource, AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
            => GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppQuotaLimit(location, quotaLimitName, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimitsAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
            => GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppQuotaLimitsAsync(location, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimits(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
            => GetMockableNetAppSubscriptionResource(subscriptionResource).GetNetAppQuotaLimits(location, cancellationToken);
    }
}
