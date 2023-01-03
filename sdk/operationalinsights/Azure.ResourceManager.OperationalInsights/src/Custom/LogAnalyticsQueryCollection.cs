// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.OperationalInsights.Models;

namespace Azure.ResourceManager.OperationalInsights
{
    /// <summary>
    /// A class representing a collection of <see cref="LogAnalyticsQueryResource" /> and their operations.
    /// Each <see cref="LogAnalyticsQueryResource" /> in the collection will belong to the same instance of <see cref="LogAnalyticsQueryPackResource" />.
    /// To get a <see cref="LogAnalyticsQueryCollection" /> instance call the GetLogAnalyticsQueries method from an instance of <see cref="LogAnalyticsQueryPackResource" />.
    /// </summary>
    public partial class LogAnalyticsQueryCollection : ArmCollection, IEnumerable<LogAnalyticsQueryResource>, IAsyncEnumerable<LogAnalyticsQueryResource>
    {
        /// <summary>
        /// Gets a list of Queries defined within a Log Analytics QueryPack.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/queryPacks/{queryPackName}/queries
        /// Operation Id: Queries_List
        /// </summary>
        /// <param name="top"> Maximum items returned in page. </param>
        /// <param name="includeBody"> Flag indicating whether or not to return the body of each applicable query. If false, only return the query information. </param>
        /// <param name="skipToken"> Base64 encoded token used to fetch the next page of items. Default is null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="LogAnalyticsQueryResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<LogAnalyticsQueryResource> GetAllAsync(long? top = null, bool? includeBody = null, string skipToken = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new LogAnalyticsQueryCollectionGetAllOptions
            {
                Top = top,
                IncludeBody = includeBody,
                SkipToken = skipToken
            }, cancellationToken);

        /// <summary>
        /// Gets a list of Queries defined within a Log Analytics QueryPack.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/queryPacks/{queryPackName}/queries
        /// Operation Id: Queries_List
        /// </summary>
        /// <param name="top"> Maximum items returned in page. </param>
        /// <param name="includeBody"> Flag indicating whether or not to return the body of each applicable query. If false, only return the query information. </param>
        /// <param name="skipToken"> Base64 encoded token used to fetch the next page of items. Default is null. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="LogAnalyticsQueryResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<LogAnalyticsQueryResource> GetAll(long? top = null, bool? includeBody = null, string skipToken = null, CancellationToken cancellationToken = default) =>
            GetAll(new LogAnalyticsQueryCollectionGetAllOptions
            {
                Top = top,
                IncludeBody = includeBody,
                SkipToken = skipToken
            }, cancellationToken);
    }
}
