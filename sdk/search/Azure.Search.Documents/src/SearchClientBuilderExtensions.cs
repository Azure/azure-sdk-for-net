// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Extensions;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="SearchClient"/> to the Azure client
    /// builder.
    /// </summary>
    [CodeGenType("DocumentsClientBuilderExtensions")]
    // These signatures remain on the compatibility type to avoid adding duplicate extension candidates.
    [CodeGenSuppress(nameof(AddSearchClient), typeof(IAzureClientFactoryBuilderWithCredential), typeof(Uri), typeof(string))]
    [CodeGenSuppress(nameof(AddSearchIndexClient), typeof(IAzureClientFactoryBuilderWithCredential), typeof(Uri))]
    [CodeGenSuppress(nameof(AddSearchIndexerClient), typeof(IAzureClientFactoryBuilderWithCredential), typeof(Uri))]
    public static partial class SearchClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="SearchClient"/> instance with the provided
        /// <paramref name="endpoint"/>, <paramref name="indexName"/>, and
        /// <paramref name="credential"/>.
        /// </summary>
        /// <typeparam name="TBuilder">Type of the client factory builder.</typeparam>
        /// <param name="builder">The client factory builder.</param>
        /// <param name="endpoint">
        /// Required. The URI endpoint of the Search Service. This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// The URI must use HTTPS.
        /// </param>
        /// <param name="indexName">Required. The name of the Search Index.</param>
        /// <param name="credential">
        /// Required. The token credential used to authenticate requests
        /// against the search service.
        /// </param>
        /// <returns>An Azure client builder.</returns>
        public static IAzureClientBuilder<SearchClient, SearchClientOptions> AddSearchClient<TBuilder>(
            this TBuilder builder,
            Uri endpoint,
            string indexName,
            TokenCredential credential)
            where TBuilder : IAzureClientFactoryBuilder =>
            builder.RegisterClientFactory<SearchClient, SearchClientOptions>(
                options => new SearchClient(endpoint, indexName, credential, options));

        /// <summary>
        /// Registers a <see cref="SearchIndexClient"/> instance with the
        /// provided <paramref name="endpoint"/> and <paramref name="credential"/>.
        /// </summary>
        /// <typeparam name="TBuilder">Type of the client factory builder.</typeparam>
        /// <param name="builder">The client factory builder.</param>
        /// <param name="endpoint">
        /// Required. The URI endpoint of the Search Service. This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// The URI must use HTTPS.
        /// </param>
        /// <param name="credential">
        /// Required. The token credential used to authenticate requests
        /// against the search service.
        /// </param>
        /// <returns>An Azure client builder.</returns>
        public static IAzureClientBuilder<SearchIndexClient, SearchClientOptions> AddSearchIndexClient<TBuilder>(
            this TBuilder builder,
            Uri endpoint,
            TokenCredential credential)
            where TBuilder : IAzureClientFactoryBuilder =>
            builder.RegisterClientFactory<SearchIndexClient, SearchClientOptions>(
                options => new SearchIndexClient(endpoint, credential, options));

        /// <summary>
        /// Registers a <see cref="SearchIndexerClient"/> instance with the
        /// provided <paramref name="endpoint"/> and <paramref name="credential"/>.
        /// </summary>
        /// <typeparam name="TBuilder">Type of the client factory builder.</typeparam>
        /// <param name="builder">The client factory builder.</param>
        /// <param name="endpoint">
        /// Required. The URI endpoint of the Search Service. This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// The URI must use HTTPS.
        /// </param>
        /// <param name="credential">
        /// Required. The token credential used to authenticate requests
        /// against the search service.
        /// </param>
        /// <returns>An Azure client builder.</returns>
        public static IAzureClientBuilder<SearchIndexerClient, SearchClientOptions> AddSearchIndexerClient<TBuilder>(
            this TBuilder builder,
            Uri endpoint,
            TokenCredential credential)
            where TBuilder : IAzureClientFactoryBuilder =>
            builder.RegisterClientFactory<SearchIndexerClient, SearchClientOptions>(
                options => new SearchIndexerClient(endpoint, credential, options));
    }
}
