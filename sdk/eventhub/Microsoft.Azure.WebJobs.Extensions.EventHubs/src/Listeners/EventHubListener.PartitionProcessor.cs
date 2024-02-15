// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Processor;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Core.Diagnostics;
using System.Diagnostics;

namespace Microsoft.Azure.WebJobs.EventHubs.Listeners
{
    internal sealed partial class EventHubListener
    {
        /// <summary>
        /// A new instance of this class is created each time a partition is initialized. One <see cref="PartitionProcessor"/> is created
        /// per partition, so this class is built to manage the processor function invocations for one partition. Each of the partition processors
        /// will run in parallel on a single machine.
        /// </summary>
        internal class PartitionProcessor : IEventProcessor, IDisposable
        {
            private readonly ITriggeredFunctionExecutor _executor;
            private readonly bool _singleDispatch;
            private readonly ILogger _logger;
            private readonly int _batchCheckpointFrequency;
            private int _batchCounter;
            private bool _firstFunctionInvocation;
            private bool _minimumBatchesEnabled;
            private bool _disposed;
            private TimeSpan _maxWaitTime;
            private ValueStopwatch _currentCycle;
            private EventProcessorHostPartition _mostRecentPartitionContext;
            private Task _cachedEventsBackgroundTask;
            private CancellationTokenSource _cachedEventsBackgroundTaskCts;
            private SemaphoreSlim _cachedEventsGuard;
            private readonly CancellationToken _functionExecutionToken;
            private readonly CancellationTokenSource _ownershipLostTokenSource;

            /// <summary>
            /// When we have a minimum batch size greater than 1, this class manages caching events.
            /// </summary>
            internal PartitionProcessorEventsManager CachedEventsManager { get; }

            public PartitionProcessor(EventHubOptions options, ITriggeredFunctionExecutor executor, ILogger logger, bool singleDispatch, CancellationToken functionExecutionToken)
            {
                _executor = executor;
                _singleDispatch = singleDispatch;
                _batchCheckpointFrequency = options.BatchCheckpointFrequency;
                _logger = logger;
                _firstFunctionInvocation = true;
                _maxWaitTime = options.MaxWaitTime;
                _minimumBatchesEnabled = options.MinEventBatchSize > 1; // 1 is the default
                _functionExecutionToken = functionExecutionToken;
                _ownershipLostTokenSource = new CancellationTokenSource();

                // Events are only cached when building a batch of minimum size.
                if (_minimumBatchesEnabled)
                {
                    _cachedEventsGuard = new SemaphoreSlim(1, 1);
                    CachedEventsManager = new PartitionProcessorEventsManager(maxBatchSize: options.MaxEventBatchSize, minBatchSize: options.MinEventBatchSize);
                }
            }

            public Task CloseAsync(EventProcessorHostPartition context, ProcessingStoppedReason reason)
            {
                if (reason == ProcessingStoppedReason.OwnershipLost)
                {
                    _ownershipLostTokenSource.Cancel();
                }

                // clear the cached events
                CachedEventsManager?.ClearEventCache();

                _logger.LogDebug(GetOperationDetails(context, $"CloseAsync, {reason}"));
                return Task.CompletedTask;
            }

            public Task OpenAsync(EventProcessorHostPartition context)
            {
                _logger.LogDebug(GetOperationDetails(context, "OpenAsync"));
                return Task.CompletedTask;
            }

            public Task ProcessErrorAsync(EventProcessorHostPartition context, Exception error)
            {
                string errorDetails = $"Processing error (Partition Id: '{context.PartitionId}', Owner: '{context.Owner}', EventHubPath: '{context.EventHubPath}').";

                Utility.LogException(error, errorDetails, _logger);

                return Task.CompletedTask;
            }

