// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.AI.OpenAI;
using Azure.Core.Extensions;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="OpenAIClient"/> to client builder. </summary>
    public static partial class AzureOpenAIClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="OpenAIClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://westus.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<OpenAIClient, OpenAIClientOptions> AddOpenAIClient<TBuilder>(
            this TBuilder builder,
            Uri endpoint,
            AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<OpenAIClient, OpenAIClientOptions>((options) => new OpenAIClient(endpoint, credential, options));
        }

        /// <summary> Registers a <see cref="OpenAIClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://westus.api.cognitive.microsoft.com).
        /// </param>
        public static IAzureClientBuilder<OpenAIClient, OpenAIClientOptions> AddOpenAIClient<TBuilder>(
            this TBuilder builder,
            Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<OpenAIClient, OpenAIClientOptions>((options, cred) => new OpenAIClient(endpoint, cred, options));
        }
    }
}
