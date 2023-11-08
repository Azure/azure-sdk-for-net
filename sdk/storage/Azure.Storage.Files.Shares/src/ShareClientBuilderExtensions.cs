// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Extensions;
using Azure.Storage;
using Azure.Storage.Files.Shares;

namespace Microsoft.Extensions.Azure
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
        /// Registers a <see cref="ShareServiceClient"/> instance with the provided <paramref name="serviceUri"/> and the <see cref="TokenCredential"/>
        /// configured using the client factory builder's UseCredential method.
        ///
        /// Note that service-level operations do not support token credential authentication.
        /// This extension exists to allow the construction of a <see cref="ShareServiceClient"/> that can be used to derive
        /// a <see cref="ShareClient"/> that has token credential authentication.
        ///
        /// Also note that <see cref="ShareClientOptions.ShareTokenIntent"/> is currently required for token authentication.
        /// </summary>
        public static IAzureClientBuilder<ShareServiceClient, ShareClientOptions> AddFileServiceClientWithCredential<TBuilder>(this TBuilder builder, Uri serviceUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<ShareServiceClient, ShareClientOptions>((options, cred) => new ShareServiceClient(serviceUri, cred, options));
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
