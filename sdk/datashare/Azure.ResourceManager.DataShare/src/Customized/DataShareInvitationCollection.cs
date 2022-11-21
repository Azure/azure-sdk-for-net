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
    /// A class representing a collection of <see cref="DataShareInvitationResource" /> and their operations.
    /// Each <see cref="DataShareInvitationResource" /> in the collection will belong to the same instance of <see cref="DataShareResource" />.
    /// To get a <see cref="DataShareInvitationCollection" /> instance call the GetDataShareInvitations method from an instance of <see cref="DataShareResource" />.
    /// </summary>
    public partial class DataShareInvitationCollection : ArmCollection, IEnumerable<DataShareInvitationResource>, IAsyncEnumerable<DataShareInvitationResource>
    {
        /// <summary>
        /// List invitations in a share
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares/{shareName}/invitations
        /// Operation Id: Invitations_ListByShare
        /// </summary>
        /// <param name="skipToken"> The continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DataShareInvitationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DataShareInvitationResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DataShareInvitationResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dataShareInvitationInvitationsClientDiagnostics.CreateScope("DataShareInvitationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dataShareInvitationInvitationsRestClient.ListByShareAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DataShareInvitationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DataShareInvitationResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dataShareInvitationInvitationsClientDiagnostics.CreateScope("DataShareInvitationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dataShareInvitationInvitationsRestClient.ListByShareNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DataShareInvitationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List invitations in a share
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares/{shareName}/invitations
        /// Operation Id: Invitations_ListByShare
        /// </summary>
        /// <param name="skipToken"> The continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DataShareInvitationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DataShareInvitationResource> GetAll(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DataShareInvitationResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dataShareInvitationInvitationsClientDiagnostics.CreateScope("DataShareInvitationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dataShareInvitationInvitationsRestClient.ListByShare(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DataShareInvitationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DataShareInvitationResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dataShareInvitationInvitationsClientDiagnostics.CreateScope("DataShareInvitationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dataShareInvitationInvitationsRestClient.ListByShareNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, skipToken, filter, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DataShareInvitationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
