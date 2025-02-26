// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using Azure.Core;

namespace Azure.AI.Inference
{
    /// <summary>
    /// The Azure AI Inference extensions.
    /// </summary>
    public static class AIInferenceExtensions
    {
        /// <summary>
        /// Gets the chat completion client.
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static ChatCompletionsClient GetChatCompletionsClient(this ConnectionProvider provider)
        {
            ChatCompletionsClient chatClient = provider.Subclients.GetClient(() => CreateChatCompletionsClient(provider), null);
            return chatClient;
        }

        private static ChatCompletionsClient CreateChatCompletionsClient(this ConnectionProvider provider)
        {
            ClientConnection connection = provider.GetConnection(typeof(ChatCompletionsClient).FullName!);
            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }
            return connection.Authentication == ClientAuthenticationMethod.Credential
            ? new ChatCompletionsClient(uri, connection.Credential as TokenCredential)
            : new ChatCompletionsClient(uri, new AzureKeyCredential(connection.ApiKeyCredential!));
        }

        /// <summary>
        /// Gets the embeddings client.
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static EmbeddingsClient GetEmbeddingsClient(this ConnectionProvider provider)
        {
            EmbeddingsClient embeddingsClient = provider.Subclients.GetClient(() => CreateEmbeddingsClient(provider), null);
            return embeddingsClient;
        }

        private static EmbeddingsClient CreateEmbeddingsClient(this ConnectionProvider provider)
        {
            ClientConnection connection = provider.GetConnection(typeof(ChatCompletionsClient).FullName!);
            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }
            return connection.Authentication == ClientAuthenticationMethod.Credential
            ? new EmbeddingsClient(uri, connection.Credential as TokenCredential)
            : new EmbeddingsClient(uri, new AzureKeyCredential(connection.ApiKeyCredential!));
        }
    }
}
