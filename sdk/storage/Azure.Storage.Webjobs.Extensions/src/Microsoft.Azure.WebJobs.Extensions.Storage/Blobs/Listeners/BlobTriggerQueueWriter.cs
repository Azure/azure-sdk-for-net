// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.Storage.Queue;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal class BlobTriggerQueueWriter : IBlobTriggerQueueWriter
    {
        private readonly CloudQueue _queue;
        private readonly IMessageEnqueuedWatcher _watcher;

        public BlobTriggerQueueWriter(CloudQueue queue, IMessageEnqueuedWatcher watcher)
        {
            _queue = queue;
            Debug.Assert(watcher != null);
            _watcher = watcher;
        }

        public async Task<(string QueueName, string MessageId)> EnqueueAsync(BlobTriggerMessage message, CancellationToken cancellationToken)
        {
            string contents = JsonConvert.SerializeObject(message, JsonSerialization.Settings);
            var queueMessage = new CloudQueueMessage(contents);
            await _queue.AddMessageAndCreateIfNotExistsAsync(queueMessage, cancellationToken);
            _watcher.Notify(_queue.Name);
            return (QueueName: _queue.Name, MessageId: queueMessage.Id);
        }
    }
}
