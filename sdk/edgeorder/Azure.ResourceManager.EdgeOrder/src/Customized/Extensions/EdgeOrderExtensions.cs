// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.ResourceManager.EdgeOrder.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EdgeOrder
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.EdgeOrder. </summary>
    public static partial class EdgeOrderExtensions
    {
        /// <summary>
        /// Lists order item at subscription level.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.EdgeOrder/orderItems
        /// Operation Id: ListOrderItemsAtSubscriptionLevel
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="filter"> $filter is supported to filter based on order id. Filter supports only equals operation. </param>
        /// <param name="expand"> $expand is supported on device details, forward shipping details and reverse shipping details parameters. Each of these can be provided as a comma separated list. Device Details for order item provides details on the devices of the product, Forward and Reverse Shipping details provide forward and reverse shipping details respectively. </param>
        /// <param name="skipToken"> $skipToken is supported on Get list of order items, which provides the next page in the list of order items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EdgeOrderItemResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<EdgeOrderItemResource> GetEdgeOrderItemsAsync(this SubscriptionResource subscriptionResource, string filter = null, string expand = null, string skipToken = null, CancellationToken cancellationToken = default)
        {
            EdgeOrderExtensionsGetEdgeOrderItemsOptions options = new EdgeOrderExtensionsGetEdgeOrderItemsOptions
            {
                Filter = filter,
                Expand = expand,
                SkipToken = skipToken
            };

            return GetExtensionClient(subscriptionResource).GetEdgeOrderItemsAsync(options, cancellationToken);
        }

        /// <summary>
        /// Lists order item at subscription level.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.EdgeOrder/orderItems
        /// Operation Id: ListOrderItemsAtSubscriptionLevel
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="filter"> $filter is supported to filter based on order id. Filter supports only equals operation. </param>
        /// <param name="expand"> $expand is supported on device details, forward shipping details and reverse shipping details parameters. Each of these can be provided as a comma separated list. Device Details for order item provides details on the devices of the product, Forward and Reverse Shipping details provide forward and reverse shipping details respectively. </param>
        /// <param name="skipToken"> $skipToken is supported on Get list of order items, which provides the next page in the list of order items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EdgeOrderItemResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<EdgeOrderItemResource> GetEdgeOrderItems(this SubscriptionResource subscriptionResource, string filter = null, string expand = null, string skipToken = null, CancellationToken cancellationToken = default)
        {
            EdgeOrderExtensionsGetEdgeOrderItemsOptions options = new EdgeOrderExtensionsGetEdgeOrderItemsOptions
            {
                Filter = filter,
                Expand = expand,
                SkipToken = skipToken
            };

            return GetExtensionClient(subscriptionResource).GetEdgeOrderItems(options, cancellationToken);
        }
    }
}
