// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues;
using Newtonsoft.Json;
using QueueClient = Azure.Storage.Queues.QueueClient;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal class BlobTriggerQueueWriter : IBlobTriggerQueueWriter
    {
        private readonly QueueClient _queue;
        private readonly IMessageEnqueuedWatcher _watcher;

        public BlobTriggerQueueWriter(QueueClient queue, IMessageEnqueuedWatcher watcher)
        {
            _queue = queue;
            Debug.Assert(watcher != null);
            _watcher = watcher;
        }

        public async Task<(string QueueName, string MessageId)> EnqueueAsync(BlobTriggerMessage message, CancellationToken cancellationToken)
        {
            string contents = JsonConvert.SerializeObject(message, JsonSerialization.Settings);
            var receipt = await _queue.AddMessageAndCreateIfNotExistsAsync(contents, cancellationToken).ConfigureAwait(false);
            _watcher.Notify(_queue.Name);
            return (QueueName: _queue.Name, MessageId: receipt.MessageId);
        }
    }
}
