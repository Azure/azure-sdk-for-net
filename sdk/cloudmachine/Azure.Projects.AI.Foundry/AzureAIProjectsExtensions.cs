// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.AI.Inference;
using Azure.AI.Projects;
using Azure.Core;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;

namespace Azure.Projects;

/// <summary>
/// The Azure AI Projects extensions.
/// </summary>
public static class AzureAIProjectsExtensions
{
#region AIProjects
    /// <summary>
    /// Gets the agent client.BlobContainerClientBlobContainerClient
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static Azure.AI.Projects.AgentsClient GetAgentsClient(this ConnectionProvider workspace)
    {
        Azure.AI.Projects.AgentsClient agentsClient = workspace.Subclients.GetClient(() =>
        {
            AIProjectClient aiClient = workspace.Subclients.GetClient(() => CreateAzureAIClient(workspace), null);
            ClientConnection connection = workspace.GetConnection(typeof(AgentsClient).FullName);
            var agentsClient = new AgentsClient(connection.Locator, (TokenCredential)connection.Credential);
            return agentsClient;
        }, null);

        return agentsClient;
    }

    /// <summary>
    /// Gets the evaluation client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static EvaluationsClient GetEvaluationsClient(this ConnectionProvider workspace)
    {
        EvaluationsClient evaluationsClient = workspace.Subclients.GetClient(() =>
        {
            AIProjectClient aiClient = workspace.Subclients.GetClient(() => CreateAzureAIClient(workspace), null);
            return aiClient.GetEvaluationsClient();
        }, null);

        return evaluationsClient;
    }

    private static AIProjectClient CreateAzureAIClient(this ConnectionProvider workspace)
    {
        ClientConnection connection = workspace.GetConnection(typeof(AIProjectClient).FullName);
        var connectionString = connection.Locator;
        return new AIProjectClient(connectionString, (TokenCredential)connection.Credential);
    }
#endregion AIProjects

#region Inference
    /// <summary>
    /// Gets the chat completion client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static ChatCompletionsClient GetChatCompletionsClient(this ConnectionProvider workspace)
    {
        ChatCompletionsClient chatClient = workspace.Subclients.GetClient(() => CreateChatCompletionsClient(workspace), null);
        return chatClient;
    }

    private static ChatCompletionsClient CreateChatCompletionsClient(this ConnectionProvider workspace)
    {
        ClientConnection connection = workspace.GetConnection(typeof(ChatCompletionsClient).FullName);

        if (!connection.TryGetLocatorAsUri(out Uri uri))
        {
            throw new InvalidOperationException("The connection is not a valid URI.");
        }

        return new(uri, new AzureKeyCredential(connection.ApiKeyCredential!));
    }

    /// <summary>
    /// Gets the embeddings client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static EmbeddingsClient GetEmbeddingsClient(this ConnectionProvider workspace)
    {
        EmbeddingsClient embeddingsClient =  workspace.Subclients.GetClient(() => CreateEmbeddingsClient(workspace), null);
        return embeddingsClient;
    }

    private static EmbeddingsClient CreateEmbeddingsClient(this ConnectionProvider workspace)
    {
        ClientConnection connection = workspace.GetConnection(typeof(ChatCompletionsClient).FullName);

        if (!connection.TryGetLocatorAsUri(out Uri uri))
        {
            throw new InvalidOperationException("The connection is not a valid URI.");
        }

        return new(uri, new AzureKeyCredential(connection.ApiKeyCredential!));
    }
#endregion Inference

#region Azure AI Search
    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <param name="indexName"></param>
    /// <returns></returns>
    public static SearchClient GetSearchClient(this ConnectionProvider workspace, string indexName)
    {
        SearchClient searchClient = workspace.Subclients.GetClient(() => CreateSearchClient(workspace, indexName), indexName);
        return searchClient;
    }

    private static SearchClient CreateSearchClient(this ConnectionProvider workspace, string indexName)
    {
        ClientConnection connection = workspace.GetConnection(typeof(SearchClient).FullName);

        if (!connection.TryGetLocatorAsUri(out Uri uri))
        {
            throw new InvalidOperationException("The connection is not a valid URI.");
        }

        return new(uri, indexName, new AzureKeyCredential(connection.ApiKeyCredential!));
    }

    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static SearchIndexClient GetSearchIndexClient(this ConnectionProvider workspace)
    {
        SearchIndexClient searchIndexClient = workspace.Subclients.GetClient(() => CreateSearchIndexClient(workspace), null);
        return searchIndexClient;
    }

    private static SearchIndexClient CreateSearchIndexClient(this ConnectionProvider workspace)
    {
        ClientConnection connection = workspace.GetConnection(typeof(SearchIndexClient).FullName);

        if (!connection.TryGetLocatorAsUri(out Uri uri))
        {
            throw new InvalidOperationException("The connection is not a valid URI.");
        }

        return new(uri, new AzureKeyCredential(connection.ApiKeyCredential!));
    }

    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static SearchIndexerClient GetSearchIndexerClient(this ConnectionProvider workspace)
    {
        SearchIndexerClient searchIndexerClient = workspace.Subclients.GetClient(() => CreateSearchIndexerClient(workspace), null);
        return searchIndexerClient;
    }

    private static SearchIndexerClient CreateSearchIndexerClient(this ConnectionProvider workspace)
    {
        ClientConnection connection = workspace.GetConnection(typeof(SearchIndexClient).FullName);

        if (!connection.TryGetLocatorAsUri(out Uri uri))
        {
            throw new InvalidOperationException("The connection is not a valid URI.");
        }

        return new(uri, new AzureKeyCredential(connection.ApiKeyCredential!));
    }
#endregion Azure AI Search
}
