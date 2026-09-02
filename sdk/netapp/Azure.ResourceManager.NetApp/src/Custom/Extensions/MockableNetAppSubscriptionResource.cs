// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableNetAppSubscriptionResource
    {
        // v1.15 exposed quota operations returning the legacy POCO; generated methods now
        // return resources, so these shims unwrap Data to preserve source compatibility.

        /// <summary>
        /// Gets the default and current quota limit for a subscription and location.
        /// </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="quotaLimitName"> The quota limit name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The default and current quota limit. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppSubscriptionQuotaItem>> GetNetAppSubscriptionQuotaLimitAsync(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            Response<NetAppSubscriptionQuotaItemResource> response = await GetNetAppSubscriptionQuotaItemAsync(location, quotaLimitName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ToLegacyQuotaItem(response.Value?.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Gets the default and current quota limit for a subscription and location.
        /// </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="quotaLimitName"> The quota limit name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The default and current quota limit. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimit(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            Response<NetAppSubscriptionQuotaItemResource> response = GetNetAppSubscriptionQuotaItem(location, quotaLimitName, cancellationToken);
            return Response.FromValue(ToLegacyQuotaItem(response.Value?.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Lists quota limits for a subscription and location.
        /// </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of quota limits. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimitsAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            var pageable = GetNetAppSubscriptionQuotaItems(location).GetAllAsync(cancellationToken);
            return new AsyncPageableWrapper<NetAppSubscriptionQuotaItemResource, NetAppSubscriptionQuotaItem>(pageable, item => ToLegacyQuotaItem(item.Data));
        }

        /// <summary>
        /// Lists quota limits for a subscription and location.
        /// </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of quota limits. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimits(AzureLocation location, CancellationToken cancellationToken = default)
        {
            var pageable = GetNetAppSubscriptionQuotaItems(location).GetAll(cancellationToken);
            return new PageableWrapper<NetAppSubscriptionQuotaItemResource, NetAppSubscriptionQuotaItem>(pageable, item => ToLegacyQuotaItem(item.Data));
        }

        /// <summary> Gets the default and current quota limit for a subscription and location. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="quotaLimitName"> The quota limit name. </param>
        /// <returns> The quota limit resource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NetAppSubscriptionQuotaItemResource> GetNetAppQuotaLimitAsync(AzureLocation location, string quotaLimitName)
        {
            // v1.15 quirk: this overload returned the bare resource (without Response<>) and
            // had no CancellationToken parameter. Forward to the generated async getter and
            // unwrap the Response<>.
            var response = await GetNetAppSubscriptionQuotaItemAsync(location, quotaLimitName).ConfigureAwait(false);
            return response.Value;
        }

        /// <summary> Gets the default and current quota limit for a subscription and location. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="quotaLimitName"> The quota limit name. </param>
        /// <returns> The quota limit resource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NetAppSubscriptionQuotaItemResource GetNetAppQuotaLimit(AzureLocation location, string quotaLimitName)
        {
            return GetNetAppSubscriptionQuotaItem(location, quotaLimitName).Value;
        }

        /// <summary> Lists quota limits for a subscription and location. </summary>
        /// <param name="location"> The location name. </param>
        /// <returns> A collection of quota limit resources. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppSubscriptionQuotaItemResource> GetNetAppQuotaLimitsAsync(AzureLocation location)
        {
            return GetNetAppSubscriptionQuotaItems(location).GetAllAsync();
        }

        /// <summary> Gets the default and current quota limit for a subscription and location. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="quotaLimitName"> The quota limit name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The default and current quota limit. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<NetAppSubscriptionQuotaItem>> GetNetAppQuotaLimitAsync(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimitAsync(location, quotaLimitName, cancellationToken);

        /// <summary> Gets the default and current quota limit for a subscription and location. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="quotaLimitName"> The quota limit name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The default and current quota limit. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimit(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimit(location, quotaLimitName, cancellationToken);

        /// <summary> Lists quota limits for a subscription and location. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of quota limits. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimitsAsync(AzureLocation location, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimitsAsync(location, cancellationToken);

        /// <summary> Lists quota limits for a subscription and location. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of quota limits. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimits(AzureLocation location, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimits(location, cancellationToken);

        /// <summary> Gets the region info resources for a subscription and location. </summary>
        /// <param name="location"> The location name. </param>
        /// <returns> The region info resource collection. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetRegionInfoResources is not supported. Use GetRegionInfoResource instead.", false)]
        public virtual RegionInfoResourceCollection GetRegionInfoResources(AzureLocation location)
        {
            throw new NotSupportedException("GetRegionInfoResources is not supported. Use GetRegionInfoResource instead.");
        }

        /// <summary> Gets a region info resource. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The region info resource. </returns>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<RegionInfoResource>> GetRegionInfoResourceAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("GetRegionInfoResourceAsync with AzureLocation is not supported. Use GetRegionInfoResource() instead.");
        }

        /// <summary> Gets a region info resource. </summary>
        /// <param name="location"> The location name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The region info resource. </returns>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<RegionInfoResource> GetRegionInfoResource(AzureLocation location, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("GetRegionInfoResource with AzureLocation is not supported. Use GetRegionInfoResource() instead.");
        }

        // ---- Helper types ----

        private static NetAppSubscriptionQuotaItem ToLegacyQuotaItem(NetAppSubscriptionQuotaItemData data)
        {
            if (data == null)
            {
                return null;
            }

            return new NetAppSubscriptionQuotaItem(data.Id, data.Name, data.ResourceType, data.SystemData, data.Current, data.Default, data.Usage);
        }
    }
}
