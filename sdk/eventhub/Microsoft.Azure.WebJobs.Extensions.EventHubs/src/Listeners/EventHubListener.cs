// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Processor;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    internal sealed class EventHubListener : IListener, IEventProcessorFactory, IScaleMonitorProvider
    {
        private readonly ITriggeredFunctionExecutor _executor;
        private readonly EventProcessorHost _eventProcessorHost;
        private readonly bool _singleDispatch;
        private readonly BlobsCheckpointStore _checkpointStore;
        private readonly EventHubOptions _options;
        private readonly ILogger _logger;

        private Lazy<EventHubsScaleMonitor> _scaleMonitor;

        public EventHubListener(
            string functionId,
            ITriggeredFunctionExecutor executor,
            EventProcessorHost eventProcessorHost,
            bool singleDispatch,
            IEventHubConsumerClient consumerClient,
            BlobsCheckpointStore checkpointStore,
            EventHubOptions options,
            ILogger logger)
        {
            _logger = logger;
            _executor = executor;
            _eventProcessorHost = eventProcessorHost;
            _singleDispatch = singleDispatch;
            _checkpointStore = checkpointStore;
            _options = options;

            _scaleMonitor = new Lazy<EventHubsScaleMonitor>(
                () => new EventHubsScaleMonitor(
                    functionId,
                    consumerClient,
                    checkpointStore,
                    _logger));
        }

        /// <summary>
        /// Cancel any in progress listen operation.
        /// </summary>
        void IListener.Cancel()
        {
            StopAsync(CancellationToken.None).Wait();
        }

        void IDisposable.Dispose()
        {
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _checkpointStore.CreateIfNotExistsAsync(cancellationToken).ConfigureAwait(false);
            await _eventProcessorHost.StartProcessingAsync(this, _checkpointStore, cancellationToken).ConfigureAwait(false);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _eventProcessorHost.StopProcessingAsync(cancellationToken).ConfigureAwait(false);
        }

        IEventProcessor IEventProcessorFactory.CreateEventProcessor()
        {
            return new EventProcessor(_options, _executor, _logger, _singleDispatch);
        }

        public IScaleMonitor GetMonitor()
        {
            return _scaleMonitor.Value;
        }

        // We get a new instance each time Start() is called.
        // We'll get a listener per partition - so they can potentialy run in parallel even on a single machine.
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

            public async Task ProcessEventsAsync(EventProcessorHostPartition context, IEnumerable<EventData> messages)
            {
                var events = messages.ToArray();

                var triggerInput = new EventHubTriggerInput
                {
                    Events = events,
                    PartitionContext = context
                };

                TriggeredFunctionData input = null;
                if (_singleDispatch)
                {
                    // Single dispatch
                    int eventCount = triggerInput.Events.Length;
                    List<Task> invocationTasks = new List<Task>();
                    for (int i = 0; i < eventCount; i++)
                    {
                        if (_cts.IsCancellationRequested)
                        {
                            break;
                        }

                        EventHubTriggerInput eventHubTriggerInput = triggerInput.GetSingleEventTriggerInput(i);
                        input = new TriggeredFunctionData
                        {
                            TriggerValue = eventHubTriggerInput,
                            TriggerDetails = eventHubTriggerInput.GetTriggerDetails(context)
                        };

                        Task task = _executor.TryExecuteAsync(input, _cts.Token);
                        invocationTasks.Add(task);
                    }

                    // Drain the whole batch before taking more work
                    if (invocationTasks.Count > 0)
                    {
                        await Task.WhenAll(invocationTasks).ConfigureAwait(false);
                    }
                }
                else
                {
                    // Batch dispatch
                    input = new TriggeredFunctionData
                    {
                        TriggerValue = triggerInput,
                        TriggerDetails = triggerInput.GetTriggerDetails(context)
                    };

                    await _executor.TryExecuteAsync(input, _cts.Token).ConfigureAwait(false);
                }

                // Checkpoint if we processed any events.
                // Don't checkpoint if no events. This can reset the sequence counter to 0.
                // Note: we intentionally checkpoint the batch regardless of function
                // success/failure. EventHub doesn't support any sort "poison event" model,
                // so that is the responsibility of the user's function currently. E.g.
                // the function should have try/catch handling around all event processing
                // code, and capture/log/persist failed events, since they won't be retried.
                if (events.Any())
                {
                    await CheckpointAsync(events.Last(), context).ConfigureAwait(false);
                }
            }

            private async Task CheckpointAsync(EventData checkpointEvent, EventProcessorHostPartition context)
            {
                bool checkpointed = false;
                if (_batchCheckpointFrequency == 1)
                {
                    await context.CheckpointAsync(checkpointEvent).ConfigureAwait(false);
                    checkpointed = true;
                }
                else
                {
                    // only checkpoint every N batches
                    if (++_batchCounter >= _batchCheckpointFrequency)
                    {
                        _batchCounter = 0;
                        await context.CheckpointAsync(checkpointEvent).ConfigureAwait(false);
                        checkpointed = true;
                    }
                }
                if (checkpointed)
                {
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
                        WritePropertyIfNotNull(writer, "lastEnqueuedOffset", context.LastEnqueuedEventProperties.Value.Offset?.ToString(CultureInfo.InvariantCulture));
                        WritePropertyIfNotNull(writer, "lastSequenceNumber", context.LastEnqueuedEventProperties.Value.SequenceNumber?.ToString(CultureInfo.InvariantCulture));
                        WritePropertyIfNotNull(writer, "lastEnqueuedTimeUtc", context.LastEnqueuedEventProperties.Value.EnqueuedTime?.ToString("o", CultureInfo.InvariantCulture));
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