// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure;
using Azure.Storage.Queues;
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
        private readonly string _queueName;
        private readonly QueueMetricsProvider _queueMetricsProvider;
        private readonly TargetScalerDescriptor _targetScalerDescriptor;
        private QueuesOptions _options;
        private readonly ILogger _logger;

        // internal mock testing only
        internal QueueTargetScaler()
        {
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TargetScalerDescriptor TargetScalerDescriptor => _targetScalerDescriptor;

        internal QueueTargetScaler(string functionId, QueueClient queueClient, QueuesOptions options, ILoggerFactory loggerFactory)
        {
            _functionId = functionId;
            _queueName = queueClient.Name;
            _queueMetricsProvider = new QueueMetricsProvider(queueClient, loggerFactory);
            _targetScalerDescriptor = new TargetScalerDescriptor(functionId);
            _options = options;
            _logger = loggerFactory.CreateLogger<QueueTargetScaler>();
        }

        /// <summary>
        /// Makes a target scale decision based on most recent metrics for the specified queue.
        /// </summary>
        /// <param name="context">The TargetScalerContext, which contains the InstanceConcurrency, or the targetMetric used in target based scaling.</param>
        /// <returns>Returns a TargetScalerResult with a TargetWorkerCount.</returns>
        public async Task<TargetScalerResult> GetScaleResultAsync(TargetScalerContext context)
        {
            int queueLength = await _queueMetricsProvider.GetQueueLengthAsync().ConfigureAwait(false);
            return GetScaleResultInternal(context, queueLength);
        }

        internal TargetScalerResult GetScaleResultInternal(TargetScalerContext context, int queueLength)
        {
            int concurrency = !context.InstanceConcurrency.HasValue ? _options.BatchSize + _options.NewBatchThreshold : context.InstanceConcurrency.Value;

            if (concurrency < 0)
            {
                throw new ArgumentOutOfRangeException($"Concurrency value='{concurrency}' used for target based scale must be > 0.");
            }

            int targetWorkerCount = (int)Math.Ceiling(queueLength / (decimal)concurrency);
            string details = $"Target worker count for function '{_functionId}' is '{targetWorkerCount}' (QueueName='{_queueName}', QueueLength ='{queueLength}', Concurrency='{concurrency}').";
            _logger.LogFunctionScaleVote(_functionId, targetWorkerCount, queueLength, concurrency, details);

            return new TargetScalerResult
            {
                TargetWorkerCount = targetWorkerCount
            };
        }
    }
}
