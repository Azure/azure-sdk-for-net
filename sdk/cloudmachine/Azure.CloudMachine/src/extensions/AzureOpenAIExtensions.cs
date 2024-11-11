// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Collections.Generic;
using Azure.AI.OpenAI;
using Azure.Core;
using OpenAI.Chat;
using OpenAI.Embeddings;

namespace Azure.CloudMachine.OpenAI;

/// <summary>
/// The Azure OpenAI extensions.
/// </summary>
public static class AzureOpenAIExtensions
{
    /// <summary>
    /// Gets the OpenAI chat client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static ChatClient GetOpenAIChatClient(this ClientWorkspace workspace)
    {
        ChatClient chatClient = workspace.Subclients.Get(() =>
        {
            AzureOpenAIClient aoiaClient = workspace.Subclients.Get(() => CreateAzureOpenAIClient(workspace));
            return workspace.CreateChatClient(aoiaClient);
        });

        return chatClient;
    }

    /// <summary>
    /// Gets the OpenAI embeddings client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static EmbeddingClient GetOpenAIEmbeddingsClient(this ClientWorkspace workspace)
    {
        EmbeddingClient embeddingsClient = workspace.Subclients.Get(() =>
        {
            AzureOpenAIClient aoiaClient = workspace.Subclients.Get(() => CreateAzureOpenAIClient(workspace));
            return workspace.CreateEmbeddingsClient(aoiaClient);
        });

        return embeddingsClient;
    }

    private static AzureOpenAIClient CreateAzureOpenAIClient(this ClientWorkspace workspace)
    {
        ClientConnectionOptions connection = workspace.GetConnectionOptions(typeof(AzureOpenAIClient));
        if (connection.ConnectionKind == ClientConnectionKind.EntraId)
        {
            return new(connection.Endpoint, connection.TokenCredential);
        }
        else
        {
            return new(connection.Endpoint, new ApiKeyCredential(connection.ApiKeyCredential!));
        }
    }

    private static ChatClient CreateChatClient(this ClientWorkspace workspace, AzureOpenAIClient client)
    {
        ClientConnectionOptions connection = workspace.GetConnectionOptions(typeof(ChatClient));
        ChatClient chat = client.GetChatClient(connection.Id);
        return chat;
    }

    private static EmbeddingClient CreateEmbeddingsClient(this ClientWorkspace workspace, AzureOpenAIClient client)
    {
        ClientConnectionOptions connection = workspace.GetConnectionOptions(typeof(EmbeddingClient));
        EmbeddingClient embeddings = client.GetEmbeddingClient(connection.Id);
        return embeddings;
    }

    /// <summary>
    /// Trims list of chat messages.
    /// </summary>
    /// <param name="messages"></param>
    public static void Trim(this List<ChatMessage> messages)
    {
        messages.RemoveRange(0, messages.Count / 2);
    }

    /// <summary>
    /// Adds a list of vectorbase entries to the list of chat messages.
    /// </summary>
    /// <param name="messages"></param>
    /// <param name="entries"></param>
    public static void Add(this List<ChatMessage> messages, IEnumerable<VectorbaseEntry> entries)
    {
        foreach (VectorbaseEntry entry in entries)
        {
            messages.Add(ChatMessage.CreateSystemMessage(entry.Data.ToString()));
        }
    }

    /// <summary>
    /// Adds a chat completion as an AssistantChatMessage to the list of chat messages.
    /// </summary>
    /// <param name="messages"></param>
    /// <param name="completion"></param>
    public static void Add(this List<ChatMessage> messages, ChatCompletion completion)
        => messages.Add(ChatMessage.CreateAssistantMessage(completion));
}
