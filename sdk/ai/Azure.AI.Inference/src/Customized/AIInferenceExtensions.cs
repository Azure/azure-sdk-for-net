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
        /// <param name="options"></param>
        /// <returns></returns>
        public static ChatCompletionsClient GetChatCompletionsClient(this ConnectionProvider provider, AzureAIInferenceClientOptions? options = null)
        {
            ChatCompletionsClientKey chatCompletionsClientKey = new(options);
            ChatCompletionsClient chatClient = provider.Subclients.GetClient(chatCompletionsClientKey, () => CreateChatCompletionsClient(provider));
            return chatClient;
        }

        private static ChatCompletionsClient CreateChatCompletionsClient(this ConnectionProvider provider, AzureAIInferenceClientOptions? options = null)
        {
            ClientConnection connection = provider.GetConnection(typeof(ChatCompletionsClient).FullName!);

            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }

            return connection.CredentialKind switch
            {
                CredentialKind.ApiKeyString => new ChatCompletionsClient(uri, new AzureKeyCredential((string)connection.Credential!), options),
                CredentialKind.TokenCredential => new ChatCompletionsClient(uri, (TokenCredential)connection.Credential!, options),
                _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
            };
        }

        /// <summary>
        /// Gets the embeddings client.
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static EmbeddingsClient GetEmbeddingsClient(this ConnectionProvider provider, AzureAIInferenceClientOptions? options = null)
        {
            EmbeddingsClientKey embeddingsClientKey = new(options);
            EmbeddingsClient embeddingsClient = provider.Subclients.GetClient(embeddingsClientKey, () => CreateEmbeddingsClient(provider));
            return embeddingsClient;
        }

        private static EmbeddingsClient CreateEmbeddingsClient(this ConnectionProvider provider, AzureAIInferenceClientOptions? options = null)
        {
            ClientConnection connection = provider.GetConnection(typeof(ChatCompletionsClient).FullName!);

            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }

            return connection.CredentialKind switch
            {
                CredentialKind.ApiKeyString => new EmbeddingsClient(uri, new AzureKeyCredential((string)connection.Credential!), options),
                CredentialKind.TokenCredential => new EmbeddingsClient(uri, (TokenCredential)connection.Credential!, options),
                _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
            };
        }

        private record ChatCompletionsClientKey(AzureAIInferenceClientOptions? Options = null) : IEquatable<object>;

        private record EmbeddingsClientKey(AzureAIInferenceClientOptions? Options = null) : IEquatable<object>;
    }
}
