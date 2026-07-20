// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Quota.Mocking
{
    public partial class MockableQuotaManagementGroupResource
    {
        // The newly generated code uses scope-based methods on MockableQuotaArmClient whose scope is the
        // "Microsoft.Management/managementGroups/subscriptions" resource. groupQuotaName and resourceProviderName
        // are passed as separate parameters (not encoded in the scope identifier).

        private MockableQuotaArmClient GetMockableQuotaArmClient()
        {
            return Client.GetCachedClient(client0 => new MockableQuotaArmClient(client0, ResourceIdentifier.Root));
        }

        private ResourceIdentifier BuildQuotaScope(string subscriptionId)
        {
            return new ResourceIdentifier($"{Id}/subscriptions/{subscriptionId}");
        }

        // --- SubscriptionQuotaAllocationsList (Guid overloads) ---

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SubscriptionQuotaAllocationsListResource>> GetSubscriptionQuotaAllocationsListAsync(Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            var scope = BuildQuotaScope(subscriptionId.ToString());
            return await GetMockableQuotaArmClient().GetSubscriptionQuotaAllocationsListAsync(scope, groupQuotaName, resourceProviderName, location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SubscriptionQuotaAllocationsListResource> GetSubscriptionQuotaAllocationsList(Guid subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            var scope = BuildQuotaScope(subscriptionId.ToString());
            return GetMockableQuotaArmClient().GetSubscriptionQuotaAllocationsList(scope, groupQuotaName, resourceProviderName, location, cancellationToken);
        }

        // --- SubscriptionQuotaAllocationsList (string overloads) ---

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SubscriptionQuotaAllocationsListResource>> GetSubscriptionQuotaAllocationsListAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            var scope = BuildQuotaScope(subscriptionId);
            return await GetMockableQuotaArmClient().GetSubscriptionQuotaAllocationsListAsync(scope, groupQuotaName, resourceProviderName, location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}</description></item></list>
        /// </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SubscriptionQuotaAllocationsListResource> GetSubscriptionQuotaAllocationsList(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            var scope = BuildQuotaScope(subscriptionId);
            return GetMockableQuotaArmClient().GetSubscriptionQuotaAllocationsList(scope, groupQuotaName, resourceProviderName, location, cancellationToken);
        }

        // --- SubscriptionQuotaAllocationsLists collection (no-param) ---

        /// <summary>
        /// Gets a collection of SubscriptionQuotaAllocationsListResources.
        /// Cannot be forwarded because subscriptionId is required to build the scope.
        /// Use ArmClient.GetSubscriptionQuotaAllocationsLists(ResourceIdentifier scope) instead.
        /// </summary>
        [Obsolete("This method is obsolete and will be removed in a future release. Use ArmClient.GetSubscriptionQuotaAllocationsLists(ResourceIdentifier scope) instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SubscriptionQuotaAllocationsListCollection GetSubscriptionQuotaAllocationsLists()
        {
            throw new NotSupportedException("Use ArmClient.GetSubscriptionQuotaAllocationsLists(ResourceIdentifier scope) instead.");
        }

        // --- QuotaAllocationRequestStatus ---

        /// <summary>
        /// Gets the quota allocation request status for the specified allocation.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocationRequests/{allocationId}</description></item></list>
        /// </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<QuotaAllocationRequestStatusResource>> GetQuotaAllocationRequestStatusAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, string allocationId, CancellationToken cancellationToken = default)
        {
            var scope = BuildQuotaScope(subscriptionId);
            return await GetMockableQuotaArmClient().GetQuotaAllocationRequestStatusAsync(scope, groupQuotaName, resourceProviderName, allocationId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the quota allocation request status for the specified allocation.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocationRequests/{allocationId}</description></item></list>
        /// </summary>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<QuotaAllocationRequestStatusResource> GetQuotaAllocationRequestStatus(string subscriptionId, string groupQuotaName, string resourceProviderName, string allocationId, CancellationToken cancellationToken = default)
        {
            var scope = BuildQuotaScope(subscriptionId);
            return GetMockableQuotaArmClient().GetQuotaAllocationRequestStatus(scope, groupQuotaName, resourceProviderName, allocationId, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of QuotaAllocationRequestStatusResources.
        /// <list type="bullet"><item><term>Request Path</term><description>/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocationRequests</description></item></list>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual QuotaAllocationRequestStatusCollection GetQuotaAllocationRequestStatuses(string subscriptionId, string groupQuotaName, string resourceProviderName)
        {
            var scope = BuildQuotaScope(subscriptionId);
            return GetMockableQuotaArmClient().GetQuotaAllocationRequestStatuses(scope, groupQuotaName, resourceProviderName);
        }
    }
}
