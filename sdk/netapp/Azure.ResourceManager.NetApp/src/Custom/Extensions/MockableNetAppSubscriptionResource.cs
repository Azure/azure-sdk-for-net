// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp.Mocking
{
    public partial class MockableNetAppSubscriptionResource
    {
        /// <summary>
        /// Gets the default and current quota limit for a subscription and location.
        /// </summary>
        /// <param name="location">The Azure region.</param>
        /// <param name="quotaLimitName">The name of the quota limit.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A quota item response mapped to <see cref="NetAppSubscriptionQuotaItem"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppSubscriptionQuotaItem>> GetNetAppSubscriptionQuotaLimitAsync(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            using var scope = NetAppResourceQuotaLimitsClientDiagnostics.CreateScope("MockableNetAppSubscriptionResource.GetNetAppSubscriptionQuotaLimit");
            scope.Start();
            try
            {
                Response<NetAppSubscriptionQuotaItemData> response = await NetAppResourceQuotaLimitsRestClient.GetAsync(Id.SubscriptionId, location, quotaLimitName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(ToLegacyQuotaItem(response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the default and current quota limit for a subscription and location.
        /// </summary>
        /// <param name="location">The Azure region.</param>
        /// <param name="quotaLimitName">The name of the quota limit.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A quota item response mapped to <see cref="NetAppSubscriptionQuotaItem"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimit(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            using var scope = NetAppResourceQuotaLimitsClientDiagnostics.CreateScope("MockableNetAppSubscriptionResource.GetNetAppSubscriptionQuotaLimit");
            scope.Start();
            try
            {
                Response<NetAppSubscriptionQuotaItemData> response = NetAppResourceQuotaLimitsRestClient.Get(Id.SubscriptionId, location, quotaLimitName, cancellationToken);
                return Response.FromValue(ToLegacyQuotaItem(response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists quota limits for a subscription and location.
        /// </summary>
        /// <param name="location">The Azure region.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An async collection of <see cref="NetAppSubscriptionQuotaItem"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimitsAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => NetAppResourceQuotaLimitsRestClient.CreateListRequest(Id.SubscriptionId, location);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => NetAppResourceQuotaLimitsRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, location);

            return GeneratorPageableHelpers.CreateAsyncPageable(
                FirstPageRequest,
                NextPageRequest,
                element => ToLegacyQuotaItem(NetAppSubscriptionQuotaItemData.DeserializeNetAppSubscriptionQuotaItemData(element)),
                NetAppResourceQuotaLimitsClientDiagnostics,
                Pipeline,
                "MockableNetAppSubscriptionResource.GetNetAppSubscriptionQuotaLimits",
                "value",
                "nextLink",
                cancellationToken);
        }

        /// <summary>
        /// Lists quota limits for a subscription and location.
        /// </summary>
        /// <param name="location">The Azure region.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A pageable collection of <see cref="NetAppSubscriptionQuotaItem"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimits(AzureLocation location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => NetAppResourceQuotaLimitsRestClient.CreateListRequest(Id.SubscriptionId, location);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => NetAppResourceQuotaLimitsRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, location);

            return GeneratorPageableHelpers.CreatePageable(
                FirstPageRequest,
                NextPageRequest,
                element => ToLegacyQuotaItem(NetAppSubscriptionQuotaItemData.DeserializeNetAppSubscriptionQuotaItemData(element)),
                NetAppResourceQuotaLimitsClientDiagnostics,
                Pipeline,
                "MockableNetAppSubscriptionResource.GetNetAppSubscriptionQuotaLimits",
                "value",
                "nextLink",
                cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NetAppSubscriptionQuotaItemResource> GetNetAppQuotaLimitAsync(AzureLocation location, string quotaLimitName)
        {
            using var scope = NetAppResourceQuotaLimitsClientDiagnostics.CreateScope("MockableNetAppSubscriptionResource.GetNetAppQuotaLimit");
            scope.Start();
            try
            {
                Response<NetAppSubscriptionQuotaItemData> response = await NetAppResourceQuotaLimitsRestClient.GetAsync(Id.SubscriptionId, location, quotaLimitName, default).ConfigureAwait(false);
                return new NetAppSubscriptionQuotaItemResource(Client, response.Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppSubscriptionQuotaItemResource> GetNetAppQuotaLimitsAsync(AzureLocation location)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => NetAppResourceQuotaLimitsRestClient.CreateListRequest(Id.SubscriptionId, location);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => NetAppResourceQuotaLimitsRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, location);

            return GeneratorPageableHelpers.CreateAsyncPageable(
                FirstPageRequest,
                NextPageRequest,
                element => new NetAppSubscriptionQuotaItemResource(Client, NetAppSubscriptionQuotaItemData.DeserializeNetAppSubscriptionQuotaItemData(element)),
                NetAppResourceQuotaLimitsClientDiagnostics,
                Pipeline,
                "MockableNetAppSubscriptionResource.GetNetAppQuotaLimits",
                "value",
                "nextLink",
                default(CancellationToken));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<NetAppSubscriptionQuotaItem>> GetNetAppQuotaLimitAsync(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimitAsync(location, quotaLimitName, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimit(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimit(location, quotaLimitName, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimitsAsync(AzureLocation location, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimitsAsync(location, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimits(AzureLocation location, CancellationToken cancellationToken = default)
            => GetNetAppSubscriptionQuotaLimits(location, cancellationToken);

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
