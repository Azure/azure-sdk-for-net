// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;

namespace Azure.ResourceManager.EdgeOrder
{
    // Manually add to maintain its backward compatibility
    public partial class EdgeOrderItemCollection
    {
        /// <summary>
        /// Lists order item at resource group level.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/orderItems</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ListOrderItemsAtResourceGroupLevel</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="EdgeOrderItemResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> $filter is supported to filter based on order id. Filter supports only equals operation. </param>
        /// <param name="expand"> $expand is supported on device details, forward shipping details and reverse shipping details parameters. Each of these can be provided as a comma separated list. Device Details for order item provides details on the devices of the product, Forward and Reverse Shipping details provide forward and reverse shipping details respectively. </param>
        /// <param name="skipToken"> $skipToken is supported on Get list of order items, which provides the next page in the list of order items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EdgeOrderItemResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<EdgeOrderItemResource> GetAllAsync(string filter, string expand, string skipToken, CancellationToken cancellationToken)
        {
            return GetAllAsync(filter, expand, skipToken, top: null, cancellationToken);
        }

        /// <summary>
        /// Lists order item at resource group level.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/orderItems</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ListOrderItemsAtResourceGroupLevel</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="EdgeOrderItemResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> $filter is supported to filter based on order id. Filter supports only equals operation. </param>
        /// <param name="expand"> $expand is supported on device details, forward shipping details and reverse shipping details parameters. Each of these can be provided as a comma separated list. Device Details for order item provides details on the devices of the product, Forward and Reverse Shipping details provide forward and reverse shipping details respectively. </param>
        /// <param name="skipToken"> $skipToken is supported on Get list of order items, which provides the next page in the list of order items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EdgeOrderItemResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EdgeOrderItemResource> GetAll(string filter, string expand, string skipToken, CancellationToken cancellationToken)
        {
            return GetAll(filter, expand, skipToken, top: null, cancellationToken);
        }
    }
}
