// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Listeners
{
    internal class QueueScalerProvider : IScaleMonitorProvider, ITargetScalerProvider
    {
        private readonly TriggerMetadata _triggerMetadata;
        private readonly IOptions<QueuesOptions> _options;
        private readonly ILoggerFactory _loggerFactory;
        private readonly QueueMetadata _queueMetadata;
        private readonly QueueClient _queueClient;

        public QueueScalerProvider(IServiceProvider serviceProvider, TriggerMetadata triggerMetadata)
        {
            AzureComponentFactory azureComponentFactory = null;
            if ((triggerMetadata.Properties != null) && (triggerMetadata.Properties.TryGetValue(nameof(AzureComponentFactory), out object value)))
            {
                azureComponentFactory = value as AzureComponentFactory;
            }
            else
            {
                azureComponentFactory = serviceProvider.GetService<AzureComponentFactory>();
            }

            _triggerMetadata = triggerMetadata;
            _loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            _queueMetadata = JsonConvert.DeserializeObject<QueueMetadata>(_triggerMetadata.Metadata.ToString());
            _queueMetadata.ResolveProperties(serviceProvider.GetService<INameResolver>());
            _options = serviceProvider.GetService<IOptions<QueuesOptions>>();

            QueueServiceClientProvider queueServiceClientProvider = new QueueServiceClientProvider(
                serviceProvider.GetService<IConfiguration>(),
                azureComponentFactory,
                serviceProvider.GetService<AzureEventSourceLogForwarder>(),
                _options,
                _loggerFactory,
                _loggerFactory.CreateLogger<QueueServiceClient>(),
                serviceProvider.GetService<IQueueProcessorFactory>(),
                new SharedQueueWatcher());

            QueueServiceClient serviceClient = queueServiceClientProvider.Get(_queueMetadata.Connection, serviceProvider.GetService<INameResolver>());
            _queueClient = serviceClient.GetQueueClient(_queueMetadata.QueueName);
        }

        public IScaleMonitor GetMonitor()
        {
            return new QueueScaleMonitor(
                _triggerMetadata.FunctionName,
                _queueClient,
                _loggerFactory);
        }

        public ITargetScaler GetTargetScaler()
        {
            return new QueueTargetScaler(
                _triggerMetadata.FunctionName,
                _queueClient,
                _options.Value,
                _loggerFactory);
        }

        internal class QueueMetadata
        {
            [JsonProperty]
            public string Connection { get; set; }

            [JsonProperty]
            public string QueueName { get; set; }

            public void NormalizeQueueName()
            {
                QueueName = QueueName.ToLowerInvariant();
            }

            public void ResolveProperties(INameResolver resolver)
            {
                if (resolver != null)
                {
                    QueueName = resolver.ResolveWholeString(QueueName);
                }

                NormalizeQueueName();
            }
        }
    }
}
