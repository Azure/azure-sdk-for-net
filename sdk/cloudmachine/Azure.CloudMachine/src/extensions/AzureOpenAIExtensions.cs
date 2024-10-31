// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using Azure.AI.OpenAI;
using Azure.Core;
using OpenAI.Chat;
using OpenAI.Embeddings;

namespace Azure.CloudMachine.OpenAI;

public static class AzureOpenAIExtensions
{
    public static ChatClient GetOpenAIChatClient(this ClientWorkspace workspace)
    {
        ChatClient chatClient = workspace.Subclients.Get(() =>
        {
            AzureOpenAIClient aoiaClient = workspace.Subclients.Get(() => CreateAzureOpenAIClient(workspace));
            return workspace.CreateChatClient(aoiaClient);
        });

        return chatClient;
    }

    public static EmbeddingClient GetOpenAIEmbeddingsClient(this ClientWorkspace workspace)
    {
        EmbeddingClient embeddingsClient = workspace.Subclients.Get(() =>
        {
            AzureOpenAIClient aoiaClient = workspace.Subclients.Get(() => CreateAzureOpenAIClient(workspace));
            return workspace.CreateEmbeddingsClient(aoiaClient);
        });

        return embeddingsClient;
    }

    //public static EmbeddingKnowledgebase CreateEmbeddingKnowledgebase(this ClientWorkspace workspace)
    //{
    //    EmbeddingClient embeddingsClient = workspace.GetOpenAIEmbeddingsClient();
    //    return new EmbeddingKnowledgebase(embeddingsClient);
    //}

    //public static OpenAIConversation CreateOpenAIConversation(this ClientWorkspace workspace)
    //{
    //    ChatClient chatClient = workspace.GetOpenAIChatClient();
    //    EmbeddingKnowledgebase knowledgebase = workspace.CreateEmbeddingKnowledgebase();
    //    return new OpenAIConversation(chatClient, [], knowledgebase);
    //}

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
}
