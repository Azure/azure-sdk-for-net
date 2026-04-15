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
        // The newly generated code uses scope-based collection methods that only take AzureLocation.
        // Path: /providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}
        // The subscriptionId, groupQuotaName, and resourceProviderName are now encoded in the collection's scope (ResourceIdentifier).

        // --- Get (Guid overloads) ---

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SubscriptionQuotaAllocationsListResource>> GetAsync(Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await GetAsync(location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SubscriptionQuotaAllocationsListResource> Get(Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return Get(location, cancellationToken);
        }

        // --- Get (string overloads) ---

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SubscriptionQuotaAllocationsListResource>> GetAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await GetAsync(location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SubscriptionQuotaAllocationsListResource> Get(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return Get(location, cancellationToken);
        }

        // --- Exists (Guid overloads) ---

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return Exists(location, cancellationToken);
        }

        // --- Exists (string overloads) ---

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return Exists(location, cancellationToken);
        }

        // --- GetIfExists (Guid overloads) ---

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<SubscriptionQuotaAllocationsListResource>> GetIfExistsAsync(Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<SubscriptionQuotaAllocationsListResource> GetIfExists(Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetIfExists(location, cancellationToken);
        }

        // --- GetIfExists (string overloads) ---

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<SubscriptionQuotaAllocationsListResource>> GetIfExistsAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<SubscriptionQuotaAllocationsListResource> GetIfExists(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetIfExists(location, cancellationToken);
        }
    }
}
