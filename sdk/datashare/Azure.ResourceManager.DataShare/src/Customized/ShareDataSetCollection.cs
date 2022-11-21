// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.DataShare
{
    /// <summary>
    /// A class representing a collection of <see cref="ShareDataSetResource" /> and their operations.
    /// Each <see cref="ShareDataSetResource" /> in the collection will belong to the same instance of <see cref="DataShareResource" />.
    /// To get a <see cref="ShareDataSetCollection" /> instance call the GetShareDataSets method from an instance of <see cref="DataShareResource" />.
    /// </summary>
    public partial class ShareDataSetCollection : ArmCollection, IEnumerable<ShareDataSetResource>, IAsyncEnumerable<ShareDataSetResource>
    {
        /// <summary>
        /// List DataSets in a share
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares/{shareName}/dataSets
        /// Operation Id: DataSets_ListByShare
        /// </summary>
        /// <param name="skipToken"> continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ShareDataSetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ShareDataSetResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ShareDataSetResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _shareDataSetDataSetsClientDiagnostics.CreateScope("ShareDataSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _shareDataSetDataSetsRestClient.ListByShareAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ShareDataSetResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ShareDataSetResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _shareDataSetDataSetsClientDiagnostics.CreateScope("ShareDataSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _shareDataSetDataSetsRestClient.ListByShareNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ShareDataSetResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List DataSets in a share
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares/{shareName}/dataSets
        /// Operation Id: DataSets_ListByShare
        /// </summary>
        /// <param name="skipToken"> continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ShareDataSetResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ShareDataSetResource> GetAll(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<ShareDataSetResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _shareDataSetDataSetsClientDiagnostics.CreateScope("ShareDataSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _shareDataSetDataSetsRestClient.ListByShare(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ShareDataSetResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ShareDataSetResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _shareDataSetDataSetsClientDiagnostics.CreateScope("ShareDataSetCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _shareDataSetDataSetsRestClient.ListByShareNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ShareDataSetResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
