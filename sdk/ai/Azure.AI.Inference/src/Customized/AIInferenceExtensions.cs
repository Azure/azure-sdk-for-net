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
        public static ChatCompletionsClient GetChatCompletionsClient(this ClientConnectionProvider provider)
        {
            ChatCompletionsClientKey chatCompletionsClientKey = new();
            ChatCompletionsClient chatClient = provider.Subclients.GetClient(chatCompletionsClientKey, () => CreateChatCompletionsClient(provider));
            return chatClient;
        }

        private static ChatCompletionsClient CreateChatCompletionsClient(this ClientConnectionProvider provider)
        {
            ClientConnection connection = provider.GetConnection(typeof(ChatCompletionsClient).FullName!);

            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }

            return connection.CredentialKind switch
            {
                CredentialKind.ApiKeyString => new ChatCompletionsClient(uri, new AzureKeyCredential((string)connection.Credential!)),
                CredentialKind.TokenCredential => new ChatCompletionsClient(uri, (TokenCredential)connection.Credential!),
                _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
            };
        }

        /// <summary>
        /// Gets the embeddings client.
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static EmbeddingsClient GetEmbeddingsClient(this ClientConnectionProvider provider)
        {
            EmbeddingsClientKey embeddingsClientKey = new();
            EmbeddingsClient embeddingsClient = provider.Subclients.GetClient(embeddingsClientKey, () => CreateEmbeddingsClient(provider));
            return embeddingsClient;
        }

        private static EmbeddingsClient CreateEmbeddingsClient(this ClientConnectionProvider provider)
        {
            ClientConnection connection = provider.GetConnection(typeof(ChatCompletionsClient).FullName!);

            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }

            return connection.CredentialKind switch
            {
                CredentialKind.ApiKeyString => new EmbeddingsClient(uri, new AzureKeyCredential((string)connection.Credential!)),
                CredentialKind.TokenCredential => new EmbeddingsClient(uri, (TokenCredential)connection.Credential!),
                _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
            };
        }

        private record ChatCompletionsClientKey();

        private record EmbeddingsClientKey();
    }
}
