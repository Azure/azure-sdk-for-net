// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Core.Diagnostics;
using Microsoft.Extensions.Azure;
using System.Text;
using Azure.Identity;
using Azure.Core;
using System.Diagnostics.Tracing;

namespace Microsoft.Azure.WebJobs.EventHubs.Listeners
{
    internal sealed class EventHubListener : IListener, IEventProcessorFactory, IScaleMonitorProvider
    {
        private readonly ITriggeredFunctionExecutor _executor;
        private readonly EventProcessorHost _eventProcessorHost;
        private readonly bool _singleDispatch;
        private readonly BlobCheckpointStoreInternal _checkpointStore;
        private readonly EventHubOptions _options;

        private Lazy<EventHubsScaleMonitor> _scaleMonitor;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;
        private string _details;

        public EventHubListener(
            string functionId,
            ITriggeredFunctionExecutor executor,
            EventProcessorHost eventProcessorHost,
            bool singleDispatch,
            IEventHubConsumerClient consumerClient,
            BlobCheckpointStoreInternal checkpointStore,
            EventHubOptions options,
            ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _executor = executor;
            _eventProcessorHost = eventProcessorHost;
            _singleDispatch = singleDispatch;
            _checkpointStore = checkpointStore;
            _options = options;
            _logger = _loggerFactory.CreateLogger<EventHubListener>();

            _scaleMonitor = new Lazy<EventHubsScaleMonitor>(
                () => new EventHubsScaleMonitor(
                    functionId,
                    consumerClient,
                    checkpointStore,
                    _loggerFactory.CreateLogger<EventHubsScaleMonitor>()));

            _details = $"'namespace='{eventProcessorHost?.FullyQualifiedNamespace}', eventHub='{eventProcessorHost?.EventHubName}', " +
                $"consumerGroup='{eventProcessorHost?.ConsumerGroup}', functionId='{functionId}', singleDispatch='{singleDispatch}'";
        }

        /// <summary>
        /// Cancel any in progress listen operation.
        /// </summary>
        void IListener.Cancel()
        {
#pragma warning disable AZC0102
            StopAsync(CancellationToken.None).GetAwaiter().GetResult();
#pragma warning restore AZC0102
        }

        void IDisposable.Dispose()
        {
#pragma warning disable AZC0102
            StopAsync(CancellationToken.None).GetAwaiter().GetResult();
#pragma warning restore AZC0102
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _checkpointStore.CreateIfNotExistsAsync(cancellationToken).ConfigureAwait(false);
            await _eventProcessorHost.StartProcessingAsync(this, _checkpointStore, cancellationToken).ConfigureAwait(false);

            _logger.LogDebug($"EventHub listener started ({_details})");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _eventProcessorHost.StopProcessingAsync(cancellationToken).ConfigureAwait(false);

            _logger.LogDebug($"EventHub listener stopped ({_details})");
        }

        IEventProcessor IEventProcessorFactory.CreateEventProcessor()
        {
            return new EventProcessor(_options, _executor, _loggerFactory.CreateLogger<EventProcessor>(), _singleDispatch);
        }

        public IScaleMonitor GetMonitor()
        {
            return _scaleMonitor.Value;
        }

        internal class EventProcessorStoredEventsManager : IDisposable
        {
            private ConcurrentDictionary<string, List<EventData>> _storedEvents;
            private SemaphoreSlim _storedEventsGuard;
            private int _maxBatchSize;
            private int _minBatchSize;

            public bool HasStoredEvents
            {
                get
                {
                    try
                    {
                        _storedEventsGuard.Wait();
                        return !_storedEvents.IsEmpty;
                    }
                    finally
                    {
                        _storedEventsGuard.Release();
                    }
                }
            }

            public EventProcessorStoredEventsManager(int maxBatchSize, int minBatchSize)
            {
                _storedEvents = new ConcurrentDictionary<string, List<EventData>>();
                _storedEventsGuard = new SemaphoreSlim(1, 1);
                _maxBatchSize = maxBatchSize;
                _minBatchSize = minBatchSize;
            }

