// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Extensions;
using Azure.Messaging.ServiceBus.Consumer;
using Azure.Messaging.ServiceBus.Producer;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    ///    The set of extensions to add the Event Hub client types to the clients builder
    /// </summary>
    public static class ServiceBusClientBuilderExtensions
    {
        /// <summary>
        ///   Registers a <see cref="ServiceBusSenderClient"/> instance with the provided <paramref name="connectionString"/>
        /// </summary>
        ///
        public static IAzureClientBuilder<ServiceBusSenderClient, ServiceBusSenderClientOptions> AddEventHubProducerClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ServiceBusSenderClient, ServiceBusSenderClientOptions>(options => new ServiceBusSenderClient(connectionString, options));
        }

        /// <summary>
        ///   Registers a <see cref="ServiceBusSenderClient"/> instance with the provided <paramref name="connectionString"/> and <paramref name="eventHubName"/>
        /// </summary>
        ///
        public static IAzureClientBuilder<ServiceBusSenderClient, ServiceBusSenderClientOptions> AddEventHubProducerClient<TBuilder>(this TBuilder builder, string connectionString, string eventHubName)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ServiceBusSenderClient, ServiceBusSenderClientOptions>(options => new ServiceBusSenderClient(connectionString, eventHubName, options));
        }

        /// <summary>
        ///   Registers a <see cref="ServiceBusSenderClient"/> instance with the provided <paramref name="fullyQualifiedNamespace"/> and <paramref name="eventHubName"/>
        /// </summary>
        ///
        public static IAzureClientBuilder<ServiceBusSenderClient, ServiceBusSenderClientOptions> AddEventHubProducerClientWithNamespace<TBuilder>(this TBuilder builder, string fullyQualifiedNamespace, string eventHubName)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<ServiceBusSenderClient, ServiceBusSenderClientOptions>((options, token) => new ServiceBusSenderClient(fullyQualifiedNamespace, eventHubName, token, options));
        }

        /// <summary>
        ///   Registers a <see cref="ServiceBusSenderClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        ///
        public static IAzureClientBuilder<ServiceBusSenderClient, ServiceBusSenderClientOptions> AddEventHubProducerClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ServiceBusSenderClient, ServiceBusSenderClientOptions>(configuration);
        }

        /// <summary>
        ///   Registers a <see cref="ServiceBusReceiverClientOptions"/> instance with the provided <paramref name="connectionString"/>
        /// </summary>
        ///
        public static IAzureClientBuilder<ServiceBusReceiverClient, ServiceBusReceiverClientOptions> AddEventHubConsumerClient<TBuilder>(this TBuilder builder, string consumerGroup, string connectionString)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ServiceBusReceiverClient, ServiceBusReceiverClientOptions>(options => new ServiceBusReceiverClient(consumerGroup, connectionString, options));
        }

        /// <summary>
        ///   Registers a <see cref="ServiceBusReceiverClient"/> instance with the provided <paramref name="connectionString"/> and <paramref name="eventHubName"/>
        /// </summary>
        ///
        public static IAzureClientBuilder<ServiceBusReceiverClient, ServiceBusReceiverClientOptions> AddEventHubConsumerClient<TBuilder>(this TBuilder builder, string consumerGroup, string connectionString, string eventHubName)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ServiceBusReceiverClient, ServiceBusReceiverClientOptions>(options => new ServiceBusReceiverClient(connectionString, eventHubName, options));
        }

        /// <summary>
        ///   Registers a <see cref="ServiceBusReceiverClient"/> instance with the provided <paramref name="fullyQualifiedNamespace"/> and <paramref name="eventHubName"/>
        /// </summary>
        ///
        public static IAzureClientBuilder<ServiceBusReceiverClient, ServiceBusReceiverClientOptions> AddEventHubConsumerClientWithNamespace<TBuilder>(this TBuilder builder, string consumerGroup, string fullyQualifiedNamespace, string eventHubName)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<ServiceBusReceiverClient, ServiceBusReceiverClientOptions>((options, token) => new ServiceBusReceiverClient(fullyQualifiedNamespace, eventHubName, token, options));
        }

        /// <summary>
        ///   Registers a <see cref="ServiceBusReceiverClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        ///
        public static IAzureClientBuilder<ServiceBusReceiverClient, ServiceBusReceiverClientOptions> AddEventHubConsumerClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ServiceBusReceiverClient, ServiceBusReceiverClientOptions>(configuration);
        }
    }
}
