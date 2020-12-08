// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal class SharedBlobQueueListenerFactory : IFactory<SharedBlobQueueListener>
    {
        // the shared queue listener for blobs doesn't have a corresponding function, so we use
        // this constant for the scale monitor
        private const string SharedBlobQueueListenerFunctionId = "SharedBlobQueueListener";

        private readonly SharedQueueWatcher _sharedQueueWatcher;
        private readonly QueueClient _hostBlobTriggerQueue;
        private readonly QueuesOptions _queueOptions;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly IBlobWrittenWatcher _blobWrittenWatcher;
        private readonly FunctionDescriptor _functionDescriptor;
        private readonly StorageAccount _hostAccount;
        private readonly ILoggerFactory _loggerFactory;

        public SharedBlobQueueListenerFactory(
            StorageAccount hostAccount,
            SharedQueueWatcher sharedQueueWatcher,
            QueueClient hostBlobTriggerQueue,
            QueuesOptions queueOptions,
            IWebJobsExceptionHandler exceptionHandler,
            ILoggerFactory loggerFactory,
            IBlobWrittenWatcher blobWrittenWatcher,
            FunctionDescriptor functionDescriptor)
        {
            _hostAccount = hostAccount ?? throw new ArgumentNullException(nameof(hostAccount));
            _sharedQueueWatcher = sharedQueueWatcher ?? throw new ArgumentNullException(nameof(sharedQueueWatcher));
            _hostBlobTriggerQueue = hostBlobTriggerQueue ?? throw new ArgumentNullException(nameof(hostBlobTriggerQueue));
            _queueOptions = queueOptions ?? throw new ArgumentNullException(nameof(queueOptions));
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _loggerFactory = loggerFactory;
            _blobWrittenWatcher = blobWrittenWatcher ?? throw new ArgumentNullException(nameof(blobWrittenWatcher));
            _functionDescriptor = functionDescriptor;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public SharedBlobQueueListener Create()
        {
            BlobQueueTriggerExecutor triggerExecutor = new BlobQueueTriggerExecutor(_blobWrittenWatcher, _loggerFactory.CreateLogger<BlobListener>());

            // The poison queue to use for a given poison blob lives in the same
            // storage account as the triggering blob by default. In multi-storage account scenarios
            // that means that we'll be writing to different poison queues, determined by
            // the triggering blob.
            // However we use a poison queue in the host storage account as a fallback default
            // in case a particular blob lives in a restricted "blob only" storage account (i.e. no queues).
            var defaultPoisonQueue = _hostAccount.CreateQueueServiceClient().GetQueueClient(HostQueueNames.BlobTriggerPoisonQueue);

            // This special queue bypasses the QueueProcessorFactory - we don't want people to override this.
            // So we define our own custom queue processor factory for this listener
            var queueProcessorFactory = new SharedBlobQueueProcessorFactory(triggerExecutor, _hostBlobTriggerQueue, _loggerFactory, _queueOptions, defaultPoisonQueue);
            IListener listener = new QueueListener(_hostBlobTriggerQueue, defaultPoisonQueue, triggerExecutor, _exceptionHandler, _loggerFactory,
                _sharedQueueWatcher, _queueOptions, queueProcessorFactory, _functionDescriptor, functionId: SharedBlobQueueListenerFunctionId);

            return new SharedBlobQueueListener(listener, triggerExecutor);
        }

        /// <summary>
        /// Custom queue processor for the shared blob queue.
        /// </summary>
        private class SharedBlobQueueProcessor : QueueProcessor
        {
            private BlobQueueTriggerExecutor _executor;

            public SharedBlobQueueProcessor(QueueProcessorFactoryContext context, BlobQueueTriggerExecutor executor) : base(context)
            {
                _executor = executor;
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

                var blobTriggerMessage = JsonConvert.DeserializeObject<BlobTriggerMessage>(message.MessageText);

                BlobQueueRegistration registration = null;
                if (_executor.TryGetRegistration(blobTriggerMessage.FunctionId, out registration))
                {
                    var poisonQueue = registration.QueueServiceClient.GetQueueClient(HostQueueNames.BlobTriggerPoisonQueue);
                    return poisonQueue;
                }

                return null;
            }
        }

        private class SharedBlobQueueProcessorFactory : IQueueProcessorFactory
        {
            private readonly BlobQueueTriggerExecutor _triggerExecutor;
            private readonly QueueClient _queue;
            private readonly ILoggerFactory _loggerFactory;
            private readonly QueuesOptions _options;
            private readonly QueueClient _poisonQueue;

            public SharedBlobQueueProcessorFactory(BlobQueueTriggerExecutor triggerExecutor, QueueClient queue, ILoggerFactory loggerFactory, QueuesOptions queuesOptions, QueueClient poisonQueue)
            {
                _triggerExecutor = triggerExecutor;
                _queue = queue;
                _loggerFactory = loggerFactory;
                _options = queuesOptions;
                _poisonQueue = poisonQueue;
            }

            public QueueProcessor Create(QueueProcessorFactoryContext context)
            {
                context = new QueueProcessorFactoryContext(_queue, _loggerFactory, _options, _poisonQueue);
                return new SharedBlobQueueProcessor(context, _triggerExecutor);
            }
        }
    }
}
