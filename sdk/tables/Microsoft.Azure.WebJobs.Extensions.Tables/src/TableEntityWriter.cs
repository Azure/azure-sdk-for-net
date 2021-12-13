// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
//using Microsoft.Azure.Storage;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class TableEntityWriter<T> : ICollector<T>, IAsyncCollector<T>, IWatcher
        where T : ITableEntity
    {
        private readonly CloudTable _table;

        /// <summary>
        /// Max batch size is an azure limitation on how many entries can be in each batch.
        /// </summary>
        public const int MaxBatchSize = 100;

        /// <summary>
        /// How many different partition keys to cache offline before flushing.
        /// This means the max offline cache size is (MaxPartitionWidth * (MaxBatchSize-1)) entries.
        /// </summary>
        public const int MaxPartitionWidth = 1000;

        private readonly Dictionary<string, Dictionary<string, TableOperation>> _map =
            new Dictionary<string, Dictionary<string, TableOperation>>();

        private readonly TableParameterLog _log;
        private readonly Stopwatch _watch = new Stopwatch();

        public TableEntityWriter(CloudTable table, TableParameterLog log)
        {
            _table = table;
            _log = log;
        }

        public TableEntityWriter(CloudTable table)
            : this(table, new TableParameterLog())
        {
        }

        public void Add(T item)
        {
// TODO
#pragma warning disable AZC0102
            AddAsync(item, CancellationToken.None).GetAwaiter().GetResult();
#pragma warning restore AZC0102
        }

        public async Task AddAsync(T item, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Careful:
            // 1. even with upsert, all rowkeys within a batch must be unique. If they aren't, the previous items
            // will be flushed.
            // 2. Capture at time of Add, in case item is mutated after add.
            // 3. Validate rowkey on the client so we get a nice error instead of the cryptic 400 from auzre.
            string partitionKey = item.PartitionKey;
            string rowKey = item.RowKey;
            TableClient.ValidateAzureTableKeyValue(partitionKey);
            TableClient.ValidateAzureTableKeyValue(rowKey);
            Dictionary<string, TableOperation> partition;
            if (!_map.TryGetValue(partitionKey, out partition))
            {
                if (_map.Count >= MaxPartitionWidth)
                {
                    // Offline cache is too large. Clear some room
                    await FlushAsync(cancellationToken).ConfigureAwait(false);
                }

                partition = new Dictionary<string, TableOperation>();
                _map[partitionKey] = partition;
            }

            var itemCopy = Copy(item);
            if (partition.ContainsKey(rowKey))
            {
                // Replacing item forces a flush to ensure correct eTag behaviour.
                await FlushPartitionAsync(partition, cancellationToken).ConfigureAwait(false);
                // Reinitialize partition
                partition = new Dictionary<string, TableOperation>();
                _map[partitionKey] = partition;
            }

            _log.EntitiesWritten++;
            if (String.IsNullOrEmpty(itemCopy.ETag))
            {
                partition.Add(rowKey, _table.CreateInsertOperation(itemCopy));
            }
            else if (itemCopy.ETag.Equals("*"))
            {
                partition.Add(rowKey, _table.CreateInsertOrReplaceOperation(itemCopy));
            }
            else
            {
                partition.Add(rowKey, _table.CreateReplaceOperation(itemCopy));
            }

            if (partition.Count >= MaxBatchSize)
            {
                await FlushPartitionAsync(partition, cancellationToken).ConfigureAwait(false);
                _map.Remove(partitionKey);
            }
        }

        private static ITableEntity Copy(ITableEntity item)
        {
            var props = TableEntityValueBinder.DeepClone(item.WriteEntity(null));
            DynamicTableEntity copy = new DynamicTableEntity(item.PartitionKey, item.RowKey, item.ETag, props);
            return copy;
        }

        public virtual async Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var kv in _map)
            {
                await FlushPartitionAsync(kv.Value, cancellationToken).ConfigureAwait(false);
            }

            _map.Clear();
        }

        internal virtual async Task FlushPartitionAsync(Dictionary<string, TableOperation> partition,
            CancellationToken cancellationToken)
        {
            if (partition.Count > 0)
            {
                try
                {
                    _watch.Start();
                    await ExecuteBatchAndCreateTableIfNotExistsAsync(partition, cancellationToken).ConfigureAwait(false);
                }
                finally
                {
                    _watch.Stop();
                    _log.ElapsedWriteTime = _watch.Elapsed;
                }
            }
        }

        internal virtual async Task ExecuteBatchAndCreateTableIfNotExistsAsync(
            Dictionary<string, TableOperation> partition, CancellationToken cancellationToken)
        {
            TableBatchOperation batch = new TableBatchOperation();
            foreach (var operation in partition.Values)
            {
                batch.Add(operation);
            }

            if (batch.Count > 0)
            {
                StorageException exception = null;
                try
                {
                    // Commit the batch
                    await _table.ExecuteBatchAsync(batch, cancellationToken).ConfigureAwait(false);
                }
                catch (StorageException e)
                {
                    if (!e.IsNotFoundTableNotFound())
                    {
                        throw new StorageException(e.GetDetailedErrorMessage(), e);
                    }

                    exception = e;
                }

                if (exception != null)
                {
                    // Make sure the table exists
                    await _table.CreateIfNotExistsAsync(cancellationToken).ConfigureAwait(false);
                    // Commit the batch
                    try
                    {
                        await _table.ExecuteBatchAsync(batch, cancellationToken).ConfigureAwait(false);
                    }
                    catch (StorageException e)
                    {
                        throw new StorageException(e.GetDetailedErrorMessage(), e);
                    }
                }
            }
        }

        public ParameterLog GetStatus()
        {
            if (_log.EntitiesWritten > 0)
            {
                return _log;
            }
            else
            {
                return null;
            }
        }
    }
}