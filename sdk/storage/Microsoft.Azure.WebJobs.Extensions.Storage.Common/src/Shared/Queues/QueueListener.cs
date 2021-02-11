// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
    internal sealed partial class QueueListener : IListener, ITaskSeriesCommand, INotificationCommand, IScaleMonitor<QueueTriggerMetrics>
    {
        private const int NumberOfSamplesToConsider = 5;

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
        private readonly ScaleMonitorDescriptor _scaleMonitorDescriptor;
        private readonly CancellationTokenSource _shutdownCancellationTokenSource;

        private bool? _queueExists;
        private bool _foundMessageSinceLastDelay;
        private bool _disposed;
        private TaskCompletionSource<object> _stopWaitingTaskSource;

        // for mock testing only
        internal QueueListener()
        {
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
            string functionId = null,
            TimeSpan? maxPollingInterval = null)
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

            _scaleMonitorDescriptor = new ScaleMonitorDescriptor($"{_functionId}-QueueTrigger-{_queue.Name}".ToLower(CultureInfo.InvariantCulture));
            _shutdownCancellationTokenSource = new CancellationTokenSource();
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
            return Task.FromResult(0);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            using (cancellationToken.Register(() => _shutdownCancellationTokenSource.Cancel()))
            {
                ThrowIfDisposed();
                _timer.Cancel();
                await Task.WhenAll(_processing).ConfigureAwait(false);
                await _timer.StopAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _timer.Dispose();
                _shutdownCancellationTokenSource.Dispose();
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
                        sw = Stopwatch.StartNew();

                        Response<QueueMessage[]> response = await _queue.ReceiveMessagesAsync(_queueProcessor.QueuesOptions.BatchSize, _visibilityTimeout, cancellationToken).ConfigureAwait(false);
                        batch = response.Value;

                        int count = batch?.Length ?? -1;
                        Logger.GetMessages(_logger, _functionDescriptor.LogName, _queue.Name, response.GetRawResponse().ClientRequestId, count, sw.ElapsedMilliseconds);
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

        private TaskSeriesCommandResult CreateSucceededResult()
        {
            Task wait = WaitForNewBatchThreshold();
            return new TaskSeriesCommandResult(wait);
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
                if (!await _queueProcessor.BeginProcessingMessageAsync(message, cancellationToken).ConfigureAwait(false))
                {
                    return;
                }

                FunctionResult result = null;
                Action<UpdateReceipt> onUpdateReceipt = updateReceipt => { message = message.Update(updateReceipt); };
                using (ITaskSeriesTimer timer = CreateUpdateMessageVisibilityTimer(_queue, message, visibilityTimeout, _exceptionHandler, onUpdateReceipt))
                {
                    timer.Start();

                    result = await _triggerExecutor.ExecuteAsync(message, cancellationToken).ConfigureAwait(false);

                    await timer.StopAsync(cancellationToken).ConfigureAwait(false);
                }

                // Use a different cancellation token for shutdown to allow graceful shutdown.
                // Specifically, don't cancel the completion or update of the message itself during graceful shutdown.
                // Only cancel completion or update of the message if a non-graceful shutdown is requested via _shutdownCancellationTokenSource.
                await _queueProcessor.CompleteProcessingMessageAsync(message, result, _shutdownCancellationTokenSource.Token).ConfigureAwait(false);
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
                EventHandler<PoisonMessageEventArgs> poisonMessageEventHandler = (object sender, PoisonMessageEventArgs e) =>
                {
                    sharedWatcher.Notify(e.PoisonQueue.Name);
                };
                queueProcessor.MessageAddedToPoisonQueue += poisonMessageEventHandler;
            }
        }

        public ScaleMonitorDescriptor Descriptor
        {
            get
            {
                return _scaleMonitorDescriptor;
            }
        }

        async Task<ScaleMetrics> IScaleMonitor.GetMetricsAsync()
        {
            return await GetMetricsAsync().ConfigureAwait(false);
        }

        public async Task<QueueTriggerMetrics> GetMetricsAsync()
        {
            int queueLength = 0;
            TimeSpan queueTime = TimeSpan.Zero;

            try
            {
                QueueProperties queueProperties = await _queue.GetPropertiesAsync().ConfigureAwait(false);
                queueLength = queueProperties.ApproximateMessagesCount;

                if (queueLength > 0)
                {
                    PeekedMessage message = (await _queue.PeekMessagesAsync(1).ConfigureAwait(false)).Value.FirstOrDefault();
                    if (message != null)
                    {
                        if (message.InsertedOn.HasValue)
                        {
                            queueTime = DateTime.UtcNow.Subtract(message.InsertedOn.Value.DateTime);
                        }
                    }
                    else
                    {
                        // ApproximateMessageCount often returns a stale value,
                        // especially when the queue is empty.
                        queueLength = 0;
                    }
                }
            }
            catch (RequestFailedException ex)
            {
                if (ex.IsNotFoundQueueNotFound() ||
                    ex.IsConflictQueueBeingDeletedOrDisabled() ||
                    ex.IsServerSideError())
                {
                    // ignore transient errors, and return default metrics
                    // E.g. if the queue doesn't exist, we'll return a zero queue length
                    // and scale in
                    _logger.LogWarning($"Error querying for queue scale status: {ex.Message}");
                }
            }

            return new QueueTriggerMetrics
            {
                QueueLength = queueLength,
                QueueTime = queueTime,
                Timestamp = DateTime.UtcNow
            };
        }

        ScaleStatus IScaleMonitor.GetScaleStatus(ScaleStatusContext context)
        {
            return GetScaleStatusCore(context.WorkerCount, context.Metrics?.Cast<QueueTriggerMetrics>().ToArray());
        }

        public ScaleStatus GetScaleStatus(ScaleStatusContext<QueueTriggerMetrics> context)
        {
            return GetScaleStatusCore(context.WorkerCount, context.Metrics?.ToArray());
        }

        private ScaleStatus GetScaleStatusCore(int workerCount, QueueTriggerMetrics[] metrics)
        {
            ScaleStatus status = new ScaleStatus
            {
                Vote = ScaleVote.None
            };

            // verify we have enough samples to make a scale decision.
            if (metrics == null || (metrics.Length < NumberOfSamplesToConsider))
            {
                return status;
            }

            // Maintain a minimum ratio of 1 worker per 1,000 queue messages.
            long latestQueueLength = metrics.Last().QueueLength;
            if (latestQueueLength > workerCount * 1000)
            {
                status.Vote = ScaleVote.ScaleOut;
                _logger.LogInformation($"QueueLength ({latestQueueLength}) > workerCount ({workerCount}) * 1,000");
                _logger.LogInformation($"Length of queue ({_queue.Name}, {latestQueueLength}) is too high relative to the number of instances ({workerCount}).");
                return status;
            }

            // Check to see if the queue has been empty for a while.
            bool queueIsIdle = metrics.All(p => p.QueueLength == 0);
            if (queueIsIdle)
            {
                status.Vote = ScaleVote.ScaleIn;
                _logger.LogInformation($"Queue '{_queue.Name}' is idle");
                return status;
            }

            // Samples are in chronological order. Check for a continuous increase in time or length.
            // If detected, this results in an automatic scale out.
            if (metrics[0].QueueLength > 0)
            {
                bool queueLengthIncreasing =
                IsTrueForLastN(
                    metrics,
                    NumberOfSamplesToConsider,
                    (prev, next) => prev.QueueLength < next.QueueLength);
                if (queueLengthIncreasing)
                {
                    status.Vote = ScaleVote.ScaleOut;
                    _logger.LogInformation($"Queue length is increasing for '{_queue.Name}'");
                    return status;
                }
            }

            if (metrics[0].QueueTime > TimeSpan.Zero && metrics[0].QueueTime < metrics[NumberOfSamplesToConsider - 1].QueueTime)
            {
                bool queueTimeIncreasing =
                    IsTrueForLastN(
                        metrics,
                        NumberOfSamplesToConsider,
                        (prev, next) => prev.QueueTime <= next.QueueTime);
                if (queueTimeIncreasing)
                {
                    status.Vote = ScaleVote.ScaleOut;
                    _logger.LogInformation($"Queue time is increasing for '{_queue.Name}'");
                    return status;
                }
            }

            bool queueLengthDecreasing =
                IsTrueForLastN(
                    metrics,
                    NumberOfSamplesToConsider,
                    (prev, next) => prev.QueueLength > next.QueueLength);
            if (queueLengthDecreasing)
            {
                status.Vote = ScaleVote.ScaleIn;
                _logger.LogInformation($"Queue length is decreasing for '{_queue.Name}'");
                return status;
            }

            bool queueTimeDecreasing = IsTrueForLastN(
                metrics,
                NumberOfSamplesToConsider,
                (prev, next) => prev.QueueTime > next.QueueTime);
            if (queueTimeDecreasing)
            {
                status.Vote = ScaleVote.ScaleIn;
                _logger.LogInformation($"Queue time is decreasing for '{_queue.Name}'");
                return status;
            }

            _logger.LogInformation($"Queue '{_queue.Name}' is steady");

            return status;
        }

        private static bool IsTrueForLastN(IList<QueueTriggerMetrics> samples, int count, Func<QueueTriggerMetrics, QueueTriggerMetrics, bool> predicate)
        {
            Debug.Assert(count > 1, "count must be greater than 1.");
            Debug.Assert(count <= samples.Count, "count must be less than or equal to the list size.");

            // Walks through the list from left to right starting at len(samples) - count.
            for (int i = samples.Count - count; i < samples.Count - 1; i++)
            {
                if (!predicate(samples[i], samples[i + 1]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
