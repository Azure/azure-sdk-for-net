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
    /// A class representing a collection of <see cref="ApiIssueAttachmentResource" /> and their operations.
    /// Each <see cref="ApiIssueAttachmentResource" /> in the collection will belong to the same instance of <see cref="ApiIssueResource" />.
    /// To get an <see cref="ApiIssueAttachmentCollection" /> instance call the GetApiIssueAttachments method from an instance of <see cref="ApiIssueResource" />.
    /// </summary>
    public partial class ApiIssueAttachmentCollection : ArmCollection, IEnumerable<ApiIssueAttachmentResource>, IAsyncEnumerable<ApiIssueAttachmentResource>
    {
        /// <summary>
        /// Lists all attachments for the Issue associated with the specified API.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/issues/{issueId}/attachments
        /// Operation Id: ApiIssueAttachment_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| userId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiIssueAttachmentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiIssueAttachmentResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ApiIssueAttachmentResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiIssueAttachmentClientDiagnostics.CreateScope("ApiIssueAttachmentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiIssueAttachmentRestClient.ListByServiceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiIssueAttachmentResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ApiIssueAttachmentResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiIssueAttachmentClientDiagnostics.CreateScope("ApiIssueAttachmentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _apiIssueAttachmentRestClient.ListByServiceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiIssueAttachmentResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all attachments for the Issue associated with the specified API.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/issues/{issueId}/attachments
        /// Operation Id: ApiIssueAttachment_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| userId | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiIssueAttachmentResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiIssueAttachmentResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default)
        {
            Page<ApiIssueAttachmentResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _apiIssueAttachmentClientDiagnostics.CreateScope("ApiIssueAttachmentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiIssueAttachmentRestClient.ListByService(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiIssueAttachmentResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ApiIssueAttachmentResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _apiIssueAttachmentClientDiagnostics.CreateScope("ApiIssueAttachmentCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _apiIssueAttachmentRestClient.ListByServiceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, filter, top, skip, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ApiIssueAttachmentResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
