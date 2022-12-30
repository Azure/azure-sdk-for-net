// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A class representing a collection of <see cref="ApiOperationTagResource" /> and their operations.
    /// Each <see cref="ApiOperationTagResource" /> in the collection will belong to the same instance of <see cref="ApiOperationResource" />.
    /// To get an <see cref="ApiOperationTagCollection" /> instance call the GetApiOperationTags method from an instance of <see cref="ApiOperationResource" />.
    /// </summary>
    public partial class ApiOperationTagCollection : ArmCollection, IEnumerable<ApiOperationTagResource>, IAsyncEnumerable<ApiOperationTagResource>
    {
        /// <summary>
        /// Lists all Tags associated with the Operation.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/operations/{operationId}/tags
        /// Operation Id: Tag_ListByOperation
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiOperationTagResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiOperationTagResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new ApiOperationTagCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);

        /// <summary>
        /// Lists all Tags associated with the Operation.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/operations/{operationId}/tags
        /// Operation Id: Tag_ListByOperation
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiOperationTagResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiOperationTagResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetAll(new ApiOperationTagCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);
    }
}
