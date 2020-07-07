// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Storage.Queue;

namespace Microsoft.Azure.WebJobs.Host.Queues.Listeners
{
    internal class QueueListenerFactory : IListenerFactory
    {
        private static string poisonQueueSuffix = "-poison";

        private readonly CloudQueue _queue;
        private readonly CloudQueue _poisonQueue;
        private readonly QueuesOptions _queueOptions;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly SharedQueueWatcher _messageEnqueuedWatcherSetter;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ITriggeredFunctionExecutor _executor;
        private readonly FunctionDescriptor _descriptor;
        private readonly IQueueProcessorFactory _queueProcessorFactory;

        public QueueListenerFactory(CloudQueue queue,
            QueuesOptions queueOptions,
            IWebJobsExceptionHandler exceptionHandler,
            SharedQueueWatcher messageEnqueuedWatcherSetter,
            ILoggerFactory loggerFactory,
            ITriggeredFunctionExecutor executor,
            IQueueProcessorFactory queueProcessorFactory,
            FunctionDescriptor descriptor)
        {
            _queue = queue ?? throw new ArgumentNullException(nameof(queue));
            _queueOptions = queueOptions ?? throw new ArgumentNullException(nameof(queueOptions));
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _messageEnqueuedWatcherSetter = messageEnqueuedWatcherSetter ?? throw new ArgumentNullException(nameof(messageEnqueuedWatcherSetter));
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
            _descriptor = descriptor ?? throw new ArgumentNullException(nameof(descriptor));

            _poisonQueue = CreatePoisonQueueReference(queue.ServiceClient, queue.Name);
            _loggerFactory = loggerFactory;
            _queueProcessorFactory = queueProcessorFactory;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public Task<IListener> CreateAsync(CancellationToken cancellationToken)
        {
            QueueTriggerExecutor triggerExecutor = new QueueTriggerExecutor(_executor);

            IListener listener = new QueueListener(_queue, _poisonQueue, triggerExecutor, _exceptionHandler, _loggerFactory,
                _messageEnqueuedWatcherSetter, _queueOptions, _queueProcessorFactory, _descriptor);

            return Task.FromResult(listener);
        }

        private static CloudQueue CreatePoisonQueueReference(CloudQueueClient client, string name)
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

            if (!QueueClient.IsValidQueueName(possiblePoisonQueueName))
            {
                return null;
            }

            return client.GetQueueReference(possiblePoisonQueueName);
        }
    }
}
