// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;

using Azure;
using Azure.Core;
using Azure.Core.Extensions;
using Azure.Messaging.WebPubSub;

//TODO: there is no way to only suppress a single member of a static class so we need to have everything custom here.
[assembly: CodeGenSuppressType("MessagingWebPubSubClientBuilderExtensions")]

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="WebPubSubServiceClient"/> client to clients builder.
    /// </summary>
    public static partial class WebPubSubServiceClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="WebPubSubServiceClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="connectionString"> HTTP or HTTPS endpoint for the Web PubSub service instance. </param>
        /// <param name="hub"> Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore. </param>
        public static IAzureClientBuilder<WebPubSubServiceClient, WebPubSubServiceClientOptions> AddWebPubSubServiceClient<TBuilder>(this TBuilder builder, string connectionString, string hub)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<WebPubSubServiceClient, WebPubSubServiceClientOptions>((options) => new WebPubSubServiceClient(connectionString, hub, options));
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

        /// <summary> Registers a <see cref="WebPubSubServiceClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<WebPubSubServiceClient, WebPubSubServiceClientOptions> AddWebPubSubServiceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<WebPubSubServiceClient, WebPubSubServiceClientOptions>(configuration);
        }
    }
}
