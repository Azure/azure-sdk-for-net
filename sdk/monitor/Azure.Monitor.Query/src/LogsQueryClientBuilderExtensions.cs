// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Extensions;
using Azure.Monitor.Query;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="LogsQueryClient"/> to client builder. </summary>
    public static class LogsQueryClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="LogsQueryClient"/> instance with the default endpoint 'https://api.loganalytics.io'. </summary>
        /// <param name="builder"> The builder to register with. </param>
        public static IAzureClientBuilder<LogsQueryClient, LogsQueryClientOptions> AddLogsQueryClient<TBuilder>(this TBuilder builder)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<LogsQueryClient, LogsQueryClientOptions>((options, cred) => new LogsQueryClient(cred, options));
        }

        /// <summary> Registers a <see cref="LogsQueryClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The service endpoint to use. </param>
        public static IAzureClientBuilder<LogsQueryClient, LogsQueryClientOptions> AddLogsQueryClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<LogsQueryClient, LogsQueryClientOptions>((options, cred) => new LogsQueryClient(endpoint, cred, options));
        }

        /// <summary> Registers a <see cref="LogsQueryClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<LogsQueryClient, LogsQueryClientOptions> AddLogsQueryClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<LogsQueryClient, LogsQueryClientOptions>(configuration);
        }
    }
}
