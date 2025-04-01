// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;

namespace Azure.AI.OpenAI.Chat;

[Experimental("AOAI001")]
[CodeGenType("AzureSearchChatDataSourceParameters")]
internal partial class InternalAzureSearchChatDataSourceParameters
{
    [CodeGenMember("IncludeContexts")]
    private IList<string> _internalIncludeContexts = new ChangeTrackingList<string>();
    private DataSourceOutputContexts? _outputContexts;

    /// <inheritdoc cref="DataSourceOutputContexts"/>
    public DataSourceOutputContexts? OutputContexts
    {
        get => DataSourceOutputContextsExtensions.FromStringList(_internalIncludeContexts);
        internal set
        {
            _outputContexts = value;
            _internalIncludeContexts = _outputContexts?.ToStringList();
        }
    }

#if !AZURE_OPENAI_GA
    /// <summary>
    /// The authentication options to use with the Azure Search data source.
    /// </summary>
    /// <remarks>
    /// Azure Search data sources support any of the following options:
    /// <list type="bullet">
    /// <item><see cref="DataSourceAuthentication.FromApiKey(string)"/></item>
    /// <item><see cref="DataSourceAuthentication.FromAccessToken(string)"/></item>
    /// <item><see cref="DataSourceAuthentication.FromSystemManagedIdentity()"/></item>
    /// <item><see cref="DataSourceAuthentication.FromUserManagedIdentity(ResourceIdentifier)"/></item>
    /// </list>
    /// </remarks>
#else
    /// <summary>
    /// The authentication options to use with the Azure Search data source.
    /// </summary>
    /// <remarks>
    /// Azure Search data sources support any of the following options:
    /// <list type="bullet">
    /// <item><see cref="DataSourceAuthentication.FromApiKey(string)"/></item>
    /// <item><see cref="DataSourceAuthentication.FromSystemManagedIdentity()"/></item>
    /// <item><see cref="DataSourceAuthentication.FromUserManagedIdentity(ResourceIdentifier)"/></item>
    /// </list>
    /// </remarks>
#endif
    [CodeGenMember("Authentication")]
    public DataSourceAuthentication Authentication { get; set; }

    /// <summary> Gets the index field mappings. </summary>
    /// <remarks>
    /// Supported field mappings for Azure Search data sources include:
    /// <list type="bullet">
    /// <item><see cref="DataSourceFieldMappings.ContentFieldNames"/></item>
    /// <item><see cref="DataSourceFieldMappings.ContentFieldSeparator"/></item>
    /// <item><see cref="DataSourceFieldMappings.TitleFieldName"/></item>
    /// <item><see cref="DataSourceFieldMappings.UrlFieldName"/></item>
    /// <item><see cref="DataSourceFieldMappings.FilePathFieldName"/></item>
    /// <item><see cref="DataSourceFieldMappings.VectorFieldNames"/></item>
    /// <item><see cref="DataSourceFieldMappings.ImageVectorFieldNames"/></item>
    /// </list>
    /// </remarks>
    [CodeGenMember("FieldsMapping")]
    public DataSourceFieldMappings FieldMappings { get; set; }

    /// <summary> The query type for the Azure Search resource to use. </summary>
    [CodeGenMember("QueryType")]
    public DataSourceQueryType? QueryType { get; set; }

    /// <summary>
    /// The vectorization dependency used for embeddings.
    /// </summary>
    /// <remarks>
    /// Supported vectorization dependencies for Azure Search data sources include:
    /// <list type="bullet">
    /// <item><see cref="DataSourceVectorizer.FromEndpoint(Uri, DataSourceAuthentication)"/></item>
    /// <item><see cref="DataSourceVectorizer.FromDeploymentName(string)"/></item>
    /// </list>
    /// </remarks>
    [CodeGenMember("EmbeddingDependency")]
    public DataSourceVectorizer VectorizationSource { get; set; }
}