            public EventData[] ProcessWithStoredEvents(EventProcessorHostPartition partitionContext, List<EventData> events = null, bool timerTrigger = false, CancellationToken cancellationToken = default)
            {
                Argument.AssertNotNull(partitionContext, nameof(partitionContext));
                try
                {
                    _storedEventsGuard.Wait(cancellationToken);
                    events ??= new List<EventData>();

                    var partitionId = partitionContext.PartitionId;

                    var numEventsToProcess = events.Count;
                    var storedEventsForPartition = _storedEvents.GetOrAdd(partitionId, new List<EventData>());
                    var storedEvents = storedEventsForPartition.Count;
                    var totalEvents = storedEvents + numEventsToProcess;
                    storedEventsForPartition.AddRange(events);

                    if (totalEvents < _minBatchSize && !timerTrigger)
                    {
                        return Array.Empty<EventData>();
                    }
                    else if (totalEvents > _maxBatchSize)
                    {
                        var eventsToAdd = storedEventsForPartition.Take(_maxBatchSize).ToArray();
                        storedEventsForPartition.RemoveRange(0, _maxBatchSize);

                        return eventsToAdd;
                    }
                    else
                    {
                        var eventArray = storedEventsForPartition.ToArray();
                        _storedEvents.Clear();
                        return eventArray;
                    }
                }
                finally
                {
                    _storedEventsGuard.Release();
                }
            }

            public void Dispose()
            {
                _storedEventsGuard?.Dispose();
            }
        }

        // We get a new instance each time Start() is called.
        // We'll get a listener per partition - so they can potentially run in parallel even on a single machine.
        internal class EventProcessor : IEventProcessor, IDisposable
        {
            private readonly ITriggeredFunctionExecutor _executor;
            private readonly bool _singleDispatch;
            private readonly ILogger _logger;
            private readonly CancellationTokenSource _cts = new CancellationTokenSource();
            private readonly int _batchCheckpointFrequency;
            private int _batchCounter;
            private bool _minimumBatchesEnabled;
            private bool _disposed;
            private EventProcessorStoredEventsManager _storedEventsManager;
            private Task _storedEventsBackgroundTask;
            private TimeSpan _maxWaitTime;
            private ValueStopwatch _currentCycle;
            private EventProcessorHostPartition _mostRecentPartitionContext;
            private CancellationTokenSource _storedEventsBackgroundTaskCts;

            public EventProcessor(EventHubOptions options, ITriggeredFunctionExecutor executor, ILogger logger, bool singleDispatch)
            {
                _executor = executor;
                _singleDispatch = singleDispatch;
                _batchCheckpointFrequency = options.BatchCheckpointFrequency;
                _logger = logger;
                _minimumBatchesEnabled = options.MinEventBatchSize > 0;
                _storedEventsManager = new EventProcessorStoredEventsManager(options.MaxEventBatchSize, options.MinEventBatchSize);
                _maxWaitTime = TimeSpan.FromSeconds(options.MaxWaitTime);
            }

