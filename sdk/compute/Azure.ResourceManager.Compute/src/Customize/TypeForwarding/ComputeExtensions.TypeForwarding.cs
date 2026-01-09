// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Skus.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    public static partial class ComputeExtensions
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeSkusSubscriptionResource.GetComputeResourceSkus(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="filter"> The filter to apply on the operation. Only **location** filter is supported currently. </param>
        /// <param name="includeExtendedLocations"> To Include Extended Locations information or not in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> An async collection of <see cref="ComputeResourceSku"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ComputeResourceSku> GetComputeResourceSkusAsync(SubscriptionResource subscriptionResource, string filter = null, string includeExtendedLocations = null, CancellationToken cancellationToken = default)
        {
            return ComputeSkusExtensions.GetComputeResourceSkusAsync(subscriptionResource, filter, includeExtendedLocations, cancellationToken);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableComputeSkusSubscriptionResource.GetComputeResourceSkus(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="filter"> The filter to apply on the operation. Only **location** filter is supported currently. </param>
        /// <param name="includeExtendedLocations"> To Include Extended Locations information or not in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="ComputeResourceSku"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ComputeResourceSku> GetComputeResourceSkus(SubscriptionResource subscriptionResource, string filter = null, string includeExtendedLocations = null, CancellationToken cancellationToken = default)
        {
            return ComputeSkusExtensions.GetComputeResourceSkus(subscriptionResource, filter, includeExtendedLocations, cancellationToken);
        }
    }
}
