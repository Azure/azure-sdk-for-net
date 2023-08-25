// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Azure.ResourceManager.DataLakeAnalytics.Models;

namespace Azure.ResourceManager.DataLakeAnalytics
{
    public partial class DataLakeAnalyticsStorageAccountInformationCollection
    {
        /// <summary>
        /// Gets the first page of Azure Storage accounts, if any, linked to the specified Data Lake Analytics account. The response includes a link to the next page, if any.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataLakeAnalytics/accounts/{accountName}/storageAccounts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_ListByAccount</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The OData filter. Optional. </param>
        /// <param name="top"> The number of items to return. Optional. </param>
        /// <param name="skip"> The number of items to skip over before returning elements. Optional. </param>
        /// <param name="select"> OData Select statement. Limits the properties on each entry to just those requested, e.g. Categories?$select=CategoryName,Description. Optional. </param>
        /// <param name="orderby"> OrderBy clause. One or more comma-separated expressions with an optional &quot;asc&quot; (the default) or &quot;desc&quot; depending on the order you&apos;d like the values sorted, e.g. Categories?$orderby=CategoryName desc. Optional. </param>
        /// <param name="count"> The Boolean value of true or false to request a count of the matching resources included with the resources in the response, e.g. Categories?$count=true. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DataLakeAnalyticsStorageAccountInformationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DataLakeAnalyticsStorageAccountInformationResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, string select = null, string orderby = null, bool? count = null, CancellationToken cancellationToken = default)
        {
            DataLakeAnalyticsStorageAccountInformationCollectionGetAllOptions options = new DataLakeAnalyticsStorageAccountInformationCollectionGetAllOptions();
            options.Filter = filter;
            options.Top = top;
            options.Skip = skip;
            options.Select = select;
            options.Orderby = orderby;
            options.Count = count;

            return GetAllAsync(options, cancellationToken);
        }

        /// <summary>
        /// Gets the first page of Azure Storage accounts, if any, linked to the specified Data Lake Analytics account. The response includes a link to the next page, if any.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataLakeAnalytics/accounts/{accountName}/storageAccounts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StorageAccounts_ListByAccount</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The OData filter. Optional. </param>
        /// <param name="top"> The number of items to return. Optional. </param>
        /// <param name="skip"> The number of items to skip over before returning elements. Optional. </param>
        /// <param name="select"> OData Select statement. Limits the properties on each entry to just those requested, e.g. Categories?$select=CategoryName,Description. Optional. </param>
        /// <param name="orderby"> OrderBy clause. One or more comma-separated expressions with an optional &quot;asc&quot; (the default) or &quot;desc&quot; depending on the order you&apos;d like the values sorted, e.g. Categories?$orderby=CategoryName desc. Optional. </param>
        /// <param name="count"> The Boolean value of true or false to request a count of the matching resources included with the resources in the response, e.g. Categories?$count=true. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DataLakeAnalyticsStorageAccountInformationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DataLakeAnalyticsStorageAccountInformationResource> GetAll(string filter = null, int? top = null, int? skip = null, string select = null, string orderby = null, bool? count = null, CancellationToken cancellationToken = default)
        {
            DataLakeAnalyticsStorageAccountInformationCollectionGetAllOptions options = new DataLakeAnalyticsStorageAccountInformationCollectionGetAllOptions();
            options.Filter = filter;
            options.Top = top;
            options.Skip = skip;
            options.Select = select;
            options.Orderby = orderby;
            options.Count = count;

            return GetAll(options, cancellationToken);
        }
    }
}
