﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
using Newtonsoft.Json;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common
{
    // $$$ Review APIs
#pragma warning disable CS0618 // Type or member is obsolete
    internal class StorageLoadBalancerQueue : ILoadBalancerQueue
#pragma warning restore CS0618 // Type or member is obsolete
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

        private class QueueWriter<T> : IAsyncCollector<T>
        {
            private readonly StorageLoadBalancerQueue _parent;
            private readonly QueueClient _queue;

            public QueueWriter(StorageLoadBalancerQueue parent, QueueClient queue)
            {
                this._parent = parent;
                this._queue = queue;
            }


            public async Task AddAsync(T item, CancellationToken cancellationToken = default(CancellationToken))
            {
                string contents = JsonConvert.SerializeObject(
                    item,
                    JsonSerialization.Settings);

                await _queue.AddMessageAndCreateIfNotExistsAsync(contents, cancellationToken).ConfigureAwait(false);

                _parent._sharedWatcher.Notify(_queue.Name);
            }

            public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.CompletedTask;
            }
        }

        private QueueClient Convert(string queueMoniker)
        {
            // $$$ Review
            var account = _storageAccountProvider.Get(ConnectionStringNames.Dashboard);
            var queue = account.CreateQueueServiceClient().GetQueueClient(queueMoniker);
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
            TimeSpan maxPollingInterval = SharedQueuePollingIntervals.DefaultMaximum;

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
        private class Wrapper : ITriggerExecutor<QueueMessage>
        {
            public Func<string, CancellationToken, Task<FunctionResult>> _callback;

            public Task<FunctionResult> ExecuteAsync(QueueMessage value, CancellationToken cancellationToken)
            {
                return _callback(value.MessageText, cancellationToken);
            }
        }
    }
}
