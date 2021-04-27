// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure.Core;

namespace Azure.Data.Tables
{
    /// <summary>
    /// Provides synchronous and asynchronous methods for creating and submitting table transactional batch requests.
    /// </summary>
    public class TableTransactionalBatch
    {
        private readonly SemaphoreSlim _batchLock = new(1, 1);
        internal MultipartContent _changeset;
        internal MultipartContent _batch;
        private Guid _batchGuid;
        private Guid _changesetGuid;
        internal readonly Dictionary<string, BatchItem> _requestLookup = new();
        internal ConcurrentQueue<string> _requestMessages = new();
        internal List<BatchItem> _submittedMessageList;
        internal bool _submitted;
        private readonly string _partitionKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableTransactionalBatch"/> class.
        /// </summary>
        /// <param name="partitionKey">The partitionKEy value for this transactional batch.</param>
        public TableTransactionalBatch(string partitionKey)
        {
            Argument.AssertNotNullOrEmpty(partitionKey, nameof(partitionKey));

            _batch = TableRestClient.CreateBatchContent(_batchGuid);
            _changeset = _batch.AddChangeset(_changesetGuid);
            _partitionKey = partitionKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableTransactionalBatch"/> class for mocking.
        /// </summary>
        protected TableTransactionalBatch()
        { }

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
        /// Adds a Table Entity to the batch.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public virtual void AddEntity(ITableEntity entity)
        {
            AddRequest(entity, RequestType.Create);
        }

        /// <summary>
        /// Adds an UpdateEntity request to the batch which updates the specified table entity, if it exists.
        /// If the <paramref name="mode"/> is <see cref="TableUpdateMode.Replace"/>, the entity will be replaced.
        /// If the <paramref name="mode"/> is <see cref="TableUpdateMode.Merge"/>, the property values present in the
        /// <paramref name="entity"/> will be merged with the existing entity.
        /// </summary>
        /// <remarks>
        /// See <see cref="TableUpdateMode"/> for more information about the behavior of the <paramref name="mode"/>.
        /// </remarks>
        /// <param name="entity">The entity to update.</param>
        /// <param name="ifMatch">
        /// The If-Match value to be used for optimistic concurrency.
        /// If <see cref="ETag.All"/> is specified, the operation will be executed unconditionally.
        /// If the <see cref="ITableEntity.ETag"/> value is specified, the operation will fail with a status of 412 (Precondition Failed)
        /// if the <see cref="ETag"/> value of the entity in the table does not match.
        /// </param>
        /// <param name="mode">Determines the behavior of the Update operation.</param>
        public virtual void UpdateEntity(ITableEntity entity, ETag ifMatch, TableUpdateMode mode = TableUpdateMode.Merge)
        {
            entity.ETag = ifMatch;
            AddRequest(entity, mode == TableUpdateMode.Merge ? RequestType.UpdateMerge : RequestType.UpdateReplace);
        }

        /// <summary>
        /// Replaces the specified table entity, if it exists. Creates the entity if it does not exist.
        /// </summary>
        /// <param name="entity">The entity to upsert.</param>
        /// <param name="mode">Determines the behavior of the update operation when the entity already exists in the table.
        /// See <see cref="TableUpdateMode"/> for more details.</param>
        public virtual void UpsertEntity(ITableEntity entity, TableUpdateMode mode = TableUpdateMode.Merge)
            => AddRequest(entity, mode == TableUpdateMode.Merge ? RequestType.UpsertMerge : RequestType.UpsertReplace);

        /// <summary>
        /// Add a DeleteEntity request to the batch.
        /// </summary>
        /// <param name="rowKey">The row key of the entity to delete.</param>
        /// <param name="ifMatch">
        /// The If-Match value to be used for optimistic concurrency.
        /// If <see cref="ETag.All"/> is specified, the operation will be executed unconditionally.
        /// If the <see cref="ITableEntity.ETag"/> value is specified, the operation will fail with a status of 412 (Precondition Failed)
        /// if the <see cref="ETag"/> value of the entity in the table does not match.
        /// The default is to delete unconditionally.
        /// </param>
        public virtual void DeleteEntity(string rowKey, ETag ifMatch = default)
            => AddRequest(new TableEntity(_partitionKey, rowKey) { ETag = ifMatch }, RequestType.Delete);

        /// <summary>
        /// Tries to get the entity that caused the batch operation failure from the <see cref="RequestFailedException"/>.
        /// </summary>
        /// <param name="exception">The exception thrown from <see cref="TableClient.SubmitTransaction"/> or <see cref="TableClient.SubmitTransactionAsync"/>.</param>
        /// <param name="failedEntity">If the return value is <c>true</c>, contains the <see cref="ITableEntity"/> that caused the batch operation to fail.</param>
        /// <returns><c>true</c> if the failed entity was retrieved from the exception, else <c>false</c>.</returns>
        public virtual bool TryGetFailedEntityFromException(RequestFailedException exception, out ITableEntity failedEntity)
        {
            failedEntity = null;

            if (exception.Data.Contains(TableConstants.ExceptionData.FailedEntityIndex))
            {
                try
                {
                    if (exception.Data[TableConstants.ExceptionData.FailedEntityIndex] is string stringIndex && int.TryParse(stringIndex, out int index))
                    {
                        failedEntity = _submittedMessageList[index].Entity;
                    }
                }
                catch
                {
                    // We just don't want to throw here.
                }
            }

            return failedEntity != null;
        }

        /// <summary>
        /// Re-initializes the batch with the specified Guids for testing purposes.
        /// </summary>
        /// <param name="batchGuid">The batch boundary Guid.</param>
        /// <param name="changesetGuid">The changeset boundary Guid.</param>
        internal virtual void SetBatchGuids(Guid batchGuid, Guid changesetGuid)
        {
            _batchGuid = batchGuid;
            _changesetGuid = changesetGuid;
            _batch = TableRestClient.CreateBatchContent(_batchGuid);
            _changeset = _batch.AddChangeset(_changesetGuid);
        }

        /// <summary>
        /// Adds a message to the batch to preserve sub-request ordering.
        /// </summary>
        private void AddRequest(ITableEntity entity, RequestType requestType)
        {
            _requestMessages.Enqueue(entity.RowKey);
            _requestLookup[entity.RowKey] = new BatchItem(requestType, entity, null);
        }

        /// <summary>
        /// Gets the collection of entities represented in the batch.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public IReadOnlyList<ITableEntity> GetEntities()
        {
            return _requestMessages
                .ToList()
                .Select(rk => _requestLookup[rk].Entity)
                .ToList()
                .AsReadOnly();
        }

        /// <summary>
        /// Clears the contents of the batch operation.
        /// </summary>
        public void ClearOperations()
        {
            _requestLookup.Clear();
            _requestMessages = new ConcurrentQueue<string>();
        }

        /// <summary>
        /// Removes the specified entity from the batch.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool RemoveEntityOperation(ITableEntity entity)
            => RemoveEntityOperations(new[] { entity });

        /// <summary>
        /// Removes the specified entities from the batch.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool RemoveEntityOperations(IEnumerable<ITableEntity> entities)
        {
            try
            {
                bool acquired = _batchLock.Wait(TimeSpan.FromSeconds(2));
                if (!acquired)
                {
                    throw new Exception($"Unexpected error. Unable to {nameof(RemoveEntityOperation)}");
                }
                var itemsToRemove = new HashSet<string>(entities.Select(e => e.RowKey));
                var newQueue = new ConcurrentQueue<string>();
                while (_requestMessages.TryDequeue(out string item))
                {
                    if (!itemsToRemove.Contains(item))
                    {
                        newQueue.Enqueue(item);
                    }
                    else
                    {
                        var isRemoved = _requestLookup.Remove(item);
                        if (!isRemoved)
                        {
                            // There was some error removing the entities
                            return false;
                        }
                    }
                }
                _requestMessages = newQueue;
            }
            finally
            {
                _batchLock.Release();
            }
            return true;
        }

        /// <summary>
        /// Returns the count of entity operations contained in the batch.
        /// </summary>
        public int OperationCount => _requestMessages.Count;
    }
}
