// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure;
using Azure.Core.Extensions;
using Azure.Messaging.EventGrid.Namespaces;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="EventGridSenderClient"/>, <see cref="EventGridReceiverClient"/> to client builder. </summary>
    public static partial class EventGridNamespacesClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="EventGridSenderClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="topicName"> The topic to send to. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<EventGridSenderClient, EventGridSenderClientOptions>
            AddEventGridSenderClient<TBuilder>(this TBuilder builder,
                Uri endpoint,
                string topicName,
                AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<EventGridSenderClient, EventGridSenderClientOptions>((options) => new EventGridSenderClient(endpoint, topicName, credential, options));
        }

        /// <summary> Registers a <see cref="EventGridSenderClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="topicName"> The topic to send to. </param>
        public static IAzureClientBuilder<EventGridSenderClient, EventGridSenderClientOptions> AddEventGridSenderClient<TBuilder>(this TBuilder builder, Uri endpoint, string topicName)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<EventGridSenderClient, EventGridSenderClientOptions>((options, cred) => new EventGridSenderClient(endpoint, topicName, cred, options));
        }

        /// <summary> Registers a <see cref="EventGridReceiverClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="topicName"> The topic to receive from. </param>
        /// <param name="subscriptionName"> The subscription to receive from. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<EventGridReceiverClient, EventGridReceiverClientOptions>
            AddEventGridReceiverClient<TBuilder>(this TBuilder builder,
                Uri endpoint,
                string topicName,
                string subscriptionName,
                AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<EventGridReceiverClient, EventGridReceiverClientOptions>((options) => new EventGridReceiverClient(endpoint, topicName, subscriptionName, credential, options));
        }

        /// <summary> Registers a <see cref="EventGridReceiverClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="topicName"> The topic to receive from. </param>
        /// <param name="subscriptionName"> The subscription to receive from. </param>
        public static IAzureClientBuilder<EventGridReceiverClient, EventGridReceiverClientOptions> AddEventGridReceiverClient<TBuilder>(this TBuilder builder, Uri endpoint, string topicName, string subscriptionName)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<EventGridReceiverClient, EventGridReceiverClientOptions>((options, cred) => new EventGridReceiverClient(endpoint, topicName, subscriptionName, cred, options));
        }

        /// <summary> Registers a <see cref="EventGridSenderClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<EventGridSenderClient, EventGridSenderClientOptions> AddEventGridSenderClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<EventGridSenderClient, EventGridSenderClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="EventGridReceiverClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<EventGridReceiverClient, EventGridReceiverClientOptions> AddEventGridReceiverClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<EventGridReceiverClient, EventGridReceiverClientOptions>(configuration);
        }
    }
}
