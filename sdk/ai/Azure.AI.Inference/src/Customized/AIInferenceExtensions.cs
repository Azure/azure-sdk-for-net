// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="provider">The connection provider to get connections from.</param>
        /// <param name="connectionName">The name of the connection to be used.</param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <returns></returns>
        public static ChatCompletionsClient GetChatCompletionsClient(this ConnectionProvider provider, string? connectionName=default, AzureAIInferenceClientOptions? options = default)
        {
            ChatCompletionsClient chatClient = provider.Subclients.GetClient(() => CreateChatCompletionsClient(provider, connectionName, options), null);
            return chatClient;
        }

        private static ChatCompletionsClient CreateChatCompletionsClient(this ConnectionProvider provider, string? connectionName, AzureAIInferenceClientOptions? options)
        {
            ClientConnection connection = GetConnnectionByNameOrDefault(provider, connectionName, typeof(ChatCompletionsClient).FullName!);

            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }
            return connection.Authentication == ClientAuthenticationMethod.Credential
            ? new ChatCompletionsClient(uri, connection.Credential as TokenCredential, ["https://cognitiveservices.azure.com/.default"], options)
            : new ChatCompletionsClient(uri, new AzureKeyCredential(connection.ApiKeyCredential!), options);
        }

        /// <summary>
        /// Get the default connection if connectionName is null and get connection with given name otherwise.
        /// If no Connections with the given name were found, Throw InvalidOperationException.
        /// </summary>
        /// <param name="provider">The connection provider to be extended by this method.</param>
        /// <param name="connectionName">The name of connection to search for</param>
        /// <param name="connectionType">The type of a connection; ignored if connectionName is set.</param>
        /// <returns></returns>
        private static ClientConnection GetConnnectionByNameOrDefault(this ConnectionProvider provider, string? connectionName, string connectionType)
        {
            ClientConnection connection = default;
            if (string.IsNullOrEmpty(connectionName))
            {
                // Get Default connection for given service type.
                connection = provider.GetConnection(connectionType);
            }
            else
            {
                IEnumerable<ClientConnection> conns = provider.GetAllConnections().Where(
                    conn => string.Equals(conn.Id, connectionName, StringComparison.Ordinal)).Take(1);
                if (!conns.Any())
                {
                    throw new InvalidOperationException($"No connections with name {connectionName} were found.");
                }
                connection = conns.FirstOrDefault();
            }
            return connection;
        }

        /// <summary>
        /// Gets the embeddings client.
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="connectionName">The name of the connection to be used.</param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <returns></returns>
        public static EmbeddingsClient GetEmbeddingsClient(this ConnectionProvider provider, string? connectionName = default, AzureAIInferenceClientOptions? options = default)
        {
            EmbeddingsClient embeddingsClient = provider.Subclients.GetClient(() => CreateEmbeddingsClient(provider, connectionName, options), null);
            return embeddingsClient;
        }

        private static EmbeddingsClient CreateEmbeddingsClient(this ConnectionProvider provider, string? connectionName, AzureAIInferenceClientOptions? options)
        {
            ClientConnection connection = GetConnnectionByNameOrDefault(provider, connectionName, typeof(EmbeddingsClient).FullName!);
            if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
            {
                throw new InvalidOperationException("Invalid URI.");
            }
            return connection.Authentication == ClientAuthenticationMethod.Credential
            ? new EmbeddingsClient(uri, connection.Credential as TokenCredential, ["https://cognitiveservices.azure.com/.default"], options)
            : new EmbeddingsClient(uri, new AzureKeyCredential(connection.ApiKeyCredential!), options);
        }
    }
}
