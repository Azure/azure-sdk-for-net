// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A class representing a collection of <see cref="ApiOperationResource" /> and their operations.
    /// Each <see cref="ApiOperationResource" /> in the collection will belong to the same instance of <see cref="ApiResource" />.
    /// To get an <see cref="ApiOperationCollection" /> instance call the GetApiOperations method from an instance of <see cref="ApiResource" />.
    /// </summary>
    public partial class ApiOperationCollection : ArmCollection, IEnumerable<ApiOperationResource>, IAsyncEnumerable<ApiOperationResource>
    {
        /// <summary>
        /// Lists a collection of the operations for the specified API.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/operations
        /// Operation Id: ApiOperation_ListByApi
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| method | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| urlTemplate | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="tags"> Include tags in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiOperationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiOperationResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, string tags = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new ApiOperationCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                Tags = tags
            }, cancellationToken);

        /// <summary>
        /// Lists a collection of the operations for the specified API.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/operations
        /// Operation Id: ApiOperation_ListByApi
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| method | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| urlTemplate | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="tags"> Include tags in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiOperationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiOperationResource> GetAll(string filter = null, int? top = null, int? skip = null, string tags = null, CancellationToken cancellationToken = default) =>
            GetAll(new ApiOperationCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                Tags = tags
            }, cancellationToken);
    }
}
