// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A class representing a collection of <see cref="ApiResource" /> and their operations.
    /// Each <see cref="ApiResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiCollection" /> instance call the GetApis method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiCollection : ArmCollection, IEnumerable<ApiResource>, IAsyncEnumerable<ApiResource>
    {
        /// <summary>
        /// Lists all APIs of the API Management service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis
        /// Operation Id: Api_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| serviceUrl | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| path | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| isCurrent | filter | eq, ne |  |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="tags"> Include tags in the response. </param>
        /// <param name="expandApiVersionSet"> Include full ApiVersionSet resource in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, string tags = null, bool? expandApiVersionSet = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new ApiCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                Tags = tags,
                ExpandApiVersionSet = expandApiVersionSet
            }, cancellationToken);

        /// <summary>
        /// Lists all APIs of the API Management service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis
        /// Operation Id: Api_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| serviceUrl | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| path | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| isCurrent | filter | eq, ne |  |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="tags"> Include tags in the response. </param>
        /// <param name="expandApiVersionSet"> Include full ApiVersionSet resource in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiResource> GetAll(string filter = null, int? top = null, int? skip = null, string tags = null, bool? expandApiVersionSet = null, CancellationToken cancellationToken = default) =>
            GetAll(new ApiCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                Tags = tags,
                ExpandApiVersionSet = expandApiVersionSet
            }, cancellationToken);
    }
}
