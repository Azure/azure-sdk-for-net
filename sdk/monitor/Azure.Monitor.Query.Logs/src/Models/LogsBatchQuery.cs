// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Globalization;
using Azure.Core;

namespace Azure.Monitor.Query.Logs.Models
{
    /// <summary>
    /// Represents a batch that consists of multiple log queries.
    /// </summary>
    public class LogsBatchQuery
    {
        private int _counter;
        internal List<BatchQueryRequest> Requests { get; } = new();

        /// <summary>
        /// Initializes a new instance of <see cref="LogsBatchQuery"/>.
        /// </summary>
        public LogsBatchQuery()
        {
        }

        /// <summary>
        /// Adds the specified query to the batch. Results can be retrieved after the query is submitted via the <see cref="LogsQueryClient.QueryBatchAsync(LogsBatchQuery, System.Threading.CancellationToken)"/> call.
        /// <example snippet="Snippet:QueryLogs_BatchQueryAddAndGet">
        /// <code language="csharp">
        /// string countQueryId = batch.AddWorkspaceQuery(
        ///     workspaceId,
        ///     &quot;AzureActivity | count&quot;,
        ///     new QueryTimeRange(TimeSpan.FromDays(1)));
        /// string topQueryId = batch.AddWorkspaceQuery(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count&quot;,
        ///     new QueryTimeRange(TimeSpan.FromDays(1)));
        ///
        /// Response&lt;LogsBatchQueryResultCollection&gt; response = await client.QueryBatchAsync(batch);
        ///
        /// var count = response.Value.GetResult&lt;int&gt;(countQueryId).Single();
        /// var topEntries = response.Value.GetResult&lt;MyLogEntryModel&gt;(topQueryId);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="workspaceId">The workspace to include in the query.</param>
        /// <param name="query">The query text to execute.</param>
        /// <param name="timeRange">The timespan over which to query data.</param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <returns>The query identifier that has to be passed into <see cref="LogsBatchQueryResultCollection.GetResult"/> to get the result.</returns>
        public virtual string AddWorkspaceQuery(string workspaceId, string query, QueryTimeRange timeRange, LogsQueryOptions options = null)
        {
            var id = _counter.ToString("G", CultureInfo.InvariantCulture);
            _counter++;
            var logQueryRequest = new BatchQueryRequest(id, LogsQueryClient.CreateQueryBody(query, timeRange, options, out string prefer), workspaceId)
            {
                Options = options
            };
            if (prefer != null)
            {
                logQueryRequest.Headers.Add(HttpHeader.Names.Prefer, prefer);
            }
            Requests.Add(logQueryRequest);
            return id;
        }
    }
}
