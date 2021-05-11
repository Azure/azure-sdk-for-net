// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Extensions;
using Azure.Data.Tables;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="TablesClientOptions"/> client to clients builder.
    /// </summary>
    public static class TableClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="TableServiceClient"/> instance with the provided <paramref name="connectionString"/>
        /// </summary>
        public static IAzureClientBuilder<TableServiceClient, TablesClientOptions> AddTableServiceClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<TableServiceClient, TablesClientOptions>(options => new TableServiceClient(connectionString, options));
        }

        /// <summary>
        /// Registers a <see cref="TableServiceClient"/> instance with the provided <paramref name="serviceUri"/> and <paramref name="sharedKeyCredential"/>
        /// </summary>
        public static IAzureClientBuilder<TableServiceClient, TablesClientOptions> AddTableServiceClient<TBuilder>(this TBuilder builder, Uri serviceUri, TableSharedKeyCredential sharedKeyCredential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<TableServiceClient, TablesClientOptions>(options => new TableServiceClient(serviceUri, sharedKeyCredential, options));
        }

        /// <summary>
        /// Registers a <see cref="TableServiceClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<TableServiceClient, TablesClientOptions> AddTableServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<TableServiceClient, TablesClientOptions>(configuration);
        }
    }
}
