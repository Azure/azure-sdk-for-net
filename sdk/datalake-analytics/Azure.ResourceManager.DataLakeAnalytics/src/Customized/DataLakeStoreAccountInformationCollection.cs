// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.DataLakeAnalytics.Models;

namespace Azure.ResourceManager.DataLakeAnalytics
{
    /// <summary>
    /// A class representing a collection of <see cref="DataLakeStoreAccountInformationResource" /> and their operations.
    /// Each <see cref="DataLakeStoreAccountInformationResource" /> in the collection will belong to the same instance of <see cref="DataLakeAnalyticsAccountResource" />.
    /// To get a <see cref="DataLakeStoreAccountInformationCollection" /> instance call the GetDataLakeStoreAccountInformation method from an instance of <see cref="DataLakeAnalyticsAccountResource" />.
    /// </summary>
    public partial class DataLakeStoreAccountInformationCollection : ArmCollection, IEnumerable<DataLakeStoreAccountInformationResource>, IAsyncEnumerable<DataLakeStoreAccountInformationResource>
    {
        /// <summary>
        /// Gets the first page of Data Lake Store accounts linked to the specified Data Lake Analytics account. The response includes a link to the next page, if any.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataLakeAnalytics/accounts/{accountName}/dataLakeStoreAccounts
        /// Operation Id: DataLakeStoreAccounts_ListByAccount
        /// </summary>
        /// <param name="filter"> OData filter. Optional. </param>
        /// <param name="top"> The number of items to return. Optional. </param>
        /// <param name="skip"> The number of items to skip over before returning elements. Optional. </param>
        /// <param name="select"> OData Select statement. Limits the properties on each entry to just those requested, e.g. Categories?$select=CategoryName,Description. Optional. </param>
        /// <param name="orderby"> OrderBy clause. One or more comma-separated expressions with an optional &quot;asc&quot; (the default) or &quot;desc&quot; depending on the order you&apos;d like the values sorted, e.g. Categories?$orderby=CategoryName desc. Optional. </param>
        /// <param name="count"> The Boolean value of true or false to request a count of the matching resources included with the resources in the response, e.g. Categories?$count=true. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DataLakeStoreAccountInformationResource" /> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<DataLakeStoreAccountInformationResource> GetAllAsync(string filter = null, int? top = null, int? skip = null, string select = null, string orderby = null, bool? count = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new DataLakeStoreAccountInformationCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                Select = select,
                Orderby = orderby,
                Count = count
            }, cancellationToken);

        /// <summary>
        /// Gets the first page of Data Lake Store accounts linked to the specified Data Lake Analytics account. The response includes a link to the next page, if any.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataLakeAnalytics/accounts/{accountName}/dataLakeStoreAccounts
        /// Operation Id: DataLakeStoreAccounts_ListByAccount
        /// </summary>
        /// <param name="filter"> OData filter. Optional. </param>
        /// <param name="top"> The number of items to return. Optional. </param>
        /// <param name="skip"> The number of items to skip over before returning elements. Optional. </param>
        /// <param name="select"> OData Select statement. Limits the properties on each entry to just those requested, e.g. Categories?$select=CategoryName,Description. Optional. </param>
        /// <param name="orderby"> OrderBy clause. One or more comma-separated expressions with an optional &quot;asc&quot; (the default) or &quot;desc&quot; depending on the order you&apos;d like the values sorted, e.g. Categories?$orderby=CategoryName desc. Optional. </param>
        /// <param name="count"> The Boolean value of true or false to request a count of the matching resources included with the resources in the response, e.g. Categories?$count=true. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DataLakeStoreAccountInformationResource" /> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public virtual Pageable<DataLakeStoreAccountInformationResource> GetAll(string filter = null, int? top = null, int? skip = null, string select = null, string orderby = null, bool? count = null, CancellationToken cancellationToken = default) =>
            GetAll(new DataLakeStoreAccountInformationCollectionGetAllOptions
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
