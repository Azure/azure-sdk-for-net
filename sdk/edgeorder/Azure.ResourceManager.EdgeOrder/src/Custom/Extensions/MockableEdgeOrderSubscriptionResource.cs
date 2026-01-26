// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.EdgeOrder.Mocking
{
    // Manually add to maintain its backward compatibility
    public partial class MockableEdgeOrderSubscriptionResource
    {
        /// <summary>
        /// Lists all the addresses available under the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.EdgeOrder/addresses</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ListAddressesAtSubscriptionLevel</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="EdgeOrderAddressResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> $filter is supported to filter based on shipping address properties. Filter supports only equals operation. </param>
        /// <param name="skipToken"> $skipToken is supported on Get list of addresses, which provides the next page in the list of addresses. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EdgeOrderAddressResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<EdgeOrderAddressResource> GetEdgeOrderAddressesAsync(string filter = null, string skipToken = null, CancellationToken cancellationToken = default)
        {
            return GetEdgeOrderAddressesAsync(filter, skipToken, top: null, cancellationToken);
        }

        /// <summary>
        /// Lists all the addresses available under the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.EdgeOrder/addresses</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ListAddressesAtSubscriptionLevel</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="EdgeOrderAddressResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> $filter is supported to filter based on shipping address properties. Filter supports only equals operation. </param>
        /// <param name="skipToken"> $skipToken is supported on Get list of addresses, which provides the next page in the list of addresses. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EdgeOrderAddressResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EdgeOrderAddressResource> GetEdgeOrderAddresses(string filter, string skipToken, CancellationToken cancellationToken = default)
        {
            return GetEdgeOrderAddresses(filter, skipToken, top: null, cancellationToken);
        }

        /// <summary>
        /// Lists order item at subscription level.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.EdgeOrder/orderItems</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ListOrderItemsAtSubscriptionLevel</description>
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
        public virtual AsyncPageable<EdgeOrderItemResource> GetEdgeOrderItemsAsync(string filter, string expand, string skipToken, CancellationToken cancellationToken = default)
        {
            return GetEdgeOrderItemsAsync(filter, expand, skipToken, top: null, cancellationToken);
        }

        /// <summary>
        /// Lists order item at subscription level.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.EdgeOrder/orderItems</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ListOrderItemsAtSubscriptionLevel</description>
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
        public virtual Pageable<EdgeOrderItemResource> GetEdgeOrderItems(string filter, string expand, string skipToken, CancellationToken cancellationToken = default)
        {
            return GetEdgeOrderItems(filter, expand, skipToken, top: null, cancellationToken);
        }

        /// <summary>
        /// Lists order at subscription level.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.EdgeOrder/orders</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ListOrderAtSubscriptionLevel</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-12-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skipToken"> $skipToken is supported on Get list of order, which provides the next page in the list of order. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EdgeOrderResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<EdgeOrderResource> GetEdgeOrdersAsync(string skipToken, CancellationToken cancellationToken)
        {
            return GetEdgeOrdersAsync(skipToken, top: null, cancellationToken);
        }

        /// <summary>
        /// Lists order at subscription level.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.EdgeOrder/orders</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ListOrderAtSubscriptionLevel</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-12-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="skipToken"> $skipToken is supported on Get list of order, which provides the next page in the list of order. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EdgeOrderResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<EdgeOrderResource> GetEdgeOrders(string skipToken, CancellationToken cancellationToken)
        {
            return GetEdgeOrders(skipToken, top: null, cancellationToken);
        }
    }
}
