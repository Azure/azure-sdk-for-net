// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure;
using Azure.Core.Extensions;
using Azure.Messaging.EventGrid;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// The set of extensions to add the <see cref="EventGridPublisherClient"/> type to the clients builder.
    /// </summary>
    public static class EventGridPublisherClientBuilderExtensions
    {
        /// <summary>
        /// Registers an <see cref="EventGridPublisherClient "/> instance with the provided <see cref="Uri"/> and <see cref="AzureKeyCredential"/>./>.
        /// </summary>
        public static IAzureClientBuilder<EventGridPublisherClient, EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder>(
            this TBuilder builder,
            Uri endpoint,
            AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder =>
            builder.RegisterClientFactory<EventGridPublisherClient, EventGridPublisherClientOptions>(options => new EventGridPublisherClient(endpoint, credential, options));

        /// <summary>
        /// Registers an <see cref="EventGridPublisherClient "/> instance with the provided <see cref="Uri"/> and <see cref="AzureSasCredential"/>./>.
        /// </summary>
        public static IAzureClientBuilder<EventGridPublisherClient, EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder>(
            this TBuilder builder,
            Uri endpoint,
            AzureSasCredential credential)
            where TBuilder : IAzureClientFactoryBuilder =>
            builder.RegisterClientFactory<EventGridPublisherClient, EventGridPublisherClientOptions>(options => new EventGridPublisherClient(endpoint, credential, options));

        /// <summary>
        /// Registers an <see cref="EventGridPublisherClient"/> instance with the provided <see cref="Uri"/>.
        /// </summary>
        public static IAzureClientBuilder<EventGridPublisherClient, EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder>(this TBuilder builder, Uri endpoint)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<EventGridPublisherClient, EventGridPublisherClientOptions>((options, token) => new EventGridPublisherClient(endpoint, token, options));
        }

        /// <summary>
        /// Registers an <see cref="EventGridPublisherClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<EventGridPublisherClient, EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder, TConfiguration>(
            this TBuilder builder,
            TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration> =>
            builder.RegisterClientFactory<EventGridPublisherClient, EventGridPublisherClientOptions>(configuration);
    }
}
