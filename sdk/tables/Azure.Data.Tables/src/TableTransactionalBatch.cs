﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        internal ConcurrentQueue<(ITableEntity Entity, HttpMessage HttpMessage)> _requestMessages = new ConcurrentQueue<(ITableEntity Entity, HttpMessage HttpMessage)>();

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
        /// Adds a Table Entity of type <typeparamref name="T"/> to the batch.
        /// </summary>
        /// <typeparam name="T">A custom model type that implements <see cref="ITableEntity" /> or an instance of <see cref="TableEntity"/>.</typeparam>
        /// <param name="entity">The entity to add.</param>
        public virtual void AddEntity<T>(T entity) where T : class, ITableEntity, new()
        {
            var message = _batchOperations.CreateInsertEntityRequest(
                _table,
                null,
                null,
                _returnNoContent,
                tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                queryOptions: new QueryOptions() { Format = _format });

            AddMessage(entity, message, RequestType.Create);
        }

        /// <summary>
        /// Adds an UpdateEntity request to the batch which
        /// updates the specified table entity of type <typeparamref name="T"/>, if it exists.
        /// If the <paramref name="mode"/> is <see cref="TableUpdateMode.Replace"/>, the entity will be replaced.
        /// If the <paramref name="mode"/> is <see cref="TableUpdateMode.Merge"/>, the property values present in the <paramref name="entity"/> will be merged with the existing entity.
        /// </summary>
        /// <remarks>
        /// See <see cref="TableUpdateMode"/> for more information about the behavior of the <paramref name="mode"/>.
        /// </remarks>
        /// <typeparam name="T">A custom model type that implements <see cref="ITableEntity" /> or an instance of <see cref="TableEntity"/>.</typeparam>
        /// <param name="entity">The entity to update.</param>
        /// <param name="ifMatch">
        /// The If-Match value to be used for optimistic concurrency.
        /// If <see cref="ETag.All"/> is specified, the operation will be executed unconditionally.
        /// If the <see cref="ITableEntity.ETag"/> value is specified, the operation will fail with a status of 412 (Precondition Failed) if the <see cref="ETag"/> value of the entity in the table does not match.
        /// </param>
        /// <param name="mode">Determines the behavior of the Update operation.</param>
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

            AddMessage(entity, message, RequestType.Update);
        }

        /// <summary>
        /// Add a DeleteEntity request to the batch.
        /// </summary>
        /// <param name="partitionKey">The partition key of the entity to delete.</param>
        /// <param name="rowKey">The row key of the entity to delete.</param>
        /// <param name="ifMatch">
        /// The If-Match value to be used for optimistic concurrency.
        /// If <see cref="ETag.All"/> is specified, the operation will be executed unconditionally.
        /// If the <see cref="ITableEntity.ETag"/> value is specified, the operation will fail with a status of 412 (Precondition Failed) if the <see cref="ETag"/> value of the entity in the table does not match.
        /// The default is to delete unconditionally.
        /// </param>
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

            AddMessage(new TableEntity(partitionKey, rowKey) { ETag = ifMatch }, message, RequestType.Delete);
        }

        /// <summary>
        /// Submits the batch transaction to the service for execution.
        /// The sub-operations contained in the batch will either succeed or fail together as a transaction.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns><see cref="Response{T}"/> containing a <see cref="TableBatchResponse"/>.</returns>
        /// <exception cref="RequestFailedException"/> if the batch transaction fails./>
        public virtual async Task<Response<TableBatchResponse>> SubmitBatchAsync(CancellationToken cancellationToken = default)
        {
            var messageList = BuildOrderedBatchRequests();

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(SubmitBatch)}");
            scope.Start();
            try
            {
                var request = _tableOperations.CreateBatchRequest(_batch, null, null);
                var response = await _tableOperations.SendBatchRequestAsync(request, messageList, cancellationToken).ConfigureAwait(false);

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
        /// Submits the batch transaction to the service for execution.
        /// The sub-operations contained in the batch will either succeed or fail together as a transaction.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns><see cref="Response{T}"/> containing a <see cref="TableBatchResponse"/>.</returns>
        /// <exception cref="RequestFailedException"/> if the batch transaction fails./>
        public virtual Response<TableBatchResponse> SubmitBatch(CancellationToken cancellationToken = default)
        {
            var messageList = BuildOrderedBatchRequests();

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(SubmitBatch)}");
            scope.Start();
            try
            {
                var request = _tableOperations.CreateBatchRequest(_batch, null, null);
                var response = _tableOperations.SendBatchRequest(request, messageList, cancellationToken);

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
        /// Adds a message to the batch to preserve sub-request ordering.
        /// </summary>
        /// <returns><c>true</c>if the add succeeded, else <c>false</c>.</returns>
        private bool AddMessage(ITableEntity entity, HttpMessage message, RequestType requestType)
        {
            if (_requestLookup.TryAdd(entity.RowKey, (message, requestType)))
            {
                _requestMessages.Enqueue((entity, message));
                return true;
            }
            throw new InvalidOperationException("Each entity can only be represented once per batch.");
        }

        /// <summary>
        /// Builds an ordered list of <see cref="HttpMessage"/>s containing the batch sub-requests.
        /// </summary>
        /// <returns></returns>
        private List<(ITableEntity entity, HttpMessage HttpMessage)> BuildOrderedBatchRequests()
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
