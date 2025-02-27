// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using Azure.AI.OpenAI;
using Azure.AI.Projects;
using Azure.Core;
using OpenAI.Chat;
using OpenAI.Embeddings;

namespace Azure.Projects.OpenAI;

/// <summary>
/// The Azure OpenAI extensions.
/// </summary>
public static class AzureOpenAIExtensions
{
    /// <summary>
    /// Gets the OpenAI chat client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <param name="deploymentName"></param>
    /// <returns></returns>
    public static ChatClient GetOpenAIChatClient(this ConnectionProvider workspace, string? deploymentName = null)
    {
        string name = deploymentName ?? "default";

        // TODO: nest the calls after new SCM merges
        AzureOpenAIClient aoiaClient = workspace.Subclients.GetClient(() => CreateAzureOpenAIClient(workspace));
        ChatClient chatClient = workspace.Subclients.GetClient(() =>
        {
            return workspace.CreateChatClient(aoiaClient, deploymentName);
        }, name);

        return chatClient;
    }

    /// <summary>
    /// Gets the OpenAI embeddings client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <param name="deploymentName"></param>
    /// <returns></returns>
    public static EmbeddingClient GetOpenAIEmbeddingsClient(this ConnectionProvider workspace, string? deploymentName = null)
    {
        string name = deploymentName ?? "default";

        // TODO: nest the calls after new SCM merges
        AzureOpenAIClient aoiaClient = workspace.Subclients.GetClient(() => CreateAzureOpenAIClient(workspace));
        EmbeddingClient embeddingsClient = workspace.Subclients.GetClient(() =>
        {
            return workspace.CreateEmbeddingsClient(aoiaClient, deploymentName);
        }, name);

        return embeddingsClient;
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

    private static AzureOpenAIClient CreateAzureOpenAIClient(this ConnectionProvider workspace)
    {
        ClientConnection connection = workspace.GetConnection(typeof(AzureOpenAIClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri? uri))
        {
            throw new InvalidOperationException("The connection is not a valid URI.");
        }

        if (connection.Authentication == ClientAuthenticationMethod.Credential)
        {
            return new(uri, (TokenCredential)connection.Credential!);
        }
        else
        {
            return new(uri, new ApiKeyCredential(connection.ApiKeyCredential!));
        }
    }

    private static ChatClient CreateChatClient(this ConnectionProvider workspace, AzureOpenAIClient client, string? deploymentName = null)
    {
        ClientConnection connection = workspace.GetConnection(typeof(ChatClient).FullName!);
        ChatClient chat = client.GetChatClient(deploymentName ?? connection.Locator);
        return chat;
    }

    private static EmbeddingClient CreateEmbeddingsClient(this ConnectionProvider workspace, AzureOpenAIClient client, string? deploymentName = null)
    {
        ClientConnection connection = workspace.GetConnection(typeof(EmbeddingClient).FullName!);
        EmbeddingClient embeddings = client.GetEmbeddingClient(deploymentName ?? connection.Locator);
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

    /// <summary>
    /// Adds a list of tool chat messages to the list of chat messages.
    /// </summary>
    /// <param name="messages"></param>
    /// <param name="toolCallResults"></param>
    public static void Add(this List<ChatMessage> messages, IEnumerable<ToolChatMessage> toolCallResults)
        => messages.AddRange(toolCallResults);
}
