// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.ResourceManager.DataLakeStore.Models;

namespace Azure.ResourceManager.DataLakeStore.Mocking
{
    public partial class MockableDataLakeStoreSubscriptionResource : ArmResource
    {
        /// <summary>
        /// Lists the Data Lake Store accounts within the subscription. The response includes a link to the next page of results, if any.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DataLakeStore/accounts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Accounts_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> OData filter. Optional. </param>
        /// <param name="top"> The number of items to return. Optional. </param>
        /// <param name="skip"> The number of items to skip over before returning elements. Optional. </param>
        /// <param name="select"> OData Select statement. Limits the properties on each entry to just those requested, e.g. Categories?$select=CategoryName,Description. Optional. </param>
        /// <param name="orderBy"> OrderBy clause. One or more comma-separated expressions with an optional &quot;asc&quot; (the default) or &quot;desc&quot; depending on the order you&apos;d like the values sorted, e.g. Categories?$orderby=CategoryName desc. Optional. </param>
        /// <param name="count"> The Boolean value of true or false to request a count of the matching resources included with the resources in the response, e.g. Categories?$count=true. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DataLakeStoreAccountBasicData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DataLakeStoreAccountBasicData> GetAccountsAsync(string filter = null, int? top = null, int? skip = null, string select = null, string orderBy = null, bool? count = null, CancellationToken cancellationToken = default)
        {
            SubscriptionResourceGetAccountsOptions options = new SubscriptionResourceGetAccountsOptions();
            options.Filter = filter;
            options.Top = top;
            options.Skip = skip;
            options.Select = select;
            options.OrderBy = orderBy;
            options.Count = count;

            return GetAccountsAsync(options, cancellationToken);
        }

        /// <summary>
        /// Lists the Data Lake Store accounts within the subscription. The response includes a link to the next page of results, if any.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DataLakeStore/accounts</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Accounts_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> OData filter. Optional. </param>
        /// <param name="top"> The number of items to return. Optional. </param>
        /// <param name="skip"> The number of items to skip over before returning elements. Optional. </param>
        /// <param name="select"> OData Select statement. Limits the properties on each entry to just those requested, e.g. Categories?$select=CategoryName,Description. Optional. </param>
        /// <param name="orderBy"> OrderBy clause. One or more comma-separated expressions with an optional &quot;asc&quot; (the default) or &quot;desc&quot; depending on the order you&apos;d like the values sorted, e.g. Categories?$orderby=CategoryName desc. Optional. </param>
        /// <param name="count"> The Boolean value of true or false to request a count of the matching resources included with the resources in the response, e.g. Categories?$count=true. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DataLakeStoreAccountBasicData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DataLakeStoreAccountBasicData> GetAccounts(string filter = null, int? top = null, int? skip = null, string select = null, string orderBy = null, bool? count = null, CancellationToken cancellationToken = default)
        {
            SubscriptionResourceGetAccountsOptions options = new SubscriptionResourceGetAccountsOptions();
            options.Filter = filter;
            options.Top = top;
            options.Skip = skip;
            options.Select = select;
            options.OrderBy = orderBy;
            options.Count = count;

            return GetAccounts(options, cancellationToken);
        }
    }
}
