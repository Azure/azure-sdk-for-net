// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using Azure.Core;
using Azure.Search.Documents.Indexes;

namespace Azure.Search.Documents;

/// <summary>
/// The Azure OpenAI extensions.
/// </summary>
public static class SearchExtensions
{
    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="indexName"></param>
    /// <returns></returns>
    public static SearchClient GetSearchClient(this ConnectionProvider provider, string indexName)
    {
        SearchClient searchClient = provider.Subclients.GetClient(() => CreateSearchClient(provider, indexName), indexName);
        return searchClient;
    }

    private static SearchClient CreateSearchClient(this ConnectionProvider provider, string indexName)
    {
        ClientConnection connection = provider.GetConnection(typeof(SearchClient).FullName!);
        if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }
        return connection.Authentication == ClientAuthenticationMethod.Credential
            ? new SearchClient(uri, indexName, connection.Credential as TokenCredential)
            : new SearchClient(uri, indexName, new AzureKeyCredential(connection.ApiKeyCredential!));
    }

    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static SearchIndexClient GetSearchIndexClient(this ConnectionProvider provider)
    {
        SearchIndexClient searchIndexClient = provider.Subclients.GetClient(() => CreateSearchIndexClient(provider), null);
        return searchIndexClient;
    }

    private static SearchIndexClient CreateSearchIndexClient(this ConnectionProvider provider)
    {
        ClientConnection connection = provider.GetConnection(typeof(SearchIndexClient).FullName!);
        if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }
        return connection.Authentication == ClientAuthenticationMethod.Credential
            ? new SearchIndexClient(uri, connection.Credential as TokenCredential)
            : new SearchIndexClient(uri, new AzureKeyCredential(connection.ApiKeyCredential!));
    }

    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static SearchIndexerClient GetSearchIndexerClient(this ConnectionProvider provider)
    {
        SearchIndexerClient searchIndexerClient = provider.Subclients.GetClient(() => CreateSearchIndexerClient(provider), null);
        return searchIndexerClient;
    }

    private static SearchIndexerClient CreateSearchIndexerClient(this ConnectionProvider provider)
    {
        ClientConnection connection = provider.GetConnection(typeof(SearchIndexClient).FullName!);
        if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }
        return connection.Authentication == ClientAuthenticationMethod.Credential
            ? new SearchIndexerClient(uri, connection.Credential as TokenCredential)
            : new SearchIndexerClient(uri, new AzureKeyCredential(connection.ApiKeyCredential!));
    }
}
