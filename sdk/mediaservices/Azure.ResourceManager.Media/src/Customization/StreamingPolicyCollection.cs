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
    /// A class representing a collection of <see cref="StreamingPolicyResource" /> and their operations.
    /// Each <see cref="StreamingPolicyResource" /> in the collection will belong to the same instance of <see cref="MediaServicesAccountResource" />.
    /// To get a <see cref="StreamingPolicyCollection" /> instance call the GetStreamingPolicies method from an instance of <see cref="MediaServicesAccountResource" />.
    /// </summary>
    public partial class StreamingPolicyCollection : ArmCollection, IEnumerable<StreamingPolicyResource>, IAsyncEnumerable<StreamingPolicyResource>
    {
        /// <summary>
        /// Lists the Streaming Policies in the account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/streamingPolicies
        /// Operation Id: StreamingPolicies_List
        /// </summary>
        /// <param name="filter"> Restricts the set of items returned. </param>
        /// <param name="top"> Specifies a non-negative integer n that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value n. </param>
        /// <param name="orderby"> Specifies the key by which the result collection should be ordered. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="StreamingPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<StreamingPolicyResource> GetAllAsync(string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<StreamingPolicyResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _streamingPolicyClientDiagnostics.CreateScope("StreamingPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _streamingPolicyRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new StreamingPolicyResource(Client, value)), response.Value.OdataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<StreamingPolicyResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _streamingPolicyClientDiagnostics.CreateScope("StreamingPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _streamingPolicyRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new StreamingPolicyResource(Client, value)), response.Value.OdataNextLink, response.GetRawResponse());
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
        /// Lists the Streaming Policies in the account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/streamingPolicies
        /// Operation Id: StreamingPolicies_List
        /// </summary>
        /// <param name="filter"> Restricts the set of items returned. </param>
        /// <param name="top"> Specifies a non-negative integer n that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value n. </param>
        /// <param name="orderby"> Specifies the key by which the result collection should be ordered. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="StreamingPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<StreamingPolicyResource> GetAll(string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<StreamingPolicyResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _streamingPolicyClientDiagnostics.CreateScope("StreamingPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _streamingPolicyRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new StreamingPolicyResource(Client, value)), response.Value.OdataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<StreamingPolicyResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _streamingPolicyClientDiagnostics.CreateScope("StreamingPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _streamingPolicyRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new StreamingPolicyResource(Client, value)), response.Value.OdataNextLink, response.GetRawResponse());
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
