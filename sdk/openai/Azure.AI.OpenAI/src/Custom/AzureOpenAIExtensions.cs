// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text;
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
    public static ChatClient GetOpenAIChatClient(this ConnectionProvider provider, string? deploymentName = null)
    {
        string name = deploymentName ?? "default";

        ChatClient chatClient = provider.Subclients.GetClient(() =>
        {
            AzureOpenAIClient aoiaClient = provider.Subclients.GetClient(() => CreateAzureOpenAIClient(provider));
            return provider.CreateChatClient(aoiaClient, deploymentName);
        }, name);

        return chatClient;
    }

    /// <summary>
    /// Gets the OpenAI embeddings client.
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="deploymentName"></param>
    /// <returns></returns>
    public static EmbeddingClient GetOpenAIEmbeddingsClient(this ConnectionProvider provider, string? deploymentName = null)
    {
        string name = deploymentName ?? "default";

        EmbeddingClient embeddingsClient = provider.Subclients.GetClient(() =>
        {
            AzureOpenAIClient aoiaClient = provider.Subclients.GetClient(() => CreateAzureOpenAIClient(provider));
            return provider.CreateEmbeddingsClient(aoiaClient, deploymentName);
        }, name);

        return embeddingsClient;
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

    private static EmbeddingClient CreateEmbeddingsClient(this ConnectionProvider provider, AzureOpenAIClient client, string? deploymentName = null)
    {
        ClientConnection connection = provider.GetConnection(typeof(EmbeddingClient).FullName!);
        EmbeddingClient embeddings = client.GetEmbeddingClient(deploymentName ?? connection.Locator);
        return embeddings;
    }

    /// <summary>
    /// returns full text of all parts.
    /// </summary>
    /// <returns></returns>
    public static string AsText(this ClientResult<ChatCompletion> completionResult)
        => AsText(completionResult.Value);

    /// <summary>
    /// returns full text of all parts.
    /// </summary>
    /// <param name="completion"></param>
    /// <returns></returns>
    public static string AsText(this ChatCompletion completion)
        => completion.Content.AsText();

    /// <summary>
    /// returns full text of all parts.
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static string AsText(this ChatMessageContent content)
    {
        StringBuilder sb = new();
        foreach (ChatMessageContentPart part in content)
        {
            switch (part.Kind)
            {
                case ChatMessageContentPartKind.Text:
                    sb.AppendLine(part.Text);
                    break;
                default:
                    sb.AppendLine($"<{part.Kind}>");
                    break;
            }
        }
        return sb.ToString();
    }
}
