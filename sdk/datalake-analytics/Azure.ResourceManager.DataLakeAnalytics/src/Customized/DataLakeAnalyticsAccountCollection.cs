// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.DataLakeAnalytics.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DataLakeAnalytics
{
    /// <summary>
    /// A class representing a collection of <see cref="DataLakeAnalyticsAccountResource" /> and their operations.
    /// Each <see cref="DataLakeAnalyticsAccountResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="DataLakeAnalyticsAccountCollection" /> instance call the GetDataLakeAnalyticsAccounts method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class DataLakeAnalyticsAccountCollection : ArmCollection, IEnumerable<DataLakeAnalyticsAccountBasic>, IAsyncEnumerable<DataLakeAnalyticsAccountBasic>
    {
        /// <summary>
        /// Gets the first page of Data Lake Analytics accounts, if any, within a specific resource group. This includes a link to the next page, if any.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataLakeAnalytics/accounts
        /// Operation Id: Accounts_ListByResourceGroup
        /// </summary>
        /// <param name="filter"> OData filter. Optional. </param>
        /// <param name="top"> The number of items to return. Optional. </param>
        /// <param name="skip"> The number of items to skip over before returning elements. Optional. </param>
        /// <param name="select"> OData Select statement. Limits the properties on each entry to just those requested, e.g. Categories?$select=CategoryName,Description. Optional. </param>
        /// <param name="orderby"> OrderBy clause. One or more comma-separated expressions with an optional &quot;asc&quot; (the default) or &quot;desc&quot; depending on the order you&apos;d like the values sorted, e.g. Categories?$orderby=CategoryName desc. Optional. </param>
        /// <param name="count"> The Boolean value of true or false to request a count of the matching resources included with the resources in the response, e.g. Categories?$count=true. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DataLakeAnalyticsAccountBasic" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DataLakeAnalyticsAccountBasic> GetAllAsync(string filter = null, int? top = null, int? skip = null, string select = null, string orderby = null, bool? count = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new DataLakeAnalyticsAccountCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                Select = select,
                Orderby = orderby,
                Count = count
            }, cancellationToken);

        /// <summary>
        /// Gets the first page of Data Lake Analytics accounts, if any, within a specific resource group. This includes a link to the next page, if any.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataLakeAnalytics/accounts
        /// Operation Id: Accounts_ListByResourceGroup
        /// </summary>
        /// <param name="filter"> OData filter. Optional. </param>
        /// <param name="top"> The number of items to return. Optional. </param>
        /// <param name="skip"> The number of items to skip over before returning elements. Optional. </param>
        /// <param name="select"> OData Select statement. Limits the properties on each entry to just those requested, e.g. Categories?$select=CategoryName,Description. Optional. </param>
        /// <param name="orderby"> OrderBy clause. One or more comma-separated expressions with an optional &quot;asc&quot; (the default) or &quot;desc&quot; depending on the order you&apos;d like the values sorted, e.g. Categories?$orderby=CategoryName desc. Optional. </param>
        /// <param name="count"> The Boolean value of true or false to request a count of the matching resources included with the resources in the response, e.g. Categories?$count=true. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DataLakeAnalyticsAccountBasic" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DataLakeAnalyticsAccountBasic> GetAll(string filter = null, int? top = null, int? skip = null, string select = null, string orderby = null, bool? count = null, CancellationToken cancellationToken = default) =>
            GetAll(new DataLakeAnalyticsAccountCollectionGetAllOptions
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
