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
    public static ChatClient GetAzureOpenAIChatClient(this ClientConnectionProvider provider, string? deploymentName = null)
    {
        ChatClientKey chatClientKey = new(deploymentName);
        AzureOpenAIClientKey openAIClientKey = new();

        ChatClient chatClient = provider.Subclients.GetClient(chatClientKey, () =>
        {
            AzureOpenAIClient aoaiClient = provider.Subclients.GetClient(openAIClientKey, () => CreateAzureOpenAIClient(provider));
            return provider.CreateChatClient(aoaiClient, deploymentName);
        });

        return chatClient;
    }

    /// <summary>
    /// Gets the OpenAI embedding client.
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="deploymentName"></param>
    /// <returns></returns>
    public static EmbeddingClient GetAzureOpenAIEmbeddingClient(this ClientConnectionProvider provider, string? deploymentName = null)
    {
        EmbeddingClientKey embeddingClientKey = new(deploymentName);
        AzureOpenAIClientKey openAIClientKey = new();

        EmbeddingClient embeddingClient = provider.Subclients.GetClient(embeddingClientKey, () =>
        {
            AzureOpenAIClient aoaiClient = provider.Subclients.GetClient(openAIClientKey , () => CreateAzureOpenAIClient(provider));
            return provider.CreateEmbeddingClient(aoaiClient, deploymentName);
        });

        return embeddingClient;
    }

    private static AzureOpenAIClient CreateAzureOpenAIClient(this ClientConnectionProvider provider)
    {
        ClientConnection connection = provider.GetConnection(typeof(AzureOpenAIClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }

        return connection.CredentialKind switch
        {
            CredentialKind.ApiKeyString => new AzureOpenAIClient(uri, new ApiKeyCredential((string)connection.Credential!)),
            CredentialKind.TokenCredential => new AzureOpenAIClient(uri, (TokenCredential)connection.Credential!),
            _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
        };
    }

    private static ChatClient CreateChatClient(this ClientConnectionProvider provider, AzureOpenAIClient client, string? deploymentName = null)
    {
        ClientConnection connection = provider.GetConnection(typeof(ChatClient).FullName!);
        ChatClient chat = client.GetChatClient(deploymentName ?? connection.Locator);
        return chat;
    }

    private static EmbeddingClient CreateEmbeddingClient(this ClientConnectionProvider provider, AzureOpenAIClient client, string? deploymentName = null)
    {
        ClientConnection connection = provider.GetConnection(typeof(EmbeddingClient).FullName!);
        EmbeddingClient embedding = client.GetEmbeddingClient(deploymentName ?? connection.Locator);
        return embedding;
    }

    private record AzureOpenAIClientKey();

    private record ChatClientKey(string? DeploymentName);

    private record EmbeddingClientKey(string? DeploymentName);
}