// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Extensions;
using Azure.Monitor.Ingestion;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="LogsIngestionClient"/> to clients builder.
    /// </summary>
    public static class IngestionClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="LogsIngestionClient"/> instance with the provided <paramref name="endpoint"/>
        /// </summary>
        public static IAzureClientBuilder<LogsIngestionClient, LogsIngestionClientOptions> AddLogsIngestionClient<TBuilder>(this TBuilder builder, Uri endpoint)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<LogsIngestionClient, LogsIngestionClientOptions>((options, credential) => new LogsIngestionClient(endpoint, credential, options));
        }

        /// <summary>
        /// Registers a <see cref="LogsIngestionClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<LogsIngestionClient, LogsIngestionClientOptions> AddLogsIngestionClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<LogsIngestionClient, LogsIngestionClientOptions>(configuration);
        }
    }
}
