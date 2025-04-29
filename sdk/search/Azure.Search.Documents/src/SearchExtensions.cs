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
    /// <param name="options"></param>
    /// <returns></returns>
    public static SearchClient GetSearchClient(this ConnectionProvider provider, string indexName, SearchClientOptions? options = null)
    {
        SearchClientKey searchClientKey = new(indexName, options);
        SearchClient searchClient = provider.Subclients.GetClient(searchClientKey, () => CreateSearchClient(provider, indexName));
        return searchClient;
    }

    private static SearchClient CreateSearchClient(this ConnectionProvider provider, string indexName, SearchClientOptions? options = null)
    {
        ClientConnection connection = provider.GetConnection(typeof(SearchClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }

        return connection.CredentialKind switch
        {
            CredentialKind.ApiKeyString => new SearchClient(uri, indexName, new AzureKeyCredential((string)connection.Credential!), options),
            CredentialKind.TokenCredential => new SearchClient(uri, indexName, (TokenCredential)connection.Credential!, options),
            _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
        };
    }

    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static SearchIndexClient GetSearchIndexClient(this ConnectionProvider provider, SearchClientOptions? options = null)
    {
        SearchIndexClientKey searchIndexClientKey = new(options);
        SearchIndexClient searchIndexClient = provider.Subclients.GetClient(searchIndexClientKey, () => CreateSearchIndexClient(provider));
        return searchIndexClient;
    }

    private static SearchIndexClient CreateSearchIndexClient(this ConnectionProvider provider, SearchClientOptions? options = null)
    {
        ClientConnection connection = provider.GetConnection(typeof(SearchIndexClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }

        return connection.CredentialKind switch
        {
            CredentialKind.ApiKeyString => new SearchIndexClient(uri, new AzureKeyCredential((string)connection.Credential!), options),
            CredentialKind.TokenCredential => new SearchIndexClient(uri, (TokenCredential)connection.Credential!, options),
            _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
        };
    }

    /// <summary>
    /// Gets the search client.
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static SearchIndexerClient GetSearchIndexerClient(this ConnectionProvider provider, SearchClientOptions? options = null)
    {
        SearchIndexerClientKey searchIndexerClientKey = new(options);
        SearchIndexerClient searchIndexerClient = provider.Subclients.GetClient(searchIndexerClientKey, () => CreateSearchIndexerClient(provider));
        return searchIndexerClient;
    }

    private static SearchIndexerClient CreateSearchIndexerClient(this ConnectionProvider provider, SearchClientOptions? options = null)
    {
        ClientConnection connection = provider.GetConnection(typeof(SearchIndexClient).FullName!);

        if (!connection.TryGetLocatorAsUri(out Uri? uri) || uri is null)
        {
            throw new InvalidOperationException("Invalid URI.");
        }

        return connection.CredentialKind switch
        {
            CredentialKind.ApiKeyString => new SearchIndexerClient(uri, new AzureKeyCredential((string)connection.Credential!), options),
            CredentialKind.TokenCredential => new SearchIndexerClient(uri, (TokenCredential)connection.Credential!, options),
            _ => throw new InvalidOperationException($"Unsupported credential kind: {connection.CredentialKind}")
        };
    }

    private record SearchClientKey(string IndexName, SearchClientOptions? Options = null) : IEquatable<object>;

    private record SearchIndexClientKey(SearchClientOptions? Options = null) : IEquatable<object>;

    private record SearchIndexerClientKey(SearchClientOptions? Options = null) : IEquatable<object>;
}
