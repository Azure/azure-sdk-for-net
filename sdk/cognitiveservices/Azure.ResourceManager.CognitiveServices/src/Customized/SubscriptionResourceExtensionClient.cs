// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.CognitiveServices
{
    internal partial class SubscriptionResourceExtensionClient
    {
        /// <summary>
        /// Returns all the resources of a particular type belonging to a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.CognitiveServices/deletedAccounts
        /// Operation Id: DeletedAccounts_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CognitiveServicesDeletedAccountResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CognitiveServicesDeletedAccountResource> GetDeletedAccountsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<CognitiveServicesDeletedAccountResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = DeletedAccountsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetDeletedAccounts");
                scope.Start();
                try
                {
                    var response = await DeletedAccountsRestClient.ListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new CognitiveServicesDeletedAccountResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<CognitiveServicesDeletedAccountResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = DeletedAccountsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetDeletedAccounts");
                scope.Start();
                try
                {
                    var response = await DeletedAccountsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new CognitiveServicesDeletedAccountResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Returns all the resources of a particular type belonging to a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.CognitiveServices/deletedAccounts
        /// Operation Id: DeletedAccounts_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CognitiveServicesDeletedAccountResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CognitiveServicesDeletedAccountResource> GetDeletedAccounts(CancellationToken cancellationToken = default)
        {
            Page<CognitiveServicesDeletedAccountResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = DeletedAccountsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetDeletedAccounts");
                scope.Start();
                try
                {
                    var response = DeletedAccountsRestClient.List(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new CognitiveServicesDeletedAccountResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<CognitiveServicesDeletedAccountResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = DeletedAccountsClientDiagnostics.CreateScope("SubscriptionResourceExtensionClient.GetDeletedAccounts");
                scope.Start();
                try
                {
                    var response = DeletedAccountsRestClient.ListNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new CognitiveServicesDeletedAccountResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
