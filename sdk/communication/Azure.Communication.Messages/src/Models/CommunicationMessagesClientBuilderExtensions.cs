// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Azure;
using Azure.Communication;
using Azure.Communication.Messages;
using Azure.Core.Extensions;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add clients to <see cref="IAzureClientBuilder{TClient,TOptions}"/>.
    /// This type is provided for backward compatibility.
    /// </summary>
    [CodeGenType("MessagesClientBuilderExtensions")]
    [CodeGenSuppress("AddConversationThreadClient", typeof(IAzureClientFactoryBuilder), typeof(Uri), typeof(CommunicationTokenCredential))]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static partial class CommunicationMessagesClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="NotificationMessagesClient"/> client. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration to use for the client. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<NotificationMessagesClient, CommunicationMessagesClientOptions> AddNotificationMessagesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<NotificationMessagesClient, CommunicationMessagesClientOptions>(configuration);
        }

        /// <summary> Registers a <see cref="NotificationMessagesClient"/> client. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The service endpoint. </param>
        public static IAzureClientBuilder<NotificationMessagesClient, CommunicationMessagesClientOptions> AddNotificationMessagesClient<TBuilder>(this TBuilder builder, Uri endpoint)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<NotificationMessagesClient, CommunicationMessagesClientOptions>((options, credential) => new NotificationMessagesClient(endpoint, credential, new CommunicationMessagesClientOptions()));
        }

        /// <summary> Registers a <see cref="NotificationMessagesClient"/> client. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The service endpoint. </param>
        /// <param name="credential"> The key credential. </param>
        public static IAzureClientBuilder<NotificationMessagesClient, CommunicationMessagesClientOptions> AddNotificationMessagesClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<NotificationMessagesClient, CommunicationMessagesClientOptions>(options => new NotificationMessagesClient(endpoint, credential, new CommunicationMessagesClientOptions()));
        }

        /// <summary> Registers a <see cref="MessageTemplateClient"/> client. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration to use for the client. </param>
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<MessageTemplateClient, CommunicationMessagesClientOptions> AddMessageTemplateClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<MessageTemplateClient, CommunicationMessagesClientOptions>(configuration);
        }

        /// <summary> Registers a <see cref="MessageTemplateClient"/> client. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The service endpoint. </param>
        public static IAzureClientBuilder<MessageTemplateClient, CommunicationMessagesClientOptions> AddMessageTemplateClient<TBuilder>(this TBuilder builder, Uri endpoint)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<MessageTemplateClient, CommunicationMessagesClientOptions>((options, credential) => new MessageTemplateClient(endpoint, credential, new CommunicationMessagesClientOptions()));
        }

        /// <summary> Registers a <see cref="MessageTemplateClient"/> client. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The service endpoint. </param>
        /// <param name="credential"> The key credential. </param>
        public static IAzureClientBuilder<MessageTemplateClient, CommunicationMessagesClientOptions> AddMessageTemplateClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<MessageTemplateClient, CommunicationMessagesClientOptions>(options => new MessageTemplateClient(endpoint, credential, new CommunicationMessagesClientOptions()));
        }
    }
}
