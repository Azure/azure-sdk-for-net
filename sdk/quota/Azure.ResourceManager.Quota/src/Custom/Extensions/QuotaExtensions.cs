// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Quota.Mocking;
using Azure.ResourceManager.Quota.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Quota
{
    public static partial class QuotaExtensions
    {
        // The newly generated code uses scope-based ArmClient extension methods instead of ManagementGroupResource extension methods.
        // Path: /providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}
        // Path: /providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocationRequests/{allocationId}
        // The subscriptionId, groupQuotaName, and resourceProviderName are now encoded in the ResourceIdentifier scope.

        // --- SubscriptionQuotaAllocationsList (Guid overloads) ---

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<SubscriptionQuotaAllocationsListResource>> GetSubscriptionQuotaAllocationsListAsync(this ManagementGroupResource managementGroupResource, Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));
            return await GetMockableQuotaManagementGroupResource(managementGroupResource).GetSubscriptionQuotaAllocationsListAsync(subscriptionId, groupQuotaName, resourceProviderName, location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SubscriptionQuotaAllocationsListResource> GetSubscriptionQuotaAllocationsList(this ManagementGroupResource managementGroupResource, Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));
            return GetMockableQuotaManagementGroupResource(managementGroupResource).GetSubscriptionQuotaAllocationsList(subscriptionId, groupQuotaName, resourceProviderName, location, cancellationToken);
        }

        // --- SubscriptionQuotaAllocationsList (string overloads) ---

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<SubscriptionQuotaAllocationsListResource>> GetSubscriptionQuotaAllocationsListAsync(this ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));
            return await GetMockableQuotaManagementGroupResource(managementGroupResource).GetSubscriptionQuotaAllocationsListAsync(subscriptionId, groupQuotaName, resourceProviderName, location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SubscriptionQuotaAllocationsListResource> GetSubscriptionQuotaAllocationsList(this ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));
            return GetMockableQuotaManagementGroupResource(managementGroupResource).GetSubscriptionQuotaAllocationsList(subscriptionId, groupQuotaName, resourceProviderName, location, cancellationToken);
        }

        // --- SubscriptionQuotaAllocationsLists collection (no-param) ---

        /// <summary>
        /// Gets a collection of SubscriptionQuotaAllocationsListResources.
        /// Cannot be forwarded because subscriptionId, groupQuotaName, and resourceProviderName are required to build the scope.
        /// Use ArmClient.GetSubscriptionQuotaAllocationsLists(ResourceIdentifier scope) instead.
        /// </summary>
        // Operation path: /providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}
        [Obsolete("This method is obsolete and will be removed in a future release. Use ArmClient.GetSubscriptionQuotaAllocationsLists(ResourceIdentifier scope) instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SubscriptionQuotaAllocationsListCollection GetSubscriptionQuotaAllocationsLists(this ManagementGroupResource managementGroupResource)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));
            return GetMockableQuotaManagementGroupResource(managementGroupResource).GetSubscriptionQuotaAllocationsLists();
        }

        // --- QuotaAllocationRequestStatus ---

        /// <summary>
        /// Gets the quota allocation request status for the specified allocation.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocationRequests/{allocationId}</description></item></list>
        /// </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<QuotaAllocationRequestStatusResource>> GetQuotaAllocationRequestStatusAsync(this ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceProviderName, string allocationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));
            return await GetMockableQuotaManagementGroupResource(managementGroupResource).GetQuotaAllocationRequestStatusAsync(subscriptionId, groupQuotaName, resourceProviderName, allocationId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the quota allocation request status for the specified allocation.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocationRequests/{allocationId}</description></item></list>
        /// </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<QuotaAllocationRequestStatusResource> GetQuotaAllocationRequestStatus(this ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceProviderName, string allocationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));
            return GetMockableQuotaManagementGroupResource(managementGroupResource).GetQuotaAllocationRequestStatus(subscriptionId, groupQuotaName, resourceProviderName, allocationId, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of QuotaAllocationRequestStatusResources.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocationRequests</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static QuotaAllocationRequestStatusCollection GetQuotaAllocationRequestStatuses(this ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceProviderName)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));
            return GetMockableQuotaManagementGroupResource(managementGroupResource).GetQuotaAllocationRequestStatuses(subscriptionId, groupQuotaName, resourceProviderName);
        }

        // --- Obsolete TenantResource methods ---

        // Operation path: /providers/Microsoft.Quota/operations
        // This operation is obsolete; use GetAllAsync instead.
        /// <summary> Obsolete. Use GetAllAsync instead. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<QuotaOperationResult> GetQuotaOperationsAsync(this TenantResource tenantResource, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is obsolete. Use GetAllAsync instead.");
        }

        // Operation path: /providers/Microsoft.Quota/operations
        // This operation is obsolete; use GetAll instead.
        /// <summary> Obsolete. Use GetAll instead. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<QuotaOperationResult> GetQuotaOperations(this TenantResource tenantResource, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is obsolete. Use GetAll instead.");
        }
    }
}
