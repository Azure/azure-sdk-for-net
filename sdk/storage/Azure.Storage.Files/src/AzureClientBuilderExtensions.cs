// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Extensions;
using Azure.Storage.Files;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Extension methods to add <see cref="FileServiceClient"/> client to clients builder
    /// </summary>
    public static class AzureClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="FileServiceClient"/> instance with the provided <paramref name="connectionString"/>
        /// </summary>
        public static IAzureClientBuilder<FileServiceClient, FileClientOptions> AddFileServiceClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder: IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<FileServiceClient, FileClientOptions>(options => new FileServiceClient(connectionString, options));
        }

        /// <summary>
        /// Registers a <see cref="FileServiceClient"/> instance with the provided <paramref name="serviceUri"/>
        /// </summary>
        public static IAzureClientBuilder<FileServiceClient, FileClientOptions> AddFileServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri)
            where TBuilder: IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<FileServiceClient, FileClientOptions>(options => new FileServiceClient(serviceUri, options));
        }

        /// <summary>
        /// Registers a <see cref="FileServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="sharedKeyCredential"/>
        /// </summary>
        public static IAzureClientBuilder<FileServiceClient, FileClientOptions> AddFileServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri, StorageSharedKeyCredential sharedKeyCredential)
            where TBuilder: IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<FileServiceClient, FileClientOptions>(options => new FileServiceClient(serviceUri, sharedKeyCredential, options));
        }

        /// <summary>
        /// Registers a <see cref="FileServiceClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<FileServiceClient, FileClientOptions> AddFileServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder: IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<FileServiceClient, FileClientOptions>(configuration);
        }
    }
}
