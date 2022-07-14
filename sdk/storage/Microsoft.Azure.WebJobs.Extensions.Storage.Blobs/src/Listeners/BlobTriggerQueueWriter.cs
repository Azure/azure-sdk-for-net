// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Protocols;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using QueueClient = Azure.Storage.Queues.QueueClient;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal class BlobTriggerQueueWriter : IBlobTriggerQueueWriter
    {
        public BlobTriggerQueueWriter(
            QueueClient queueClient,
            SharedQueueWatcher wsharedQueueWatcher,
            QueuesOptions options = default)
        {
            QueueClient = queueClient;
            SharedQueueWatcher = wsharedQueueWatcher;
            Options = options ??
                new QueuesOptions()
                {
                    JsonSerializerSettings = JsonSerialization.Settings
                };
        }

        public QueueClient QueueClient { get; }

        public SharedQueueWatcher SharedQueueWatcher { get; }

        public QueuesOptions Options { get; }

        public async Task<(string QueueName, string MessageId)> EnqueueAsync(BlobTriggerMessage message, CancellationToken cancellationToken)
        {
            string contents = JsonConvert.SerializeObject(message, Options.JsonSerializerSettings);
            var receipt = await QueueClient.AddMessageAndCreateIfNotExistsAsync(BinaryData.FromString(contents), cancellationToken).ConfigureAwait(false);
            SharedQueueWatcher.Notify(QueueClient.Name);
            return (QueueName: QueueClient.Name, MessageId: receipt.MessageId);
        }
    }
}
