// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    [CodeGenModel("batchResponse")]
    public partial class LogsBatchQueryResults
    {
        private LogsBatchQueryResult[] _results;

        private IReadOnlyList<BatchQueryResponse> Responses { get; }

        /// <summary>
        /// Gets the list of results for the batch query.
        /// </summary>
        public IReadOnlyList<LogsBatchQueryResult> Results => _results ??= Responses.Select(r => r.Body).ToArray();

        /// <summary>
        /// Gets the result for the query that was a part of the batch.
        /// </summary>
        /// <code snippet="Snippet:BatchQueryAddAndGet" language="csharp">
        /// string countQueryId = batch.AddQuery(
        ///     workspaceId,
        ///     &quot;AzureActivity | count&quot;,
        ///     new DateTimeRange(TimeSpan.FromDays(1)));
        /// string topQueryId = batch.AddQuery(
        ///     workspaceId,
        ///     &quot;AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count&quot;,
        ///     new DateTimeRange(TimeSpan.FromDays(1)));
        ///
        /// Response&lt;LogsBatchQueryResults&gt; response = await client.QueryBatchAsync(batch);
        ///
        /// var count = response.Value.GetResult&lt;int&gt;(countQueryId).Single();
        /// var topEntries = response.Value.GetResult&lt;MyLogEntryModel&gt;(topQueryId);
        /// </code>
        /// <param name="queryId">The query identifier returned from the <see cref="LogsBatchQuery.AddQuery"/>.</param>
        /// <returns>The <see cref="LogsBatchQueryResults"/> with the query results.</returns>
        /// <exception cref="ArgumentException">When the query with <paramref name="queryId"/> was not part of the batch.</exception>
        /// <exception cref="RequestFailedException">When the query <paramref name="queryId"/> failed.</exception>
        public LogsQueryResult GetResult(string queryId)
        {
            BatchQueryResponse result = Responses.SingleOrDefault(r => r.Id == queryId);

            if (result == null)
            {
                throw new ArgumentException($"Query with ID '{queryId}' wasn't part of the batch." +
                                            $" Please use the return value of {nameof(LogsBatchQuery)}.{nameof(LogsBatchQuery.AddQuery)} as the '{nameof(queryId)}' argument.", nameof(queryId));
            }

            if (result.Body.HasFailed)
            {
                var message = $"Batch query with id '{queryId}' failed.{Environment.NewLine}{result.Body.Error}";
                throw new RequestFailedException(result.Status ?? 0, message, result.Body.Error.Code, null);
            }

            return result.Body;
        }

        /// <summary>
        /// Gets the result for the query that was a part of the batch.
        /// </summary>
        /// <param name="queryId">The query identifier returned from the <see cref="LogsBatchQuery.AddQuery"/>.</param>
        /// <returns>Query results mapped to a type <typeparamref name="T"/>.</returns>
        /// <exception cref="ArgumentException">When the query with <paramref name="queryId"/> was not part of the batch.</exception>
        /// <exception cref="RequestFailedException">When the query <paramref name="queryId"/> failed.</exception>
        public IReadOnlyList<T> GetResult<T>(string queryId)
        {
            return RowBinder.Shared.BindResults<T>(GetResult(queryId).Tables);
        }
    }
}
