// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.ApiManagement.Models;

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
        public virtual AsyncPageable<ApiIssueCommentResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new ApiIssueCommentCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);

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
        public virtual Pageable<ApiIssueCommentResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetAll(new ApiIssueCommentCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);
    }
}
