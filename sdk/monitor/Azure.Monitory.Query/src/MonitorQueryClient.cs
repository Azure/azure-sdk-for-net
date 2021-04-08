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
    public class MonitorQueryClient
    {
        private readonly QueryRestClient _queryClient;
        private readonly MetadataRestClient _metadataClient;
        private readonly ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        public MonitorQueryClient(TokenCredential credential) : this(credential, null)
        {
        }

        protected MonitorQueryClient()
        {
        }

        public MonitorQueryClient(TokenCredential credential, MonitorQueryClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new MonitorQueryClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, "https://api.loganalytics.io//.default"));
            _queryClient = new QueryRestClient(_clientDiagnostics, _pipeline);
            _metadataClient = new MetadataRestClient(_clientDiagnostics, _pipeline);
        }

        public virtual Response<QueryResults> Query(string workspace, string query, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MonitorQueryClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return _queryClient.Get(workspace, query, null, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<QueryResults>> QueryAsync(string workspace, string query, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(MonitorQueryClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return await _queryClient.GetAsync(workspace, query, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}