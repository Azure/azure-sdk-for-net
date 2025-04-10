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
        ChatClient chatClient = provider.Subclients.GetClient(() =>
        {
            AzureOpenAIClient aoaiClient = provider.Subclients.GetClient(() => CreateAzureOpenAIClient(provider, options), new AzureOpenAIClientKey(options));
            return provider.CreateChatClient(aoaiClient, deploymentName);
        }, new ChatClientKey(deploymentName, options));

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
        EmbeddingClient embeddingClient = provider.Subclients.GetClient(() =>
        {
            AzureOpenAIClient aoaiClient = provider.Subclients.GetClient(() => CreateAzureOpenAIClient(provider, options), (IEquatable<object>)new AzureOpenAIClientKey(options));
            return provider.CreateEmbeddingClient(aoaiClient, deploymentName);
        }, new EmbeddingClientKey(deploymentName, options));

        return embeddingClient;
    }

    private static AzureOpenAIClient CreateAzureOpenAIClient(this ConnectionProvider provider, AzureOpenAIClientOptions? options = null)
    {
        ClientConnection connection = provider.GetConnection(typeof(AzureOpenAIClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }

        return connection.Authentication == ClientAuthenticationMethod.Credential
            ? new AzureOpenAIClient(uri, connection.Credential as TokenCredential, options)
            : new AzureOpenAIClient(uri, new ApiKeyCredential(connection.ApiKeyCredential!), options);
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
