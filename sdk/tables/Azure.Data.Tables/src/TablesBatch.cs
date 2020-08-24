// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Data.Tables.Models;

namespace Azure.Data.Tables
{
    public class TablesBatch
    {
        private readonly TableRestClient _tableOperations;
        private readonly TableRestClient _batchOperations;
        private readonly string _table;
        private readonly ClientDiagnostics _diagnostics;
        private MultipartContent _changeset;
        private readonly OdataMetadataFormat _format;
        private readonly ResponseFormat _returnNoContent = ResponseFormat.ReturnNoContent;
        internal MultipartContent _batch;
        internal Guid _batchGuid = default;
        internal Guid _changesetGuid = default;
        internal ConcurrentDictionary<(string PartitionKey, string RowKey), HttpMessage> _addMessages = new ConcurrentDictionary<(string PartitionKey, string RowKey), HttpMessage>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TablesBatch"/> class.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="tableOperations"></param>
        /// <param name="format"></param>
        internal TablesBatch(string table, TableRestClient tableOperations, OdataMetadataFormat format)
        {
            _table = table;
            _tableOperations = tableOperations;
            _diagnostics = _tableOperations.clientDiagnostics;
            _batchOperations = new TableRestClient(_diagnostics, CreateBatchPipeline(), _tableOperations.endpoint, _tableOperations.clientVersion);
            _format = format;
            _batch = TableRestClient.CreateBatchContent(_batchGuid);
            _changeset = _batch.AddChangeset(_changesetGuid);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TablesBatch"/> class for mocking.
        /// </summary>
        protected TablesBatch()
        { }

        /// <summary>
        /// Re-initializes the batch with the specified Guids for testing purposes.
        /// </summary>
        /// <param name="batchGuid">The batch boundary Guid.</param>
        /// <param name="changesetGuid">The changeset boundary Guid.</param>
        internal void SetBatchGuids(Guid batchGuid, Guid changesetGuid)
        {
            _batchGuid = batchGuid;
            _changesetGuid = changesetGuid;
            _batch = TableRestClient.CreateBatchContent(_batchGuid);
            _changeset = _batch.AddChangeset(_changesetGuid);
        }

        /// <summary>
        /// Placeholder for batch operations. This is just being used for testing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        internal virtual void BatchTest<T>(IEnumerable<T> entities) where T : class, ITableEntity, new()
        {

            foreach (var entity in entities)
            {
                _tableOperations.AddInsertEntityRequest(
                    _changeset,
                    _table,
                    null,
                    null,
                    null,
                    tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                    queryOptions: new QueryOptions() { Format = _format });
            }
        }

        /// <summary>
        /// Placeholder for batch operations. This is just being used for testing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal virtual async Task<Response<List<Response>>> BatchTestAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(BatchTest)}");
            scope.Start();
            try
            {
                var batch = TableRestClient.CreateBatchContent(_batchGuid);
                var changeset = batch.AddChangeset(_changesetGuid);
                foreach (var entity in entities)
                {
                    _addMessages[(entity.PartitionKey, entity.RowKey)] = _batchOperations.AddInsertEntityRequest(
                        changeset,
                        _table,
                        null,
                        _returnNoContent.ToString(),
                        null,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format });
                }
                return await _tableOperations.SendBatchRequestAsync(_tableOperations.CreateBatchRequest(batch, null, null), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Placeholder for batch operations. This is just being used for testing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal virtual Response<List<Response>> BatchTest<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : class, ITableEntity, new()
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(BatchTest)}");
            scope.Start();
            try
            {
                var batch = TableRestClient.CreateBatchContent(_batchGuid);
                var changeset = batch.AddChangeset(_changesetGuid);
                foreach (var entity in entities)
                {
                    _batchOperations.AddInsertEntityRequest(
                        changeset,
                        _table,
                        null,
                        _returnNoContent.ToString(),
                        null,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format });
                }
                return _tableOperations.SendBatchRequest(_tableOperations.CreateBatchRequest(batch, null, null), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a pipeline to use for processing sub-operations before they
        /// are combined into a single multipart request.
        /// </summary>
        /// <returns>A pipeline to use for processing sub-operations.</returns>
        private static HttpPipeline CreateBatchPipeline()
        {
            // Configure the options to use minimal policies
            var options = new TableClientOptions();
            options.Diagnostics.IsLoggingEnabled = false;
            options.Diagnostics.IsTelemetryEnabled = false;
            options.Diagnostics.IsDistributedTracingEnabled = false;
            options.Retry.MaxRetries = 0;

            // Use an empty transport so requests aren't sent
            options.Transport = new MemoryTransport();

            // Use the same authentication mechanism
            return HttpPipelineBuilder.Build(options);
        }
    }
}
