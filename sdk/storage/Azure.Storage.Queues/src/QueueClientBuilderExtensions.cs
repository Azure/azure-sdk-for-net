// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Azure;
using Azure.Core.Extensions;
using Azure.Storage;
using Azure.Storage.Queues;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="QueueClientOptions"/> client to clients builder
    /// </summary>
    public static class QueueClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="QueueServiceClient"/> instance with the provided <paramref name="connectionString"/>
        /// </summary>
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<QueueServiceClient, QueueClientOptions>(options => new QueueServiceClient(connectionString, options));
        }

        /// <summary>
        /// Registers a <see cref="QueueServiceClient"/> instance with the provided <paramref name="serviceUri"/>
        /// </summary>
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<QueueServiceClient, QueueClientOptions>(
                (options, token) => token != null ? new QueueServiceClient(serviceUri, token, options) : new QueueServiceClient(serviceUri, options),
                requiresCredential: false);
        }

        /// <summary>
        /// Registers a <see cref="QueueServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="sharedKeyCredential"/>
        /// </summary>
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri, StorageSharedKeyCredential sharedKeyCredential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<QueueServiceClient, QueueClientOptions>(options => new QueueServiceClient(serviceUri, sharedKeyCredential, options));
        }

        /// <summary>
        /// Registers a <see cref="QueueServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="tokenCredential"/>
        /// </summary>
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri, TokenCredential tokenCredential)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<QueueServiceClient, QueueClientOptions>((options, token) => new QueueServiceClient(serviceUri, token, options));
        }

        /// <summary>
        /// Registers a <see cref="QueueServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="sasCredential"/>
        /// </summary>
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri, AzureSasCredential sasCredential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<QueueServiceClient, QueueClientOptions>(options => new QueueServiceClient(serviceUri, sasCredential, options));
        }

        /// <summary>
        /// Registers a <see cref="QueueServiceClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<QueueServiceClient, QueueClientOptions>(configuration);
        }
    }
}
