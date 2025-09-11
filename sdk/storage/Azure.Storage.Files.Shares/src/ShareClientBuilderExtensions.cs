// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using Azure.Core.Extensions;
using Azure.Core;
using Azure.Storage;
using Azure.Storage.Files.Shares;
using Azure;

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
        /// Registers a <see cref="ShareServiceClient"/> instance with the provided <paramref name="serviceUri"/>.
        ///
        /// Note that use of this method is not recommended as it constructs a <see cref="ShareServiceClient"/> without authentication details, ignoring the token
        /// credential configured using the client factory builder's UseCredential method. Use <see cref="AddFileServiceClientWithCredential{TBuilder}"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IAzureClientBuilder<ShareServiceClient, ShareClientOptions> AddFileServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ShareServiceClient, ShareClientOptions>(options => new ShareServiceClient(serviceUri, options));
        }

        /// <summary>
        /// Registers a <see cref="ShareServiceClient"/> instance with the provided <paramref name="serviceUri"/> and the token credential
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
        /// Registers a <see cref="ShareServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="tokenCredential"/>
        /// </summary>
        public static IAzureClientBuilder<ShareServiceClient, ShareClientOptions> AddShareServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri, TokenCredential tokenCredential)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<ShareServiceClient, ShareClientOptions>((options, token) => new ShareServiceClient(serviceUri, token, options));
        }

        /// <summary>
        /// Registers a <see cref="ShareServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="sasCredential"/>
        /// </summary>
        public static IAzureClientBuilder<ShareServiceClient, ShareClientOptions> AddShareServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri, AzureSasCredential sasCredential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ShareServiceClient, ShareClientOptions>(options => new ShareServiceClient(serviceUri, sasCredential, options));
        }

        /// <summary>
        /// Registers a <see cref="ShareServiceClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<ShareServiceClient, ShareClientOptions> AddFileServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ShareServiceClient, ShareClientOptions>(configuration);
        }
    }
}
