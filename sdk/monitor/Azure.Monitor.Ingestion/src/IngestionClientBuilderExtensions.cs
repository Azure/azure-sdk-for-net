// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Extensions;
using Azure.Monitor.Ingestion;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="LogsIngestionClient"/> to client builder. </summary>
    public static partial class IngestionClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="LogsIngestionClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The Data Collection Endpoint for the Data Collection Rule, for example https://dce-name.eastus-2.ingest.monitor.azure.com. </param>
        public static IAzureClientBuilder<LogsIngestionClient, LogsIngestionClientOptions> AddLogsIngestionClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<LogsIngestionClient, LogsIngestionClientOptions>((options, cred) => new LogsIngestionClient(endpoint, cred, options));
        }
    }
}
