// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Azure;
using Azure.Core;
using Azure.Core.Extensions;
using Azure.Storage;
using Azure.Storage.Blobs;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="BlobServiceClient"/> client to clients builder.
    /// </summary>
    public static class BlobClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="BlobServiceClient"/> instance with the provided <paramref name="connectionString"/>
        /// </summary>
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<BlobServiceClient, BlobClientOptions>(options => new BlobServiceClient(connectionString, options));
        }

        /// <summary>
        /// Registers a <see cref="BlobServiceClient"/> instance with the provided <paramref name="serviceUri"/>
        /// </summary>
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<BlobServiceClient, BlobClientOptions>(
                (options, token) => token != null ? new BlobServiceClient(serviceUri, token, options) : new BlobServiceClient(serviceUri, options),
                requiresCredential: false);
        }

        /// <summary>
        /// Registers a <see cref="BlobServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="sharedKeyCredential"/>
        /// </summary>
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri, StorageSharedKeyCredential sharedKeyCredential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<BlobServiceClient, BlobClientOptions>(options => new BlobServiceClient(serviceUri, sharedKeyCredential, options));
        }

        /// <summary>
        /// Registers a <see cref="BlobServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="tokenCredential"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri, TokenCredential tokenCredential)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<BlobServiceClient, BlobClientOptions>((options, token) => new BlobServiceClient(serviceUri, token, options));
        }

        /// <summary>
        /// Registers a <see cref="BlobServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="tokenCredential"/>
        /// </summary>
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClientWithTokenCredential<TBuilder>(this TBuilder builder, Uri serviceUri, TokenCredential tokenCredential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<BlobServiceClient, BlobClientOptions>(options => new BlobServiceClient(serviceUri, tokenCredential, options));
        }

        /// <summary>
        /// Registers a <see cref="BlobServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="sasCredential"/>
        /// </summary>
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri, AzureSasCredential sasCredential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<BlobServiceClient, BlobClientOptions>(options => new BlobServiceClient(serviceUri, sasCredential, options));
        }

        /// <summary>
        /// Registers a <see cref="BlobServiceClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<BlobServiceClient, BlobClientOptions>(configuration);
        }
    }
}
