// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners
{
    /// <summary>
    /// Provides queue length metrics for the <see cref="QueueTargetScaler"/>.
    /// </summary>
    internal sealed class QueueTargetScaler : ITargetScaler
    {
        private readonly string _functionId;
        private readonly QueueMetricsProvider _queueMetricsProvider;
        private readonly TargetScalerDescriptor _targetScalerDescriptor;
        private QueuesOptions _options;
        private readonly ILogger _logger;
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TargetScalerDescriptor TargetScalerDescriptor => _targetScalerDescriptor;
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="queueClient"></param>
        /// <param name="options"></param>
        /// <param name="loggerFactory"></param>
        public QueueTargetScaler(string functionId,QueueClient queueClient, QueuesOptions options, ILoggerFactory loggerFactory)
        {
            _functionId = functionId;
            _queueMetricsProvider = new QueueMetricsProvider(queueClient,loggerFactory);
            _targetScalerDescriptor = new TargetScalerDescriptor(functionId);
            _options = options;
            _logger = loggerFactory.CreateLogger<QueueTargetScaler>();
        }

        public async Task<TargetScalerResult> GetScaleResultAsync(TargetScalerContext context)
        {
            var metrics = await _queueMetricsProvider.GetMetricsAsync().ConfigureAwait(false);
            return GetScaleResultInternal(context, metrics);
        }

        internal TargetScalerResult GetScaleResultInternal(TargetScalerContext context, QueueTriggerMetrics metrics)
        {
            int concurrency = !context.InstanceConcurrency.HasValue ? _options.BatchSize : context.InstanceConcurrency.Value;

            int targetWorkerCount = (int)Math.Ceiling(metrics.QueueLength / (decimal)concurrency);

            _logger.LogInformation($"'Target worker count for function '{_functionId}' is '{targetWorkerCount}' (QueueLength ='{metrics.QueueLength}', Concurrecny='{concurrency}').");
            return new TargetScalerResult
            {
                TargetWorkerCount = targetWorkerCount
            };
        }
    }
}
