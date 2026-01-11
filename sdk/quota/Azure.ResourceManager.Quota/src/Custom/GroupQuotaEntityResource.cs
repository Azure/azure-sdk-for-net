// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Quota.Models;

namespace Azure.ResourceManager.Quota
{
    public partial class GroupQuotaEntityResource
    {
        /// <summary>
        /// Gets the GroupQuotas usages and limits(quota). Location is required paramter.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/locationUsages/{location}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GroupQuotasEntities_GroupQuotaUsagesList. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="GroupQuotaEntityResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceProviderName"> The resource provider name, such as - Microsoft.Compute. Currently only Microsoft.Compute resource provider supports this API. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> A collection of <see cref="GroupQuotaResourceUsages"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<GroupQuotaResourceUsages> ListAsync(string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetGroupQuotaUsagesAsync(resourceProviderName, location, cancellationToken);
        }

        /// <summary>
        /// Gets the GroupQuotas usages and limits(quota). Location is required paramter.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/resourceProviders/{resourceProviderName}/locationUsages/{location}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GroupQuotasEntities_GroupQuotaUsagesList. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="GroupQuotaEntityResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceProviderName"> The resource provider name, such as - Microsoft.Compute. Currently only Microsoft.Compute resource provider supports this API. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resourceProviderName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> A collection of <see cref="GroupQuotaResourceUsages"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<GroupQuotaResourceUsages> List(string resourceProviderName, AzureLocation location, CancellationToken cancellationToken = default)
        {
            return GetGroupQuotaUsages(resourceProviderName, location, cancellationToken);
        }
    }
}
