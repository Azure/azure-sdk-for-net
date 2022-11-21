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
    /// A class representing a collection of <see cref="ApiIssueResource" /> and their operations.
    /// Each <see cref="ApiIssueResource" /> in the collection will belong to the same instance of <see cref="ApiResource" />.
    /// To get an <see cref="ApiIssueCollection" /> instance call the GetApiIssues method from an instance of <see cref="ApiResource" />.
    /// </summary>
    public partial class ApiIssueCollection : ArmCollection, IEnumerable<ApiIssueResource>, IAsyncEnumerable<ApiIssueResource>
    {
        /// <summary>
        /// Lists all issues associated with the specified API.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/issues
        /// Operation Id: ApiIssue_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| userId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| state | filter | eq |     |&lt;/br&gt;. </param>
        /// <param name="expandCommentsAttachments"> Expand the comment attachments. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiIssueResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiIssueResource> GetAllAsync(string filter = null, bool? expandCommentsAttachments = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiIssueResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiIssueClientDiagnostics.CreateScope("ApiIssueCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiIssueRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, expandCommentsAttachments, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiIssueResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiIssueResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiIssueClientDiagnostics.CreateScope("ApiIssueCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiIssueRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, expandCommentsAttachments, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiIssueResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all issues associated with the specified API.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/issues
        /// Operation Id: ApiIssue_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| userId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| state | filter | eq |     |&lt;/br&gt;. </param>
        /// <param name="expandCommentsAttachments"> Expand the comment attachments. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiIssueResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiIssueResource> GetAll(string filter = null, bool? expandCommentsAttachments = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiIssueResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiIssueClientDiagnostics.CreateScope("ApiIssueCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiIssueRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, expandCommentsAttachments, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiIssueResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiIssueResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiIssueClientDiagnostics.CreateScope("ApiIssueCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiIssueRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, expandCommentsAttachments, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiIssueResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
