// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class TableEntityWriter: ICollector<TableEntity>, IAsyncCollector<TableEntity>
    {
        private readonly TableClient _table;
        private readonly string _partitionKey;
        private readonly string _rowKey;

        /// <summary>
        /// Max batch size is an azure limitation on how many entries can be in each batch.
        /// </summary>
        public const int MaxBatchSize = 100;

        /// <summary>
        /// How many different partition keys to cache offline before flushing.
        /// This means the max offline cache size is (MaxPartitionWidth * (MaxBatchSize-1)) entries.
        /// </summary>
        public const int MaxPartitionWidth = 1000;

        private readonly Dictionary<string, Dictionary<string, TableTransactionAction>> _map = new();

        public TableEntityWriter(TableClient table, string partitionKey, string rowKey)
        {
            _table = table;
            _partitionKey = partitionKey;
            _rowKey = rowKey;
        }

        public void Add(TableEntity item)
        {
#pragma warning disable AZC0102
            AddAsync(item, CancellationToken.None).GetAwaiter().GetResult();
#pragma warning restore AZC0102
        }

        public async Task AddAsync(TableEntity item, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Careful:
            // 1. even with upsert, all rowkeys within a batch must be unique. If they aren't, the previous items
            // will be flushed.
            // 2. Capture at time of Add, in case item is mutated after add.
            // 3. Validate rowkey on the client so we get a nice error instead of the cryptic 400 from auzre.
            item.PartitionKey ??= _partitionKey;
            item.RowKey ??= _rowKey;

            string partitionKey = item.PartitionKey;
            string rowKey = item.RowKey;
            TableClientHelpers.ValidateAzureTableKeyValue(partitionKey);
            TableClientHelpers.ValidateAzureTableKeyValue(rowKey);

            Dictionary<string, TableTransactionAction> partition;
            if (!_map.TryGetValue(partitionKey, out partition))
            {
                if (_map.Count >= MaxPartitionWidth)
                {
                    // Offline cache is too large. Clear some room
                    await FlushAsync(cancellationToken).ConfigureAwait(false);
                }

                partition = new Dictionary<string, TableTransactionAction>();
                _map[partitionKey] = partition;
            }

            if (partition.ContainsKey(rowKey))
            {
                // Replacing item forces a flush to ensure correct eTag behaviour.
                await FlushPartitionAsync(partition, cancellationToken).ConfigureAwait(false);
                // Reinitialize partition
                partition = new Dictionary<string, TableTransactionAction>();
                _map[partitionKey] = partition;
            }

            if (string.IsNullOrEmpty(item.ETag.ToString()))
            {
                partition.Add(rowKey, new TableTransactionAction(TableTransactionActionType.Add, item));
            }
            else if (item.ETag.Equals("*"))
            {
                partition.Add(rowKey, new TableTransactionAction(TableTransactionActionType.UpsertReplace, item));
            }
            else
            {
                partition.Add(rowKey, new TableTransactionAction(TableTransactionActionType.UpdateReplace, item, item.ETag));
            }

            if (partition.Count >= MaxBatchSize)
            {
                await FlushPartitionAsync(partition, cancellationToken).ConfigureAwait(false);
                _map.Remove(partitionKey);
            }
        }

        public virtual async Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var kv in _map)
            {
                await FlushPartitionAsync(kv.Value, cancellationToken).ConfigureAwait(false);
            }

            _map.Clear();
        }

        internal virtual async Task FlushPartitionAsync(Dictionary<string, TableTransactionAction> partition,
            CancellationToken cancellationToken)
        {
            if (partition.Count > 0)
            {
                RequestFailedException exception = null;
                try
                {
                    // Commit the batch
                    await _table.SubmitTransactionAsync(partition.Values, cancellationToken).ConfigureAwait(false);
                }
                catch (RequestFailedException e) when
                    (e.Status == 404 && (e.ErrorCode == TableErrorCode.TableNotFound || e.ErrorCode == TableErrorCode.ResourceNotFound))
                {
                    exception = e;
                }

                if (exception != null)
                {
                    // Make sure the table exists
                    await _table.CreateIfNotExistsAsync(cancellationToken).ConfigureAwait(false);
                    // Commit the batch
                    await _table.SubmitTransactionAsync(partition.Values, cancellationToken).ConfigureAwait(false);
                }
            }
        }
    }
}