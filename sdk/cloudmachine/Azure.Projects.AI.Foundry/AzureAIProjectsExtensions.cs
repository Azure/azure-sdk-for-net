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
    private static AIProjectClient CreateAzureAIClient(this ClientConnectionProvider workspace)
    {
        ClientConnection connection = workspace.GetConnection(typeof(AIProjectClient).FullName);
        if (!connection.TryGetLocatorAsUri(out Uri uri))
        {
            throw new InvalidOperationException("The AIProjectClient connection locator is not a valid URI.");
        }
        return new AIProjectClient(uri, (TokenCredential)connection.Credential);
    }
#endregion AIProjects

#region Inference
    /// <summary>
    /// Gets the chat completion client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static ChatCompletionsClient GetChatCompletionsClient(this ClientConnectionProvider workspace)
    {
        ChatCompletionsClient chatClient = workspace.Subclients.GetClient<ChatCompletionsClient>(null, () => CreateChatCompletionsClient(workspace));
        return chatClient;
    }

    private static ChatCompletionsClient CreateChatCompletionsClient(this ClientConnectionProvider workspace)
    {
        ClientConnection connection = workspace.GetConnection(typeof(ChatCompletionsClient).FullName);

        if (!connection.TryGetLocatorAsUri(out Uri uri))
        {
            throw new InvalidOperationException("The connection is not a valid URI.");
        }

        if (connection.CredentialKind != CredentialKind.ApiKeyString || connection.Credential is not string apiKey)
        {
            throw new InvalidOperationException("The connection does not contain a valid API key credential.");
        }

        return new(uri, new AzureKeyCredential(apiKey));
    }

    /// <summary>
    /// Gets the embeddings client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static EmbeddingsClient GetEmbeddingsClient(this ClientConnectionProvider workspace)
    {
        EmbeddingsClient embeddingsClient =  workspace.Subclients.GetClient<EmbeddingsClient>(null, () => CreateEmbeddingsClient(workspace));
        return embeddingsClient;
    }

    private static EmbeddingsClient CreateEmbeddingsClient(this ClientConnectionProvider workspace)
    {
        ClientConnection connection = workspace.GetConnection(typeof(EmbeddingsClient).FullName);

        if (!connection.TryGetLocatorAsUri(out Uri uri))
        {
            throw new InvalidOperationException("The connection is not a valid URI.");
        }

        if (connection.CredentialKind != CredentialKind.ApiKeyString || connection.Credential is not string apiKey)
        {
            throw new InvalidOperationException("The connection does not contain a valid API key credential.");
        }

        return new(uri, new AzureKeyCredential(apiKey));
    }
#endregion Inference

#region Azure AI Search
    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <param name="indexName"></param>
    /// <returns></returns>
    public static SearchClient GetSearchClient(this ClientConnectionProvider workspace, string indexName)
    {
        SearchClient searchClient = workspace.Subclients.GetClient<SearchClient>(indexName, () => CreateSearchClient(workspace, indexName));
        return searchClient;
    }

    private static SearchClient CreateSearchClient(this ClientConnectionProvider workspace, string indexName)
    {
        ClientConnection connection = workspace.GetConnection(typeof(SearchClient).FullName);

        if (!connection.TryGetLocatorAsUri(out Uri uri))
        {
            throw new InvalidOperationException("The connection is not a valid URI.");
        }

        if (connection.CredentialKind != CredentialKind.ApiKeyString || connection.Credential is not string apiKey)
        {
            throw new InvalidOperationException("The connection does not contain a valid API key credential.");
        }

        return new(uri, indexName, new AzureKeyCredential(apiKey));
    }

    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static SearchIndexClient GetSearchIndexClient(this ClientConnectionProvider workspace)
    {
        SearchIndexClient searchIndexClient = workspace.Subclients.GetClient<SearchIndexClient>(null, () => CreateSearchIndexClient(workspace));
        return searchIndexClient;
    }

    private static SearchIndexClient CreateSearchIndexClient(this ClientConnectionProvider workspace)
    {
        ClientConnection connection = workspace.GetConnection(typeof(SearchIndexClient).FullName);

        if (!connection.TryGetLocatorAsUri(out Uri uri))
        {
            throw new InvalidOperationException("The connection is not a valid URI.");
        }

        if (connection.CredentialKind != CredentialKind.ApiKeyString || connection.Credential is not string apiKey)
        {
            throw new InvalidOperationException("The connection does not contain a valid API key credential.");
        }

        return new(uri, new AzureKeyCredential(apiKey));
    }

    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="workspace"></param>
    /// <returns></returns>
    public static SearchIndexerClient GetSearchIndexerClient(this ClientConnectionProvider workspace)
    {
        SearchIndexerClient searchIndexerClient = workspace.Subclients.GetClient<SearchIndexerClient>(null, () => CreateSearchIndexerClient(workspace));
        return searchIndexerClient;
    }

    private static SearchIndexerClient CreateSearchIndexerClient(this ClientConnectionProvider workspace)
    {
        ClientConnection connection = workspace.GetConnection(typeof(SearchIndexerClient).FullName);

        if (!connection.TryGetLocatorAsUri(out Uri uri))
        {
            throw new InvalidOperationException("The connection is not a valid URI.");
        }

        if (connection.CredentialKind != CredentialKind.ApiKeyString || connection.Credential is not string apiKey)
        {
            throw new InvalidOperationException("The connection does not contain a valid API key credential.");
        }

        return new(uri, new AzureKeyCredential(apiKey));
    }
#endregion Azure AI Search
}
