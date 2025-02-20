// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Listeners
{
    internal class ServiceBusTargetScaler : ITargetScaler
    {
        private readonly string _functionId;
        private readonly ServiceBusMetricsProvider _serviceBusMetricsProvider;
        private readonly ServiceBusOptions _options;
        private readonly bool _isSessionsEnabled;
        private readonly bool _singleDispatch;
        private readonly TargetScalerDescriptor _targetScalerDescriptor;
        private readonly string _entityPath;
        private readonly ILogger _logger;

        public ServiceBusTargetScaler(
            string functionId,
            string entityPath,
            ServiceBusEntityType entityType,
            Lazy<ServiceBusReceiver> receiver,
            Lazy<ServiceBusAdministrationClient> administrationClient,
            ServiceBusOptions options,
            bool isSessionsEnabled,
            bool singleDispatch,
            ILoggerFactory loggerFactory
            )
        {
            _functionId = functionId;
            _serviceBusMetricsProvider = new ServiceBusMetricsProvider(entityPath, entityType, receiver, administrationClient, loggerFactory);
            _entityPath = entityPath;
            _targetScalerDescriptor = new TargetScalerDescriptor(functionId);
            _logger = loggerFactory.CreateLogger<ServiceBusTargetScaler>();
            _options = options;
            _singleDispatch = singleDispatch;
            _isSessionsEnabled = isSessionsEnabled;
        }

        public TargetScalerDescriptor TargetScalerDescriptor => _targetScalerDescriptor;

        public async Task<TargetScalerResult> GetScaleResultAsync(TargetScalerContext context)
        {
            try
            {
                long activeMessageCount = await _serviceBusMetricsProvider.GetMessageCountAsync().ConfigureAwait(false);
                return GetScaleResultInternal(context, activeMessageCount);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new NotSupportedException("Target scaler is not supported.", ex);
            }
        }

        internal TargetScalerResult GetScaleResultInternal(TargetScalerContext context, long messageCount)
        {
            int concurrency;

            if (!context.InstanceConcurrency.HasValue)
            {
                if (!_singleDispatch)
                {
                    concurrency = _options.MaxMessageBatchSize;
                }
                else
                {
                    if (_isSessionsEnabled)
                    {
                        concurrency = _options.MaxConcurrentSessions;
                    }
                    else
                    {
                        concurrency = _options.MaxConcurrentCalls;
                    }
                }
            }
            else
            {
                concurrency = context.InstanceConcurrency.Value;
            }

            if (concurrency < 1)
            {
                throw new ArgumentOutOfRangeException($"Unexpected concurrency='{concurrency}' - the value must be > 0.");
            }

            int targetWorkerCount;

            try
            {
                checked
                {
                    targetWorkerCount = (int)Math.Ceiling(messageCount / (decimal)concurrency);
                }
            }
            catch (OverflowException)
            {
                targetWorkerCount = int.MaxValue;
            }

            _logger.LogInformation($"Target worker count for function '{_functionId}' is '{targetWorkerCount}' (EntityPath='{_entityPath}', MessageCount ='{messageCount}', Concurrency='{concurrency}').");

            return new TargetScalerResult
            {
                TargetWorkerCount = targetWorkerCount
            };
        }
    }
}