            /// <summary>
            /// This method is called by the <see cref="EventProcessorHost"/>.
            /// </summary>
            /// <param name="context">The partition information for this partition.</param>
            /// <param name="messages">The events to process.</param>
            /// <returns></returns>
            public async Task ProcessEventsAsync(EventProcessorHostPartition context, IEnumerable<EventData> messages)
            {
                using CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(_functionExecutionToken, _ownershipLostTokenSource.Token);
                _mostRecentPartitionContext = context;
                var events = messages.ToArray();
                EventData eventToCheckpoint = null;
                var acquiredSemaphore = false;

                int eventCount = events.Length;

                if (_singleDispatch)
                {
                    UpdateCheckpointContext(events, context);

                    var triggerInput = new EventHubTriggerInput
                    {
                        Events = events,
                        ProcessorPartition = context
                    };

                    // Single dispatch
                    for (int i = 0; i < eventCount; i++)
                    {
                        if (linkedCts.Token.IsCancellationRequested)
                        {
                            break;
                        }

                        EventHubTriggerInput eventHubTriggerInput = triggerInput.GetSingleEventTriggerInput(i);
                        TriggeredFunctionData input = new()
                        {
                            TriggerValue = eventHubTriggerInput,
                            TriggerDetails = eventHubTriggerInput.GetTriggerDetails(context)
                        };

                        await _executor.TryExecuteAsync(input, linkedCts.Token).ConfigureAwait(false);
                        _firstFunctionInvocation = false;
                        eventToCheckpoint = events[i];
                    }
                }
                else
                {
                    // Batch dispatch

                    if (_minimumBatchesEnabled)
                    {
                        try
                        {
                            // Try to acquire the semaphore. This protects the cached events.
                            if (!_cachedEventsGuard.Wait(0, linkedCts.Token))
                            {
                                // This will throw if the cancellation token is canceled.
                                await _cachedEventsGuard.WaitAsync(linkedCts.Token).ConfigureAwait(false);
                            }
                            acquiredSemaphore = true;

                            // Try to get a batch
                            // of events from the cache.
                            var triggerEvents = CachedEventsManager.TryGetBatchofEventsWithCached(events, false);

                            // If events were returned that means we hit the threshold for the minimum batch size, so
                            // invoke the function.
                            if (triggerEvents.Length > 0)
                            {
                                var details = GetOperationDetails(context, "EventsDispatched");
                                _logger.LogDebug($"Partition Processor received events and is attempting to invoke function ({details})");

                                UpdateCheckpointContext(triggerEvents, context);
                                await TriggerExecute(triggerEvents, context, linkedCts.Token).ConfigureAwait(false);
                                eventToCheckpoint = triggerEvents.Last();

                                // If there is a background timer task, cancel it and dispose of the cancellation token. If there
                                // are still events in the cache, the timer will be restarted.
                                _cachedEventsBackgroundTaskCts?.Cancel();
                                _cachedEventsBackgroundTaskCts?.Dispose();
                                _cachedEventsBackgroundTaskCts = null;
                            }
                            else
                            {
                                var details = GetOperationDetails(context, "EventsDispatched");
                                _logger.LogDebug($"Partition Processor received events but has less than MinBatchSize total events. Waiting for more events ({details})");
                            }

                            if (_cachedEventsBackgroundTaskCts == null && CachedEventsManager.HasCachedEvents)
                            {
                                // If there are events waiting to be processed, and no background task running, start a monitoring cycle.
                                // Don't reference linkedCts in the class level background task, as it will be disposed when the method goes out of scope.
                                _cachedEventsBackgroundTaskCts = CancellationTokenSource.CreateLinkedTokenSource(_functionExecutionToken, _ownershipLostTokenSource.Token);
                                _cachedEventsBackgroundTask = MonitorCachedEvents(context.ProcessorHost.GetLastReadCheckpoint(context.PartitionId)?.LastModified, _cachedEventsBackgroundTaskCts);
                            }
                        }
                        finally
                        {
                            if (acquiredSemaphore)
                            {
                                _cachedEventsGuard.Release();
                            }
                        }
                    }
                    else
                    {
                        UpdateCheckpointContext(events, context);
                        await TriggerExecute(events, context, linkedCts.Token).ConfigureAwait(false);
                        eventToCheckpoint = events.LastOrDefault();
                    }

                    // If total events is less than the batch size, leave them in the stored events list
                    // and wait to send until we receive enough events or total max wait time has passed.
                }

                // Checkpoint if we processed any events and cancellation has not been signaled.
                // Don't checkpoint if no events. This can reset the sequence counter to 0.
                // Note: we intentionally checkpoint the batch regardless of function
                // success/failure. EventHub doesn't support any sort "poison event" model,
                // so that is the responsibility of the user's function currently. E.g.
                // the function should have try/catch handling around all event processing
                // code, and capture/log/persist failed events, since they won't be retried.
                // Don't checkpoint if cancellation has been requested as this can lead to data loss,
                // since the user may not actually process the event.

                if (eventToCheckpoint != null &&
                    // IMPORTANT - explicitly check each token to avoid data loss as the linkedCts is not canceled atomically when each of the
                    // sources are canceled.
                    !_functionExecutionToken.IsCancellationRequested && !_ownershipLostTokenSource.IsCancellationRequested)
                {
                    await CheckpointAsync(eventToCheckpoint, context).ConfigureAwait(false);
                }
            }

            private async Task TriggerExecute(EventData[] events, EventProcessorHostPartition context, CancellationToken cancellationToken)
            {
                var triggerInput = new EventHubTriggerInput
                {
                    Events = events,
                    ProcessorPartition = context
                };

                // Batch dispatch
                TriggeredFunctionData input = new()
                {
                    TriggerValue = triggerInput,
                    TriggerDetails = triggerInput.GetTriggerDetails(context)
                };

                await _executor.TryExecuteAsync(input, cancellationToken).ConfigureAwait(false);
                _firstFunctionInvocation = false;
            }

