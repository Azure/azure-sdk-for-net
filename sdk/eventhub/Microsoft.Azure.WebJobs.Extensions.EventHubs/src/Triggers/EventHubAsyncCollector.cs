// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.EventHubs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    /// <summary>
    /// Core object to send events to EventHub.
    /// Any user parameter that sends EventHub events will eventually get bound to this object.
    /// This will queue events and send in batches, also keeping under the 1024kb event hub limit per batch.
    /// </summary>
    internal class EventHubAsyncCollector : IAsyncCollector<EventData>, IDisposable
    {
        private readonly IEventHubProducerClient _client;
        private readonly SemaphoreSlim _batchSemaphore;
        private readonly Dictionary<string, IEventDataBatch> _batches = new Dictionary<string, IEventDataBatch>();

        /// <summary>
        /// Create a sender around the given client.
        /// </summary>
        /// <param name="client"></param>
        public EventHubAsyncCollector(IEventHubProducerClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            _batchSemaphore = new SemaphoreSlim(1, 1);
            _client = client;
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

            string key = item.PartitionKey ?? string.Empty;

            while (true)
            {
                await _batchSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);

                IEventDataBatch batchToSend;
                try
                {
                    if (!_batches.TryGetValue(key, out IEventDataBatch batch))
                    {
                        batch = await _client.CreateBatchAsync(cancellationToken).ConfigureAwait(false);
                        _batches[key] = batch;
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

                    _batches.Remove(key);
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
        /// synchronously flush events that have been queued up via AddAsync.
        /// </summary>
        /// <param name="cancellationToken">a cancellation token</param>
        public async Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
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

        public void Dispose()
        {
            _batchSemaphore.Dispose();
        }
    }
}