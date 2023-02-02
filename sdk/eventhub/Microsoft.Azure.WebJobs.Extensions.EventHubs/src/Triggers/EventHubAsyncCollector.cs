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

namespace Microsoft.Azure.WebJobs.EventHubs
{
    /// <summary>
    /// This collector allows events to be published to Event Hubs asynchronously in the background.
    /// </summary>
    public class EventHubAsyncCollector : IAsyncCollector<EventData>, IDisposable
    {
        private readonly IEventHubProducerClient _client;
        private readonly SemaphoreSlim _batchSemaphore;
        private readonly Dictionary<string, IEventDataBatch> _batches = new Dictionary<string, IEventDataBatch>();

        private bool _disposed;

        /// <summary>
        /// Create a sender around the given client.
        /// </summary>
        /// <param name="client">The producer to use for publishing events.</param>
        internal EventHubAsyncCollector(IEventHubProducerClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            _batchSemaphore = new SemaphoreSlim(1, 1);
            _client = client;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHubAsyncCollector" /> class.
        /// </summary>
        /// <remarks>This constructor is intended to be used for mocking scenarios only.</remarks>
        protected EventHubAsyncCollector()
        {
        }

        /// <summary>
        /// Add an event to be published with round-robin partition assignment.
        /// </summary>
        /// <param name="item">The event to add</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
        public virtual Task AddAsync(EventData item, CancellationToken cancellationToken = default(CancellationToken)) => AddAsync(item, null, cancellationToken);

        /// <summary>
        /// Add an event to be published using the provided <paramref name="partitionKey"/> for partition assignment.
        /// </summary>
        /// <param name="item">The event to add</param>
        /// <param name="partitionKey">The partition key to use for partition assignment.  If <c>null</c>, round-robin partition assignment will be used.</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
        public virtual async Task AddAsync(EventData item, string partitionKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            // Normalize the partition key to an empty string so that it can be
            // used with the dictionary.  The batch options consider null and empty
            // to indicate that no partition key is specified.
            partitionKey ??= string.Empty;

            while (true)
            {
                await _batchSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);

                IEventDataBatch batchToSend;
                try
                {
                    if (!_batches.TryGetValue(partitionKey, out IEventDataBatch batch))
                    {
                        batch = await _client.CreateBatchAsync(new CreateBatchOptions { PartitionKey = partitionKey }, cancellationToken).ConfigureAwait(false);
                        _batches[partitionKey] = batch;
                    }

                    if (batch.TryAdd(item))
                    {
                        return;
                    }

                    // If we reach this point, the new item won't fit in the batch. If there are no other items in the batch it means this event will never fit
                    // and we should error. If there are already some items in the batch, we should publish the batched items and then
                    // try publishing this one again to see if it will fit.
                    if (batch.Count == 0)
                    {
                        // Single event is too large to add.
                        string msg = string.Format(CultureInfo.InvariantCulture, "Event is too large. Event is approximately {0}b and max size is {1}b", item.Body.Length, batch.MaximumSizeInBytes);
                        throw new InvalidOperationException(msg);
                    }

                    _batches.Remove(partitionKey);
                    batchToSend = batch;
                }
                finally
                {
                    _batchSemaphore.Release();
                }

                await _client.SendAsync(batchToSend, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Flushes events collected, publishing them to the Event Hub.
        /// </summary>
        /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
        public virtual async Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _batchSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);

            try
            {
                foreach (var eventDataBatch in _batches.ToArray())
                {
                    await _client.SendAsync(eventDataBatch.Value, cancellationToken).ConfigureAwait(false);
                    _batches.Remove(eventDataBatch.Key);
                }
            }
            finally
            {
                _batchSemaphore.Release();
            }
        }

        /// <summary>
        /// Disposes the collector, ensuring that its resources
        /// have been properly cleaned-up.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the collector, ensuring that its resources
        /// have been properly cleaned-up.
        /// </summary>
        /// <param name="disposing"><c>true</c> if disposing; <c>false</c> if being executed from a finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            _batchSemaphore.Dispose();
            _disposed = true;
        }
    }
}