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
            private bool _disposed;
            private readonly int _minBatchSize;
            private readonly int _maxBatchSize;
            private readonly TimeSpan _maxWaitTime;
            private ConcurrentDictionary<string, List<EventData>> _storedEvents;
            private int _numStoredEvents;
            private ValueStopwatch _cycleWaitTime;
            private Task _backgroundWaitForEvents;

            public EventProcessor(EventHubOptions options, ITriggeredFunctionExecutor executor, ILogger logger, bool singleDispatch)
            {
                _executor = executor;
                _singleDispatch = singleDispatch;
                _batchCheckpointFrequency = options.BatchCheckpointFrequency;
                _logger = logger;
                _minBatchSize = options.MinEventBatchSize;
                _maxBatchSize = options.MaxEventBatchSize;
                _storedEvents = new ConcurrentDictionary<string, List<EventData>>();
                _numStoredEvents = 0;
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

                        var partitionID = context.PartitionId;

                        // If the total events is less than the minimum batch size, put all events in the stored events list and
                        // update numStoredEvents. Check on the timer and start one if it hasn't been started.

                        if (_numStoredEvents + eventCount < _minBatchSize)
                        {
                            _storedEvents.AddOrUpdate(partitionID, messages.ToList(),
                            (k, v) =>
                            {
                                v.AddRange(messages);
                                return v;
                            });
                            Interlocked.Add(ref _numStoredEvents, eventCount);

                            if (_backgroundWaitForEvents == null)
                            {
                                _backgroundWaitForEvents = WaitForMoreEventsOrTimer(processingCancellationToken);
                            }
                        }

                        if (_numStoredEvents > _minBatchSize && _numStoredEvents <= _maxBatchSize)
                        {
                            // If there are between minBatchSize and maxBatchSize events available, trigger the function
                            // with all events. Clear the stored events for this partition.

                            _storedEvents.TryRemove(partitionID, out var storedEvents);
                            storedEvents ??= new List<EventData>();
                            storedEvents.AddRange(messages);

                            Interlocked.Exchange(ref _numStoredEvents, 0);
                            await TriggerExecute(storedEvents.ToArray(), context, linkedCts).ConfigureAwait(false);

                            eventToCheckpoint = storedEvents.LastOrDefault();
                            // Cancel background event
                        }
                        else if (_numStoredEvents > _maxBatchSize)
                        {
                            // If there are more than maxBatchSize events available, trigger the function with maxBatchSize
                            // events and save the rest in storage.
                            _storedEvents.TryRemove(partitionID, out var triggerEvents);
                            Interlocked.Exchange(ref _numStoredEvents, 0);

                            var fullBatch = triggerEvents.Take(_maxBatchSize);
                            await TriggerExecute(fullBatch.ToArray(), context, linkedCts).ConfigureAwait(false);
                            eventToCheckpoint = fullBatch.LastOrDefault();

                            // cancel background event

                            // Store the overflow events. Update numStoredEvents.

                            triggerEvents.RemoveRange(0, _maxBatchSize - 1);
                            var numOverflow = triggerEvents.Count;
                            _storedEvents.TryAdd(partitionID, triggerEvents);
                            Interlocked.Exchange(ref _numStoredEvents, numOverflow);

                            if (_backgroundWaitForEvents == null)
                            {
                                _backgroundWaitForEvents = WaitForMoreEventsOrTimer(processingCancellationToken);
                            }
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

            private async Task WaitForMoreEventsOrTimer(CancellationToken cancellationToken)
            {
                _cycleWaitTime = ValueStopwatch.StartNew();

                while (!cancellationToken.IsCancellationRequested)
                {
                    var remaining = RemainingTime(_maxWaitTime, _cycleWaitTime.GetElapsedTime());
                    await Task.Delay(remaining, cancellationToken).ConfigureAwait(false);
                }
            }

            private static TimeSpan RemainingTime(TimeSpan waitTime, TimeSpan elapsed)
            {
                if ((waitTime == Timeout.InfiniteTimeSpan) || (waitTime == TimeSpan.Zero) || (elapsed == TimeSpan.Zero))
                {
                    return waitTime;
                }

                if (elapsed >= waitTime)
                {
                    return TimeSpan.Zero;
                }

                return TimeSpan.FromMilliseconds(waitTime.TotalMilliseconds - elapsed.TotalMilliseconds);
            }

            private async Task<EventData> ProcessStoredEventsOnly(EventProcessorHostPartition context, CancellationTokenSource cts)
            {
                EventData eventToCheckpoint = null;

                var hasStoredEventsPartition = _storedEvents.TryGetValue(context.PartitionId, out var storedEvents);
                if (hasStoredEventsPartition && storedEvents.Any())
                {
                    await TriggerExecute(storedEvents.ToArray(), context, cts).ConfigureAwait(false);
                    eventToCheckpoint = storedEvents.Last();
                }
                _numStoredEvents -= storedEvents.Count;
                storedEvents.Clear();

                return eventToCheckpoint;
            }

            private async Task TriggerExecute(EventData[] events, EventProcessorHostPartition context, CancellationTokenSource linkedCts)
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

                await _executor.TryExecuteAsync(input, linkedCts.Token).ConfigureAwait(false);
            }

            private void UpdateCheckpointContext(EventData[] events, EventProcessorHostPartition context)
            {
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
                        if (_batchCounter + 1 >= _batchCheckpointFrequency)
                        {
                            isCheckpointingAfterInvocation = true;
                        }
                    }
                }

                context.PartitionContext.IsCheckpointingAfterInvocation = isCheckpointingAfterInvocation;
            }

            private async Task CheckpointAsync(EventData checkpointEvent, EventProcessorHostPartition context)
            {
                _batchCounter++;

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