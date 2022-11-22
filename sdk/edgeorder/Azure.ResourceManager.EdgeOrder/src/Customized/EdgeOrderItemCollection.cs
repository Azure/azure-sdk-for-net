// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
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
        public virtual AsyncPageable<EdgeOrderItemResource> GetAllAsync(string filter = null, string expand = null, string skipToken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<EdgeOrderItemResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _edgeOrderItemClientDiagnostics.CreateScope("EdgeOrderItemCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _edgeOrderItemRestClient.ListOrderItemsAtResourceGroupLevelAsync(Id.SubscriptionId, Id.ResourceGroupName, filter, expand, skipToken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new EdgeOrderItemResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<EdgeOrderItemResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _edgeOrderItemClientDiagnostics.CreateScope("EdgeOrderItemCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _edgeOrderItemRestClient.ListOrderItemsAtResourceGroupLevelNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, expand, skipToken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new EdgeOrderItemResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

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
        public virtual Pageable<EdgeOrderItemResource> GetAll(string filter = null, string expand = null, string skipToken = null, CancellationToken cancellationToken = default)
        {
            Page<EdgeOrderItemResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _edgeOrderItemClientDiagnostics.CreateScope("EdgeOrderItemCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _edgeOrderItemRestClient.ListOrderItemsAtResourceGroupLevel(Id.SubscriptionId, Id.ResourceGroupName, filter, expand, skipToken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new EdgeOrderItemResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<EdgeOrderItemResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _edgeOrderItemClientDiagnostics.CreateScope("EdgeOrderItemCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _edgeOrderItemRestClient.ListOrderItemsAtResourceGroupLevelNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, expand, skipToken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new EdgeOrderItemResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
