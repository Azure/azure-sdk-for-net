// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Data.Tables.Models;

namespace Azure.Data.Tables
{
    public partial class TableTransactionalBatch
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
        internal ConcurrentDictionary<string, (HttpMessage Message, RequestType RequestType)> _requestLookup = new ConcurrentDictionary<string, (HttpMessage Message, RequestType RequestType)>();
        internal ConcurrentQueue<(string RowKey, HttpMessage HttpMessage)> _requestMessages = new ConcurrentQueue<(string RowKey, HttpMessage HttpMessage)>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TableTransactionalBatch"/> class.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="tableOperations"></param>
        /// <param name="format"></param>
        internal TableTransactionalBatch(string table, TableRestClient tableOperations, OdataMetadataFormat format)
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
        /// Initializes a new instance of the <see cref="TableTransactionalBatch"/> class for mocking.
        /// </summary>
        protected TableTransactionalBatch()
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
            var message = _batchOperations.CreateInsertEntityRequest(
                _table,
                null,
                null,
                _returnNoContent,
                tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                queryOptions: new QueryOptions() { Format = _format });

            AddMessage(entity.RowKey, message, RequestType.Create);
        }

        /// <summary>
        /// Add an UpdateEntity request to the batch.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public virtual void UpdateEntity<T>(T entity, ETag ifMatch, TableUpdateMode mode = TableUpdateMode.Merge) where T : class, ITableEntity, new()
        {
            var message = _batchOperations.CreateUpdateEntityRequest(
                _table,
                entity.PartitionKey,
                entity.RowKey,
                null,
                null,
                ifMatch.ToString(),
                tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                queryOptions: new QueryOptions() { Format = _format });

            AddMessage(entity.RowKey, message, RequestType.Update);
        }

        /// <summary>
        /// Add a DeleteEntity request to the batch.
        /// </summary>
        /// <param name="partitionKey"></param>
        /// <param name="rowKey"></param>
        /// <param name="ifMatch"></param>
        public virtual void DeleteEntity(string partitionKey, string rowKey, ETag ifMatch = default)
        {
            var message = _batchOperations.CreateDeleteEntityRequest(
                _table,
                partitionKey,
                rowKey,
                ifMatch.ToString(),
                null,
                null,
                queryOptions: new QueryOptions() { Format = _format });

            AddMessage(rowKey, message, RequestType.Delete);
        }

        /// <summary>
        /// Placeholder for batch operations. This is just being used for testing.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<TableBatchResponse>> SubmitBatchAsync(CancellationToken cancellationToken = default)
        {
            var messageList = BuildOrderedBatchRequests();

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(SubmitBatch)}");
            scope.Start();
            try
            {
                var request = _tableOperations.CreateBatchRequest(_batch, null, null);
                var response = await _tableOperations.SendBatchRequestAsync(request, cancellationToken).ConfigureAwait(false);

                for (int i = 0; i < response.Value.Count; i++)
                {
                    messageList[i].HttpMessage.Response = response.Value[i];
                }

                return Response.FromValue(new TableBatchResponse(_requestLookup), response.GetRawResponse());
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
        public virtual Response<TableBatchResponse> SubmitBatch<T>(CancellationToken cancellationToken = default)
        {
            var messageList = BuildOrderedBatchRequests();

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(SubmitBatch)}");
            scope.Start();
            try
            {
                var request = _tableOperations.CreateBatchRequest(_batch, null, null);
                var response = _tableOperations.SendBatchRequest(request, cancellationToken);

                for (int i = 0; i < response.Value.Count; i++)
                {
                    messageList[i].HttpMessage.Response = response.Value[i];
                }

                return Response.FromValue(new TableBatchResponse(_requestLookup), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private bool AddMessage(string rowKey, HttpMessage message, RequestType requestType)
        {
            if (_requestLookup.TryAdd(rowKey, (message, requestType)))
            {
                _requestMessages.Enqueue((rowKey, message));
                return true;
            }
            throw new InvalidOperationException("Each entity can only be represented once per batch.");
        }

        private List<(string RowKey, HttpMessage HttpMessage)> BuildOrderedBatchRequests()
        {
            var orderedList = _requestMessages.ToList();
            foreach (var item in orderedList)
            {
                _changeset.AddContent(new RequestRequestContent(item.HttpMessage.Request));
            }
            return orderedList;
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
