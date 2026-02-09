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
        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location for resource names passed in $filter=resourceName eq {SKU}. This will include the GroupQuota and total quota allocated to the subscription. Only the Group quota allocated to the subscription can be allocated back to the MG Group Quota.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableQuotaManagementGroupResource.GetSubscriptionQuotaAllocationsListAsync(Guid, string, string, AzureLocation, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource"/> the method will execute against. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="groupQuotaName"> The GroupQuota name. The name should be unique for the provided context tenantId/MgId. </param>
        /// <param name="resourceProviderName"> The resource provider name, such as - Microsoft.Compute. Currently only Microsoft.Compute resource provider supports this API. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managementGroupResource"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<SubscriptionQuotaAllocationsListResource>> GetSubscriptionQuotaAllocationsListAsync(this ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));

            return await GetMockableQuotaManagementGroupResource(managementGroupResource).GetSubscriptionQuotaAllocationsListAsync(subscriptionId, groupQuotaName, resourceProviderName, location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location for resource names passed in $filter=resourceName eq {SKU}. This will include the GroupQuota and total quota allocated to the subscription. Only the Group quota allocated to the subscription can be allocated back to the MG Group Quota.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableQuotaManagementGroupResource.GetSubscriptionQuotaAllocationsList(Guid, string, string, AzureLocation, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource"/> the method will execute against. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="groupQuotaName"> The GroupQuota name. The name should be unique for the provided context tenantId/MgId. </param>
        /// <param name="resourceProviderName"> The resource provider name, such as - Microsoft.Compute. Currently only Microsoft.Compute resource provider supports this API. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="managementGroupResource"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SubscriptionQuotaAllocationsListResource> GetSubscriptionQuotaAllocationsList(this ManagementGroupResource managementGroupResource, string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(managementGroupResource, nameof(managementGroupResource));

            return GetMockableQuotaManagementGroupResource(managementGroupResource).GetSubscriptionQuotaAllocationsList(subscriptionId, groupQuotaName, resourceProviderName, location, cancellationToken);
        }

        /// <summary>
        /// List the operations for the provider
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Quota/operations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>QuotaOperation_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-09-01</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableQuotaTenantResource.GetQuotaOperations(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="QuotaOperationResult"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<QuotaOperationResult> GetQuotaOperationsAsync(this TenantResource tenantResource, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// List the operations for the provider
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Quota/operations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>QuotaOperation_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-09-01</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableQuotaTenantResource.GetQuotaOperations(CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> is null. </exception>
        /// <returns> A collection of <see cref="QuotaOperationResult"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<QuotaOperationResult> GetQuotaOperations(this TenantResource tenantResource, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }
    }
}
