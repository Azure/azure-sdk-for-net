// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query
{
    public class LogsClient
    {
        private readonly QueryRestClient _queryClient;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        private readonly RowBinder _rowBinder;

        public LogsClient(TokenCredential credential) : this(credential, null)
        {
        }

        public LogsClient(TokenCredential credential, LogsClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new LogsClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "https://api.loganalytics.io//.default"));
            _queryClient = new QueryRestClient(_clientDiagnostics, _pipeline);
            _rowBinder = new RowBinder();
        }

        protected LogsClient()
        {
        }

        public virtual Response<IReadOnlyList<T>> Query<T>(string workspaceId, string query, TimeSpan? timeSpan = null, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = Query(workspaceId, query, timeSpan, options, cancellationToken);

            return Response.FromValue(_rowBinder.BindResults<T>(response), response.GetRawResponse());
        }

        public virtual async Task<Response<IReadOnlyList<T>>> QueryAsync<T>(string workspaceId, string query, TimeSpan? timeSpan = null, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = await QueryAsync(workspaceId, query, timeSpan, options, cancellationToken).ConfigureAwait(false);

            return Response.FromValue(_rowBinder.BindResults<T>(response), response.GetRawResponse());
        }

        public virtual Response<LogsQueryResult> Query(string workspaceId, string query, TimeSpan? timeSpan = null, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return ExecuteAsync(workspaceId, query, timeSpan, options, false, cancellationToken).EnsureCompleted();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<LogsQueryResult>> QueryAsync(string workspaceId, string query, TimeSpan? timeSpan = null, LogsQueryOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return await ExecuteAsync(workspaceId, query, timeSpan, options, true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual LogsBatchQuery CreateBatchQuery()
        {
            return new LogsBatchQuery(_clientDiagnostics, _queryClient, _rowBinder);
        }

        internal static QueryBody CreateQueryBody(string query, TimeSpan? timeSpan, LogsQueryOptions options, out string prefer)
        {
            var queryBody = new QueryBody(query);
            if (timeSpan != null)
            {
                queryBody.Timespan = TypeFormatters.ToString(timeSpan.Value, "P");
            }

            StringBuilder preferBuilder = null;
            if (options?.Timeout is TimeSpan timeout)
            {
                preferBuilder ??= new();
                preferBuilder.Append("wait=");
                preferBuilder.Append((int) timeout.TotalSeconds);
            }

            if (options?.IncludeStatistics == true)
            {
                preferBuilder ??= new();
                preferBuilder.Append(" include-statistics=true");
            }

            prefer = preferBuilder?.ToString();

            return queryBody;
        }

        private async Task<Response<LogsQueryResult>> ExecuteAsync(string workspaceId, string query, TimeSpan? timeSpan, LogsQueryOptions options, bool async, CancellationToken cancellationToken = default)
        {
            if (workspaceId == null)
            {
                throw new ArgumentNullException(nameof(workspaceId));
            }

            QueryBody queryBody = CreateQueryBody(query, timeSpan, options, out string prefer);
            using var message = _queryClient.CreateExecuteRequest(workspaceId, queryBody, prefer);

            if (options.Timeout != null)
            {
                message.SetProperty("NetworkTimeoutOverride", options.Timeout);
            }

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