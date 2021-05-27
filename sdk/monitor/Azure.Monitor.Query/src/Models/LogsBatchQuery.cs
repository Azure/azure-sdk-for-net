// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// Represents a batch that consists out of multiple log queries.
    /// </summary>
    public class LogsBatchQuery
    {
        internal BatchRequest Batch { get; }
        private int _counter;

        /// <summary>
        /// Initializes a new instance of <see cref="LogsBatchQuery"/>.
        /// </summary>
        public LogsBatchQuery()
        {
            Batch = new BatchRequest();
        }

        /// <summary>
        /// Adds the specified query to the batch. Results can be retrieved after the query is submitted via the <see cref="LogsClient.QueryBatchAsync"/> call.
        /// </summary>
        /// <param name="workspaceId">The workspace to include in the query.</param>
        /// <param name="query">The query text to execute.</param>
        /// <param name="timeRange">The timespan over which to query data.</param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <returns>The query identifier that has to be passed into <see cref="LogsBatchQueryResult.GetResult"/> to get the result.</returns>
        public virtual string AddQuery(string workspaceId, string query, DateTimeRange timeRange, LogsQueryOptions options = null)
        {
            var id = _counter.ToString("G", CultureInfo.InvariantCulture);
            _counter++;
            var logQueryRequest = new LogQueryRequest()
            {
                Id = id,
                Body = LogsClient.CreateQueryBody(query, timeRange, options, out string prefer),
                Workspace = workspaceId
            };
            if (prefer != null)
            {
                logQueryRequest.Headers.Add("prefer", prefer);
            }
            Batch.Requests.Add(logQueryRequest);
            return id;
        }
    }
}
