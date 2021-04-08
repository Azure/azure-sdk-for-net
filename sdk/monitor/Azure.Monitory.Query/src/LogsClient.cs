// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitory.Query.Models;

namespace Azure.Monitory.Query
{
    public class LogsClient
    {
        private readonly QueryRestClient _queryClient;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

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
        }

        protected LogsClient()
        {
        }

        public virtual Response<LogsQueryResult> Query(string workspaceId, string query, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return _queryClient.Execute(workspaceId, new QueryBody(query), null, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<LogsQueryResult>> QueryAsync(string workspaceId, string query, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return await _queryClient.ExecuteAsync(workspaceId, new QueryBody(query), null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual LogsBatchQuery CreateBatchQuery()
        {
            return new LogsBatchQuery(_clientDiagnostics, _queryClient);
        }
    }
}