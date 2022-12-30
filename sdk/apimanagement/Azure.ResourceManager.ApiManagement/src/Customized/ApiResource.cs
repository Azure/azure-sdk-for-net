// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A Class representing an Api along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="ApiResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetApiResource method.
    /// Otherwise you can get one from its parent resource <see cref="ApiManagementServiceResource" /> using the GetApi method.
    /// </summary>
    public partial class ApiResource : ArmResource
    {
        /// <summary>
        /// Lists all revisions of an API.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/revisions
        /// Operation Id: ApiRevision_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| apiRevision | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiRevisionContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiRevisionContract> GetApiRevisionsByServiceAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetApiRevisionsByServiceAsync(new ApiResourceGetApiRevisionsByServiceOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);

        /// <summary>
        /// Lists all revisions of an API.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/revisions
        /// Operation Id: ApiRevision_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| apiRevision | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiRevisionContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiRevisionContract> GetApiRevisionsByService(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetApiRevisionsByService(new ApiResourceGetApiRevisionsByServiceOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);

        /// <summary>
        /// Lists all Products, which the API is part of.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/products
        /// Operation Id: ApiProduct_ListByApis
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ApiManagementProductResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ApiManagementProductResource> GetApiProductsAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetApiProductsAsync(new ApiResourceGetApiProductsOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);

        /// <summary>
        /// Lists all Products, which the API is part of.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/products
        /// Operation Id: ApiProduct_ListByApis
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ApiManagementProductResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ApiManagementProductResource> GetApiProducts(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetApiProducts(new ApiResourceGetApiProductsOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);

        /// <summary>
        /// Lists a collection of operations associated with tags.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/operationsByTags
        /// Operation Id: Operation_ListByTags
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| apiName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| method | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| urlTemplate | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="includeNotTaggedOperations"> Include not tagged Operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TagResourceContractDetails" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TagResourceContractDetails> GetOperationsByTagsAsync(string filter = null, int? top = null, int? skip = null, bool? includeNotTaggedOperations = null, CancellationToken cancellationToken = default) =>
            GetOperationsByTagsAsync(new ApiResourceGetOperationsByTagsOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                IncludeNotTaggedOperations = includeNotTaggedOperations
            }, cancellationToken);

        /// <summary>
        /// Lists a collection of operations associated with tags.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apis/{apiId}/operationsByTags
        /// Operation Id: Operation_ListByTags
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| apiName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| method | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| urlTemplate | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="includeNotTaggedOperations"> Include not tagged Operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TagResourceContractDetails" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TagResourceContractDetails> GetOperationsByTags(string filter = null, int? top = null, int? skip = null, bool? includeNotTaggedOperations = null, CancellationToken cancellationToken = default) =>
            GetOperationsByTags(new ApiResourceGetOperationsByTagsOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                IncludeNotTaggedOperations = includeNotTaggedOperations
            }, cancellationToken);
    }
}
