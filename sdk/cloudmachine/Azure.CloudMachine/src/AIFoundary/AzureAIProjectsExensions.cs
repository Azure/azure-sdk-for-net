// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Inference;
using Azure.AI.Projects;
using Azure.Core;
using Azure.Search.Documents;

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
        AgentsClient agentsClient = workspace.Subclients.Get(() => CreateAgentsClient(workspace));
        return agentsClient;
    }

    private static AgentsClient CreateAgentsClient(this ClientWorkspace workspace)
    {
        ClientConnection connection = workspace.GetConnectionOptions(typeof(AgentsClient).FullName);
        var connectionString = connection.Locator;
        return new AgentsClient(connectionString, workspace.Credential);
    }

    /// <summary>
    /// Gets the evaluation client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static EvaluationsClient GetEvaluationsClient(this ClientWorkspace workspace)
    {
        EvaluationsClient evaluationsClient = workspace.Subclients.Get(() => CreateEvaluationsClient(workspace));
        return evaluationsClient;
    }

    private static EvaluationsClient CreateEvaluationsClient(this ClientWorkspace workspace)
    {
        ClientConnection connection = workspace.GetConnectionOptions(typeof(EvaluationsClient).FullName);
        var connectionString = connection.Locator;
        return new EvaluationsClient(connectionString, workspace.Credential);
    }
#endregion AIProjects

#region Inference
    /// <summary>
    /// Gets the chat completion client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static ChatCompletionsClient GetInferenceChatCompletionsClient(this ClientWorkspace workspace)
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
    public static EmbeddingsClient GetInferenceEmbeddingsClient(this ClientWorkspace workspace)
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
    #endregion Inference
}
