// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public static IAzureClientBuilder<DataLakeServiceClient, DataLakeClientOptions> AddDataLakeServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<DataLakeServiceClient, DataLakeClientOptions>(configuration);
        }
    }
}
