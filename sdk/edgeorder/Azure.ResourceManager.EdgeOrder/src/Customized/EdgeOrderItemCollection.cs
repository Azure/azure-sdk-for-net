// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.EdgeOrder.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EdgeOrder
{
    /// <summary>
    /// A class representing a collection of <see cref="EdgeOrderItemResource" /> and their operations.
    /// Each <see cref="EdgeOrderItemResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get an <see cref="EdgeOrderItemCollection" /> instance call the GetEdgeOrderItems method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class EdgeOrderItemCollection : ArmCollection, IEnumerable<EdgeOrderItemResource>, IAsyncEnumerable<EdgeOrderItemResource>
    {
        /// <summary>
        /// Lists order item at resource group level.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/orderItems
        /// Operation Id: ListOrderItemsAtResourceGroupLevel
        /// </summary>
        /// <param name="filter"> $filter is supported to filter based on order id. Filter supports only equals operation. </param>
        /// <param name="expand"> $expand is supported on device details, forward shipping details and reverse shipping details parameters. Each of these can be provided as a comma separated list. Device Details for order item provides details on the devices of the product, Forward and Reverse Shipping details provide forward and reverse shipping details respectively. </param>
        /// <param name="skipToken"> $skipToken is supported on Get list of order items, which provides the next page in the list of order items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EdgeOrderItemResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<EdgeOrderItemResource> GetAllAsync(string filter = null, string expand = null, string skipToken = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new EdgeOrderItemCollectionGetAllOptions
            {
                Filter = filter,
                Expand = expand,
                SkipToken = skipToken
            }, cancellationToken);

        /// <summary>
        /// Lists order item at resource group level.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/orderItems
        /// Operation Id: ListOrderItemsAtResourceGroupLevel
        /// </summary>
        /// <param name="filter"> $filter is supported to filter based on order id. Filter supports only equals operation. </param>
        /// <param name="expand"> $expand is supported on device details, forward shipping details and reverse shipping details parameters. Each of these can be provided as a comma separated list. Device Details for order item provides details on the devices of the product, Forward and Reverse Shipping details provide forward and reverse shipping details respectively. </param>
        /// <param name="skipToken"> $skipToken is supported on Get list of order items, which provides the next page in the list of order items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EdgeOrderItemResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<EdgeOrderItemResource> GetAll(string filter = null, string expand = null, string skipToken = null, CancellationToken cancellationToken = default) =>
            GetAll(new EdgeOrderItemCollectionGetAllOptions
            {
                Filter = filter,
                Expand = expand,
                SkipToken = skipToken
            }, cancellationToken);
    }
}
