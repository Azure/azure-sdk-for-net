// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.ApiManagement.Models;

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
        public virtual AsyncPageable<ApiIssueResource> GetAllAsync(string filter = null, bool? expandCommentsAttachments = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new ApiIssueCollectionGetAllOptions
            {
                Filter = filter,
                ExpandCommentsAttachments = expandCommentsAttachments,
                Top = top,
                Skip = skip
            }, cancellationToken);

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
        public virtual Pageable<ApiIssueResource> GetAll(string filter = null, bool? expandCommentsAttachments = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetAll(new ApiIssueCollectionGetAllOptions
            {
                Filter = filter,
                ExpandCommentsAttachments = expandCommentsAttachments,
                Top = top,
                Skip = skip
            }, cancellationToken);
    }
}
