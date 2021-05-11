// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// Represents a batch that consists out of multiple log queries.
    /// </summary>
    public class LogsBatchQuery
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly QueryRestClient _restClient;
        private readonly RowBinder _rowBinder;
        private readonly BatchRequest _batch;
        private int _counter;

        internal LogsBatchQuery(ClientDiagnostics clientDiagnostics, QueryRestClient restClient, RowBinder rowBinder)
        {
            _clientDiagnostics = clientDiagnostics;
            _restClient = restClient;
            _rowBinder = rowBinder;
            _batch = new BatchRequest();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="LogsBatchQuery"/> for mocking.
        /// </summary>
        protected LogsBatchQuery()
        {
        }

        /// <summary>
        /// Adds the specified query to the batch. Results can be retrieved after the query is submitted via the <see cref="SubmitAsync"/> call.
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
            _batch.Requests.Add(logQueryRequest);
            return id;
        }

        /// <summary>
        /// Submits the batch.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="LogsBatchQueryResult"/> containing the query identifier that has to be passed into <see cref="LogsBatchQueryResult.GetResult"/> to get the result.</returns>
        public virtual Response<LogsBatchQueryResult> Submit(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsBatchQuery)}.{nameof(Submit)}");
            scope.Start();
            try
            {
                var response = _restClient.Batch(_batch, cancellationToken);
                response.Value.RowBinder = _rowBinder;
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Submits the batch.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="LogsBatchQueryResult"/> that allows retrieving query results.</returns>
        public virtual async Task<Response<LogsBatchQueryResult>> SubmitAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsBatchQuery)}.{nameof(Submit)}");
            scope.Start();
            try
            {
                var response = await _restClient.BatchAsync(_batch, cancellationToken).ConfigureAwait(false);
                response.Value.RowBinder = _rowBinder;
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
