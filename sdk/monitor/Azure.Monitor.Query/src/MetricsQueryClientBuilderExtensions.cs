// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Extensions;
using Azure.Monitor.Query;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="MetricsQueryClient"/> to client builder. </summary>
    public static class MetricsQueryClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="MetricsQueryClient"/> instance with the default endpoint <c>https://management.azure.com/</c> for the public cloud. </summary>
        /// <param name="builder"> The builder to register with. </param>
        public static IAzureClientBuilder<MetricsQueryClient, MetricsQueryClientOptions> AddMetricsQueryClient<TBuilder>(this TBuilder builder)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<MetricsQueryClient, MetricsQueryClientOptions>((options, cred) => new MetricsQueryClient(cred, options));
        }

        /// <summary> Registers a <see cref="MetricsQueryClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The resource manager service endpoint to use. </param>
        public static IAzureClientBuilder<MetricsQueryClient, MetricsQueryClientOptions> AddMetricsQueryClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<MetricsQueryClient, MetricsQueryClientOptions>((options, cred) => new MetricsQueryClient(endpoint, cred, options));
        }

        /// <summary> Registers a <see cref="MetricsQueryClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<MetricsQueryClient, MetricsQueryClientOptions> AddMetricsQueryClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<MetricsQueryClient, MetricsQueryClientOptions>(configuration);
        }
    }
}
