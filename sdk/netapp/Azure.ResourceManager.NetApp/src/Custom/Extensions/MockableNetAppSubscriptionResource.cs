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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppSubscriptionQuotaItem>> GetNetAppSubscriptionQuotaLimitAsync(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            Response<NetAppResourceQuotaLimitResource> response = await GetNetAppResourceQuotaLimitAsync(location, quotaLimitName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(ToLegacyQuotaItem(response.Value?.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Gets the default and current quota limit for a subscription and location.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimit(AzureLocation location, string quotaLimitName, CancellationToken cancellationToken = default)
        {
            Response<NetAppResourceQuotaLimitResource> response = GetNetAppResourceQuotaLimit(location, quotaLimitName, cancellationToken);
            return Response.FromValue(ToLegacyQuotaItem(response.Value?.Data), response.GetRawResponse());
        }

        /// <summary>
        /// Lists quota limits for a subscription and location.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimitsAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            return new LegacyQuotaItemAsyncPageable(this, location, cancellationToken);
        }

        /// <summary>
        /// Lists quota limits for a subscription and location.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppSubscriptionQuotaItem> GetNetAppSubscriptionQuotaLimits(AzureLocation location, CancellationToken cancellationToken = default)
        {
            IEnumerable<Page<NetAppSubscriptionQuotaItem>> Pages()
            {
                foreach (Page<NetAppResourceQuotaLimitResource> page in GetNetAppResourceQuotaLimits(location).GetAll(cancellationToken).AsPages())
                {
                    yield return Page<NetAppSubscriptionQuotaItem>.FromValues(
                        page.Values.Select(item => ToLegacyQuotaItem(item.Data)).ToList(),
                        page.ContinuationToken,
                        page.GetRawResponse());
                }
            }

            return Pageable<NetAppSubscriptionQuotaItem>.FromPages(Pages());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NetAppResourceQuotaLimitResource> GetNetAppQuotaLimitAsync(AzureLocation location, string quotaLimitName)
        {
            Response<NetAppResourceQuotaLimitResource> response = await GetNetAppResourceQuotaLimitAsync(location, quotaLimitName, default).ConfigureAwait(false);
            return response.Value;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppResourceQuotaLimitResource> GetNetAppQuotaLimitsAsync(AzureLocation location)
        {
            return GetNetAppResourceQuotaLimits(location).GetAllAsync();
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

        private class LegacyQuotaItemAsyncPageable : AsyncPageable<NetAppSubscriptionQuotaItem>
        {
            private readonly MockableNetAppSubscriptionResource _parent;
            private readonly AzureLocation _location;
            private readonly CancellationToken _cancellationToken;

            public LegacyQuotaItemAsyncPageable(MockableNetAppSubscriptionResource parent, AzureLocation location, CancellationToken cancellationToken)
            {
                _parent = parent;
                _location = location;
                _cancellationToken = cancellationToken;
            }

            public override async IAsyncEnumerable<Page<NetAppSubscriptionQuotaItem>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await foreach (Page<NetAppResourceQuotaLimitResource> page in _parent.GetNetAppResourceQuotaLimits(_location).GetAllAsync(_cancellationToken).AsPages().ConfigureAwait(false))
                {
                    yield return Page<NetAppSubscriptionQuotaItem>.FromValues(
                        page.Values.Select(item => ToLegacyQuotaItem(item.Data)).ToList(),
                        page.ContinuationToken,
                        page.GetRawResponse());
                }
            }
        }
    }
}
