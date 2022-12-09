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
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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

            public EventProcessor(EventHubOptions options, ITriggeredFunctionExecutor executor, ILogger logger, bool singleDispatch)
            {
                _executor = executor;
                _singleDispatch = singleDispatch;
                _batchCheckpointFrequency = options.BatchCheckpointFrequency;
                _logger = logger;
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
                    var events = messages.ToArray();
                    EventData eventToCheckpoint = null;

                    var triggerInput = new EventHubTriggerInput
                    {
                        Events = events,
                        ProcessorPartition = context
                    };

                    UpdateCheckpointContext(events, context);

                    if (_singleDispatch)
                    {
                        // Single dispatch
                        int eventCount = triggerInput.Events.Length;

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
                        TriggeredFunctionData input = new TriggeredFunctionData
                        {
                            TriggerValue = triggerInput,
                            TriggerDetails = triggerInput.GetTriggerDetails(context)
                        };

                        await _executor.TryExecuteAsync(input, linkedCts.Token).ConfigureAwait(false);
                        eventToCheckpoint = events.LastOrDefault();
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