// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query
{
    /// <summary>
    /// The <see cref="LogsClient"/> allows to query the Azure Monitor Logs service.
    /// </summary>
    public class LogsClient
    {
        private readonly QueryRestClient _queryClient;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        private readonly RowBinder _rowBinder;

        /// <summary>
        /// Initializes a new instance of <see cref="LogsClient"/>.
        /// </summary>
        /// <param name="endpoint">The service endpoint to use.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        public LogsClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="LogsClient"/>.
        /// </summary>
        /// <param name="endpoint">The service endpoint to use.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> instance to use for authentication.</param>
        /// <param name="options">The <see cref="LogsClientOptions"/> instance to use as client configuration.</param>
        public LogsClient(Uri endpoint, TokenCredential credential, LogsClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            options ??= new LogsClientOptions();
            endpoint = new Uri(endpoint, options.GetVersionString());
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "https://api.loganalytics.io//.default"));
            _queryClient = new QueryRestClient(_clientDiagnostics, _pipeline, endpoint);
            _rowBinder = new RowBinder();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="LogsClient"/> for mocking.
        /// </summary>
        protected LogsClient()
        {
        }

        /// <summary>
        /// Executes the logs query.
        /// </summary>
        /// <param name="workspaceId">The workspace to include in the query.</param>
        /// <param name="query">The query text to execute.</param>
        /// <param name="timeRange">The timespan over which to query data. Logs would be filtered to include entries produced starting at <c>Now - timeSpan</c>. </param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>Query results mapped to a type <typeparamref name="T"/>.</returns>
        public virtual Response<IReadOnlyList<T>> Query<T>(string workspaceId, string query, DateTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = Query(workspaceId, query, timeRange, options, cancellationToken);

            return Response.FromValue(_rowBinder.BindResults<T>(response), response.GetRawResponse());
        }

        /// <summary>
        /// Executes the logs query.
        /// </summary>
        /// <param name="workspaceId">The workspace to include in the query.</param>
        /// <param name="query">The query text to execute.</param>
        /// <param name="timeRange">The timespan over which to query data. Logs would be filtered to include entries produced starting at <c>Now - timeSpan</c>. </param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>Query results mapped to a type <typeparamref name="T"/>.</returns>
        public virtual async Task<Response<IReadOnlyList<T>>> QueryAsync<T>(string workspaceId, string query, DateTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = await QueryAsync(workspaceId, query, timeRange, options, cancellationToken).ConfigureAwait(false);

            return Response.FromValue(_rowBinder.BindResults<T>(response), response.GetRawResponse());
        }

        /// <summary>
        /// Executes the logs query.
        /// </summary>
        /// <param name="workspaceId">The workspace to include in the query.</param>
        /// <param name="query">The query text to execute.</param>
        /// <param name="timeRange">The timespan over which to query data. Logs would be filtered to include entries produced starting at <c>Now - timeSpan</c>. </param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="LogsQueryResult"/> containing the query results.</returns>
        public virtual Response<LogsQueryResult> Query(string workspaceId, string query, DateTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return ExecuteAsync(workspaceId, query, timeRange, options, false, cancellationToken).EnsureCompleted();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Executes the logs query.
        /// </summary>
        /// <param name="workspaceId">The workspace to include in the query.</param>
        /// <param name="query">The query text to execute.</param>
        /// <param name="timeRange">The timespan over which to query data. Logs would be filtered to include entries produced starting at <c>Now - timeSpan</c>. </param>
        /// <param name="options">The <see cref="LogsQueryOptions"/> to configure the query.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="LogsQueryResult"/> with the query results.</returns>
        public virtual async Task<Response<LogsQueryResult>> QueryAsync(string workspaceId, string query, DateTimeRange timeRange, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return await ExecuteAsync(workspaceId, query, timeRange, options, true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Submits the batch query.
        /// </summary>
        /// <param name="batch">The batch of queries to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="LogsBatchQueryResult"/> containing the query identifier that has to be passed into <see cref="LogsBatchQueryResult.GetResult"/> to get the result.</returns>
        public virtual Response<LogsBatchQueryResult> QueryBatch(LogsBatchQuery batch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(batch, nameof(batch));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsClient)}.{nameof(QueryBatch)}");
            scope.Start();
            try
            {
                var response = _queryClient.Batch(batch.Batch, cancellationToken);
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
        /// Submits the batch query.
        /// </summary>
        /// <param name="batch">The batch of queries to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <returns>The <see cref="LogsBatchQueryResult"/> that allows retrieving query results.</returns>
        public virtual async Task<Response<LogsBatchQueryResult>> QueryBatchAsync(LogsBatchQuery batch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(batch, nameof(batch));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsClient)}.{nameof(QueryBatch)}");
            scope.Start();
            try
            {
                var response = await _queryClient.BatchAsync(batch.Batch, cancellationToken).ConfigureAwait(false);
                response.Value.RowBinder = _rowBinder;
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal static QueryBody CreateQueryBody(string query, DateTimeRange timeRange, LogsQueryOptions options, out string prefer)
        {
            var queryBody = new QueryBody(query);
            if (timeRange != DateTimeRange.All)
            {
                queryBody.Timespan = timeRange.ToString();
            }

            prefer = null;

            if (options?.Timeout is TimeSpan timeout)
            {
                prefer = "wait=" + (int) timeout.TotalSeconds;
            }

            if (options?.IncludeStatistics == true)
            {
                prefer += " include-statistics=true";
            }

            return queryBody;
        }

        private async Task<Response<LogsQueryResult>> ExecuteAsync(string workspaceId, string query, DateTimeRange timeRange, LogsQueryOptions options, bool async, CancellationToken cancellationToken = default)
        {
            if (workspaceId == null)
            {
                throw new ArgumentNullException(nameof(workspaceId));
            }

            QueryBody queryBody = CreateQueryBody(query, timeRange, options, out string prefer);
            using var message = _queryClient.CreateExecuteRequest(workspaceId, queryBody, prefer);

            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/20859
            // if (options?.Timeout != null)
            // {
            //     message.NetworkTimeout = options.Timeout;
            // }

            if (async)
            {
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                _pipeline.Send(message, cancellationToken);
            }

            switch (message.Response.Status)
            {
                case 200:
                {
                    using var document = async ?
                        await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false) :
                        JsonDocument.Parse(message.Response.ContentStream, default);

                    LogsQueryResult value = LogsQueryResult.DeserializeLogsQueryResult(document.RootElement);
                    return Response.FromValue(value, message.Response);
                }
                default:
                {
                    if (async)
                    {
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                    }
                    else
                    {
                        throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                    }
                }
            }
        }
    }
}
