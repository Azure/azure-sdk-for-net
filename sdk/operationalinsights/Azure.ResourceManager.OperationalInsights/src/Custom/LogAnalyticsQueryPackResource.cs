// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.OperationalInsights.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.OperationalInsights
{
    /// <summary>
    /// A Class representing a LogAnalyticsQueryPack along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="LogAnalyticsQueryPackResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetLogAnalyticsQueryPackResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetLogAnalyticsQueryPack method.
    /// </summary>
    public partial class LogAnalyticsQueryPackResource : ArmResource
    {
        /// <summary>
        /// Search a list of Queries defined within a Log Analytics QueryPack according to given search properties.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/queryPacks/{queryPackName}/queries/search
        /// Operation Id: Queries_Search
        /// </summary>
        /// <param name="querySearchProperties"> Properties by which to search queries in the given Log Analytics QueryPack. </param>
        /// <param name="top"> Maximum items returned in page. </param>
        /// <param name="includeBody"> Flag indicating whether or not to return the body of each applicable query. If false, only return the query information. </param>
        /// <param name="skipToken"> Base64 encoded token used to fetch the next page of items. Default is null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="querySearchProperties"/> is null. </exception>
        /// <returns> An async collection of <see cref="LogAnalyticsQueryResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<LogAnalyticsQueryResource> SearchQueriesAsync(LogAnalyticsQuerySearchProperties querySearchProperties, long? top = null, bool? includeBody = null, string skipToken = null, CancellationToken cancellationToken = default) =>
            SearchQueriesAsync(new LogAnalyticsQueryPackResourceSearchQueriesOptions(querySearchProperties)
            {
                Top = top,
                IncludeBody = includeBody,
                SkipToken = skipToken
            }, cancellationToken);

        /// <summary>
        /// Search a list of Queries defined within a Log Analytics QueryPack according to given search properties.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/queryPacks/{queryPackName}/queries/search
        /// Operation Id: Queries_Search
        /// </summary>
        /// <param name="querySearchProperties"> Properties by which to search queries in the given Log Analytics QueryPack. </param>
        /// <param name="top"> Maximum items returned in page. </param>
        /// <param name="includeBody"> Flag indicating whether or not to return the body of each applicable query. If false, only return the query information. </param>
        /// <param name="skipToken"> Base64 encoded token used to fetch the next page of items. Default is null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="querySearchProperties"/> is null. </exception>
        /// <returns> A collection of <see cref="LogAnalyticsQueryResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<LogAnalyticsQueryResource> SearchQueries(LogAnalyticsQuerySearchProperties querySearchProperties, long? top = null, bool? includeBody = null, string skipToken = null, CancellationToken cancellationToken = default) =>
            SearchQueries(new LogAnalyticsQueryPackResourceSearchQueriesOptions(querySearchProperties)
            {
                Top = top,
                IncludeBody = includeBody,
                SkipToken = skipToken
            }, cancellationToken);
    }
}
