// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure;
using Azure.Core.Extensions;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.KnowledgeBases;

namespace Microsoft.Extensions.Azure
{
    public static partial class SearchClientBuilderExtensions
    {
        // Only DocumentsClientBuilderExtensions exposes these legacy signatures as public extensions.
        internal static IAzureClientBuilder<SearchClient, SearchClientOptions> AddSearchClient<TBuilder>(
            TBuilder builder, Uri endpoint, string indexName)
            where TBuilder : IAzureClientFactoryBuilderWithCredential =>
            builder.RegisterClientFactory<SearchClient, SearchClientOptions>(
                (options, credential) => new SearchClient(endpoint, indexName, credential, options));

        internal static IAzureClientBuilder<SearchIndexClient, SearchClientOptions> AddSearchIndexClient<TBuilder>(
            TBuilder builder, Uri endpoint)
            where TBuilder : IAzureClientFactoryBuilderWithCredential =>
            builder.RegisterClientFactory<SearchIndexClient, SearchClientOptions>(
                (options, credential) => new SearchIndexClient(endpoint, credential, options));

        internal static IAzureClientBuilder<SearchIndexerClient, SearchClientOptions> AddSearchIndexerClient<TBuilder>(
            TBuilder builder, Uri endpoint)
            where TBuilder : IAzureClientFactoryBuilderWithCredential =>
            builder.RegisterClientFactory<SearchIndexerClient, SearchClientOptions>(
                (options, credential) => new SearchIndexerClient(endpoint, credential, options));

        internal static IAzureClientBuilder<KnowledgeBaseRetrievalClient, SearchClientOptions> AddKnowledgeBaseRetrievalClient<TBuilder>(
            TBuilder builder, Uri endpoint, string knowledgeBaseName, AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder =>
            builder.RegisterClientFactory<KnowledgeBaseRetrievalClient, SearchClientOptions>(
                options => new KnowledgeBaseRetrievalClient(endpoint, knowledgeBaseName, credential, options));

        internal static IAzureClientBuilder<KnowledgeBaseRetrievalClient, SearchClientOptions> AddKnowledgeBaseRetrievalClient<TBuilder>(
            TBuilder builder, Uri endpoint, string knowledgeBaseName)
            where TBuilder : IAzureClientFactoryBuilderWithCredential =>
            builder.RegisterClientFactory<KnowledgeBaseRetrievalClient, SearchClientOptions>(
                (options, credential) => new KnowledgeBaseRetrievalClient(endpoint, knowledgeBaseName, credential, options));

        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        internal static IAzureClientBuilder<KnowledgeBaseRetrievalClient, SearchClientOptions> AddKnowledgeBaseRetrievalClient<TBuilder, TConfiguration>(
            TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration> =>
            builder.RegisterClientFactory<KnowledgeBaseRetrievalClient, SearchClientOptions>(configuration);
    }
}
