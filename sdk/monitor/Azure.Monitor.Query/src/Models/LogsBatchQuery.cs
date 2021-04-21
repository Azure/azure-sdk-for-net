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

        protected LogsBatchQuery()
        {
        }

        public virtual string AddQuery(string workspaceId, string query, TimeSpan? timeSpan = null)
        {
            var id = _counter.ToString("G", CultureInfo.InvariantCulture);
            _counter++;
            _batch.Requests.Add(new LogQueryRequest()
            {
                Id = id,
                Body = LogsClient.CreateQueryBody(query, timeSpan),
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