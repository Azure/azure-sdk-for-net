// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Extensions;
using Azure.Storage;
using Azure.Storage.Files.Shares;

#pragma warning disable AZC0001 // https://github.com/Azure/azure-sdk-tools/issues/213
namespace Microsoft.Extensions.Azure
#pragma warning restore AZC0001
{
    /// <summary>
    /// Extension methods to add <see cref="ShareServiceClient"/> client to clients builder
    /// </summary>
    public static class ShareClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="ShareServiceClient"/> instance with the provided <paramref name="connectionString"/>
        /// </summary>
        public static IAzureClientBuilder<ShareServiceClient, ShareClientOptions> AddFileServiceClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ShareServiceClient, ShareClientOptions>(options => new ShareServiceClient(connectionString, options));
        }

        /// <summary>
        /// Registers a <see cref="ShareServiceClient"/> instance with the provided <paramref name="serviceUri"/>
        /// </summary>
        public static IAzureClientBuilder<ShareServiceClient, ShareClientOptions> AddFileServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ShareServiceClient, ShareClientOptions>(options => new ShareServiceClient(serviceUri, options));
        }

        /// <summary>
        /// Registers a <see cref="ShareServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="sharedKeyCredential"/>
        /// </summary>
        public static IAzureClientBuilder<ShareServiceClient, ShareClientOptions> AddFileServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri, StorageSharedKeyCredential sharedKeyCredential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ShareServiceClient, ShareClientOptions>(options => new ShareServiceClient(serviceUri, sharedKeyCredential, options));
        }

        /// <summary>
        /// Registers a <see cref="ShareServiceClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<ShareServiceClient, ShareClientOptions> AddFileServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ShareServiceClient, ShareClientOptions>(configuration);
        }
    }
}
