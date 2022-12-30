// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A class representing a collection of <see cref="ApiManagementPortalRevisionResource" /> and their operations.
    /// Each <see cref="ApiManagementPortalRevisionResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementPortalRevisionCollection" /> instance call the GetApiManagementPortalRevisions method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementPortalRevisionCollection : ArmCollection, IEnumerable<ApiManagementPortalRevisionResource>, IAsyncEnumerable<ApiManagementPortalRevisionResource>
    {
        /// <summary>
        /// Lists developer portal&apos;s revisions.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/portalRevisions
        /// Operation Id: PortalRevision_ListByService
        /// </summary>
        /// <param name="filter">
        /// | Field       | Supported operators    | Supported functions               |
        /// |-------------|------------------------|-----------------------------------|
        ///
        /// |name | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith|
        /// |description | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith|
        /// |isCurrent | eq, ne |    |
        ///
        /// </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementPortalRevisionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementPortalRevisionResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new ApiManagementPortalRevisionCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);

        /// <summary>
        /// Lists developer portal&apos;s revisions.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/portalRevisions
        /// Operation Id: PortalRevision_ListByService
        /// </summary>
        /// <param name="filter">
        /// | Field       | Supported operators    | Supported functions               |
        /// |-------------|------------------------|-----------------------------------|
        ///
        /// |name | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith|
        /// |description | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith|
        /// |isCurrent | eq, ne |    |
        ///
        /// </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementPortalRevisionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementPortalRevisionResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetAll(new ApiManagementPortalRevisionCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);
    }
}
