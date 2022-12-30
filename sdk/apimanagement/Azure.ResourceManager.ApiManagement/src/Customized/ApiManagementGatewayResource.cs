// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A Class representing an ApiManagementGateway along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="ApiManagementGatewayResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetApiManagementGatewayResource method.
    /// Otherwise you can get one from its parent resource <see cref="ApiManagementServiceResource" /> using the GetApiManagementGateway method.
    /// </summary>
    public partial class ApiManagementGatewayResource : ArmResource
    {
        /// <summary>
        /// Lists a collection of the APIs associated with a gateway.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}/apis
        /// Operation Id: GatewayApi_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="GatewayApiData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GatewayApiData> GetGatewayApisByServiceAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetGatewayApisByServiceAsync(new ApiManagementGatewayResourceGetGatewayApisByServiceOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);

        /// <summary>
        /// Lists a collection of the APIs associated with a gateway.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/gateways/{gatewayId}/apis
        /// Operation Id: GatewayApi_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GatewayApiData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GatewayApiData> GetGatewayApisByService(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetGatewayApisByService(new ApiManagementGatewayResourceGetGatewayApisByServiceOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);
    }
}
