// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Quota
{
    public partial class SubscriptionQuotaAllocationsListCollection
    {
        // The newly generated Get/Exists/GetIfExists take (groupQuotaName, resourceProviderName, location, ct).
        // These legacy overloads add an initial subscriptionId parameter (Guid or string) for API compat;
        // subscriptionId is already encoded in this collection's scope (Id.Name), so it's ignored.

        // --- Get (Guid overloads) ---

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SubscriptionQuotaAllocationsListResource>> GetAsync(Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await GetAsync(groupQuotaName, resourceProviderName, location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SubscriptionQuotaAllocationsListResource> Get(Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return Get(groupQuotaName, resourceProviderName, location, cancellationToken);
        }

        // --- Get (string overloads) ---

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SubscriptionQuotaAllocationsListResource>> GetAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await GetAsync(groupQuotaName, resourceProviderName, location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SubscriptionQuotaAllocationsListResource> Get(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return Get(groupQuotaName, resourceProviderName, location, cancellationToken);
        }

        // --- Exists (Guid overloads) ---

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(groupQuotaName, resourceProviderName, location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return Exists(groupQuotaName, resourceProviderName, location, cancellationToken);
        }

        // --- Exists (string overloads) ---

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(groupQuotaName, resourceProviderName, location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return Exists(groupQuotaName, resourceProviderName, location, cancellationToken);
        }

        // --- GetIfExists (Guid overloads) ---

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<SubscriptionQuotaAllocationsListResource>> GetIfExistsAsync(Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(groupQuotaName, resourceProviderName, location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<SubscriptionQuotaAllocationsListResource> GetIfExists(Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetIfExists(groupQuotaName, resourceProviderName, location, cancellationToken);
        }

        // --- GetIfExists (string overloads) ---

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<SubscriptionQuotaAllocationsListResource>> GetIfExistsAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(groupQuotaName, resourceProviderName, location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<SubscriptionQuotaAllocationsListResource> GetIfExists(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetIfExists(groupQuotaName, resourceProviderName, location, cancellationToken);
        }
    }
}
