// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host.Executors;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal class BlobTriggerQueueWriterFactory
    {
        private readonly IHostIdProvider _hostIdProvider;
        private readonly QueueServiceClientProvider _queueServiceClientProvider;
        private readonly SharedQueueWatcher _sharedQueueWatcher;

        public BlobTriggerQueueWriterFactory(IHostIdProvider hostIdProvider, QueueServiceClientProvider queueServiceClientProvider, SharedQueueWatcher sharedQueueWatcher)
        {
            _hostIdProvider = hostIdProvider ?? throw new ArgumentNullException(nameof(hostIdProvider));
            _queueServiceClientProvider = queueServiceClientProvider ?? throw new ArgumentNullException(nameof(queueServiceClientProvider));
            _sharedQueueWatcher = sharedQueueWatcher ?? throw new ArgumentNullException(nameof(sharedQueueWatcher));
        }

        public async Task<BlobTriggerQueueWriter> CreateAsync(CancellationToken cancellationToken)
        {
            string hostId = await _hostIdProvider.GetHostIdAsync(cancellationToken).ConfigureAwait(false);
            string hostBlobTriggerQueueName = HostQueueNames.GetHostBlobTriggerQueueName(hostId);
            var hostBlobTriggerQueue = _queueServiceClientProvider.GetHost().GetQueueClient(hostBlobTriggerQueueName);

            return new BlobTriggerQueueWriter(hostBlobTriggerQueue, _sharedQueueWatcher);
        }
    }
}
