// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Extensions;
using Azure.Messaging.EventHubs;

#pragma warning disable AZC0001 // https://github.com/Azure/azure-sdk-tools/issues/213
namespace Microsoft.Extensions.Azure
#pragma warning restore AZC0001
{
    /// <summary>
    /// Extension methods to add <see cref="EventHubConnection"/> client to clients builder
    /// </summary>
    public static class EventHubClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="EventHubConnection"/> instance with the provided <paramref name="connectionString"/>
        /// </summary>
        public static IAzureClientBuilder<EventHubConnection, EventHubConnectionOptions> AddEventHubClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<EventHubConnection, EventHubConnectionOptions>(options => new EventHubConnection(connectionString, options));
        }

        /// <summary>
        /// Registers a <see cref="EventHubConnection"/> instance with the provided <paramref name="connectionString"/> and <paramref name="eventHubName"/>
        /// </summary>
        public static IAzureClientBuilder<EventHubConnection, EventHubConnectionOptions> AddEventHubClient<TBuilder>(this TBuilder builder, string connectionString, string eventHubName)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<EventHubConnection, EventHubConnectionOptions>(options => new EventHubConnection(connectionString, eventHubName, options));
        }

        /// <summary>
        /// Registers a <see cref="EventHubConnection"/> instance with the provided <paramref name="host"/> and <paramref name="eventHubName"/>
        /// </summary>
        public static IAzureClientBuilder<EventHubConnection, EventHubConnectionOptions> AddEventHubClientWithHost<TBuilder>(this TBuilder builder, string host, string eventHubName)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<EventHubConnection, EventHubConnectionOptions>((options, token) => new EventHubConnection(host, eventHubName, token, options));
        }

        /// <summary>
        /// Registers a <see cref="EventHubConnection"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<EventHubConnection, EventHubConnectionOptions> AddEventHubClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<EventHubConnection, EventHubConnectionOptions>(configuration);
        }
    }
}
