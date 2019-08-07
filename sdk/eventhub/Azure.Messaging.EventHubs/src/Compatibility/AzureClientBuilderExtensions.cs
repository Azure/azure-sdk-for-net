// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Extensions;
using Azure.Messaging.EventHubs;

namespace Azure.ApplicationModel.Configuration
{
    /// <summary>
    /// Extension methods to add <see cref="EventHubClient"/> client to clients builder
    /// </summary>
    public static class AzureClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="EventHubClient"/> instance with the provided <paramref name="connectionString"/>
        /// </summary>
        public static IAzureClientBuilder<EventHubClient, EventHubClientOptions> AddEventHubClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<EventHubClient, EventHubClientOptions>(options => new EventHubClient(connectionString, options));
        }

        /// <summary>
        /// Registers a <see cref="EventHubClient"/> instance with the provided <paramref name="connectionString"/> and <paramref name="eventHubName"/>
        /// </summary>
        public static IAzureClientBuilder<EventHubClient, EventHubClientOptions> AddEventHubClient<TBuilder>(this TBuilder builder, string connectionString, string eventHubName)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<EventHubClient, EventHubClientOptions>(options => new EventHubClient(connectionString, eventHubName, options));
        }

        /// <summary>
        /// Registers a <see cref="EventHubClient"/> instance with the provided <paramref name="host"/> and <paramref name="eventHubName"/>
        /// </summary>
        public static IAzureClientBuilder<EventHubClient, EventHubClientOptions> AddEventHubClientWithHost<TBuilder>(this TBuilder builder, string host, string eventHubName)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<EventHubClient, EventHubClientOptions>((options, token) => new EventHubClient(host, eventHubName, token, options));
        }

        /// <summary>
        /// Registers a <see cref="EventHubClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<EventHubClient, EventHubClientOptions> AddEventHubClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<EventHubClient, EventHubClientOptions>(configuration);
        }
    }
}
