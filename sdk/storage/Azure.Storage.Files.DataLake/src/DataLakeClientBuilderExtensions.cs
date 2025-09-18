// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Azure;
using Azure.Core;
using Azure.Core.Extensions;
using Azure.Storage;
using Azure.Storage.Files.DataLake;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="DataLakeServiceClient"/> client to clients builder.
    /// </summary>
    public static class DataLakeClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="DataLakeServiceClient"/> instance with the provided <paramref name="serviceUri"/>.
        /// </summary>
        public static IAzureClientBuilder<DataLakeServiceClient, DataLakeClientOptions> AddDataLakeServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<DataLakeServiceClient, DataLakeClientOptions>(
                (options, token) => token != null ? new DataLakeServiceClient(serviceUri, token, options) : new DataLakeServiceClient(serviceUri, options),
                requiresCredential: false);
        }

        /// <summary>
        /// Registers a <see cref="DataLakeServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="sharedKeyCredential"/>.
        /// </summary>
        public static IAzureClientBuilder<DataLakeServiceClient, DataLakeClientOptions> AddDataLakeServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri, StorageSharedKeyCredential sharedKeyCredential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<DataLakeServiceClient, DataLakeClientOptions>(options => new DataLakeServiceClient(serviceUri, sharedKeyCredential, options));
        }

        /// <summary>
        /// Registers a <see cref="DataLakeServiceClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<DataLakeServiceClient, DataLakeClientOptions> AddDataLakeServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<DataLakeServiceClient, DataLakeClientOptions>(configuration);
        }

        /// <summary>
        /// Registers a <see cref="DataLakeServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="tokenCredential"/>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IAzureClientBuilder<DataLakeServiceClient, DataLakeClientOptions> AddDataLakeServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri, TokenCredential tokenCredential)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<DataLakeServiceClient, DataLakeClientOptions>((options, token) => new DataLakeServiceClient(serviceUri, token, options));
        }

        /// <summary>
        /// Registers a <see cref="DataLakeServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="tokenCredential"/>
        /// </summary>
        public static IAzureClientBuilder<DataLakeServiceClient, DataLakeClientOptions> AddDataLakeServiceClientWithTokenCredential<TBuilder>(this TBuilder builder, Uri serviceUri, TokenCredential tokenCredential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<DataLakeServiceClient, DataLakeClientOptions>(options => new DataLakeServiceClient(serviceUri, tokenCredential, options));
        }

        /// <summary>
        /// Registers a <see cref="DataLakeServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="sasCredential"/>
        /// </summary>
        public static IAzureClientBuilder<DataLakeServiceClient, DataLakeClientOptions> AddDataLakeServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri, AzureSasCredential sasCredential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<DataLakeServiceClient, DataLakeClientOptions>(options => new DataLakeServiceClient(serviceUri, sasCredential, options));
        }
    }
}
