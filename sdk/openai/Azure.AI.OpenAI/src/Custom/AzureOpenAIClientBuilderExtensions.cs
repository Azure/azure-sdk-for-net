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
        /// <param name="deploymentId"> Default deployment id to perform operations against </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<OpenAIClient, OpenAIClientOptions> AddOpenAIClient<TBuilder>(this TBuilder builder, Uri endpoint, string deploymentId, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<OpenAIClient, OpenAIClientOptions>((options) => new OpenAIClient(endpoint, deploymentId, credential, options));
        }

        /// <summary> Registers a <see cref="OpenAIClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint">
        /// Supported Cognitive Services endpoints (protocol and hostname, for example:
        /// https://westus.api.cognitive.microsoft.com).
        /// </param>
        /// <param name="deploymentId"> Default deployment id to perform operations against </param>
        public static IAzureClientBuilder<OpenAIClient, OpenAIClientOptions> AddOpenAIClient<TBuilder>(this TBuilder builder, Uri endpoint, string deploymentId)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<OpenAIClient, OpenAIClientOptions>((options, cred) => new OpenAIClient(endpoint, deploymentId, cred, options));
        }
    }
}
