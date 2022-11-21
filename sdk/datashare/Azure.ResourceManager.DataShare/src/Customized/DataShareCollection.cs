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
    /// A class representing a collection of <see cref="DataShareResource" /> and their operations.
    /// Each <see cref="DataShareResource" /> in the collection will belong to the same instance of <see cref="DataShareAccountResource" />.
    /// To get a <see cref="DataShareCollection" /> instance call the GetDataShares method from an instance of <see cref="DataShareAccountResource" />.
    /// </summary>
    public partial class DataShareCollection : ArmCollection, IEnumerable<DataShareResource>, IAsyncEnumerable<DataShareResource>
    {
        /// <summary>
        /// List shares in an account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares
        /// Operation Id: Shares_ListByAccount
        /// </summary>
        /// <param name="skipToken"> Continuation Token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DataShareResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DataShareResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DataShareResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dataShareSharesClientDiagnostics.CreateScope("DataShareCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dataShareSharesRestClient.ListByAccountAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DataShareResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DataShareResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dataShareSharesClientDiagnostics.CreateScope("DataShareCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dataShareSharesRestClient.ListByAccountNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DataShareResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List shares in an account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares
        /// Operation Id: Shares_ListByAccount
        /// </summary>
        /// <param name="skipToken"> Continuation Token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DataShareResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DataShareResource> GetAll(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DataShareResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dataShareSharesClientDiagnostics.CreateScope("DataShareCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dataShareSharesRestClient.ListByAccount(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DataShareResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DataShareResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dataShareSharesClientDiagnostics.CreateScope("DataShareCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dataShareSharesRestClient.ListByAccountNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DataShareResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
