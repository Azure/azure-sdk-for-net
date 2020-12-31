// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.Core.Extensions;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="SearchClient"/> to the Azure client
    /// builder.
    /// </summary>
    public static class SearchClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="SearchClient"/> instance with the provided
        /// <paramref name="endpoint"/>, <paramref name="indexName"/>, and
        /// <paramref name="credential"/>.
        /// </summary>
        /// <typeparam name="TBuilder">Type of the client factory builder.</typeparam>
        /// <param name="builder">The client factory builder.</param>
        /// <param name="endpoint">
        /// Required.  The URI endpoint of the Search Service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// The URI must use HTTPS.
        /// </param>
        /// <param name="indexName">
        /// Required.  The name of the Search Index.
        /// </param>
        /// <param name="credential">
        /// Required.  The API key credential used to authenticate requests
        /// against the search service.  You need to use an admin key to
        /// modify the documents in a Search Index.  See
        /// <see href="https://docs.microsoft.com/azure/search/search-security-api-keys">Create and manage api-keys for an Azure Cognitive Search service</see>
        /// for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <returns>An Azure client builder.</returns>
        public static IAzureClientBuilder<SearchClient, SearchClientOptions> AddSearchClient<TBuilder>(
            this TBuilder builder,
            Uri endpoint,
            string indexName,
            AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder =>
            builder.RegisterClientFactory<SearchClient, SearchClientOptions>(
                options => new SearchClient(endpoint, indexName, credential, options));

        /// <summary>
        /// Registers a <see cref="SearchClient"/> instance with connection
        /// options loaded from the provided <paramref name="configuration"/>
        /// instance.
        /// </summary>
        /// <typeparam name="TBuilder">Type of the client factory builder.</typeparam>
        /// <typeparam name="TConfiguration">Type of the configuration.</typeparam>
        /// <param name="builder">The client factory builder.</param>
        /// <param name="configuration">The client configuration.</param>
        /// <returns>An Azure client builder.</returns>
        public static IAzureClientBuilder<SearchClient, SearchClientOptions> AddSearchClient<TBuilder, TConfiguration>(
            this TBuilder builder,
            TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration> =>
            builder.RegisterClientFactory<SearchClient, SearchClientOptions>(configuration);

        /// <summary>
        /// Registers a <see cref="SearchIndexClient"/> instance with the
        /// provided <paramref name="endpoint"/> and <paramref name="credential"/>.
        /// </summary>
        /// <typeparam name="TBuilder">Type of the client factory builder.</typeparam>
        /// <param name="builder">The client factory builder.</param>
        /// <param name="endpoint">
        /// Required.  The URI endpoint of the Search Service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// The URI must use HTTPS.
        /// </param>
        /// <param name="credential">
        /// Required.  The API key credential used to authenticate requests
        /// against the search service.  You need to use an admin key to
        /// modify the documents in a Search Index.  See
        /// <see href="https://docs.microsoft.com/azure/search/search-security-api-keys">Create and manage api-keys for an Azure Cognitive Search service</see>
        /// for more information about API keys in Azure Cognitive Search.
        /// </param>
        /// <returns>An Azure client builder.</returns>
        public static IAzureClientBuilder<SearchIndexClient, SearchClientOptions> AddSearchIndexClient<TBuilder>(
            this TBuilder builder,
            Uri endpoint,
            AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder =>
            builder.RegisterClientFactory<SearchIndexClient, SearchClientOptions>(
                options => new SearchIndexClient(endpoint, credential, options));

        /// <summary>
        /// Registers a <see cref="SearchIndexClient"/> instance with connection
        /// options loaded from the provided <paramref name="configuration"/>
        /// instance.
        /// </summary>
        /// <typeparam name="TBuilder">Type of the client factory builder.</typeparam>
        /// <typeparam name="TConfiguration">Type of the configuration.</typeparam>
        /// <param name="builder">The client factory builder.</param>
        /// <param name="configuration">The client configuration.</param>
        /// <returns>An Azure client builder.</returns>
        public static IAzureClientBuilder<SearchIndexClient, SearchClientOptions> AddSearchIndexClient<TBuilder, TConfiguration>(
            this TBuilder builder,
            TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration> =>
            builder.RegisterClientFactory<SearchIndexClient, SearchClientOptions>(configuration);
    }
}
