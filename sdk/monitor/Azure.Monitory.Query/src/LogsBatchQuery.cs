// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Monitory.Query.Models;

namespace Azure.Monitory.Query
{
    public class LogsBatchQuery
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly QueryRestClient _restClient;
        private readonly BatchRequest _batch;
        private int _counter;

        internal LogsBatchQuery(ClientDiagnostics clientDiagnostics, QueryRestClient restClient)
        {
            _clientDiagnostics = clientDiagnostics;
            _restClient = restClient;
            _batch = new BatchRequest();
        }

        protected LogsBatchQuery()
        {
        }

        public virtual string AddQuery(string workspaceId, string query)
        {
            var id = _counter.ToString("G", CultureInfo.InvariantCulture);
            _counter++;
            _batch.Requests.Add(new LogQueryRequest()
            {
                Id = id,
                Body = new QueryBody(query),
                Workspace = workspaceId
            });
            return id;
        }

        public virtual Response<LogsBatchQueryResult> Submit(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsBatchQuery)}.{nameof(Submit)}");
            scope.Start();
            try
            {
                return _restClient.Batch(_batch, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<LogsBatchQueryResult>> SubmitAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(LogsBatchQuery)}.{nameof(Submit)}");
            scope.Start();
            try
            {
                return await _restClient.BatchAsync(_batch, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}