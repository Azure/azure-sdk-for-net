// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    /// <summary>
    /// Core object to send events to EventHub.
    /// Any user parameter that sends EventHub events will eventually get bound to this object.
    /// This will queue events and send in batches, also keeping under the 1024kb event hub limit per batch.
    /// </summary>
    internal class EventHubAsyncCollector : IAsyncCollector<EventData>
    {
        private readonly EventHubProducerClient _client;

        private readonly Dictionary<string, PartitionCollector> _partitions = new Dictionary<string, PartitionCollector>();

        private readonly ILogger _logger;

        /// <summary>
        /// Create a sender around the given client.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="loggerFactory"></param>
        public EventHubAsyncCollector(EventHubProducerClient client, ILoggerFactory loggerFactory)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            _client = client;
            _logger = loggerFactory?.CreateLogger(LogCategories.Executor);
        }

        /// <summary>
        /// Add an event.
        /// </summary>
        /// <param name="item">The event to add</param>
        /// <param name="cancellationToken">a cancellation token. </param>
        /// <returns></returns>
        public async Task AddAsync(EventData item, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            // TODO(matell): In the common case item.PartitionKey will be null since partiton keys are not assigned until
            // after a message is delivered.
            string key = item.PartitionKey ?? string.Empty;

            PartitionCollector partition;
            lock (_partitions)
            {
                if (!_partitions.TryGetValue(key, out partition))
                {
                    partition = new PartitionCollector(this._client);
                    _partitions[key] = partition;
                }
            }
            await partition.AddAsync(item, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// synchronously flush events that have been queued up via AddAsync.
        /// </summary>
        /// <param name="cancellationToken">a cancellation token</param>
        public async Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            while (true)
            {
                PartitionCollector partition;
                lock (_partitions)
                {
                    if (_partitions.Count == 0)
                    {
                        return;
                    }
                    var kv = _partitions.First();
                    partition = kv.Value;
                    _partitions.Remove(kv.Key);
                }

                await partition.FlushAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        // A per-partition sender
        private class PartitionCollector : IAsyncCollector<EventData>
        {
            private readonly EventHubProducerClient _client;
            private EventDataBatch _batch;
            private object _lock = new object();

            public PartitionCollector(EventHubProducerClient client)
            {
                this._client = client;
            }

            /// <summary>
            /// Add an event.
            /// </summary>
            /// <param name="item">The event to add</param>
            /// <param name="cancellationToken">a cancellation token. </param>
            /// <returns></returns>
            public async Task AddAsync(EventData item, CancellationToken cancellationToken = default(CancellationToken))
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                while (true)
                {
                    if (_batch == null)
                    {
                        var batch = await _client.CreateBatchAsync(cancellationToken).ConfigureAwait(false);
                        if (Interlocked.CompareExchange(ref _batch, batch, null) != null)
                        {
                            // If we got here, some other thread created the batch before us, so we dispose the one we just made.
                            batch.Dispose();
                        }
                    }

                    EventDataBatch batchToPublish = null;

                    lock (_lock)
                    {
                        if (_batch == null)
                        {
                            // The batch was published and disposed out from under us. Retry the outer loop to create a new batch and try again
                            continue;
                        }

                        if (_batch.TryAdd(item))
                        {
                            return;
                        }

                        // If we reach this point, the new item won't fit in the batch. If there are no other items in the batch it means this event will never fit
                        // and we should error. If there are already some items in the batch, we should publish the batched items and then
                        // try publishing this one again to see if it will fit.
                        if (_batch.Count == 0)
                        {
                            // Single event is too large to add.
                            string msg = string.Format(CultureInfo.InvariantCulture, "Event is too large. Event is approximately {0}b and max size is {1}b", item.Body.Length, _batch.MaximumSizeInBytes);
                            throw new InvalidOperationException(msg);
                        }

                        batchToPublish = _batch;
                        _batch = null;
                    }

                    if (batchToPublish != null)
                    {
                        try
                        {
                            await _client.SendAsync(_batch, cancellationToken).ConfigureAwait(false);
                        }
                        finally
                        {
                            batchToPublish.Dispose();
                        }
                    }
                }
            }

            /// <summary>
            /// synchronously flush events that have been queued up via AddAsync.
            /// </summary>
            /// <param name="cancellationToken">a cancellation token</param>
            public async Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
            {
                EventDataBatch batchToPublish = null;

                lock (_lock)
                {
                    batchToPublish = _batch;
                    _batch = null;
                }

                if (batchToPublish != null)
                {
                    try
                    {
                        await _client.SendAsync(batchToPublish).ConfigureAwait(false);
                    }
                    finally
                    {
                        batchToPublish.Dispose();
                    }
                }
            }
        }
    }
}