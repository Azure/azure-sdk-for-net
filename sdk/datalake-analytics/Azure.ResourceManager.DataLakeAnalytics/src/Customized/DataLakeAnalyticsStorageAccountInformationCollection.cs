// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.DataLakeAnalytics.Models;

namespace Azure.ResourceManager.DataLakeAnalytics
{
    /// <summary>
    /// A class representing a collection of <see cref="DataLakeAnalyticsStorageAccountInformationResource" /> and their operations.
    /// Each <see cref="DataLakeAnalyticsStorageAccountInformationResource" /> in the collection will belong to the same instance of <see cref="DataLakeAnalyticsAccountResource" />.
    /// To get a <see cref="DataLakeAnalyticsStorageAccountInformationCollection" /> instance call the GetDataLakeAnalyticsStorageAccountInformation method from an instance of <see cref="DataLakeAnalyticsAccountResource" />.
    /// </summary>
    public partial class DataLakeAnalyticsStorageAccountInformationCollection : ArmCollection, IEnumerable<DataLakeAnalyticsStorageAccountInformationResource>, IAsyncEnumerable<DataLakeAnalyticsStorageAccountInformationResource>
    {
        /// <summary>
        /// Gets the first page of Azure Storage accounts, if any, linked to the specified Data Lake Analytics account. The response includes a link to the next page, if any.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataLakeAnalytics/accounts/{accountName}/storageAccounts
        /// Operation Id: StorageAccounts_ListByAccount
        /// </summary>
        /// <param name="filter"> The OData filter. Optional. </param>
        /// <param name="top"> The number of items to return. Optional. </param>
        /// <param name="skip"> The number of items to skip over before returning elements. Optional. </param>
        /// <param name="select"> OData Select statement. Limits the properties on each entry to just those requested, e.g. Categories?$select=CategoryName,Description. Optional. </param>
        /// <param name="orderby"> OrderBy clause. One or more comma-separated expressions with an optional &quot;asc&quot; (the default) or &quot;desc&quot; depending on the order you&apos;d like the values sorted, e.g. Categories?$orderby=CategoryName desc. Optional. </param>
        /// <param name="count"> The Boolean value of true or false to request a count of the matching resources included with the resources in the response, e.g. Categories?$count=true. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DataLakeAnalyticsStorageAccountInformationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DataLakeAnalyticsStorageAccountInformationResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, string select = null, string orderby = null, bool? count = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new DataLakeAnalyticsStorageAccountInformationCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                Select = select,
                Orderby = orderby,
                Count = count
            }, cancellationToken);

        /// <summary>
        /// Gets the first page of Azure Storage accounts, if any, linked to the specified Data Lake Analytics account. The response includes a link to the next page, if any.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataLakeAnalytics/accounts/{accountName}/storageAccounts
        /// Operation Id: StorageAccounts_ListByAccount
        /// </summary>
        /// <param name="filter"> The OData filter. Optional. </param>
        /// <param name="top"> The number of items to return. Optional. </param>
        /// <param name="skip"> The number of items to skip over before returning elements. Optional. </param>
        /// <param name="select"> OData Select statement. Limits the properties on each entry to just those requested, e.g. Categories?$select=CategoryName,Description. Optional. </param>
        /// <param name="orderby"> OrderBy clause. One or more comma-separated expressions with an optional &quot;asc&quot; (the default) or &quot;desc&quot; depending on the order you&apos;d like the values sorted, e.g. Categories?$orderby=CategoryName desc. Optional. </param>
        /// <param name="count"> The Boolean value of true or false to request a count of the matching resources included with the resources in the response, e.g. Categories?$count=true. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DataLakeAnalyticsStorageAccountInformationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DataLakeAnalyticsStorageAccountInformationResource> GetAll(string filter = null, int? top = null, int? skip = null, string select = null, string orderby = null, bool? count = null, CancellationToken cancellationToken = default) =>
            GetAll(new DataLakeAnalyticsStorageAccountInformationCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                Select = select,
                Orderby = orderby,
                Count = count
            }, cancellationToken);
    }
}
