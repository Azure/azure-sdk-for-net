// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Extensions;
using Azure.Monitor.Query;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="MetricsClient"/> to client builder. </summary>
    public static class MetricsClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="MetricsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The data plane service endpoint to use. </param>
        public static IAzureClientBuilder<MetricsClient, MetricsClientOptions> AddMetricsClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<MetricsClient, MetricsClientOptions>((options, cred) => new MetricsClient(endpoint, cred, options));
        }

        /// <summary> Registers a <see cref="MetricsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<MetricsClient, MetricsClientOptions> AddMetricsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<MetricsClient, MetricsClientOptions>(configuration);
        }
    }
}
