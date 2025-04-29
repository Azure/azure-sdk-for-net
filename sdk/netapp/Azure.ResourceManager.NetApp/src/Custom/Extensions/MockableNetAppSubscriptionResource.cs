// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableNetAppSubscriptionResource : ArmResource
    {
        /// <summary>
        /// Get the default and current limits for quotas
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetApp/locations/{location}/quotaLimits</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NetAppResourceQuotaLimits_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-09-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetAppSubscriptionQuotaItem"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimitsAsync(AzureLocation location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => NetAppResourceQuotaLimitsRestClient.CreateListRequest(Id.SubscriptionId, location);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => NetAppSubscriptionQuotaItem.DeserializeNetAppSubscriptionQuotaItem(e), NetAppResourceQuotaLimitsClientDiagnostics, Pipeline, "MockableNetAppSubscriptionResource.GetNetAppQuotaLimits", "value", null, cancellationToken);
        }

        /// <summary>
        /// Get the default and current limits for quotas
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NetApp/locations/{location}/quotaLimits</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>NetAppResourceQuotaLimits_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-09-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetAppSubscriptionQuotaItem"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NetAppSubscriptionQuotaItem> GetNetAppQuotaLimits(AzureLocation location, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => NetAppResourceQuotaLimitsRestClient.CreateListRequest(Id.SubscriptionId, location);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => NetAppSubscriptionQuotaItem.DeserializeNetAppSubscriptionQuotaItem(e), NetAppResourceQuotaLimitsClientDiagnostics, Pipeline, "MockableNetAppSubscriptionResource.GetNetAppQuotaLimits", "value", null, cancellationToken);
        }
    }
}
