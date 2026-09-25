// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.Core;
using Azure.Core.Extensions;
using Azure.Messaging.WebPubSub.Chat;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="WebPubSubChatServiceClient"/> to an Azure client factory builder.
    /// </summary>
    public static class WebPubSubChatServiceClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="WebPubSubChatServiceClient"/> instance with the provided <paramref name="connectionString"/> and <paramref name="hub"/>.
        /// </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="connectionString"> Connection string for the Web PubSub service instance. </param>
        /// <param name="hub"> Target hub name. </param>
        public static IAzureClientBuilder<WebPubSubChatServiceClient, WebPubSubChatServiceClientOptions> AddWebPubSubChatServiceClient<TBuilder>(this TBuilder builder, string connectionString, string hub)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<WebPubSubChatServiceClient, WebPubSubChatServiceClientOptions>(options => new WebPubSubChatServiceClient(connectionString, hub, options));
        }

        /// <summary>
        /// Registers a <see cref="WebPubSubChatServiceClient"/> instance with the provided <paramref name="endpoint"/> and <paramref name="hub"/>.
        /// </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="hub"> Target hub name. </param>
        public static IAzureClientBuilder<WebPubSubChatServiceClient, WebPubSubChatServiceClientOptions> AddWebPubSubChatServiceClient<TBuilder>(this TBuilder builder, Uri endpoint, string hub)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<WebPubSubChatServiceClient, WebPubSubChatServiceClientOptions>((options, credential) => new WebPubSubChatServiceClient(endpoint, hub, credential, options));
        }

        /// <summary>
        /// Registers a <see cref="WebPubSubChatServiceClient"/> instance with the provided <paramref name="endpoint"/>, <paramref name="hub"/>, and <paramref name="credential"/>.
        /// </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="hub"> Target hub name. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        public static IAzureClientBuilder<WebPubSubChatServiceClient, WebPubSubChatServiceClientOptions> AddWebPubSubChatServiceClient<TBuilder>(this TBuilder builder, Uri endpoint, string hub, AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<WebPubSubChatServiceClient, WebPubSubChatServiceClientOptions>(options => new WebPubSubChatServiceClient(endpoint, hub, credential, options));
        }
    }
}