// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ApiManagement
{
    /// <summary>
    /// A Class representing an ApiManagementService along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="ApiManagementServiceResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetApiManagementServiceResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetApiManagementService method.
    /// </summary>
    public partial class ApiManagementServiceResource : ArmResource
    {
        /// <summary>
        /// Lists a collection of apis associated with tags.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apisByTags
        /// Operation Id: Api_ListByTags
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| apiRevision | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| path | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| serviceUrl | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| isCurrent | filter | eq |     |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="includeNotTaggedApis"> Include not tagged APIs. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TagResourceContractDetails" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TagResourceContractDetails> GetApisByTagsAsync(string filter = null, int? top = null, int? skip = null, bool? includeNotTaggedApis = null, CancellationToken cancellationToken = default) =>
            GetApisByTagsAsync(new ApiManagementServiceResourceGetApisByTagsOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                IncludeNotTaggedApis = includeNotTaggedApis
            }, cancellationToken);

        /// <summary>
        /// Lists a collection of apis associated with tags.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/apisByTags
        /// Operation Id: Api_ListByTags
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| apiRevision | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| path | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| serviceUrl | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| isCurrent | filter | eq |     |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="includeNotTaggedApis"> Include not tagged APIs. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TagResourceContractDetails" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TagResourceContractDetails> GetApisByTags(string filter = null, int? top = null, int? skip = null, bool? includeNotTaggedApis = null, CancellationToken cancellationToken = default) =>
            GetApisByTags(new ApiManagementServiceResourceGetApisByTagsOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                IncludeNotTaggedApis = includeNotTaggedApis
            }, cancellationToken);

        /// <summary>
        /// Lists a collection of products associated with tags.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/productsByTags
        /// Operation Id: Product_ListByTags
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| terms | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| state | filter | eq | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="includeNotTaggedProducts"> Include not tagged Products. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TagResourceContractDetails" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TagResourceContractDetails> GetProductsByTagsAsync(string filter = null, int? top = null, int? skip = null, bool? includeNotTaggedProducts = null, CancellationToken cancellationToken = default) =>
            GetProductsByTagsAsync(new ApiManagementServiceResourceGetProductsByTagsOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                IncludeNotTaggedProducts = includeNotTaggedProducts
            }, cancellationToken);

        /// <summary>
        /// Lists a collection of products associated with tags.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/productsByTags
        /// Operation Id: Product_ListByTags
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| terms | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| state | filter | eq | substringof, contains, startswith, endswith |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="includeNotTaggedProducts"> Include not tagged Products. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TagResourceContractDetails" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TagResourceContractDetails> GetProductsByTags(string filter = null, int? top = null, int? skip = null, bool? includeNotTaggedProducts = null, CancellationToken cancellationToken = default) =>
            GetProductsByTags(new ApiManagementServiceResourceGetProductsByTagsOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                IncludeNotTaggedProducts = includeNotTaggedProducts
            }, cancellationToken);

        /// <summary>
        /// Lists report records by API.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/byApi
        /// Operation Id: Reports_ListByApi
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="orderBy"> OData order by query option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> An async collection of <see cref="ReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ReportRecordContract> GetReportsByApiAsync(string filter, int? top = null, int? skip = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            GetReportsByApiAsync(new ApiManagementServiceResourceGetReportsByApiOptions(filter)
            {
                Top = top,
                Skip = skip,
                OrderBy = orderBy
            }, cancellationToken);

        /// <summary>
        /// Lists report records by API.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/byApi
        /// Operation Id: Reports_ListByApi
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="orderBy"> OData order by query option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> A collection of <see cref="ReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ReportRecordContract> GetReportsByApi(string filter, int? top = null, int? skip = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            GetReportsByApi(new ApiManagementServiceResourceGetReportsByApiOptions(filter)
            {
                Top = top,
                Skip = skip,
                OrderBy = orderBy
            }, cancellationToken);

        /// <summary>
        /// Lists report records by User.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/byUser
        /// Operation Id: Reports_ListByUser
        /// </summary>
        /// <param name="filter"> |   Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| timestamp | filter | ge, le |     | &lt;/br&gt;| displayName | select, orderBy |     |     | &lt;/br&gt;| userId | select, filter | eq |     | &lt;/br&gt;| apiRegion | filter | eq |     | &lt;/br&gt;| productId | filter | eq |     | &lt;/br&gt;| subscriptionId | filter | eq |     | &lt;/br&gt;| apiId | filter | eq |     | &lt;/br&gt;| operationId | filter | eq |     | &lt;/br&gt;| callCountSuccess | select, orderBy |     |     | &lt;/br&gt;| callCountBlocked | select, orderBy |     |     | &lt;/br&gt;| callCountFailed | select, orderBy |     |     | &lt;/br&gt;| callCountOther | select, orderBy |     |     | &lt;/br&gt;| callCountTotal | select, orderBy |     |     | &lt;/br&gt;| bandwidth | select, orderBy |     |     | &lt;/br&gt;| cacheHitsCount | select |     |     | &lt;/br&gt;| cacheMissCount | select |     |     | &lt;/br&gt;| apiTimeAvg | select, orderBy |     |     | &lt;/br&gt;| apiTimeMin | select |     |     | &lt;/br&gt;| apiTimeMax | select |     |     | &lt;/br&gt;| serviceTimeAvg | select |     |     | &lt;/br&gt;| serviceTimeMin | select |     |     | &lt;/br&gt;| serviceTimeMax | select |     |     | &lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="orderBy"> OData order by query option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> An async collection of <see cref="ReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ReportRecordContract> GetReportsByUserAsync(string filter, int? top = null, int? skip = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            GetReportsByUserAsync(new ApiManagementServiceResourceGetReportsByUserOptions(filter)
            {
                Top = top,
                Skip = skip,
                OrderBy = orderBy
            }, cancellationToken);

        /// <summary>
        /// Lists report records by User.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/byUser
        /// Operation Id: Reports_ListByUser
        /// </summary>
        /// <param name="filter"> |   Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| timestamp | filter | ge, le |     | &lt;/br&gt;| displayName | select, orderBy |     |     | &lt;/br&gt;| userId | select, filter | eq |     | &lt;/br&gt;| apiRegion | filter | eq |     | &lt;/br&gt;| productId | filter | eq |     | &lt;/br&gt;| subscriptionId | filter | eq |     | &lt;/br&gt;| apiId | filter | eq |     | &lt;/br&gt;| operationId | filter | eq |     | &lt;/br&gt;| callCountSuccess | select, orderBy |     |     | &lt;/br&gt;| callCountBlocked | select, orderBy |     |     | &lt;/br&gt;| callCountFailed | select, orderBy |     |     | &lt;/br&gt;| callCountOther | select, orderBy |     |     | &lt;/br&gt;| callCountTotal | select, orderBy |     |     | &lt;/br&gt;| bandwidth | select, orderBy |     |     | &lt;/br&gt;| cacheHitsCount | select |     |     | &lt;/br&gt;| cacheMissCount | select |     |     | &lt;/br&gt;| apiTimeAvg | select, orderBy |     |     | &lt;/br&gt;| apiTimeMin | select |     |     | &lt;/br&gt;| apiTimeMax | select |     |     | &lt;/br&gt;| serviceTimeAvg | select |     |     | &lt;/br&gt;| serviceTimeMin | select |     |     | &lt;/br&gt;| serviceTimeMax | select |     |     | &lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="orderBy"> OData order by query option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> A collection of <see cref="ReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ReportRecordContract> GetReportsByUser(string filter, int? top = null, int? skip = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            GetReportsByUser(new ApiManagementServiceResourceGetReportsByUserOptions(filter)
            {
                Top = top,
                Skip = skip,
                OrderBy = orderBy
            }, cancellationToken);

        /// <summary>
        /// Lists report records by API Operations.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/byOperation
        /// Operation Id: Reports_ListByOperation
        /// </summary>
        /// <param name="filter"> |   Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| timestamp | filter | ge, le |     | &lt;/br&gt;| displayName | select, orderBy |     |     | &lt;/br&gt;| apiRegion | filter | eq |     | &lt;/br&gt;| userId | filter | eq |     | &lt;/br&gt;| productId | filter | eq |     | &lt;/br&gt;| subscriptionId | filter | eq |     | &lt;/br&gt;| apiId | filter | eq |     | &lt;/br&gt;| operationId | select, filter | eq |     | &lt;/br&gt;| callCountSuccess | select, orderBy |     |     | &lt;/br&gt;| callCountBlocked | select, orderBy |     |     | &lt;/br&gt;| callCountFailed | select, orderBy |     |     | &lt;/br&gt;| callCountOther | select, orderBy |     |     | &lt;/br&gt;| callCountTotal | select, orderBy |     |     | &lt;/br&gt;| bandwidth | select, orderBy |     |     | &lt;/br&gt;| cacheHitsCount | select |     |     | &lt;/br&gt;| cacheMissCount | select |     |     | &lt;/br&gt;| apiTimeAvg | select, orderBy |     |     | &lt;/br&gt;| apiTimeMin | select |     |     | &lt;/br&gt;| apiTimeMax | select |     |     | &lt;/br&gt;| serviceTimeAvg | select |     |     | &lt;/br&gt;| serviceTimeMin | select |     |     | &lt;/br&gt;| serviceTimeMax | select |     |     | &lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="orderBy"> OData order by query option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> An async collection of <see cref="ReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ReportRecordContract> GetReportsByOperationAsync(string filter, int? top = null, int? skip = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            GetReportsByOperationAsync(new ApiManagementServiceResourceGetReportsByOperationOptions(filter)
            {
                Top = top,
                Skip = skip,
                OrderBy = orderBy
            }, cancellationToken);

        /// <summary>
        /// Lists report records by API Operations.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/byOperation
        /// Operation Id: Reports_ListByOperation
        /// </summary>
        /// <param name="filter"> |   Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| timestamp | filter | ge, le |     | &lt;/br&gt;| displayName | select, orderBy |     |     | &lt;/br&gt;| apiRegion | filter | eq |     | &lt;/br&gt;| userId | filter | eq |     | &lt;/br&gt;| productId | filter | eq |     | &lt;/br&gt;| subscriptionId | filter | eq |     | &lt;/br&gt;| apiId | filter | eq |     | &lt;/br&gt;| operationId | select, filter | eq |     | &lt;/br&gt;| callCountSuccess | select, orderBy |     |     | &lt;/br&gt;| callCountBlocked | select, orderBy |     |     | &lt;/br&gt;| callCountFailed | select, orderBy |     |     | &lt;/br&gt;| callCountOther | select, orderBy |     |     | &lt;/br&gt;| callCountTotal | select, orderBy |     |     | &lt;/br&gt;| bandwidth | select, orderBy |     |     | &lt;/br&gt;| cacheHitsCount | select |     |     | &lt;/br&gt;| cacheMissCount | select |     |     | &lt;/br&gt;| apiTimeAvg | select, orderBy |     |     | &lt;/br&gt;| apiTimeMin | select |     |     | &lt;/br&gt;| apiTimeMax | select |     |     | &lt;/br&gt;| serviceTimeAvg | select |     |     | &lt;/br&gt;| serviceTimeMin | select |     |     | &lt;/br&gt;| serviceTimeMax | select |     |     | &lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="orderBy"> OData order by query option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> A collection of <see cref="ReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ReportRecordContract> GetReportsByOperation(string filter, int? top = null, int? skip = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            GetReportsByOperation(new ApiManagementServiceResourceGetReportsByOperationOptions(filter)
            {
                Top = top,
                Skip = skip,
                OrderBy = orderBy
            }, cancellationToken);

        /// <summary>
        /// Lists report records by Product.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/byProduct
        /// Operation Id: Reports_ListByProduct
        /// </summary>
        /// <param name="filter"> |   Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| timestamp | filter | ge, le |     | &lt;/br&gt;| displayName | select, orderBy |     |     | &lt;/br&gt;| apiRegion | filter | eq |     | &lt;/br&gt;| userId | filter | eq |     | &lt;/br&gt;| productId | select, filter | eq |     | &lt;/br&gt;| subscriptionId | filter | eq |     | &lt;/br&gt;| callCountSuccess | select, orderBy |     |     | &lt;/br&gt;| callCountBlocked | select, orderBy |     |     | &lt;/br&gt;| callCountFailed | select, orderBy |     |     | &lt;/br&gt;| callCountOther | select, orderBy |     |     | &lt;/br&gt;| callCountTotal | select, orderBy |     |     | &lt;/br&gt;| bandwidth | select, orderBy |     |     | &lt;/br&gt;| cacheHitsCount | select |     |     | &lt;/br&gt;| cacheMissCount | select |     |     | &lt;/br&gt;| apiTimeAvg | select, orderBy |     |     | &lt;/br&gt;| apiTimeMin | select |     |     | &lt;/br&gt;| apiTimeMax | select |     |     | &lt;/br&gt;| serviceTimeAvg | select |     |     | &lt;/br&gt;| serviceTimeMin | select |     |     | &lt;/br&gt;| serviceTimeMax | select |     |     | &lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="orderBy"> OData order by query option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> An async collection of <see cref="ReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ReportRecordContract> GetReportsByProductAsync(string filter, int? top = null, int? skip = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            GetReportsByProductAsync(new ApiManagementServiceResourceGetReportsByProductOptions(filter)
            {
                Top = top,
                Skip = skip,
                OrderBy = orderBy
            }, cancellationToken);

        /// <summary>
        /// Lists report records by Product.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/byProduct
        /// Operation Id: Reports_ListByProduct
        /// </summary>
        /// <param name="filter"> |   Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| timestamp | filter | ge, le |     | &lt;/br&gt;| displayName | select, orderBy |     |     | &lt;/br&gt;| apiRegion | filter | eq |     | &lt;/br&gt;| userId | filter | eq |     | &lt;/br&gt;| productId | select, filter | eq |     | &lt;/br&gt;| subscriptionId | filter | eq |     | &lt;/br&gt;| callCountSuccess | select, orderBy |     |     | &lt;/br&gt;| callCountBlocked | select, orderBy |     |     | &lt;/br&gt;| callCountFailed | select, orderBy |     |     | &lt;/br&gt;| callCountOther | select, orderBy |     |     | &lt;/br&gt;| callCountTotal | select, orderBy |     |     | &lt;/br&gt;| bandwidth | select, orderBy |     |     | &lt;/br&gt;| cacheHitsCount | select |     |     | &lt;/br&gt;| cacheMissCount | select |     |     | &lt;/br&gt;| apiTimeAvg | select, orderBy |     |     | &lt;/br&gt;| apiTimeMin | select |     |     | &lt;/br&gt;| apiTimeMax | select |     |     | &lt;/br&gt;| serviceTimeAvg | select |     |     | &lt;/br&gt;| serviceTimeMin | select |     |     | &lt;/br&gt;| serviceTimeMax | select |     |     | &lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="orderBy"> OData order by query option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> A collection of <see cref="ReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ReportRecordContract> GetReportsByProduct(string filter, int? top = null, int? skip = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            GetReportsByProduct(new ApiManagementServiceResourceGetReportsByProductOptions(filter)
            {
                Top = top,
                Skip = skip,
                OrderBy = orderBy
            }, cancellationToken);

        /// <summary>
        /// Lists report records by geography.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/byGeo
        /// Operation Id: Reports_ListByGeo
        /// </summary>
        /// <param name="filter"> |   Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| timestamp | filter | ge, le |     | &lt;/br&gt;| country | select |     |     | &lt;/br&gt;| region | select |     |     | &lt;/br&gt;| zip | select |     |     | &lt;/br&gt;| apiRegion | filter | eq |     | &lt;/br&gt;| userId | filter | eq |     | &lt;/br&gt;| productId | filter | eq |     | &lt;/br&gt;| subscriptionId | filter | eq |     | &lt;/br&gt;| apiId | filter | eq |     | &lt;/br&gt;| operationId | filter | eq |     | &lt;/br&gt;| callCountSuccess | select |     |     | &lt;/br&gt;| callCountBlocked | select |     |     | &lt;/br&gt;| callCountFailed | select |     |     | &lt;/br&gt;| callCountOther | select |     |     | &lt;/br&gt;| bandwidth | select, orderBy |     |     | &lt;/br&gt;| cacheHitsCount | select |     |     | &lt;/br&gt;| cacheMissCount | select |     |     | &lt;/br&gt;| apiTimeAvg | select |     |     | &lt;/br&gt;| apiTimeMin | select |     |     | &lt;/br&gt;| apiTimeMax | select |     |     | &lt;/br&gt;| serviceTimeAvg | select |     |     | &lt;/br&gt;| serviceTimeMin | select |     |     | &lt;/br&gt;| serviceTimeMax | select |     |     | &lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> An async collection of <see cref="ReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ReportRecordContract> GetReportsByGeoAsync(string filter, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetReportsByGeoAsync(new ApiManagementServiceResourceGetReportsByGeoOptions(filter)
            {
                Top = top,
                Skip = skip
            }, cancellationToken);

        /// <summary>
        /// Lists report records by geography.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/byGeo
        /// Operation Id: Reports_ListByGeo
        /// </summary>
        /// <param name="filter"> |   Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| timestamp | filter | ge, le |     | &lt;/br&gt;| country | select |     |     | &lt;/br&gt;| region | select |     |     | &lt;/br&gt;| zip | select |     |     | &lt;/br&gt;| apiRegion | filter | eq |     | &lt;/br&gt;| userId | filter | eq |     | &lt;/br&gt;| productId | filter | eq |     | &lt;/br&gt;| subscriptionId | filter | eq |     | &lt;/br&gt;| apiId | filter | eq |     | &lt;/br&gt;| operationId | filter | eq |     | &lt;/br&gt;| callCountSuccess | select |     |     | &lt;/br&gt;| callCountBlocked | select |     |     | &lt;/br&gt;| callCountFailed | select |     |     | &lt;/br&gt;| callCountOther | select |     |     | &lt;/br&gt;| bandwidth | select, orderBy |     |     | &lt;/br&gt;| cacheHitsCount | select |     |     | &lt;/br&gt;| cacheMissCount | select |     |     | &lt;/br&gt;| apiTimeAvg | select |     |     | &lt;/br&gt;| apiTimeMin | select |     |     | &lt;/br&gt;| apiTimeMax | select |     |     | &lt;/br&gt;| serviceTimeAvg | select |     |     | &lt;/br&gt;| serviceTimeMin | select |     |     | &lt;/br&gt;| serviceTimeMax | select |     |     | &lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> A collection of <see cref="ReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ReportRecordContract> GetReportsByGeo(string filter, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetReportsByGeo(new ApiManagementServiceResourceGetReportsByGeoOptions(filter)
            {
                Top = top,
                Skip = skip
            }, cancellationToken);

        /// <summary>
        /// Lists report records by subscription.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/bySubscription
        /// Operation Id: Reports_ListBySubscription
        /// </summary>
        /// <param name="filter"> |   Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| timestamp | filter | ge, le |     | &lt;/br&gt;| displayName | select, orderBy |     |     | &lt;/br&gt;| apiRegion | filter | eq |     | &lt;/br&gt;| userId | select, filter | eq |     | &lt;/br&gt;| productId | select, filter | eq |     | &lt;/br&gt;| subscriptionId | select, filter | eq |     | &lt;/br&gt;| callCountSuccess | select, orderBy |     |     | &lt;/br&gt;| callCountBlocked | select, orderBy |     |     | &lt;/br&gt;| callCountFailed | select, orderBy |     |     | &lt;/br&gt;| callCountOther | select, orderBy |     |     | &lt;/br&gt;| callCountTotal | select, orderBy |     |     | &lt;/br&gt;| bandwidth | select, orderBy |     |     | &lt;/br&gt;| cacheHitsCount | select |     |     | &lt;/br&gt;| cacheMissCount | select |     |     | &lt;/br&gt;| apiTimeAvg | select, orderBy |     |     | &lt;/br&gt;| apiTimeMin | select |     |     | &lt;/br&gt;| apiTimeMax | select |     |     | &lt;/br&gt;| serviceTimeAvg | select |     |     | &lt;/br&gt;| serviceTimeMin | select |     |     | &lt;/br&gt;| serviceTimeMax | select |     |     | &lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="orderBy"> OData order by query option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> An async collection of <see cref="ReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ReportRecordContract> GetReportsBySubscriptionAsync(string filter, int? top = null, int? skip = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            GetReportsBySubscriptionAsync(new ApiManagementServiceResourceGetReportsBySubscriptionOptions(filter)
            {
                Top = top,
                Skip = skip,
                OrderBy = orderBy
            }, cancellationToken);

        /// <summary>
        /// Lists report records by subscription.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/bySubscription
        /// Operation Id: Reports_ListBySubscription
        /// </summary>
        /// <param name="filter"> |   Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| timestamp | filter | ge, le |     | &lt;/br&gt;| displayName | select, orderBy |     |     | &lt;/br&gt;| apiRegion | filter | eq |     | &lt;/br&gt;| userId | select, filter | eq |     | &lt;/br&gt;| productId | select, filter | eq |     | &lt;/br&gt;| subscriptionId | select, filter | eq |     | &lt;/br&gt;| callCountSuccess | select, orderBy |     |     | &lt;/br&gt;| callCountBlocked | select, orderBy |     |     | &lt;/br&gt;| callCountFailed | select, orderBy |     |     | &lt;/br&gt;| callCountOther | select, orderBy |     |     | &lt;/br&gt;| callCountTotal | select, orderBy |     |     | &lt;/br&gt;| bandwidth | select, orderBy |     |     | &lt;/br&gt;| cacheHitsCount | select |     |     | &lt;/br&gt;| cacheMissCount | select |     |     | &lt;/br&gt;| apiTimeAvg | select, orderBy |     |     | &lt;/br&gt;| apiTimeMin | select |     |     | &lt;/br&gt;| apiTimeMax | select |     |     | &lt;/br&gt;| serviceTimeAvg | select |     |     | &lt;/br&gt;| serviceTimeMin | select |     |     | &lt;/br&gt;| serviceTimeMax | select |     |     | &lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="orderBy"> OData order by query option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> A collection of <see cref="ReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ReportRecordContract> GetReportsBySubscription(string filter, int? top = null, int? skip = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            GetReportsBySubscription(new ApiManagementServiceResourceGetReportsBySubscriptionOptions(filter)
            {
                Top = top,
                Skip = skip,
                OrderBy = orderBy
            }, cancellationToken);

        /// <summary>
        /// Lists report records by Time.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/byTime
        /// Operation Id: Reports_ListByTime
        /// </summary>
        /// <param name="filter"> |   Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| timestamp | filter, select | ge, le |     | &lt;/br&gt;| interval | select |     |     | &lt;/br&gt;| apiRegion | filter | eq |     | &lt;/br&gt;| userId | filter | eq |     | &lt;/br&gt;| productId | filter | eq |     | &lt;/br&gt;| subscriptionId | filter | eq |     | &lt;/br&gt;| apiId | filter | eq |     | &lt;/br&gt;| operationId | filter | eq |     | &lt;/br&gt;| callCountSuccess | select |     |     | &lt;/br&gt;| callCountBlocked | select |     |     | &lt;/br&gt;| callCountFailed | select |     |     | &lt;/br&gt;| callCountOther | select |     |     | &lt;/br&gt;| bandwidth | select, orderBy |     |     | &lt;/br&gt;| cacheHitsCount | select |     |     | &lt;/br&gt;| cacheMissCount | select |     |     | &lt;/br&gt;| apiTimeAvg | select |     |     | &lt;/br&gt;| apiTimeMin | select |     |     | &lt;/br&gt;| apiTimeMax | select |     |     | &lt;/br&gt;| serviceTimeAvg | select |     |     | &lt;/br&gt;| serviceTimeMin | select |     |     | &lt;/br&gt;| serviceTimeMax | select |     |     | &lt;/br&gt;. </param>
        /// <param name="interval"> By time interval. Interval must be multiple of 15 minutes and may not be zero. The value should be in ISO  8601 format (http://en.wikipedia.org/wiki/ISO_8601#Durations).This code can be used to convert TimeSpan to a valid interval string: XmlConvert.ToString(new TimeSpan(hours, minutes, seconds)). </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="orderBy"> OData order by query option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> An async collection of <see cref="ReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ReportRecordContract> GetReportsByTimeAsync(string filter, TimeSpan interval, int? top = null, int? skip = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            GetReportsByTimeAsync(new ApiManagementServiceResourceGetReportsByTimeOptions(filter, interval)
            {
                Top = top,
                Skip = skip,
                OrderBy = orderBy
            }, cancellationToken);

        /// <summary>
        /// Lists report records by Time.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/byTime
        /// Operation Id: Reports_ListByTime
        /// </summary>
        /// <param name="filter"> |   Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| timestamp | filter, select | ge, le |     | &lt;/br&gt;| interval | select |     |     | &lt;/br&gt;| apiRegion | filter | eq |     | &lt;/br&gt;| userId | filter | eq |     | &lt;/br&gt;| productId | filter | eq |     | &lt;/br&gt;| subscriptionId | filter | eq |     | &lt;/br&gt;| apiId | filter | eq |     | &lt;/br&gt;| operationId | filter | eq |     | &lt;/br&gt;| callCountSuccess | select |     |     | &lt;/br&gt;| callCountBlocked | select |     |     | &lt;/br&gt;| callCountFailed | select |     |     | &lt;/br&gt;| callCountOther | select |     |     | &lt;/br&gt;| bandwidth | select, orderBy |     |     | &lt;/br&gt;| cacheHitsCount | select |     |     | &lt;/br&gt;| cacheMissCount | select |     |     | &lt;/br&gt;| apiTimeAvg | select |     |     | &lt;/br&gt;| apiTimeMin | select |     |     | &lt;/br&gt;| apiTimeMax | select |     |     | &lt;/br&gt;| serviceTimeAvg | select |     |     | &lt;/br&gt;| serviceTimeMin | select |     |     | &lt;/br&gt;| serviceTimeMax | select |     |     | &lt;/br&gt;. </param>
        /// <param name="interval"> By time interval. Interval must be multiple of 15 minutes and may not be zero. The value should be in ISO  8601 format (http://en.wikipedia.org/wiki/ISO_8601#Durations).This code can be used to convert TimeSpan to a valid interval string: XmlConvert.ToString(new TimeSpan(hours, minutes, seconds)). </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="orderBy"> OData order by query option. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> A collection of <see cref="ReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ReportRecordContract> GetReportsByTime(string filter, TimeSpan interval, int? top = null, int? skip = null, string orderBy = null, CancellationToken cancellationToken = default) =>
            GetReportsByTime(new ApiManagementServiceResourceGetReportsByTimeOptions(filter, interval)
            {
                Top = top,
                Skip = skip,
                OrderBy = orderBy
            }, cancellationToken);

        /// <summary>
        /// Lists report records by Request.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/byRequest
        /// Operation Id: Reports_ListByRequest
        /// </summary>
        /// <param name="filter"> |   Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| timestamp | filter | ge, le |     | &lt;/br&gt;| apiId | filter | eq |     | &lt;/br&gt;| operationId | filter | eq |     | &lt;/br&gt;| productId | filter | eq |     | &lt;/br&gt;| userId | filter | eq |     | &lt;/br&gt;| apiRegion | filter | eq |     | &lt;/br&gt;| subscriptionId | filter | eq |     | &lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> An async collection of <see cref="RequestReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<RequestReportRecordContract> GetReportsByRequestAsync(string filter, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetReportsByRequestAsync(new ApiManagementServiceResourceGetReportsByRequestOptions(filter)
            {
                Top = top,
                Skip = skip
            }, cancellationToken);

        /// <summary>
        /// Lists report records by Request.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/reports/byRequest
        /// Operation Id: Reports_ListByRequest
        /// </summary>
        /// <param name="filter"> |   Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| timestamp | filter | ge, le |     | &lt;/br&gt;| apiId | filter | eq |     | &lt;/br&gt;| operationId | filter | eq |     | &lt;/br&gt;| productId | filter | eq |     | &lt;/br&gt;| userId | filter | eq |     | &lt;/br&gt;| apiRegion | filter | eq |     | &lt;/br&gt;| subscriptionId | filter | eq |     | &lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <returns> A collection of <see cref="RequestReportRecordContract" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<RequestReportRecordContract> GetReportsByRequest(string filter, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetReportsByRequest(new ApiManagementServiceResourceGetReportsByRequestOptions(filter)
            {
                Top = top,
                Skip = skip
            }, cancellationToken);

        /// <summary>
        /// Lists a collection of resources associated with tags.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tagResources
        /// Operation Id: TagResource_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| aid | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| apiName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| apiRevision | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| path | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| serviceUrl | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| method | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| urlTemplate | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| terms | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| state | filter | eq |     |&lt;/br&gt;| isCurrent | filter | eq |     |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TagResourceContractDetails" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TagResourceContractDetails> GetTagResourcesAsync(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetTagResourcesAsync(new ApiManagementServiceResourceGetTagResourcesOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);

        /// <summary>
        /// Lists a collection of resources associated with tags.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/tagResources
        /// Operation Id: TagResource_ListByService
        /// </summary>
        /// <param name="filter"> |     Field     |     Usage     |     Supported operators     |     Supported functions     |&lt;/br&gt;|-------------|-------------|-------------|-------------|&lt;/br&gt;| aid | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| name | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| displayName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| apiName | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| apiRevision | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| path | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| description | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| serviceUrl | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| method | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| urlTemplate | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| terms | filter | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |&lt;/br&gt;| state | filter | eq |     |&lt;/br&gt;| isCurrent | filter | eq |     |&lt;/br&gt;. </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skip"> Number of records to skip. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TagResourceContractDetails" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TagResourceContractDetails> GetTagResources(string filter = null, int? top = null, int? skip = null, CancellationToken cancellationToken = default) =>
            GetTagResources(new ApiManagementServiceResourceGetTagResourcesOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip
            }, cancellationToken);
    }
}
