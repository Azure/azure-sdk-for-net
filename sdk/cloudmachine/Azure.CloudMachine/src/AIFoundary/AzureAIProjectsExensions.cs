// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Inference;
using Azure.AI.Projects;
using Azure.Core;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;

namespace Azure.CloudMachine;

/// <summary>
/// The Azure AI Projects extensions.
/// </summary>
public static class AzureAIProjectsExensions
{
#region AIProjects
    /// <summary>
    /// Gets the agent client.BlobContainerClientBlobContainerClient
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static AgentsClient GetAgentsClient(this ClientWorkspace workspace)
    {
        AgentsClient agentsClient = workspace.Subclients.Get(() =>
        {
            AIProjectClient aiClient = workspace.Subclients.Get(() => CreateAzureAIClient(workspace));
            return aiClient.GetAgentsClient();
        });

        return agentsClient;
    }

    /// <summary>
    /// Gets the evaluation client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static EvaluationsClient GetEvaluationsClient(this ClientWorkspace workspace)
    {
        EvaluationsClient evaluationsClient = workspace.Subclients.Get(() =>
        {
            AIProjectClient aiClient = workspace.Subclients.Get(() => CreateAzureAIClient(workspace));
            return aiClient.GetEvaluationsClient();
        });

        return evaluationsClient;
    }

    private static AIProjectClient CreateAzureAIClient(this ClientWorkspace workspace)
    {
        ClientConnection connection = workspace.GetConnectionOptions(typeof(AIProjectClient).FullName);
        var connectionString = connection.Locator;
        return new AIProjectClient(connectionString, workspace.Credential);
    }
#endregion AIProjects

#region Inference
    /// <summary>
    /// Gets the chat completion client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static ChatCompletionsClient GetChatCompletionsClient(this ClientWorkspace workspace)
    {
        ChatCompletionsClient chatClient = workspace.Subclients.Get(() => CreateChatCompletionsClient(workspace));
        return chatClient;
    }

    private static ChatCompletionsClient CreateChatCompletionsClient(this ClientWorkspace workspace)
    {
        ClientConnection connection = workspace.GetConnectionOptions(typeof(ChatCompletionsClient).FullName);
        return new(connection.ToUri(), new AzureKeyCredential(connection.ApiKeyCredential!));
    }

    /// <summary>
    /// Gets the embeddings client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static EmbeddingsClient GetEmbeddingsClient(this ClientWorkspace workspace)
    {
        EmbeddingsClient embeddingsClient =  workspace.Subclients.Get(() => CreateEmbeddingsClient(workspace));
        return embeddingsClient;
    }

    private static EmbeddingsClient CreateEmbeddingsClient(this ClientWorkspace workspace)
    {
        ClientConnection connection = workspace.GetConnectionOptions(typeof(ChatCompletionsClient).FullName);
        return new(connection.ToUri(), new AzureKeyCredential(connection.ApiKeyCredential!));
    }
#endregion Inference

#region Azure AI Search
    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <param name="indexName"></param>
    /// <returns></returns>
    public static SearchClient GetSearchClient(this ClientWorkspace workspace, string indexName)
    {
        SearchClient searchClient = workspace.Subclients.Get(() => CreateSearchClient(workspace, indexName));
        return searchClient;
    }

    private static SearchClient CreateSearchClient(this ClientWorkspace workspace, string indexName)
    {
        ClientConnection connection = workspace.GetConnectionOptions(typeof(SearchClient).FullName);
        return new(connection.ToUri(), "indexName", new AzureKeyCredential(connection.ApiKeyCredential!));
    }

    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static SearchIndexClient GetSearchIndexClient(this ClientWorkspace workspace)
    {
        SearchIndexClient searchIndexClient = workspace.Subclients.Get(() => CreateSearchIndexClient(workspace));
        return searchIndexClient;
    }

    private static SearchIndexClient CreateSearchIndexClient(this ClientWorkspace workspace)
    {
        ClientConnection connection = workspace.GetConnectionOptions(typeof(SearchIndexClient).FullName);
        return new(connection.ToUri(), new AzureKeyCredential(connection.ApiKeyCredential!));
    }

    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static SearchIndexerClient GetSearchIndexerClient(this ClientWorkspace workspace)
    {
        SearchIndexerClient searchIndexerClient = workspace.Subclients.Get(() => CreateSearchIndexerClient(workspace));
        return searchIndexerClient;
    }

    private static SearchIndexerClient CreateSearchIndexerClient(this ClientWorkspace workspace)
    {
        ClientConnection connection = workspace.GetConnectionOptions(typeof(SearchIndexClient).FullName);
        return new(connection.ToUri(), new AzureKeyCredential(connection.ApiKeyCredential!));
    }
#endregion Azure AI Search
}
