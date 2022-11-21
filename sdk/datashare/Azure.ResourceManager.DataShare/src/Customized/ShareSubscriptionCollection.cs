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
    /// A class representing a collection of <see cref="ShareSubscriptionResource" /> and their operations.
    /// Each <see cref="ShareSubscriptionResource" /> in the collection will belong to the same instance of <see cref="DataShareAccountResource" />.
    /// To get a <see cref="ShareSubscriptionCollection" /> instance call the GetShareSubscriptions method from an instance of <see cref="DataShareAccountResource" />.
    /// </summary>
    public partial class ShareSubscriptionCollection : ArmCollection, IEnumerable<ShareSubscriptionResource>, IAsyncEnumerable<ShareSubscriptionResource>
    {
        /// <summary>
        /// List share subscriptions in an account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shareSubscriptions
        /// Operation Id: ShareSubscriptions_ListByAccount
        /// </summary>
        /// <param name="skipToken"> Continuation Token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ShareSubscriptionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ShareSubscriptionResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ShareSubscriptionResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _shareSubscriptionClientDiagnostics.CreateScope("ShareSubscriptionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _shareSubscriptionRestClient.ListByAccountAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ShareSubscriptionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ShareSubscriptionResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _shareSubscriptionClientDiagnostics.CreateScope("ShareSubscriptionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _shareSubscriptionRestClient.ListByAccountNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ShareSubscriptionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List share subscriptions in an account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shareSubscriptions
        /// Operation Id: ShareSubscriptions_ListByAccount
        /// </summary>
        /// <param name="skipToken"> Continuation Token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ShareSubscriptionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ShareSubscriptionResource> GetAll(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<ShareSubscriptionResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _shareSubscriptionClientDiagnostics.CreateScope("ShareSubscriptionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _shareSubscriptionRestClient.ListByAccount(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ShareSubscriptionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ShareSubscriptionResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _shareSubscriptionClientDiagnostics.CreateScope("ShareSubscriptionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _shareSubscriptionRestClient.ListByAccountNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ShareSubscriptionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
