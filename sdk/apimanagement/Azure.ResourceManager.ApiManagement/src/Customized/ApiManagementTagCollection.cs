// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A class representing a collection of <see cref="ApiManagementTagResource" /> and their operations.
    /// Each <see cref="ApiManagementTagResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementTagCollection" /> instance call the GetApiManagementTags method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementTagCollection : ArmCollection, IEnumerable<ApiManagementTagResource>, IAsyncEnumerable<ApiManagementTagResource>
    {
        /// <summary>
        /// Lists a collection of tags defined within a service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tags
        /// Operation Id: Tag_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="scope"> Scope like &apos;apis&apos;, &apos;products&apos; or &apos;apis/{apiId}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementTagResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementTagResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, string scope = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new ApiManagementTagCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                Scope = scope
            }, cancellationToken);

        /// <summary>
        /// Lists a collection of tags defined within a service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tags
        /// Operation Id: Tag_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="scope"> Scope like &apos;apis&apos;, &apos;products&apos; or &apos;apis/{apiId}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementTagResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementTagResource> GetAll(string filter = null, int? top = null, int? skip = null, string scope = null, CancellationToken cancellationToken = default) =>
            GetAll(new ApiManagementTagCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                Scope = scope
            }, cancellationToken);
    }
}
