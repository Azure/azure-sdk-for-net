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
    public static SearchClient GetSearchClient(this ClientConnectionProvider provider, string indexName)
    {
        SearchClientKey searchClientKey = new(indexName);
        SearchClient searchClient = provider.Subclients.GetClient(searchClientKey, () => CreateSearchClient(provider, indexName));
        return searchClient;
    }

    private static SearchClient CreateSearchClient(this ClientConnectionProvider provider, string indexName)
    {
        ClientConnection connection = provider.GetConnection(typeof(SearchClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }

        return connection.CredentialKind switch
        {
            CredentialKind.ApiKeyString => new SearchClient(uri, indexName, new AzureKeyCredential((string)connection.Credential!)),
            CredentialKind.TokenCredential => new SearchClient(uri, indexName, (TokenCredential)connection.Credential!),
            _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
        };
    }

    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static SearchIndexClient GetSearchIndexClient(this ClientConnectionProvider provider)
    {
        SearchIndexClientKey searchIndexClientKey = new();
        SearchIndexClient searchIndexClient = provider.Subclients.GetClient(searchIndexClientKey, () => CreateSearchIndexClient(provider));
        return searchIndexClient;
    }

    private static SearchIndexClient CreateSearchIndexClient(this ClientConnectionProvider provider)
    {
        ClientConnection connection = provider.GetConnection(typeof(SearchIndexClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }

        return connection.CredentialKind switch
        {
            CredentialKind.ApiKeyString => new SearchIndexClient(uri, new AzureKeyCredential((string)connection.Credential!)),
            CredentialKind.TokenCredential => new SearchIndexClient(uri, (TokenCredential)connection.Credential!),
            _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
        };
    }

    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static SearchIndexerClient GetSearchIndexerClient(this ClientConnectionProvider provider)
    {
        SearchIndexerClientKey searchIndexerClientKey = new();
        SearchIndexerClient searchIndexerClient = provider.Subclients.GetClient(searchIndexerClientKey, () => CreateSearchIndexerClient(provider));
        return searchIndexerClient;
    }

    private static SearchIndexerClient CreateSearchIndexerClient(this ClientConnectionProvider provider)
    {
        ClientConnection connection = provider.GetConnection(typeof(SearchIndexClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }

        return connection.CredentialKind switch
        {
            CredentialKind.ApiKeyString => new SearchIndexerClient(uri, new AzureKeyCredential((string)connection.Credential!)),
            CredentialKind.TokenCredential => new SearchIndexerClient(uri, (TokenCredential)connection.Credential!),
            _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
        };
    }

    private record SearchClientKey(string IndexName);

    private record SearchIndexClientKey();

    private record SearchIndexerClientKey();
}
