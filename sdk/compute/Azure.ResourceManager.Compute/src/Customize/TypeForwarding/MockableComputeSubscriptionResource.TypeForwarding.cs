// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute.Mocking
{
    public partial class MockableComputeSubscriptionResource : ArmResource
    {
        /// <summary>
        /// Gets the list of Microsoft.Compute SKUs available for your Subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/skus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceSkus_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-07-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Only **location** filter is supported currently. </param>
        /// <param name="includeExtendedLocations"> To Include Extended Locations information or not in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ComputeResourceSku"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Call Azure.ResourceManager.Compute.Skus.MockableComputeSkusSubscriptionResource.GetComputeResourceSkusAsync instead.", false)]
        public virtual AsyncPageable<ComputeResourceSku> GetComputeResourceSkusAsync(string filter = null, string includeExtendedLocations = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported, please call Azure.ResourceManager.Compute.Skus.MockableComputeSkusSubscriptionResource.GetComputeResourceSkusAsync instead.");
        }

        /// <summary>
        /// Gets the list of Microsoft.Compute SKUs available for your Subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/skus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceSkus_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-07-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Only **location** filter is supported currently. </param>
        /// <param name="includeExtendedLocations"> To Include Extended Locations information or not in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ComputeResourceSku"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete. Call Azure.ResourceManager.Compute.Skus.MockableComputeSkusSubscriptionResource.GetComputeResourceSkus instead.", false)]
        public virtual Pageable<ComputeResourceSku> GetComputeResourceSkus(string filter = null, string includeExtendedLocations = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is no longer supported, please call Azure.ResourceManager.Compute.Skus.MockableComputeSkusSubscriptionResource.GetComputeResourceSkus instead.");
        }
    }
}
