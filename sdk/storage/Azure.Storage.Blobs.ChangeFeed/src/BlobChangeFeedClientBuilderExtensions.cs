// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Extensions;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.ChangeFeed;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="BlobChangeFeedClient"/> client to clients builder.
    /// </summary>
    public static class BlobChangeFeedClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="BlobChangeFeedClient"/> instance with the provided <paramref name="connectionString"/>
        /// </summary>
        public static IAzureClientBuilder<BlobChangeFeedClient, BlobClientOptions> AddBlobChangeFeedClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<BlobChangeFeedClient, BlobClientOptions>(options => new BlobChangeFeedClient(connectionString, options));
        }

        /// <summary>
        /// Registers a <see cref="BlobChangeFeedClient"/> instance with the provided <paramref name="serviceUri"/>
        /// </summary>
        public static IAzureClientBuilder<BlobChangeFeedClient, BlobClientOptions> AddBlobChangeFeedClient<TBuilder>(this TBuilder builder, Uri serviceUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<BlobChangeFeedClient, BlobClientOptions>(
                (options, token) => token != null ? new BlobChangeFeedClient(serviceUri, token, options) : new BlobChangeFeedClient(serviceUri, options),
                requiresCredential: false);
        }

        /// <summary>
        /// Registers a <see cref="BlobChangeFeedClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="sharedKeyCredential"/>
        /// </summary>
        public static IAzureClientBuilder<BlobChangeFeedClient, BlobClientOptions> AddBlobChangeFeedClient<TBuilder>(this TBuilder builder, Uri serviceUri, StorageSharedKeyCredential sharedKeyCredential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<BlobChangeFeedClient, BlobClientOptions>(options => new BlobChangeFeedClient(serviceUri, sharedKeyCredential, options));
        }

        /// <summary>
        /// Registers a <see cref="BlobChangeFeedClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<BlobChangeFeedClient, BlobClientOptions> AddBlobChangeFeedClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<BlobChangeFeedClient, BlobClientOptions>(configuration);
        }
    }
}
