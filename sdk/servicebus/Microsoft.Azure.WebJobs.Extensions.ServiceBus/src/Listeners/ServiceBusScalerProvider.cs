// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.ServiceBus.Listeners
{
    internal class ServiceBusScalerProvider : IScaleMonitorProvider, ITargetScalerProvider
    {
        private readonly ServiceBusScaleMonitor _scaleMonitor;
        private readonly ServiceBusTargetScaler _targetScaler;

        public ServiceBusScalerProvider(IServiceProvider serviceProvider, TriggerMetadata triggerMetadata)
        {
            AzureComponentFactory azureComponentFactory;
            if ((triggerMetadata.Properties != null) && (triggerMetadata.Properties.TryGetValue(nameof(AzureComponentFactory), out object value)))
            {
                // Managed identity is used for the connection - use the AzureComponentFactory passed from the ScaleConttroller.
                azureComponentFactory = value as AzureComponentFactory;
            }
            else
            {
                // Connection string is used for the connection - use the deafult AzureComponentFactory.
                azureComponentFactory = serviceProvider.GetService<AzureComponentFactory>();
            }

            IConfiguration configuration = serviceProvider.GetService<IConfiguration>();
            MessagingProvider messagingProvider = serviceProvider.GetService<MessagingProvider>();
            AzureEventSourceLogForwarder logForwarder = serviceProvider.GetService<AzureEventSourceLogForwarder>();
            IOptions<ServiceBusOptions> options = serviceProvider.GetService<IOptions<ServiceBusOptions>>();
            ILoggerFactory loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            ServiceBusMetadata serviceBusMetadata = JsonConvert.DeserializeObject<ServiceBusMetadata>(triggerMetadata.Metadata.ToString());
            serviceBusMetadata.ResolveProperties(serviceProvider.GetService<INameResolver>());
            ServiceBusClientFactory factory = new ServiceBusClientFactory(configuration, azureComponentFactory, messagingProvider, logForwarder, options);
            ServiceBusAdministrationClient serviceBusAdminClient = factory.CreateAdministrationClient(serviceBusMetadata.Connection);
            ServiceBusClient serviceBusClient = factory.CreateClientFromSetting(serviceBusMetadata.Connection);
            ServiceBusReceiver serviceBusReceiver = !string.IsNullOrEmpty(serviceBusMetadata.QueueName) ? serviceBusClient.CreateReceiver(serviceBusMetadata.QueueName)
            : serviceBusClient.CreateReceiver(serviceBusMetadata.TopicName, serviceBusMetadata.SubscriptionName);

            _scaleMonitor = new ServiceBusScaleMonitor(
                triggerMetadata.FunctionName,
                serviceBusReceiver.EntityPath,
                !string.IsNullOrEmpty(serviceBusMetadata.QueueName) ? ServiceBusEntityType.Queue : ServiceBusEntityType.Topic,
                new Lazy<ServiceBusReceiver>(() => serviceBusReceiver),
                new Lazy<ServiceBusAdministrationClient>(() => serviceBusAdminClient),
                loggerFactory);

            _targetScaler = new ServiceBusTargetScaler(
                triggerMetadata.FunctionName,
                serviceBusReceiver.EntityPath,
                !string.IsNullOrEmpty(serviceBusMetadata.QueueName) ? ServiceBusEntityType.Queue : ServiceBusEntityType.Topic,
                new Lazy<ServiceBusReceiver>(() => serviceBusReceiver),
                new Lazy<ServiceBusAdministrationClient>(() => serviceBusAdminClient),
                options.Value,
                serviceBusMetadata.IsSessionsEnabled,
                !string.Equals(serviceBusMetadata.Cardinality, "many", StringComparison.InvariantCultureIgnoreCase),
                loggerFactory);
        }

        public IScaleMonitor GetMonitor()
        {
            return _scaleMonitor;
        }

        public ITargetScaler GetTargetScaler()
        {
            return _targetScaler;
        }

        internal class ServiceBusMetadata
        {
            [JsonProperty]
            public string Type { get; set; }

            [JsonProperty]
            public string Connection { get; set; }

            [JsonProperty]
            public string QueueName { get; set; }

            [JsonProperty]
            public string TopicName { get; set; }

            [JsonProperty]
            public string SubscriptionName { get; set; }

            [JsonProperty]
            public bool IsSessionsEnabled { get; set; }

            [JsonProperty]
            public string Cardinality { get; set; }

            public void ResolveProperties(INameResolver resolver)
            {
                if (resolver != null)
                {
                    QueueName = resolver.ResolveWholeString(QueueName);
                    TopicName = resolver.ResolveWholeString(TopicName);
                    SubscriptionName = resolver.ResolveWholeString(SubscriptionName);
                }
            }
        }
    }
}
