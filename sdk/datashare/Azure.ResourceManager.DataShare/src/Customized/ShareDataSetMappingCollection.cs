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
    /// A class representing a collection of <see cref="ShareDataSetMappingResource" /> and their operations.
    /// Each <see cref="ShareDataSetMappingResource" /> in the collection will belong to the same instance of <see cref="ShareSubscriptionResource" />.
    /// To get a <see cref="ShareDataSetMappingCollection" /> instance call the GetShareDataSetMappings method from an instance of <see cref="ShareSubscriptionResource" />.
    /// </summary>
    public partial class ShareDataSetMappingCollection : ArmCollection, IEnumerable<ShareDataSetMappingResource>, IAsyncEnumerable<ShareDataSetMappingResource>
    {
        /// <summary>
        /// List DataSetMappings in a share subscription
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shareSubscriptions/{shareSubscriptionName}/dataSetMappings
        /// Operation Id: DataSetMappings_ListByShareSubscription
        /// </summary>
        /// <param name="skipToken"> Continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ShareDataSetMappingResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ShareDataSetMappingResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ShareDataSetMappingResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _shareDataSetMappingDataSetMappingsClientDiagnostics.CreateScope("ShareDataSetMappingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _shareDataSetMappingDataSetMappingsRestClient.ListByShareSubscriptionAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ShareDataSetMappingResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ShareDataSetMappingResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _shareDataSetMappingDataSetMappingsClientDiagnostics.CreateScope("ShareDataSetMappingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _shareDataSetMappingDataSetMappingsRestClient.ListByShareSubscriptionNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ShareDataSetMappingResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List DataSetMappings in a share subscription
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shareSubscriptions/{shareSubscriptionName}/dataSetMappings
        /// Operation Id: DataSetMappings_ListByShareSubscription
        /// </summary>
        /// <param name="skipToken"> Continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ShareDataSetMappingResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ShareDataSetMappingResource> GetAll(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<ShareDataSetMappingResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _shareDataSetMappingDataSetMappingsClientDiagnostics.CreateScope("ShareDataSetMappingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _shareDataSetMappingDataSetMappingsRestClient.ListByShareSubscription(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ShareDataSetMappingResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ShareDataSetMappingResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _shareDataSetMappingDataSetMappingsClientDiagnostics.CreateScope("ShareDataSetMappingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _shareDataSetMappingDataSetMappingsRestClient.ListByShareSubscriptionNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ShareDataSetMappingResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
