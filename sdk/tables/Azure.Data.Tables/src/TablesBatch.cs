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
        private string _table;
        private ClientDiagnostics _diagnostics;
        private MultipartContent _changeset;
        private OdataMetadataFormat _format;
        private ResponseFormat _returnNoContent = ResponseFormat.ReturnNoContent;
        internal MultipartContent _batch;
        internal Guid _batchGuid = default;
        internal Guid _changesetGuid = default;
        internal ConcurrentDictionary<(string PartitionKey, string RowKey), HttpMessage> AddMessages = new ConcurrentDictionary<(string PartitionKey, string RowKey), HttpMessage>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TablesBatch"/> class.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="tableOperations"></param>
        /// <param name="format"></param>
        /// <param name="diagnostics"></param>
        internal TablesBatch(string table, TableRestClient tableOperations, OdataMetadataFormat format, ClientDiagnostics diagnostics)
        {
            _table = table;
            _tableOperations = tableOperations;
            _format = format;
            _diagnostics = diagnostics;
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
                    AddMessages[(entity.PartitionKey, entity.RowKey)] = _tableOperations.AddInsertEntityRequest(
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
                    _tableOperations.AddInsertEntityRequest(
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
    }
}
