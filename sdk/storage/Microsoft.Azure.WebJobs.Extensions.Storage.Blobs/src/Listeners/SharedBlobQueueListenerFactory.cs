// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal class SharedBlobQueueListenerFactory : IFactory<SharedBlobQueueListener>
    {
        // the shared queue listener for blobs doesn't have a corresponding function, so we use
        // this constant for the scale monitor
        private const string SharedBlobQueueListenerFunctionId = "SharedBlobQueueListener";

        private readonly SharedQueueWatcher _sharedQueueWatcher;
        private readonly QueueClient _hostBlobTriggerQueue;
        private readonly BlobsOptions _blobsOptions;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly IBlobWrittenWatcher _blobWrittenWatcher;
        private readonly FunctionDescriptor _functionDescriptor;
        private readonly QueueServiceClient _hostQueueServiceClient;
        private readonly ILoggerFactory _loggerFactory;
        private readonly BlobTriggerSource _blobTriggerSource;

        public SharedBlobQueueListenerFactory(
            QueueServiceClient hostQueueServiceClient,
            SharedQueueWatcher sharedQueueWatcher,
            QueueClient hostBlobTriggerQueue,
            BlobsOptions blobsOptions,
            IWebJobsExceptionHandler exceptionHandler,
            ILoggerFactory loggerFactory,
            IBlobWrittenWatcher blobWrittenWatcher,
            FunctionDescriptor functionDescriptor,
            BlobTriggerSource blobTriggerSource)
        {
            _hostQueueServiceClient = hostQueueServiceClient ?? throw new ArgumentNullException(nameof(hostQueueServiceClient));
            _sharedQueueWatcher = sharedQueueWatcher ?? throw new ArgumentNullException(nameof(sharedQueueWatcher));
            _hostBlobTriggerQueue = hostBlobTriggerQueue ?? throw new ArgumentNullException(nameof(hostBlobTriggerQueue));
            _blobsOptions = blobsOptions ?? throw new ArgumentNullException(nameof(blobsOptions));
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _loggerFactory = loggerFactory;
            _blobWrittenWatcher = blobWrittenWatcher;
            _functionDescriptor = functionDescriptor;
            _blobTriggerSource = blobTriggerSource;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public SharedBlobQueueListener Create()
        {
            BlobQueueTriggerExecutor triggerExecutor = new BlobQueueTriggerExecutor(_blobTriggerSource, _blobWrittenWatcher, _loggerFactory.CreateLogger<BlobListener>());

            // The poison queue to use for a given poison blob lives in the same
            // storage account as the triggering blob by default. In multi-storage account scenarios
            // that means that we'll be writing to different poison queues, determined by
            // the triggering blob.
            // However we use a poison queue in the host storage account as a fallback default
            // in case a particular blob lives in a restricted "blob only" storage account (i.e. no queues).
            var defaultPoisonQueue = _hostQueueServiceClient.GetQueueClient(HostQueueNames.BlobTriggerPoisonQueue);

            // This special queue bypasses the QueueProcessorFactory - we don't want people to override this.
            // So we define our own custom queue processor factory for this listener
            var queuesOptions = BlobsOptionsToQueuesOptions(_blobsOptions);
            var queueProcessor = new SharedBlobQueueProcessor(triggerExecutor, _hostBlobTriggerQueue, defaultPoisonQueue, _loggerFactory, queuesOptions);
            QueueListener.RegisterSharedWatcherWithQueueProcessor(queueProcessor, _sharedQueueWatcher);
            IListener listener = new QueueListener(_hostBlobTriggerQueue, defaultPoisonQueue, triggerExecutor, _exceptionHandler, _loggerFactory,
                _sharedQueueWatcher, queuesOptions, queueProcessor, _functionDescriptor, functionId: SharedBlobQueueListenerFunctionId);

            return new SharedBlobQueueListener(listener, triggerExecutor);
        }

        internal static QueuesOptions BlobsOptionsToQueuesOptions(BlobsOptions blobsOptions)
        {
            // The maximum parallelism of QueueListener is BatchSize + NewBatchThreshold when configuring queue options. I.e. extension will keep requesting new batches until number
            // of tasks that are still processing messages is below NewBatchThreshold.

            // Split MaxDegreeOfParallelism between BatchSize and NewBatchThreshold. Cap at MaxBatchSize to not exceed the limit and make sure there's at least 1 message pulled
            // if MaxDegreeOfParallelism is 1.
            int batchSize = Math.Min(QueuesOptions.MaxBatchSize, blobsOptions.MaxDegreeOfParallelism / 2 + 1);
            int newBatchThreshold = blobsOptions.MaxDegreeOfParallelism - batchSize;

            return new QueuesOptions()
            {
                BatchSize = batchSize,
                NewBatchThreshold = newBatchThreshold,
            };
        }

        /// <summary>
        /// Custom queue processor for the shared blob queue.
        /// </summary>
        private class SharedBlobQueueProcessor : QueueProcessor
        {
            private BlobQueueTriggerExecutor _executor;

            public SharedBlobQueueProcessor(BlobQueueTriggerExecutor triggerExecutor, QueueClient queue, QueueClient poisonQueue, ILoggerFactory loggerFactory, QueuesOptions queuesOptions)
                : base(new QueueProcessorOptions(queue, loggerFactory, queuesOptions, poisonQueue)) {
                _executor = triggerExecutor;
            }

            protected override Task CopyMessageToPoisonQueueAsync(QueueMessage message, QueueClient poisonQueue, CancellationToken cancellationToken)
            {
                // determine the poison queue based on the storage account
                // of the triggering blob, or default
                poisonQueue = GetPoisonQueue(message) ?? poisonQueue;

                return base.CopyMessageToPoisonQueueAsync(message, poisonQueue, cancellationToken);
            }

            private QueueClient GetPoisonQueue(QueueMessage message)
            {
                if (message == null)
                {
                    throw new ArgumentNullException(nameof(message));
                }

                var blobTriggerMessage = JsonConvert.DeserializeObject<BlobTriggerMessage>(message.Body.ToValidUTF8String());

                BlobQueueRegistration registration = null;
                if (_executor.TryGetRegistration(blobTriggerMessage.FunctionId, out registration))
                {
                    var poisonQueue = registration.QueueServiceClient.GetQueueClient(HostQueueNames.BlobTriggerPoisonQueue);
                    return poisonQueue;
                }

                return null;
            }
        }
    }
}
