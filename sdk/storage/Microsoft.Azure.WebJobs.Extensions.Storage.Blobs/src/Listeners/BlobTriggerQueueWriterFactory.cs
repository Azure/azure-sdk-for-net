// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Protocols;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal class BlobTriggerQueueWriterFactory
    {
        private readonly IHostIdProvider _hostIdProvider;
        private readonly QueueServiceClientProvider _queueServiceClientProvider;
        private readonly SharedQueueWatcher _sharedQueueWatcher;
        private readonly QueuesOptions _options;

        public BlobTriggerQueueWriterFactory(
            IHostIdProvider hostIdProvider,
            QueueServiceClientProvider queueServiceClientProvider,
            SharedQueueWatcher sharedQueueWatcher,
            IOptions<QueuesOptions> options = default)
        {
            _hostIdProvider = hostIdProvider ?? throw new ArgumentNullException(nameof(hostIdProvider));
            _queueServiceClientProvider = queueServiceClientProvider ?? throw new ArgumentNullException(nameof(queueServiceClientProvider));
            _sharedQueueWatcher = sharedQueueWatcher ?? throw new ArgumentNullException(nameof(sharedQueueWatcher));
            _options = options?.Value ?? new QueuesOptions()
            {
                JsonSerializerSettings = JsonSerialization.Settings
            };
        }

        public async Task<BlobTriggerQueueWriter> CreateAsync(CancellationToken cancellationToken)
        {
            string hostId = await _hostIdProvider.GetHostIdAsync(cancellationToken).ConfigureAwait(false);
            string hostBlobTriggerQueueName = HostQueueNames.GetHostBlobTriggerQueueName(hostId);
            var hostBlobTriggerQueue = _queueServiceClientProvider.GetHost().GetQueueClient(hostBlobTriggerQueueName);

            return new BlobTriggerQueueWriter(hostBlobTriggerQueue, _sharedQueueWatcher, _options);
        }
    }
}
