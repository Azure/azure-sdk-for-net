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
    /// <param name="options"></param>
    /// <returns></returns>
    public static ChatClient GetAzureOpenAIChatClient(this ConnectionProvider provider, string? deploymentName = null, AzureOpenAIClientOptions? options = null)
    {
        ChatClientKey chatClientKey = new(deploymentName, options);
        AzureOpenAIClientKey openAIClientKey = new(options);

        ChatClient chatClient = provider.Subclients.GetClient(chatClientKey, () =>
        {
            AzureOpenAIClient aoaiClient = provider.Subclients.GetClient(openAIClientKey, () => CreateAzureOpenAIClient(provider, options));
            return provider.CreateChatClient(aoaiClient, deploymentName);
        });

        return chatClient;
    }

    /// <summary>
    /// Gets the OpenAI embedding client.
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="deploymentName"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static EmbeddingClient GetAzureOpenAIEmbeddingClient(this ConnectionProvider provider, string? deploymentName = null, AzureOpenAIClientOptions? options = null)
    {
        EmbeddingClientKey embeddingClientKey = new(deploymentName, options);
        AzureOpenAIClientKey openAIClientKey = new(options);

        EmbeddingClient embeddingClient = provider.Subclients.GetClient(embeddingClientKey, () =>
        {
            AzureOpenAIClient aoaiClient = provider.Subclients.GetClient(openAIClientKey , () => CreateAzureOpenAIClient(provider, options));
            return provider.CreateEmbeddingClient(aoaiClient, deploymentName);
        });

        return embeddingClient;
    }

    private static AzureOpenAIClient CreateAzureOpenAIClient(this ConnectionProvider provider, AzureOpenAIClientOptions? options = null)
    {
        ClientConnection connection = provider.GetConnection(typeof(AzureOpenAIClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }

        return connection.CredentialKind switch
        {
            CredentialKind.ApiKeyString => new AzureOpenAIClient(uri, new ApiKeyCredential((string)connection.Credential!), options),
            CredentialKind.TokenCredential => new AzureOpenAIClient(uri, (TokenCredential)connection.Credential!, options),
            _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
        };
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

    private record AzureOpenAIClientKey(AzureOpenAIClientOptions? Options) : IEquatable<object>;

    private record ChatClientKey(string? DeploymentName, AzureOpenAIClientOptions? Options) : IEquatable<object>;

    private record EmbeddingClientKey(string? DeploymentName, AzureOpenAIClientOptions? Options) : IEquatable<object>;
}
