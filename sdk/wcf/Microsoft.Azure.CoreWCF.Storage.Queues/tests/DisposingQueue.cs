// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreWCF.AzureQueueStorage.Tests
{
    public class DisposingQueue : IAsyncDisposable
    {
        public QueueClient Queue { get; private set; }

        public static async Task<DisposingQueue> CreateAsync(QueueClient queue, IDictionary<string, string> metadata)
        {
            await queue.CreateIfNotExistsAsync(metadata: metadata);
            return new DisposingQueue(queue);
        }

        private DisposingQueue(QueueClient queue)
        {
            Queue = queue;
        }

        public async ValueTask DisposeAsync()
        {
            if (Queue != null)
            {
                try
                {
                    await Queue.DeleteIfExistsAsync();
                    Queue = null;
                }
                catch
                {
                    // swallow the exception to avoid hiding another test failure
                }
            }
        }
    }
}
