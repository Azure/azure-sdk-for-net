// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Azure;
using Azure.Core.Extensions;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.KnowledgeBases;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Client registration extensions retained for backward compatibility.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class DocumentsClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="SearchClient"/> client. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The search service endpoint. </param>
        /// <param name="indexName"> The search index name. </param>
        /// <param name="credential"> The API key credential. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IAzureClientBuilder<SearchClient, SearchClientOptions> AddSearchClient<TBuilder>(
            this TBuilder builder, Uri endpoint, string indexName, AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder =>
            SearchClientBuilderExtensions.AddSearchClient(builder, endpoint, indexName, credential);

        /// <summary> Registers a <see cref="SearchClient"/> client using the builder's credential. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The search service endpoint. </param>
        /// <param name="indexName"> The search index name. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IAzureClientBuilder<SearchClient, SearchClientOptions> AddSearchClient<TBuilder>(
            this TBuilder builder, Uri endpoint, string indexName)
            where TBuilder : IAzureClientFactoryBuilderWithCredential =>
            SearchClientBuilderExtensions.AddSearchClient(builder, endpoint, indexName);

        /// <summary> Registers a <see cref="SearchClient"/> client. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration to use for the client. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<SearchClient, SearchClientOptions> AddSearchClient<TBuilder, TConfiguration>(
            this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration> =>
            SearchClientBuilderExtensions.AddSearchClient<TBuilder, TConfiguration>(builder, configuration);

        /// <summary> Registers a <see cref="SearchIndexClient"/> client. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The search service endpoint. </param>
        /// <param name="credential"> The API key credential. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IAzureClientBuilder<SearchIndexClient, SearchClientOptions> AddSearchIndexClient<TBuilder>(
            this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder =>
            SearchClientBuilderExtensions.AddSearchIndexClient(builder, endpoint, credential);

        /// <summary> Registers a <see cref="SearchIndexClient"/> client using the builder's credential. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The search service endpoint. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IAzureClientBuilder<SearchIndexClient, SearchClientOptions> AddSearchIndexClient<TBuilder>(
            this TBuilder builder, Uri endpoint)
            where TBuilder : IAzureClientFactoryBuilderWithCredential =>
            SearchClientBuilderExtensions.AddSearchIndexClient(builder, endpoint);

        /// <summary> Registers a <see cref="SearchIndexClient"/> client. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration to use for the client. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<SearchIndexClient, SearchClientOptions> AddSearchIndexClient<TBuilder, TConfiguration>(
            this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration> =>
            SearchClientBuilderExtensions.AddSearchIndexClient<TBuilder, TConfiguration>(builder, configuration);

        /// <summary> Registers a <see cref="SearchIndexerClient"/> client. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The search service endpoint. </param>
        /// <param name="credential"> The API key credential. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IAzureClientBuilder<SearchIndexerClient, SearchClientOptions> AddSearchIndexerClient<TBuilder>(
            this TBuilder builder, Uri endpoint, AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder =>
            SearchClientBuilderExtensions.AddSearchIndexerClient(builder, endpoint, credential);

        /// <summary> Registers a <see cref="SearchIndexerClient"/> client using the builder's credential. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The search service endpoint. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IAzureClientBuilder<SearchIndexerClient, SearchClientOptions> AddSearchIndexerClient<TBuilder>(
            this TBuilder builder, Uri endpoint)
            where TBuilder : IAzureClientFactoryBuilderWithCredential =>
            SearchClientBuilderExtensions.AddSearchIndexerClient(builder, endpoint);

        /// <summary> Registers a <see cref="SearchIndexerClient"/> client. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration to use for the client. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<SearchIndexerClient, SearchClientOptions> AddSearchIndexerClient<TBuilder, TConfiguration>(
            this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration> =>
            SearchClientBuilderExtensions.AddSearchIndexerClient<TBuilder, TConfiguration>(builder, configuration);

        /// <summary> Registers a <see cref="KnowledgeBaseRetrievalClient"/> client. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The search service endpoint. </param>
        /// <param name="knowledgeBaseName"> The knowledge base name. </param>
        /// <param name="credential"> The API key credential. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IAzureClientBuilder<KnowledgeBaseRetrievalClient, SearchClientOptions> AddKnowledgeBaseRetrievalClient<TBuilder>(
            this TBuilder builder, Uri endpoint, string knowledgeBaseName, AzureKeyCredential credential)
            where TBuilder : IAzureClientFactoryBuilder =>
            SearchClientBuilderExtensions.AddKnowledgeBaseRetrievalClient(builder, endpoint, knowledgeBaseName, credential);

        /// <summary> Registers a <see cref="KnowledgeBaseRetrievalClient"/> client using the builder's credential. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The search service endpoint. </param>
        /// <param name="knowledgeBaseName"> The knowledge base name. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IAzureClientBuilder<KnowledgeBaseRetrievalClient, SearchClientOptions> AddKnowledgeBaseRetrievalClient<TBuilder>(
            this TBuilder builder, Uri endpoint, string knowledgeBaseName)
            where TBuilder : IAzureClientFactoryBuilderWithCredential =>
            SearchClientBuilderExtensions.AddKnowledgeBaseRetrievalClient(builder, endpoint, knowledgeBaseName);

        /// <summary> Registers a <see cref="KnowledgeBaseRetrievalClient"/> client. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration to use for the client. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [RequiresUnreferencedCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        [RequiresDynamicCode("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static IAzureClientBuilder<KnowledgeBaseRetrievalClient, SearchClientOptions> AddKnowledgeBaseRetrievalClient<TBuilder, TConfiguration>(
            this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration> =>
            SearchClientBuilderExtensions.AddKnowledgeBaseRetrievalClient<TBuilder, TConfiguration>(builder, configuration);
    }
}
