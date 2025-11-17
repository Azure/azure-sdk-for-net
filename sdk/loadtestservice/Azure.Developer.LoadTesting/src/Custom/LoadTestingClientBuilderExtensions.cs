// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Extensions;
using Azure.Developer.LoadTesting;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add clients to <see cref="IAzureClientBuilder{TClient,TOptions}"/>. </summary>
    public static partial class LoadTestingClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="LoadTestAdministrationClient"/> client with the specified <see cref="IAzureClientBuilder{TClient,TOptions}"/>. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        public static IAzureClientBuilder<LoadTestAdministrationClient, LoadTestingClientOptions> AddLoadTestAdministrationClient<TBuilder>(this TBuilder builder, Uri endpoint)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<LoadTestAdministrationClient, LoadTestingClientOptions>((options, cred) => new LoadTestAdministrationClient(endpoint, cred, options));
        }

        /// <summary> Registers a <see cref="LoadTestRunClient"/> client with the specified <see cref="IAzureClientBuilder{TClient,TOptions}"/>. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        public static IAzureClientBuilder<LoadTestRunClient, LoadTestingClientOptions> AddLoadTestRunClient<TBuilder>(this TBuilder builder, Uri endpoint)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<LoadTestRunClient, LoadTestingClientOptions>((options, cred) => new LoadTestRunClient(endpoint, cred, options));
        }
    }
}
