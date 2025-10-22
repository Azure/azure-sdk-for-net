// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[Experimental("AOAI001")]
[CodeGenType("ElasticsearchChatDataSourceParameters")]
internal partial class InternalElasticsearchChatDataSourceParameters
{
    [CodeGenMember("IncludeContexts")]
    private IList<string> InternalIncludeContexts { get; set; }
    private DataSourceOutputContexts? _outputContexts;

    /// <inheritdoc cref="DataSourceOutputContexts"/>
    public DataSourceOutputContexts? OutputContexts
    {
        get => DataSourceOutputContextsExtensions.FromStringList(InternalIncludeContexts);
        internal set
        {
            _outputContexts = value;
            InternalIncludeContexts = _outputContexts?.ToStringList();
        }
    }

#if !AZURE_OPENAI_GA
    /// <summary>
    /// The authentication options to use with the Elasticsearch data source.
    /// </summary>
    /// <remarks>
    /// Elasticsearch data sources support any of the following options:
    /// <list type="bullet">
    /// <item><see cref="DataSourceAuthentication.FromEncodedApiKey(string)"/></item>
    /// <item><see cref="DataSourceAuthentication.FromKeyAndKeyId(string,string)"/></item>
    /// </list>
    /// </remarks>
#else
#endif
    [CodeGenMember("Authentication")]
    public DataSourceAuthentication Authentication { get; set; }

    /// <summary> Gets the index field mappings. </summary>
    /// <remarks>
    /// Supported field mappings for Elasticsearch data sources include:
    /// <list type="bullet">
    /// <item><see cref="DataSourceFieldMappings.ContentFieldNames"/></item>
    /// <item><see cref="DataSourceFieldMappings.ContentFieldSeparator"/></item>
    /// <item><see cref="DataSourceFieldMappings.TitleFieldName"/></item>
    /// <item><see cref="DataSourceFieldMappings.UrlFieldName"/></item>
    /// <item><see cref="DataSourceFieldMappings.FilePathFieldName"/></item>
    /// <item><see cref="DataSourceFieldMappings.VectorFieldNames"/></item>
    /// </list>
    /// </remarks>
    [CodeGenMember("FieldsMapping")]
    public DataSourceFieldMappings FieldMappings { get; set; }

    /// <summary>
    /// Gets the query type.
    /// </summary>
    /// <remarks>
    /// Elasticsearch supports <see cref="DataSourceQueryType.Simple"/> and <see cref="DataSourceQueryType.Vector"/>.
    /// </remarks>
    [CodeGenMember("QueryType")]
    public DataSourceQueryType? QueryType { get; set; }

#if !AZURE_OPENAI_GA
    /// <summary>
    /// The vectorization dependency used for embeddings.
    /// </summary>
    /// <remarks>
    /// Supported vectorization dependencies for Elasticsearch data sources include:
    /// <list type="bullet">
    /// <item><see cref="DataSourceVectorizer.FromEndpoint(Uri, DataSourceAuthentication)"/></item>
    /// <item><see cref="DataSourceVectorizer.FromDeploymentName(string)"/></item>
    /// <item><see cref="DataSourceVectorizer.FromModelId(string)"/></item>
    /// </list>
    /// </remarks>
#else
    /// <summary>
    /// The vectorization dependency used for embeddings.
    /// </summary>
    /// <remarks>
    /// Supported vectorization dependencies for Elasticsearch data sources include:
    /// <list type="bullet">
    /// <item><see cref="DataSourceVectorizer.FromEndpoint(Uri, DataSourceAuthentication)"/></item>
    /// <item><see cref="DataSourceVectorizer.FromDeploymentName(string)"/></item>
    /// </list>
    /// </remarks>
#endif
    [CodeGenMember("EmbeddingDependency")]
    public DataSourceVectorizer VectorizationSource { get; set; }
}