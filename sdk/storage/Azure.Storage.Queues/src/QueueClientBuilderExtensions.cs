// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Extensions;
using Azure.Storage;
using Azure.Storage.Queues;

#pragma warning disable AZC0001 // https://github.com/Azure/azure-sdk-tools/issues/213
namespace Microsoft.Extensions.Azure
#pragma warning restore AZC0001
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
        /// Registers a <see cref="QueueServiceClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<QueueServiceClient, QueueClientOptions>(configuration);
        }
    }
}
