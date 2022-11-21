// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Media
{
    /// <summary>
    /// A class representing a collection of <see cref="ContentKeyPolicyResource" /> and their operations.
    /// Each <see cref="ContentKeyPolicyResource" /> in the collection will belong to the same instance of <see cref="MediaServicesAccountResource" />.
    /// To get a <see cref="ContentKeyPolicyCollection" /> instance call the GetContentKeyPolicies method from an instance of <see cref="MediaServicesAccountResource" />.
    /// </summary>
    public partial class ContentKeyPolicyCollection : ArmCollection, IEnumerable<ContentKeyPolicyResource>, IAsyncEnumerable<ContentKeyPolicyResource>
    {
        /// <summary>
        /// Lists the Content Key Policies in the account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/contentKeyPolicies
        /// Operation Id: ContentKeyPolicies_List
        /// </summary>
        /// <param name="filter"> Restricts the set of items returned. </param>
        /// <param name="top"> Specifies a non-negative integer n that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value n. </param>
        /// <param name="orderby"> Specifies the key by which the result collection should be ordered. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ContentKeyPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ContentKeyPolicyResource> GetAllAsync(string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ContentKeyPolicyResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _contentKeyPolicyClientDiagnostics.CreateScope("ContentKeyPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _contentKeyPolicyRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ContentKeyPolicyResource(Client, value)), response.Value.OdataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ContentKeyPolicyResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _contentKeyPolicyClientDiagnostics.CreateScope("ContentKeyPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _contentKeyPolicyRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ContentKeyPolicyResource(Client, value)), response.Value.OdataNextLink, response.GetRawResponse());
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
        /// Lists the Content Key Policies in the account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/contentKeyPolicies
        /// Operation Id: ContentKeyPolicies_List
        /// </summary>
        /// <param name="filter"> Restricts the set of items returned. </param>
        /// <param name="top"> Specifies a non-negative integer n that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value n. </param>
        /// <param name="orderby"> Specifies the key by which the result collection should be ordered. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ContentKeyPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ContentKeyPolicyResource> GetAll(string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<ContentKeyPolicyResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _contentKeyPolicyClientDiagnostics.CreateScope("ContentKeyPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _contentKeyPolicyRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ContentKeyPolicyResource(Client, value)), response.Value.OdataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ContentKeyPolicyResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _contentKeyPolicyClientDiagnostics.CreateScope("ContentKeyPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _contentKeyPolicyRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ContentKeyPolicyResource(Client, value)), response.Value.OdataNextLink, response.GetRawResponse());
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