            private async Task MonitorCachedEvents(DateTimeOffset? lastCheckpointTime, CancellationTokenSource backgroundCancellationTokenSource)
            {
                Debug.Assert(_minimumBatchesEnabled, "Monitoring of cached events should only take place when minimum batches are enabled.");

                var acquiredSemaphore = false;
                var adjustedMaxWaitTime = GetAdjustedMaxWaitTime(_maxWaitTime, lastCheckpointTime, _firstFunctionInvocation);

                try
                {
                    _currentCycle = ValueStopwatch.StartNew();

                    // Wait max wait time after starting this task before checking the number of events.
                    while (_currentCycle.GetElapsedTime() < adjustedMaxWaitTime && !backgroundCancellationTokenSource.Token.IsCancellationRequested)
                    {
                        var remainingTime = GetRemainingTime(_currentCycle.GetElapsedTime(), adjustedMaxWaitTime);
                        await Task.Delay(remainingTime, backgroundCancellationTokenSource.Token).ConfigureAwait(false);
                    }

                    if (!_cachedEventsGuard.Wait(0, backgroundCancellationTokenSource.Token))
                    {
                        await _cachedEventsGuard.WaitAsync(backgroundCancellationTokenSource.Token).ConfigureAwait(false);
                    }
                    acquiredSemaphore = true;

                    // Since max wait time has passed, pull all events out of the cache and invoke the function on it.
                    var triggerEvents = CachedEventsManager.TryGetBatchofEventsWithCached(allowPartialBatch: true);

                    if (triggerEvents.Length > 0)
                    {
                        var details = GetOperationDetails(_mostRecentPartitionContext, "MaxWaitTimeElapsed");
                        _logger.LogDebug($"Partition Processor has waited MaxWaitTime since last invocation and is attempting to invoke function on all held events ({details})");

                        UpdateCheckpointContext(triggerEvents, _mostRecentPartitionContext);
                        await TriggerExecute(triggerEvents, _mostRecentPartitionContext, backgroundCancellationTokenSource.Token).ConfigureAwait(false);
                        if (!backgroundCancellationTokenSource.Token.IsCancellationRequested)
                        {
                            await CheckpointAsync(triggerEvents.Last(), _mostRecentPartitionContext).ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        var details = GetOperationDetails(_mostRecentPartitionContext, "MaxWaitTimeElapsed");
                        _logger.LogDebug($"Partition Processor has waited MaxWaitTime since last invocation but there are no events still being held ({details})");
                    }

                    // After one wait cycle, cancel and null the background task cancellation token source. It can be assumed that there will never be more than the
                    // minimum batch size number of events in the cache. The monitoring cycle will be restarted by the process events handler if needed.
                    backgroundCancellationTokenSource.Cancel();
                    backgroundCancellationTokenSource.Dispose();
                    _cachedEventsBackgroundTaskCts = null;
                }
                catch (TaskCanceledException)
                {
                    // If this monitoring cycle was canceled, then null the background task cancellation token source and dispose the cancellation token.
                    backgroundCancellationTokenSource.Dispose();
                    _cachedEventsBackgroundTaskCts = null;
                }
                finally
                {
                    if (acquiredSemaphore)
                    {
                        _cachedEventsGuard.Release();
                    }
                }
            }

            private static TimeSpan GetAdjustedMaxWaitTime(TimeSpan configuredMaxWaitTime, DateTimeOffset? lastCheckpointTime, bool firstInvocation)
            {
                // If this is not the first invocation of the function for this partition then use the configured wait time.
                if (!firstInvocation)
                {
                    return configuredMaxWaitTime;
                }

                // If there was no checkpoint found, then it is safer to dispatch a partial batch for the
                // first invocation than assume no ownership changes are taking place.
                if (!lastCheckpointTime.HasValue)
                {
                    return TimeSpan.Zero;
                }

                var timeSinceLastCheckpoint = DateTimeOffset.UtcNow.Subtract(lastCheckpointTime.Value);

                // If the checkpoint was last recorded less that the configured wait time ago, then we can
                // assume that was when a batch was last dispatched.  Adjust the wait time to reduce the configured
                // wait time and try to honor the configured interval.  In the worst case where checkpoints are written
                // infrequently, we'll dispatch a partial batch more quickly for the first iteration.
                if (timeSinceLastCheckpoint < configuredMaxWaitTime)
                {
                    return configuredMaxWaitTime.Subtract(timeSinceLastCheckpoint);
                }

                // If the checkpoint was last recorded longer than the configured wait time ago, ownership
                // of the partition likely migrated and the function was not invoked on the expected schedule.
                // Dispatch any available events immediately, as the wait time is presumed to have already elapsed.
                if (timeSinceLastCheckpoint >= configuredMaxWaitTime)
                {
                    return TimeSpan.Zero;
                }

                return configuredMaxWaitTime;
            }

            private TimeSpan GetRemainingTime(TimeSpan elapsed, TimeSpan maxWaitTime)
            {
                if (maxWaitTime == Timeout.InfiniteTimeSpan)
                {
                    return TimeSpan.Zero;
                }

                if ((maxWaitTime == TimeSpan.Zero) || (elapsed == TimeSpan.Zero))
                {
                    return maxWaitTime;
                }

                if (elapsed >= maxWaitTime)
                {
                    return TimeSpan.Zero;
                }

                return TimeSpan.FromMilliseconds(maxWaitTime.TotalMilliseconds - elapsed.TotalMilliseconds);
            }

            private void UpdateCheckpointContext(EventData[] events, EventProcessorHostPartition context)
            {
                _batchCounter++;
                var isCheckpointingAfterInvocation = false;

                if (events != null && events.Length > 0)
                {
                    if (_batchCheckpointFrequency == 1)
                    {
                        isCheckpointingAfterInvocation = true;
                    }
                    else
                    {
                        // only checkpoint every N batches
                        if (_batchCounter >= _batchCheckpointFrequency)
                        {
                            isCheckpointingAfterInvocation = true;
                        }
                    }
                }

                context.PartitionContext.IsCheckpointingAfterInvocation = isCheckpointingAfterInvocation;
            }

            private async Task CheckpointAsync(EventData checkpointEvent, EventProcessorHostPartition context)
            {
                if (context.PartitionContext.IsCheckpointingAfterInvocation)
                {
                    await context.CheckpointAsync(checkpointEvent).ConfigureAwait(false);

                    _batchCounter = 0;

                    _logger.LogDebug(GetOperationDetails(context, "CheckpointAsync"));
                }
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        _cachedEventsBackgroundTaskCts?.Dispose();
                        _cachedEventsGuard?.Dispose();
                    }

                    _disposed = true;
                }
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            private static string GetOperationDetails(EventProcessorHostPartition context, string operation)
            {
                StringWriter sw = new StringWriter();
                using JsonTextWriter writer = new JsonTextWriter(sw) { Formatting = Formatting.None };

                writer.WriteStartObject();
                WritePropertyIfNotNull(writer, "operation", operation);
                writer.WritePropertyName("partitionContext");
                writer.WriteStartObject();
                WritePropertyIfNotNull(writer, "partitionId", context.PartitionId);
                WritePropertyIfNotNull(writer, "owner", context.Owner);
                WritePropertyIfNotNull(writer, "eventHubPath", context.EventHubPath);
                writer.WriteEndObject();

                // Log partition checkpoint info
                if (context.Checkpoint != null)
                {
                    // leave the property name as lease for backcompat with T1
                    writer.WritePropertyName("lease");
                    writer.WriteStartObject();
                    WritePropertyIfNotNull(writer, "offset", context.Checkpoint.Value.Offset.ToString(CultureInfo.InvariantCulture));
                    WritePropertyIfNotNull(writer, "sequenceNumber", context.Checkpoint.Value.SequenceNumber.ToString(CultureInfo.InvariantCulture));
                    writer.WriteEndObject();
                }

                // Log RuntimeInformation if EnableReceiverRuntimeMetric is enabled
                if (context.LastEnqueuedEventProperties != null)
                {
                    writer.WritePropertyName("runtimeInformation");
                    writer.WriteStartObject();
                    WritePropertyIfNotNull(writer, "lastEnqueuedOffset", context.LastEnqueuedEventProperties.Offset?.ToString(CultureInfo.InvariantCulture));
                    WritePropertyIfNotNull(writer, "lastSequenceNumber", context.LastEnqueuedEventProperties.SequenceNumber?.ToString(CultureInfo.InvariantCulture));
                    WritePropertyIfNotNull(writer, "lastEnqueuedTimeUtc", context.LastEnqueuedEventProperties.EnqueuedTime?.ToString("o", CultureInfo.InvariantCulture));
                    writer.WriteEndObject();
                }
                writer.WriteEndObject();

                return sw.ToString();
            }

            private static void WritePropertyIfNotNull(JsonTextWriter writer, string propertyName, string propertyValue)
            {
                if (propertyValue != null)
                {
                    writer.WritePropertyName(propertyName);
                    writer.WriteValue(propertyValue);
                }
            }
        }
    }
}