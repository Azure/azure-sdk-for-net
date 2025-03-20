// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.Core;

namespace Azure.AI.OpenAI;

/// <summary>
/// The Azure OpenAI extensions.
/// </summary>
public static class AzureOpenAIExtensions
{
    /// <summary>
    /// Gets the OpenAI chat client.
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="deploymentName"></param>
    /// <returns></returns>
    public static ChatClient GetAzureOpenAIChatClient(this ConnectionProvider provider, string? deploymentName = null)
    {
        ChatClient chatClient = provider.Subclients.GetClient(() =>
        {
            AzureOpenAIClient aoaiClient = provider.Subclients.GetClient(() => CreateAzureOpenAIClient(provider), null);
            return provider.CreateChatClient(aoaiClient, deploymentName);
        }, deploymentName);

        return chatClient;
    }

    /// <summary>
    /// Gets the OpenAI embedding client.
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="deploymentName"></param>
    /// <returns></returns>
    public static EmbeddingClient GetAzureOpenAIEmbeddingClient(this ConnectionProvider provider, string? deploymentName = null)
    {
        EmbeddingClient embeddingClient = provider.Subclients.GetClient(() =>
        {
            AzureOpenAIClient aoaiClient = provider.Subclients.GetClient(() => CreateAzureOpenAIClient(provider), null);
            return provider.CreateEmbeddingClient(aoaiClient, deploymentName);
        }, deploymentName);

        return embeddingClient;
    }

    private static AzureOpenAIClient CreateAzureOpenAIClient(this ConnectionProvider provider)
    {
        ClientConnection connection = provider.GetConnection(typeof(AzureOpenAIClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }

        return connection.Authentication == ClientAuthenticationMethod.Credential
            ? new AzureOpenAIClient(uri, connection.Credential as TokenCredential)
            : new AzureOpenAIClient(uri, new ApiKeyCredential(connection.ApiKeyCredential!));
    }

    private static ChatClient CreateChatClient(this ConnectionProvider provider, AzureOpenAIClient client, string? deploymentName = null)
    {
        ClientConnection connection = provider.GetConnection(typeof(ChatClient).FullName!);
        ChatClient chat = client.GetChatClient(deploymentName ?? connection.Locator);
        return chat;
    }

    private static EmbeddingClient CreateEmbeddingClient(this ConnectionProvider provider, AzureOpenAIClient client, string? deploymentName = null)
    {
        ClientConnection connection = provider.GetConnection(typeof(EmbeddingClient).FullName!);
        EmbeddingClient embedding = client.GetEmbeddingClient(deploymentName ?? connection.Locator);
        return embedding;
    }
}
