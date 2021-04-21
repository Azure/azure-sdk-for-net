// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

        public virtual Response<IReadOnlyList<T>> Query<T>(string workspaceId, string query, TimeSpan? timeSpan = null, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = Query(workspaceId, query, timeSpan, cancellationToken);

            return Response.FromValue(_rowBinder.BindResults<T>(response), response.GetRawResponse());
        }

        public virtual async Task<Response<IReadOnlyList<T>>> QueryAsync<T>(string workspaceId, string query, TimeSpan? timeSpan = null, CancellationToken cancellationToken = default)
        {
            Response<LogsQueryResult> response = await QueryAsync(workspaceId, query, timeSpan,  cancellationToken).ConfigureAwait(false);

            return Response.FromValue(_rowBinder.BindResults<T>(response), response.GetRawResponse());
        }

        public virtual Response<LogsQueryResult> Query(string workspaceId, string query, TimeSpan? timeSpan = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return _queryClient.Execute(workspaceId, CreateQueryBody(query, timeSpan), null, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<LogsQueryResult>> QueryAsync(string workspaceId, string query, TimeSpan? timeSpan = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return await _queryClient.ExecuteAsync(workspaceId, CreateQueryBody(query, timeSpan), null, cancellationToken).ConfigureAwait(false);
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

        internal static QueryBody CreateQueryBody(string query, TimeSpan? timeSpan)
        {
            var queryBody = new QueryBody(query);
            if (timeSpan != null)
            {
                queryBody.Timespan = TypeFormatters.ToString(timeSpan.Value, "P");
            }

            return queryBody;
        }
    }
}