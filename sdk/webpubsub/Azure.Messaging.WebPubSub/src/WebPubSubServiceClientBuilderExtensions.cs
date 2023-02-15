// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Azure;
using Azure.Core;
using Azure.Core.Extensions;
using Azure.Messaging.WebPubSub;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="WebPubSubServiceClient"/> client to clients builder.
    /// </summary>
    public static partial class WebPubSubServiceClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="WebPubSubServiceClient"/> instance with the provided <paramref name="connectionString"/> and <paramref name="hub"/>
        /// </summary>
        public static IAzureClientBuilder<WebPubSubServiceClient, WebPubSubServiceClientOptions> AddWebPubSubServiceClient<TBuilder>(this TBuilder builder, string connectionString, string hub)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<WebPubSubServiceClient, WebPubSubServiceClientOptions>(options => new WebPubSubServiceClient(connectionString, hub, options));
        }

        /// <summary>
        /// Registers a <see cref="WebPubSubServiceClient"/> instance with the provided <paramref name="endpoint"/>, and <paramref name="hub"/> and <paramref name="credential"/>
        /// </summary>
        public static IAzureClientBuilder<WebPubSubServiceClient, WebPubSubServiceClientOptions> AddWebPubSubServiceClient<TBuilder>(this TBuilder builder, Uri endpoint, string hub, AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<WebPubSubServiceClient, WebPubSubServiceClientOptions>(options => new WebPubSubServiceClient(endpoint, hub, credential, options));
        }

        /// <summary>
        /// Registers a <see cref="WebPubSubServiceClient"/> instance with the provided <paramref name="endpoint"/>, and <paramref name="hub"/> and <paramref name="credential"/>
        /// </summary>
        public static IAzureClientBuilder<WebPubSubServiceClient, WebPubSubServiceClientOptions> AddWebPubSubServiceClient<TBuilder>(this TBuilder builder, Uri endpoint, string hub, TokenCredential credential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<WebPubSubServiceClient, WebPubSubServiceClientOptions>(options => new WebPubSubServiceClient(endpoint, hub, credential, options));
        }

        /// <summary>
        /// Registers a <see cref="WebPubSubServiceClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<WebPubSubServiceClient, WebPubSubServiceClientOptions> AddWebPubSubServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<WebPubSubServiceClient, WebPubSubServiceClientOptions>(configuration);
        }
    }
}
