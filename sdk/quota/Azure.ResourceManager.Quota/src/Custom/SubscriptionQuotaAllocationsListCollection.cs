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
        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location for resource names passed in $filter=resourceName eq {SKU}. This will include the GroupQuota and total quota allocated to the subscription. Only the Group quota allocated to the subscription can be allocated back to the MG Group Quota.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> SubscriptionQuotaAllocationsLists_List. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="groupQuotaName"> The GroupQuota name. The name should be unique for the provided context tenantId/MgId. </param>
        /// <param name="resourceProviderName"> The resource provider name, such as - Microsoft.Compute. Currently only Microsoft.Compute resource provider supports this API. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupQuotaName"/> or <paramref name="resourceProviderName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupQuotaName"/> or <paramref name="resourceProviderName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SubscriptionQuotaAllocationsListResource>> GetAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await GetAsync(Guid.Parse(subscriptionId), groupQuotaName, resourceProviderName, location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location for resource names passed in $filter=resourceName eq {SKU}. This will include the GroupQuota and total quota allocated to the subscription. Only the Group quota allocated to the subscription can be allocated back to the MG Group Quota.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> SubscriptionQuotaAllocationsLists_List. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="groupQuotaName"> The GroupQuota name. The name should be unique for the provided context tenantId/MgId. </param>
        /// <param name="resourceProviderName"> The resource provider name, such as - Microsoft.Compute. Currently only Microsoft.Compute resource provider supports this API. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupQuotaName"/> or <paramref name="resourceProviderName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupQuotaName"/> or <paramref name="resourceProviderName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SubscriptionQuotaAllocationsListResource> Get(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return Get(Guid.Parse(subscriptionId), groupQuotaName, resourceProviderName, location, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> SubscriptionQuotaAllocationsLists_List. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="groupQuotaName"> The GroupQuota name. The name should be unique for the provided context tenantId/MgId. </param>
        /// <param name="resourceProviderName"> The resource provider name, such as - Microsoft.Compute. Currently only Microsoft.Compute resource provider supports this API. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupQuotaName"/> or <paramref name="resourceProviderName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupQuotaName"/> or <paramref name="resourceProviderName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(Guid.Parse(subscriptionId), groupQuotaName, resourceProviderName, location, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> SubscriptionQuotaAllocationsLists_List. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="groupQuotaName"> The GroupQuota name. The name should be unique for the provided context tenantId/MgId. </param>
        /// <param name="resourceProviderName"> The resource provider name, such as - Microsoft.Compute. Currently only Microsoft.Compute resource provider supports this API. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupQuotaName"/> or <paramref name="resourceProviderName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupQuotaName"/> or <paramref name="resourceProviderName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return Exists(Guid.Parse(subscriptionId), groupQuotaName, resourceProviderName, location, cancellationToken);
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> SubscriptionQuotaAllocationsLists_List. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="groupQuotaName"> The GroupQuota name. The name should be unique for the provided context tenantId/MgId. </param>
        /// <param name="resourceProviderName"> The resource provider name, such as - Microsoft.Compute. Currently only Microsoft.Compute resource provider supports this API. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupQuotaName"/> or <paramref name="resourceProviderName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupQuotaName"/> or <paramref name="resourceProviderName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<SubscriptionQuotaAllocationsListResource> GetIfExists(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetIfExists(Guid.Parse(subscriptionId), groupQuotaName, resourceProviderName, location, cancellationToken);
        }

        /// <summary>
        /// Gets all the quota allocated to a subscription for the specified resource provider and location for resource names passed in $filter=resourceName eq {SKU}. This will include the GroupQuota and total quota allocated to the subscription. Only the Group quota allocated to the subscription can be allocated back to the MG Group Quota.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/quotaAllocations/{location}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> SubscriptionQuotaAllocationsLists_List. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="groupQuotaName"> The GroupQuota name. The name should be unique for the provided context tenantId/MgId. </param>
        /// <param name="resourceProviderName"> The resource provider name, such as - Microsoft.Compute. Currently only Microsoft.Compute resource provider supports this API. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="groupQuotaName"/> or <paramref name="resourceProviderName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="groupQuotaName"/> or <paramref name="resourceProviderName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<SubscriptionQuotaAllocationsListResource>> GetIfExistsAsync(string subscriptionId, string groupQuotaName, string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(Guid.Parse(subscriptionId), groupQuotaName, resourceProviderName, location, cancellationToken).ConfigureAwait(false);
        }
    }
}
