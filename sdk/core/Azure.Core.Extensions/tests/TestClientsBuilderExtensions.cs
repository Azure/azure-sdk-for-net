// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Extensions.Tests
{
    internal static class TestClientsBuilderExtensions
    {
        public static TBuilder AddTestClient<TBuilder>(this TBuilder builder, string name, string connectionString, Action<TestClientOptions> configureOptions = null)
            where TBuilder: IAzureClientsBuilder
        {
            builder.RegisterClient<TestClient, TestClientOptions>(name, options => new TestClient(connectionString, options), configureOptions);
            return builder;
        }

        public static TBuilder AddTestClient<TBuilder>(this TBuilder builder, string name, Uri uri, Action<TestClientOptions> configureOptions = null)
            where TBuilder: IAzureClientsBuilder
        {
            builder.RegisterClient<TestClient, TestClientOptions>(name, options => new TestClient(uri, options), configureOptions);
            return builder;
        }

        public static TBuilder AddTestClient<TBuilder, TConfiguration>(this TBuilder builder, string name, TConfiguration configuration)
            where TBuilder: IAzureClientsBuilderWithConfiguration<TConfiguration>
        {
            builder.RegisterClient<TestClient, TestClientOptions>(name, configuration);
            return builder;
        }

        public static TBuilder AddTestClientWithCredentials<TBuilder, TConfiguration>(this TBuilder builder, string name, TConfiguration configuration)
            where TBuilder: IAzureClientsBuilderWithConfiguration<TConfiguration>
        {
            builder.RegisterClient<TestClientWithCredentials, TestClientOptions>(name, configuration);
            return builder;
        }

        public static TBuilder AddTestClientWithCredentials<TBuilder>(this TBuilder builder, string name, Uri uri, TokenCredential tokenCredential = null, Action<TestClientOptions> configureOptions = null)
            where TBuilder: IAzureClientsBuilderWithCredential
        {
            builder.RegisterClient<TestClientWithCredentials, TestClientOptions>(name, (options, cred) => new TestClientWithCredentials(uri, cred, options), configureOptions, tokenCredential);
            return builder;
        }

    }
}