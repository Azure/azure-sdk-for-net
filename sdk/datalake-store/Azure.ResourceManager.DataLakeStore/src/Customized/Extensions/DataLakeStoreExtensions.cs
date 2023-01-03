// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.ResourceManager.DataLakeStore.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DataLakeStore
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.DataLakeStore. </summary>
    public static partial class DataLakeStoreExtensions
    {
        /// <summary>
        /// Lists the Data Lake Store accounts within the subscription. The response includes a link to the next page of results, if any.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DataLakeStore/accounts
        /// Operation Id: Accounts_List
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="filter"> OData filter. Optional. </param>
        /// <param name="top"> The number of items to return. Optional. </param>
        /// <param name="skip"> The number of items to skip over before returning elements. Optional. </param>
        /// <param name="select"> OData Select statement. Limits the properties on each entry to just those requested, e.g. Categories?$select=CategoryName,Description. Optional. </param>
        /// <param name="orderBy"> OrderBy clause. One or more comma-separated expressions with an optional &quot;asc&quot; (the default) or &quot;desc&quot; depending on the order you&apos;d like the values sorted, e.g. Categories?$orderby=CategoryName desc. Optional. </param>
        /// <param name="count"> The Boolean value of true or false to request a count of the matching resources included with the resources in the response, e.g. Categories?$count=true. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DataLakeStoreAccountBasicData" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<DataLakeStoreAccountBasicData> GetAccountsAsync(this SubscriptionResource subscriptionResource, string filter = null, int? top = null, int? skip = null, string select = null, string orderBy = null, bool? count = null, CancellationToken cancellationToken = default) =>
            GetAccountsAsync(subscriptionResource, new DataLakeStoreExtensionsGetAccountsOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                Select = select,
                OrderBy = orderBy,
                Count = count
            }, cancellationToken);

        /// <summary>
        /// Lists the Data Lake Store accounts within the subscription. The response includes a link to the next page of results, if any.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.DataLakeStore/accounts
        /// Operation Id: Accounts_List
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="filter"> OData filter. Optional. </param>
        /// <param name="top"> The number of items to return. Optional. </param>
        /// <param name="skip"> The number of items to skip over before returning elements. Optional. </param>
        /// <param name="select"> OData Select statement. Limits the properties on each entry to just those requested, e.g. Categories?$select=CategoryName,Description. Optional. </param>
        /// <param name="orderBy"> OrderBy clause. One or more comma-separated expressions with an optional &quot;asc&quot; (the default) or &quot;desc&quot; depending on the order you&apos;d like the values sorted, e.g. Categories?$orderby=CategoryName desc. Optional. </param>
        /// <param name="count"> The Boolean value of true or false to request a count of the matching resources included with the resources in the response, e.g. Categories?$count=true. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DataLakeStoreAccountBasicData" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<DataLakeStoreAccountBasicData> GetAccounts(this SubscriptionResource subscriptionResource, string filter = null, int? top = null, int? skip = null, string select = null, string orderBy = null, bool? count = null, CancellationToken cancellationToken = default) =>
            GetAccounts(subscriptionResource, new DataLakeStoreExtensionsGetAccountsOptions
            {
                Filter = filter,
                Top = top,
                Skip = skip,
                Select = select,
                OrderBy = orderBy,
                Count = count
            }, cancellationToken);
    }
}
