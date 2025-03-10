// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Timers;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners
{
    internal sealed partial class QueueListener : IListener, ITaskSeriesCommand, INotificationCommand, ITargetScalerProvider, IScaleMonitorProvider
    {
        private readonly ITaskSeriesTimer _timer;
        private readonly IDelayStrategy _delayStrategy;
        private readonly QueueClient _queue;
        private readonly QueueClient _poisonQueue;
        private readonly ITriggerExecutor<QueueMessage> _triggerExecutor;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly IMessageEnqueuedWatcher _sharedWatcher;
        private readonly List<Task> _processing = new List<Task>();
        private readonly object _stopWaitingTaskSourceLock = new object();
        private readonly QueuesOptions _queueOptions;
        private readonly QueueProcessor _queueProcessor;
        private readonly TimeSpan _visibilityTimeout;
        private readonly ILogger<QueueListener> _logger;
        private readonly FunctionDescriptor _functionDescriptor;
        private readonly string _functionId;
        private readonly CancellationTokenSource _shutdownCancellationTokenSource;
        private readonly CancellationTokenSource _executionCancellationTokenSource;
        private readonly Lazy<QueueTargetScaler> _targetScaler;
        private readonly Lazy<QueueScaleMonitor> _scaleMonitor;
        private readonly IDrainModeManager _drainModeManager;

        private bool? _queueExists;
        private bool _foundMessageSinceLastDelay;
        private bool _disposed;
        private TaskCompletionSource<object> _stopWaitingTaskSource;
        private ConcurrencyManager _concurrencyManager;
        private string _details;

        // for mock testing only
        internal QueueListener()
        {
            _scaleMonitor = new Lazy<QueueScaleMonitor>(() => new QueueScaleMonitor());
            _targetScaler = new Lazy<QueueTargetScaler>(() => new QueueTargetScaler());
        }

        public QueueListener(QueueClient queue,
            QueueClient poisonQueue,
            ITriggerExecutor<QueueMessage> triggerExecutor,
            IWebJobsExceptionHandler exceptionHandler,
            ILoggerFactory loggerFactory,
            SharedQueueWatcher sharedWatcher,
            QueuesOptions queueOptions,
            QueueProcessor queueProcessor,
            FunctionDescriptor functionDescriptor,
            ConcurrencyManager concurrencyManager = null,
            string functionId = null,
            TimeSpan? maxPollingInterval = null,
            IDrainModeManager drainModeManager = null)
        {
            if (queueOptions == null)
            {
                throw new ArgumentNullException(nameof(queueOptions));
            }

            if (queueProcessor == null)
            {
                throw new ArgumentNullException(nameof(queueProcessor));
            }

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            if (queueOptions.BatchSize <= 0)
            {
                throw new ArgumentException("BatchSize must be greater than zero.");
            }

            if (queueOptions.MaxDequeueCount <= 0)
            {
                throw new ArgumentException("MaxDequeueCount must be greater than zero.");
            }

            _timer = new TaskSeriesTimer(this, exceptionHandler, Task.Delay(0));
            _queue = queue;
            _poisonQueue = poisonQueue;
            _triggerExecutor = triggerExecutor;
            _exceptionHandler = exceptionHandler;
            _queueOptions = queueOptions;
            _logger = loggerFactory.CreateLogger<QueueListener>();
            _functionDescriptor = functionDescriptor ?? throw new ArgumentNullException(nameof(functionDescriptor));
            _functionId = functionId ?? _functionDescriptor.Id;
            _details = $"queue name='{_queue.Name}', storage account name='{_queue.AccountName}'";

            // if the function runs longer than this, the invisibility will be updated
            // on a timer periodically for the duration of the function execution
            _visibilityTimeout = TimeSpan.FromMinutes(10);

            if (sharedWatcher != null)
            {
                // Call Notify whenever a function adds a message to this queue.
                sharedWatcher.Register(queue.Name, this);
                _sharedWatcher = sharedWatcher;
            }

            _queueProcessor = queueProcessor;

            TimeSpan maximumInterval = _queueProcessor.QueuesOptions.MaxPollingInterval;
            if (maxPollingInterval.HasValue && maximumInterval > maxPollingInterval.Value)
            {
                // enforce the maximum polling interval if specified
                maximumInterval = maxPollingInterval.Value;
            }

            _delayStrategy = new RandomizedExponentialBackoffStrategy(QueuePollingIntervals.Minimum, maximumInterval);

            _shutdownCancellationTokenSource = new CancellationTokenSource();
            _executionCancellationTokenSource = new CancellationTokenSource();

            _concurrencyManager = concurrencyManager;

            _targetScaler = new Lazy<QueueTargetScaler>(
                    () => new QueueTargetScaler(
                        _functionId,
                        queue,
                        queueOptions,
                        loggerFactory
                        ));

            _scaleMonitor = new Lazy<QueueScaleMonitor>(() => new QueueScaleMonitor(_functionId, _queue, loggerFactory));
            _drainModeManager = drainModeManager;
        }

        // for testing
        internal TimeSpan MinimumVisibilityRenewalInterval { get; set; } = TimeSpan.FromMinutes(1);

        public void Cancel()
        {
            ThrowIfDisposed();
            _timer.Cancel();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();
            _timer.Start();
            _logger.LogDebug($"Storage queue listener started ({_details})");
            return Task.FromResult(0);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (!_drainModeManager?.IsDrainModeEnabled ?? true)
            {
                // Cancel the execution token when drain mode is not enabled or drain mode manager is not set.
                _executionCancellationTokenSource.Cancel();
            }

            using (cancellationToken.Register(() => _shutdownCancellationTokenSource.Cancel()))
            {
                ThrowIfDisposed();
                _timer.Cancel();
                await Task.WhenAll(_processing).ConfigureAwait(false);
                await _timer.StopAsync(cancellationToken).ConfigureAwait(false);
                _logger.LogDebug($"Storage queue listener stopped ({_details})");
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _timer.Dispose();
                _shutdownCancellationTokenSource.Cancel();
                _executionCancellationTokenSource.Cancel();
                _shutdownCancellationTokenSource.Dispose();
                _executionCancellationTokenSource.Dispose();
                _disposed = true;
            }
        }

        public async Task<TaskSeriesCommandResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            lock (_stopWaitingTaskSourceLock)
            {
                if (_stopWaitingTaskSource != null)
                {
                    _stopWaitingTaskSource.TrySetResult(null);
                }

                _stopWaitingTaskSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            }

            QueueMessage[] batch = null;
            string clientRequestId = Guid.NewGuid().ToString();
            Stopwatch sw = null;
            using (HttpPipeline.CreateClientRequestIdScope(clientRequestId))
            {
                try
                {
                    if (!_queueExists.HasValue || !_queueExists.Value)
                    {
                        // Before querying the queue, determine if it exists. This
                        // avoids generating unecessary exceptions (which pollute AppInsights logs)
                        // Once we establish the queue exists, we won't do the existence
                        // check anymore (steady state).
                        // However the queue can always be deleted from underneath us, in which case
                        // we need to recheck. That is handled below.
                        _queueExists = await _queue.ExistsAsync(cancellationToken).ConfigureAwait(false);
                    }

                    if (_queueExists.Value)
                    {
                        int numMessagesToReceive = GetMessageReceiveCount();
                        if (numMessagesToReceive == 0)
                        {
                            // We want the next invocation to run right away to ensure we
                            // quickly fetch to our max degree of concurrency.
                            return CreateDelayResult(TimeSpan.Zero);
                        }

                        sw = Stopwatch.StartNew();
                        using (CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _shutdownCancellationTokenSource.Token))
                        {
                            Response<QueueMessage[]> response = await _queue.ReceiveMessagesAsync(numMessagesToReceive, _visibilityTimeout, linkedCts.Token).ConfigureAwait(false);
                            batch = response.Value;

                            int count = batch?.Length ?? -1;
                            Logger.GetMessages(_logger, _functionDescriptor.LogName, _queue.Name, response.GetRawResponse().ClientRequestId, count, sw.ElapsedMilliseconds);
                        }
                    }
                }
                catch (RequestFailedException exception)
                {
                    // if we get ANY errors querying the queue reset our existence check
                    // doing this on all errors rather than trying to special case not
                    // found, because correctness is the most important thing here
                    _queueExists = null;

                    if (exception.IsNotFoundQueueNotFound() ||
                        exception.IsConflictQueueBeingDeletedOrDisabled() ||
                        exception.IsServerSideError())
                    {
                        long pollLatency = sw?.ElapsedMilliseconds ?? -1;
                        Logger.HandlingStorageException(_logger, _functionDescriptor.LogName, _queue.Name, clientRequestId, pollLatency, exception);

                        // Back off when no message is available, or when
                        // transient errors occur
                        return CreateBackoffResult();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            if (batch == null)
            {
                return CreateBackoffResult();
            }

            bool foundMessage = false;
            foreach (var message in batch)
            {
                if (message == null)
                {
                    continue;
                }

                foundMessage = true;

                // Note: Capturing the cancellationToken passed here on a task that continues to run is a slight abuse
                // of the cancellation token contract. However, the timer implementation would not dispose of the
                // cancellation token source until it has stopped and perhaps also disposed, and we wait for all
                // outstanding tasks to complete before stopping the timer.
                Task task = ProcessMessageAsync(message, _visibilityTimeout, cancellationToken);

                // Having both WaitForNewBatchThreshold and this method mutate _processing is safe because the timer
                // contract is serial: it only calls ExecuteAsync once the wait expires (and the wait won't expire until
                // WaitForNewBatchThreshold has finished mutating _processing).
                _processing.Add(task);
            }

            // Back off when no message was found.
            if (!foundMessage)
            {
                return CreateBackoffResult();
            }

            _foundMessageSinceLastDelay = true;
            return CreateSucceededResult();
        }

        public void Notify()
        {
            lock (_stopWaitingTaskSourceLock)
            {
                if (_stopWaitingTaskSource != null)
                {
                    _stopWaitingTaskSource.TrySetResult(null);
                }
            }
        }

        internal int GetMessageReceiveCount()
        {
            int numMessagesToReceive = _queueProcessor.QueuesOptions.BatchSize;

            if (_concurrencyManager != null && _concurrencyManager.Enabled)
            {
                // When not using DC, WaitForNewBatchThreshold cleans up tasks as they complete.
                // When using DC we need to also do cleanup of completed tasks, particularly
                // before we use the count of pending tasks in the calculation below.
                var completedTasks = _processing.Where(p => p.IsCompleted).ToArray();
                foreach (var completedTask in completedTasks)
                {
                    _processing.Remove(completedTask);
                }

                // When DynamicConcurrency is enabled, we determine the number of messages to pull
                // based on the current degree of parallelism for this function and our pending invocation count.
                var concurrencyStatus = _concurrencyManager.GetStatus(_functionId);
                int availableInvocationCount = concurrencyStatus.GetAvailableInvocationCount(_processing.Count);
                numMessagesToReceive = Math.Min(availableInvocationCount, QueuesOptions.MaxBatchSize);
            }

            return numMessagesToReceive;
        }

        private Task CreateDelayWithNotificationTask()
        {
            TimeSpan nextDelay = _delayStrategy.GetNextDelay(executionSucceeded: _foundMessageSinceLastDelay);
            Task normalDelay = Task.Delay(nextDelay);
            _foundMessageSinceLastDelay = false;

            Logger.BackoffDelay(_logger, _functionDescriptor.LogName, _queue.Name, nextDelay.TotalMilliseconds);

            return Task.WhenAny(_stopWaitingTaskSource.Task, normalDelay);
        }

        private TaskSeriesCommandResult CreateBackoffResult()
        {
            return new TaskSeriesCommandResult(wait: CreateDelayWithNotificationTask());
        }

        private TaskSeriesCommandResult CreateDelayResult(TimeSpan delay)
        {
            Task aggregateTask = Task.WhenAny(_stopWaitingTaskSource.Task, Task.Delay(delay));

            return new TaskSeriesCommandResult(wait: aggregateTask);
        }

        private TaskSeriesCommandResult CreateSucceededResult()
        {
            if (_concurrencyManager != null && _concurrencyManager.Enabled)
            {
                // We want the next invocation to run right away to ensure we
                // quickly fetch to our max degree of concurrency.
                return CreateDelayResult(TimeSpan.Zero);
            }
            else
            {
                Task wait = WaitForNewBatchThreshold();
                return new TaskSeriesCommandResult(wait);
            }
        }

        private async Task WaitForNewBatchThreshold()
        {
            while (_processing.Count > _queueProcessor.QueuesOptions.NewBatchThreshold)
            {
                Task processed = await Task.WhenAny(_processing).ConfigureAwait(false);
                _processing.Remove(processed);
            }
        }

        internal async Task ProcessMessageAsync(QueueMessage message, TimeSpan visibilityTimeout, CancellationToken cancellationToken)
        {
            try
            {
                using (CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _shutdownCancellationTokenSource.Token))
                {
                    if (!await _queueProcessor.BeginProcessingMessageAsync(message, linkedCts.Token).ConfigureAwait(false))
                    {
                        return;
                    }

                    FunctionResult result = null;
                    Action<UpdateReceipt> onUpdateReceipt = updateReceipt => { message = message.Update(updateReceipt); };
                    using (ITaskSeriesTimer timer = CreateUpdateMessageVisibilityTimer(_queue, message, visibilityTimeout, _exceptionHandler, onUpdateReceipt))
                    {
                        timer.Start();

                        result = await _triggerExecutor.ExecuteAsync(message, _executionCancellationTokenSource.Token).ConfigureAwait(false);

                        await timer.StopAsync(linkedCts.Token).ConfigureAwait(false);
                    }

                    // Use a different cancellation token for shutdown to allow graceful shutdown.
                    // Specifically, don't cancel the completion or update of the message itself during graceful shutdown.
                    // Only cancel completion or update of the message if a non-graceful shutdown is requested via _shutdownCancellationTokenSource.
                    await _queueProcessor.CompleteProcessingMessageAsync(message, result, _shutdownCancellationTokenSource.Token).ConfigureAwait(false);
                }
            }
            catch (TaskCanceledException)
            {
                // Don't fail the top-level task when an inner task cancels.
            }
            catch (OperationCanceledException)
            {
                // Don't fail the top-level task when an inner task cancels.
            }
            catch (Exception exception)
            {
                // Immediately report any unhandled exception from this background task.
                // (Don't capture the exception as a fault of this Task; that would delay any exception reporting until
                // Stop is called, which might never happen.)
#pragma warning disable AZC0103 // Do not wait synchronously in asynchronous scope.
                _exceptionHandler.OnUnhandledExceptionAsync(ExceptionDispatchInfo.Capture(exception)).GetAwaiter().GetResult();
#pragma warning restore AZC0103 // Do not wait synchronously in asynchronous scope.
            }
        }

        private ITaskSeriesTimer CreateUpdateMessageVisibilityTimer(QueueClient queue,
            QueueMessage message, TimeSpan visibilityTimeout,
            IWebJobsExceptionHandler exceptionHandler, Action<UpdateReceipt> onUpdateReceipt)
        {
            // Update a message's visibility when it is halfway to expiring.
            TimeSpan normalUpdateInterval = new TimeSpan(visibilityTimeout.Ticks / 2);

            IDelayStrategy speedupStrategy = new LinearSpeedupStrategy(normalUpdateInterval, MinimumVisibilityRenewalInterval);
            ITaskSeriesCommand command = new UpdateQueueMessageVisibilityCommand(queue, message, visibilityTimeout, speedupStrategy, onUpdateReceipt);
            return new TaskSeriesTimer(command, exceptionHandler, Task.Delay(normalUpdateInterval));
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(null);
            }
        }

        internal static void RegisterSharedWatcherWithQueueProcessor(QueueProcessor queueProcessor, IMessageEnqueuedWatcher sharedWatcher)
        {
            if (sharedWatcher != null)
            {
                queueProcessor.MessageAddedToPoisonQueueAsync += (queueProcessor, e) =>
                {
                    sharedWatcher.Notify(e.PoisonQueue.Name);
                    return Task.CompletedTask;
                };
            }
        }

        public ITargetScaler GetTargetScaler()
        {
            return _targetScaler.Value;
        }

        public IScaleMonitor GetMonitor()
        {
            return _scaleMonitor.Value;
        }
    }
}
