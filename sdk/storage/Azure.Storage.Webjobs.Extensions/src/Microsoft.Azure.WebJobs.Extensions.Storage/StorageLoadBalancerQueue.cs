// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Azure.Storage.Queue;
using Newtonsoft.Json;

namespace WebJobs.Extensions.Storage
{
    // $$$ Review APIs
    internal class StorageLoadBalancerQueue : ILoadBalancerQueue
    {
        // this shared queue listener doesn't have a corresponding function, so we use
        // this constant for the scale monitor
        private const string SharedLoadBalancerQueueListenerFunctionId = "SharedLoadBalancerQueueListener";

        private readonly QueuesOptions _queueOptions;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly SharedQueueWatcher _sharedWatcher;
        private readonly StorageAccountProvider _storageAccountProvider;
        private readonly IQueueProcessorFactory _queueProcessorFactory;

        public StorageLoadBalancerQueue(
            StorageAccountProvider storageAccountProvider,
               IOptions<QueuesOptions> queueOptions,
               IWebJobsExceptionHandler exceptionHandler,
               SharedQueueWatcher sharedWatcher,
               ILoggerFactory loggerFactory,
               IQueueProcessorFactory queueProcessorFactory)
        {
            _storageAccountProvider = storageAccountProvider;
            _queueOptions = queueOptions.Value;
            _exceptionHandler = exceptionHandler;
            _sharedWatcher = sharedWatcher;
            _loggerFactory = loggerFactory;
            _queueProcessorFactory = queueProcessorFactory;
        }

        public IAsyncCollector<T> GetQueueWriter<T>(string queue)
        {
            return new QueueWriter<T>(this, Convert(queue));
        }

        class QueueWriter<T> : IAsyncCollector<T>
        {
            StorageLoadBalancerQueue _parent;
            CloudQueue _queue;

            public QueueWriter(StorageLoadBalancerQueue parent, CloudQueue queue)
            {
                this._parent = parent;
                this._queue = queue;
            }


            public async Task AddAsync(T item, CancellationToken cancellationToken = default(CancellationToken))
            {
                string contents = JsonConvert.SerializeObject(
                    item,
                    JsonSerialization.Settings);

                var msg = new CloudQueueMessage(contents);
                await _queue.AddMessageAndCreateIfNotExistsAsync(msg, cancellationToken);

                _parent._sharedWatcher.Notify(_queue.Name);
            }

            public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.CompletedTask;
            }
        }

        private CloudQueue Convert(string queueMoniker)
        {
            // $$$ Review
            var account = _storageAccountProvider.Get(ConnectionStringNames.Dashboard);
            var queue = account.CreateCloudQueueClient().GetQueueReference(queueMoniker);
            return queue;
        }

        public IListener CreateQueueListenr(
            string queue,
            string poisonQueue,
            Func<string, CancellationToken, Task<FunctionResult>> callback
            )
        {
            // Provide an upper bound on the maximum polling interval for run/abort from dashboard.
            // This ensures that if users have customized this value the Dashboard will remain responsive.
            TimeSpan maxPollingInterval = QueuePollingIntervals.DefaultMaximum;

            var wrapper = new Wrapper
            {
                _callback = callback
            };

            IListener listener = new QueueListener(Convert(queue),
                poisonQueue: Convert(poisonQueue),
                triggerExecutor: wrapper,
                exceptionHandler: _exceptionHandler,
                loggerFactory: _loggerFactory,
                sharedWatcher: _sharedWatcher,
                queueOptions: _queueOptions,
                queueProcessorFactory: _queueProcessorFactory,
                functionDescriptor: new FunctionDescriptor { Id = SharedLoadBalancerQueueListenerFunctionId },
                maxPollingInterval: maxPollingInterval);

            return listener;
        }

        // $$$ cleanup
        private class Wrapper : ITriggerExecutor<CloudQueueMessage>
        {
            public Func<string, CancellationToken, Task<FunctionResult>> _callback;

            public Task<FunctionResult> ExecuteAsync(CloudQueueMessage value, CancellationToken cancellationToken)
            {
                return _callback(value.AsString, cancellationToken);
            }
        }
    }
}
