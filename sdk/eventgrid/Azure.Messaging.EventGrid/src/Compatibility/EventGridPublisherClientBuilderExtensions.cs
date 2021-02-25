// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.Core.Extensions;
using Azure.Messaging.EventGrid;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    ///    The set of extensions to add the <see cref="EventGridPublisherClient"/> type to the clients builder.
    /// </summary>
    public static class EventGridPublisherClientBuilderExtensions
    {
        /// <summary>
        ///   Registers a <see cref="EventGridPublisherClient "/> instance with the provided <see cref="Uri"/> and <see cref="AzureKeyCredential"/>./>.
        /// </summary>
        public static IAzureClientBuilder<EventGridPublisherClient, EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder>(
            this TBuilder builder,
            Uri endpoint,
            AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder =>
            builder.RegisterClientFactory<EventGridPublisherClient, EventGridPublisherClientOptions>(options => new EventGridPublisherClient(endpoint, credential, options));

        /// <summary>
        ///   Registers a <see cref="EventGridPublisherClient "/> instance with the provided <see cref="Uri"/> and <see cref="AzureSasCredential"/>./>.
        /// </summary>
        public static IAzureClientBuilder<EventGridPublisherClient, EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder>(
            this TBuilder builder,
            Uri endpoint,
            AzureSasCredential credential)
            where TBuilder : IAzureClientFactoryBuilder =>
            builder.RegisterClientFactory<EventGridPublisherClient, EventGridPublisherClientOptions>(options => new EventGridPublisherClient(endpoint, credential, options));

        /// <summary>
        ///   Registers a <see cref="EventGridPublisherClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<EventGridPublisherClient, EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder, TConfiguration>(
            this TBuilder builder,
            TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration> =>
            builder.RegisterClientFactory<EventGridPublisherClient, EventGridPublisherClientOptions>(configuration);
    }
}