            public Task CloseAsync(EventProcessorHostPartition context, ProcessingStoppedReason reason)
            {
                // signal cancellation for any in progress executions
                _cts.Cancel();

                _logger.LogDebug(GetOperationDetails(context, $"CloseAsync, {reason.ToString()}"));
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

            public async Task ProcessEventsAsync(EventProcessorHostPartition context, IEnumerable<EventData> messages, CancellationToken processingCancellationToken)
            {
                using (CancellationTokenSource linkedCts =
                        CancellationTokenSource.CreateLinkedTokenSource(_cts.Token, processingCancellationToken))
                {
                    _mostRecentPartitionContext = context;
                    var events = messages == null ? Array.Empty<EventData>() : messages.ToArray();
                    EventData eventToCheckpoint = null;

                    UpdateCheckpointContext(events, context);

                    int eventCount = events.Length;

                    if (_singleDispatch)
                    {
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
                            TriggeredFunctionData input = new TriggeredFunctionData
                            {
                                TriggerValue = eventHubTriggerInput,
                                TriggerDetails = eventHubTriggerInput.GetTriggerDetails(context)
                            };

                            await _executor.TryExecuteAsync(input, linkedCts.Token).ConfigureAwait(false);
                            eventToCheckpoint = events[i];
                        }
                    }
                    else
                    {
                        // Batch dispatch

                        if (_minimumBatchesEnabled)
                        {
                            var triggerEvents = _storedEventsManager.ProcessWithStoredEvents(context, messages.ToList(), false, linkedCts.Token);

                            if (triggerEvents.Length > 0)
                            {
                                await TriggerExecute(triggerEvents, context, linkedCts.Token).ConfigureAwait(false);
                                eventToCheckpoint = triggerEvents.Last();

                                if (_storedEventsBackgroundTask != null)
                                {
                                    // If there is a background timer task, cancel it and dispose of the cancellation token.
                                    _storedEventsBackgroundTaskCts.Cancel();
                                    _storedEventsBackgroundTaskCts.Dispose();
                                    _storedEventsBackgroundTaskCts = null;
                                }

                                if (_storedEventsManager.HasStoredEvents)
                                {
                                    // If there are events waiting to be processed, create a new linked cancellation token and start or restart the
                                    // timer on the newest stored events.
                                    _storedEventsBackgroundTaskCts = CancellationTokenSource.CreateLinkedTokenSource(_cts.Token, processingCancellationToken);
                                    _storedEventsBackgroundTask = MonitorStoredEvents(_storedEventsBackgroundTaskCts.Token);
                                }
                            }
                            else
                            {
                                if (_storedEventsManager.HasStoredEvents && _storedEventsBackgroundTask == null)
                                {
                                    // If we don't have enough events and the timer hasn't been started yet, start it.
                                    _storedEventsBackgroundTaskCts = CancellationTokenSource.CreateLinkedTokenSource(_cts.Token, processingCancellationToken);
                                    _storedEventsBackgroundTask = MonitorStoredEvents(_storedEventsBackgroundTaskCts.Token);
                                }
                            }
                        }
                        else
                        {
                            await TriggerExecute(events, context, _cts.Token).ConfigureAwait(false);
                            eventToCheckpoint = events.LastOrDefault();
                        }

                        // If total events is less than the batch size, leave them in the stored events list
                        // and wait to send until we receive enough events or total max wait time has passed.
                    }

                    // Checkpoint if we processed any events.
                    // Don't checkpoint if no events. This can reset the sequence counter to 0.
                    // Note: we intentionally checkpoint the batch regardless of function
                    // success/failure. EventHub doesn't support any sort "poison event" model,
                    // so that is the responsibility of the user's function currently. E.g.
                    // the function should have try/catch handling around all event processing
                    // code, and capture/log/persist failed events, since they won't be retried.
                    if (eventToCheckpoint != null)
                    {
                        await CheckpointAsync(eventToCheckpoint, context).ConfigureAwait(false);
                    }
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

                // The timer should reset upon invocation of the function
                _storedEventsBackgroundTask = null;
            }

            private async Task MonitorStoredEvents(CancellationToken cancellationToken)
            {
                try
                {
                    _currentCycle = ValueStopwatch.StartNew();
                    Console.WriteLine($"Starting a new monitoring cycle at {DateTime.Now}");

                    while (_currentCycle.GetElapsedTime() < _maxWaitTime)
                    {
                        var remainingTime = RemainingTime(_currentCycle.GetElapsedTime());
                        await Task.Delay(remainingTime, cancellationToken).ConfigureAwait(false);
                    }

                    var triggerEvents = _storedEventsManager.ProcessWithStoredEvents(_mostRecentPartitionContext, timerTrigger: true, cancellationToken: cancellationToken);

                    if (triggerEvents.Length > 0)
                    {
                        Console.WriteLine($"Invoking a timer trigger after {_currentCycle.GetElapsedTime()}");
                        await TriggerExecute(triggerEvents, _mostRecentPartitionContext, cancellationToken).ConfigureAwait(false);
                        await CheckpointAsync(triggerEvents.Last(), _mostRecentPartitionContext).ConfigureAwait(false);
                    }
                }
                catch (TaskCanceledException)
                {
                }
            }

            private TimeSpan RemainingTime(TimeSpan elapsed)
            {
                if ((_maxWaitTime == Timeout.InfiniteTimeSpan) || (_maxWaitTime == TimeSpan.Zero) || (elapsed == TimeSpan.Zero))
                {
                    return _maxWaitTime;
                }

                if (elapsed >= _maxWaitTime)
                {
                    return TimeSpan.Zero;
                }

                return TimeSpan.FromMilliseconds(_maxWaitTime.TotalMilliseconds - elapsed.TotalMilliseconds);
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
                        _cts.Dispose();
                        _storedEventsManager.Dispose();
                        _storedEventsBackgroundTaskCts.Dispose();
                    }

                    _disposed = true;
                }
            }

            public void Dispose()
            {
                Dispose(true);
            }

            private static string GetOperationDetails(EventProcessorHostPartition context, string operation)
            {
                StringWriter sw = new StringWriter();
                using (JsonTextWriter writer = new JsonTextWriter(sw) { Formatting = Formatting.None })
                {
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
                }
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