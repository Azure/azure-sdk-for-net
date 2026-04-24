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
        // ---- Quota Limit methods (delegating to generated methods) ----

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
        public virtual Task<NetAppSubscriptionQuotaItemResource> GetNetAppQuotaLimitAsync(AzureLocation location, string quotaLimitName)
        {
            throw new NotSupportedException("GetNetAppQuotaLimitAsync returning NetAppSubscriptionQuotaItemResource is not supported. Use GetNetAppResourceQuotaLimitAsync instead.");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppSubscriptionQuotaItemResource> GetNetAppQuotaLimitsAsync(AzureLocation location)
        {
            throw new NotSupportedException("GetNetAppQuotaLimitsAsync returning NetAppSubscriptionQuotaItemResource is not supported. Use GetNetAppResourceQuotaLimits instead.");
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

        // ---- Check Availability / Region Info / Network Sibling Set: AzureLocation backward-compat shims ----
        //
        // Why these shims exist (and why @@clientName alone cannot replace them):
        //
        // The pre-migration SDK exposed these subscription-scoped operations with an
        // AzureLocation parameter (e.g. CheckNetAppFilePathAvailability(AzureLocation, ...)).
        // The TypeSpec spec, however, declares them with the deprecated `LocationParameter`
        // template (location: string) instead of `LocationResourceParameter` (location: azureLocation).
        // The generated mockable methods therefore take `string location` and have shorter
        // names (CheckFilePathAvailability, CheckNameAvailability, QueryRegionInfo, QueryNetworkSiblingSet,
        // UpdateNetworkSiblingSet, ...).
        //
        // @@clientName in client.tsp could rename the generated methods to the v1.x names,
        // but it cannot change the parameter type from `string` to `AzureLocation`. As long as
        // the spec uses `LocationParameter`, the C# parameter remains `string`, and we'd still
        // need a custom AzureLocation overload here for source compatibility — making
        // @@clientName redundant rather than sufficient. Switching the spec to
        // `LocationResourceParameter` is a cross-language breaking change for NetApp and is not
        // in scope for this migration.
        //
        // [ForwardsClientCalls] is required so that the test framework's diagnostic-scope
        // assertions in recorded tests use the inner generated method's scope name rather than
        // the wrapper's name.

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetAppCheckAvailabilityResult>> CheckNetAppFilePathAvailabilityAsync(AzureLocation location, NetAppFilePathAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return await CheckFilePathAvailabilityAsync(location.ToString(), content, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetAppCheckAvailabilityResult> CheckNetAppFilePathAvailability(AzureLocation location, NetAppFilePathAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return CheckFilePathAvailability(location.ToString(), content, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetAppCheckAvailabilityResult>> CheckNetAppNameAvailabilityAsync(AzureLocation location, NetAppNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return await CheckNameAvailabilityAsync(location.ToString(), content, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetAppCheckAvailabilityResult> CheckNetAppNameAvailability(AzureLocation location, NetAppNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return CheckNameAvailability(location.ToString(), content, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetAppCheckAvailabilityResult>> CheckNetAppQuotaAvailabilityAsync(AzureLocation location, NetAppQuotaAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return await CheckQuotaAvailabilityAsync(location.ToString(), content, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetAppCheckAvailabilityResult> CheckNetAppQuotaAvailability(AzureLocation location, NetAppQuotaAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return CheckQuotaAvailability(location.ToString(), content, cancellationToken);
        }

        // ---- Region Info AzureLocation shims (see header on Check Availability section) ----

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetAppRegionInfo>> QueryRegionInfoNetAppResourceAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await QueryRegionInfoAsync(location.ToString(), cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetAppRegionInfo> QueryRegionInfoNetAppResource(AzureLocation location, CancellationToken cancellationToken = default)
        {
            return QueryRegionInfo(location.ToString(), cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual RegionInfoResourceCollection GetRegionInfoResources(AzureLocation location)
        {
            throw new NotSupportedException("GetRegionInfoResources is not supported. Use GetRegionInfoResource instead.");
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<RegionInfoResource>> GetRegionInfoResourceAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("GetRegionInfoResourceAsync with AzureLocation is not supported. Use GetRegionInfoResource() instead.");
        }

        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<RegionInfoResource> GetRegionInfoResource(AzureLocation location, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("GetRegionInfoResource with AzureLocation is not supported. Use GetRegionInfoResource() instead.");
        }

        // ---- Network Sibling Set AzureLocation shims (see header on Check Availability section) ----

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<NetworkSiblingSet>> QueryNetworkSiblingSetNetAppResourceAsync(AzureLocation location, QueryNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            return await QueryNetworkSiblingSetAsync(location.ToString(), content, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetworkSiblingSet> QueryNetworkSiblingSetNetAppResource(AzureLocation location, QueryNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            return QueryNetworkSiblingSet(location.ToString(), content, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<ArmOperation<NetworkSiblingSet>> UpdateNetworkSiblingSetNetAppResourceAsync(WaitUntil waitUntil, AzureLocation location, UpdateNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            return await UpdateNetworkSiblingSetAsync(waitUntil, location.ToString(), content, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation<NetworkSiblingSet> UpdateNetworkSiblingSetNetAppResource(WaitUntil waitUntil, AzureLocation location, UpdateNetworkSiblingSetContent content, CancellationToken cancellationToken = default)
        {
            return UpdateNetworkSiblingSet(waitUntil, location.ToString(), content, cancellationToken);
        }

        // ---- Resource Usage methods (old named overloads) ----

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppUsageResult> GetNetAppResourceUsagesAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetAllAsync(location.ToString(), cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppUsageResult> GetNetAppResourceUsages(AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetAll(location.ToString(), cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetAppUsageResult>> GetNetAppResourceUsageAsync(AzureLocation location, string usageType, CancellationToken cancellationToken = default)
        {
            return await GetAsync(location, usageType, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetAppUsageResult> GetNetAppResourceUsage(AzureLocation location, string usageType, CancellationToken cancellationToken = default)
        {
            return Get(location, usageType, cancellationToken);
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
