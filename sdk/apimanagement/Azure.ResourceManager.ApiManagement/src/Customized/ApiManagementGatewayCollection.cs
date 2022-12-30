// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A class representing a collection of <see cref="ApiManagementGatewayResource" /> and their operations.
    /// Each <see cref="ApiManagementGatewayResource" /> in the collection will belong to the same instance of <see cref="ApiManagementServiceResource" />.
    /// To get an <see cref="ApiManagementGatewayCollection" /> instance call the GetApiManagementGateways method from an instance of <see cref="ApiManagementServiceResource" />.
    /// </summary>
    public partial class ApiManagementGatewayCollection : ArmCollection, IEnumerable<ApiManagementGatewayResource>, IAsyncEnumerable<ApiManagementGatewayResource>
    {
        /// <summary>
        /// Lists a collection of gateways registered with service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways
        /// Operation Id: Gateway_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| region | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementGatewayResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementGatewayResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new ApiManagementGatewayCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);

        /// <summary>
        /// Lists a collection of gateways registered with service instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways
        /// Operation Id: Gateway_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| region | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementGatewayResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementGatewayResource> GetAll(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetAll(new ApiManagementGatewayCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);
    }
}
