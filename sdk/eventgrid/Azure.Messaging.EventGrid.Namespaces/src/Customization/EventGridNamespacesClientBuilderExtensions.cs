﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Extensions;

namespace Azure.Messaging.EventGrid.Namespaces
{
    /// <summary> Extension methods to add <see cref="EventGridSenderClient"/>, <see cref="EventGridReceiverClient"/> to client builder. </summary>
    public static partial class EventGridNamespacesClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="EventGridSenderClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="topicName"> The topic to send to. </param>
        public static IAzureClientBuilder<EventGridSenderClient, EventGridSenderClientOptions> AddEventGridSenderClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential, string topicName)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<EventGridSenderClient, EventGridSenderClientOptions>((options) => new EventGridSenderClient(endpoint, credential, topicName, options));
        }

        /// <summary> Registers a <see cref="EventGridSenderClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="topicName"> The topic to send to. </param>
        public static IAzureClientBuilder<EventGridSenderClient, EventGridSenderClientOptions> AddEventGridSenderClient<TBuilder>(this TBuilder builder, Uri endpoint, string topicName)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<EventGridSenderClient, EventGridSenderClientOptions>((options, cred) => new EventGridSenderClient(endpoint, cred, topicName, options));
        }

        /// <summary> Registers a <see cref="EventGridReceiverClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="topicName"> The topic to receive from. </param>
        /// <param name="subscriptionName"> The subscription to receive from. </param>
        public static IAzureClientBuilder<EventGridReceiverClient, EventGridReceiverClientOptions> AddEventGridReceiverClient<TBuilder>(this TBuilder builder, Uri endpoint, AzureKeyCredential credential, string topicName, string subscriptionName)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<EventGridReceiverClient, EventGridReceiverClientOptions>((options) => new EventGridReceiverClient(endpoint, credential, topicName, subscriptionName, options));
        }

        /// <summary> Registers a <see cref="EventGridReceiverClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The host name of the namespace, e.g. namespaceName1.westus-1.eventgrid.azure.net. </param>
        /// <param name="topicName"> The topic to receive from. </param>
        /// <param name="subscriptionName"> The subscription to receive from. </param>
        public static IAzureClientBuilder<EventGridReceiverClient, EventGridReceiverClientOptions> AddEventGridReceiverClient<TBuilder>(this TBuilder builder, Uri endpoint, string topicName, string subscriptionName)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<EventGridReceiverClient, EventGridReceiverClientOptions>((options, cred) => new EventGridReceiverClient(endpoint, cred, topicName, subscriptionName, options));
        }

        /// <summary> Registers a <see cref="EventGridSenderClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<EventGridSenderClient, EventGridSenderClientOptions> AddEventGridSenderClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<EventGridSenderClient, EventGridSenderClientOptions>(configuration);
        }
        /// <summary> Registers a <see cref="EventGridReceiverClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<EventGridReceiverClient, EventGridReceiverClientOptions> AddEventGridReceiverClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<EventGridReceiverClient, EventGridReceiverClientOptions>(configuration);
        }
    }
}
