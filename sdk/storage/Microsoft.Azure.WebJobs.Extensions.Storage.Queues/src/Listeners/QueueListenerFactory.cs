// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Listeners
{
    internal class QueueListenerFactory : IListenerFactory
    {
        private static string poisonQueueSuffix = "-poison";

        private readonly QueueClient _queue;
        private readonly QueueClient _poisonQueue;
        private readonly QueuesOptions _queueOptions;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly SharedQueueWatcher _messageEnqueuedWatcherSetter;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ITriggeredFunctionExecutor _executor;
        private readonly FunctionDescriptor _descriptor;
        private readonly IQueueProcessorFactory _queueProcessorFactory;
        private readonly QueueCausalityManager _queueCausalityManager;

        public QueueListenerFactory(
            QueueServiceClient queueServiceClient,
            QueueClient queue,
            QueuesOptions queueOptions,
            IWebJobsExceptionHandler exceptionHandler,
            SharedQueueWatcher messageEnqueuedWatcherSetter,
            ILoggerFactory loggerFactory,
            ITriggeredFunctionExecutor executor,
            IQueueProcessorFactory queueProcessorFactory,
            QueueCausalityManager queueCausalityManager,
            FunctionDescriptor descriptor
            )
        {
            _queue = queue ?? throw new ArgumentNullException(nameof(queue));
            _queueOptions = queueOptions ?? throw new ArgumentNullException(nameof(queueOptions));
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _messageEnqueuedWatcherSetter = messageEnqueuedWatcherSetter ?? throw new ArgumentNullException(nameof(messageEnqueuedWatcherSetter));
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
            _descriptor = descriptor ?? throw new ArgumentNullException(nameof(descriptor));
            _queueCausalityManager = queueCausalityManager ?? throw new ArgumentNullException(nameof(queueCausalityManager));

            _poisonQueue = CreatePoisonQueueReference(queueServiceClient, queue.Name);
            _loggerFactory = loggerFactory;
            _queueProcessorFactory = queueProcessorFactory;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public Task<IListener> CreateAsync(CancellationToken cancellationToken)
        {
            QueueTriggerExecutor triggerExecutor = new QueueTriggerExecutor(_executor, _queueCausalityManager);

            var queueProcessor = CreateQueueProcessor(_queue, _poisonQueue, _loggerFactory, _queueProcessorFactory, _queueOptions, _messageEnqueuedWatcherSetter);
            IListener listener = new QueueListener(_queue, _poisonQueue, triggerExecutor, _exceptionHandler, _loggerFactory,
                _messageEnqueuedWatcherSetter, _queueOptions, queueProcessor, _descriptor);

            return Task.FromResult(listener);
        }

        internal static QueueProcessor CreateQueueProcessor(QueueClient queue, QueueClient poisonQueue, ILoggerFactory loggerFactory, IQueueProcessorFactory queueProcessorFactory,
            QueuesOptions queuesOptions, IMessageEnqueuedWatcher sharedWatcher)
        {
            QueueProcessorOptions context = new QueueProcessorOptions(queue, loggerFactory, queuesOptions, poisonQueue);

            QueueProcessor queueProcessor = null;
            if (HostQueueNames.IsHostQueue(queue.Name))
            {
                // We only delegate to the processor factory for application queues,
                // not our built in control queues
                queueProcessor = new QueueProcessor(context);
            }
            else
            {
                queueProcessor = queueProcessorFactory.Create(context);
            }

            QueueListener.RegisterSharedWatcherWithQueueProcessor(queueProcessor, sharedWatcher);

            return queueProcessor;
        }

        private static QueueClient CreatePoisonQueueReference(QueueServiceClient client, string name)
        {
            Debug.Assert(client != null);

            // Only use a corresponding poison queue if:
            // 1. The poison queue name would be valid (adding "-poison" doesn't make the name too long), and
            // 2. The queue itself isn't already a poison queue.

            if (name == null || name.EndsWith(poisonQueueSuffix, StringComparison.Ordinal))
            {
                return null;
            }

            string possiblePoisonQueueName = name + poisonQueueSuffix;

            if (!QueueClientExtensions.IsValidQueueName(possiblePoisonQueueName))
            {
                return null;
            }

            return client.GetQueueClient(possiblePoisonQueueName);
        }
    }
}
