// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Queues
{
    [CodeGenType("QueuesClientBuilderExtensions")]
    internal static partial class QueuesClientBuilderExtensionsInternal
    {
        /// <summary> Registers a <see cref="QueueClient"/> client with the specified <see cref="IAzureClientBuilder{TClient,TOptions}"/>. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="queueUri"></param>
        /// <param name="credential"></param>
        public static IAzureClientBuilder<QueueClient, QueueClientOptions> AddQueueClient<TBuilder>(this TBuilder builder, Uri queueUri, StorageSharedKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<QueueClient, QueueClientOptions>(options => new QueueClient(queueUri, credential, options));
        }

        /// <summary> Registers a <see cref="QueueClient"/> client with the specified <see cref="IAzureClientBuilder{TClient,TOptions}"/>. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="queueUri"></param>
        public static IAzureClientBuilder<QueueClient, QueueClientOptions> AddQueueClient<TBuilder>(this TBuilder builder, Uri queueUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<QueueClient, QueueClientOptions>((options, credential) => new QueueClient(queueUri, credential, options));
        }
    }
}
