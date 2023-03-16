// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Extensions;
using Azure.Monitor.Query;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="LogsQueryClient"/> to client builder. </summary>
    public static class LogsQueryClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="LogsQueryClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The Data Collection Endpoint for the Data Collection Rule, for example https://dce-name.eastus-2.ingest.monitor.azure.com. </param>
        public static IAzureClientBuilder<LogsQueryClient, LogsQueryClientOptions> AddLogsQueryClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<LogsQueryClient, LogsQueryClientOptions>((options, cred) => new LogsQueryClient(endpoint, cred, options));
        }

        /// <summary> Registers a <see cref="LogsQueryClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<LogsQueryClient, LogsQueryClientOptions> AddLogsQueryClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<LogsQueryClient, LogsQueryClientOptions>(configuration);
        }
    }
}
