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
    internal class TablesBatch
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
        internal ConcurrentDictionary<string, HttpMessage> _addMessages = new ConcurrentDictionary<string, HttpMessage>();

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
        /// Add a collection of AddEntity requests to the batch.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        public virtual void AddEntities<T>(IEnumerable<T> entities) where T : class, ITableEntity, new()
        {
            foreach (T entity in entities)
            {
                AddEntity(entity);
            }
        }

        /// <summary>
        /// Add an AddEntity requests to the batch.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public virtual void AddEntity<T>(T entity) where T : class, ITableEntity, new()
        {
            _addMessages[entity.RowKey] = _batchOperations.AddInsertEntityRequest(
                _changeset,
                _table,
                null,
                null,
                _returnNoContent,
                tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                queryOptions: new QueryOptions() { Format = _format });
        }

        public virtual void UpdateEntity<T>(T entity, ETag ifMatch, TableUpdateMode mode = TableUpdateMode.Merge) where T : class, ITableEntity, new()
        {
            _batchOperations.AddUpdateEntityRequest(
                _changeset,
                _table,
                entity.PartitionKey,
                entity.RowKey,
                null,
                null,
                ifMatch.ToString(),
                tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                queryOptions: new QueryOptions() { Format = _format });
        }

        public virtual void DeleteEntity(string partitionKey, string rowKey, ETag ifMatch = default)
        {
            _batchOperations.AddDeleteEntityRequest(
                _changeset,
                _table,
                partitionKey,
                rowKey,
                ifMatch.ToString(),
                null,
                null,
                queryOptions: new QueryOptions() { Format = _format });
        }

        /// <summary>
        /// Placeholder for batch operations. This is just being used for testing.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<List<Response>>> SubmitBatchAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(SubmitBatch)}");
            scope.Start();
            try
            {
                return await _tableOperations.SendBatchRequestAsync(_tableOperations.CreateBatchRequest(_batch, null, null), cancellationToken).ConfigureAwait(false);
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
        /// <returns></returns>
        public virtual Response<List<Response>> SubmitBatch<T>(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(SubmitBatch)}");
            scope.Start();
            try
            {
                return _tableOperations.SendBatchRequest(_tableOperations.CreateBatchRequest(_batch, null, null), cancellationToken);
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
