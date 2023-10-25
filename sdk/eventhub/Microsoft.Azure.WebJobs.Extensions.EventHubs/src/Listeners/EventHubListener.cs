// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Primitives;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Extensions.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.EventHubs.Listeners
{
    internal sealed partial class EventHubListener : IListener, IEventProcessorFactory, IScaleMonitorProvider, ITargetScalerProvider
    {
        private readonly ITriggeredFunctionExecutor _executor;
        private readonly EventProcessorHost _eventProcessorHost;
        private readonly bool _singleDispatch;
        private readonly BlobCheckpointStoreInternal _checkpointStore;
        private readonly EventHubOptions _options;

        private Lazy<EventHubsScaleMonitor> _scaleMonitor;
        private Lazy<EventHubsTargetScaler> _targetScaler;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;
        private string _details;
        private CancellationTokenSource _functionExecutionCancellationTokenSource;
        private readonly IDrainModeManager _drainModeManager;
        private volatile bool _disposed;

        public EventHubListener(
            string functionId,
            ITriggeredFunctionExecutor executor,
            EventProcessorHost eventProcessorHost,
            bool singleDispatch,
            IEventHubConsumerClient consumerClient,
            BlobCheckpointStoreInternal checkpointStore,
            EventHubOptions options,
            ILoggerFactory loggerFactory,
            IDrainModeManager drainModeManager)
        {
            _loggerFactory = loggerFactory;
            _executor = executor;
            _eventProcessorHost = eventProcessorHost;
            _singleDispatch = singleDispatch;
            _checkpointStore = checkpointStore;
            _options = options;
            _logger = _loggerFactory.CreateLogger<EventHubListener>();
            _functionExecutionCancellationTokenSource = new CancellationTokenSource();
            _drainModeManager = drainModeManager;

            EventHubMetricsProvider metricsProvider = new EventHubMetricsProvider(functionId, consumerClient, checkpointStore, _loggerFactory.CreateLogger<EventHubMetricsProvider>());

            _scaleMonitor = new Lazy<EventHubsScaleMonitor>(
                () => new EventHubsScaleMonitor(
                    functionId,
                    consumerClient,
                    checkpointStore,
                    _loggerFactory.CreateLogger<EventHubsScaleMonitor>()));

            _targetScaler = new Lazy<EventHubsTargetScaler>(
                () => new EventHubsTargetScaler(
                    functionId,
                    consumerClient,
                    options,
                    metricsProvider,
                    _loggerFactory.CreateLogger<EventHubsTargetScaler>()));

            _details = $"'namespace='{eventProcessorHost?.FullyQualifiedNamespace}', eventHub='{eventProcessorHost?.EventHubName}', " +
                $"consumerGroup='{eventProcessorHost?.ConsumerGroup}', functionId='{functionId}', singleDispatch='{singleDispatch}'";
        }

        /// <summary>
        /// Cancel should be called prior to Dispose. We just validate that we are not already disposed.
        /// This is consistent with the Service Bus listener behavior.
        /// </summary>
        void IListener.Cancel()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(IListener));
            }
        }

        void IDisposable.Dispose()
        {
            _functionExecutionCancellationTokenSource.Cancel();

#pragma warning disable AZC0102
            StopAsync(CancellationToken.None).GetAwaiter().GetResult();
#pragma warning restore AZC0102

            // No need to dispose the _disposingCancellationTokenSource since we don't create it as a linked token and
            // it won't use a timer, so the Dispose method is essentially a no-op. The downside to disposing it is that
            // any customers who are trying to use it to cancel their own operations would get an ObjectDisposedException.
            _disposed = true;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _checkpointStore.CreateIfNotExistsAsync(cancellationToken).ConfigureAwait(false);
            await _eventProcessorHost.StartProcessingAsync(this, _checkpointStore, cancellationToken).ConfigureAwait(false);

            _logger.LogDebug($"EventHub listener started ({_details})");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (!_drainModeManager.IsDrainModeEnabled)
            {
                _functionExecutionCancellationTokenSource.Cancel();
            }

            await _eventProcessorHost.StopProcessingAsync(cancellationToken).ConfigureAwait(false);

            _logger.LogDebug($"EventHub listener stopped ({_details})");
        }

        IEventProcessor IEventProcessorFactory.CreatePartitionProcessor()
        {
            return new PartitionProcessor(_options, _executor, _loggerFactory.CreateLogger<PartitionProcessor>(), _singleDispatch, _functionExecutionCancellationTokenSource.Token);
        }

        public IScaleMonitor GetMonitor()
        {
            return _scaleMonitor.Value;
        }

        public ITargetScaler GetTargetScaler()
        {
            return _targetScaler.Value;
        }
    }
}