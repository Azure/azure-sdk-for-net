// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Monitor.Query.Logs.Models
{
    /// <summary>
    /// Represents a collection of results returned from a batch query.
    /// </summary>
    public class LogsBatchQueryResultCollection : ReadOnlyCollection<LogsBatchQueryResult>
    {
        internal const string RequiresUnreferencedCodeMessage = "Mapping query results to open generic types may require types and members that could be trimmed. This message can be suppressed if you are certain calls will only ever attempt to map results to primitive types.";
        internal const string RequiresDynamicCodeMessage = "Mapping query results to open generic types is not supported with AOT compilation. This message can be suppressed if you are certain calls will only ever attempt to map results to primitive types.";

        /// <summary>
        /// Gets or sets the query used to produce this result object.
        /// </summary>
        private readonly LogsBatchQuery _query;

        internal LogsBatchQueryResultCollection(IList<LogsBatchQueryResult> results, LogsBatchQuery query): base(results)
        {
            _query = query;
        }

        /// <summary>
        /// Gets the result for the query that was a part of the batch.
        /// </summary>
        /// <code snippet="Snippet:QueryLogs_BatchQueryAddAndGet" language="csharp">
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
        /// <param name="queryId">The query identifier returned from the <see cref="LogsBatchQuery.AddWorkspaceQuery"/>.</param>
        /// <returns>The <see cref="LogsBatchQueryResultCollection"/> with the query results.</returns>
        /// <exception cref="ArgumentException">When the query with <paramref name="queryId"/> was not part of the batch.</exception>
        /// <exception cref="RequestFailedException">When the query <paramref name="queryId"/> failed.</exception>
        public LogsBatchQueryResult GetResult(string queryId)
        {
            LogsBatchQueryResult result = this.SingleOrDefault(r => r.Id == queryId);
            var request = _query.Requests.SingleOrDefault(r => r.Id == queryId);

            if (result == null)
            {
                throw new ArgumentException($"Query with ID '{queryId}' wasn't part of the batch." +
                                            $" Please use the return value of {nameof(LogsBatchQuery)}.{nameof(LogsBatchQuery.AddWorkspaceQuery)} as the '{nameof(queryId)}' argument.", nameof(queryId));
            }

            if (result.Status == LogsQueryResultStatus.Failure)
            {
                var message = $"Batch query with id '{queryId}' failed.{Environment.NewLine}{result.Error}";
                throw new RequestFailedException(result.StatusCode, message, result.Error.Code, null);
            }

            if (result.Error != null &&
                request?.Options?.AllowPartialErrors != true)
            {
                throw result.CreateExceptionForErrorResponse(result.StatusCode);
            }

            return result;
        }

        /// <summary>
        /// Gets the result for the query that was a part of the batch.
        /// </summary>
        /// <param name="queryId">The query identifier returned from the <see cref="LogsBatchQuery.AddWorkspaceQuery"/>.</param>
        /// <returns>Query results mapped to a type <typeparamref name="T"/>.</returns>
        /// <exception cref="ArgumentException">When the query with <paramref name="queryId"/> was not part of the batch.</exception>
        /// <exception cref="RequestFailedException">When the query <paramref name="queryId"/> failed.</exception>
        [RequiresUnreferencedCode(RequiresUnreferencedCodeMessage)]
        [RequiresDynamicCode(RequiresDynamicCodeMessage)]
        public IReadOnlyList<T> GetResult<T>(string queryId)
        {
            return RowBinder.Shared.BindResults<T>(GetResult(queryId).AllTables);
        }
    }
}
