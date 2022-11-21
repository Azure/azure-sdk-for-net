// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Batch
{
    /// <summary>
    /// A class representing a collection of <see cref="BatchAccountPoolResource" /> and their operations.
    /// Each <see cref="BatchAccountPoolResource" /> in the collection will belong to the same instance of <see cref="BatchAccountResource" />.
    /// To get a <see cref="BatchAccountPoolCollection" /> instance call the GetBatchAccountPools method from an instance of <see cref="BatchAccountResource" />.
    /// </summary>
    public partial class BatchAccountPoolCollection : ArmCollection, IEnumerable<BatchAccountPoolResource>, IAsyncEnumerable<BatchAccountPoolResource>
    {
        /// <summary>
        /// Lists all of the pools in the specified account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/pools
        /// Operation Id: Pool_ListByBatchAccount
        /// </summary>
        /// <param name="maxresults"> The maximum number of items to return in the response. </param>
        /// <param name="select"> Comma separated list of properties that should be returned. e.g. &quot;properties/provisioningState&quot;. Only top level properties under properties/ are valid for selection. </param>
        /// <param name="filter">
        /// OData filter expression. Valid properties for filtering are:
        ///
        ///  name
        ///  properties/allocationState
        ///  properties/allocationStateTransitionTime
        ///  properties/creationTime
        ///  properties/provisioningState
        ///  properties/provisioningStateTransitionTime
        ///  properties/lastModified
        ///  properties/vmSize
        ///  properties/interNodeCommunication
        ///  properties/scaleSettings/autoScale
        ///  properties/scaleSettings/fixedScale
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BatchAccountPoolResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BatchAccountPoolResource> GetAllAsync(int? maxresults = null, string select = null, string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<BatchAccountPoolResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _batchAccountPoolPoolClientDiagnostics.CreateScope("BatchAccountPoolCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _batchAccountPoolPoolRestClient.ListByBatchAccountAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, maxresults, select, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new BatchAccountPoolResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<BatchAccountPoolResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _batchAccountPoolPoolClientDiagnostics.CreateScope("BatchAccountPoolCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _batchAccountPoolPoolRestClient.ListByBatchAccountNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, maxresults, select, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new BatchAccountPoolResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all of the pools in the specified account.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Batch/batchAccounts/{accountName}/pools
        /// Operation Id: Pool_ListByBatchAccount
        /// </summary>
        /// <param name="maxresults"> The maximum number of items to return in the response. </param>
        /// <param name="select"> Comma separated list of properties that should be returned. e.g. &quot;properties/provisioningState&quot;. Only top level properties under properties/ are valid for selection. </param>
        /// <param name="filter">
        /// OData filter expression. Valid properties for filtering are:
        ///
        ///  name
        ///  properties/allocationState
        ///  properties/allocationStateTransitionTime
        ///  properties/creationTime
        ///  properties/provisioningState
        ///  properties/provisioningStateTransitionTime
        ///  properties/lastModified
        ///  properties/vmSize
        ///  properties/interNodeCommunication
        ///  properties/scaleSettings/autoScale
        ///  properties/scaleSettings/fixedScale
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BatchAccountPoolResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BatchAccountPoolResource> GetAll(int? maxresults = null, string select = null, string filter = null, CancellationToken cancellationToken = default)
        {
            Page<BatchAccountPoolResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _batchAccountPoolPoolClientDiagnostics.CreateScope("BatchAccountPoolCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _batchAccountPoolPoolRestClient.ListByBatchAccount(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, maxresults, select, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new BatchAccountPoolResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<BatchAccountPoolResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _batchAccountPoolPoolClientDiagnostics.CreateScope("BatchAccountPoolCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _batchAccountPoolPoolRestClient.ListByBatchAccountNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, maxresults, select, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new BatchAccountPoolResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
