// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A class representing a collection of <see cref="ApiManagementNamedValueResource" /> and their operations.
    /// Each <see cref="ApiManagementNamedValueResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementNamedValueCollection" /> instance call the GetApiManagementNamedValues method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementNamedValueCollection : ArmCollection, IEnumerable<ApiManagementNamedValueResource>, IAsyncEnumerable<ApiManagementNamedValueResource>
    {
        /// <summary>
        /// Lists a collection of named values defined within a service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/namedValues
        /// Operation Id: NamedValue_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| tags | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith, any, all |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="isKeyVaultRefreshFailed"> When set to true, the response contains only named value entities which failed refresh. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementNamedValueResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementNamedValueResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, bool? isKeyVaultRefreshFailed = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new ApiManagementNamedValueCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                IsKeyVaultRefreshFailed = isKeyVaultRefreshFailed
            }, cancellationToken);

        /// <summary>
        /// Lists a collection of named values defined within a service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/namedValues
        /// Operation Id: NamedValue_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| tags | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith, any, all |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="isKeyVaultRefreshFailed"> When set to true, the response contains only named value entities which failed refresh. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementNamedValueResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementNamedValueResource> GetAll(string filter = null, int? top = null, int? skip = null, bool? isKeyVaultRefreshFailed = null, CancellationToken cancellationToken = default) =>
            GetAll(new ApiManagementNamedValueCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                IsKeyVaultRefreshFailed = isKeyVaultRefreshFailed
            }, cancellationToken);
    }
}
