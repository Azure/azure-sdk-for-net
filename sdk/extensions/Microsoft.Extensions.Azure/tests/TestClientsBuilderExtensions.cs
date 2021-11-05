// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Extensions.Tests
{
    internal static class TestClientsBuilderExtensions
    {
        public static IAzureClientBuilder<TestClient, TestClientOptions> AddTestClient<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder: IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<TestClient, TestClientOptions>(options => new TestClient(connectionString, options));
        }

        public static IAzureClientBuilder<TestClient, TestClientOptions> AddTestClient<TBuilder>(this TBuilder builder, Uri uri)
            where TBuilder: IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<TestClient, TestClientOptions>(options => new TestClient(uri, options));
        }

        public static IAzureClientBuilder<TestClient, TestClientOptions> AddTestClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder: IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<TestClient, TestClientOptions>(configuration);
        }

        public static IAzureClientBuilder<TestClientWithCredentials, TestClientOptions> AddTestClientWithCredentials<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder: IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<TestClientWithCredentials, TestClientOptions>(configuration);
        }

        public static IAzureClientBuilder<TestClientWithCredentials, TestClientOptions> AddTestClientWithCredentials<TBuilder>(this TBuilder builder, Uri uri)
            where TBuilder: IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<TestClientWithCredentials, TestClientOptions>((options, cred) => new TestClientWithCredentials(uri, cred, options));
        }

        public static IAzureClientBuilder<TestClientMultipleOptionsParameters, TestClientOptionsMultipleParameters> AddTestClientOptionsMultipleParameters<TBuilder>(this TBuilder builder, string connectionString)
            where TBuilder: IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<TestClientMultipleOptionsParameters, TestClientOptionsMultipleParameters>(options => new TestClientMultipleOptionsParameters(connectionString, options));
        }
    }
}