// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A class representing a collection of <see cref="ApiIssueCommentResource" /> and their operations.
    /// Each <see cref="ApiIssueCommentResource" /> in the collection will belong to the same instance of <see cref="ApiIssueResource" />.
    /// To get an <see cref="ApiIssueCommentCollection" /> instance call the GetApiIssueComments method from an instance of <see cref="ApiIssueResource" />.
    /// </summary>
    public partial class ApiIssueCommentCollection : ArmCollection, IEnumerable<ApiIssueCommentResource>, IAsyncEnumerable<ApiIssueCommentResource>
    {
        /// <summary>
        /// Lists all comments for the Issue associated with the specified API.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/issues/{issueId}/comments
        /// Operation Id: ApiIssueComment_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| userId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiIssueCommentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiIssueCommentResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiIssueCommentResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiIssueCommentClientDiagnostics.CreateScope("ApiIssueCommentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiIssueCommentRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiIssueCommentResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiIssueCommentResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiIssueCommentClientDiagnostics.CreateScope("ApiIssueCommentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiIssueCommentRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiIssueCommentResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all comments for the Issue associated with the specified API.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/issues/{issueId}/comments
        /// Operation Id: ApiIssueComment_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| userId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiIssueCommentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiIssueCommentResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiIssueCommentResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiIssueCommentClientDiagnostics.CreateScope("ApiIssueCommentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiIssueCommentRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiIssueCommentResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiIssueCommentResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiIssueCommentClientDiagnostics.CreateScope("ApiIssueCommentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiIssueCommentRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiIssueCommentResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
