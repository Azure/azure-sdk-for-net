// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using Azure.Core;
using Azure.Core.Extensions;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("CommunicationJobRouterClientBuilderExtensions")]
    internal static partial class JobRouterClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="JobRouterAdministrationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public static IAzureClientBuilder<JobRouterAdministrationClient, JobRouterClientOptions> AddJobRouterAdministrationClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<JobRouterAdministrationClient, JobRouterClientOptions>((options) => new JobRouterAdministrationClient(connectionString, options));
        }

        /// <summary> Registers a <see cref="JobRouterClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public static IAzureClientBuilder<JobRouterClient, JobRouterClientOptions> AddJobRouterClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<JobRouterClient, JobRouterClientOptions>((options) => new JobRouterClient(connectionString, options));
        }
    }
}
