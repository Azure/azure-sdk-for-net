// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Azure.Core;
using Azure.Core.Extensions;

namespace Azure.Communication.JobRouter
{
    /// <summary> Extension methods to add <see cref="JobRouterAdministrationClient"/>, <see cref="JobRouterClient"/> to client builder. </summary>
    public static class JobRouterClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="JobRouterAdministrationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="connectionString"> Connection string acquired from your Communication resource. </param>
        public static IAzureClientBuilder<JobRouterAdministrationClient, JobRouterClientOptions> AddJobRouterAdministrationClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<JobRouterAdministrationClient, JobRouterClientOptions>((options) => new JobRouterAdministrationClient(connectionString, options));
        }

        /// <summary> Registers a <see cref="JobRouterClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="connectionString"> Connection string acquired from your Communication resource. </param>
        public static IAzureClientBuilder<JobRouterClient, JobRouterClientOptions> AddJobRouterClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<JobRouterClient, JobRouterClientOptions>((options) => new JobRouterClient(connectionString, options));
        }

        /// <summary> Registers a <see cref="JobRouterAdministrationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> endpoint of your Communication resource. </param>
        /// <param name="credential"> The <see cref="AzureKeyCredential"/> used to authenticate requests. </param>
        public static IAzureClientBuilder<JobRouterAdministrationClient, JobRouterClientOptions> AddJobRouterAdministrationClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<JobRouterAdministrationClient, JobRouterClientOptions>((options) => new JobRouterAdministrationClient(endpoint, credential, options));
        }

        /// <summary> Registers a <see cref="JobRouterClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> endpoint of your Communication resource. </param>
        /// <param name="credential"> The <see cref="AzureKeyCredential"/> used to authenticate requests. </param>
        public static IAzureClientBuilder<JobRouterClient, JobRouterClientOptions> AddJobRouterClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<JobRouterClient, JobRouterClientOptions>((options) => new JobRouterClient(endpoint, credential, options));
        }

        /// <summary> Registers a <see cref="JobRouterAdministrationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> endpoint of your Communication resource. </param>
        /// <param name="credential"> The <see cref="TokenCredential"/> used to authenticate requests, such as DefaultAzureCredential. </param>
        public static IAzureClientBuilder<JobRouterAdministrationClient, JobRouterClientOptions> AddJobRouterAdministrationClient<TBuilder>(this TBuilder builder, Uri endpoint, TokenCredential credential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<JobRouterAdministrationClient, JobRouterClientOptions>((options) => new JobRouterAdministrationClient(endpoint, credential, options));
        }

        /// <summary> Registers a <see cref="JobRouterClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> endpoint of your Communication resource. </param>
        /// <param name="credential"> The <see cref="TokenCredential"/> used to authenticate requests, such as DefaultAzureCredential. </param>
        public static IAzureClientBuilder<JobRouterClient, JobRouterClientOptions> AddJobRouterClient<TBuilder>(this TBuilder builder, Uri endpoint, TokenCredential credential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<JobRouterClient, JobRouterClientOptions>((options) => new JobRouterClient(endpoint, credential, options));
        }

        /// <summary> Registers a <see cref="JobRouterAdministrationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<JobRouterAdministrationClient, JobRouterClientOptions> AddJobRouterAdministrationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<JobRouterAdministrationClient, JobRouterClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="JobRouterClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<JobRouterClient, JobRouterClientOptions> AddJobRouterClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<JobRouterClient, JobRouterClientOptions>(configuration);
        }
    }
}
