// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Extensions.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.EventHubs.Listeners
{
    internal class EventHubsScalerProvider : IScaleMonitorProvider, ITargetScalerProvider
    {
        private readonly IScaleMonitor _scaleMonitor;
        private readonly ITargetScaler _targetScaler;

        public EventHubsScalerProvider(IServiceProvider serviceProvider, TriggerMetadata triggerMetadata)
        {
            AzureComponentFactory azureComponentFactory;
            if ((triggerMetadata.Properties != null) && (triggerMetadata.Properties.TryGetValue(nameof(AzureComponentFactory), out object value)))
            {
                azureComponentFactory = value as AzureComponentFactory;
            }
            else
            {
                azureComponentFactory = serviceProvider.GetService<AzureComponentFactory>();
            }

            var configuration = serviceProvider.GetService<IConfiguration>();
            var hostComponentFactory = serviceProvider.GetService<AzureComponentFactory>();
            var logForwarder = serviceProvider.GetService<AzureEventSourceLogForwarder>();
            var options = serviceProvider.GetService<IOptions<EventHubOptions>>();
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            var checkpointClientProvider = new CheckpointClientProvider(configuration, hostComponentFactory, logForwarder, loggerFactory.CreateLogger<BlobServiceClient>());
            var nameResolver = serviceProvider.GetService<INameResolver>();
            var eventHubMetadata = JsonConvert.DeserializeObject<EventHubMetadata>(triggerMetadata.Metadata.ToString());
            var factory = new EventHubClientFactory(configuration, azureComponentFactory, options, nameResolver, logForwarder, checkpointClientProvider);
            eventHubMetadata.ResolveProperties(serviceProvider.GetService<INameResolver>());
            var eventHubConsumerClient = factory.GetEventHubConsumerClient(eventHubMetadata.EventHubName, eventHubMetadata.Connection, eventHubMetadata.ConsumerGroup);
            var checkpointStore = new BlobCheckpointStoreInternal(
                factory.GetCheckpointStoreClient(),
                triggerMetadata.FunctionName,
                loggerFactory.CreateLogger<BlobCheckpointStoreInternal>());
            var eventHubMerticsProvider = new EventHubMetricsProvider(
                triggerMetadata.FunctionName,
                eventHubConsumerClient,
                checkpointStore,
                loggerFactory.CreateLogger<EventHubMetricsProvider>()
                );

            _scaleMonitor = new EventHubsScaleMonitor(
                triggerMetadata.FunctionName,
                eventHubConsumerClient,
                checkpointStore,
                loggerFactory.CreateLogger<EventHubsScaleMonitor>());

            _targetScaler = new EventHubsTargetScaler(
                triggerMetadata.FunctionName,
                eventHubConsumerClient,
                options.Value,
                eventHubMerticsProvider,
                loggerFactory.CreateLogger<EventHubsScaleMonitor>());
        }

        public IScaleMonitor GetMonitor()
        {
            return _scaleMonitor;
        }

        public ITargetScaler GetTargetScaler()
        {
            return _targetScaler;
        }

        private class EventHubMetadata
        {
            [JsonProperty]
            public string EventHubName { get; set; }

            [JsonProperty]
            public string ConsumerGroup { get; set; }

            [JsonProperty]
            public string Connection { get; set; }

            public void ResolveProperties(INameResolver resolver)
            {
                if (resolver != null)
                {
                    EventHubName = resolver.ResolveWholeString(EventHubName);
                    ConsumerGroup = resolver.ResolveWholeString(ConsumerGroup);
                }
            }
        }
    }
}
